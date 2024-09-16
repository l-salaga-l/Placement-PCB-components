using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Wires
    {
        private List<Wire> _wires;

        public List<Wire> ListWireRef
        {
            get { return _wires; }
            set { _wires = value; }
        }

        public Wires()
        {
            _wires = new List<Wire>();
        }
    }
}
