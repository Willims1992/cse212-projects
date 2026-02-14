


using System.Text.Json;
using System.Globalization;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        //if (words == null || words.Length == 0) return Array.Empty<string>();

        //var seen = new HashSet<string>();
        // var result = new List<string>();

        //foreach (var w in words)

        if (words == null || words.Length == 0) return Array.Empty<string>();

        var seen = new HashSet<string>();
        var result = new List<string>();

        foreach (var w in words)


        {
            if (string.IsNullOrWhiteSpace(w) || w.Length != 2)
                continue;

            // "aa" style words never pair with anything else
            if (w[0] == w[1])
            {
                seen.Add(w);
                continue;
            }


            var rev = new string(new[] { w[1], w[0] });

            if (seen.Contains(rev))
            {
                //  use a single '&' (NOT "&amp;")
                result.Add($"{rev}&{w}");
            }

            seen.Add(w);
        }

        return result.ToArray();


    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {

        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TODO Problem 2 - ADD YOUR CODE HERE

            if (fields.Length <= 3) continue;

            // Keep the degree string exactly as it appears (tests expect specific casing)
            var degree = fields[3].Trim();

            if (degree.Length == 0) continue;

            if (degrees.ContainsKey(degree))
                degrees[degree] += 1;
            else
                degrees[degree] = 1;

        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TODO Problem 3 - ADD YOUR CODE HERE
        if (word1 == null || word2 == null) return false;

        // Dictionary<char, int> to track frequency differences
        var counts = new Dictionary<char, int>();

        // Count characters from word1 (ignoring spaces, ignoring case)
        for (int i = 0; i < word1.Length; i++)
        {
            char c = word1[i];
            if (c == ' ') continue; // per spec: ignore spaces (not all whitespace)

            c = char.ToUpperInvariant(c);

            if (counts.TryGetValue(c, out int n))
                counts[c] = n + 1;
            else
                counts[c] = 1;
        }

        // Decrease counts using word2 (ignoring spaces, ignoring case)
        for (int i = 0; i < word2.Length; i++)
        {
            char c = word2[i];
            if (c == ' ') continue; // per spec

            c = char.ToUpperInvariant(c);

            if (!counts.TryGetValue(c, out int n)) return false; // extra char not in word1
            n--;
            if (n == 0) counts.Remove(c);
            else counts[c] = n;
        }

        // If all counts balanced out, it's an anagram
        return counts.Count == 0;

        //return false;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.

        return featureCollection.Features
            .Where(f => f?.Properties != null &&
                        f.Properties.Mag.HasValue &&
                        !string.IsNullOrWhiteSpace(f.Properties.Place))
            .Select(f =>
                $"{f.Properties.Place} - Mag {f.Properties.Mag.Value.ToString("0.##", CultureInfo.InvariantCulture)}"
            )
            .ToArray();


            
    }
}