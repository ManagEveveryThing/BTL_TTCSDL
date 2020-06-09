using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdminWeb.Models.DB;

namespace AdminWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DBcontext_QLDT db = new DBcontext_QLDT();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Table()
        {
            ViewBag.tableNameList = db.tableNames.ToList();
            return View();
        }
        [HttpGet]
        public ActionResult FindingStudentAjax(string key, string check1, string check2)
        {
            int type;
            if (check1 == "true" && check2 == "false")
            {
                type = 1;
            }
            else
            if (check1 == "false" && check2 == "true")
            {
                type = 2;
            }
            else
                type = 3;
            var result = db.Database.SqlQuery<findStudent>("select maSV,tenSV,hoSV,ngaySinh,TenLopCN,TenKhoaSV,email,sdt from dbo.timKiemSV(" + type.ToString() + " ,N'" + key + "')").ToList();
            return PartialView("_resultFindingStudent", result);
        }
        public ActionResult FindingStudent()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FindingTKTAjax(string keyTKT)
        {
            var result = db.Database.SqlQuery<ThiKetThuc>("select * from ThiKetThuc where maThiKetThuc like '%"+ keyTKT + "%'").ToList();
            return PartialView("_ReTKT", result);
        }
        [HttpGet]
        public ActionResult FindingTKTAllSVAjax(string keyTKT)
        {
            var result = db.Database.SqlQuery<findTKT>("select * from dbo.timKiemTKT('"+keyTKT +"', " + 1 + " , '')").ToList();
            return PartialView("_resultFindingTest", result);
        }

        public ActionResult FindingTKT()
        {
            return View();
        }
        
    


        ////////////////// them sua xoa
        [HttpGet]
        public ActionResult getTableData(string tableName)
        {
            object data;
            int count = 0;
            ViewBag.colName = db.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            switch (tableName)
            {
                case "BaiThi":
                    data = db.Database.SqlQuery<BaiThi>("select * from " + tableName).ToList();
                    count = (data as List<BaiThi>).Count;
                    break;
                case "BoMon":
                    data = db.Database.SqlQuery<BoMon>("select * from " + tableName).ToList();
                    count = (data as List<BoMon>).Count;
                    break;
                case "CanhCao":
                    data = db.Database.SqlQuery<CanhCao>("select * from " + tableName).ToList();
                    count = (data as List<CanhCao>).Count;
                    break;
                case "CHiTietHP":
                    data = db.Database.SqlQuery<CHiTietHP>("select * from " + tableName).ToList();
                    count = (data as List<CHiTietHP>).Count;
                    break;
                case "ChuyenNganhDT":
                    data = db.Database.SqlQuery<ChuyenNganhDT>("select * from " + tableName).ToList();
                    count = (data as List<ChuyenNganhDT>).Count;
                    break;
                case "DiemDanh":
                    data = db.Database.SqlQuery<DiemDanh>("select * from " + tableName).ToList();
                    count = (data as List<DiemDanh>).Count;
                    break;
                case "DScanhcao":
                    data = db.Database.SqlQuery<DScanhcao>("select * from " + tableName).ToList();
                    count = (data as List<DScanhcao>).Count;
                    break;
                case "DSCoVanHT":
                    data = db.Database.SqlQuery<DSCoVanHT>("select * from " + tableName).ToList();
                    count = (data as List<DSCoVanHT>).Count;
                    break;
                case "DSDeThi":
                    data = db.Database.SqlQuery<DSDeThi>("select * from " + tableName).ToList();
                    count = (data as List<DSDeThi>).Count;
                    break;
                case "DSDiemDanhSV":
                    data = db.Database.SqlQuery<DSDiemDanhSV>("select * from " + tableName).ToList();
                    count = (data as List<DSDiemDanhSV>).Count;
                    break;
                case "DSGiamThi":
                    data = db.Database.SqlQuery<DSGiamThi>("select * from " + tableName).ToList();
                    count = (data as List<DSGiamThi>).Count;
                    break;
                case "DSGiangDuong":
                    data = db.Database.SqlQuery<DSGiangDuong>("select * from " + tableName).ToList();
                    count = (data as List<DSGiangDuong>).Count;
                    break;
                case "DSGVChamBai":
                    data = db.Database.SqlQuery<DSGVChamBai>("select * from " + tableName).ToList();
                    count = (data as List<DSGVChamBai>).Count;
                    break;
                case "DSGVHP":
                    data = db.Database.SqlQuery<DSGVHP>("select * from " + tableName).ToList();
                    count = (data as List<DSGVHP>).Count;
                    break;
                case "DSHocBong":
                    data = db.Database.SqlQuery<DSHocBong>("select * from " + tableName).ToList();
                    count = (data as List<DSHocBong>).Count;
                    break;
                case "DSHPThiKetThuc":
                    data = db.Database.SqlQuery<DSHPThiKetThuc>("select * from " + tableName).ToList();
                    count = (data as List<DSHPThiKetThuc>).Count;
                    break;
                case "DSKQHT":
                    data = db.Database.SqlQuery<DSKQHT>("select * from " + tableName).ToList();
                    count = (data as List<DSKQHT>).Count;
                    break;
                case "DSSVLopHP":
                    data = db.Database.SqlQuery<DSSVLopHP>("select * from " + tableName).ToList();
                    count = (data as List<DSSVLopHP>).Count;
                    break;
                case "DSSVThiKetThuc":
                    data = db.Database.SqlQuery<DSSVThiKetThuc>("select * from " + tableName).ToList();
                    count = (data as List<DSSVThiKetThuc>).Count;
                    break;
                case "GiangDuong":
                    data = db.Database.SqlQuery<GiangDuong>("select * from " + tableName).ToList();
                    count = (data as List<GiangDuong>).Count;
                    break;
                case "GiangVien":
                    data = db.Database.SqlQuery<GiangVien>("select * from " + tableName).ToList();
                    count = (data as List<GiangVien>).Count;
                    break;
                case "HinhThucHoc":
                    data = db.Database.SqlQuery<HinhThucHoc>("select * from " + tableName).ToList();
                    count = (data as List<HinhThucHoc>).Count;
                    break;
                case "HocBong":
                    data = db.Database.SqlQuery<HocBong>("select * from " + tableName).ToList();
                    count = (data as List<HocBong>).Count;
                    break;
                case "HocPhan":
                    data = db.Database.SqlQuery<HocPhan>("select * from " + tableName).ToList();
                    count = (data as List<HocPhan>).Count;
                    break;
                case "HocViGV":
                    data = db.Database.SqlQuery<HocViGV>("select * from " + tableName).ToList();
                    count = (data as List<HocViGV>).Count;
                    break;
                case "Khoa":
                    data = db.Database.SqlQuery<Khoa>("select * from " + tableName).ToList();
                    count = (data as List<Khoa>).Count;
                    break;
                case "KhoaSv":
                    data = db.Database.SqlQuery<KhoaSv>("select * from " + tableName).ToList();
                    count = (data as List<KhoaSv>).Count;
                    break;
                case "KyHoc":
                    data = db.Database.SqlQuery<KyHoc>("select * from " + tableName).ToList();
                    count = (data as List<KyHoc>).Count;
                    break;
                case "LichHP":
                    data = db.Database.SqlQuery<LichHP>("select * from " + tableName).ToList();
                    count = (data as List<LichHP>).Count;
                    break;
                case "LopCNSv":
                    data = db.Database.SqlQuery<LopCNSv>("select * from " + tableName).ToList();
                    count = (data as List<LopCNSv>).Count;
                    break;
                case "LopHP":
                    data = db.Database.SqlQuery<LopHP>("select * from " + tableName).ToList();
                    count = (data as List<LopHP>).Count;
                    break;
                case "NganhDT":
                    data = db.Database.SqlQuery<NganhDT>("select * from " + tableName).ToList();
                    count = (data as List<NganhDT>).Count;
                    break;
                case "PhanKT":
                    data = db.Database.SqlQuery<PhanKT>("select * from " + tableName).ToList();
                    count = (data as List<PhanKT>).Count;
                    break;
                case "SinhVien":
                    data = db.Database.SqlQuery<SinhVien>("select * from " + tableName).ToList();
                    count = (data as List<SinhVien>).Count;
                    break;
                case "ThiKetThuc":
                    data = db.Database.SqlQuery<ThiKetThuc>("select * from " + tableName).ToList();
                    count = (data as List<ThiKetThuc>).Count;
                    break;
                case "TietHoc":
                    data = db.Database.SqlQuery<TietHoc>("select * from " + tableName).ToList();
                    count = (data as List<TietHoc>).Count;
                    break;
                case "TrinhDoNN":
                    data = db.Database.SqlQuery<TrinhDoNN>("select * from " + tableName).ToList();
                    count = (data as List<TrinhDoNN>).Count;
                    break;
                case "XepLoai":
                    data = db.Database.SqlQuery<XepLoai>("select * from " + tableName).ToList();
                    count = (data as List<XepLoai>).Count;
                    break;
                default:
                    data = null;
                    break;
            }
            ViewBag.tableName = tableName;
            ViewBag.countRow = count;
            return PartialView("_TableDB", data);
        }

        [HttpGet]
        public ActionResult ShowRow(string tableName, string key1, string key2,string key3, string actionName)
        {
            List<string> re = new List<string>();
            ViewBag.actionName = actionName;
            ViewBag.nameTable = tableName;
            ViewBag.colName = db.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            if (key1 != "")
            {
                key1 = key1.Trim();
                if (key2 != null) key2 = key2.Trim();
                if (key3 != null) key3 = key3.Trim();
                object data;

                switch (tableName)
                {
                    case "BaiThi":
                        data = db.Database.SqlQuery<BaiThi>("select * from " + tableName + " where maBaiThi = '" + key1 + "'").ToList();
                        //data = db.BaiThis.Find(key1);
                        re.Add((data as List<BaiThi>)[0].maBaiThi);
                        re.Add((data as List<BaiThi>)[0].ngayTao.ToString());
                        re.Add((data as List<BaiThi>)[0].chuThich);
                        break;
                    case "BoMon":
                        data = db.Database.SqlQuery<BoMon>("select * from " + tableName + " where maBM = '" + key1 + "'").ToList();
                        re.Add((data as List<BoMon>)[0].maTruongBM);
                        re.Add((data as List<BoMon>)[0].maBM);
                        re.Add((data as List<BoMon>)[0].tenBM);
                        re.Add((data as List<BoMon>)[0].chuThich);
                        re.Add((data as List<BoMon>)[0].soLuongGV.ToString());
                        break;
                    case "CanhCao":
                        data = db.Database.SqlQuery<CanhCao>("select * from " + tableName + " where maCanhCao = '" + key1 + "'").ToList();
                        re.Add((data as List<CanhCao>)[0].maCanhCao);
                        re.Add((data as List<CanhCao>)[0].tenCanhCao);
                        re.Add((data as List<CanhCao>)[0].chuThich);
                        break;
                    case "CHiTietHP":
                        data = db.Database.SqlQuery<CHiTietHP>("select * from " + tableName + " where maHP = '" + key1 + "' and TenHinhThuc = '" + key2 + "'").ToList();
                        re.Add((data as List<CHiTietHP>)[0].maHP);
                        re.Add((data as List<CHiTietHP>)[0].TenHinhThuc);
                        re.Add((data as List<CHiTietHP>)[0].sotiet.ToString());
                        re.Add((data as List<CHiTietHP>)[0].chuThich);
                        break;
                    case "ChuyenNganhDT":
                        data = db.Database.SqlQuery<ChuyenNganhDT>("select * from " + tableName + " where maChuyenNganh = '" + key1 + "'").ToList();
                        re.Add((data as List<ChuyenNganhDT>)[0].maNganhDT);
                        re.Add((data as List<ChuyenNganhDT>)[0].maChuyenNganh);
                        re.Add((data as List<ChuyenNganhDT>)[0].tenChuyenNganh);
                        re.Add((data as List<ChuyenNganhDT>)[0].chuThich);
                        break;
                    case "DiemDanh":
                        data = db.Database.SqlQuery<DiemDanh>("select * from " + tableName + " where maDD = '" + key1 + "'").ToList();
                        re.Add((data as List<DiemDanh>)[0].maDD);
                        re.Add((data as List<DiemDanh>)[0].maLopHP);
                        re.Add((data as List<DiemDanh>)[0].soBuoiDiemDanh.ToString());
                        break;
                    case "DScanhcao":
                        data = db.Database.SqlQuery<DScanhcao>("select * from " + tableName + " where maCanhCao = '" + key1 + "' and maSV = '" + key2 + "'").ToList();
                        re.Add((data as List<DScanhcao>)[0].maCanhCao);
                        re.Add((data as List<DScanhcao>)[0].maSV);
                        re.Add((data as List<DScanhcao>)[0].chuThich);
                        break;
                    case "DSCoVanHT":
                        data = db.Database.SqlQuery<DSCoVanHT>("select * from " + tableName + " where maLopCN = '" + key1 + "' and maCV = '" + key2 + "'").ToList();
                        re.Add((data as List<DSCoVanHT>)[0].maLopCN);
                        re.Add((data as List<DSCoVanHT>)[0].maCV);
                        re.Add((data as List<DSCoVanHT>)[0].chuThich);
                        break;
                    case "DSDeThi":
                        data = db.Database.SqlQuery<DSDeThi>("select * from " + tableName + " where maBaiThi = '" + key1 + "' and maDeThi = '" + key2 + "'").ToList();
                        re.Add((data as List<DSDeThi>)[0].maBaiThi);
                        re.Add((data as List<DSDeThi>)[0].maDeThi);
                        re.Add((data as List<DSDeThi>)[0].soTo.ToString());
                        re.Add((data as List<DSDeThi>)[0].chuThich);
                        break;
                    case "DSDiemDanhSV":
                        data = db.Database.SqlQuery<DSDiemDanhSV>("select * from " + tableName + " where maDD = '" + key1 + "' and maSV = '" + key2 + "'").ToList();
                        re.Add((data as List<DSDiemDanhSV>)[0].maDD);
                        re.Add((data as List<DSDiemDanhSV>)[0].maSV);
                        re.Add((data as List<DSDiemDanhSV>)[0].soBuoi.ToString());
                        break;
                    case "DSGiamThi":
                        data = db.Database.SqlQuery<DSGiamThi>("select * from " + tableName + " where maThiKetThuc = '" + key1 + "' and maGV = '" + key2 + "'").ToList();
                        re.Add((data as List<DSGiamThi>)[0].maThiKetThuc);
                        re.Add((data as List<DSGiamThi>)[0].maGV);
                        re.Add((data as List<DSGiamThi>)[0].ngayPC.ToString());
                        re.Add((data as List<DSGiamThi>)[0].chuThich);
                        break;
                    case "DSGiangDuong":
                        data = db.Database.SqlQuery<DSGiangDuong>("select * from " + tableName + " where maGD = '" + key1 + "' and maLopHP = '" + key2 + "'").ToList();
                        re.Add((data as List<DSGiangDuong>)[0].maGD);
                        re.Add((data as List<DSGiangDuong>)[0].maLopHP);
                        re.Add((data as List<DSGiangDuong>)[0].thu.ToString());
                        re.Add((data as List<DSGiangDuong>)[0].chuThich);
                        break;
                    case "DSGVChamBai":
                        data = db.Database.SqlQuery<DSGVChamBai>("select * from " + tableName + " where maBaiThi = '" + key1 + "' and maGV = '" + key2 + "'").ToList();
                        re.Add((data as List<DSGVChamBai>)[0].maBaiThi);
                        re.Add((data as List<DSGVChamBai>)[0].maGV);
                        re.Add((data as List<DSGVChamBai>)[0].ngayCham.ToString());
                        re.Add((data as List<DSGVChamBai>)[0].diem.ToString());
                        re.Add((data as List<DSGVChamBai>)[0].chuThich);
                        break;
                    case "DSGVHP":
                        data = db.Database.SqlQuery<DSGVHP>("select * from " + tableName + " where maGV = '" + key1 + "' and maHP = '" + key2 + "'").ToList();
                        re.Add((data as List<DSGVHP>)[0].maGV);
                        re.Add((data as List<DSGVHP>)[0].maHP);
                        re.Add((data as List<DSGVHP>)[0].chuThich);
                        break;
                    case "DSHocBong":
                        data = db.Database.SqlQuery<DSHocBong>("select * from " + tableName + " where maHocBong = '" + key1 + "' and MaSV = '" + key2 + "'").ToList();
                        re.Add((data as List<DSHocBong>)[0].maHocBong);
                        re.Add((data as List<DSHocBong>)[0].MaSV);
                        re.Add((data as List<DSHocBong>)[0].chuThich);
                        break;
                    case "DSHPThiKetThuc":
                        data = db.Database.SqlQuery<DSHPThiKetThuc>("select * from " + tableName + " where maLopHP = '" + key1 + "' and maThiKetThuc = '" + key2 + "'").ToList();
                        re.Add((data as List<DSHPThiKetThuc>)[0].maLopHP);
                        re.Add((data as List<DSHPThiKetThuc>)[0].maThiKetThuc);
                        re.Add((data as List<DSHPThiKetThuc>)[0].chuThich);
                        break;
                    case "DSKQHT":
                        data = db.Database.SqlQuery<DSKQHT>("select * from " + tableName + " where maSV = '" + key1 + "' and tenKy = '" + key2 + "'").ToList();
                        re.Add((data as List<DSKQHT>)[0].maSV);
                        re.Add((data as List<DSKQHT>)[0].tenXepLoai);
                        re.Add((data as List<DSKQHT>)[0].tenKy);
                        re.Add((data as List<DSKQHT>)[0].diem.ToString());
                        re.Add((data as List<DSKQHT>)[0].sotinchino.ToString());
                        re.Add((data as List<DSKQHT>)[0].chuThich);
                        break;
                    case "DSSVLopHP":
                        data = db.Database.SqlQuery<DSSVLopHP>("select * from " + tableName + " where malopHP = '" + key1 + "' and maSV = '" + key2 + "'").ToList();
                        re.Add((data as List<DSSVLopHP>)[0].malopHP);
                        re.Add((data as List<DSSVLopHP>)[0].maSV);
                        re.Add((data as List<DSSVLopHP>)[0].chuThich.ToString());
                        re.Add((data as List<DSSVLopHP>)[0].diem1.ToString());
                        re.Add((data as List<DSSVLopHP>)[0].diem3.ToString());
                        re.Add((data as List<DSSVLopHP>)[0].diem6.ToString());
                        re.Add((data as List<DSSVLopHP>)[0].diemHe4.ToString());
                        break;
                    case "DSSVThiKetThuc":
                        data = db.Database.SqlQuery<DSSVThiKetThuc>("select * from " + tableName + " where maSV = '" + key1 + "' and maBaiThi = '" + key2 + "' and maThiKetThuc = '" + key3 + "'").ToList();
                        re.Add((data as List<DSSVThiKetThuc>)[0].maSV);
                        re.Add((data as List<DSSVThiKetThuc>)[0].maBaiThi);
                        re.Add((data as List<DSSVThiKetThuc>)[0].maThiKetThuc);
                        re.Add((data as List<DSSVThiKetThuc>)[0].chuThich);
                        break;
                    case "GiangDuong":
                        data = db.Database.SqlQuery<GiangDuong>("select * from " + tableName + " where maGD = '" + key1 + "'").ToList();
                        re.Add((data as List<GiangDuong>)[0].maGD);
                        re.Add((data as List<GiangDuong>)[0].soPhong.ToString());
                        re.Add((data as List<GiangDuong>)[0].tang.ToString());
                        re.Add((data as List<GiangDuong>)[0].viTri);
                        re.Add((data as List<GiangDuong>)[0].sucChua.ToString());
                        break;
                    case "GiangVien":
                        data = db.Database.SqlQuery<GiangVien>("select * from " + tableName + " where maGV = '" + key1 + "'").ToList();
                        re.Add((data as List<GiangVien>)[0].maGV);
                        re.Add((data as List<GiangVien>)[0].maBM);
                        re.Add((data as List<GiangVien>)[0].tenGV);
                        re.Add((data as List<GiangVien>)[0].hoGV);
                        re.Add((data as List<GiangVien>)[0].ngaySinh.ToString());
                        re.Add((data as List<GiangVien>)[0].gioiTinh);
                        re.Add((data as List<GiangVien>)[0].email);
                        re.Add((data as List<GiangVien>)[0].sdt);
                        break;
                    case "HinhThucHoc":
                        data = db.Database.SqlQuery<HinhThucHoc>("select * from " + tableName + " where tenHinhThuc = '" + key1 + "'").ToList();
                        re.Add((data as List<HinhThucHoc>)[0].tenHinhThuc);
                        re.Add((data as List<HinhThucHoc>)[0].chuThich);
                        break;
                    case "HocBong":
                        data = db.Database.SqlQuery<HocBong>("select * from " + tableName + " where maHocBong = '" + key1 + "'").ToList();
                        re.Add((data as List<HocBong>)[0].maHocBong);
                        re.Add((data as List<HocBong>)[0].tenHocBong);
                        re.Add((data as List<HocBong>)[0].chuThich);
                        break;
                    case "HocPhan":
                        data = db.Database.SqlQuery<HocPhan>("select * from " + tableName + " where maHP = '" + key1 + "'").ToList();
                        re.Add((data as List<HocPhan>)[0].maHP);
                        re.Add((data as List<HocPhan>)[0].soTC.ToString());
                        re.Add((data as List<HocPhan>)[0].maPKT);
                        re.Add((data as List<HocPhan>)[0].tenHP);
                        re.Add((data as List<HocPhan>)[0].chuThich);
                        break;
                    case "HocViGV":
                        data = db.Database.SqlQuery<HocViGV>("select * from " + tableName + " where maGV = '" + key1 + "' and tenHV = '" + key2 + "'").ToList();
                        re.Add((data as List<HocViGV>)[0].maGV);
                        re.Add((data as List<HocViGV>)[0].tenHV);
                        re.Add((data as List<HocViGV>)[0].chuThich);
                        break;
                    case "Khoa":
                        data = db.Database.SqlQuery<Khoa>("select * from " + tableName + " where maKhoa = '" + key1 + "'").ToList();
                        re.Add((data as List<Khoa>)[0].maTruongKhoa);
                        re.Add((data as List<Khoa>)[0].maKhoa);
                        re.Add((data as List<Khoa>)[0].tenKhoa);
                        re.Add((data as List<Khoa>)[0].chuThich);
                        break;
                    case "KhoaSv":
                        data = db.Database.SqlQuery<KhoaSv>("select * from " + tableName + " where maKhoaSv = '" + key1 + "'").ToList();
                        re.Add((data as List<KhoaSv>)[0].maKhoaSv);
                        re.Add((data as List<KhoaSv>)[0].tenKhoaSv);
                        re.Add((data as List<KhoaSv>)[0].namThanhLap.ToString());
                        re.Add((data as List<KhoaSv>)[0].chuThich);
                        re.Add((data as List<KhoaSv>)[0].soLuongSV.ToString());
                        break;
                    case "KyHoc":
                        data = db.Database.SqlQuery<KyHoc>("select * from " + tableName + " where tenKy = '" + key1 + "'").ToList();
                        re.Add((data as List<KyHoc>)[0].tenKy);
                        re.Add((data as List<KyHoc>)[0].chuThich);
                        break;
                    case "LichHP":
                        data = db.Database.SqlQuery<LichHP>("select * from " + tableName + " where maHP = '" + key1 + "' and tietHoc = '" + key2 + "' and thu = '" + key3 + "'").ToList();
                        re.Add((data as List<LichHP>)[0].maHP);
                        re.Add((data as List<LichHP>)[0].tietHoc);
                        re.Add((data as List<LichHP>)[0].soLuong.ToString());
                        re.Add((data as List<LichHP>)[0].thu);
                        re.Add((data as List<LichHP>)[0].chuThich);
                        break;
                    case "LopCNSv":
                        data = db.Database.SqlQuery<LopCNSv>("select * from " + tableName + " where maLopCN = '" + key1 + "'").ToList();
                        re.Add((data as List<LopCNSv>)[0].maLopCN);
                        re.Add((data as List<LopCNSv>)[0].tenLopCN);
                        re.Add((data as List<LopCNSv>)[0].maCNDT);
                        re.Add((data as List<LopCNSv>)[0].chuThich);
                        re.Add((data as List<LopCNSv>)[0].soLuongSV.ToString());
                        break;
                    case "LopHP":
                        data = db.Database.SqlQuery<LopHP>("select * from " + tableName + " where maLopHP = '" + key1 + "'").ToList();
                        re.Add((data as List<LopHP>)[0].maHP);
                        re.Add((data as List<LopHP>)[0].maLopHP);
                        re.Add((data as List<LopHP>)[0].maxStore.ToString());
                        re.Add((data as List<LopHP>)[0].chuThich);
                        re.Add((data as List<LopHP>)[0].curStore.ToString());
                        break;
                    case "NganhDT":
                        data = db.Database.SqlQuery<NganhDT>("select * from " + tableName + " where maNganhDT = '" + key1 + "'").ToList();
                        re.Add((data as List<NganhDT>)[0].maNganhDT);
                        re.Add((data as List<NganhDT>)[0].tenNganhDT);
                        re.Add((data as List<NganhDT>)[0].maBoMon);
                        re.Add((data as List<NganhDT>)[0].chuThich);
                        break;
                    case "PhanKT":
                        data = db.Database.SqlQuery<PhanKT>("select * from " + tableName + " where maPKT = '" + key1 + "'").ToList();
                        re.Add((data as List<PhanKT>)[0].maPKT);
                        re.Add((data as List<PhanKT>)[0].tenPKT);
                        re.Add((data as List<PhanKT>)[0].chuThich);
                        break;
                    case "SinhVien":
                        data = db.Database.SqlQuery<SinhVien>("select * from " + tableName + " where maSV = '" + key1 + "'").ToList();
                        re.Add((data as List<SinhVien>)[0].maSV);
                        re.Add((data as List<SinhVien>)[0].maLopCN);
                        re.Add((data as List<SinhVien>)[0].tenSV);
                        re.Add((data as List<SinhVien>)[0].hoSV);
                        re.Add((data as List<SinhVien>)[0].ngaySinh.ToString());
                        re.Add((data as List<SinhVien>)[0].gioiTinh);
                        re.Add((data as List<SinhVien>)[0].email);
                        re.Add((data as List<SinhVien>)[0].sdt);
                        re.Add((data as List<SinhVien>)[0].sdtPhuHUynh);
                        re.Add((data as List<SinhVien>)[0].maKhoaSv);
                        re.Add((data as List<SinhVien>)[0].chuThich);
                        re.Add((data as List<SinhVien>)[0].isLearn.ToString());
                        break;
                    case "ThiKetThuc":
                        data = db.Database.SqlQuery<ThiKetThuc>("select * from " + tableName + " where maThiKetThuc = '" + key1 + "'").ToList();
                        re.Add((data as List<ThiKetThuc>)[0].maThiKetThuc);
                        re.Add((data as List<ThiKetThuc>)[0].ngayThi.ToString());
                        re.Add((data as List<ThiKetThuc>)[0].thoiGianBatDau.ToString());
                        re.Add((data as List<ThiKetThuc>)[0].chuThich);
                        break;
                    case "TietHoc":
                        data = db.Database.SqlQuery<TietHoc>("select * from " + tableName + " where tietHoc = '" + key1 + "'").ToList();
                        re.Add((data as List<TietHoc>)[0].tietHoc1);
                        re.Add((data as List<TietHoc>)[0].timeStart.ToString());
                        re.Add((data as List<TietHoc>)[0].chuThich);
                        break;
                    case "TrinhDoNN":
                        data = db.Database.SqlQuery<TrinhDoNN>("select * from " + tableName + " where maTrinhDoNN = '" + key1 + "'").ToList();
                        re.Add((data as List<TrinhDoNN>)[0].tenTrinhDoNN);
                        re.Add((data as List<TrinhDoNN>)[0].maSV);
                        re.Add((data as List<TrinhDoNN>)[0].chuThich);
                        break;
                    case "XepLoai":
                        data = db.Database.SqlQuery<XepLoai>("select * from " + tableName + " where tenXepLoai = '" + key1 + "'").ToList();
                        re.Add((data as List<XepLoai>)[0].tenXepLoai);
                        re.Add((data as List<XepLoai>)[0].diem.ToString());
                        re.Add((data as List<XepLoai>)[0].chuThich);
                        break;
                    default:
                        data = null;
                        break;
                }
            }
            else
            {
                re = null;
            }

            return PartialView("_Eachrow", re);
        }

        [HttpPost]
        public ActionResult ModifyRow()
        {
            String tableName = Request.Form["TableName"];
            ViewBag.nameTable = tableName;
            object dataO;
            object data;
            switch (tableName)
            {
                case "BaiThi":
                    data = new BaiThi();
                    (data as BaiThi).maBaiThi = Request.Form["0"];
                    (data as BaiThi).ngayTao = DateTime.Parse(Request.Form["1"]);
                    (data as BaiThi).chuThich = Request.Form["2"];
                    dataO = new BaiThi();
                    (dataO as BaiThi).maBaiThi = Request.Form["50"];
                    (dataO as BaiThi).ngayTao = DateTime.Parse(Request.Form["51"]);
                    (dataO as BaiThi).chuThich = Request.Form["52"];
                    ModBaiThi(data as BaiThi, dataO as BaiThi);
                    data = db.Database.SqlQuery<BaiThi>("select * from " + tableName).ToList();
                    break;
                case "BoMon":
                    data = new BoMon();
                    (data as BoMon).maTruongBM = Request.Form["0"];
                    (data as BoMon).maBM = Request.Form["1"];
                    (data as BoMon).maKhoa = Request.Form["2"];
                    (data as BoMon).tenBM = Request.Form["3"];
                    (data as BoMon).chuThich = Request.Form["4"];
                    (data as BoMon).soLuongGV = Int32.Parse(Request.Form["5"]);
                    dataO = new BoMon();
                    (dataO as BoMon).maTruongBM = Request.Form["50"];
                    (dataO as BoMon).maBM = Request.Form["51"];
                    (dataO as BoMon).maKhoa = Request.Form["52"];
                    (dataO as BoMon).tenBM = Request.Form["53"];
                    (dataO as BoMon).chuThich = Request.Form["54"];
                    (dataO as BoMon).soLuongGV = Int32.Parse(Request.Form["55"]);
                    ModBoMon(data as BoMon, dataO as BoMon);
                    data = db.Database.SqlQuery<BoMon>("select * from " + tableName).ToList();
                    break;
                case "CanhCao":
                    data = new CanhCao();
                    (data as CanhCao).maCanhCao = Request.Form["0"];
                    (data as CanhCao).tenCanhCao = Request.Form["1"];
                    (data as CanhCao).chuThich = Request.Form["2"];
                    dataO = new CanhCao();
                    (dataO as CanhCao).maCanhCao = Request.Form["50"];
                    (dataO as CanhCao).tenCanhCao = Request.Form["51"];
                    (dataO as CanhCao).chuThich = Request.Form["52"];
                    ModCanhCao(data as CanhCao, dataO as CanhCao);
                    data = db.Database.SqlQuery<CanhCao>("select * from " + tableName).ToList();
                    break;
                case "CHiTietHP":
                    data = new CHiTietHP();
                    (data as CHiTietHP).maHP = Request.Form["0"];
                    (data as CHiTietHP).TenHinhThuc = Request.Form["1"];
                    (data as CHiTietHP).sotiet = Int32.Parse((Request.Form["2"]));
                    (data as CHiTietHP).chuThich = Request.Form["3"];
                    dataO = new CHiTietHP();
                    (dataO as CHiTietHP).maHP = Request.Form["50"];
                    (dataO as CHiTietHP).TenHinhThuc = Request.Form["51"];
                    (dataO as CHiTietHP).sotiet = Int32.Parse((Request.Form["52"]));
                    (dataO as CHiTietHP).chuThich = Request.Form["53"];
                    ModCHiTietHP(data as CHiTietHP, dataO as CHiTietHP);
                    data = db.Database.SqlQuery<CHiTietHP>("select * from " + tableName).ToList();
                    break;
                case "ChuyenNganhDT":
                    data = new ChuyenNganhDT();
                    (data as ChuyenNganhDT).maNganhDT = Request.Form["0"];
                    (data as ChuyenNganhDT).maChuyenNganh = Request.Form["1"];
                    (data as ChuyenNganhDT).maBoMon = Request.Form["2"];
                    (data as ChuyenNganhDT).tenChuyenNganh = Request.Form["3"];
                    (data as ChuyenNganhDT).chuThich = Request.Form["4"];
                    dataO = new ChuyenNganhDT();
                    (dataO as ChuyenNganhDT).maNganhDT = Request.Form["50"];
                    (dataO as ChuyenNganhDT).maChuyenNganh = Request.Form["51"];
                    (dataO as ChuyenNganhDT).maBoMon = Request.Form["52"];
                    (dataO as ChuyenNganhDT).tenChuyenNganh = Request.Form["53"];
                    (dataO as ChuyenNganhDT).chuThich = Request.Form["54"];
                    ModChuyenNganhDT(data as ChuyenNganhDT, dataO as ChuyenNganhDT);
                    data = db.Database.SqlQuery<ChuyenNganhDT>("select * from " + tableName).ToList();
                    break;
                case "DiemDanh":
                    data = new DiemDanh();
                    (data as DiemDanh).maDD = Request.Form["0"];
                    (data as DiemDanh).maLopHP = Request.Form["1"];
                    (data as DiemDanh).soBuoiDiemDanh = Int32.Parse(Request.Form["2"]);
                    dataO = new DiemDanh();
                    (dataO as DiemDanh).maDD = Request.Form["50"];
                    (dataO as DiemDanh).maLopHP = Request.Form["51"];
                    (dataO as DiemDanh).soBuoiDiemDanh = Int32.Parse(Request.Form["52"]);
                    ModDiemDanh(data as DiemDanh, dataO as DiemDanh);
                    data = db.Database.SqlQuery<DiemDanh>("select * from " + tableName).ToList();
                    break;
                case "DScanhcao":
                    data = new DScanhcao();
                    (data as DScanhcao).maCanhCao = Request.Form["0"];
                    (data as DScanhcao).maSV = Request.Form["1"];
                    (data as DScanhcao).chuThich = Request.Form["2"];
                    dataO = new DScanhcao();
                    (dataO as DScanhcao).maCanhCao = Request.Form["50"];
                    (dataO as DScanhcao).maSV = Request.Form["51"];
                    (dataO as DScanhcao).chuThich = Request.Form["52"];
                    ModDScanhcao(data as DScanhcao, dataO as DScanhcao);
                    data = db.Database.SqlQuery<DScanhcao>("select * from " + tableName).ToList();
                    break;
                case "DSCoVanHT":
                    data = new DSCoVanHT();
                    (data as DSCoVanHT).maLopCN = Request.Form["0"];
                    (data as DSCoVanHT).maCV = Request.Form["1"];
                    (data as DSCoVanHT).chuThich = Request.Form["2"];
                    dataO = new DSCoVanHT();
                    (dataO as DSCoVanHT).maLopCN = Request.Form["50"];
                    (dataO as DSCoVanHT).maCV = Request.Form["51"];
                    (dataO as DSCoVanHT).chuThich = Request.Form["52"];
                    ModDSCoVanHT(data as DSCoVanHT, dataO as DSCoVanHT);
                    data = db.Database.SqlQuery<DSCoVanHT>("select * from " + tableName).ToList();
                    break;
                case "DSDeThi":
                    data = new DSDeThi();
                    (data as DSDeThi).maBaiThi = Request.Form["0"];
                    (data as DSDeThi).maDeThi = Request.Form["1"];
                    (data as DSDeThi).soTo = Int32.Parse((Request.Form["2"]));
                    (data as DSDeThi).chuThich = Request.Form["3"];
                    dataO = new DSDeThi();
                    (dataO as DSDeThi).maBaiThi = Request.Form["50"];
                    (dataO as DSDeThi).maDeThi = Request.Form["51"];
                    (dataO as DSDeThi).soTo = Int32.Parse((Request.Form["52"]));
                    (dataO as DSDeThi).chuThich = Request.Form["53"];
                    ModDSDeThi(data as DSDeThi, dataO as DSDeThi);
                    data = db.Database.SqlQuery<DSDeThi>("select * from " + tableName).ToList();
                    break;
                case "DSDiemDanhSV":
                    data = new DSDiemDanhSV();
                    (data as DSDiemDanhSV).maDD = Request.Form["0"];
                    (data as DSDiemDanhSV).maSV = Request.Form["1"];
                    (data as DSDiemDanhSV).soBuoi = Int32.Parse(Request.Form["2"]);
                    dataO = new DSDiemDanhSV();
                    (dataO as DSDiemDanhSV).maDD = Request.Form["50"];
                    (dataO as DSDiemDanhSV).maSV = Request.Form["51"];
                    (dataO as DSDiemDanhSV).soBuoi = Int32.Parse(Request.Form["52"]);
                    ModDSDiemDanhSV(data as DSDiemDanhSV, dataO as DSDiemDanhSV);
                    data = db.Database.SqlQuery<DSDiemDanhSV>("select * from " + tableName).ToList();
                    break;
                case "DSGiamThi":
                    data = new DSGiamThi();
                    (data as DSGiamThi).maThiKetThuc = Request.Form["0"];
                    (data as DSGiamThi).maGV = Request.Form["1"];
                    (data as DSGiamThi).ngayPC = DateTime.Parse((Request.Form["2"]));
                    (data as DSGiamThi).chuThich = Request.Form["3"];
                    dataO = new DSGiamThi();
                    (dataO as DSGiamThi).maThiKetThuc = Request.Form["50"];
                    (dataO as DSGiamThi).maGV = Request.Form["51"];
                    (dataO as DSGiamThi).ngayPC = DateTime.Parse((Request.Form["52"]));
                    (dataO as DSGiamThi).chuThich = Request.Form["53"];
                    ModDSGiamThi(data as DSGiamThi, dataO as DSGiamThi);
                    data = db.Database.SqlQuery<DSGiamThi>("select * from " + tableName).ToList();
                    break;
                case "DSGiangDuong":
                    data = new DSGiangDuong();
                    (data as DSGiangDuong).maGD = Request.Form["0"];
                    (data as DSGiangDuong).maLopHP = Request.Form["1"];
                    (data as DSGiangDuong).thu = Int32.Parse(Request.Form["2"]);
                    (data as DSGiangDuong).chuThich = Request.Form["3"];
                    dataO = new DSGiangDuong();
                    (dataO as DSGiangDuong).maGD = Request.Form["50"];
                    (dataO as DSGiangDuong).maLopHP = Request.Form["51"];
                    (dataO as DSGiangDuong).thu = Int32.Parse(Request.Form["52"]);
                    (dataO as DSGiangDuong).chuThich = Request.Form["53"];
                    ModDSGiangDuong(data as DSGiangDuong, dataO as DSGiangDuong);
                    data = db.Database.SqlQuery<DSGiangDuong>("select * from " + tableName).ToList();
                    break;
                case "DSGVChamBai":
                    data = new DSGVChamBai();
                    (data as DSGVChamBai).maBaiThi = Request.Form["0"];
                    (data as DSGVChamBai).maGV = Request.Form["1"];
                    (data as DSGVChamBai).ngayCham = DateTime.Parse((Request.Form["2"]));
                    (data as DSGVChamBai).diem = Double.Parse((Request.Form["3"]));
                    (data as DSGVChamBai).chuThich = Request.Form["4"];
                    dataO = new DSGVChamBai();
                    (dataO as DSGVChamBai).maBaiThi = Request.Form["50"];
                    (dataO as DSGVChamBai).maGV = Request.Form["51"];
                    (dataO as DSGVChamBai).ngayCham = DateTime.Parse((Request.Form["52"]));
                    (dataO as DSGVChamBai).diem = Double.Parse((Request.Form["53"]));
                    (dataO as DSGVChamBai).chuThich = Request.Form["54"];
                    ModDSGVChamBai(data as DSGVChamBai, dataO as DSGVChamBai);
                    data = db.Database.SqlQuery<DSGVChamBai>("select * from " + tableName).ToList();
                    break;
                case "DSGVHP":
                    data = new DSGVHP();
                    (data as DSGVHP).maGV = Request.Form["0"];
                    (data as DSGVHP).maHP = Request.Form["1"];
                    (data as DSGVHP).chuThich = Request.Form["2"];
                    dataO = new DSGVHP();
                    (dataO as DSGVHP).maGV = Request.Form["50"];
                    (dataO as DSGVHP).maHP = Request.Form["51"];
                    (dataO as DSGVHP).chuThich = Request.Form["52"];
                    ModDSGVHP(data as DSGVHP, dataO as DSGVHP);
                    data = db.Database.SqlQuery<DSGVHP>("select * from " + tableName).ToList();
                    break;
                case "DSHocBong":
                    data = new DSHocBong();
                    (data as DSHocBong).maHocBong = Request.Form["0"];
                    (data as DSHocBong).MaSV = Request.Form["1"];
                    (data as DSHocBong).chuThich = Request.Form["2"];
                    dataO = new DSHocBong();
                    (dataO as DSHocBong).maHocBong = Request.Form["50"];
                    (dataO as DSHocBong).MaSV = Request.Form["51"];
                    (dataO as DSHocBong).chuThich = Request.Form["52"];
                    ModDSHocBong(data as DSHocBong, dataO as DSHocBong);
                    data = db.Database.SqlQuery<DSHocBong>("select * from " + tableName).ToList();
                    break;
                case "DSHPThiKetThuc":
                    data = new DSHPThiKetThuc();
                    (data as DSHPThiKetThuc).maLopHP = Request.Form["0"];
                    (data as DSHPThiKetThuc).maThiKetThuc = Request.Form["1"];
                    (data as DSHPThiKetThuc).chuThich = Request.Form["2"];
                    dataO = new DSHPThiKetThuc();
                    (dataO as DSHPThiKetThuc).maLopHP = Request.Form["50"];
                    (dataO as DSHPThiKetThuc).maThiKetThuc = Request.Form["51"];
                    (dataO as DSHPThiKetThuc).chuThich = Request.Form["52"];
                    ModDSHPThiKetThuc(data as DSHPThiKetThuc, dataO as DSHPThiKetThuc);
                    data = db.Database.SqlQuery<DSHPThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "DSKQHT":
                    data = new DSKQHT();
                    (data as DSKQHT).maSV = Request.Form["0"];
                    (data as DSKQHT).tenXepLoai = Request.Form["1"];
                    (data as DSKQHT).tenKy = Request.Form["2"];
                    (data as DSKQHT).diem = Double.Parse(Request.Form["3"]);
                    (data as DSKQHT).sotinchino = Int32.Parse(Request.Form["4"]);
                    (data as DSKQHT).chuThich = Request.Form["5"];
                    dataO = new DSKQHT();
                    (dataO as DSKQHT).maSV = Request.Form["50"];
                    (dataO as DSKQHT).tenXepLoai = Request.Form["51"];
                    (dataO as DSKQHT).tenKy = Request.Form["52"];
                    (dataO as DSKQHT).diem = Double.Parse(Request.Form["53"]);
                    (dataO as DSKQHT).sotinchino = Int32.Parse(Request.Form["54"]);
                    (dataO as DSKQHT).chuThich = Request.Form["55"];
                    ModDSKQHT(data as DSKQHT, dataO as DSKQHT);
                    data = db.Database.SqlQuery<DSKQHT>("select * from " + tableName).ToList();
                    break;
                case "DSSVLopHP":
                    data = new DSSVLopHP();
                    (data as DSSVLopHP).malopHP = Request.Form["0"];
                    (data as DSSVLopHP).maSV = Request.Form["1"];
                    (data as DSSVLopHP).chuThich = Request.Form["2"];
                    (data as DSSVLopHP).diem1 = Double.Parse(Request.Form["3"]);
                    (data as DSSVLopHP).diem3 = Double.Parse(Request.Form["4"]);
                    (data as DSSVLopHP).diem6 = Double.Parse(Request.Form["5"]);
                    (data as DSSVLopHP).diemHe4 = Double.Parse(Request.Form["6"]);
                    dataO = new DSSVLopHP();
                    (dataO as DSSVLopHP).malopHP = Request.Form["50"];
                    (dataO as DSSVLopHP).maSV = Request.Form["51"];
                    (dataO as DSSVLopHP).chuThich = Request.Form["52"];
                    (dataO as DSSVLopHP).diem1 = Double.Parse(Request.Form["53"]);
                    (dataO as DSSVLopHP).diem3 = Double.Parse(Request.Form["54"]);
                    (dataO as DSSVLopHP).diem6 = Double.Parse(Request.Form["55"]);
                    (dataO as DSSVLopHP).diemHe4 = Double.Parse(Request.Form["56"]);
                    ModDSSVLopHP(data as DSSVLopHP, dataO as DSSVLopHP);
                    data = db.Database.SqlQuery<DSSVLopHP>("select * from " + tableName).ToList();
                    break;
                case "DSSVThiKetThuc":
                    data = new DSSVThiKetThuc();
                    (data as DSSVThiKetThuc).maSV = Request.Form["0"];
                    (data as DSSVThiKetThuc).maBaiThi = Request.Form["1"];
                    (data as DSSVThiKetThuc).maThiKetThuc = Request.Form["2"];
                    (data as DSSVThiKetThuc).chuThich = Request.Form["3"];
                    dataO = new DSSVThiKetThuc();
                    (dataO as DSSVThiKetThuc).maSV = Request.Form["50"];
                    (dataO as DSSVThiKetThuc).maBaiThi = Request.Form["51"];
                    (dataO as DSSVThiKetThuc).maThiKetThuc = Request.Form["52"];
                    (dataO as DSSVThiKetThuc).chuThich = Request.Form["53"];
                    ModDSSVThiKetThuc(data as DSSVThiKetThuc, dataO as DSSVThiKetThuc);
                    data = db.Database.SqlQuery<DSSVThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "GiangDuong":
                    data = new GiangDuong();
                    (data as GiangDuong).maGD = Request.Form["0"];
                    (data as GiangDuong).soPhong = Int32.Parse(Request.Form["1"]);
                    (data as GiangDuong).tang = Int32.Parse(Request.Form["2"]);
                    (data as GiangDuong).viTri = Request.Form["3"];
                    (data as GiangDuong).sucChua = Int32.Parse(Request.Form["4"]);
                    (data as GiangDuong).chuThich = Request.Form["5"];
                    dataO = new GiangDuong();
                    (dataO as GiangDuong).maGD = Request.Form["50"];
                    (dataO as GiangDuong).soPhong = Int32.Parse(Request.Form["51"]);
                    (dataO as GiangDuong).tang = Int32.Parse(Request.Form["52"]);
                    (dataO as GiangDuong).viTri = Request.Form["53"];
                    (dataO as GiangDuong).sucChua = Int32.Parse(Request.Form["54"]);
                    (dataO as GiangDuong).chuThich = Request.Form["55"];
                    ModGiangDuong(data as GiangDuong, dataO as GiangDuong);
                    data = db.Database.SqlQuery<GiangDuong>("select * from " + tableName).ToList();
                    break;
                case "GiangVien":
                    data = new GiangVien();
                    (data as GiangVien).maBM = Request.Form["0"];
                    (data as GiangVien).tenGV = Request.Form["1"];
                    (data as GiangVien).hoGV = Request.Form["2"];
                    (data as GiangVien).ngaySinh = DateTime.Parse(Request.Form["3"]);
                    (data as GiangVien).gioiTinh = Request.Form["4"];
                    (data as GiangVien).email = Request.Form["5"];
                    (data as GiangVien).sdt = Request.Form["6"];
                    dataO = new GiangVien();
                    (dataO as GiangVien).maBM = Request.Form["50"];
                    (dataO as GiangVien).tenGV = Request.Form["51"];
                    (dataO as GiangVien).hoGV = Request.Form["52"];
                    (dataO as GiangVien).ngaySinh = DateTime.Parse(Request.Form["53"]);
                    (dataO as GiangVien).gioiTinh = Request.Form["54"];
                    (dataO as GiangVien).email = Request.Form["55"];
                    (dataO as GiangVien).sdt = Request.Form["56"];
                    ModGiangVien(data as GiangVien, dataO as GiangVien);
                    data = db.Database.SqlQuery<GiangVien>("select * from " + tableName).ToList();
                    break;
                case "HinhThucHoc":
                    data = new HinhThucHoc();
                    (data as HinhThucHoc).tenHinhThuc = Request.Form["0"];
                    (data as HinhThucHoc).chuThich = Request.Form["1"];
                    dataO = new HinhThucHoc();
                    (dataO as HinhThucHoc).tenHinhThuc = Request.Form["50"];
                    (dataO as HinhThucHoc).chuThich = Request.Form["51"];
                    ModHinhThucHoc(data as HinhThucHoc, dataO as HinhThucHoc);
                    data = db.Database.SqlQuery<HinhThucHoc>("select * from " + tableName).ToList();
                    break;
                case "HocBong":
                    data = new HocBong();
                    (data as HocBong).maHocBong = Request.Form["0"];
                    (data as HocBong).tenHocBong = Request.Form["1"];
                    (data as HocBong).chuThich = Request.Form["2"];
                    dataO = new HocBong();
                    (dataO as HocBong).maHocBong = Request.Form["50"];
                    (dataO as HocBong).tenHocBong = Request.Form["51"];
                    (dataO as HocBong).chuThich = Request.Form["52"];
                    ModHocBong(data as HocBong, dataO as HocBong);
                    data = db.Database.SqlQuery<HocBong>("select * from " + tableName).ToList();
                    break;
                case "HocPhan":
                    data = new HocPhan();
                    (data as HocPhan).maHP = Request.Form["0"];
                    (data as HocPhan).soTC = Int32.Parse(Request.Form["1"]);
                    (data as HocPhan).maPKT = Request.Form["2"];
                    (data as HocPhan).tenHP = Request.Form["3"];
                    (data as HocPhan).chuThich = Request.Form["4"];
                    dataO = new HocPhan();
                    (dataO as HocPhan).maHP = Request.Form["50"];
                    (dataO as HocPhan).soTC = Int32.Parse(Request.Form["51"]);
                    (dataO as HocPhan).maPKT = Request.Form["52"];
                    (dataO as HocPhan).tenHP = Request.Form["53"];
                    (dataO as HocPhan).chuThich = Request.Form["54"];
                    ModHocPhan(data as HocPhan, dataO as HocPhan);
                    data = db.Database.SqlQuery<HocPhan>("select * from " + tableName).ToList();
                    break;
                case "HocViGV":
                    data = new HocViGV();
                    (data as HocViGV).maGV = Request.Form["0"];
                    (data as HocViGV).tenHV = Request.Form["1"];
                    dataO = new HocViGV();
                    (dataO as HocViGV).maGV = Request.Form["50"];
                    (dataO as HocViGV).tenHV = Request.Form["51"];
                    ModHocViGV(data as HocViGV, dataO as HocViGV);
                    data = db.Database.SqlQuery<HocViGV>("select * from " + tableName).ToList();
                    break;
                case "Khoa":
                    data = new Khoa();
                    (data as Khoa).maTruongKhoa = Request.Form["0"];
                    (data as Khoa).maKhoa = Request.Form["1"];
                    (data as Khoa).tenKhoa = Request.Form["2"];
                    (data as Khoa).chuThich = Request.Form["3"];
                    dataO = new Khoa();
                    (dataO as Khoa).maTruongKhoa = Request.Form["50"];
                    (dataO as Khoa).maKhoa = Request.Form["51"];
                    (dataO as Khoa).tenKhoa = Request.Form["52"];
                    (dataO as Khoa).chuThich = Request.Form["53"];
                    ModKhoa(data as Khoa, dataO as Khoa);
                    data = db.Database.SqlQuery<Khoa>("select * from " + tableName).ToList();
                    break;
                case "KhoaSv":
                    data = new KhoaSv();
                    (data as KhoaSv).maKhoaSv = Request.Form["0"];
                    (data as KhoaSv).tenKhoaSv = Request.Form["1"];
                    (data as KhoaSv).namThanhLap = DateTime.Parse(Request.Form["2"]);
                    (data as KhoaSv).chuThich = Request.Form["3"];
                    (data as KhoaSv).soLuongSV = Int32.Parse(Request.Form["4"]);
                    dataO = new KhoaSv();
                    (dataO as KhoaSv).maKhoaSv = Request.Form["50"];
                    (dataO as KhoaSv).tenKhoaSv = Request.Form["51"];
                    (dataO as KhoaSv).namThanhLap = DateTime.Parse(Request.Form["52"]);
                    (dataO as KhoaSv).chuThich = Request.Form["53"];
                    (dataO as KhoaSv).soLuongSV = Int32.Parse(Request.Form["54"]);
                    ModKhoaSv(data as KhoaSv, dataO as KhoaSv);
                    data = db.Database.SqlQuery<KhoaSv>("select * from " + tableName).ToList();
                    break;
                case "KyHoc":
                    data = new KyHoc();
                    (data as KyHoc).tenKy = Request.Form["0"];
                    (data as KyHoc).chuThich = Request.Form["1"];
                    dataO = new KyHoc();
                    (dataO as KyHoc).tenKy = Request.Form["50"];
                    (dataO as KyHoc).chuThich = Request.Form["51"];
                    ModKyHoc(data as KyHoc, dataO as KyHoc);
                    data = db.Database.SqlQuery<KyHoc>("select * from " + tableName).ToList();
                    break;
                case "LichHP":
                    data = new LichHP();
                    (data as LichHP).maHP = Request.Form["0"];
                    (data as LichHP).tietHoc = Request.Form["1"];
                    (data as LichHP).soLuong = Int32.Parse(Request.Form["2"]);
                    (data as LichHP).thu = Request.Form["3"];
                    (data as LichHP).chuThich = Request.Form["4"];
                    dataO = new LichHP();
                    (dataO as LichHP).maHP = Request.Form["50"];
                    (dataO as LichHP).tietHoc = Request.Form["51"];
                    (dataO as LichHP).soLuong = Int32.Parse(Request.Form["52"]);
                    (dataO as LichHP).thu = Request.Form["53"];
                    (dataO as LichHP).chuThich = Request.Form["54"];
                    ModLichHP(data as LichHP, dataO as LichHP);
                    data = db.Database.SqlQuery<LichHP>("select * from " + tableName).ToList();
                    break;
                case "LopCNSv":
                    data = new LopCNSv();
                    (data as LopCNSv).maLopCN = Request.Form["0"];
                    (data as LopCNSv).tenLopCN = Request.Form["1"];
                    (data as LopCNSv).maCNDT = Request.Form["2"];
                    (data as LopCNSv).chuThich = Request.Form["3"];
                    (data as LopCNSv).soLuongSV = Int32.Parse(Request.Form["4"]);
                    dataO = new LopCNSv();
                    (dataO as LopCNSv).maLopCN = Request.Form["50"];
                    (dataO as LopCNSv).tenLopCN = Request.Form["51"];
                    (dataO as LopCNSv).maCNDT = Request.Form["52"];
                    (dataO as LopCNSv).chuThich = Request.Form["53"];
                    (dataO as LopCNSv).soLuongSV = Int32.Parse(Request.Form["54"]);
                    ModLopCNSv(data as LopCNSv, dataO as LopCNSv);
                    data = db.Database.SqlQuery<LopCNSv>("select * from " + tableName).ToList();
                    break;
                case "LopHP":
                    data = new LopHP();
                    (data as LopHP).maHP = Request.Form["0"];
                    (data as LopHP).maLopHP = Request.Form["1"];
                    (data as LopHP).maxStore = Int32.Parse(Request.Form["2"]);
                    (data as LopHP).chuThich = Request.Form["3"];
                    (data as LopHP).curStore = Int32.Parse(Request.Form["4"]);
                    dataO = new LopHP();
                    (dataO as LopHP).maHP = Request.Form["50"];
                    (dataO as LopHP).maLopHP = Request.Form["51"];
                    (dataO as LopHP).maxStore = Int32.Parse(Request.Form["52"]);
                    (dataO as LopHP).chuThich = Request.Form["53"];
                    (dataO as LopHP).curStore = Int32.Parse(Request.Form["54"]);
                    ModLopHP(data as LopHP, dataO as LopHP);
                    data = db.Database.SqlQuery<LopHP>("select * from " + tableName).ToList();
                    break;
                case "NganhDT":
                    data = new NganhDT();
                    (data as NganhDT).maNganhDT = Request.Form["0"];
                    (data as NganhDT).tenNganhDT = Request.Form["1"];
                    (data as NganhDT).maBoMon = Request.Form["2"];
                    (data as NganhDT).chuThich = Request.Form["3"];
                    dataO = new NganhDT();
                    (dataO as NganhDT).maNganhDT = Request.Form["50"];
                    (dataO as NganhDT).tenNganhDT = Request.Form["51"];
                    (dataO as NganhDT).maBoMon = Request.Form["52"];
                    (dataO as NganhDT).chuThich = Request.Form["53"];
                    ModNganhDT(data as NganhDT, dataO as NganhDT);
                    data = db.Database.SqlQuery<NganhDT>("select * from " + tableName).ToList();
                    break;
                case "PhanKT":
                    data = new PhanKT();
                    (data as PhanKT).maPKT = Request.Form["0"];
                    (data as PhanKT).tenPKT = Request.Form["1"];
                    (data as PhanKT).chuThich = Request.Form["2"];
                    dataO = new PhanKT();
                    (dataO as PhanKT).maPKT = Request.Form["50"];
                    (dataO as PhanKT).tenPKT = Request.Form["51"];
                    (dataO as PhanKT).chuThich = Request.Form["52"];
                    ModPhanKT(data as PhanKT, dataO as PhanKT);
                    data = db.Database.SqlQuery<PhanKT>("select * from " + tableName).ToList();
                    break;
                case "SinhVien":
                    data = new SinhVien();
                    (data as SinhVien).maSV = Request.Form["0"];
                    (data as SinhVien).maLopCN = Request.Form["1"];
                    (data as SinhVien).tenSV = Request.Form["2"];
                    (data as SinhVien).hoSV = Request.Form["3"];
                    (data as SinhVien).ngaySinh = DateTime.Parse(Request.Form["4"]);
                    (data as SinhVien).gioiTinh = Request.Form["5"];
                    (data as SinhVien).email = Request.Form["6"];
                    (data as SinhVien).sdt = Request.Form["7"];
                    (data as SinhVien).sdtPhuHUynh = Request.Form["8"];
                    (data as SinhVien).maKhoaSv = Request.Form["9"];
                    (data as SinhVien).chuThich = Request.Form["10"];
                    (data as SinhVien).isLearn = Boolean.Parse(Request.Form["11"]);
                    dataO = new SinhVien();
                    (dataO as SinhVien).maSV = Request.Form["50"];
                    (dataO as SinhVien).maLopCN = Request.Form["51"];
                    (dataO as SinhVien).tenSV = Request.Form["52"];
                    (dataO as SinhVien).hoSV = Request.Form["53"];
                    (dataO as SinhVien).ngaySinh = DateTime.Parse(Request.Form["54"]);
                    (dataO as SinhVien).gioiTinh = Request.Form["55"];
                    (dataO as SinhVien).email = Request.Form["56"];
                    (dataO as SinhVien).sdt = Request.Form["57"];
                    (dataO as SinhVien).sdtPhuHUynh = Request.Form["58"];
                    (dataO as SinhVien).maKhoaSv = Request.Form["59"];
                    (dataO as SinhVien).chuThich = Request.Form["60"];
                    (dataO as SinhVien).isLearn = Boolean.Parse(Request.Form["61"]);
                    ModSinhVien(data as SinhVien, dataO as SinhVien);
                    data = db.Database.SqlQuery<SinhVien>("select * from " + tableName).ToList();
                    break;
                case "ThiKetThuc":
                    data = new ThiKetThuc();
                    (data as ThiKetThuc).maThiKetThuc = Request.Form["0"];
                    (data as ThiKetThuc).ngayThi = DateTime.Parse(Request.Form["1"]);
                    (data as ThiKetThuc).thoiGianBatDau = TimeSpan.Parse(Request.Form["2"]);
                    (data as ThiKetThuc).chuThich = Request.Form["3"];
                    dataO = new ThiKetThuc();
                    (dataO as ThiKetThuc).maThiKetThuc = Request.Form["50"];
                    (dataO as ThiKetThuc).ngayThi = DateTime.Parse(Request.Form["51"]);
                    (dataO as ThiKetThuc).thoiGianBatDau = TimeSpan.Parse(Request.Form["52"]);
                    (dataO as ThiKetThuc).chuThich = Request.Form["53"];
                    ModThiKetThuc(data as ThiKetThuc, dataO as ThiKetThuc);
                    data = db.Database.SqlQuery<ThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "TietHoc":
                    data = new TietHoc();
                    (data as TietHoc).tietHoc1 = Request.Form["0"];
                    (data as TietHoc).timeStart = TimeSpan.Parse(Request.Form["1"]);
                    (data as TietHoc).chuThich = Request.Form["2"];
                    dataO = new TietHoc();
                    (dataO as TietHoc).tietHoc1 = Request.Form["50"];
                    (dataO as TietHoc).timeStart = TimeSpan.Parse(Request.Form["51"]);
                    (dataO as TietHoc).chuThich = Request.Form["52"];
                    ModTietHoc(data as TietHoc, dataO as TietHoc);
                    data = db.Database.SqlQuery<TietHoc>("select * from " + tableName).ToList();
                    break;
                case "TrinhDoNN":
                    data = new TrinhDoNN();
                    (data as TrinhDoNN).tenTrinhDoNN = Request.Form["0"];
                    (data as TrinhDoNN).maSV = Request.Form["1"];
                    (data as TrinhDoNN).chuThich = Request.Form["2"];
                    dataO = new TrinhDoNN();
                    (dataO as TrinhDoNN).tenTrinhDoNN = Request.Form["50"];
                    (dataO as TrinhDoNN).maSV = Request.Form["51"];
                    (dataO as TrinhDoNN).chuThich = Request.Form["52"];
                    ModTrinhDoNN(data as TrinhDoNN, dataO as TrinhDoNN);
                    data = db.Database.SqlQuery<TrinhDoNN>("select * from " + tableName).ToList();
                    break;
                case "XepLoai":
                    data = new XepLoai();
                    (data as XepLoai).tenXepLoai = Request.Form["0"];
                    (data as XepLoai).diem = Double.Parse(Request.Form["1"]);
                    (data as XepLoai).chuThich = Request.Form["2"];
                    dataO = new XepLoai();
                    (dataO as XepLoai).tenXepLoai = Request.Form["50"];
                    (dataO as XepLoai).diem = Double.Parse(Request.Form["51"]);
                    (dataO as XepLoai).chuThich = Request.Form["52"];
                    ModXepLoai(data as XepLoai, dataO as XepLoai);
                    data = db.Database.SqlQuery<XepLoai>("select * from " + tableName).ToList();
                    break;
                default:
                    data = null;
                    break;
            }
            ViewBag.colName = db.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            ViewBag.tableName = tableName;
            return PartialView("_TableDB", data);
        }

        

        [HttpPost]
        public ActionResult AddRow()
        {
            String tableName = Request.Form["TableName"];
            ViewBag.nameTable = tableName;
            object data = null;
            switch (tableName)
            {
                case "BaiThi":
                    data = new BaiThi();
                    (data as BaiThi).maBaiThi = Request.Form["0"];
                    //(data as BaiThi).ngayTao = Convert.ToDateTime(Request.Form["1"].ToString());
                    (data as BaiThi).ngayTao = null;
                    (data as BaiThi).chuThich = Request.Form["2"];
                    AddBaiThi(data as BaiThi);
                    data = db.Database.SqlQuery<BaiThi>("select * from " + tableName).ToList();
                    break;
                case "BoMon":
                    data = new BoMon();
                    (data as BoMon).maTruongBM = Request.Form["0"];
                    (data as BoMon).maBM = Request.Form["1"];
                    (data as BoMon).maKhoa = Request.Form["2"];
                    (data as BoMon).tenBM = Request.Form["3"];
                    (data as BoMon).chuThich = Request.Form["4"];
                    (data as BoMon).soLuongGV = Int32.Parse(Request.Form["5"]);
                    AddBoMon(data as BoMon);
                    data = db.Database.SqlQuery<BoMon>("select * from " + tableName).ToList();
                    break;
                case "CanhCao":
                    data = new CanhCao();
                    (data as CanhCao).maCanhCao = Request.Form["0"];
                    (data as CanhCao).tenCanhCao = Request.Form["1"];
                    (data as CanhCao).chuThich = Request.Form["2"];
                    AddCanhCao(data as CanhCao);
                    data = db.Database.SqlQuery<CanhCao>("select * from " + tableName).ToList();
                    break;
                case "CHiTietHP":
                    data = new CHiTietHP();
                    (data as CHiTietHP).maHP = Request.Form["0"];
                    (data as CHiTietHP).TenHinhThuc = Request.Form["1"];
                    (data as CHiTietHP).sotiet = Int32.Parse((Request.Form["2"]));
                    (data as CHiTietHP).chuThich = Request.Form["3"];
                    AddCHiTietHP(data as CHiTietHP);
                    data = db.Database.SqlQuery<CHiTietHP>("select * from " + tableName).ToList();
                    break;
                case "ChuyenNganhDT":
                    data = new ChuyenNganhDT();
                    (data as ChuyenNganhDT).maNganhDT = Request.Form["0"];
                    (data as ChuyenNganhDT).maChuyenNganh = Request.Form["1"];
                    (data as ChuyenNganhDT).maBoMon = Request.Form["2"];
                    (data as ChuyenNganhDT).tenChuyenNganh = Request.Form["3"];
                    (data as ChuyenNganhDT).chuThich = Request.Form["4"];
                    AddChuyenNganhDT(data as ChuyenNganhDT);
                    data = db.Database.SqlQuery<ChuyenNganhDT>("select * from " + tableName).ToList();
                    break;
                case "DiemDanh":
                    data = new DiemDanh();
                    (data as DiemDanh).maDD = Request.Form["0"];
                    (data as DiemDanh).maLopHP = Request.Form["1"];
                    (data as DiemDanh).soBuoiDiemDanh = Int32.Parse(Request.Form["2"]);
                    AddDiemDanh(data as DiemDanh);
                    data = db.Database.SqlQuery<DiemDanh>("select * from " + tableName).ToList();
                    break;
                case "DScanhcao":
                    data = new DScanhcao();
                    (data as DScanhcao).maCanhCao = Request.Form["0"];
                    (data as DScanhcao).maSV = Request.Form["1"];
                    (data as DScanhcao).chuThich = Request.Form["2"];
                    AddDScanhcao(data as DScanhcao);
                    data = db.Database.SqlQuery<DScanhcao>("select * from " + tableName).ToList();
                    break;
                case "DSCoVanHT":
                    data = new DSCoVanHT();
                    (data as DSCoVanHT).maLopCN = Request.Form["0"];
                    (data as DSCoVanHT).maCV = Request.Form["1"];
                    (data as DSCoVanHT).chuThich = Request.Form["2"];
                    AddDSCoVanHT(data as DSCoVanHT);
                    data = db.Database.SqlQuery<DSCoVanHT>("select * from " + tableName).ToList();
                    break;
                case "DSDeThi":
                    data = new DSDeThi();
                    (data as DSDeThi).maBaiThi = Request.Form["0"];
                    (data as DSDeThi).maDeThi = Request.Form["1"];
                    (data as DSDeThi).soTo = Int32.Parse((Request.Form["2"]));
                    (data as DSDeThi).chuThich = Request.Form["3"];
                    AddDSDeThi(data as DSDeThi);
                    data = db.Database.SqlQuery<DSDeThi>("select * from " + tableName).ToList();
                    break;
                case "DSDiemDanhSV":
                    data = new DSDiemDanhSV();
                    (data as DSDiemDanhSV).maDD = Request.Form["0"];
                    (data as DSDiemDanhSV).maSV = Request.Form["1"];
                    (data as DSDiemDanhSV).soBuoi = Int32.Parse(Request.Form["2"]);
                    AddDSDiemDanhSV(data as DSDiemDanhSV);
                    data = db.Database.SqlQuery<DSDiemDanhSV>("select * from " + tableName).ToList();
                    break;
                case "DSGiamThi":
                    data = new DSGiamThi();
                    (data as DSGiamThi).maThiKetThuc = Request.Form["0"];
                    (data as DSGiamThi).maGV = Request.Form["1"];
                    (data as DSGiamThi).ngayPC = DateTime.Parse((Request.Form["2"]));
                    (data as DSGiamThi).chuThich = Request.Form["3"];
                    AddDSGiamThi(data as DSGiamThi);
                    data = db.Database.SqlQuery<DSGiamThi>("select * from " + tableName).ToList();
                    break;
                case "DSGiangDuong":
                    data = new DSGiangDuong();
                    (data as DSGiangDuong).maGD = Request.Form["0"];
                    (data as DSGiangDuong).maLopHP = Request.Form["1"];
                    (data as DSGiangDuong).thu = Int32.Parse(Request.Form["2"]);
                    (data as DSGiangDuong).chuThich = Request.Form["3"];
                    AddDSGiangDuong(data as DSGiangDuong);
                    data = db.Database.SqlQuery<DSGiangDuong>("select * from " + tableName).ToList();
                    break;
                case "DSGVChamBai":
                    data = new DSGVChamBai();
                    (data as DSGVChamBai).maBaiThi = Request.Form["0"];
                    (data as DSGVChamBai).maGV = Request.Form["1"];
                    (data as DSGVChamBai).ngayCham = DateTime.Parse((Request.Form["2"]));
                    (data as DSGVChamBai).diem = Double.Parse((Request.Form["3"]));
                    (data as DSGVChamBai).chuThich = Request.Form["4"];
                    AddDSGVChamBai(data as DSGVChamBai);
                    data = db.Database.SqlQuery<DSGVChamBai>("select * from " + tableName).ToList();
                    break;
                case "DSGVHP":
                    data = new DSGVHP();
                    (data as DSGVHP).maGV = Request.Form["0"];
                    (data as DSGVHP).maHP = Request.Form["1"];
                    (data as DSGVHP).chuThich = Request.Form["2"];
                    AddDSGVHP(data as DSGVHP);
                    data = db.Database.SqlQuery<DSGVHP>("select * from " + tableName).ToList();
                    break;
                case "DSHocBong":
                    data = new DSHocBong();
                    (data as DSHocBong).maHocBong = Request.Form["0"];
                    (data as DSHocBong).MaSV = Request.Form["1"];
                    (data as DSHocBong).chuThich = Request.Form["2"];
                    AddDSHocBong(data as DSHocBong);
                    data = db.Database.SqlQuery<DSHocBong>("select * from " + tableName).ToList();
                    break;
                case "DSHPThiKetThuc":
                    data = new DSHPThiKetThuc();
                    (data as DSHPThiKetThuc).maLopHP = Request.Form["0"];
                    (data as DSHPThiKetThuc).maThiKetThuc = Request.Form["1"];
                    (data as DSHPThiKetThuc).chuThich = Request.Form["2"];
                    AddDSHPThiKetThuc(data as DSHPThiKetThuc);
                    data = db.Database.SqlQuery<DSHPThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "DSKQHT":
                    data = new DSKQHT();
                    (data as DSKQHT).maSV = Request.Form["0"];
                    (data as DSKQHT).tenXepLoai = Request.Form["1"];
                    (data as DSKQHT).tenKy = Request.Form["2"];
                    (data as DSKQHT).diem = Double.Parse(Request.Form["3"]);
                    (data as DSKQHT).sotinchino = Int32.Parse(Request.Form["4"]);
                    (data as DSKQHT).chuThich = Request.Form["5"];
                    AddDSKQHT(data as DSKQHT);
                    data = db.Database.SqlQuery<DSKQHT>("select * from " + tableName).ToList();
                    break;
                case "DSSVLopHP":
                    data = new DSSVLopHP();
                    (data as DSSVLopHP).malopHP = Request.Form["0"];
                    (data as DSSVLopHP).maSV = Request.Form["1"];
                    (data as DSSVLopHP).chuThich =Request.Form["2"];
                    (data as DSSVLopHP).diem1 = Double.Parse(Request.Form["3"]);
                    (data as DSSVLopHP).diem3 = Double.Parse(Request.Form["4"]);
                    (data as DSSVLopHP).diem6 = Double.Parse(Request.Form["5"]);
                    (data as DSSVLopHP).diemHe4 = Double.Parse(Request.Form["6"]);
                    AddDSSVLopHP(data as DSSVLopHP);
                    data = db.Database.SqlQuery<DSSVLopHP>("select * from " + tableName).ToList();
                    break;
                case "DSSVThiKetThuc":
                    data = new DSSVThiKetThuc();
                    (data as DSSVThiKetThuc).maSV = Request.Form["0"];
                    (data as DSSVThiKetThuc).maBaiThi = Request.Form["1"];
                    (data as DSSVThiKetThuc).maThiKetThuc = Request.Form["2"];
                    (data as DSSVThiKetThuc).chuThich = Request.Form["3"];
                    AddDSSVThiKetThuc(data as DSSVThiKetThuc);
                    data = db.Database.SqlQuery<DSSVThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "GiangDuong":
                    data = new GiangDuong();
                    (data as GiangDuong).maGD = Request.Form["0"];
                    (data as GiangDuong).soPhong = Int32.Parse(Request.Form["1"]);
                    (data as GiangDuong).tang = Int32.Parse(Request.Form["2"]);
                    (data as GiangDuong).viTri = Request.Form["3"];
                    (data as GiangDuong).sucChua = Int32.Parse(Request.Form["4"]);
                    (data as GiangDuong).chuThich = Request.Form["5"];
                    AddGiangDuong(data as GiangDuong);
                    data = db.Database.SqlQuery<GiangDuong>("select * from " + tableName).ToList();
                    break;
                case "GiangVien":
                    data = new GiangVien();
                    (data as GiangVien).maBM = Request.Form["0"];
                    (data as GiangVien).tenGV = Request.Form["1"];
                    (data as GiangVien).hoGV = Request.Form["2"];
                    (data as GiangVien).ngaySinh = DateTime.Parse(Request.Form["3"]);
                    (data as GiangVien).gioiTinh = Request.Form["4"];
                    (data as GiangVien).email = Request.Form["5"];
                    (data as GiangVien).sdt = Request.Form["6"];
                    AddGiangVien(data as GiangVien);
                    data = db.Database.SqlQuery<GiangVien>("select * from " + tableName).ToList();
                    break;
                case "HinhThucHoc":
                    data = new HinhThucHoc();
                    (data as HinhThucHoc).tenHinhThuc = Request.Form["0"];
                    (data as HinhThucHoc).chuThich = Request.Form["1"];
                    AddHinhThucHoc(data as HinhThucHoc);
                    data = db.Database.SqlQuery<HinhThucHoc>("select * from " + tableName).ToList();
                    break;
                case "HocBong":
                    data = new HocBong();
                    (data as HocBong).maHocBong = Request.Form["0"];
                    (data as HocBong).tenHocBong = Request.Form["1"];
                    (data as HocBong).chuThich = Request.Form["2"];
                    AddHocBong(data as HocBong);
                    data = db.Database.SqlQuery<HocBong>("select * from " + tableName).ToList();
                    break;
                case "HocPhan":
                    data = new HocPhan();
                    (data as HocPhan).maHP = Request.Form["0"];
                    (data as HocPhan).soTC = Int32.Parse(Request.Form["1"]);
                    (data as HocPhan).maPKT = Request.Form["2"];
                    (data as HocPhan).tenHP = Request.Form["3"];
                    (data as HocPhan).chuThich = Request.Form["4"];
                    AddHocPhan(data as HocPhan);
                    data = db.Database.SqlQuery<HocPhan>("select * from " + tableName).ToList();
                    break;
                case "HocViGV":
                    data = new HocViGV();
                    (data as HocViGV).maGV = Request.Form["0"];
                    (data as HocViGV).tenHV = Request.Form["1"];
                    AddHocViGV(data as HocViGV);
                    data = db.Database.SqlQuery<HocViGV>("select * from " + tableName).ToList();
                    break;
                case "Khoa":
                    data = new Khoa();
                    (data as Khoa).maTruongKhoa = Request.Form["0"];
                    (data as Khoa).maKhoa = Request.Form["1"];
                    (data as Khoa).tenKhoa = Request.Form["2"];
                    (data as Khoa).chuThich = Request.Form["3"];
                    AddKhoa(data as Khoa);
                    data = db.Database.SqlQuery<Khoa>("select * from " + tableName).ToList();
                    break;
                case "KhoaSv":
                    data = new KhoaSv();
                    (data as KhoaSv).maKhoaSv = Request.Form["0"];
                    (data as KhoaSv).tenKhoaSv = Request.Form["1"];
                    (data as KhoaSv).namThanhLap = DateTime.Parse(Request.Form["2"]);
                    (data as KhoaSv).chuThich = Request.Form["3"];
                    (data as KhoaSv).soLuongSV = Int32.Parse(Request.Form["4"]);
                    AddKhoaSv(data as KhoaSv);
                    data = db.Database.SqlQuery<KhoaSv>("select * from " + tableName).ToList();
                    break;
                case "KyHoc":
                    data = new KyHoc();
                    (data as KyHoc).tenKy = Request.Form["0"];
                    (data as KyHoc).chuThich = Request.Form["1"];
                    AddKyHoc(data as KyHoc);
                    data = db.Database.SqlQuery<KyHoc>("select * from " + tableName).ToList();
                    break;
                case "LichHP":
                    data = new LichHP();
                    (data as LichHP).maHP = Request.Form["0"];
                    (data as LichHP).tietHoc = Request.Form["1"];
                    (data as LichHP).soLuong = Int32.Parse(Request.Form["2"]);
                    (data as LichHP).thu = Request.Form["3"];
                    (data as LichHP).chuThich = Request.Form["4"];
                    AddLichHP(data as LichHP);
                    data = db.Database.SqlQuery<LichHP>("select * from " + tableName).ToList();
                    break;
                case "LopCNSv":
                    data = new LopCNSv();
                    (data as LopCNSv).maLopCN = Request.Form["0"];
                    (data as LopCNSv).tenLopCN = Request.Form["1"];
                    (data as LopCNSv).maCNDT = Request.Form["2"];
                    (data as LopCNSv).chuThich = Request.Form["3"];
                    (data as LopCNSv).soLuongSV = Int32.Parse(Request.Form["4"]);
                    AddLopCNSv(data as LopCNSv);
                    data = db.Database.SqlQuery<LopCNSv>("select * from " + tableName).ToList();
                    break;
                case "LopHP":
                    data = new LopHP();
                    (data as LopHP).maHP = Request.Form["0"];
                    (data as LopHP).maLopHP = Request.Form["1"];
                    (data as LopHP).maxStore = Int32.Parse(Request.Form["2"]);
                    (data as LopHP).chuThich = Request.Form["3"];
                    (data as LopHP).curStore = Int32.Parse(Request.Form["4"]);
                    AddLopHP(data as LopHP);
                    data = db.Database.SqlQuery<LopHP>("select * from " + tableName).ToList();
                    break;
                case "NganhDT":
                    data = new NganhDT();
                    (data as NganhDT).maNganhDT = Request.Form["0"];
                    (data as NganhDT).tenNganhDT = Request.Form["1"];
                    (data as NganhDT).maBoMon = Request.Form["2"];
                    (data as NganhDT).chuThich = Request.Form["3"];
                    AddNganhDT(data as NganhDT);
                    data = db.Database.SqlQuery<NganhDT>("select * from " + tableName).ToList();
                    break;
                case "PhanKT":
                    data = new PhanKT();
                    (data as PhanKT).maPKT = Request.Form["0"];
                    (data as PhanKT).tenPKT = Request.Form["1"];
                    (data as PhanKT).chuThich = Request.Form["2"];
                    AddPhanKT(data as PhanKT);
                    data = db.Database.SqlQuery<PhanKT>("select * from " + tableName).ToList();
                    break;
                case "SinhVien":
                    data = new SinhVien();
                    (data as SinhVien).maSV = Request.Form["0"];
                    (data as SinhVien).maLopCN = Request.Form["1"];
                    (data as SinhVien).tenSV = Request.Form["2"];
                    (data as SinhVien).hoSV = Request.Form["3"];
                    (data as SinhVien).ngaySinh = DateTime.Parse(Request.Form["4"]);
                    (data as SinhVien).gioiTinh = Request.Form["5"];
                    (data as SinhVien).email = Request.Form["6"];
                    (data as SinhVien).sdt = Request.Form["7"];
                    (data as SinhVien).sdtPhuHUynh = Request.Form["8"];
                    (data as SinhVien).maKhoaSv = Request.Form["9"];
                    (data as SinhVien).chuThich = Request.Form["10"];
                    (data as SinhVien).isLearn = Boolean.Parse(Request.Form["11"]);
                    AddSinhVien(data as SinhVien);
                    data = db.Database.SqlQuery<SinhVien>("select * from " + tableName).ToList();
                    break;
                case "ThiKetThuc":
                    data = new ThiKetThuc();
                    (data as ThiKetThuc).maThiKetThuc = Request.Form["0"];
                    (data as ThiKetThuc).ngayThi = DateTime.Parse(Request.Form["1"]);
                    (data as ThiKetThuc).thoiGianBatDau = TimeSpan.Parse(Request.Form["2"]);
                    (data as ThiKetThuc).chuThich = Request.Form["3"];
                    AddThiKetThuc(data as ThiKetThuc);
                    data = db.Database.SqlQuery<ThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "TietHoc":
                    data = new TietHoc();
                    (data as TietHoc).tietHoc1 = Request.Form["0"];
                    (data as TietHoc).timeStart = TimeSpan.Parse(Request.Form["1"]);
                    (data as TietHoc).chuThich = Request.Form["2"];
                    AddTietHoc(data as TietHoc);
                    data = db.Database.SqlQuery<TietHoc>("select * from " + tableName).ToList();
                    break;
                case "TrinhDoNN":
                    data = new TrinhDoNN();
                    (data as TrinhDoNN).tenTrinhDoNN = Request.Form["0"];
                    (data as TrinhDoNN).maSV = Request.Form["1"];
                    (data as TrinhDoNN).chuThich = Request.Form["2"];
                    AddTrinhDoNN(data as TrinhDoNN);
                    data = db.Database.SqlQuery<TrinhDoNN>("select * from " + tableName).ToList();
                    break;
                case "XepLoai":
                    data = new XepLoai();
                    (data as XepLoai).tenXepLoai = Request.Form["0"];
                    (data as XepLoai).diem = Double.Parse(Request.Form["1"]);
                    (data as XepLoai).chuThich = Request.Form["2"];
                    AddXepLoai(data as XepLoai);
                    data = db.Database.SqlQuery<XepLoai>("select * from " + tableName).ToList();
                    break;
                default:
                    data = null;
                    break;
            }
            //var ads = db.DestinationReviews.ToList();
            //var tableNameList = db.TenCacBangs.ToList();
            //ViewBag.tableNameList = tableNameList;
            //return View("Table", ads);
            ViewBag.colName = db.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            ViewBag.tableName = tableName;
            return PartialView("_TableDB", data);
        }


        [HttpPost]
        public ActionResult DeleteRow()
        {
            String tableName = Request.Form["TableName"];
            ViewBag.nameTable = tableName;
            object data = null;
            switch (tableName)
            {
                case "BaiThi":
                    data = new BaiThi();
                    (data as BaiThi).maBaiThi = Request.Form["0"];
                    (data as BaiThi).ngayTao = DateTime.Parse(Request.Form["1"]);
                    (data as BaiThi).chuThich = Request.Form["2"];
                    DelAllBaiThi(data as BaiThi);
                    data = db.Database.SqlQuery<BaiThi>("select * from " + tableName).ToList();
                    break;
                case "BoMon":
                    data = new BoMon();
                    (data as BoMon).maTruongBM = Request.Form["0"];
                    (data as BoMon).maBM = Request.Form["1"];
                    (data as BoMon).maKhoa = Request.Form["2"];
                    (data as BoMon).tenBM = Request.Form["3"];
                    (data as BoMon).chuThich = Request.Form["4"];
                    (data as BoMon).soLuongGV = Int32.Parse(Request.Form["5"]);
                    DelAllBoMon(data as BoMon);
                    data = db.Database.SqlQuery<BoMon>("select * from " + tableName).ToList();
                    break;
                case "CanhCao":
                    data = new CanhCao();
                    (data as CanhCao).maCanhCao = Request.Form["0"];
                    (data as CanhCao).tenCanhCao = Request.Form["1"];
                    (data as CanhCao).chuThich = Request.Form["2"];
                    DelAllCanhCao(data as CanhCao);
                    data = db.Database.SqlQuery<CanhCao>("select * from " + tableName).ToList();
                    break;
                case "CHiTietHP":
                    data = new CHiTietHP();
                    (data as CHiTietHP).maHP = Request.Form["0"];
                    (data as CHiTietHP).TenHinhThuc = Request.Form["1"];
                    (data as CHiTietHP).sotiet = Int32.Parse((Request.Form["2"]));
                    (data as CHiTietHP).chuThich = Request.Form["3"];
                    DelAllChiTietHP(data as CHiTietHP);
                    data = db.Database.SqlQuery<CHiTietHP>("select * from " + tableName).ToList();
                    break;
                case "ChuyenNganhDT":
                    data = new ChuyenNganhDT();
                    (data as ChuyenNganhDT).maNganhDT = Request.Form["0"];
                    (data as ChuyenNganhDT).maChuyenNganh = Request.Form["1"];
                    (data as ChuyenNganhDT).maBoMon = Request.Form["2"];
                    (data as ChuyenNganhDT).tenChuyenNganh = Request.Form["3"];
                    (data as ChuyenNganhDT).chuThich = Request.Form["4"];
                    DelAllChuyenNganhDT(data as ChuyenNganhDT);
                    data = db.Database.SqlQuery<ChuyenNganhDT>("select * from " + tableName).ToList();
                    break;
                case "DiemDanh":
                    data = new DiemDanh();
                    (data as DiemDanh).maDD = Request.Form["0"];
                    (data as DiemDanh).maLopHP = Request.Form["1"];
                    (data as DiemDanh).soBuoiDiemDanh = Int32.Parse(Request.Form["2"]);
                    DelAllDiemDanh(data as DiemDanh);
                    data = db.Database.SqlQuery<DiemDanh>("select * from " + tableName).ToList();
                    break;
                case "DScanhcao":
                    data = new DScanhcao();
                    (data as DScanhcao).maCanhCao = Request.Form["0"];
                    (data as DScanhcao).maSV = Request.Form["1"];
                    (data as DScanhcao).chuThich = Request.Form["2"];
                    DelAllDSCanhCao(data as DScanhcao);
                    data = db.Database.SqlQuery<DScanhcao>("select * from " + tableName).ToList();
                    break;
                case "DSCoVanHT":
                    data = new DSCoVanHT();
                    (data as DSCoVanHT).maLopCN = Request.Form["0"];
                    (data as DSCoVanHT).maCV = Request.Form["1"];
                    (data as DSCoVanHT).chuThich = Request.Form["2"];
                    DelAllDSCoVanHT(data as DSCoVanHT);
                    data = db.Database.SqlQuery<DSCoVanHT>("select * from " + tableName).ToList();
                    break;
                case "DSDeThi":
                    data = new DSDeThi();
                    (data as DSDeThi).maBaiThi = Request.Form["0"];
                    (data as DSDeThi).maDeThi = Request.Form["1"];
                    (data as DSDeThi).soTo = Int32.Parse((Request.Form["2"]));
                    (data as DSDeThi).chuThich = Request.Form["3"];
                    DelAllDSDeTHi(data as DSDeThi);
                    data = db.Database.SqlQuery<DSDeThi>("select * from " + tableName).ToList();
                    break;
                case "DSDiemDanhSV":
                    data = new DSDiemDanhSV();
                    (data as DSDiemDanhSV).maDD = Request.Form["0"];
                    (data as DSDiemDanhSV).maSV = Request.Form["1"];
                    (data as DSDiemDanhSV).soBuoi = Int32.Parse(Request.Form["2"]);
                    DelAllDSDiemDanhSV(data as DSDiemDanhSV);
                    data = db.Database.SqlQuery<DSDiemDanhSV>("select * from " + tableName).ToList();
                    break;
                case "DSGiamThi":
                    data = new DSGiamThi();
                    (data as DSGiamThi).maThiKetThuc = Request.Form["0"];
                    (data as DSGiamThi).maGV = Request.Form["1"];
                    (data as DSGiamThi).ngayPC = DateTime.Parse((Request.Form["2"]));
                    (data as DSGiamThi).chuThich = Request.Form["3"];
                    DelAllDSGiamThi(data as DSGiamThi);
                    data = db.Database.SqlQuery<DSGiamThi>("select * from " + tableName).ToList();
                    break;
                case "DSGiangDuong":
                    data = new DSGiangDuong();
                    (data as DSGiangDuong).maGD = Request.Form["0"];
                    (data as DSGiangDuong).maLopHP = Request.Form["1"];
                    (data as DSGiangDuong).thu = Int32.Parse(Request.Form["2"]);
                    (data as DSGiangDuong).chuThich = Request.Form["3"];
                    DelAllDSGiangDuong(data as DSGiangDuong);
                    data = db.Database.SqlQuery<DSGiangDuong>("select * from " + tableName).ToList();
                    break;
                case "DSGVChamBai":
                    data = new DSGVChamBai();
                    (data as DSGVChamBai).maBaiThi = Request.Form["0"];
                    (data as DSGVChamBai).maGV = Request.Form["1"];
                    (data as DSGVChamBai).ngayCham = DateTime.Parse((Request.Form["2"]));
                    (data as DSGVChamBai).diem = Double.Parse((Request.Form["3"]));
                    (data as DSGVChamBai).chuThich = Request.Form["4"];
                    DelAllDSGVChamBai(data as DSGVChamBai);
                    data = db.Database.SqlQuery<DSGVChamBai>("select * from " + tableName).ToList();
                    break;
                case "DSGVHP":
                    data = new DSGVHP();
                    (data as DSGVHP).maGV = Request.Form["0"];
                    (data as DSGVHP).maHP = Request.Form["1"];
                    (data as DSGVHP).chuThich = Request.Form["2"];
                    DelAllDSGVHP(data as DSGVHP);
                    data = db.Database.SqlQuery<DSGVHP>("select * from " + tableName).ToList();
                    break;
                case "DSHocBong":
                    data = new DSHocBong();
                    (data as DSHocBong).maHocBong = Request.Form["0"];
                    (data as DSHocBong).MaSV = Request.Form["1"];
                    (data as DSHocBong).chuThich = Request.Form["2"];
                    DelAllDSHocBong(data as DSHocBong);
                    data = db.Database.SqlQuery<DSHocBong>("select * from " + tableName).ToList();
                    break;
                case "DSHPThiKetThuc":
                    data = new DSHPThiKetThuc();
                    (data as DSHPThiKetThuc).maLopHP = Request.Form["0"];
                    (data as DSHPThiKetThuc).maThiKetThuc = Request.Form["1"];
                    (data as DSHPThiKetThuc).chuThich = Request.Form["2"];
                    DelAllDSHPThiKetThuc(data as DSHPThiKetThuc);
                    data = db.Database.SqlQuery<DSHPThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "DSKQHT":
                    data = new DSKQHT();
                    (data as DSKQHT).maSV = Request.Form["0"];
                    (data as DSKQHT).tenXepLoai = Request.Form["1"];
                    (data as DSKQHT).tenKy = Request.Form["2"];
                    (data as DSKQHT).diem = Double.Parse(Request.Form["3"]);
                    (data as DSKQHT).sotinchino = Int32.Parse(Request.Form["4"]);
                    (data as DSKQHT).chuThich = Request.Form["5"];
                    DelAllDSKQHT(data as DSKQHT);
                    data = db.Database.SqlQuery<DSKQHT>("select * from " + tableName).ToList();
                    break;
                case "DSSVLopHP":
                    data = new DSSVLopHP();
                    (data as DSSVLopHP).malopHP = Request.Form["0"];
                    (data as DSSVLopHP).maSV = Request.Form["1"];
                    (data as DSSVLopHP).chuThich = Request.Form["2"];
                    (data as DSSVLopHP).diem1 = Double.Parse(Request.Form["3"]);
                    (data as DSSVLopHP).diem3 = Double.Parse(Request.Form["4"]);
                    (data as DSSVLopHP).diem6 = Double.Parse(Request.Form["5"]);
                    (data as DSSVLopHP).diemHe4 = Double.Parse(Request.Form["6"]);
                    DelAllDSSVLopHP(data as DSSVLopHP);
                    data = db.Database.SqlQuery<DSSVLopHP>("select * from " + tableName).ToList();
                    break;
                case "DSSVThiKetThuc":
                    data = new DSSVThiKetThuc();
                    (data as DSSVThiKetThuc).maSV = Request.Form["0"];
                    (data as DSSVThiKetThuc).maBaiThi = Request.Form["1"];
                    (data as DSSVThiKetThuc).maThiKetThuc = Request.Form["2"];
                    (data as DSSVThiKetThuc).chuThich = Request.Form["3"];
                    DelAllDSSVThiKetThuc(data as DSSVThiKetThuc);
                    data = db.Database.SqlQuery<DSSVThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "GiangDuong":
                    data = new GiangDuong();
                    (data as GiangDuong).maGD = Request.Form["0"];
                    (data as GiangDuong).soPhong = Int32.Parse(Request.Form["1"]);
                    (data as GiangDuong).tang = Int32.Parse(Request.Form["2"]);
                    (data as GiangDuong).viTri = Request.Form["3"];
                    (data as GiangDuong).sucChua = Int32.Parse(Request.Form["4"]);
                    (data as GiangDuong).chuThich = Request.Form["5"];
                    DelAllGiangDuong(data as GiangDuong);
                    data = db.Database.SqlQuery<GiangDuong>("select * from " + tableName).ToList();
                    break;
                case "GiangVien":
                    data = new GiangVien();
                    (data as GiangVien).maBM = Request.Form["0"];
                    (data as GiangVien).tenGV = Request.Form["1"];
                    (data as GiangVien).hoGV = Request.Form["2"];
                    (data as GiangVien).ngaySinh = DateTime.Parse(Request.Form["3"]);
                    (data as GiangVien).gioiTinh = Request.Form["4"];
                    (data as GiangVien).email = Request.Form["5"];
                    (data as GiangVien).sdt = Request.Form["6"];
                    DelAllGiangVien(data as GiangVien);
                    data = db.Database.SqlQuery<GiangVien>("select * from " + tableName).ToList();
                    break;
                case "HinhThucHoc":
                    data = new HinhThucHoc();
                    (data as HinhThucHoc).tenHinhThuc = Request.Form["0"];
                    (data as HinhThucHoc).chuThich = Request.Form["1"];
                    DelAllHinhThucHoc(data as HinhThucHoc);
                    data = db.Database.SqlQuery<HinhThucHoc>("select * from " + tableName).ToList();
                    break;
                case "HocBong":
                    data = new HocBong();
                    (data as HocBong).maHocBong = Request.Form["0"];
                    (data as HocBong).tenHocBong = Request.Form["1"];
                    (data as HocBong).chuThich = Request.Form["2"];
                    DelAllHocBong(data as HocBong);
                    data = db.Database.SqlQuery<HocBong>("select * from " + tableName).ToList();
                    break;
                case "HocPhan":
                    data = new HocPhan();
                    (data as HocPhan).maHP = Request.Form["0"];
                    (data as HocPhan).soTC = Int32.Parse(Request.Form["1"]);
                    (data as HocPhan).maPKT = Request.Form["2"];
                    (data as HocPhan).tenHP = Request.Form["3"];
                    (data as HocPhan).chuThich = Request.Form["4"];
                    DelAllHocPhan(data as HocPhan);
                    data = db.Database.SqlQuery<HocPhan>("select * from " + tableName).ToList();
                    break;
                case "HocViGV":
                    data = new HocViGV();
                    (data as HocViGV).maGV = Request.Form["0"];
                    (data as HocViGV).tenHV = Request.Form["1"];
                    DelAllhocViGV(data as HocViGV);
                    data = db.Database.SqlQuery<HocViGV>("select * from " + tableName).ToList();
                    break;
                case "Khoa":
                    data = new Khoa();
                    (data as Khoa).maTruongKhoa = Request.Form["0"];
                    (data as Khoa).maKhoa = Request.Form["1"];
                    (data as Khoa).tenKhoa = Request.Form["2"];
                    (data as Khoa).chuThich = Request.Form["3"];
                    DelAllKhoa(data as Khoa);
                    data = db.Database.SqlQuery<Khoa>("select * from " + tableName).ToList();
                    break;
                case "KhoaSv":
                    data = new KhoaSv();
                    (data as KhoaSv).maKhoaSv = Request.Form["0"];
                    (data as KhoaSv).tenKhoaSv = Request.Form["1"];
                    (data as KhoaSv).namThanhLap = DateTime.Parse(Request.Form["2"]);
                    (data as KhoaSv).chuThich = Request.Form["3"];
                    (data as KhoaSv).soLuongSV = Int32.Parse(Request.Form["4"]);
                    DelAllKhoaSV(data as KhoaSv);
                    data = db.Database.SqlQuery<KhoaSv>("select * from " + tableName).ToList();
                    break;
                case "KyHoc":
                    data = new KyHoc();
                    (data as KyHoc).tenKy = Request.Form["0"];
                    (data as KyHoc).chuThich = Request.Form["1"];
                    DelAllKyHoc(data as KyHoc);
                    data = db.Database.SqlQuery<KyHoc>("select * from " + tableName).ToList();
                    break;
                case "LichHP":
                    data = new LichHP();
                    (data as LichHP).maHP = Request.Form["0"];
                    (data as LichHP).tietHoc = Request.Form["1"];
                    (data as LichHP).soLuong = Int32.Parse(Request.Form["2"]);
                    (data as LichHP).thu = Request.Form["3"];
                    (data as LichHP).chuThich = Request.Form["4"];
                    DelAllLichHP(data as LichHP);
                    data = db.Database.SqlQuery<LichHP>("select * from " + tableName).ToList();
                    break;
                case "LopCNSv":
                    data = new LopCNSv();
                    (data as LopCNSv).maLopCN = Request.Form["0"];
                    (data as LopCNSv).tenLopCN = Request.Form["1"];
                    (data as LopCNSv).maCNDT = Request.Form["2"];
                    (data as LopCNSv).chuThich = Request.Form["3"];
                    (data as LopCNSv).soLuongSV = Int32.Parse(Request.Form["4"]);
                    DelAllLopCNSV(data as LopCNSv);
                    data = db.Database.SqlQuery<LopCNSv>("select * from " + tableName).ToList();
                    break;
                case "LopHP":
                    data = new LopHP();
                    (data as LopHP).maHP = Request.Form["0"];
                    (data as LopHP).maLopHP = Request.Form["1"];
                    (data as LopHP).maxStore = Int32.Parse(Request.Form["2"]);
                    (data as LopHP).chuThich = Request.Form["3"];
                    (data as LopHP).curStore = Int32.Parse(Request.Form["4"]);
                    DelAllLopHP(data as LopHP);
                    data = db.Database.SqlQuery<LopHP>("select * from " + tableName).ToList();
                    break;
                case "NganhDT":
                    data = new NganhDT();
                    (data as NganhDT).maNganhDT = Request.Form["0"];
                    (data as NganhDT).tenNganhDT = Request.Form["1"];
                    (data as NganhDT).maBoMon = Request.Form["2"];
                    (data as NganhDT).chuThich = Request.Form["3"];
                    DelAllNganhDT(data as NganhDT);
                    data = db.Database.SqlQuery<NganhDT>("select * from " + tableName).ToList();
                    break;
                case "PhanKT":
                    data = new PhanKT();
                    (data as PhanKT).maPKT = Request.Form["0"];
                    (data as PhanKT).tenPKT = Request.Form["1"];
                    (data as PhanKT).chuThich = Request.Form["2"];
                    DelAllPhanKT(data as PhanKT);
                    data = db.Database.SqlQuery<PhanKT>("select * from " + tableName).ToList();
                    break;
                case "SinhVien":
                    data = new SinhVien();
                    (data as SinhVien).maSV = Request.Form["0"];
                    (data as SinhVien).maLopCN = Request.Form["1"];
                    (data as SinhVien).tenSV = Request.Form["2"];
                    (data as SinhVien).hoSV = Request.Form["3"];
                    (data as SinhVien).ngaySinh = DateTime.Parse(Request.Form["4"]);
                    (data as SinhVien).gioiTinh = Request.Form["5"];
                    (data as SinhVien).email = Request.Form["6"];
                    (data as SinhVien).sdt = Request.Form["7"];
                    (data as SinhVien).sdtPhuHUynh = Request.Form["8"];
                    (data as SinhVien).maKhoaSv = Request.Form["9"];
                    (data as SinhVien).chuThich = Request.Form["10"];
                    (data as SinhVien).isLearn = Boolean.Parse(Request.Form["11"]);
                    DelAllSinhVien(data as SinhVien);
                    data = db.Database.SqlQuery<SinhVien>("select * from " + tableName).ToList();
                    break;
                case "ThiKetThuc":
                    data = new ThiKetThuc();
                    (data as ThiKetThuc).maThiKetThuc = Request.Form["0"];
                    (data as ThiKetThuc).ngayThi = DateTime.Parse(Request.Form["1"]);
                    (data as ThiKetThuc).thoiGianBatDau = TimeSpan.Parse(Request.Form["2"]);
                    (data as ThiKetThuc).chuThich = Request.Form["3"];
                    DelAllThiKetThuc(data as ThiKetThuc);
                    data = db.Database.SqlQuery<ThiKetThuc>("select * from " + tableName).ToList();
                    break;
                case "TietHoc":
                    data = new TietHoc();
                    (data as TietHoc).tietHoc1 = Request.Form["0"];
                    (data as TietHoc).timeStart = TimeSpan.Parse(Request.Form["1"]);
                    (data as TietHoc).chuThich = Request.Form["2"];
                    DelAllTietHoc(data as TietHoc);
                    data = db.Database.SqlQuery<TietHoc>("select * from " + tableName).ToList();
                    break;
                case "TrinhDoNN":
                    data = new TrinhDoNN();
                    (data as TrinhDoNN).tenTrinhDoNN = Request.Form["0"];
                    (data as TrinhDoNN).maSV = Request.Form["1"];
                    (data as TrinhDoNN).chuThich = Request.Form["2"];
                    DelAllTrinhDoNN(data as TrinhDoNN);
                    data = db.Database.SqlQuery<TrinhDoNN>("select * from " + tableName).ToList();
                    break;
                case "XepLoai":
                    data = new XepLoai();
                    (data as XepLoai).tenXepLoai = Request.Form["0"];
                    (data as XepLoai).diem = Double.Parse(Request.Form["1"]);
                    (data as XepLoai).chuThich = Request.Form["2"];
                    DelAllXepLoai(data as XepLoai);
                    data = db.Database.SqlQuery<XepLoai>("select * from " + tableName).ToList();
                    break;
                default:
                    data = null;
                    break;
            }
            ViewBag.colName = db.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            ViewBag.tableName = tableName;
            return PartialView("_TableDB", data);
        }
        private void ModXepLoai(XepLoai xepLoai1, XepLoai xepLoai2)
        {

        }
        private void ModTrinhDoNN(TrinhDoNN trinhDoNN1, TrinhDoNN trinhDoNN2)
        {
            throw new NotImplementedException();
        }

        private void ModTietHoc(TietHoc tietHoc1, TietHoc tietHoc2)
        {
            throw new NotImplementedException();
        }

        private void ModThiKetThuc(ThiKetThuc thiKetThuc1, ThiKetThuc thiKetThuc2)
        {
            throw new NotImplementedException();
        }

        private void ModSinhVien(SinhVien sinhVien1, SinhVien sinhVien2)
        {
            throw new NotImplementedException();
        }

        private void ModPhanKT(PhanKT phanKT1, PhanKT phanKT2)
        {
            throw new NotImplementedException();
        }

        private void ModNganhDT(NganhDT nganhDT1, NganhDT nganhDT2)
        {
            throw new NotImplementedException();
        }

        private void ModLopHP(LopHP lopHP1, LopHP lopHP2)
        {
            throw new NotImplementedException();
        }

        private void ModLopCNSv(LopCNSv lopCNSv1, LopCNSv lopCNSv2)
        {
            throw new NotImplementedException();
        }

        private void ModLichHP(LichHP lichHP1, LichHP lichHP2)
        {
            throw new NotImplementedException();
        }

        private void ModKyHoc(KyHoc kyHoc1, KyHoc kyHoc2)
        {
            throw new NotImplementedException();
        }

        private void ModKhoaSv(KhoaSv khoaSv1, KhoaSv khoaSv2)
        {
            throw new NotImplementedException();
        }

        private void ModKhoa(Khoa khoa1, Khoa khoa2)
        {
            throw new NotImplementedException();
        }

        private void ModHocViGV(HocViGV hocViGV1, HocViGV hocViGV2)
        {
            throw new NotImplementedException();
        }

        private void ModHocPhan(HocPhan hocPhan1, HocPhan hocPhan2)
        {
            throw new NotImplementedException();
        }

        private void ModHocBong(HocBong hocBong1, HocBong hocBong2)
        {
            throw new NotImplementedException();
        }

        private void ModHinhThucHoc(HinhThucHoc hinhThucHoc1, HinhThucHoc hinhThucHoc2)
        {
            throw new NotImplementedException();
        }

        private void ModGiangVien(GiangVien giangVien1, GiangVien giangVien2)
        {
            throw new NotImplementedException();
        }

        private void ModGiangDuong(GiangDuong giangDuong1, GiangDuong giangDuong2)
        {
            throw new NotImplementedException();
        }

        private void ModDSSVThiKetThuc(DSSVThiKetThuc dSSVThiKetThuc1, DSSVThiKetThuc dSSVThiKetThuc2)
        {
            throw new NotImplementedException();
        }

        private void ModDSSVLopHP(DSSVLopHP dSSVLopHP1, DSSVLopHP dSSVLopHP2)
        {
            throw new NotImplementedException();
        }

        private void ModDSKQHT(DSKQHT dSKQHT1, DSKQHT dSKQHT2)
        {
            throw new NotImplementedException();
        }

        private void ModDSHPThiKetThuc(DSHPThiKetThuc dSHPThiKetThuc1, DSHPThiKetThuc dSHPThiKetThuc2)
        {
            throw new NotImplementedException();
        }

        private void ModDSHocBong(DSHocBong dSHocBong1, DSHocBong dSHocBong2)
        {
            throw new NotImplementedException();
        }

        private void ModDSGVHP(DSGVHP dSGVHP1, DSGVHP dSGVHP2)
        {
            throw new NotImplementedException();
        }

        private void ModDSGVChamBai(DSGVChamBai dSGVChamBai1, DSGVChamBai dSGVChamBai2)
        {
            throw new NotImplementedException();
        }

        private void ModDSGiangDuong(DSGiangDuong dSGiangDuong1, DSGiangDuong dSGiangDuong2)
        {
            throw new NotImplementedException();
        }

        private void ModDSGiamThi(DSGiamThi dSGiamThi1, DSGiamThi dSGiamThi2)
        {
            throw new NotImplementedException();
        }

        private void ModDSDiemDanhSV(DSDiemDanhSV dSDiemDanhSV1, DSDiemDanhSV dSDiemDanhSV2)
        {
            throw new NotImplementedException();
        }

        private void ModDSDeThi(DSDeThi dSDeThi1, DSDeThi dSDeThi2)
        {
            throw new NotImplementedException();
        }

        private void ModDSCoVanHT(DSCoVanHT dSCoVanHT1, DSCoVanHT dSCoVanHT2)
        {
            throw new NotImplementedException();
        }

        private void ModDScanhcao(DScanhcao dScanhcao1, DScanhcao dScanhcao2)
        {
            throw new NotImplementedException();
        }

        private void ModDiemDanh(DiemDanh diemDanh1, DiemDanh diemDanh2)
        {
            throw new NotImplementedException();
        }

        private void ModChuyenNganhDT(ChuyenNganhDT chuyenNganhDT1, ChuyenNganhDT chuyenNganhDT2)
        {
            throw new NotImplementedException();
        }

        private void ModCHiTietHP(CHiTietHP cHiTietHP1, CHiTietHP cHiTietHP2)
        {
            throw new NotImplementedException();
        }

        private void ModCanhCao(CanhCao canhCao1, CanhCao canhCao2)
        {
            throw new NotImplementedException();
        }

        private void ModBoMon(BoMon boMon1, BoMon boMon2)
        {
            throw new NotImplementedException();
        }

        private void ModBaiThi(BaiThi baiThi1, BaiThi baiThi2)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        ///  chức năng xóa
        /// </summary>
        /// <param name="data"></param>
        private void DelAllBaiThi(BaiThi data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllBaiThi '" + data.maBaiThi + "'");
        }
        private void DelAllBoMon(BoMon data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllBoMon '" + data.maBM + "'");
        }
        private void DelAllCanhCao(CanhCao data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllCanhCao '" + data.maCanhCao + "'");
        }
        private void DelAllChiTietHP(CHiTietHP data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllChiTietHP '" + data.maHP + "','" + data.TenHinhThuc + "' ");
        }
        private void DelAllDiemDanh(DiemDanh diemDanh)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDiemDanh '" + diemDanh.maDD +"'");
        }
        private void DelAllChuyenNganhDT(ChuyenNganhDT data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllChuyenNganhDT '" + data.maNganhDT + "','" + data.maChuyenNganh + "' ");
        }
        private void DelAllDSCanhCao(DScanhcao data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSCanhCao '" + data.maCanhCao + "','" + data.maSV + "' ");
        }
        private void DelAllDSCoVanHT(DSCoVanHT data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSCoVanHT '" + data.maLopCN + "','" + data.maCV + "' ");
        }
        private void DelAllDSDiemDanhSV(DSDiemDanhSV dSDiemDanhSV)
        {
            db.Database.ExecuteSqlCommand("execute AddDiemDanh '" + dSDiemDanhSV.maDD + "', '" + dSDiemDanhSV.maSV  + "'");
        }
        private void DelAllDSDeTHi(DSDeThi data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSDeTHi '" + data.maBaiThi + "','" + data.maDeThi + "' ");
        }
        private void DelAllDSGiamThi(DSGiamThi data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSGiamThi '" + data.maThiKetThuc + "','" + data.maGV + "' ");
        }
        private void DelAllDSGiangDuong(DSGiangDuong data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSGiangDuong '" + data.maGD + "','" + data.maLopHP + "' ");
        }
        private void DelAllDSGVChamBai(DSGVChamBai data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSGVChamBai '" + data.maBaiThi + "','" + data.maGV + "' ");
        }
        private void DelAllDSGVHP(DSGVHP data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSGVHP '" + data.maGV + "','" + data.maHP + "' ");
        }
        private void DelAllDSHocBong(DSHocBong data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSHocBong '" + data.maHocBong + "','" + data.MaSV + "' ");
        }
        private void DelAllDSHPThiKetThuc(DSHPThiKetThuc data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSHPThiKetThuc '" + data.maLopHP + "','" + data.maThiKetThuc + "' ");
        }
        private void DelAllDSKQHT(DSKQHT data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSKQHT '" + data.tenKy + "','" + data.maSV + "' ");
        }
        private void DelAllDSSVLopHP(DSSVLopHP data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSSVLopHP '" + data.malopHP + "','" + data.maSV + "' ");
        }
        private void DelAllDSSVThiKetThuc(DSSVThiKetThuc data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllDSSVThiKetThuc '" + data.maBaiThi + "','" + data.maSV + "','" + data.maThiKetThuc + "' ");
        }
        private void DelAllGiangDuong(GiangDuong data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllGiangDuong '" + data.maGD + "' ");
        }
        private void DelAllGiangVien(GiangVien data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllGiangVien '" + data.maGV + "' ");
        }
        private void DelAllHinhThucHoc(HinhThucHoc data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllHinhThucHoc '" + data.tenHinhThuc + "' ");
        }
        private void DelAllHocBong(HocBong data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllHocBong '" + data.maHocBong + "' ");
        }
        private void DelAllHocPhan(HocPhan data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllHocPhan '" + data.maHP + "' ");
        }
        private void DelAllhocViGV(HocViGV data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllhocViGV '" + data.maGV + "','" + data.tenHV + "' ");
        }
        private void DelAllKhoa(Khoa data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllKhoa '" + data.maKhoa + "' ");
        }
        private void DelAllKhoaSV(KhoaSv data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllKhoaSV '" + data.maKhoaSv + "' ");
        }
        private void DelAllKyHoc(KyHoc data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllKyHoc '" + data.tenKy + "' ");
        }
        private void DelAllLichHP(LichHP data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllLichHP '" + data.maHP + "','" + data.tietHoc + "','" + data.thu + "' ");
        }
        private void DelAllLopCNSV(LopCNSv data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllLopCNSV '" + data.maLopCN + "' ");

        }
        private void DelAllLopHP(LopHP data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllLopHP '" + data.maLopHP + "' ");
        }
        private void DelAllNganhDT(NganhDT data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllNganhDT '" + data.maNganhDT + "' ");
        }
        private void DelAllPhanKT(PhanKT data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllPhanKT '" + data.maPKT + "' ");
        }
        private void DelAllSinhVien(SinhVien data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllSinhVien '" + data.maSV + "' ");
        }
        private void DelAllThiKetThuc(ThiKetThuc data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllSinhVien '" + data.maThiKetThuc + "' ");
        }
        private void DelAllTietHoc(TietHoc data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllTietHoc '" + data.tietHoc1 + "' ");
        }
        private void DelAllTrinhDoNN(TrinhDoNN data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllTrinhDoNN '" + data.maSV + "', '" + data.tenTrinhDoNN + "' ");
        }
        private void DelAllXepLoai(XepLoai data)
        {
            db.Database.ExecuteSqlCommand("execute DelAllXepLoai '" + data.tenXepLoai + "' ");
        }
        /// <summary>
        /// chức năng add
        /// </summary>
        /// <param name="xepLoai"></param>
        private void AddXepLoai(XepLoai xepLoai)
        {
            db.Database.ExecuteSqlCommand("execute AddXepLoai '" + xepLoai.tenXepLoai + "', '" + xepLoai.diem + "', '" + xepLoai.chuThich + "'");
        }

        private void AddTrinhDoNN(TrinhDoNN trinhDoNN)
        {
            db.Database.ExecuteSqlCommand("execute AddTrinhDoNN '" + trinhDoNN.maSV + "', '" + trinhDoNN.tenTrinhDoNN + "', '" + trinhDoNN.chuThich + "'");
        }

        private void AddTietHoc(TietHoc tietHoc)
        {
            db.Database.ExecuteSqlCommand("execute AddTietHoc '" + tietHoc.tietHoc1 + "', '" + tietHoc.timeStart +  "', '" + tietHoc.chuThich + "'");
        }

        private void AddThiKetThuc(ThiKetThuc thiKetThuc)
        {
            db.Database.ExecuteSqlCommand("execute AddThiKetThuc '" + thiKetThuc.maThiKetThuc + "', '" + thiKetThuc.ngayThi + "', '" + thiKetThuc.thoiGianBatDau + "', '" + thiKetThuc.chuThich + "'");
        }

        private void AddSinhVien(SinhVien sinhVien)
        {
            db.Database.ExecuteSqlCommand("execute AddSinhVien '"+sinhVien.maSV+"'" +
                ",'"+sinhVien.maLopCN+"','"+sinhVien.tenSV+"','"+sinhVien.hoSV+"','"+sinhVien.ngaySinh+"','"+sinhVien.gioiTinh+"'" +
                ",'"+sinhVien.sdt+"','"+sinhVien.sdtPhuHUynh+"','"+sinhVien.maKhoaSv+"','"+sinhVien.email+"','"+sinhVien.chuThich+"'");   
        }

        private void AddPhanKT(PhanKT phanKT)
        {
            db.Database.ExecuteSqlCommand("execute AddPhanKT '" + phanKT.maPKT + "', '" + phanKT.tenPKT + "', '" + phanKT.chuThich + "'");
        }

        private void AddNganhDT(NganhDT nganhDT)
        {
            db.Database.ExecuteSqlCommand("execute AddNganhDT '" + nganhDT.maNganhDT + "', '" + nganhDT.tenNganhDT + "', '" + nganhDT.maBoMon + "', '" + nganhDT.chuThich + "'");
        }

        private void AddLopHP(LopHP lopHP)
        {
            db.Database.ExecuteSqlCommand("execute AddLopHP '" + lopHP.maLopHP + "', '" + lopHP.maxStore + "', '" + lopHP.maHP + "', '" + lopHP.chuThich + "'");
        }

        private void AddLopCNSv(LopCNSv lopCNSv)
        {
            db.Database.ExecuteSqlCommand("execute AddLopCNSV '" + lopCNSv.maLopCN + "', '" + lopCNSv.tenLopCN + "', '" + lopCNSv.maCNDT + "', '" + lopCNSv.chuThich + "'");
        }

        private void AddLichHP(LichHP lichHP)
        {
            db.Database.ExecuteSqlCommand("execute AddLichHP '" + lichHP.maHP + "', '" + lichHP.tietHoc + "', '" + lichHP.soLuong + "', '" + lichHP.thu + "', '" + lichHP.chuThich + "'");
        }

        private void AddKyHoc(KyHoc kyHoc)
        {
            db.Database.ExecuteSqlCommand("execute AddKyHoc '" + kyHoc.tenKy + "', '" + kyHoc.chuThich + "'");
        }

        private void AddKhoaSv(KhoaSv khoaSv)
        {
            db.Database.ExecuteSqlCommand("execute AddKhoaSV '" + khoaSv.maKhoaSv + "', '" + khoaSv.tenKhoaSv + "', '" + khoaSv.namThanhLap + "', '" + khoaSv.chuThich + "'");
        }

        private void AddKhoa(Khoa khoa)
        {
            db.Database.ExecuteSqlCommand("execute AddKhoa '" + khoa.maTruongKhoa + "', '" + khoa.maKhoa + "', '" + khoa.tenKhoa + "', '" + khoa.chuThich + "'");
        }

        private void AddHocViGV(HocViGV hocViGV)
        {
            db.Database.ExecuteSqlCommand("execute AddhocViGV '" + hocViGV.maGV + "', '" + hocViGV.tenHV + "', '" + hocViGV.chuThich + "'");
        }

        private void AddHocPhan(HocPhan hocPhan)
        {
            db.Database.ExecuteSqlCommand("execute AddHocPhan '" + hocPhan.maHP + "', '" + hocPhan.maPKT + "', '" + hocPhan.tenHP+ "', '" + hocPhan.chuThich + "'");
        }

        private void AddHocBong(HocBong hocBong)
        {
            db.Database.ExecuteSqlCommand("execute AddHocBong '" + hocBong.maHocBong + "', '" + hocBong.tenHocBong + "', '"+hocBong.chuThich+"'");
        }

        private void AddHinhThucHoc(HinhThucHoc hinhThucHoc)
        {
            db.Database.ExecuteSqlCommand("execute AddHinhThucHoc '"+ hinhThucHoc.tenHinhThuc+ "', '"+ hinhThucHoc.chuThich + "'");
        }

        private void AddGiangVien(GiangVien giangVien)
        {
            db.Database.ExecuteSqlCommand("execute AddGiangVien '" + giangVien.maGV + "', '" + giangVien.maBM + "', '" + giangVien.tenGV + "', '" + giangVien.hoGV + "', '" + giangVien.ngaySinh + "', '" + giangVien.gioiTinh +"', '" + giangVien.sdt+"', '" + giangVien.email + "'");
        }

        private void AddGiangDuong(GiangDuong giangDuong)
        {
            db.Database.ExecuteSqlCommand("execute AddGiangDuong '" + giangDuong.maGD + "', '" + giangDuong.soPhong + "', '" + giangDuong.tang + "', '" + giangDuong.viTri + "', '" + giangDuong.sucChua + "', '" + giangDuong.chuThich + "'");
        }

        private void AddDSSVThiKetThuc(DSSVThiKetThuc dSSVThiKetThuc)
        {
            db.Database.ExecuteSqlCommand("execute AddDSSVThiKetThuc '" + dSSVThiKetThuc.maBaiThi + "', '" + dSSVThiKetThuc.maSV + "', '" + dSSVThiKetThuc.maThiKetThuc + "', '" + dSSVThiKetThuc.chuThich + "'");
        }

        private void AddDSSVLopHP(DSSVLopHP dSSVLopHP)
        {
            db.Database.ExecuteSqlCommand("execute AddDSSVLopHP '" + dSSVLopHP.malopHP + "', '" + dSSVLopHP.maSV + "', '" + dSSVLopHP.chuThich + "'");
        }

        private void AddDSKQHT(DSKQHT dSKQHT)
        {
            db.Database.ExecuteSqlCommand("execute AddDSKQHT '" + dSKQHT.tenKy + "', '" + dSKQHT.maSV + "', '" + dSKQHT.tenXepLoai + "', '" + dSKQHT.diem + "', '" + dSKQHT.sotinchino + "', '" + dSKQHT.chuThich + "'");
        }

        private void AddDSHPThiKetThuc(DSHPThiKetThuc dSHPThiKetThuc)
        {
            db.Database.ExecuteSqlCommand("execute AddDSHPThiKetThuc '" + dSHPThiKetThuc.maLopHP + "', '" + dSHPThiKetThuc.maThiKetThuc + "', '" + dSHPThiKetThuc.chuThich + "'");
        }

        private void AddDSHocBong(DSHocBong dSHocBong)
        {
            db.Database.ExecuteSqlCommand("execute AddDSHocBong '" + dSHocBong.maHocBong + "', '" + dSHocBong.MaSV + "', '" + dSHocBong.chuThich + "'");
        }

        private void AddDSGVHP(DSGVHP dSGVHP)
        {
            db.Database.ExecuteSqlCommand("execute AddDSGVHP '" + dSGVHP.maGV + "', '" + dSGVHP.maHP + "', '" + dSGVHP.chuThich + "'");
        }

        private void AddDSGVChamBai(DSGVChamBai dSGVChamBai)
        {
            db.Database.ExecuteSqlCommand("execute AddDSGVChamBai '" + dSGVChamBai.maBaiThi + "', '" + dSGVChamBai.maGV + "', '" + dSGVChamBai.diem + "', '" + dSGVChamBai.chuThich + "'");
        }

        private void AddDSGiangDuong(DSGiangDuong dSGiangDuong)
        {
            db.Database.ExecuteSqlCommand("execute AddDSGiangDuong '" + dSGiangDuong.maGD + "', '" + dSGiangDuong.maLopHP + "', '" + dSGiangDuong.thu + "', '" + dSGiangDuong.chuThich + "'");
        }

        private void AddDSGiamThi(DSGiamThi dSGiamThi)
        {
            db.Database.ExecuteSqlCommand("execute AddDSGiamThi '" + dSGiamThi.maThiKetThuc + "', '" + dSGiamThi.maGV + "', '" + dSGiamThi.ngayPC + "', '" + dSGiamThi.chuThich + "'");
        }

        private void AddDSDiemDanhSV(DSDiemDanhSV dSDiemDanhSV)
        {
            db.Database.ExecuteSqlCommand("execute AddDiemDanh '" + dSDiemDanhSV.maDD + "', '" + dSDiemDanhSV.maSV + "', '" + dSDiemDanhSV.soBuoi + "'");
        }

        private void AddDSDeThi(DSDeThi dSDeThi)
        {
            db.Database.ExecuteSqlCommand("execute AddDSDeTHi '" + dSDeThi.maBaiThi + "', '" + dSDeThi.maDeThi + "', '" + dSDeThi.soTo + "', '" + dSDeThi.chuThich + "'");
        }

        private void AddDSCoVanHT(DSCoVanHT dSCoVanHT)
        {
            db.Database.ExecuteSqlCommand("execute AddDSCoVanHT '" + dSCoVanHT.maLopCN + "', '" + dSCoVanHT.maCV + "', '" + dSCoVanHT.ngayThanhLap +"', '" + dSCoVanHT.chuThich + "'");
        }

        private void AddDScanhcao(DScanhcao dScanhcao)
        {
            db.Database.ExecuteSqlCommand("execute AddDSCanhCao '" + dScanhcao.maCanhCao + "', '" + dScanhcao.maSV + "', '" + dScanhcao.chuThich + "'");
        }

        private void AddDiemDanh(DiemDanh diemDanh)
        {
            db.Database.ExecuteSqlCommand("execute AddDiemDanh '" + diemDanh.maDD + "', '" + diemDanh.maLopHP + "', '" + diemDanh.soBuoiDiemDanh + "'");
        }

        private void AddChuyenNganhDT(ChuyenNganhDT chuyenNganhDT)
        {
            db.Database.ExecuteSqlCommand("execute AddChuyenNganhDT '" + chuyenNganhDT.maNganhDT + "', '" + chuyenNganhDT.maChuyenNganh +"', '"+chuyenNganhDT.tenChuyenNganh+ "', '" + chuyenNganhDT.chuThich + "'");
        }

        private void AddCHiTietHP(CHiTietHP cHiTietHP)
        {
            db.Database.ExecuteSqlCommand("execute AddChiTietHP '" + cHiTietHP.maHP + "', '" + cHiTietHP.TenHinhThuc + "', '" + cHiTietHP.chuThich + "'");
        }

        private void AddCanhCao(CanhCao canhCao)
        {
            db.Database.ExecuteSqlCommand("execute AddCanhCao '" + canhCao.maCanhCao + "', '"+canhCao.tenCanhCao+"', '" + canhCao.chuThich + "'");
        }

        private void AddBoMon(BoMon boMon)
        {
            db.Database.ExecuteSqlCommand("Execute AddBoMon '"+boMon.maTruongBM+"' ,'"+boMon.maBM+"' ,'"+boMon.maKhoa+"', '"+boMon.tenBM+"' ,'"+boMon.chuThich+"'");
        }

        private void AddBaiThi(BaiThi baiThi)
        {
            db.Database.ExecuteSqlCommand("execute AddBaiThi '"+ baiThi.maBaiThi + "', ' ', '"+ baiThi.chuThich + "'");
            
        }
    }
}
