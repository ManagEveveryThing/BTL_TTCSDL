namespace AdminWeb.Models.DB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBContext_QLDT : DbContext
    {
        public DBContext_QLDT()
            : base("name=DBContext_QLDT")
        {
        }

        public virtual DbSet<BaiThi> BaiThis { get; set; }
        public virtual DbSet<BoMon> BoMons { get; set; }
        public virtual DbSet<CanhCao> CanhCaos { get; set; }
        public virtual DbSet<CHiTietHP> CHiTietHPs { get; set; }
        public virtual DbSet<ChuyenNganhDT> ChuyenNganhDTs { get; set; }
        public virtual DbSet<DiemDanh> DiemDanhs { get; set; }
        public virtual DbSet<DScanhcao> DScanhcaos { get; set; }
        public virtual DbSet<DSCoVanHT> DSCoVanHTs { get; set; }
        public virtual DbSet<DSDeThi> DSDeThis { get; set; }
        public virtual DbSet<DSGiamThi> DSGiamThis { get; set; }
        public virtual DbSet<DSGiangDuong> DSGiangDuongs { get; set; }
        public virtual DbSet<DSGVChamBai> DSGVChamBais { get; set; }
        public virtual DbSet<DSGVHP> DSGVHPs { get; set; }
        public virtual DbSet<DSHocBong> DSHocBongs { get; set; }
        public virtual DbSet<DSHPThiKetThuc> DSHPThiKetThucs { get; set; }
        public virtual DbSet<DSKQHT> DSKQHTs { get; set; }
        public virtual DbSet<DSSVLopHP> DSSVLopHPs { get; set; }
        public virtual DbSet<DSSVThiKetThuc> DSSVThiKetThucs { get; set; }
        public virtual DbSet<GiangDuong> GiangDuongs { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<HinhThucHoc> HinhThucHocs { get; set; }
        public virtual DbSet<HocBong> HocBongs { get; set; }
        public virtual DbSet<HocPhan> HocPhans { get; set; }
        public virtual DbSet<HocViGV> HocViGVs { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<KhoaSv> KhoaSvs { get; set; }
        public virtual DbSet<KyHoc> KyHocs { get; set; }
        public virtual DbSet<LichHP> LichHPs { get; set; }
        public virtual DbSet<LopCNSv> LopCNSvs { get; set; }
        public virtual DbSet<LopHP> LopHPs { get; set; }
        public virtual DbSet<NganhDT> NganhDTs { get; set; }
        public virtual DbSet<PhanKT> PhanKTs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<ThiKetThuc> ThiKetThucs { get; set; }
        public virtual DbSet<TietHoc> TietHocs { get; set; }
        public virtual DbSet<TrinhDoNN> TrinhDoNNs { get; set; }
        public virtual DbSet<XepLoai> XepLoais { get; set; }
        public virtual DbSet<DSDiemDanhSV> DSDiemDanhSVs { get; set; }
        public virtual DbSet<colName> colNames { get; set; }
        public virtual DbSet<tableName> tableNames { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaiThi>()
                .Property(e => e.maBaiThi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BaiThi>()
                .HasMany(e => e.DSDeThis)
                .WithRequired(e => e.BaiThi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaiThi>()
                .HasMany(e => e.DSGVChamBais)
                .WithRequired(e => e.BaiThi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BaiThi>()
                .HasMany(e => e.DSSVThiKetThucs)
                .WithRequired(e => e.BaiThi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoMon>()
                .Property(e => e.maTruongBM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoMon>()
                .Property(e => e.maBM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoMon>()
                .Property(e => e.maKhoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BoMon>()
                .HasMany(e => e.ChuyenNganhDTs)
                .WithOptional(e => e.BoMon)
                .HasForeignKey(e => e.maBoMon);

            modelBuilder.Entity<BoMon>()
                .HasMany(e => e.GiangViens)
                .WithOptional(e => e.BoMon)
                .HasForeignKey(e => e.maBM);

            modelBuilder.Entity<CanhCao>()
                .Property(e => e.maCanhCao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CanhCao>()
                .HasMany(e => e.DScanhcaos)
                .WithRequired(e => e.CanhCao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CHiTietHP>()
                .Property(e => e.maHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenNganhDT>()
                .Property(e => e.maNganhDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenNganhDT>()
                .Property(e => e.maChuyenNganh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenNganhDT>()
                .Property(e => e.maBoMon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ChuyenNganhDT>()
                .HasMany(e => e.LopCNSvs)
                .WithOptional(e => e.ChuyenNganhDT)
                .HasForeignKey(e => e.maCNDT);

            modelBuilder.Entity<DiemDanh>()
                .Property(e => e.maDD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DiemDanh>()
                .Property(e => e.maLopHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DiemDanh>()
                .HasMany(e => e.DSDiemDanhSVs)
                .WithRequired(e => e.DiemDanh)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DScanhcao>()
                .Property(e => e.maCanhCao)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DScanhcao>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSCoVanHT>()
                .Property(e => e.maLopCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSCoVanHT>()
                .Property(e => e.maCV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSDeThi>()
                .Property(e => e.maBaiThi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSDeThi>()
                .Property(e => e.maDeThi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSGiamThi>()
                .Property(e => e.maThiKetThuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSGiamThi>()
                .Property(e => e.maGV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSGiangDuong>()
                .Property(e => e.maGD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSGiangDuong>()
                .Property(e => e.maLopHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSGVChamBai>()
                .Property(e => e.maBaiThi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSGVChamBai>()
                .Property(e => e.maGV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSGVHP>()
                .Property(e => e.maGV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSGVHP>()
                .Property(e => e.maHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSHocBong>()
                .Property(e => e.maHocBong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSHocBong>()
                .Property(e => e.MaSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSHPThiKetThuc>()
                .Property(e => e.maLopHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSHPThiKetThuc>()
                .Property(e => e.maThiKetThuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSKQHT>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSKQHT>()
                .Property(e => e.tenKy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSSVLopHP>()
                .Property(e => e.malopHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSSVLopHP>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSSVThiKetThuc>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSSVThiKetThuc>()
                .Property(e => e.maBaiThi)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSSVThiKetThuc>()
                .Property(e => e.maThiKetThuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiangDuong>()
                .Property(e => e.maGD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiangDuong>()
                .HasMany(e => e.DSGiangDuongs)
                .WithRequired(e => e.GiangDuong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.maGV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.maBM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.sdt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.BoMons)
                .WithOptional(e => e.GiangVien)
                .HasForeignKey(e => e.maTruongBM);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.DSCoVanHTs)
                .WithRequired(e => e.GiangVien)
                .HasForeignKey(e => e.maCV)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.DSGiamThis)
                .WithRequired(e => e.GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.DSGVChamBais)
                .WithRequired(e => e.GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.DSGVHPs)
                .WithRequired(e => e.GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.HocViGVs)
                .WithRequired(e => e.GiangVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.Khoas)
                .WithOptional(e => e.GiangVien)
                .HasForeignKey(e => e.maTruongKhoa);

            modelBuilder.Entity<HinhThucHoc>()
                .HasMany(e => e.CHiTietHPs)
                .WithRequired(e => e.HinhThucHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocBong>()
                .Property(e => e.maHocBong)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HocBong>()
                .HasMany(e => e.DSHocBongs)
                .WithRequired(e => e.HocBong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocPhan>()
                .Property(e => e.maHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HocPhan>()
                .Property(e => e.maPKT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HocPhan>()
                .HasMany(e => e.CHiTietHPs)
                .WithRequired(e => e.HocPhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocPhan>()
                .HasMany(e => e.DSGVHPs)
                .WithRequired(e => e.HocPhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocPhan>()
                .HasMany(e => e.LichHPs)
                .WithRequired(e => e.HocPhan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HocViGV>()
                .Property(e => e.maGV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.maTruongKhoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Khoa>()
                .Property(e => e.maKhoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KyHoc>()
                .Property(e => e.tenKy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KyHoc>()
                .HasMany(e => e.DSKQHTs)
                .WithRequired(e => e.KyHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LichHP>()
                .Property(e => e.maHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LichHP>()
                .Property(e => e.tietHoc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LopCNSv>()
                .Property(e => e.maLopCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LopCNSv>()
                .Property(e => e.maCNDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LopCNSv>()
                .HasMany(e => e.DSCoVanHTs)
                .WithRequired(e => e.LopCNSv)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHP>()
                .Property(e => e.maHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LopHP>()
                .Property(e => e.maLopHP)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LopHP>()
                .HasMany(e => e.DiemDanhs)
                .WithRequired(e => e.LopHP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHP>()
                .HasMany(e => e.DSGiangDuongs)
                .WithRequired(e => e.LopHP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHP>()
                .HasMany(e => e.DSHPThiKetThucs)
                .WithRequired(e => e.LopHP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LopHP>()
                .HasMany(e => e.DSSVLopHPs)
                .WithRequired(e => e.LopHP)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NganhDT>()
                .Property(e => e.maNganhDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NganhDT>()
                .Property(e => e.maBoMon)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PhanKT>()
                .Property(e => e.maPKT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.maLopCN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.sdt)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.sdtPhuHUynh)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.DScanhcaos)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.DSHocBongs)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.DSKQHTs)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.DSSVLopHPs)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.DSSVThiKetThucs)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.DSDiemDanhSVs)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SinhVien>()
                .HasMany(e => e.TrinhDoNNs)
                .WithRequired(e => e.SinhVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThiKetThuc>()
                .Property(e => e.maThiKetThuc)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ThiKetThuc>()
                .HasMany(e => e.DSGiamThis)
                .WithRequired(e => e.ThiKetThuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThiKetThuc>()
                .HasMany(e => e.DSHPThiKetThucs)
                .WithRequired(e => e.ThiKetThuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ThiKetThuc>()
                .HasMany(e => e.DSSVThiKetThucs)
                .WithRequired(e => e.ThiKetThuc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TietHoc>()
                .Property(e => e.tietHoc1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TietHoc>()
                .HasMany(e => e.LichHPs)
                .WithRequired(e => e.TietHoc1)
                .HasForeignKey(e => e.tietHoc)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TrinhDoNN>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSDiemDanhSV>()
                .Property(e => e.maDD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DSDiemDanhSV>()
                .Property(e => e.maSV)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
