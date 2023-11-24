using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.Repository.Entities.Taxiation
{
    public class TaxInvoice
    {
        public TaxInvoice()
        {
            Body = new List<TaxInvoiceBody>();
            Payment = new List<TaxInvoicePayment>();
        }
        public DateTime CreatedOn { get; set; }
        public TaxInvoiceHeader Header { get; set; }
        public List<TaxInvoiceBody> Body { get; set; }
        public List<TaxInvoicePayment> Payment { get; set; }
    }
}
