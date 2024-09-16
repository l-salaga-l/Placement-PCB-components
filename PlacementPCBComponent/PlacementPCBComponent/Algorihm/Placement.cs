using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VKR.Entities;
using VKR.Tools;

namespace VKR.Algorihm
{
    public class Placement
    {
        public Placement() { }

        public void Start()
        {
            if (Project.instance.ZonesRef.ListofZonesRef.Count > 0) 
            {
                WithZones();
            }
            else
            {
                WithoutZones();
            }
        }

        private void WithZones()
        {
            foreach (Zone zone in Project.instance.ZonesRef.ListofZonesRef)
            {
                KohonenNetwork kohonenNetwork_1 = new KohonenNetwork();
                kohonenNetwork_1.SizeArea = new Size(zone.Width, zone.Height);
                kohonenNetwork_1.AlgorithmParametersRef = Project.instance.AlgorithmParametersRef;
                kohonenNetwork_1.Grid = Project.instance.PCB.Grid;
                kohonenNetwork_1.NeuronsRef = GetNeurons(zone);

                Neurons result = kohonenNetwork_1.Iterations();
                SetCoordinatesComponent(result);
                IncreaseAreaZone(zone);
            }

            KohonenNetwork kohonenNetwork_2 = new KohonenNetwork();
            kohonenNetwork_2.SizeArea = new Size(Project.instance.PCB.Width, Project.instance.PCB.Height);
            kohonenNetwork_2.AlgorithmParametersRef = Project.instance.AlgorithmParametersRef;
            kohonenNetwork_2.Grid = Project.instance.PCB.Grid;
            kohonenNetwork_2.NeuronsRef = GetNeurons(Project.instance.ZonesRef, Project.instance.PCB.ForbiddenZonesRef);

        }

        public void WithoutZones()
        {
            KohonenNetwork kohonenNetwork = new KohonenNetwork();
            kohonenNetwork.SizeArea = new Size(Project.instance.PCB.Width, Project.instance.PCB.Height);
            kohonenNetwork.AlgorithmParametersRef = Project.instance.AlgorithmParametersRef;
            kohonenNetwork.Grid = Project.instance.PCB.Grid;
            kohonenNetwork.NeuronsRef = GetNeurons(Project.instance.Scheme.ComponentsRef);

            Neurons result = kohonenNetwork.Iterations();
            SetCoordinatesComponent(result);
            Util.GetCoordinate();
            Util.GetZones();
            Util.GetSizeZones();
            Util.ResetAngle();
        }

        private void SetCoordinatesComponent(Neurons neurons)
        {
            foreach (Neuron neuron in neurons.NeuronRef)
            {
                Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == neuron.Id).X = neuron.X;
                Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == neuron.Id).Y = neuron.Y;
            }
        }

        private Neurons GetNeurons(Components components)
        {
            Neurons neurons = new Neurons();
            foreach (Entities.Component component in components.ListComponentsRef)
            {
                Neuron neuron = new Neuron();
                neuron.Width = component.Footprint.Width;
                neuron.Height = component.Footprint.Height;
                neuron.Power = component.PowerDissipation;
                neuron.Id = component.Designator;
                neuron.Possibility = true;

                List<(PinNeuron, PinNeuron)> pinNeurons = new List<(PinNeuron, PinNeuron)>();
                foreach (Pin pin in component.PinsRef.ListofPinsRef)
                {
                    PinNeuron pinNeuron_i = new PinNeuron();
                    pinNeuron_i.Id = pin.Id;
                    pinNeuron_i.X = pin.X;
                    pinNeuron_i.Y = pin.Y;
                    pinNeuron_i.IdNeuron = component.Designator;

                    List<PinNeuron> pins_connected = GetConnected(pin, component);

                    if (pins_connected == null) continue;

                    foreach (PinNeuron pinNeuron_j in pins_connected)
                    {
                        pinNeurons.Add((pinNeuron_i, pinNeuron_j));
                    }
                }

                neuron.Connection = pinNeurons;

                neurons.NeuronRef.Add(neuron);
            }
            return neurons;
        }

        private Neurons GetNeurons(Zone zone)
        {
            Neurons neurons = new Neurons();
            foreach (Entities.Component component in zone.ComponentsRef.ListComponentsRef)
            {
                Neuron neuron = new Neuron();
                neuron.Width = component.Footprint.Width;
                neuron.Height = component.Footprint.Height;
                neuron.Power = component.PowerDissipation;
                neuron.Id = component.Designator;
                neuron.Possibility = true;

                List<(PinNeuron, PinNeuron)> pinNeurons = new List<(PinNeuron, PinNeuron)>();
                foreach (Pin pin in component.PinsRef.ListofPinsRef)
                {
                    PinNeuron pinNeuron_i = new PinNeuron();
                    pinNeuron_i.Id = pin.Id;
                    pinNeuron_i.X = pin.X;
                    pinNeuron_i.Y = pin.Y;
                    pinNeuron_i.IdNeuron = component.Designator;

                    List<PinNeuron> pins_connected = GetConnectedinZone(pin, component);

                    if (pins_connected == null) continue;

                    foreach (PinNeuron pinNeuron_j in pins_connected)
                    {
                        pinNeurons.Add((pinNeuron_i, pinNeuron_j));
                    }
                }

                neuron.Connection = pinNeurons;

                neurons.NeuronRef.Add(neuron);
            }
            return neurons;
        }

        private Neurons GetNeurons(Zones zones, ForbiddenZones forbiddenZones)
        {
            Neurons neurons = new Neurons();
            
            foreach (Zone zone in zones.ListofZonesRef)
            {
                Neuron neuron = new Neuron();
                neuron.Width = zone.Width;
                neuron.Height = zone.Height;
                neuron.Power = GetPowerDissipation(zone);
                neuron.Id = $"Зона {zone.Id}";
                neuron.Possibility = true;

                neurons.NeuronRef.Add(neuron);
            }

            foreach (ForbiddenZone forbiddenZone in  forbiddenZones.ListForbiddenZoneRef)
            {
                Neuron neuron = new Neuron();
                neuron.Width = forbiddenZone.Width;
                neuron.Height = forbiddenZone.Height;
                neuron.X = forbiddenZone.X;
                neuron.Y = forbiddenZone.Y;
                neuron.Power = 0;
                neuron.Id = $"Запрещенная зона {forbiddenZone.Id}";
                neuron.Possibility = false;

                neurons.NeuronRef.Add(neuron);
            }

            return neurons;
        }

        private double GetPowerDissipation(Zone zone)
        {
            double power = 0;
            foreach (Entities.Component component in zone.ComponentsRef.ListComponentsRef)
            {
                power += component.PowerDissipation;
            }
            return power;
        }

        private List<PinNeuron> GetConnected(Pin pin, Entities.Component component)
        {
            if (Project.instance.Scheme.WiresRef.ListWireRef.Find(x => x.IdPin == pin.Id && x.Designator == component.Designator) != null)
            {
                string name = Project.instance.Scheme.WiresRef.ListWireRef.Find(x => x.IdPin == pin.Id && x.Designator == component.Designator).Id;

                List<Wire> wires = Project.instance.Scheme.WiresRef.ListWireRef.FindAll(x => x.Id == name);

                List<PinNeuron> pins = new List<PinNeuron>();
                foreach (Wire w in wires)
                {
                    if (w.IdPin != pin.Id || w.Designator != component.Designator)
                    {
                        PinNeuron pinNeuron = new PinNeuron();
                        pinNeuron.Id = w.IdPin;
                        pinNeuron.IdNeuron = w.Designator;
                        (pinNeuron.X, pinNeuron.Y) = GetCoordinate(w.IdPin, w.Designator);
                        pins.Add(pinNeuron);
                    }
                }

                return pins;
            }
            else return null;
        }

        private List<PinNeuron> GetConnectedinZone(Pin pin, Entities.Component component)
        {
            if (Project.instance.Scheme.WiresRef.ListWireRef.Find(x => x.IdPin == pin.Id && x.Designator == component.Designator) != null)
            {
                string name = Project.instance.Scheme.WiresRef.ListWireRef.Find(x => x.IdPin == pin.Id && x.Designator == component.Designator).Id;

                List<Wire> wires = Project.instance.Scheme.WiresRef.ListWireRef.FindAll(x => x.Id == name);

                List<PinNeuron> pins = new List<PinNeuron>();
                foreach (Wire w in wires)
                {
                    if (w.IdPin != pin.Id || w.Designator != component.Designator)
                    {
                        if (Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == w.Designator).CodeZone == component.CodeZone)
                        {
                            PinNeuron pinNeuron = new PinNeuron();
                            pinNeuron.Id = w.IdPin;
                            pinNeuron.IdNeuron = w.Designator;
                            (pinNeuron.X, pinNeuron.Y) = GetCoordinate(w.IdPin, w.Designator);
                            pins.Add(pinNeuron);
                        }
                    }
                }

                return pins;
            }
            else return null;
        }

        private (double, double) GetCoordinate(int idpin, string designator)
        {
            Entities.Component component = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == designator);
            Pin pin = component.PinsRef.ListofPinsRef.Find(x => x.Id == idpin);

            return (pin.X, pin.Y);
        }

        private void IncreaseAreaZone(Zone zone)
        {
            double x_max = 0;
            double x_min = double.MaxValue;
            double y_max = 0;
            double y_min = double.MaxValue;

            foreach (var component in zone.ComponentsRef.ListComponentsRef)
            {
                Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).ComponentsRef.ListComponentsRef
                            .Find(x => x.Designator == component.Designator).X = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == component.Designator).X;
                Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).ComponentsRef.ListComponentsRef
                    .Find(x => x.Designator == component.Designator).Y = Project.instance.Scheme.ComponentsRef.ListComponentsRef.Find(x => x.Designator == component.Designator).Y;

                if (x_max < component.X + component.Footprint.Width / 2)
                {
                    x_max = component.X + component.Footprint.Width / 2;
                }
                if (x_min > component.X - component.Footprint.Width / 2)
                {
                    x_min = component.X - component.Footprint.Width / 2;
                }
                if (y_max < component.Y + component.Footprint.Height / 2)
                {
                    y_max = component.Y + component.Footprint.Height / 2;
                }
                if (y_min > component.Y - component.Footprint.Height / 2)
                {
                    y_min = component.Y - component.Footprint.Height / 2;
                }
            }

            Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).Width = x_max - x_min;
            Project.instance.ZonesRef.ListofZonesRef.Find(x => x.Id == zone.Id).Height = y_max - y_min;
        }
    }
}
