using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidge
{
    
        public static class Classifier
        {
           
            /// Calculates the Status and HousingUnit for a score (0-100).
            /// The bands have no gaps: 19->Critical, 20->Serious, and so on.
            
            public static void Classify(int score, out string status, out string housingUnit)
            {
                if (score < 0 || score > 100)
                    throw new ArgumentOutOfRangeException(nameof(score), "Score must be 0-100.");

                if (score <= 19) { status = "Critical"; housingUnit = "Intensive Care Unit"; }
                else if (score <= 39) { status = "Serious"; housingUnit = "High-Dependency Ward"; }
                else if (score <= 59) { status = "Stable"; housingUnit = "Recovery Ward"; }
                else if (score <= 79) { status = "Recovering"; housingUnit = "Outdoor Enclosure"; }
                else { status = "Release-Ready"; housingUnit = "Pre-Release Camp"; }
            }

        }
    }
