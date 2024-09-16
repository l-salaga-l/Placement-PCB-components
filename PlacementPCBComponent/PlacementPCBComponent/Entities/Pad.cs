using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Pad
    {
        private int _padNumber;
        private double _xLocation;
        private double _yLocation;

        public int PadNumber
        {
            get { return _padNumber; }
            set { _padNumber = value; }
        }
        public double XLocation
        {
            get { return _xLocation; }
            set { _xLocation = value; }
        }
        public double YLocation
        {
            get { return _yLocation; }
            set { _yLocation = value; }
        }
        public Pad() 
        {
            _xLocation = 0;
            _yLocation = 0;
        }
    }
}
