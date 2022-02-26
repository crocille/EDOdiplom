namespace EDODiplom.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            BuildObjects = new HashSet<BuildObject>();
            Supplies = new HashSet<Supply>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idUser { get; set; }

        [Required]
        [StringLength(45)]
        public string Password { get; set; }

        [Required]
        [StringLength(45)]
        public string Login { get; set; }

        [Required]
        [StringLength(60)]
        public string FIO { get; set; }

        public int Role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BuildObject> BuildObjects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply> Supplies { get; set; }
    }
}
