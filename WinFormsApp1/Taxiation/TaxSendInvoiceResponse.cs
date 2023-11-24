using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxData.Taxiation
{
    public class TaxSendInvoiceResponse
    {
        public Guid Uid { get; set; }
        public string ReferenceNumber { get; set; }
        public string ErrorCode { get; set; }
        public string ErrorDetail { get; set; }
        public string TaxId { get; set; }
        public string Inno { get; set; }
    }
}
