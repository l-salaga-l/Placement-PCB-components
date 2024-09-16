using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Algorihm
{
    public class Neurons
    {
        private List<Neuron> _neurons;

        public List<Neuron> NeuronRef
        {
            get { return _neurons; }
            set { _neurons = value; }
        }

        public Neurons()
        {
            _neurons = new List<Neuron>();
        }
    }
}
