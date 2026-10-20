# Baobab Ridge Wildlife Rehabilitation Records System

## Project Background
Baobab Ridge Wildlife Rehabilitation Centre, treats injured and orphaned wild animals and returns them to the wild once they are ready.

Problem: Currently, the vets record each animal's progress on clipboards and in loose spreadsheets. Records go missing, get copied incorrectly, and nobody can see at a glance how many animals need intensive care and how many are ready for release.

Solution: We have built this desktop application to solve these issues. It records every animal in care, automatically works out its status and housing unit from the vet's Recovery Score, and produces a summary report for the Centre manager. Because several developers worked on this code, the project is strictly maintained under version control on GitHub.

## Group Members
*   Kitso Knowledge Matlaila
*   Ngoako Thandi Phalafala
*   Sitolwakhe Prosper Maluka
*   Thapelo Ramalebana

## Features
1.  **Add Animal:** Validates all fields and appends a new record to the text file.
2.  **View Animals:** Loads all valid records into a read-only grid on startup. Malformed lines are skipped and reported to the user.
3.  **Update Animal:** Loads a record via grid click or exact ID search; recalculates status and housing.
4.  **Delete Animal:** Removes a selected record with a Yes/No confirmation prompt.
5.  **Summary Report:** Calculates totals, averages, and per-status counts, saving to `summary.txt`.

## How It Works (System Architecture)
The application uses a clean separation of concerns across multiple classes to ensure the code is reliable and easy to maintain:

   **1. Data Model (`Animal.cs`)**
    This class acts as a blueprint to hold a single animal's data in memory while the program is running. It contains the seven required fields (ID, Name, Species, Age, Score, Status, Housing Unit).
    
   **2. Classification Logic (`Classifier.cs`)**
    The brief requires the classification logic to live in exactly one place. The `Classify()` method takes the 0-100 Recovery Score and uses an if/else chain to determine the exact Status and Housing Unit (e.g., a score of 20-39 is "Serious" and goes to the "High-Dependency Ward"). This single method is called by both the Add and Update features.
    
   **3. File Storage and Error Handling (`FileStore.cs`)**
    Because databases are not allowed, all data is stored in plain text. This class handles reading, appending, and rewriting the text file.
       **Loading:** Reads the file line by line, splits it by the pipe (`|`) character, and validates the fields. If a line is malformed, it skips it and reports the count to the user. If the file is missing, it creates an empty one.
      **Saving (Append):** When adding, it simply appends one new line to the bottom of the file.
      **Saving (Rewrite):** When updating or deleting, it overwrites the entire file with the updated list to prevent data corruption.
      **Error Catching:** Every file operation is wrapped in `try/catch` blocks. It specifically catches `IOException` (file in use) and `UnauthorizedAccessException` (permission denied) to show friendly error messages instead of crashing the app.
    
   **4. User Interface (`MainForm.cs`)**
    This class handles all the button clicks, the DataGridView (which is read-only and locked to full-row selection), the form validation, and switching between "Add Mode" (Add button enabled) and "Edit Mode" (Save Changes button enabled).

## File Formats
*   **`animals.txt`**: Stores animal records using UTF-8 plain text, with 7 fields separated by a pipe (`|`) character in this order: 
    `ID | Name | Species | Age | Score | Status | Housing Unit`. 
    No header line. Malformed lines are skipped on load.
*   **`summary.txt`**: Stores the generated summary report. Created automatically when the Generate Summary button is clicked.

## How to Build and Run
1.  Clone the repository to your local machine.
2.  Open the `BaobabRidge.sln` file in Visual Studio 2022 (.NET 8.0).
3.  Ensure the `animals.txt` file is present in the root directory.
4.  Press **F5** (or click Build > Start Debugging) to run the application.
    *   *Note: The `animals.txt` file is configured with "Copy if newer" to ensure it is always placed next to the compiled `.exe` in the output directory.*

## Known Limitations
The application is single-user; it does not implement file-locking for simultaneous multi-user editing.
Status and housing units are only recalculated when a record is added or updated, not dynamically on load.






