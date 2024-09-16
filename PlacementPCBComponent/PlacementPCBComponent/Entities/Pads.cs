using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Pads
    {
        private List<Pad> _pads;

        public List<Pad> PadRef
        {
            get { return _pads; }
            set { _pads = value; }
        }

        public Pads() 
        {
            _pads = new List<Pad>();
        }
    }
}
