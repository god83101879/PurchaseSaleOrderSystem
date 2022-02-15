namespace PurchaseSaleOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrder
    {
        [Key]
        public int purchaseorder_pid { get; set; }

        [Required]
        [StringLength(32)]
        public string purchaseorder_orderid { get; set; }

        public int purchaseorder_userid { get; set; }

        public DateTime purchaseorder_date { get; set; }

        public int purchaseorder_producid { get; set; }

        public int purchaseorder_productnum { get; set; }

        public int purchaseorder_totalcost { get; set; }

        [Required]
        [StringLength(50)]
        public string purchaseorder_creator { get; set; }

        public DateTime purchaseorder_createdate { get; set; }

        [StringLength(50)]
        public string purchaseorder_remover { get; set; }

        public DateTime? purchaseorder_removedate { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
