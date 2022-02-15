namespace PurchaseSaleOrderSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            PurchaseOrders = new HashSet<PurchaseOrder>();
        }

        [Key]
        public int user_id { get; set; }

        [Required]
        [StringLength(50)]
        public string user_level { get; set; }

        [Required]
        [StringLength(50)]
        public string user_name { get; set; }

        [Required]
        [StringLength(50)]
        public string user_account { get; set; }

        [Required]
        [StringLength(50)]
        public string user_password { get; set; }

        [Required]
        [StringLength(50)]
        public string user_creator { get; set; }

        public DateTime user_createdate { get; set; }

        [StringLength(50)]
        public string user_remover { get; set; }

        public DateTime? user_removedate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
