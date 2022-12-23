using BLL.DTO.ReportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IReportService
    {
        /// <summary>
        /// выполнить ХП - отчет по заказам за месяц
        /// </summary>

        List<PaymentClients> Trainings(int id);
        List<TrainingClients> ExecuteSP(DateTime time);
        /// <summary>
        /// Количество заказов
        /// </summary>
    }
}
