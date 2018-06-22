using System;
using System.Linq;


namespace App.Module32.Infrastructure.Utility
{
    /// <summary>
    /// Contains approximate string matching
    /// </summary>
    public static class LevenshteinDistance
    {
        /// <summary>
        /// Compute the distance between two strings.
        /// </summary>
        public static int Compute(string original, string modified)
        {
            int lenOrig = original.Length;
            int lenDiff = modified.Length;

            var matrix = new int[lenOrig + 1, lenDiff + 1];
            for (int i = 0; i <= lenOrig; i++)
                matrix[i, 0] = i;
            for (int j = 0; j <= lenDiff; j++)
                matrix[0, j] = j;

            for (int i = 1; i <= lenOrig; i++)
            {
                for (int j = 1; j <= lenDiff; j++)
                {
                    int cost = modified[j - 1] == original[i - 1] ? 0 : 1;
                    var vals = new[] {
                        matrix[i - 1, j] + 1,
                        matrix[i, j - 1] + 1,
                        matrix[i - 1, j - 1] + cost
                    };
                    matrix[i, j] = vals.Min();
                    if (i > 1 && j > 1 && original[i - 1] == modified[j - 2] && original[i - 2] == modified[j - 1])
                        matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
                }
            }
            return matrix[lenOrig, lenDiff];
        }
    }
}
