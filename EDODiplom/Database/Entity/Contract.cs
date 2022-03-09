namespace EDODiplom.Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Runtime.CompilerServices;

    [Table("Contract")]
    public partial class Contract:INotifyPropertyChanged
    {
        [Key]
        public int ID_Contract { get; set; }

        [Required]
        [StringLength(45)]
        public string Number { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int Suppliers_ID_Supplier { get; set; }

        [Required]
        private byte[] _DocumentScan;
        public byte[] DocumentScan { 
        
            get { return _DocumentScan; }
            set
            {
                _DocumentScan = value;
                PropChange("DocumentScan");
            }
        }

        public virtual Supplier Supplier { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void PropChange([CallerMemberName] string PropertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
