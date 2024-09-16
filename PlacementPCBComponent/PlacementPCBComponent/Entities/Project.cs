using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace VKR.Entities
{
    [Serializable]
    public class Project
    {
        #region Поля

        public static Project instance;
        private string _name = String.Empty;
        private bool _isCreated = false;
        private Scheme _scheme;
        private PCB _pcb;
        private Zones _zones;
        private AlgorithmParameters _algorithmParameters;

        #endregion

        #region Свойства

        public bool IsCreated 
        { 
            get { return _isCreated; } 
            set { _isCreated = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Scheme Scheme 
        {
            get { return _scheme; }
            set { _scheme = value; }
        }

        public PCB PCB 
        { 
            get { return _pcb; }
            set { _pcb = value; }
        }

        public Zones ZonesRef
        {
            get { return _zones; }
            set { _zones = value; }
        }

        public AlgorithmParameters AlgorithmParametersRef
        {
            get { return _algorithmParameters; }
            set { _algorithmParameters = value; }
        }

        #endregion

        #region Методы

        public Project() 
        {
            instance = this;

            _zones = new Zones();
            _pcb = new PCB();
            _scheme = new Scheme();
            _algorithmParameters = new AlgorithmParameters();
        }

        public static void CreateProject(string Name = "")
        {
            Project project = new Project();
            project.Name = Name;
            project.IsCreated = true;
        }

        #endregion
    }
}
