using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PaymentDTO
    {
        public int ID { get; set; }

        public int Cost { get; set; }
        public DateTime Date { get; set; }
        public int ClientID { get; set; }

        PaymentDTO() { }
        public PaymentDTO(Payment p)
        {
            ID = p.ID;
            Cost = p.Cost;
            Date = p.Date;
            ClientID = p.ClientID;
        }
    }
}
