using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO.ReportModels
{
    public class PaymentClients
    {
        //Fio id cost date
        public string FIO { get; set; }
        public string Telephone { get; set; }
        public string Mail { get; set; }

    }

    public class TrainingClients
    {
        // id fio nameservice date
        public string FIO { get; set; }
        public int Balance { get; set; }
        public int Cost { get; set; }
        public DateTime Date { get; set; }

    }
}
