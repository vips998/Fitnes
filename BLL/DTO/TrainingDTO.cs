using DAL;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TrainingDTO
    {
        public int ID { get; set; }

        public int NumberTrain { get; set; }

        public DateTime Date { get; set; }

        public TrainingDTO() { }
        public TrainingDTO(Training t)
        {
            ID = t.ID;
            NumberTrain = t.NumberTrain;
            Date = t.Date;
        }
    }
}