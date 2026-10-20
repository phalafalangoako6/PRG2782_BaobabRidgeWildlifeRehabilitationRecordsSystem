using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaobabRidgeWildlife
{

public class Summary()
{
     // Enforces full stop as decimal separator regardless of regional settings
    private static readonly CultureInfo invariantCulture = CultureInfo.InvariantCulture;

    // Generates the summary report and writes them to summary.txt
    public static void GenerateSummaryReport(List<Animal> animals, string outputPath)
    {
            try
            {
                int totalAnimals = animals.Count;
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                // Initialize all statuses to a default count of 0
                var statusCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
                {
                    { "Critical", 0 },
                    { "Serious", 0 },
                    { "Stable", 0 },
                    { "Recovering", 0 },
                    { "Release-Ready", 0 }
                };

                // Populate counts from the loaded animal records
                foreach (var animal in animals)
                {
                    if (!string.IsNullOrWhiteSpace(animal.Status) && statusCounts.ContainsKey(animal.Status.Trim()))
                    {
                        statusCounts[animal.Status.Trim()]++;
                    }
                }


                // Prepare metrics with conditional formatting for empty or populated states
                string averageAgeStr = totalAnimals > 0 
                    ? animals.Average(a => a.Age).ToString("F2", invariantCulture) 
                    : "N/A";

                string averageScoreStr = totalAnimals > 0 
                    ? animals.Average(a => a.RecoveryScore).ToString("F2", invariantCulture) 
                    : "N/A";

                string[] summaryLines = new string[]
                {
                    "BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE",
                    "ANIMAL SUMMARY REPORT",
                    $"Generated: {timestamp}",
                    "----------------------------------------",
                    "Total animals:",
                    $"{totalAnimals}",
                    "Average age (years):",
                    $"{averageAgeStr}",
                    "Average recovery score:",
                    $"{averageScoreStr}",
                    "----------------------------------------",
                    "Animals per status:",
                    "Critical:",
                    $"{statusCounts["Critical"]}",
                    "Serious:",
                    $"{statusCounts["Serious"]}",
                    "Stable:",
                    $"{statusCounts["Stable"]}",
                    "Recovering:",
                    $"{statusCounts["Recovering"]}",
                    "Release-Ready:",
                    $"{statusCounts["Release-Ready"]}"
                };

                File.WriteAllLines(outputPath, summaryLines);
            }
            catch (IOException ex)
            {
                throw new Exception("The summary report file is currently open in another program or inaccessible.", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new Exception("Permission denied when trying to save the summary report.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred while generating the summary report.", ex);
            }
        }
    }
}

