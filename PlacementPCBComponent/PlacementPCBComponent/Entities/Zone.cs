using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Zone
    {
        private int _id;
        private string _name;
        private Components _components;
        private double _width;
        private double _height;
        private double _x;
        private double _y;

        public int Id
        {
            get => _id; set => _id = value;
        }

        public string Name
        {
            get => _name; set => _name = value;
        }

        public Components ComponentsRef
        {
            get => _components; set => _components = value;
        }

        public double Width
        {
            get => _width; set => _width = value;
        }

        public double Height
        {
            get => _height; set => _height = value;
        }

        public double X
        {
            get => _x; set => _x = value;
        }

        public double Y
        {
            get => _y; set => _y = value;
        }

        public Zone() 
        {
            _components = new Components();
            _width = 0;
            _height = 0;
            _x = 0;
            _y = 0;
        }
    }
}
