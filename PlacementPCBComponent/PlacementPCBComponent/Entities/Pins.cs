using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Pins
    {
        private List<Pin> _pins;

        public List<Pin> ListofPinsRef
        {
            get { return _pins; }
            set { _pins = value; }
        }

        public Pins() 
        {
            _pins = new List<Pin>();
        }
    }
}
