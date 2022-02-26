using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EDODiplom.Database
{
    public partial class EfModel : DbContext
    {
        private static EfModel Instance;
        public static EfModel Init()
        {
            if (Instance == null)
                Instance = new EfModel();
                return Instance;
        }
        public EfModel()
            : base("name=EfModel1")
        {
        }

        public virtual DbSet<BuildObject> BuildObjects { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Contract> Contracts { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Materials_has_Suppliers> Materials_has_Suppliers { get; set; }
        public virtual DbSet<Materials_has_Supply> Materials_has_Supply { get; set; }
        public virtual DbSet<MaterialType> MaterialTypes { get; set; }
        public virtual DbSet<ObjectDocument> ObjectDocuments { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BuildObject>()
                .Property(e => e.BuildObjectName)
                .IsUnicode(false);

            modelBuilder.Entity<BuildObject>()
                .HasMany(e => e.ObjectDocuments)
                .WithRequired(e => e.BuildObject)
                .HasForeignKey(e => e.BuildObject_ID_BuildObject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BuildObject>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.BuildObject)
                .HasForeignKey(e => e.BuildObject_ID_BuildObject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.INN)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.BuildObjects)
                .WithRequired(e => e.Client)
                .HasForeignKey(e => e.Clients_id_Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Contract>()
                .Property(e => e.Number)
                .IsUnicode(false);

            modelBuilder.Entity<Contract>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Materials_has_Suppliers)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.Materials_ID_Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.Materials_has_Supply)
                .WithRequired(e => e.Material)
                .HasForeignKey(e => e.Materials_ID_Material)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Material>()
                .HasMany(e => e.MaterialTypes)
                .WithMany(e => e.Materials)
                .Map(m => m.ToTable("Materials_has_MaterialType").MapLeftKey("Materials_id_material").MapRightKey("MaterialType_id_MaterialType"));

            modelBuilder.Entity<MaterialType>()
                .Property(e => e.MaterialTypeName)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialType>()
                .Property(e => e.MaterialTypeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ObjectDocument>()
                .Property(e => e.ObjectName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Adress)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Contracts)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.Suppliers_ID_Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Materials_has_Suppliers)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.Suppliers_ID_Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.Suppliers_ID_Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Supply>()
                .HasMany(e => e.Materials_has_Supply)
                .WithRequired(e => e.Supply)
                .HasForeignKey(e => e.Supply_ID_Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.BuildObjects)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_idUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Supplies)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.User_idUser)
                .WillCascadeOnDelete(false);
        }
    }
}
