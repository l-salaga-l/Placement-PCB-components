using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Wire
    {
        #region Поля

        private string _id;
        private string _designator;
        private int _idPin;

        #endregion

        #region Свойства

        /// <summary> Код цепи </summary>
        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary> Обозначение компонента </summary>
        public string Designator
        {
            get { return _designator; }
            set { _designator = value; }
        }

        /// <summary> Номер вывода компонента </summary>
        public int IdPin
        {
            get { return _idPin; }
            set { _idPin = value; }
        }

        #endregion

        public Wire() { }
    }
}
