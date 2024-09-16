using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using VKR.Entities;

namespace VKR.Tools
{
    /// <summary> Инструмент для сохранения файла </summary>
    public class ToolForSave
    {
        public ToolForSave() { }

        /// <summary> Метод для сохранения данных в файл </summary>
        /// <param name="filename"> Путь к файлу </param>
        public void Save(string filename) 
        {
            string _extension = Path.GetExtension(filename);
            if (_extension == ".DDC")
            {
                SaveDDC(filename);
            }
            else if (_extension == ".xml")
            {
                SaveXML(filename);
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

        private void SaveXML(string filename) 
        {
            try
            {
                // передаем в конструктор тип класса Project
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Project));

                // получаем поток, куда будем записывать сериализованный объект
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    // сериализация данных
                    xmlSerializer.Serialize(fs, Project.instance);
                }
            }
            // выводим ошибку
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SaveDDC(string filename)
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
                var designs = GetNodeByName(сomponent, "Designs");
                var netlist = GetNodeByName(designs, "Netlist");
                var views = GetNodeByName(netlist, "Views");
                var pcbBoard = GetNodeByName(views, "PcbBoard");
                var pcbComponents = GetNodeByName(pcbBoard, "PcbComponents") ?? throw new Exception("Разместите все элементы на PCB");
                
                foreach (XmlNode component in pcbComponents.ChildNodes)
                {
                    string designator = component.Attributes["Designator"].InnerText;

                    double x = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(a => a.Designator == designator).X;
                    double y = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(a => a.Designator == designator).Y;

                    string location = $"{x};{y}".Replace(',', '.');
                    component.Attributes["Location"].InnerText = location;
                }
            }
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                _xDoc.Save(fs);
            }
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
