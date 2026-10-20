using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace BaobabRidgeWildlife
{
    public static class AnimalRepository
    {
        // The path to animals.txt in the same folder as the .exe.
        private static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "animals.txt");

        // Loads animal records from animals.txt. Malformed lines are skipped; their count is reported.
        public static List<Animal> Load(out int skipped)
        {
            var animals = new List<Animal>();
            skipped = 0;

            // Create an empty file if it doesn't exist
            if (!File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, string.Empty);
                return animals;
            }

            string[] lines = File.ReadAllLines(FilePath);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) { skipped++; continue; }
                string[] f = line.Split('|');

                if (f.Length != 7) { skipped++; continue; }
                if (!int.TryParse(f[3], NumberStyles.Integer, CultureInfo.InvariantCulture, out int age)) { skipped++; continue; }
                if (!int.TryParse(f[4], NumberStyles.Integer, CultureInfo.InvariantCulture, out int score)) { skipped++; continue; }
                if (f[0].Length != 7 || !f[0].StartsWith("WR-")) { skipped++; continue; }

                animals.Add(new Animal
                {
                    AnimalID = f[0],
                    Name = f[1],
                    Species = f[2],
                    Age = age,
                    RecoveryScore = score,
                    Status = f[5],
                    HousingUnit = f[6]
                });
            }
            return animals;
        }

        // Rewrites animals.txt replacing only the line whose ID matches, leaving all others untouched.
        public static void UpdateRecord(string id, Animal updated)
        {
            if (!File.Exists(FilePath)) return;

            string[] lines = File.ReadAllLines(FilePath);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] f = lines[i].Split('|');
                if (f.Length == 7 && f[0] == id)
                {
                    lines[i] = $"{updated.AnimalID}|{updated.Name}|{updated.Species}|{updated.Age}|{updated.RecoveryScore}|{updated.Status}|{updated.HousingUnit}";
                    break; // Stop once we find and update the correct animal
                }
            }
            File.WriteAllLines(FilePath, lines);
        }

        // Rewrites animals.txt with every line whose ID does not match the given ID.
        public static void DeleteRecord(string id)
        {
            if (!File.Exists(FilePath)) return;

            string[] lines = File.ReadAllLines(FilePath);
            var remaining = new List<string>();

            foreach (string line in lines)
            {
                string[] f = line.Split('|');
                if (f.Length > 0 && f[0] == id)
                {
                    continue; // Skip (delete) the matching record
                }
                remaining.Add(line);
            }
            File.WriteAllLines(FilePath, remaining);
        }
    }
}