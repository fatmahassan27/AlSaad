using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlSaad.Application.DTOs
{
    public class StockTransactionDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public int? OrderId { get; set; }

        // 1=Manual, 2=Invoice, 3=Purchase order, 4=Credit note, 5=Transfer,
        // 6=Refund receipt, 7=Purchase refund, 8=Bundle, 9=Requisition, 14=Purchase debit note
        public int SourceType { get; set; }

        // 1 = إدخال, 2 = إخراج
        public int TransactionType { get; set; }

        public decimal Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal? TotalPrice { get; set; }
        public string? CurrencyCode { get; set; }
        public DateTime? ReceivedDate { get; set; }

        // 1=Draft, 2=Pending, 4=Processed, 5=Transfer
        public int Status { get; set; }

        public string? Notes { get; set; }
    }
}
