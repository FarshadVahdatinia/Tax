using GW.Repository.Entities.Taxiation;

namespace TaxCollectData.Library.Dto.Content
{
    public class InvoiceDtoWrapper
    {
        public TaxInvoice Invoice { get; set; }
        public string FiscalId { get; set; }
        public string Uid { get; set; }
    }
}
