using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnExampleApp.Interfaces
{
    public interface IDidYouMean
    {
        // This method will get the words from ds and use these as
        // the collection of words.
        void SetDataSource(IDataSource ds);
        // Will return a dictionary containing all words ordered by distance to s
        // up to maxDistance. For d = 1..maxDistance, result[d] is an array containing
        // the words with a distance to s of exactly d.
        IDictionary<int, string[]> GetByDistance(string s, int maxDistance);
        // Will return a dictionary containing maxAmount words ordered by distance to s
        // up to maxDistance. for d = 1..maxDistance, result[d] is an array containing
        // the words with a distance to s of exactly d.
        IDictionary<int, string[]> GetByDistance(string s, int maxDistance, int maxAmount);
        // will return the words close to s, ordered by distance to s and thereafter length.
        string[] GetCloseWords(string s);
        // will return the distance between s and t. This method will not depend on the
        // current data-source.
        int Distance(string s, string t);
    }

}

