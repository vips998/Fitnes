using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ServiceTypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public ServiceTypeDTO() { }
        public ServiceTypeDTO(ServiceType t)
        {
            Name = t.Name;
            ID = t.ID;
            Cost = t.Cost;
        }
    }
}
