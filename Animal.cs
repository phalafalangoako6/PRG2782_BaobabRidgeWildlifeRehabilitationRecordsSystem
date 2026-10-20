using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidgeWildlife
{
    // Represents one animal in the rehabilitation centre.
    public class Animal
    {
        public string AnimalID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Species { get; set; } = string.Empty;
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; set; } = string.Empty;
        public string HousingUnit { get; set; } = string.Empty;
    }
}