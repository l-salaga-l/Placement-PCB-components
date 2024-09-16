using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Components
    {
        private List<Component> _components;

        public List<Component> ListComponentsRef
        {
            get { return _components; }
            set { _components = value; }
        }

        public Components() 
        {
            _components = new List<Component>();
        }
    }
}
