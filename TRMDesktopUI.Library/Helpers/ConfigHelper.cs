using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRMDesktopUI.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public double GetTaxRate()
        {
            var taxRate = ConfigurationManager.AppSettings["taxRate"];

            var IsValidTaxRate = Double.TryParse(taxRate, out double output);

            if (IsValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("The taxRate is not set up properly. Please, use a valid double value.");
            }

            return output;
        }
    }
}
