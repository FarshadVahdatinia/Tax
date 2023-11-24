using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.Repository.Entities.Taxiation
{
    public class TaxationDataResponse
    {
        public TaxationDataResponse()
        {
            Error = new List<TaxationResponseError>();
        }
        public Guid? ConfirmationReferenceId { get; set; }
        public List<TaxationResponseError> Error { get; set; }
        public bool Success { get; set; }
        public override string ToString()
        {
            return Success == true ? "موفقیت آمیز بود" : "خطا در اطلاعات ارسالی ";
        }
    }
}
