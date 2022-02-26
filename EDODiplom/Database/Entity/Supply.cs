namespace EDODiplom.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Supply")]
    public partial class Supply
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supply()
        {
            Materials_has_Supply = new HashSet<Materials_has_Supply>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_Supply { get; set; }

        public int Suppliers_ID_Supplier { get; set; }

        public int BuildObject_ID_BuildObject { get; set; }

        public int User_idUser { get; set; }

        public DateTime Date { get; set; }

        public virtual BuildObject BuildObject { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materials_has_Supply> Materials_has_Supply { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual User User { get; set; }
    }
}
