using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Services
{
    public class BaseService
    {
        public ConverterEntities conection;
        public BaseService()
        {
            conection = new ConverterEntities();
        }
    }
}
