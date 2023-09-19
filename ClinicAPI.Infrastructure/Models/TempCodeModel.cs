using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAPI.Infrastructure.Models
{
    public class TempCodeModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
