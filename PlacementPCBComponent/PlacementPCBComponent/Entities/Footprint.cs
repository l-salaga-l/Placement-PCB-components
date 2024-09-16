using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Footprint
    {
        private string _name;
        private double _height;
        private double _width;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public Footprint() 
        {
            _width = 0;
            _height = 0;
        }
    }
}
