using System.Collections.Generic;

namespace BaobabRidgeWildlife
{
    // TEMPORARY STUB — Member 1 will replace this with the real file-backed version.
    public static class AnimalRepository
    {
        // Loads animal records from animals.txt. Stub returns an empty list.
        public static List<Animal> Load(out int skipped)
        {
            skipped = 0;
            return new List<Animal>();
        }

        // Updates one record in animals.txt. Stub does nothing.
        public static void UpdateRecord(string id, Animal updated) { }

        // Deletes one record from animals.txt. Stub does nothing.
        public static void DeleteRecord(string id) { }
    }
}