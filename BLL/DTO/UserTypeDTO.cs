using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserTypeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public UserTypeDTO() { }
        public UserTypeDTO(UserType t)
        {
            ID = t.ID;
            Name = t.Name;
        }
    }
}
