namespace PurchaseSaleOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Money
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int money_totalmoneyID { get; set; }

        public decimal money_totalmoney { get; set; }
    }
}
