using Converter.Interfaces;
using Converter.SharedObjects.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.Services
{
    public class EmplyeeService : BaseService, IEmplyeeService
    {
        public List<VEmployee> GetAll()
        {
            var result = conection.SP_GetAll().ToList();
            var listCates = result.ConvertAll(s => new VEmployee
            {
                Id = s.Id,
                WC = s.WC,
                Dept = s.Dept,
                Name = s.Name,
                Email = s.Email,
                Status = s.Status
            });
            return listCates.OrderBy(s => s.Id).ToList();
        }
        //public int Delete(string employeeId)
        //{
        //    try
        //    {
        //        conection.(employeeId);
        //        return 200;
        //    }
        //    catch (Exception)
        //    {

        //        return 400;
        //    }
        //}
    }
}
