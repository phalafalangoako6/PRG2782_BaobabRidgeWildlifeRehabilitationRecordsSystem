using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidgeWildlife
{
  public class Animal
    {

        /// Represents a single animal in care. Holds every field that is stored
        /// in animals.txt, plus the calculated Status and HousingUnit. 

        public string AnimalID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public int RecoveryScore { get; set; }
        public string Status { get; set; }
        public string HousingUnit { get; set; }
    }
}
