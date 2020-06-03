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
        DBContext_QLDT db = new DBContext_QLDT();
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

        ///
        [HttpGet]
        public ActionResult getTableData(string tableName)
        {
            object data;
            int count = 0;
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            switch (tableName)
            {
                case "Blog":
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).ToList();
                    count = (data as List<Blog>).Count;
                    break;
                case "Customer":
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).ToList();
                    count = (data as List<Customer>).Count;
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).ToList();
                    count = (data as List<DestinationReview>).Count;
                    break;
                case "DSDatXe":
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).ToList();
                    count = (data as List<DSDatXe>).Count;
                    break;
                case "DSKSCanTT":
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).ToList();
                    count = (data as List<DSKSCanTT>).Count;
                    break;
                case "DSKSTheoTrip":
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).ToList();
                    count = (data as List<DSKSTheoTrip>).Count;
                    break;
                case "DSKSTrongWL":
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).ToList();
                    count = (data as List<DSKSTrongWL>).Count;
                    break;
                case "DSTourCanTT":
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).ToList();
                    count = (data as List<DSTourCanTT>).Count;
                    break;
                case "DSTourTrongWL":
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).ToList();
                    count = (data as List<DSTourTrongWL>).Count;
                    break;
                case "DSTripTheoTour":
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).ToList();
                    count = (data as List<DSTripTheoTour>).Count;
                    break;
                case "ElecBill":
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName).ToList();
                    count = (data as List<ElecBill>).Count;
                    break;
                case "HomeStay":
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName).ToList();
                    count = (data as List<HomeStay>).Count;
                    break;
                case "Nation":
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName).ToList();
                    count = (data as List<Nation>).Count;
                    break;
                case "Province":
                    data = context.Database.SqlQuery<Province>("select * from " + tableName).ToList();
                    count = (data as List<Province>).Count;
                    break;
                case "Taxi":
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName).ToList();
                    count = (data as List<Taxi>).Count;
                    break;
                case "Tour":
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName).ToList();
                    count = (data as List<Tour>).Count;
                    break;
                case "TourDestination":
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName).ToList();
                    count = (data as List<TourDestination>).Count;
                    break;
                case "Trip":
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName).ToList();
                    count = (data as List<Trip>).Count;
                    break;
                case "WishList":
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName).ToList();
                    count = (data as List<WishList>).Count;
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
        public ActionResult ShowRow(string tableName, string key1, string key2, string actionName)
        {
            List<string> re = new List<string>();
            ViewBag.actionName = actionName;
            ViewBag.nameTable = tableName;
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            if (key1 != "")
            {
                key1 = key1.Trim();
                if (key2 != null) key2 = key2.Trim();

                object data;

                switch (tableName)
                {
                    case "Blog":
                        data = context.Database.SqlQuery<Blog>("select * from " + tableName + " where maBlog = '" + key1 + "'").ToList();
                        re.Add((data as List<Blog>)[0].maBlog);
                        re.Add((data as List<Blog>)[0].maDD);
                        re.Add((data as List<Blog>)[0].username);
                        re.Add((data as List<Blog>)[0].content);
                        re.Add((data as List<Blog>)[0].pic);
                        re.Add((data as List<Blog>)[0].note);
                        re.Add((data as List<Blog>)[0].header);
                        break;
                    case "Customer":
                        data = context.Database.SqlQuery<Customer>("select * from " + tableName + " where username = '" + key1 + "'").ToList();
                        re.Add((data as List<Customer>)[0].username);
                        re.Add((data as List<Customer>)[0].pass);
                        re.Add((data as List<Customer>)[0].tenKH);
                        re.Add((data as List<Customer>)[0].hoKH);
                        re.Add((data as List<Customer>)[0].phoneNum);
                        re.Add((data as List<Customer>)[0].email);
                        re.Add((data as List<Customer>)[0].note);
                        re.Add((data as List<Customer>)[0].Feedback);
                        re.Add((data as List<Customer>)[0].Job);
                        break;
                    case "DestinationReview":
                        data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName + " where maDD = '" + key1 + "'").ToList();
                        re.Add((data as List<DestinationReview>)[0].maDD);
                        re.Add((data as List<DestinationReview>)[0].tenDD);
                        re.Add((data as List<DestinationReview>)[0].tenTinh);
                        re.Add((data as List<DestinationReview>)[0].tenQG);
                        re.Add((data as List<DestinationReview>)[0].pic);
                        break;
                    case "DSDatXe":
                        data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName + " where maHD = '" + key1 + "' and bienSo = '" + key2 + "'").ToList();
                        re.Add((data as List<DSDatXe>)[0].maHD);
                        re.Add((data as List<DSDatXe>)[0].bienSo);
                        re.Add((data as List<DSDatXe>)[0].cost.ToString());
                        re.Add((data as List<DSDatXe>)[0].note);
                        break;
                    case "DSKSCanTT":
                        data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName + " where maKS = '" + key1 + "' and maHD = '" + key2 + "'").ToList();
                        re.Add((data as List<DSKSCanTT>)[0].maKS);
                        re.Add((data as List<DSKSCanTT>)[0].maHD);
                        re.Add((data as List<DSKSCanTT>)[0].cost.ToString());
                        re.Add((data as List<DSKSCanTT>)[0].note);
                        break;
                    case "DSKSTheoTrip":
                        data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName + " where maCD = '" + key1 + "' and maKS = '" + key2 + "'").ToList();
                        re.Add((data as List<DSKSTheoTrip>)[0].maCD);
                        re.Add((data as List<DSKSTheoTrip>)[0].maKS);
                        re.Add((data as List<DSKSTheoTrip>)[0].note);
                        break;
                    case "DSKSTrongWL":
                        data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName + " where maKS = '" + key1 + "' and maWL = '" + key2 + "'").ToList();
                        re.Add((data as List<DSKSTrongWL>)[0].maKS);
                        re.Add((data as List<DSKSTrongWL>)[0].maWL);
                        re.Add((data as List<DSKSTrongWL>)[0].ngayAdd.ToString());
                        re.Add((data as List<DSKSTrongWL>)[0].note);
                        break;
                    case "DSTourCanTT":
                        data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName + " where maTour = '" + key1 + "' and maHD = '" + key2 + "'").ToList();
                        re.Add((data as List<DSTourCanTT>)[0].maTour);
                        re.Add((data as List<DSTourCanTT>)[0].maHD);
                        re.Add((data as List<DSTourCanTT>)[0].cost.ToString());
                        re.Add((data as List<DSTourCanTT>)[0].note);
                        break;
                    case "DSTourTrongWL":
                        data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName + " where maTour = '" + key1 + "' and maWL = '" + key2 + "'").ToList();
                        re.Add((data as List<DSTourTrongWL>)[0].maTour);
                        re.Add((data as List<DSTourTrongWL>)[0].maWL);
                        re.Add((data as List<DSTourTrongWL>)[0].ngayAdd.ToString());
                        re.Add((data as List<DSTourTrongWL>)[0].note);
                        break;
                    case "DSTripTheoTour":
                        data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName + " where maCD = '" + key1 + "' and maTour = '" + key2 + "'").ToList();
                        re.Add((data as List<DSTripTheoTour>)[0].maCD);
                        re.Add((data as List<DSTripTheoTour>)[0].maTour);
                        re.Add((data as List<DSTripTheoTour>)[0].note);
                        break;
                    case "ElecBill":
                        data = context.Database.SqlQuery<ElecBill>("select * from " + tableName + " where maHD = '" + key1 + "'").ToList();
                        re.Add((data as List<ElecBill>)[0].maHD);
                        re.Add((data as List<ElecBill>)[0].username);
                        re.Add((data as List<ElecBill>)[0].tongTien.ToString());
                        re.Add((data as List<ElecBill>)[0].paymentMethod);
                        re.Add((data as List<ElecBill>)[0].dayCreate.ToString());
                        re.Add((data as List<ElecBill>)[0].note);
                        break;
                    case "HomeStay":
                        data = context.Database.SqlQuery<HomeStay>("select * from " + tableName + " where maKS = '" + key1 + "'").ToList();
                        re.Add((data as List<HomeStay>)[0].maKS);
                        re.Add((data as List<HomeStay>)[0].maDD);
                        re.Add((data as List<HomeStay>)[0].tenKS);
                        re.Add((data as List<HomeStay>)[0].phoneNum);
                        re.Add((data as List<HomeStay>)[0].pic);
                        re.Add((data as List<HomeStay>)[0].note);
                        re.Add((data as List<HomeStay>)[0].moTa);
                        re.Add((data as List<HomeStay>)[0].numReview.ToString());
                        re.Add((data as List<HomeStay>)[0].costPerNight.ToString());
                        break;
                    case "Nation":
                        data = context.Database.SqlQuery<Nation>("select * from " + tableName + " where maQG = '" + key1 + "'").ToList();
                        re.Add((data as List<Nation>)[0].maQG);
                        re.Add((data as List<Nation>)[0].tenQG);
                        re.Add((data as List<Nation>)[0].pic);
                        re.Add((data as List<Nation>)[0].note);
                        re.Add((data as List<Nation>)[0].countTour.ToString());
                        break;
                    case "Province":
                        data = context.Database.SqlQuery<Province>("select * from " + tableName + " where maTinh = '" + key1 + "'").ToList();
                        re.Add((data as List<Province>)[0].maTinh);
                        re.Add((data as List<Province>)[0].maQG);
                        re.Add((data as List<Province>)[0].tenTinh);
                        re.Add((data as List<Province>)[0].pic);
                        re.Add((data as List<Province>)[0].note);
                        re.Add((data as List<Province>)[0].moTa);
                        break;
                    case "Taxi":
                        data = context.Database.SqlQuery<Taxi>("select * from " + tableName + " where bienSo = '" + key1 + "'").ToList();
                        re.Add((data as List<Taxi>)[0].bienSo);
                        re.Add((data as List<Taxi>)[0].maDD);
                        re.Add((data as List<Taxi>)[0].soGhe.ToString());
                        re.Add((data as List<Taxi>)[0].phoneNum);
                        re.Add((data as List<Taxi>)[0].note);
                        break;
                    case "Tour":
                        data = context.Database.SqlQuery<Tour>("select * from " + tableName + " where maTour = '" + key1 + "'").ToList();
                        re.Add((data as List<Tour>)[0].maTour);
                        re.Add((data as List<Tour>)[0].tenTour);
                        re.Add((data as List<Tour>)[0].dayStart.ToString());
                        re.Add((data as List<Tour>)[0].soLuongMax.ToString());
                        re.Add((data as List<Tour>)[0].soDem.ToString());
                        re.Add((data as List<Tour>)[0].pic);
                        re.Add((data as List<Tour>)[0].note);
                        re.Add((data as List<Tour>)[0].moTa);
                        break;
                    case "TourDestination":
                        data = context.Database.SqlQuery<TourDestination>("select * from " + tableName + " where maDD = '" + key1 + "'").ToList();
                        re.Add((data as List<TourDestination>)[0].maDD);
                        re.Add((data as List<TourDestination>)[0].maTinh);
                        re.Add((data as List<TourDestination>)[0].tenDD);
                        re.Add((data as List<TourDestination>)[0].pic);
                        re.Add((data as List<TourDestination>)[0].note);
                        re.Add((data as List<TourDestination>)[0].near);
                        re.Add((data as List<TourDestination>)[0].countHomeStay.ToString());
                        re.Add((data as List<TourDestination>)[0].countTaxi.ToString());
                        break;
                    case "Trip":
                        data = context.Database.SqlQuery<Trip>("select * from " + tableName + " where maCD = '" + key1 + "'").ToList();
                        re.Add((data as List<Trip>)[0].maCD);
                        re.Add((data as List<Trip>)[0].maDDStart);
                        re.Add((data as List<Trip>)[0].maDDEnd);
                        re.Add((data as List<Trip>)[0].dayStrat.ToString());
                        re.Add((data as List<Trip>)[0].pic);
                        re.Add((data as List<Trip>)[0].note);
                        break;
                    case "WishList":
                        data = context.Database.SqlQuery<WishList>("select * from " + tableName + " where maWL = '" + key1 + "'").ToList();
                        re.Add((data as List<WishList>)[0].maWL);
                        re.Add((data as List<WishList>)[0].username);
                        re.Add((data as List<WishList>)[0].note);
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
                case "Blog":
                    data = new Blog();
                    dataO = new Blog();
                    (data as Blog).maBlog = Request.Form["0"];
                    (data as Blog).maDD = Request.Form["1"];
                    (data as Blog).username = Request.Form["2"];
                    (data as Blog).content = Request.Form["3"];
                    (data as Blog).pic = Request.Form["4"];
                    (data as Blog).note = Request.Form["5"];
                    (data as Blog).header = Request.Form["6"];
                    (dataO as Blog).maBlog = Request.Form["50"];
                    (dataO as Blog).maDD = Request.Form["51"];
                    (dataO as Blog).username = Request.Form["52"];
                    (dataO as Blog).content = Request.Form["53"];
                    (dataO as Blog).pic = Request.Form["54"];
                    (dataO as Blog).note = Request.Form["55"];
                    (dataO as Blog).header = Request.Form["56"];
                    ModifyBlogs(dataO as Blog, data as Blog);
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).ToList();
                    break;
                case "Customer":
                    data = new Customer();
                    (data as Customer).username = Request.Form["0"];
                    (data as Customer).pass = Request.Form["1"];
                    (data as Customer).tenKH = Request.Form["2"];
                    (data as Customer).hoKH = Request.Form["3"];
                    (data as Customer).phoneNum = Request.Form["4"];
                    (data as Customer).email = Request.Form["5"];
                    (data as Customer).note = Request.Form["6"];
                    (data as Customer).Feedback = Request.Form["7"];
                    (data as Customer).Job = Request.Form["8"];
                    dataO = new Customer();
                    (dataO as Customer).username = Request.Form["50"];
                    (dataO as Customer).pass = Request.Form["51"];
                    (dataO as Customer).tenKH = Request.Form["52"];
                    (dataO as Customer).hoKH = Request.Form["53"];
                    (dataO as Customer).phoneNum = Request.Form["54"];
                    (dataO as Customer).email = Request.Form["55"];
                    (dataO as Customer).note = Request.Form["56"];
                    (dataO as Customer).Feedback = Request.Form["57"];
                    (dataO as Customer).Job = Request.Form["58"];
                    ModifyCustomer(dataO as Customer, data as Customer);
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).ToList();
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).ToList();
                    // bo lai
                    break;
                case "DSDatXe":
                    data = new DSDatXe();
                    (data as DSDatXe).maHD = Request.Form["0"];
                    (data as DSDatXe).bienSo = Request.Form["1"];
                    (data as DSDatXe).cost = Double.Parse((Request.Form["2"]));
                    (data as DSDatXe).note = Request.Form["3"];
                    dataO = new DSDatXe();
                    (dataO as DSDatXe).maHD = Request.Form["50"];
                    (dataO as DSDatXe).bienSo = Request.Form["51"];
                    (dataO as DSDatXe).cost = Double.Parse((Request.Form["52"]));
                    (dataO as DSDatXe).note = Request.Form["53"];
                    ModifyDSDatXe(dataO as DSDatXe, data as DSDatXe);
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).ToList();
                    break;
                case "DSKSCanTT":
                    data = new DSKSCanTT();
                    (data as DSKSCanTT).maKS = Request.Form["0"];
                    (data as DSKSCanTT).maHD = Request.Form["1"];
                    (data as DSKSCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSKSCanTT).note = Request.Form["3"];
                    dataO = new DSKSCanTT();
                    (dataO as DSKSCanTT).maKS = Request.Form["50"];
                    (dataO as DSKSCanTT).maHD = Request.Form["51"];
                    (dataO as DSKSCanTT).cost = Double.Parse((Request.Form["52"]));
                    (dataO as DSKSCanTT).note = Request.Form["53"];
                    ModifyDSKSCanTT(dataO as DSKSCanTT, data as DSKSCanTT);
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSKSTheoTrip":
                    data = new DSKSTheoTrip();
                    (data as DSKSTheoTrip).maCD = Request.Form["0"];
                    (data as DSKSTheoTrip).maKS = Request.Form["1"];
                    (data as DSKSTheoTrip).note = Request.Form["2"];
                    dataO = new DSKSTheoTrip();
                    (dataO as DSKSTheoTrip).maCD = Request.Form["50"];
                    (dataO as DSKSTheoTrip).maKS = Request.Form["51"];
                    (dataO as DSKSTheoTrip).note = Request.Form["52"];
                    ModifyDSKSTheoTrip(dataO as DSKSTheoTrip, data as DSKSTheoTrip);
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).ToList();
                    break;
                case "DSKSTrongWL":
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    dataO = new DSTourTrongWL();
                    (dataO as DSTourTrongWL).maTour = Request.Form["50"];
                    (dataO as DSTourTrongWL).maWL = Request.Form["51"];
                    (dataO as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["52"]));
                    (dataO as DSTourTrongWL).note = Request.Form["53"];
                    ModifyDSTourTrongWL(dataO as DSTourTrongWL, data as DSTourTrongWL);
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTourCanTT":
                    data = new DSTourCanTT();
                    (data as DSTourCanTT).maTour = Request.Form["0"];
                    (data as DSTourCanTT).maHD = Request.Form["1"];
                    (data as DSTourCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSTourCanTT).note = Request.Form["3"];
                    dataO = new DSTourCanTT();
                    (dataO as DSTourCanTT).maTour = Request.Form["50"];
                    (dataO as DSTourCanTT).maHD = Request.Form["51"];
                    (dataO as DSTourCanTT).cost = Double.Parse((Request.Form["52"]));
                    (dataO as DSTourCanTT).note = Request.Form["53"];
                    ModifyDSTourCanTT(dataO as DSTourCanTT, data as DSTourCanTT);
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSTourTrongWL":
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    dataO = new DSTourTrongWL();
                    (dataO as DSTourTrongWL).maTour = Request.Form["50"];
                    (dataO as DSTourTrongWL).maWL = Request.Form["51"];
                    (dataO as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["52"]));
                    (dataO as DSTourTrongWL).note = Request.Form["53"];
                    ModifyDSTourTrongWL(dataO as DSTourTrongWL, data as DSTourTrongWL);
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTripTheoTour":
                    data = new DSTripTheoTour();
                    (data as DSTripTheoTour).maCD = Request.Form["0"];
                    (data as DSTripTheoTour).maTour = Request.Form["1"];
                    (data as DSTripTheoTour).note = Request.Form["2"];
                    dataO = new DSTripTheoTour();
                    (dataO as DSTripTheoTour).maCD = Request.Form["50"];
                    (dataO as DSTripTheoTour).maTour = Request.Form["51"];
                    (dataO as DSTripTheoTour).note = Request.Form["52"];
                    ModifyDSTripTheoTour(dataO as DSTripTheoTour, data as DSTripTheoTour);
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).ToList();
                    break;
                case "ElecBill":
                    data = new ElecBill();
                    (data as ElecBill).maHD = Request.Form["0"];
                    (data as ElecBill).username = Request.Form["1"];
                    (data as ElecBill).tongTien = Double.Parse(Request.Form["2"]);
                    (data as ElecBill).paymentMethod = Request.Form["3"];
                    (data as ElecBill).dayCreate = DateTime.Parse(Request.Form["4"]);
                    (data as ElecBill).note = Request.Form["5"];
                    dataO = new ElecBill();
                    (dataO as ElecBill).maHD = Request.Form["50"];
                    (dataO as ElecBill).username = Request.Form["51"];
                    (dataO as ElecBill).tongTien = Double.Parse(Request.Form["52"]);
                    (dataO as ElecBill).paymentMethod = Request.Form["53"];
                    (dataO as ElecBill).dayCreate = DateTime.Parse(Request.Form["54"]);
                    (dataO as ElecBill).note = Request.Form["55"];
                    ModifyElecBill(dataO as ElecBill, data as ElecBill);
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName).ToList();
                    break;
                case "HomeStay":
                    data = new HomeStay();
                    (data as HomeStay).maKS = Request.Form["0"];
                    (data as HomeStay).maDD = Request.Form["1"];
                    (data as HomeStay).tenKS = Request.Form["2"];
                    (data as HomeStay).phoneNum = Request.Form["3"];
                    (data as HomeStay).pic = Request.Form["4"];
                    (data as HomeStay).note = Request.Form["5"];
                    (data as HomeStay).moTa = Request.Form["6"];
                    (data as HomeStay).numReview = Int32.Parse(Request.Form["7"]);
                    (data as HomeStay).costPerNight = Int32.Parse(Request.Form["8"]);
                    dataO = new HomeStay();
                    (dataO as HomeStay).maKS = Request.Form["50"];
                    (dataO as HomeStay).maDD = Request.Form["51"];
                    (dataO as HomeStay).tenKS = Request.Form["52"];
                    (dataO as HomeStay).phoneNum = Request.Form["53"];
                    (dataO as HomeStay).pic = Request.Form["54"];
                    (dataO as HomeStay).note = Request.Form["55"];
                    (dataO as HomeStay).moTa = Request.Form["56"];
                    (dataO as HomeStay).numReview = Int32.Parse(Request.Form["57"]);
                    (dataO as HomeStay).costPerNight = Int32.Parse(Request.Form["58"]);
                    ModifyHomeStay(dataO as HomeStay, data as HomeStay);
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName).ToList();
                    break;
                case "Nation":
                    data = new Nation();
                    (data as Nation).maQG = Request.Form["0"];
                    (data as Nation).tenQG = Request.Form["1"];
                    (data as Nation).pic = Request.Form["2"];
                    (data as Nation).note = Request.Form["3"];
                    (data as Nation).moTa = Request.Form["4"];
                    (data as Nation).countTour = Int32.Parse(Request.Form["5"]);
                    dataO = new Nation();
                    (dataO as Nation).maQG = Request.Form["50"];
                    (dataO as Nation).tenQG = Request.Form["51"];
                    (dataO as Nation).pic = Request.Form["52"];
                    (dataO as Nation).note = Request.Form["53"];
                    (dataO as Nation).moTa = Request.Form["54"];
                    (dataO as Nation).countTour = Int32.Parse(Request.Form["55"]);
                    ModifyNation(dataO as Nation, data as Nation);
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName).ToList();
                    break;
                case "Province":
                    data = new Province();
                    (data as Province).maTinh = Request.Form["0"];
                    (data as Province).maQG = Request.Form["1"];
                    (data as Province).tenTinh = Request.Form["2"];
                    (data as Province).note = Request.Form["3"];
                    (data as Province).moTa = Request.Form["4"];
                    dataO = new Province();
                    (dataO as Province).maTinh = Request.Form["50"];
                    (dataO as Province).maQG = Request.Form["51"];
                    (dataO as Province).tenTinh = Request.Form["52"];
                    (dataO as Province).note = Request.Form["53"];
                    (dataO as Province).moTa = Request.Form["54"];
                    ModifyProvince(dataO as Province, data as Province);
                    data = context.Database.SqlQuery<Province>("select * from " + tableName).ToList();
                    break;
                case "Taxi":
                    data = new Taxi();
                    (data as Taxi).bienSo = Request.Form["0"];
                    (data as Taxi).maDD = Request.Form["1"];
                    (data as Taxi).soGhe = Int32.Parse(Request.Form["2"]);
                    (data as Taxi).phoneNum = Request.Form["3"];
                    (data as Taxi).note = Request.Form["4"];
                    dataO = new Taxi();
                    (dataO as Taxi).bienSo = Request.Form["50"];
                    (dataO as Taxi).maDD = Request.Form["51"];
                    (dataO as Taxi).soGhe = Int32.Parse(Request.Form["52"]);
                    (dataO as Taxi).phoneNum = Request.Form["53"];
                    (dataO as Taxi).note = Request.Form["54"];
                    ModifyTaxi(dataO as Taxi, data as Taxi);
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName).ToList();
                    break;
                case "Tour":
                    data = new Tour();
                    (data as Tour).maTour = Request.Form["0"];
                    (data as Tour).tenTour = Request.Form["1"];
                    (data as Tour).dayStart = DateTime.Parse(Request.Form["2"]);
                    (data as Tour).soLuongMax = Int32.Parse(Request.Form["3"]);
                    (data as Tour).soDem = Int32.Parse(Request.Form["4"]);
                    (data as Tour).pic = Request.Form["5"];
                    (data as Tour).note = Request.Form["6"];
                    (data as Tour).moTa = Request.Form["7"];
                    dataO = new Tour();
                    (dataO as Tour).maTour = Request.Form["50"];
                    (dataO as Tour).tenTour = Request.Form["51"];
                    (dataO as Tour).dayStart = DateTime.Parse(Request.Form["52"]);
                    (dataO as Tour).soLuongMax = Int32.Parse(Request.Form["53"]);
                    (dataO as Tour).soDem = Int32.Parse(Request.Form["54"]);
                    (dataO as Tour).pic = Request.Form["55"];
                    (dataO as Tour).note = Request.Form["56"];
                    (dataO as Tour).moTa = Request.Form["57"];
                    ModifyTour(dataO as Tour, data as Tour);
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName).ToList();
                    break;
                case "TourDestination":
                    data = new TourDestination();
                    (data as TourDestination).maDD = Request.Form["0"];
                    (data as TourDestination).maTinh = Request.Form["1"];
                    (data as TourDestination).tenDD = Request.Form["2"];
                    (data as TourDestination).pic = Request.Form["3"];
                    (data as TourDestination).note = Request.Form["4"];
                    (data as TourDestination).near = Request.Form["5"];
                    (data as TourDestination).countHomeStay = Int32.Parse(Request.Form["6"]);
                    (data as TourDestination).countTaxi = Int32.Parse(Request.Form["7"]);
                    dataO = new TourDestination();
                    (dataO as TourDestination).maDD = Request.Form["50"];
                    (dataO as TourDestination).maTinh = Request.Form["51"];
                    (dataO as TourDestination).tenDD = Request.Form["52"];
                    (dataO as TourDestination).pic = Request.Form["53"];
                    (dataO as TourDestination).note = Request.Form["54"];
                    (dataO as TourDestination).near = Request.Form["55"];
                    (dataO as TourDestination).countHomeStay = Int32.Parse(Request.Form["56"]);
                    (dataO as TourDestination).countTaxi = Int32.Parse(Request.Form["57"]);
                    ModifyTourDestination(dataO as TourDestination, data as TourDestination);
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName).ToList();
                    break;
                case "Trip":
                    data = new Trip();
                    (data as Trip).maCD = Request.Form["0"];
                    (data as Trip).maDDStart = Request.Form["1"];
                    (data as Trip).maDDEnd = Request.Form["2"];
                    (data as Trip).dayStrat = DateTime.Parse(Request.Form["3"]);
                    (data as Trip).pic = Request.Form["4"];
                    (data as Trip).note = Request.Form["5"];
                    dataO = new Trip();
                    (dataO as Trip).maCD = Request.Form["50"];
                    (dataO as Trip).maDDStart = Request.Form["51"];
                    (dataO as Trip).maDDEnd = Request.Form["52"];
                    (dataO as Trip).dayStrat = DateTime.Parse(Request.Form["53"]);
                    (dataO as Trip).pic = Request.Form["54"];
                    (dataO as Trip).note = Request.Form["55"];
                    ModifyTrip(dataO as Trip, data as Trip);
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName).ToList();
                    break;
                case "WishList":
                    data = new WishList();
                    (data as WishList).maWL = Request.Form["0"];
                    (data as WishList).username = Request.Form["1"];
                    (data as WishList).note = Request.Form["2"];
                    dataO = new WishList();
                    (dataO as WishList).maWL = Request.Form["50"];
                    (dataO as WishList).username = Request.Form["51"];
                    (dataO as WishList).note = Request.Form["52"];
                    ModifyWishList(dataO as WishList, data as WishList);
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName).ToList();
                    break;
                default:
                    data = null;
                    break;
            }
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
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
                case "Blog":
                    data = new BaiThi();
                    (data as BaiThi).maBlog = Request.Form["0"];
                    (data as BaiThi).maDD = Request.Form["1"];
                    (data as BaiThi).username = Request.Form["2"];
                    (data as BaiThi).content = Request.Form["3"];
                    (data as BaiThi).pic = Request.Form["4"];
                    (data as BaiThi).note = Request.Form["5"];
                    (data as BaiThi).header = Request.Form["6"];
                    AddBlogs(data as BaiThi);
                    data = context.Database.SqlQuery<BaiThi>("select * from " + tableName).ToList();
                    break;
                case "Customer":
                    data = new Customer();
                    (data as Customer).username = Request.Form["0"];
                    (data as Customer).pass = Request.Form["1"];
                    (data as Customer).tenKH = Request.Form["2"];
                    (data as Customer).hoKH = Request.Form["3"];
                    (data as Customer).phoneNum = Request.Form["4"];
                    (data as Customer).email = Request.Form["5"];
                    (data as Customer).note = Request.Form["6"];
                    (data as Customer).Feedback = Request.Form["7"];
                    (data as Customer).Job = Request.Form["8"];
                    AddCustomer(data as Customer);
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).ToList();
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).ToList();
                    // bo
                    break;
                case "DSDatXe":
                    data = new DSDatXe();
                    (data as DSDatXe).maHD = Request.Form["0"];
                    (data as DSDatXe).bienSo = Request.Form["1"];
                    (data as DSDatXe).cost = Double.Parse((Request.Form["2"]));
                    (data as DSDatXe).note = Request.Form["3"];
                    AddDSDatXe(data as DSDatXe);
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).ToList();
                    break;
                case "DSKSCanTT":
                    data = new DSKSCanTT();
                    (data as DSKSCanTT).maKS = Request.Form["0"];
                    (data as DSKSCanTT).maHD = Request.Form["1"];
                    (data as DSKSCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSKSCanTT).note = Request.Form["3"];
                    AddDSKSCanTT(data as DSKSCanTT);
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSKSTheoTrip":
                    data = new DSKSTheoTrip();
                    (data as DSKSTheoTrip).maCD = Request.Form["0"];
                    (data as DSKSTheoTrip).maKS = Request.Form["1"];
                    (data as DSKSTheoTrip).note = Request.Form["2"];
                    AddDSKSTheoTrip(data as DSKSTheoTrip);
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).ToList();
                    break;
                case "DSKSTrongWL":
                    data = new DSKSTrongWL();
                    (data as DSKSTrongWL).maKS = Request.Form["0"];
                    (data as DSKSTrongWL).maWL = Request.Form["1"];
                    (data as DSKSTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSKSTrongWL).note = Request.Form["3"];
                    AddDSKSTrongWL(data as DSKSTrongWL);
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTourCanTT":
                    data = new DSTourCanTT();
                    (data as DSTourCanTT).maTour = Request.Form["0"];
                    (data as DSTourCanTT).maHD = Request.Form["1"];
                    (data as DSTourCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSTourCanTT).note = Request.Form["3"];
                    AddDSTourCanTT(data as DSTourCanTT);
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSTourTrongWL":
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    AddDSTourTrongWL(data as DSTourTrongWL);
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTripTheoTour":
                    data = new DSTripTheoTour();
                    (data as DSTripTheoTour).maCD = Request.Form["0"];
                    (data as DSTripTheoTour).maTour = Request.Form["1"];
                    (data as DSTripTheoTour).note = Request.Form["2"];
                    AddDSTripTheoTour(data as DSTripTheoTour);
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).ToList();
                    break;
                case "ElecBill":
                    data = new ElecBill();
                    (data as ElecBill).maHD = Request.Form["0"];
                    (data as ElecBill).username = Request.Form["1"];
                    (data as ElecBill).tongTien = Double.Parse(Request.Form["2"]);
                    (data as ElecBill).paymentMethod = Request.Form["3"];
                    (data as ElecBill).dayCreate = DateTime.Parse((Request.Form["4"]));
                    (data as ElecBill).note = Request.Form["5"];
                    AddElecBill(data as ElecBill);
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName).ToList();
                    break;
                case "HomeStay":
                    data = new HomeStay();
                    (data as HomeStay).maKS = Request.Form["0"];
                    (data as HomeStay).maDD = Request.Form["1"];
                    (data as HomeStay).tenKS = Request.Form["2"];
                    (data as HomeStay).phoneNum = Request.Form["3"];
                    (data as HomeStay).pic = Request.Form["4"];
                    (data as HomeStay).note = Request.Form["5"];
                    (data as HomeStay).moTa = Request.Form["6"];
                    (data as HomeStay).numReview = Int32.Parse(Request.Form["7"]);
                    (data as HomeStay).costPerNight = Int32.Parse(Request.Form["8"]);
                    AddHomeStay(data as HomeStay);
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName).ToList();
                    break;
                case "Nation":
                    data = new Nation();
                    (data as Nation).maQG = Request.Form["0"];
                    (data as Nation).tenQG = Request.Form["1"];
                    (data as Nation).pic = Request.Form["2"];
                    (data as Nation).note = Request.Form["3"];
                    (data as Nation).moTa = Request.Form["4"];
                    (data as Nation).countTour = Int32.Parse(Request.Form["5"]);
                    AddNation(data as Nation);
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName).ToList();
                    break;
                case "Province":
                    data = new Province();
                    (data as Province).maTinh = Request.Form["0"];
                    (data as Province).maQG = Request.Form["1"];
                    (data as Province).tenTinh = Request.Form["2"];
                    (data as Province).pic = Request.Form["3"];
                    (data as Province).note = Request.Form["4"];
                    (data as Province).moTa = Request.Form["5"];
                    AddProvince(data as Province);
                    data = context.Database.SqlQuery<Province>("select * from " + tableName).ToList();
                    break;
                case "Taxi":
                    data = new Taxi();
                    (data as Taxi).bienSo = Request.Form["0"];
                    (data as Taxi).maDD = Request.Form["1"];
                    (data as Taxi).soGhe = Int32.Parse(Request.Form["2"]);
                    (data as Taxi).phoneNum = Request.Form["3"];
                    (data as Taxi).note = Request.Form["4"];
                    AddTaxi(data as Taxi);
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName).ToList();
                    break;
                case "Tour":
                    data = new Tour();
                    (data as Tour).maTour = Request.Form["0"];
                    (data as Tour).tenTour = Request.Form["1"];
                    (data as Tour).dayStart = DateTime.Parse(Request.Form["2"]);
                    (data as Tour).soLuongMax = Int32.Parse(Request.Form["3"]);
                    (data as Tour).soDem = Int32.Parse(Request.Form["4"]);
                    (data as Tour).pic = Request.Form["5"];
                    (data as Tour).note = Request.Form["6"];
                    (data as Tour).moTa = Request.Form["7"];
                    AddTour(data as Tour);
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName).ToList();
                    break;
                case "TourDestination":
                    data = new TourDestination();
                    (data as TourDestination).maDD = Request.Form["0"];
                    (data as TourDestination).maTinh = Request.Form["1"];
                    (data as TourDestination).tenDD = Request.Form["2"];
                    (data as TourDestination).pic = Request.Form["3"];
                    (data as TourDestination).near = Request.Form["4"];
                    (data as TourDestination).countHomeStay = Int32.Parse(Request.Form["5"]);
                    (data as TourDestination).countTaxi = Int32.Parse(Request.Form["6"]);
                    AddTourDestination(data as TourDestination);
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName).ToList();
                    break;
                case "Trip":
                    data = new Trip();
                    (data as Trip).maCD = Request.Form["0"];
                    (data as Trip).maDDStart = Request.Form["1"];
                    (data as Trip).maDDEnd = Request.Form["2"];
                    (data as Trip).dayStrat = DateTime.Parse(Request.Form["3"]);
                    (data as Trip).pic = Request.Form["4"];
                    (data as Trip).note = Request.Form["5"];
                    AddTrip(data as Trip);
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName).ToList();
                    break;
                case "WishList":
                    data = new WishList();
                    (data as WishList).maWL = Request.Form["0"];
                    (data as WishList).username = Request.Form["1"];
                    (data as WishList).note = Request.Form["2"];
                    AddWishList(data as WishList);
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName).ToList();
                    break;
                default:
                    data = null;
                    break;
            }
            //var ads = context.DestinationReviews.ToList();
            //var tableNameList = context.TenCacBangs.ToList();
            //ViewBag.tableNameList = tableNameList;
            //return View("Table", ads);
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
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
                case "Blog":
                    data = new Blog();
                    (data as Blog).maBlog = Request.Form["0"];
                    (data as Blog).maDD = Request.Form["1"];
                    (data as Blog).username = Request.Form["2"];
                    (data as Blog).content = Request.Form["3"];
                    (data as Blog).pic = Request.Form["4"];
                    (data as Blog).note = Request.Form["5"];
                    (data as Blog).header = Request.Form["6"];
                    DeleteBlogs(data as Blog);
                    data = context.Database.SqlQuery<Blog>("select * from " + tableName).ToList();
                    break;
                case "Customer":
                    data = new Customer();
                    (data as Customer).username = Request.Form["0"];
                    (data as Customer).pass = Request.Form["1"];
                    (data as Customer).tenKH = Request.Form["2"];
                    (data as Customer).hoKH = Request.Form["3"];
                    (data as Customer).phoneNum = Request.Form["4"];
                    (data as Customer).email = Request.Form["5"];
                    (data as Customer).note = Request.Form["6"];
                    (data as Customer).Feedback = Request.Form["7"];
                    (data as Customer).Job = Request.Form["8"];
                    DeleteCustomer(data as Customer);
                    data = context.Database.SqlQuery<Customer>("select * from " + tableName).ToList();
                    break;
                case "DestinationReview":
                    data = context.Database.SqlQuery<DestinationReview>("select * from " + tableName).ToList();
                    // bo
                    break;
                case "DSDatXe":
                    data = new DSDatXe();
                    (data as DSDatXe).maHD = Request.Form["0"];
                    (data as DSDatXe).bienSo = Request.Form["1"];
                    (data as DSDatXe).cost = Double.Parse((Request.Form["2"]));
                    (data as DSDatXe).note = Request.Form["3"];
                    DeleteDSDatXe(data as DSDatXe);
                    data = context.Database.SqlQuery<DSDatXe>("select * from " + tableName).ToList();
                    break;
                case "DSKSCanTT":
                    data = new DSKSCanTT();
                    (data as DSKSCanTT).maKS = Request.Form["0"];
                    (data as DSKSCanTT).maHD = Request.Form["1"];
                    (data as DSKSCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSKSCanTT).note = Request.Form["3"];
                    DeleteDSKSCanTT(data as DSKSCanTT);
                    data = context.Database.SqlQuery<DSKSCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSKSTheoTrip":
                    data = new DSKSTheoTrip();
                    (data as DSKSTheoTrip).maCD = Request.Form["0"];
                    (data as DSKSTheoTrip).maKS = Request.Form["1"];
                    (data as DSKSTheoTrip).note = Request.Form["2"];
                    DeleteDSKSTheoTrip(data as DSKSTheoTrip);
                    data = context.Database.SqlQuery<DSKSTheoTrip>("select * from " + tableName).ToList();
                    break;
                case "DSKSTrongWL":
                    data = new DSKSTrongWL();
                    (data as DSKSTrongWL).maKS = Request.Form["0"];
                    (data as DSKSTrongWL).maWL = Request.Form["1"];
                    (data as DSKSTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSKSTrongWL).note = Request.Form["3"];
                    DeleteDSKSTrongWL(data as DSKSTrongWL);
                    data = context.Database.SqlQuery<DSKSTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTourCanTT":
                    data = new DSTourCanTT();
                    (data as DSTourCanTT).maTour = Request.Form["0"];
                    (data as DSTourCanTT).maHD = Request.Form["1"];
                    (data as DSTourCanTT).cost = Double.Parse((Request.Form["2"]));
                    (data as DSTourCanTT).note = Request.Form["3"];
                    DeleteDSTourCanTT(data as DSTourCanTT);
                    data = context.Database.SqlQuery<DSTourCanTT>("select * from " + tableName).ToList();
                    break;
                case "DSTourTrongWL":
                    data = new DSTourTrongWL();
                    (data as DSTourTrongWL).maTour = Request.Form["0"];
                    (data as DSTourTrongWL).maWL = Request.Form["1"];
                    (data as DSTourTrongWL).ngayAdd = DateTime.Parse((Request.Form["2"]));
                    (data as DSTourTrongWL).note = Request.Form["3"];
                    DeleteDSTourTrongWL(data as DSTourTrongWL);
                    data = context.Database.SqlQuery<DSTourTrongWL>("select * from " + tableName).ToList();
                    break;
                case "DSTripTheoTour":
                    data = new DSTripTheoTour();
                    (data as DSTripTheoTour).maCD = Request.Form["0"];
                    (data as DSTripTheoTour).maTour = Request.Form["1"];
                    (data as DSTripTheoTour).note = Request.Form["2"];
                    DeleteDSTripTheoTour(data as DSTripTheoTour);
                    data = context.Database.SqlQuery<DSTripTheoTour>("select * from " + tableName).ToList();
                    break;
                case "ElecBill":
                    data = new ElecBill();
                    (data as ElecBill).maHD = Request.Form["0"];
                    (data as ElecBill).username = Request.Form["1"];
                    (data as ElecBill).tongTien = Double.Parse(Request.Form["2"]);
                    (data as ElecBill).paymentMethod = Request.Form["3"];
                    (data as ElecBill).dayCreate = DateTime.Parse((Request.Form["4"]));
                    (data as ElecBill).note = Request.Form["5"];
                    DeleteElecBill(data as ElecBill);
                    data = context.Database.SqlQuery<ElecBill>("select * from " + tableName).ToList();
                    break;
                case "HomeStay":
                    data = new HomeStay();
                    (data as HomeStay).maKS = Request.Form["0"];
                    (data as HomeStay).maDD = Request.Form["1"];
                    (data as HomeStay).tenKS = Request.Form["2"];
                    (data as HomeStay).phoneNum = Request.Form["3"];
                    (data as HomeStay).pic = Request.Form["4"];
                    (data as HomeStay).note = Request.Form["5"];
                    (data as HomeStay).moTa = Request.Form["6"];
                    (data as HomeStay).numReview = Int32.Parse(Request.Form["7"]);
                    (data as HomeStay).costPerNight = Int32.Parse(Request.Form["8"]);
                    DeleteHomeStay(data as HomeStay);
                    data = context.Database.SqlQuery<HomeStay>("select * from " + tableName).ToList();
                    break;
                case "Nation":
                    data = new Nation();
                    (data as Nation).maQG = Request.Form["0"];
                    (data as Nation).tenQG = Request.Form["1"];
                    (data as Nation).pic = Request.Form["2"];
                    (data as Nation).note = Request.Form["3"];
                    (data as Nation).moTa = Request.Form["4"];
                    (data as Nation).countTour = Int32.Parse(Request.Form["5"]);
                    DeleteNation(data as Nation);
                    data = context.Database.SqlQuery<Nation>("select * from " + tableName).ToList();
                    break;
                case "Province":
                    data = new Province();
                    (data as Province).maTinh = Request.Form["0"];
                    (data as Province).maQG = Request.Form["1"];
                    (data as Province).tenTinh = Request.Form["2"];
                    (data as Province).pic = Request.Form["3"];
                    (data as Province).note = Request.Form["4"];
                    (data as Province).moTa = Request.Form["5"];
                    DeleteProvince(data as Province);
                    data = context.Database.SqlQuery<Province>("select * from " + tableName).ToList();
                    break;
                case "Taxi":
                    data = new Taxi();
                    (data as Taxi).bienSo = Request.Form["0"];
                    (data as Taxi).maDD = Request.Form["1"];
                    (data as Taxi).soGhe = Int32.Parse(Request.Form["2"]);
                    (data as Taxi).phoneNum = Request.Form["3"];
                    (data as Taxi).note = Request.Form["4"];
                    DeleteTaxi(data as Taxi);
                    data = context.Database.SqlQuery<Taxi>("select * from " + tableName).ToList();
                    break;
                case "Tour":
                    data = new Tour();
                    (data as Tour).maTour = Request.Form["0"];
                    (data as Tour).tenTour = Request.Form["1"];
                    (data as Tour).dayStart = DateTime.Parse(Request.Form["2"]);
                    (data as Tour).soLuongMax = Int32.Parse(Request.Form["3"]);
                    (data as Tour).soDem = Int32.Parse(Request.Form["4"]);
                    (data as Tour).pic = Request.Form["5"];
                    (data as Tour).note = Request.Form["6"];
                    (data as Tour).moTa = Request.Form["7"];
                    DeleteTour(data as Tour);
                    data = context.Database.SqlQuery<Tour>("select * from " + tableName).ToList();
                    break;
                case "TourDestination":
                    data = new TourDestination();
                    (data as TourDestination).maDD = Request.Form["0"];
                    (data as TourDestination).maTinh = Request.Form["1"];
                    (data as TourDestination).tenDD = Request.Form["2"];
                    (data as TourDestination).pic = Request.Form["3"];
                    (data as TourDestination).near = Request.Form["4"];
                    (data as TourDestination).countHomeStay = Int32.Parse(Request.Form["5"]);
                    (data as TourDestination).countTaxi = Int32.Parse(Request.Form["6"]);
                    DeleteTourDestination(data as TourDestination);
                    data = context.Database.SqlQuery<TourDestination>("select * from " + tableName).ToList();
                    break;
                case "Trip":
                    data = new Trip();
                    (data as Trip).maCD = Request.Form["0"];
                    (data as Trip).maDDStart = Request.Form["1"];
                    (data as Trip).maDDEnd = Request.Form["2"];
                    (data as Trip).dayStrat = DateTime.Parse(Request.Form["3"]);
                    (data as Trip).pic = Request.Form["4"];
                    (data as Trip).note = Request.Form["5"];
                    data = context.Database.SqlQuery<Trip>("select * from " + tableName).ToList();
                    break;
                case "WishList":
                    data = new WishList();
                    (data as WishList).maWL = Request.Form["0"];
                    (data as WishList).username = Request.Form["1"];
                    (data as WishList).note = Request.Form["2"];
                    DeleteWishList(data as WishList);
                    data = context.Database.SqlQuery<WishList>("select * from " + tableName).ToList();
                    break;
                default:
                    data = null;
                    break;
            }
            ViewBag.colName = context.Database.SqlQuery<colName>("select * from colName where TABLE_NAME = '" + tableName + "'").ToList();
            ViewBag.tableName = tableName;
            return PartialView("_TableDB", data);
        }

        void addBaiThi(BaiThi data)
        {
            if (data.maBaiThi != null)
            {
                if(db.BaiThis.Find(data.maBaiThi) == null)
                {
                    db.BaiThis.Attach(data);
                    db.BaiThis.Add(data);
                }
            }
        }
        void addBoMon(BoMon data)
        {
            if(data.maBM != null)
            {
                if(db.BoMons.Find(data.maBM) == null)
                {
                    if(db.GiangViens.Find(data.maTruongBM) != null)
                    {
                        db.BoMons.Attach(data);
                        db.BoMons.Add(data);
                    }
                }
            }
        }
    }
}
}