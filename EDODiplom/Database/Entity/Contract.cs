namespace EDODiplom.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contract")]
    public partial class Contract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Contract { get; set; }

        [Required]
        [StringLength(45)]
        public string Number { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public int Suppliers_ID_Supplier { get; set; }

        public virtual Supplier Supplier { get; set; }
        [Required]
        public byte[] DocumentScan { get; set; }
    }
}
