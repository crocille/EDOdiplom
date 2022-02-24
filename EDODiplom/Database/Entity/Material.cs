namespace EDODiplom.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Material")]
    public partial class Material
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Material()
        {
            Materials_has_Suppliers = new HashSet<Materials_has_Suppliers>();
            Materials_has_Supply = new HashSet<Materials_has_Supply>();
            MaterialTypes = new HashSet<MaterialType>();
        }

        [Key]
        public int ID_Material { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        [Required]
        public byte[] ImageMaterial { get; set; }

        [StringLength(45)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materials_has_Suppliers> Materials_has_Suppliers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Materials_has_Supply> Materials_has_Supply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaterialType> MaterialTypes { get; set; }
    }
}
