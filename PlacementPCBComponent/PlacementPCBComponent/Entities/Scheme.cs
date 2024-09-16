using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Scheme
    {
        #region Поля

        private string _name;
        private Wires _wires;
        private Components _components;

        #endregion

        #region Свойства

        /// <summary> Название схемы </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary> Компоненты </summary>
        public Components ComponentsRef
        {
            get { return _components; }
            set { _components = value; }
        }

        /// <summary> Цепи </summary>
        public Wires WiresRef
        {
            get { return _wires; }
            set { _wires = value; }
        }

        #endregion

        public Scheme() 
        {
            _components = new Components();
            _wires = new Wires();
        }

        public static Scheme CreateScheme(string schemeID, Wires wires = null, Components components = null)
        {
            Scheme scheme = new Scheme();
            scheme.Name = schemeID;
            scheme.WiresRef = wires;
            scheme.ComponentsRef = components;

            return scheme;
        }
    }
}
