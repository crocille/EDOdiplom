namespace EDODiplom.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Materials_has_Suppliers")]
    public partial class Materials_has_Suppliers
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Materials_ID_Material { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Suppliers_ID_Supplier { get; set; }

        public decimal Material_Price { get; set; }

        public virtual Material Material { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
