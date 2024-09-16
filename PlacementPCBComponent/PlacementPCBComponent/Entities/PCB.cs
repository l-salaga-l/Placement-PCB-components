using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class PCB
    {
        #region Поля

        private string _marking;
        private double _height;
        private double _width;
        private double _grid;
        private ForbiddenZones _forbiddenZones;

        #endregion

        #region Свойства

        /// <summary> Маркировка печатной платы </summary>
        public string Marking
        {
            get { return _marking; }
            set { _marking = value; }
        }

        /// <summary> Длина платы </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary> Ширина платы </summary>
        public double Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary> Размер сетки </summary>
        public double Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }

        /// <summary> Запрещенные зоны </summary>
        public ForbiddenZones ForbiddenZonesRef
        {
            get { return _forbiddenZones; }
            set { _forbiddenZones = value; }
        }

        #endregion

        public PCB() 
        {
            _forbiddenZones = new ForbiddenZones();
            _width = 0;
            _height = 0;
            _grid = 0;
        }

        public static PCB CreatePCB(string markingPCB, string height, string width)
        {
            PCB pcb = new PCB();
            pcb.Marking = markingPCB;
            pcb.Height = Double.Parse(height);
            pcb.Width = Double.Parse(width);

            return pcb;
        }
    }
}
