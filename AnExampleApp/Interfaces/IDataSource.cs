using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnExampleApp.Interfaces
{
    public interface IDataSource
    {
        IEnumerable<string> GetAll();
    }
}
