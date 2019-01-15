using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using pas_pertamina.Models;

namespace pas_pertamina.Models
{
    public partial class db_penjadwalan_pelabuhanContext : DbContext
    {
        public db_penjadwalan_pelabuhanContext()
        {
        }

        public db_penjadwalan_pelabuhanContext(DbContextOptions<db_penjadwalan_pelabuhanContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Detailshipment> Detailshipment { get; set; }
        public virtual DbSet<Estimasiwaktu> Estimasiwaktu { get; set; }
        public virtual DbSet<Kapal> Kapal { get; set; }
        public virtual DbSet<Listketerangan> Listketerangan { get; set; }
        public virtual DbSet<Listsatuan> Listsatuan { get; set; }
        public virtual DbSet<Liststatus> Liststatus { get; set; }
        public virtual DbSet<Listtipekapal> Listtipekapal { get; set; }
        public virtual DbSet<Listwaiting> Listwaiting { get; set; }
        public virtual DbSet<Pelabuhan> Pelabuhan { get; set; }
        public virtual DbSet<Produk> Produk { get; set; }
        public virtual DbSet<Rute> Rute { get; set; }
        public virtual DbSet<Shipment> Shipment { get; set; }
        public virtual DbSet<Stok> Stok { get; set; }
        public virtual DbSet<TbChat> TbChat { get; set; }
        public virtual DbSet<Userlogin> Userlogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IK66D93\\BUDIMAN;Database=db_penjadwalan_pelabuhan;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Detailshipment>(entity =>
            {
                entity.HasKey(e => e.Iddetailshipment);

                entity.ToTable("detailshipment");

                entity.Property(e => e.Iddetailshipment).HasColumnName("iddetailshipment");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idproduk).HasColumnName("idproduk");

                entity.Property(e => e.Idsatuan).HasColumnName("idsatuan");

                entity.Property(e => e.Idshipment).HasColumnName("idshipment");

                entity.Property(e => e.Jumlah).HasColumnName("jumlah");

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdprodukNavigation)
                    .WithMany(p => p.Detailshipment)
                    .HasForeignKey(d => d.Idproduk)
                    .HasConstraintName("FK_detailshipment_produk");

                entity.HasOne(d => d.IdsatuanNavigation)
                    .WithMany(p => p.Detailshipment)
                    .HasForeignKey(d => d.Idsatuan)
                    .HasConstraintName("FK_detailshipment_listsatuan");

                entity.HasOne(d => d.IdshipmentNavigation)
                    .WithMany(p => p.Detailshipment)
                    .HasForeignKey(d => d.Idshipment)
                    .HasConstraintName("FK_detailshipment_shipment");
            });

            modelBuilder.Entity<Estimasiwaktu>(entity =>
            {
                entity.HasKey(e => e.Idestimasiwaktu);

                entity.ToTable("estimasiwaktu");

                entity.Property(e => e.Idestimasiwaktu).HasColumnName("idestimasiwaktu");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Estimasiwaktu1)
                    .HasColumnName("estimasiwaktu")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idkapal).HasColumnName("idkapal");

                entity.Property(e => e.Idlistket).HasColumnName("idlistket");

                entity.Property(e => e.Idlistpelabuhan).HasColumnName("idlistpelabuhan");

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdkapalNavigation)
                    .WithMany(p => p.Estimasiwaktu)
                    .HasForeignKey(d => d.Idkapal)
                    .HasConstraintName("FK_estimasiwaktu_kapal");

                entity.HasOne(d => d.IdlistketNavigation)
                    .WithMany(p => p.Estimasiwaktu)
                    .HasForeignKey(d => d.Idlistket)
                    .HasConstraintName("FK_estimasiwaktu_listketerangan");

                entity.HasOne(d => d.IdlistpelabuhanNavigation)
                    .WithMany(p => p.Estimasiwaktu)
                    .HasForeignKey(d => d.Idlistpelabuhan)
                    .HasConstraintName("FK_estimasiwaktu_pelabuhan");
            });

            modelBuilder.Entity<Kapal>(entity =>
            {
                entity.HasKey(e => e.Idkapal);

                entity.ToTable("kapal");

                entity.Property(e => e.Idkapal).HasColumnName("idkapal");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Flowrate).HasColumnName("flowrate");

                entity.Property(e => e.Idlisttipekapal).HasColumnName("idlisttipekapal");

                entity.Property(e => e.Jenisangkut)
                    .HasColumnName("jenisangkut")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Kapasitas).HasColumnName("kapasitas");

                entity.Property(e => e.Namakapal)
                    .HasColumnName("namakapal")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Satuanflowrate).HasColumnName("satuanflowrate");

                entity.Property(e => e.Satuankapasitas).HasColumnName("satuankapasitas");

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdlisttipekapalNavigation)
                    .WithMany(p => p.Kapal)
                    .HasForeignKey(d => d.Idlisttipekapal)
                    .HasConstraintName("FK_kapal_listtipekapal");

                entity.HasOne(d => d.SatuanflowrateNavigation)
                    .WithMany(p => p.KapalSatuanflowrateNavigation)
                    .HasForeignKey(d => d.Satuanflowrate)
                    .HasConstraintName("FK_kapal_listsatuan1");

                entity.HasOne(d => d.SatuankapasitasNavigation)
                    .WithMany(p => p.KapalSatuankapasitasNavigation)
                    .HasForeignKey(d => d.Satuankapasitas)
                    .HasConstraintName("FK_kapal_listsatuan");
            });

            modelBuilder.Entity<Listketerangan>(entity =>
            {
                entity.HasKey(e => e.Idlistketerangan);

                entity.ToTable("listketerangan");

                entity.Property(e => e.Idlistketerangan).HasColumnName("idlistketerangan");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Namaketerangan)
                    .HasColumnName("namaketerangan")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Listsatuan>(entity =>
            {
                entity.HasKey(e => e.IdListsatuan);

                entity.ToTable("listsatuan");

                entity.Property(e => e.IdListsatuan).HasColumnName("id_listsatuan");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.NamaSatuan)
                    .HasColumnName("nama_satuan")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SimbolSatuan)
                    .HasColumnName("simbol_satuan")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Liststatus>(entity =>
            {
                entity.HasKey(e => e.Idstatus);

                entity.ToTable("liststatus");

                entity.Property(e => e.Idstatus).HasColumnName("idstatus");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Namastatus)
                    .HasColumnName("namastatus")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Listtipekapal>(entity =>
            {
                entity.HasKey(e => e.Idlisttipekapal);

                entity.ToTable("listtipekapal");

                entity.Property(e => e.Idlisttipekapal).HasColumnName("idlisttipekapal");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Namalisttipekapal)
                    .HasColumnName("namalisttipekapal")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Listwaiting>(entity =>
            {
                entity.HasKey(e => e.Idlistwaiting);

                entity.ToTable("listwaiting");

                entity.Property(e => e.Idlistwaiting).HasColumnName("idlistwaiting");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Namalistwaiting)
                    .HasColumnName("namalistwaiting")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Pelabuhan>(entity =>
            {
                entity.HasKey(e => e.Idlistpelabuhan);

                entity.ToTable("pelabuhan");

                entity.Property(e => e.Idlistpelabuhan).HasColumnName("idlistpelabuhan");

                entity.Property(e => e.Baseline)
                    .HasColumnName("baseline")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Jenisproduk)
                    .HasColumnName("jenisproduk")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Kodepelabuhan)
                    .HasColumnName("kodepelabuhan")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Namapelabuhan)
                    .HasColumnName("namapelabuhan")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Produk>(entity =>
            {
                entity.HasKey(e => e.Idproduk);

                entity.ToTable("produk");

                entity.Property(e => e.Idproduk).HasColumnName("idproduk");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Jenisproduk)
                    .HasColumnName("jenisproduk")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Namaproduk)
                    .HasColumnName("namaproduk")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Rute>(entity =>
            {
                entity.HasKey(e => e.Idrute);

                entity.ToTable("rute");

                entity.Property(e => e.Idrute).HasColumnName("idrute");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Idasal).HasColumnName("idasal");

                entity.Property(e => e.Idkapal).HasColumnName("idkapal");

                entity.Property(e => e.Idtujuan).HasColumnName("idtujuan");

                entity.Property(e => e.Seatime)
                    .HasColumnName("seatime")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdasalNavigation)
                    .WithMany(p => p.RuteIdasalNavigation)
                    .HasForeignKey(d => d.Idasal)
                    .HasConstraintName("FK_rute_pelabuhan");

                entity.HasOne(d => d.IdkapalNavigation)
                    .WithMany(p => p.Rute)
                    .HasForeignKey(d => d.Idkapal)
                    .HasConstraintName("FK_rute_kapal");

                entity.HasOne(d => d.IdtujuanNavigation)
                    .WithMany(p => p.RuteIdtujuanNavigation)
                    .HasForeignKey(d => d.Idtujuan)
                    .HasConstraintName("FK_rute_pelabuhan1");
            });

            modelBuilder.Entity<Shipment>(entity =>
            {
                entity.HasKey(e => e.Idshipment);

                entity.ToTable("shipment");

                entity.Property(e => e.Idshipment).HasColumnName("idshipment");

                entity.Property(e => e.Antrian).HasColumnName("antrian");

                entity.Property(e => e.Arrival).HasColumnName("arrival");

                entity.Property(e => e.Berthed).HasColumnName("berthed");

                entity.Property(e => e.Comm).HasColumnName("comm");

                entity.Property(e => e.Comp).HasColumnName("comp");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Departure).HasColumnName("departure");

                entity.Property(e => e.Idasal).HasColumnName("idasal");

                entity.Property(e => e.Idbantuan).HasColumnName("idbantuan");

                entity.Property(e => e.Idkapal).HasColumnName("idkapal");

                entity.Property(e => e.Idpelabuhanbantuan).HasColumnName("idpelabuhanbantuan");

                entity.Property(e => e.Idtujuan).HasColumnName("idtujuan");

                entity.Property(e => e.Nojetty).HasColumnName("nojetty");

                entity.Property(e => e.Noshipment)
                    .HasColumnName("noshipment")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Proses)
                    .HasColumnName("proses")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Prosesbantuan)
                    .HasColumnName("prosesbantuan")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Unberthed).HasColumnName("unberthed");

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Waiting1).HasColumnName("waiting1");

                entity.Property(e => e.Waiting2).HasColumnName("waiting2");

                entity.Property(e => e.Waiting3).HasColumnName("waiting3");

                entity.Property(e => e.Waiting4).HasColumnName("waiting4");

                entity.Property(e => e.Waiting5).HasColumnName("waiting5");

                entity.HasOne(d => d.IdasalNavigation)
                    .WithMany(p => p.ShipmentIdasalNavigation)
                    .HasForeignKey(d => d.Idasal)
                    .HasConstraintName("FK_shipment_pelabuhan");

                entity.HasOne(d => d.IdkapalNavigation)
                    .WithMany(p => p.Shipment)
                    .HasForeignKey(d => d.Idkapal)
                    .HasConstraintName("FK_shipment_kapal");

                entity.HasOne(d => d.IdpelabuhanbantuanNavigation)
                    .WithMany(p => p.ShipmentIdpelabuhanbantuanNavigation)
                    .HasForeignKey(d => d.Idpelabuhanbantuan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_shipment_pelabuhan2");

                entity.HasOne(d => d.IdtujuanNavigation)
                    .WithMany(p => p.ShipmentIdtujuanNavigation)
                    .HasForeignKey(d => d.Idtujuan)
                    .HasConstraintName("FK_shipment_pelabuhan1");
            });

            modelBuilder.Entity<Stok>(entity =>
            {
                entity.HasKey(e => e.Idstock);

                entity.ToTable("stok");

                entity.Property(e => e.Idstock).HasColumnName("idstock");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Deadstok).HasColumnName("deadstok");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Dot).HasColumnName("dot");

                entity.Property(e => e.Idlistpelabuhan).HasColumnName("idlistpelabuhan");

                entity.Property(e => e.Idproduk).HasColumnName("idproduk");

                entity.Property(e => e.Pumpable).HasColumnName("pumpable");

                entity.Property(e => e.Safestok).HasColumnName("safestok");

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdlistpelabuhanNavigation)
                    .WithMany(p => p.Stok)
                    .HasForeignKey(d => d.Idlistpelabuhan)
                    .HasConstraintName("FK_stok_pelabuhan");

                entity.HasOne(d => d.IdprodukNavigation)
                    .WithMany(p => p.Stok)
                    .HasForeignKey(d => d.Idproduk)
                    .HasConstraintName("FK_stok_produk");
            });

            modelBuilder.Entity<TbChat>(entity =>
            {
                entity.HasKey(e => e.Idchat);

                entity.ToTable("tb_chat");

                entity.Property(e => e.Idchat).HasColumnName("idchat");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Iduser)
                    .HasColumnName("iduser")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Isichat)
                    .HasColumnName("isichat")
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Tanggalchat)
                    .HasColumnName("tanggalchat")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Userlogin>(entity =>
            {
                entity.HasKey(e => e.Iduserlogin);

                entity.ToTable("userlogin");

                entity.Property(e => e.Iduserlogin).HasColumnName("iduserlogin");

                entity.Property(e => e.Akses)
                    .HasColumnName("akses")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTime)
                    .HasColumnName("created_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.DeletedBy)
                    .HasColumnName("deleted_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DeletedTime)
                    .HasColumnName("deleted_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.IdPelabuhan).HasColumnName("id_pelabuhan");

                entity.Property(e => e.Namauser)
                    .HasColumnName("namauser")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoftDelete)
                    .HasColumnName("soft_delete")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedTime)
                    .HasColumnName("updated_time")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.IdPelabuhanNavigation)
                    .WithMany(p => p.Userlogin)
                    .HasForeignKey(d => d.IdPelabuhan)
                    .HasConstraintName("FK_userlogin_pelabuhan");
            });
        }

        public DbSet<pas_pertamina.Models.ViewShipmenDetail> ViewShipmenDetail { get; set; }
    }
}
