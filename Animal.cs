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
        public required string AnimalID { get; set; }
        public required string Name { get; set; }
        public required string Species { get; set; }
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public required string Status { get; set; }
        public required string HousingUnit { get; set; }
    }
}