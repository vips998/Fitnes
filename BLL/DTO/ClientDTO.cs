using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ClientDTO
    {
        public int ID { get; set; }

        public int Balance { get; set; }

        public int UserID { get; set; }

        public ClientDTO() { }
        public ClientDTO(Client t)
        {
            ID = t.ID;
            Balance = t.Balance;
            UserID = t.UserID;
        }
    }
}
