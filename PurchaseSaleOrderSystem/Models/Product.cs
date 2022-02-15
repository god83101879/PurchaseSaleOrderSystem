namespace PurchaseSaleOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        [Key]
        public int product_id { get; set; }

        [Required]
        [StringLength(50)]
        public string product_name { get; set; }

        public int product_price { get; set; }

        public int product_stock { get; set; }

        [Required]
        [StringLength(50)]
        public string product_creator { get; set; }

        public DateTime product_createdate { get; set; }

        [StringLength(50)]
        public string product_remover { get; set; }

        public DateTime? product_removedate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
