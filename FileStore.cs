using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BaobabRidge
{
    
    /// All reading and writing of animals.txt and summary.txt.
    /// Never throws for expected file problems; reports them via out string error.
   
    public static class FileStore
    {
        public const string AnimalsFile = "animals.txt";
        public const string SummaryFile = "summary.txt";

        /// Loads every valid record from animals.txt. Creates an empty file if
        /// missing. Skips malformed lines (wrong field count, bad age/score,
        /// bad ID) and reports how many were skipped. Returns the list.
       
        public static List<Animal> LoadAnimals(out int skippedLines, out string error)
        {
            skippedLines = 0;
            error = null;
            var list = new List<Animal>();

            try
            {
                if (!File.Exists(AnimalsFile))
                {
                    File.WriteAllText(AnimalsFile, string.Empty, Encoding.UTF8);
                    return list;
                }

                foreach (string raw in File.ReadAllLines(AnimalsFile, Encoding.UTF8))
                {
                    if (string.IsNullOrWhiteSpace(raw)) continue;

                    string[] p = raw.Split('|');
                    if (p.Length != 7 ||
                        !IsValidId(p[0]) ||
                        !int.TryParse(p[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int age) ||
                        !int.TryParse(p[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out int score) ||
                        age < 0 || age > 100 || score < 0 || score > 100)
                    {
                        skippedLines++;
                        continue;
                    }

                    // Fields are trimmed so stray spaces never break a round-trip.
                    list.Add(new Animal
                    {
                        AnimalID = p[0].Trim().ToUpperInvariant(),
                        Name = p[1].Trim(),
                        Species = p[2].Trim(),
                        Age = age,
                        RecoveryScore = score,
                        Status = p[5].Trim(),
                        HousingUnit = p[6].Trim()
                    });
                }
            }
            catch (UnauthorizedAccessException) { error = "Permission denied while reading animals.txt."; }
            catch (IOException) { error = "animals.txt is in use by another program."; }
            catch (Exception ex) { error = "Unexpected error reading animals.txt: " + ex.Message; }

            return list;
        }

        
        /// Appends one animal as a single new line. Existing lines are untouched.
     
        public static bool AppendAnimal(Animal a, out string error)
        {
            error = null;
            try
            {
                File.AppendAllText(AnimalsFile, Serialize(a) + Environment.NewLine, Encoding.UTF8);
                return true;
            }
            catch (UnauthorizedAccessException) { error = "Permission denied while writing animals.txt."; }
            catch (IOException) { error = "animals.txt is in use by another program."; }
            catch (Exception ex) { error = "Unexpected error writing animals.txt: " + ex.Message; }
            return false;
        }

        
        /// Rewrites animals.txt from the given list. Used by Update and Delete
        /// so only the affected record changes and no others are lost.
        
        public static bool RewriteAll(List<Animal> animals, out string error)
        {
            error = null;
            try
            {
                var sb = new StringBuilder();
                foreach (var a in animals) sb.AppendLine(Serialize(a));
                File.WriteAllText(AnimalsFile, sb.ToString(), Encoding.UTF8);
                return true;
            }
            catch (UnauthorizedAccessException) { error = "Permission denied while writing animals.txt."; }
            catch (IOException) { error = "animals.txt is in use by another program."; }
            catch (Exception ex) { error = "Unexpected error writing animals.txt: " + ex.Message; }
            return false;
        }

        
        /// Writes the summary report to summary.txt as plain UTF-8 text.
       
        public static bool WriteSummary(string content, out string error)
        {
            error = null;
            try
            {
                File.WriteAllText(SummaryFile, content, Encoding.UTF8);
                return true;
            }
            catch (UnauthorizedAccessException) { error = "Permission denied while writing summary.txt."; }
            catch (IOException) { error = "summary.txt is in use by another program."; }
            catch (Exception ex) { error = "Unexpected error writing summary.txt: " + ex.Message; }
            return false;
        }

        
        /// Validates the Animal ID format: WR- followed by exactly 4 digits,
        /// case-insensitive.
       
        public static bool IsValidId(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            string t = id.Trim().ToUpperInvariant();
            if (t.Length != 7 || !t.StartsWith("WR-")) return false;
            for (int i = 3; i < 7; i++) if (!char.IsDigit(t[i])) return false;
            return true;
        }

        /// Converts one animal into the pipe-delimited storage line.
        
        private static string Serialize(Animal a)
        {
            return string.Join("|",
                a.AnimalID, a.Name, a.Species,
                a.Age.ToString(CultureInfo.InvariantCulture),
                a.RecoveryScore.ToString(CultureInfo.InvariantCulture),
                a.Status, a.HousingUnit);
        }
    }
}