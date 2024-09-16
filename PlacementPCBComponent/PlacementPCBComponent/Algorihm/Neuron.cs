using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKR.Entities;

namespace VKR.Algorihm
{
    public class Neuron
    {
        private string _id;
        private double _width;
        private double _height;
        private double _x;
        private double _y;
        private bool _possibility;
        private double power_dissipation;
        private List<(PinNeuron, PinNeuron)> _connection;

        public string Id 
        { 
            get { return _id; } 
            set { _id = value; } 
        }

        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Power
        {
            get { return power_dissipation; }
            set { power_dissipation = value; }
        }

        public bool Possibility
        {
            get { return _possibility; }
            set { _possibility = value; }
        }

        public List<(PinNeuron, PinNeuron)> Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        public Neuron() { }
    }

    public class PinNeuron
    {
        private string _idNeuron;
        private int _id;
        private double _x;
        private double _y;

        public string IdNeuron
        {
            get => _idNeuron;
            set { _idNeuron = value; }
        }
        public int Id
        {
            get => _id;
            set { _id = value; }
        }

        public double X
        {
            get => _x;
            set { _x = value; }
        }
        public double Y
        {
            get => _y;
            set { _y = value; }
        }
    }
}
