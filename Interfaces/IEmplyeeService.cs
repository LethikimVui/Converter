using Converter.SharedObjects.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Interfaces
{
    public interface IEmplyeeService
    {
        List<VEmployee> GetAll();
        //int Delete(string employeeId);

    }
}
