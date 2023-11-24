using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GW.Repository.Entities.Taxiation
{
    public class TaxationInquiryResult
    {
        public string ReferenceNumber { get; set; }
        public string Uid { get; set; }
        public string Status { get; set; }
        public TaxationDataResponse Data { get; set; }
        public string PacketType { get; set; }
        public string FiscalId { get; set; }
        public string Error { get; set; }
    }
}
