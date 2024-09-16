using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class AlgorithmParameters
    {
        private double _a1;
        private double _a2;
        private double _a3;
        private double _t_max;
        private double _nu0;

        public double A1
        {
            get => _a1; set => _a1 = value;
        }

        public double A2
        {
            get => _a2; set => _a2 = value;
        }

        public double A3
        {
            get => _a3; set => _a3 = value;
        }

        public double T_max
        {
            get => _t_max; set => _t_max = value;
        }

        public double Nu0
        {
            get => _nu0; set => _nu0 = value;
        }

        public AlgorithmParameters() 
        {
            _a1 = 0.0;
            _a2 = 0.0;
            _a3 = 0.0;
            _t_max = 0.0;
            _nu0 = 0.0;
        }
    }
}
