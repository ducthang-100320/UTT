namespace UTTUniversity.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CECMSDbContext : DbContext
    {
        public CECMSDbContext()
            : base("name=CECMSDbContext3")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tblAccount> tblAccounts { get; set; }
        public virtual DbSet<tblBanner> tblBanners { get; set; }
        public virtual DbSet<tblChiTietMuonTra> tblChiTietMuonTras { get; set; }
        public virtual DbSet<tblChiTietPhieuNhap> tblChiTietPhieuNhaps { get; set; }
        public virtual DbSet<tblChucVu> tblChucVus { get; set; }
        public virtual DbSet<tblCoSo> tblCoSoes { get; set; }
        public virtual DbSet<tblDiem> tblDiems { get; set; }
        public virtual DbSet<tblDocGia> tblDocGias { get; set; }
        public virtual DbSet<tblGiangVien_Khoa> tblGiangVien_Khoa { get; set; }
        public virtual DbSet<tblHeDaoTao> tblHeDaoTaos { get; set; }
        public virtual DbSet<tblHocPhan> tblHocPhans { get; set; }
        public virtual DbSet<tblHocPhi> tblHocPhis { get; set; }
        public virtual DbSet<tblKhenThuong_KyLuat> tblKhenThuong_KyLuat { get; set; }
        public virtual DbSet<tblKhoa> tblKhoas { get; set; }
        public virtual DbSet<tblLoaiDocGia> tblLoaiDocGias { get; set; }
        public virtual DbSet<tblLop> tblLops { get; set; }
        public virtual DbSet<tblMenu> tblMenus { get; set; }
        public virtual DbSet<tblMenu_Role> tblMenu_Role { get; set; }
        public virtual DbSet<tblMuonTra> tblMuonTras { get; set; }
        public virtual DbSet<tblNew> tblNews { get; set; }
        public virtual DbSet<tblNews_File> tblNews_File { get; set; }
        public virtual DbSet<tblNganh_Khoa> tblNganh_Khoa { get; set; }
        public virtual DbSet<tblNhanVien> tblNhanViens { get; set; }
        public virtual DbSet<tblNhaXuatBan> tblNhaXuatBans { get; set; }
        public virtual DbSet<tblNVIEN_QUYEN> tblNVIEN_QUYEN { get; set; }
        public virtual DbSet<tblPhieuNhapSach> tblPhieuNhapSaches { get; set; }
        public virtual DbSet<tblPhongBan> tblPhongBans { get; set; }
        public virtual DbSet<tblPhongDoc> tblPhongDocs { get; set; }
        public virtual DbSet<tblQuyen> tblQuyens { get; set; }
        public virtual DbSet<tblSach> tblSaches { get; set; }
        public virtual DbSet<tblSinhVien> tblSinhViens { get; set; }
        public virtual DbSet<tblSinhVien_HocPhan> tblSinhVien_HocPhan { get; set; }
        public virtual DbSet<tblSinhVien_Khoa> tblSinhVien_Khoa { get; set; }
        public virtual DbSet<tblTacGia> tblTacGias { get; set; }
        public virtual DbSet<tblTheLoaiSach> tblTheLoaiSaches { get; set; }
        public virtual DbSet<tblThoiKhoaBieu> tblThoiKhoaBieux { get; set; }
        public virtual DbSet<tblTrinhDoHocVan> tblTrinhDoHocVans { get; set; }
        public virtual DbSet<tblVideo> tblVideos { get; set; }
        public virtual DbSet<tblCategory> tblCategories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblChiTietPhieuNhap>()
                .Property(e => e.DON_GIA)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblChiTietPhieuNhap>()
                .Property(e => e.THANH_TIEN)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblDiem>()
                .Property(e => e.MA_HOCPHAN)
                .IsFixedLength();

            modelBuilder.Entity<tblHocPhan>()
                .HasMany(e => e.tblSinhVien_HocPhan)
                .WithRequired(e => e.tblHocPhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblHocPhi>()
                .Property(e => e.TONG_SO)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblHocPhi>()
                .Property(e => e.DA_DONG)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblHocPhi>()
                .Property(e => e.CON_NO)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblHocPhi>()
                .Property(e => e.CON_DU)
                .HasPrecision(19, 4);

            modelBuilder.Entity<tblKhoa>()
                .HasMany(e => e.tblNganh_Khoa)
                .WithRequired(e => e.tblKhoa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblQuyen>()
                .HasMany(e => e.tblNVIEN_QUYEN)
                .WithRequired(e => e.tblQuyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSinhVien>()
                .HasMany(e => e.tblDiems)
                .WithRequired(e => e.tblSinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSinhVien>()
                .HasMany(e => e.tblHocPhis)
                .WithRequired(e => e.tblSinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSinhVien>()
                .HasMany(e => e.tblSinhVien_HocPhan)
                .WithRequired(e => e.tblSinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSinhVien>()
                .HasMany(e => e.tblSinhVien_Khoa)
                .WithRequired(e => e.tblSinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tblSinhVien_Khoa>()
                .Property(e => e.MA_KHOA)
                .IsFixedLength();
        }
    }
}
