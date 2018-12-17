using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Entities
{
    /// <summary>
    /// Building - 
    /// </summary>
    [Serializable]
    public class Building : System.Object
    {
        public string _name; 

        Building(string name)
        {
            _name = name;
        }
    }
}
