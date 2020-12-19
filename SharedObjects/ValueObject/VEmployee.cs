using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.SharedObjects.ValueObject
{
    public class VEmployee
    {
        public int Id { get; set; }
        public string WC { get; set; }
        public string Dept { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Nullable<byte> Status { get; set; }
    }
}
