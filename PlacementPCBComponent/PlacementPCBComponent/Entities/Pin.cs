using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Pin
    {
        #region Поля

        private int _id;
        private int _padNumber;
        private double _x;
        private double _y;

        #endregion

        #region Свойства

        /// <summary> Номер вывода компонента </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int PadNumber
        {
            get { return _padNumber; }
            set { _padNumber = value; }
        }

        /// <summary> Координата по оси Х </summary>
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary> Координата по оси У </summary>
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        #endregion

        public Pin() { }
    }
}
