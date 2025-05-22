using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.Utilities.Results
{
    public interface IDataResult<T>: IResult
    {
        T Data { get; } //sadece oxunabilir
    }
  
}
