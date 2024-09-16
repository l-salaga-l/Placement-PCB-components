using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class ForbiddenZone
    {
        private int _id;
        private string _name;
        private double _width;
        private double _height;
        private double _x;
        private double _y;

        public int Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }

        public string Name
        { 
            get { return _name; } 
            set {  _name = value; } 
        }

        public double Width
        { 
            get { return _width; } 
            set {  _width = value; } 
        }

        public double Height
        { 
            get { return _height; }
            set { _height = value; }
        }

        public double X
        { 
            get { return _x; } 
            set {  _x = value; } 
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public ForbiddenZone() { }
    }
}
