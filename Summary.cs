private bool GenerateSummary()
{
    //Reads the animals.txt then calculates the totals and averages then saves the summary.txt
    string dataFile = "animals.txt";
    string summaryFile = "summary.txt";

    //variables to hold calculations for summary
    int totalCount = 0;
    int totalAge = 0;
    int totalScore = 0;

    int criticalCount = 0;
    int seriousCount = 0;
    int stableCount = 0;
    int recoveringCount = 0;
    int releaseReadyCount = 0;
    
    //try catch to read and process the file
    try
    {
        if (File.Exists(dataFile))
        {
            string[] lines = File.ReadAllLines(dataFile);

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] fields = line.Split('|');

                // Checks if the line has all 7 required fields
                if (fields.Length == 7)
                {
                    // Converts the text values to numbers
                    bool isValidAge = int.TryParse(fields[3].Trim(), out int age);
                    bool isValidScore = int.TryParse(fields[4].Trim(), out int score);
                    string status = fields[5].Trim();

                    // If statemet for if the numbers are valid then its add them to the totals
                    if (isValidAge && isValidScore)
                    {
                        totalCount++;
                        totalAge += age;
                        totalScore += score;

                        // Sort into the correct status buckets
                        if (status == "Critical") criticalCount++;
                        else if (status == "Serious") seriousCount++;
                        else if (status == "Stable") stableCount++;
                        else if (status == "Recovering") recoveringCount++;
                        else if (status == "Release-Ready") releaseReadyCount++;
                    }
                }
            }
        }
    }
    catch (IOException)
    {
        MessageBox.Show("The file is being used by another program.", MessageBoxButtons.OK);
        return false;
    }
    catch (UnauthorizedAccessException)
    {
        MessageBox.Show("You do not have permission to access this file.", MessageBoxButtons.OK);
        return false;
    }
     string avgAgeStr = "N/A";
    string avgScoreStr = "N/A";

    if (totalCount > 0)
    {
        double averageAge = (double)totalAge / totalCount;
        double averageScore = (double)totalScore / totalCount;

        // "F2" fixes it to 2 decimal places while InvariantCulture forces a dot separator.
        avgAgeStr = averageAge.ToString("F2", CultureInfo.InvariantCulture);
        avgScoreStr = averageScore.ToString("F2", CultureInfo.InvariantCulture);
    }
    lblTotalAnimals.Text = totalCount.ToString();
    lblAverageAge.Text = avgAgeStr;
    lblAverageRecoveryScore.Text = avgScoreStr;
    lblCritical.Text = criticalCount.ToString();
    lblSerious.Text = seriousCount.ToString();
    lblStable.Text = stableCount.ToString();
    lblRecovering.Text = recoveringCount.ToString();
    lblReleaseReady.Text = releaseReadyCount.ToString();

     //Overwrites Summary.txt
    try
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

        using (StreamWriter writer = new StreamWriter(summaryFile, false)) // false means overwrite
        {
            writer.WriteLine("BAOBAB RIDGE WILDLIFE REHABILITATION CENTRE");
            writer.WriteLine("ANIMAL SUMMARY REPORT");
            writer.WriteLine("Generated: " + timestamp);
            writer.WriteLine("----------------------------------------");
            writer.WriteLine("Total animals:");
            writer.WriteLine(totalCount);
            writer.WriteLine("Average age (years):");
            writer.WriteLine(avgAgeStr);
            writer.WriteLine("Average recovery score:");
            writer.WriteLine(avgScoreStr);
            writer.WriteLine("----------------------------------------");
            writer.WriteLine("Animals per status:");
            writer.WriteLine("Critical:");
            writer.WriteLine(criticalCount);
            writer.WriteLine("Serious:");
            writer.WriteLine(seriousCount);
            writer.WriteLine("Stable:");
            writer.WriteLine(stableCount);
            writer.WriteLine("Recovering:");
            writer.WriteLine(recoveringCount);
            writer.WriteLine("Release-Ready:");
            writer.WriteLine(releaseReadyCount);
        }
        return true;
    }
    catch (Exception ex)
    {
        MessageBox.Show("Could not save the summary file: " + ex.Message, "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
    }
}
