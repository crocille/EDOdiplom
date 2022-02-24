namespace EDODiplom.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ObjectDocument")]
    public partial class ObjectDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_ObjectDocument { get; set; }

        [Required]
        [StringLength(45)]
        public string ObjectName { get; set; }

        [Required]
        public byte[] ObjectScan { get; set; }

        public int BuildObject_ID_BuildObject { get; set; }

        public virtual BuildObject BuildObject { get; set; }
    }
}
