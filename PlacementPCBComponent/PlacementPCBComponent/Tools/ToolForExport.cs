using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using VKR.Entities;

namespace VKR.Tools
{
    public class ToolForExport
    {
        public ToolForExport() { }

        public void Export(string filename)
        {
            string _extension = Path.GetExtension(filename);
            if (_extension == ".DDC")
            {
                ParsingProjectFile(filename);
            }
            else if (_extension == ".xml")
            {
                Deserialization(filename);
            }
            else
            {
                MessageBox.Show(
                    "Ошибка в открытии файла!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        private void ParsingProjectFile(string filename)
        {
            XmlDocument _xDoc = new XmlDocument();
            XmlElement _xRoot = null;

            try
            {
                _xDoc.Load(filename);
                _xRoot = _xDoc.DocumentElement;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка в загрузке DDC файла",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            if (_xRoot != null)
            {
                var сomponents = GetNodeByName(_xRoot, "Components");
                var сomponent = GetNodeByName(сomponents, "Component");
                var parts = GetNodeByName(сomponent, "Parts");
                var part = GetNodeByName(parts, "Part");
                var partName = GetNodeByAttribute(part, "Attribute", "Name", "PartName");
                var designs = GetNodeByName(сomponent, "Designs");
                var netlist = GetNodeByName(designs, "Netlist");
                var views = GetNodeByName(netlist, "Views");
                var componentInstances = GetNodeByName(netlist, "ComponentInstances");
                var pcbBoard = GetNodeByName(views, "PcbBoard");
                var pcbComponents = GetNodeByName(pcbBoard, "PcbComponents") ?? throw new Exception("Разместите все элементы на PCB");
                var footprintPatterns = GetNodeByName(pcbBoard, "FootprintPatterns");
                var pcbNets = GetNodeByName(pcbBoard, "PcbNets");
                var schematic = GetNodeByName(views, "Schematic");
                var schematicComponents = GetNodeByName(schematic, "SchematicComponents");

                if (pcbComponents.ChildNodes.Count != schematicComponents.ChildNodes.Count)
                {
                    throw new Exception("Разместите все элементы на PCB");
                }

                Project.CreateProject(partName.InnerText);

                PCB pcb = GetPcb(pcbBoard);
                pcb.Marking = partName.InnerText;
                Project.instance.PCB = pcb;

                Dictionary<Footprint, Pads> footprintsProject = GetFootprintsProject(footprintPatterns);

                Dictionary<Component, Pins> componentsProject = GetComponentsProject(componentInstances);

                Components componentsPcb = GetComponentsPcb(pcbComponents, footprintsProject, componentsProject);

                Wires wires = GetWires(pcbNets, componentsPcb);
                Scheme scheme = new Scheme();
                scheme.WiresRef = wires;
                scheme.ComponentsRef = componentsPcb;
                scheme.Name = partName.InnerText;
                Project.instance.Scheme = scheme;
            }
        }

        /// <summary> Десериализация файла </summary>
        /// <param name="filename"></param>
        private void Deserialization(string filename)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Project));

                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    Project.CreateProject();
                    // десериализуем объект
                    Project.instance = xmlSerializer.Deserialize(fs) as Project;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка в десериализации файла",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private PCB GetPcb(XmlNode pcbBoard)
        {
            PCB pcb = new PCB();

            //if (pcbBoard.Attributes["DeviceCode"].Value != null) 
            //{
            //    pcb.Marking = pcbBoard.Attributes["DeviceCode"].InnerText;
            //}

            var outlineDrawData = GetNodeByName(pcbBoard, "OutlineDrawData");
            var boardOutlineFigure = GetNodeByName(outlineDrawData, "BoardOutlineFigure");
            var rectangleG = GetNodeByName(boardOutlineFigure, "RectangleG");

            if (double.TryParse(rectangleG.Attributes["Width"].InnerText.Replace('.', ','), out double width))
            {
                pcb.Width = width;

            }
            if (double.TryParse(rectangleG.Attributes["Height"].InnerText.Replace('.', ','), out double height))
            {
                pcb.Height = height;
            }

            return pcb;
        }

        private Wires GetWires(XmlNode pcbNets, Components componentsPcb)
        {
            Wires wiresPcb = new Wires();
            wiresPcb.ListWireRef = new List<Wire>();
            foreach (XmlNode pcbNet in pcbNets.ChildNodes)
            {
                string id = pcbNet.Attributes["Name"].InnerText;
                if (id != "GND")
                {
                    var pcbPads = GetNodeByName(pcbNet, "PcbPads")
                        .ChildNodes
                        .Cast<XmlNode>()
                        .Select(x => (x.Attributes["Component"].InnerText, x.Attributes["Pad"].InnerText))
                        .ToList();

                    foreach (var pcbPad in pcbPads)
                    {
                        Wire new_wire = new Wire();

                        new_wire.Id = id;
                        new_wire.Designator = pcbPad.Item1 as string;
                        var component = componentsPcb.ListComponentsRef.Find(x => x.Designator == pcbPad.Item1 as string);
                        var pin = component.PinsRef.ListofPinsRef.Find(x => x.PadNumber.ToString() == pcbPad.Item2);
                        new_wire.IdPin = pin.Id;
                        wiresPcb.ListWireRef.Add(new_wire);
                    }
                }
            }


            return wiresPcb;
        }

        private Components GetComponentsPcb(XmlNode componentsPcbFile, Dictionary<Footprint, Pads> footprintsProject, Dictionary<Component, Pins> componentsProject)
        {
            Components componentsPcb = new Components();
            componentsPcb.ListComponentsRef = new List<Component>();
            foreach (XmlNode componentPcbFile in componentsPcbFile.ChildNodes)
            {
                Component new_component = new Component();

                var designator = GetNodeByName(componentPcbFile, "Designator").InnerText;
                var location = componentPcbFile.Attributes["Location"].Value as string;
                string[] coordinates = location == null ? null : location.Split(';');

                if (componentPcbFile.Attributes["Angle"] != null)
                {
                    new_component.Angle = int.Parse(componentPcbFile.Attributes["Angle"].Value as string);
                }
                else
                {
                    new_component.Angle = 0;
                }

                if (coordinates != null)
                {
                    new_component.X = double.Parse(coordinates[0].Replace('.', ','));
                    new_component.Y = double.Parse(coordinates[1].Replace('.', ','));
                }


                foreach (Component component in componentsProject.Keys)
                {
                    if (component.Designator == designator)
                    {
                        new_component.Designator = designator;
                        new_component.Marking = component.Marking;
                        new_component.PinsRef = componentsProject[component];
                    }
                }

                var patterIdXmlNode = GetNodeByName(componentPcbFile, "PatternId");
                var patternId = patterIdXmlNode.Attributes["Name"].InnerText;
                foreach (Footprint footprint in footprintsProject.Keys)
                {
                    if (footprint.Name == patternId)
                    {
                        new_component.Footprint = footprint;
                        foreach (Pad pad in footprintsProject[footprint].PadRef)
                        {
                            if (new_component.PinsRef.ListofPinsRef.Find(x => x.PadNumber == pad.PadNumber) != null)
                            {
                                new_component.PinsRef.ListofPinsRef.Find(x => x.PadNumber == pad.PadNumber).X = pad.XLocation;
                                new_component.PinsRef.ListofPinsRef.Find(x => x.PadNumber == pad.PadNumber).Y = pad.YLocation;
                            }
                        }
                    }
                }

                componentsPcb.ListComponentsRef.Add(new_component);
            }
            return componentsPcb;
        }

        private Dictionary<Footprint, Pads> GetFootprintsProject(XmlNode footprintPatterns)
        {
            Dictionary<Footprint, Pads> footprints = new Dictionary<Footprint, Pads>();
            if (footprintPatterns != null)
            {
                foreach (XmlNode footprint in footprintPatterns)
                {
                    Footprint new_footprint = new Footprint();
                    Pads new_pads = new Pads();

                    var internalFootprint = GetNodeByName(footprint, "InternalFootprint");
                    new_footprint.Name = internalFootprint.Attributes["Name"].InnerText;

                    XmlNode technologyItem = GetNodeByAttribute(internalFootprint, "TechnologyItem", "Technology", "Default");
                    XmlNode graphicData = technologyItem != null ? GetNodeByName(technologyItem, "GraphicData") : null;
                    XmlNode rectangleG = graphicData != null ? GetNodeByName(graphicData, "RectangleG") : null;

                    if (rectangleG != null)
                    {
                        if (double.TryParse(rectangleG.Attributes["Width"].InnerText.Replace('.', ','), out double width))
                        {
                            new_footprint.Width = width;
                        }
                        if (double.TryParse(rectangleG.Attributes["Height"].InnerText.Replace('.', ','), out double height))
                        {
                            new_footprint.Height = height;
                        }
                    }

                    var pads = GetNodeByName(internalFootprint, "Pads");
                    
                    foreach (XmlNode padRef in pads.ChildNodes)
                    {
                        if (padRef.Attributes.Count > 0)
                        {
                            Pad new_pad = new Pad();
                            if (int.TryParse(padRef.Attributes["PadNumber"].InnerText, out int padNumber))
                            {
                                new_pad.PadNumber = padNumber;
                            }
                            if (padRef.Attributes["Location"] != null)
                            {
                                string location = padRef.Attributes["Location"].InnerText;
                                string[] coordinates = location.Split(';');
                                if (double.TryParse(coordinates[0].Replace('.', ','), out double x))
                                {
                                    new_pad.XLocation = x;
                                }
                                if (double.TryParse(coordinates[1].Replace('.', ','), out double y))
                                {
                                    new_pad.YLocation = y;
                                }
                            }

                            new_pads.PadRef.Add(new_pad);
                        }
                    }

                    footprints.Add(new_footprint, new_pads);
                }

            }

            return footprints;
        }

        private Dictionary<Component, Pins> GetComponentsProject(XmlNode componentInstances)
        {
            Dictionary<Component, Pins> components = new Dictionary<Component, Pins>();

            foreach (XmlNode component in componentInstances.ChildNodes) 
            {
                Component new_component = new Component();
                Pins new_pins = new Pins();

                new_component.Designator = component.Attributes["Designator"].Value;
                var componentRef = GetNodeByName(component, "ComponentRef");

                if (componentRef != null)
                {
                    new_component.Marking = componentRef.Attributes["Component"].InnerText;
                }

                var pins = GetNodeByName(component, "Pins");

                foreach (XmlNode pin in pins.ChildNodes)
                {
                    Pin new_pin = new Pin();
                    if (int.TryParse(pin.Attributes["Id"].InnerText, out int id))
                    {
                        new_pin.Id = id;
                    }
                    if (int.TryParse(pin.Attributes["PadNumber"].InnerText, out int padNumber))
                    {
                        new_pin.PadNumber = padNumber;
                        new_pins.ListofPinsRef.Add(new_pin);
                    }
                    else
                    {
                        string[] ids = pin.Attributes["PadNumber"].InnerText.Split(',');
                        for (int i = 0; i < ids.Length; i++)
                        {
                            Pin pin_ = new Pin();
                            pin_.Id = new_pin.Id;
                            pin_.PadNumber = int.Parse(ids[i]);
                            new_pins.ListofPinsRef.Add(pin_);
                        }
                    }
                }
                components.Add(new_component, new_pins);
            }

            return components;
        }

        private XmlNode GetNodeByName(XmlNode root, string name)
        {
            XmlNode node = null;

            foreach (XmlNode xNode in root)
            {
                if (xNode.Name.Equals(name))
                {
                    node = xNode; break;
                }
            }

            return node;
        }

        private XmlNode GetNodeByAttribute(XmlNode root, string nodeName, string attributeName, string attributeValue)
        {
            List<XmlNode> nodes = new List<XmlNode>();

            foreach (XmlNode xNode in root)
            {
                if (xNode.Name.Equals(nodeName))
                {
                    nodes.Add(xNode);
                }
            }

            if (nodes.Count == 0) return null;

            foreach (XmlNode node in nodes)
            {
                XmlAttribute attribute = node.Attributes[attributeName];
                if (attribute != null && attribute.Value == attributeValue)
                    return node;
            }

            return null;
        }
    }
}
