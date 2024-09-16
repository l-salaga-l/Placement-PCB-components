using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class ForbiddenZones
    {
        private List<ForbiddenZone> _forbiddenZones;

        public List<ForbiddenZone> ListForbiddenZoneRef
        {
            get { return _forbiddenZones; }
            set { _forbiddenZones = value; }
        }

        public ForbiddenZones() 
        {
            _forbiddenZones = new List<ForbiddenZone>();
        }
    }
}
