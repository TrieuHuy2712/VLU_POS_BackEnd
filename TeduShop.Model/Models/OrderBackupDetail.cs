using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeduShop.Model.Models
{
    [Table("OrderBackupDetails")]
    public class OrderBackupDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }
        public int OrderID { set; get; }
        public int ProductID { set; get; }

        [ForeignKey("OrderID")]
        public virtual OrderBackup OrderBackup{ set; get; }

    }
}
