using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxData.Taxiation
{

    public class InquiryByReferenceNumberDto
    {
        public InquiryByReferenceNumberDto()
        {
            ReferenceNumber = new List<string>();
        }
        public List<string> ReferenceNumber { get; set; }
    }

}
