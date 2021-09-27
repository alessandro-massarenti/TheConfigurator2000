using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheConfigurator2000.Classes;

namespace TheConfigurator2000.Data
{
    interface IReportService
    {
        void GenerateReport(Quotation quotation);

    }
}
