using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Component
    {
        private string _marking;
        private string _designator;
        private double _powerDissipation;
        private int _code_zone;
        private Pins _pins;
        private Footprint _footprint;
        private double _x = 0;
        private double _y = 0;
        private int _angle;

        public string Marking
        {
            get { return _marking; }
            set { _marking = value; }
        }
        public string Designator 
        { 
            get { return _designator; }
            set { _designator = value; }
        }
        public double PowerDissipation
        {
            get { return _powerDissipation; }
            set { _powerDissipation = value; }
        }
        public Pins PinsRef
        {
            get { return _pins; }
            set { _pins = value; }
        }
        public Footprint Footprint
        {
            get { return _footprint; }
            set { _footprint = value; }
        }
        public int Angle
        {
            get => _angle; set { _angle = value; }
        }

        public int CodeZone
        {
            get => _code_zone; set { _code_zone = value; }
        }

        public double X
        {
            get => _x; set { _x = value;}
        }

        public double Y
        {
            get => _y; set { _y = value;}
        }

        public Component() 
        {
            _pins = new Pins();
            _powerDissipation = 0;
            _x = 0;
            _y = 0;
            _code_zone = 0;
        }

        public void AddPin(Pin pin)
        {
            if (!PinsRef.ListofPinsRef.Contains(pin))
            {
                PinsRef.ListofPinsRef.Contains(pin);
            }
        }

        public void AddPin(List<Pin> pins) 
        {
            foreach (Pin pin in pins)
            {
                AddPin(pin);
            }
        }
    }
}
