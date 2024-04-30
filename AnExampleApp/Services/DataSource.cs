using AnExampleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnExampleApp.Services
{
    internal class DataSource : IDataSource
    {
        public List<String> Source { get; set; }
        public DataSource(List<string> source)
        {
            Source = source;
        }
        public IEnumerable<string> GetAll()
        {
            return Source;
        }
    }
}
