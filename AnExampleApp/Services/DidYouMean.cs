using AnExampleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnExampleApp.Services
{

    public class DidYouMean : IDidYouMean
    {
        IDataSource _ds { get; set; }

        public int Distance(string s, string t)
        {
            int n = s.Length;
            int m = t.Length;

            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                d[i, 0] = i;
            }
            for (int j = 0; j <= m; j++)
            {
                d[0, j] = j;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;

                    int insertCost = d[i - 1, j] + 1;
                    int deleteCost = d[i, j - 1] + 1;
                    int substituteCost = d[i - 1, j - 1] + cost;

                    // check if swapping two adjacent characters is possible
                    if (i > 1 && j > 1 && s[i - 1] == t[j - 2] && s[i - 2] == t[j - 1])
                    {
                        int swapCost = d[i - 2, j - 2] + cost;
                        d[i, j] = Math.Min(Math.Min(insertCost, deleteCost), Math.Min(substituteCost, swapCost));
                    }
                    else
                    {
                        d[i, j] = Math.Min(Math.Min(insertCost, deleteCost), substituteCost);
                    }
                }
            }

            return d[n, m];
        }

        public IDictionary<int, string[]> GetByDistance(string s, int maxDistance)
        {
            if (_ds == null || _ds.GetAll().ToList().Count == 0)
            {
                return new Dictionary<int, string[]>();
            }

            Dictionary<int, List<string>> result = new Dictionary<int, List<string>>();

            foreach (string word in _ds.GetAll())
            {
                int distance = Distance(s, word);
                if (distance <= maxDistance && distance != 0)
                {
                    if (!result.ContainsKey(distance))
                    {
                        result[distance] = new List<string> { word };
                    }
                    else
                    {
                        result[distance].Add(word);
                    }
                }
            }

            return result.OrderBy(entry => entry.Key).ToDictionary(entry => entry.Key, entry => entry.Value.ToArray());
        }

        public IDictionary<int, string[]> GetByDistance(string s, int maxDistance, int maxAmount)
        {
            if (maxAmount <= 0)
            {
                throw new ArgumentException("maxAmount must be greater than zero.");
            }

            return GetByDistance(s, maxDistance)
                .Take(maxAmount)
                .ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        public string[] GetCloseWords(string s)
        {
            var wordDistancePairs = _ds.GetAll()
                .Select(word => new { Word = word, Distance = Distance(s, word) })
                .OrderBy(pair => pair.Distance)
                .ToArray();

            // Extract the sorted words from the pairs
            var sortedWords = wordDistancePairs.Select(pair => pair.Word).ToArray();

            return sortedWords;
        }


        public void SetDataSource(IDataSource ds)
        {
            _ds = ds;
        }
    }
}
