using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevOps.Model
{

    public interface IWorkItem<T> : IRecordClass where T : new()
    {
        T? Parent { get; set; }
    }
}
