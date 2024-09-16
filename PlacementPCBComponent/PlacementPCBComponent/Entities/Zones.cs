using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Zones
    {
        private List<Zone> _zones;

        public List<Zone> ListofZonesRef
        {
            get => _zones;
            set => _zones = value;
        }

        public Zones() 
        {
            _zones = new List<Zone>();
        }
    }
}
