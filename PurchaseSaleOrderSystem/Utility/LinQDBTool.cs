using PurchaseSaleOrderSystem.Models;
using PurchaseSaleOrderSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchaseSaleOrderSystem.Utility
{
    public class LinQDBTool
    {
        public IEnumerable<PurchaseOrderListModel> GetPurchaseOrder()
        {
            using (var context = new PSOrderSystemContext())
            {
                var query =
                         from purchaseorders in context.PurchaseOrders
                         where purchaseorders.purchaseorder_remover == null
                         orderby purchaseorders.purchaseorder_date descending
                         group purchaseorders by new
                         {
                             purchaseorders.purchaseorder_orderid,
                             purchaseorders.purchaseorder_date,
                         }
                         into p
                         select new
                         {
                             Purchaseorder_orderid = p.Key.purchaseorder_orderid,
                             Purchaseorder_pid = p.Count(),
                             Purchaseorder_productnum = p.Sum(o => o.purchaseorder_productnum),
                             Purchaseorder_date = p.Key.purchaseorder_date,
                             Purchaseorder_totalcost = p.Sum(o => o.purchaseorder_totalcost)
                         };
                var result = query.ToList();
                List<PurchaseOrderListModel> lastresult = new List<PurchaseOrderListModel>();
                foreach (var item in result)
                {
                    PurchaseOrderListModel Temp = new PurchaseOrderListModel()
                    {
                        PurchaseOrderID = item.Purchaseorder_orderid.ToString(),
                        PurchaseOrder_PID = item.Purchaseorder_pid.ToString(),
                        ProductNum = item.Purchaseorder_productnum,
                        PurchaseDate = item.Purchaseorder_date,
                        PurchaseOrderCost = item.Purchaseorder_totalcost
                    };
                    lastresult.Add(Temp);
                }
                //TotalPage = (lastresult.Count / PageSize) + 1;
                //return lastresult.Skip(PageSize * (CurrentPage - 1)).Take(PageSize);
                return lastresult;
            }
        }

        public void DelPurchaseOrder(List<string> delpur)
        {
            using (var context = new PSOrderSystemContext())
            {

                foreach (var item in delpur)
                {
                    var deitem = context.PurchaseOrders.Where(obj => obj.purchaseorder_orderid == item).ToArray();
                    foreach (var item2 in deitem)
                    {
                        context.PurchaseOrders.Remove(item2); //一次移除一筆
                    }
                }
                context.SaveChanges();
            }
        }

        public List<string> GetPL()
        {
            using (var context = new PSOrderSystemContext())
            {
                var pl = from products in context.Products
                         orderby products.product_id
                         select new
                         {
                             Product_Name = products.product_name,
                         };
                List<string> ProductList = new List<string>();
                foreach (var item in pl.ToList())
                {
                    ProductList.Add(item.Product_Name);
                }
                return ProductList;
            }
        }

        public int GetPrice(string ProductName)
        {
            using (var context = new PSOrderSystemContext())
            {
                var pr = from products in context.Products
                         where products.product_name == ProductName
                         select new
                         {
                             ProductPrice = products.product_price,
                         };
                return Convert.ToInt32(pr.FirstOrDefault().ProductPrice);
            }
        }

        public string GetPurchaseDate(string PID)
        {
            using (var context = new PSOrderSystemContext())
            {
                var date = from purchase in context.PurchaseOrders
                           where purchase.purchaseorder_orderid == PID
                           select purchase.purchaseorder_date;

                return date.FirstOrDefault().ToString("yyyy-MM-dd HH:mm");
            }
        }

        public string GetProductID(string ProductName)
        {
            using (var context = new PSOrderSystemContext())
            {
                var pid = from products in context.Products
                          where products.product_name == ProductName
                          select products.product_id;

                return pid.FirstOrDefault().ToString();
            }
        }

        public List<OrderView> GetOrder(string PurchaseID, out decimal FullPrice, out int TotalPage, int currentPage = 1, int pageSize = 10)
        {
            using (var context = new PSOrderSystemContext())
            {
                var orderslist =
                     from orders in context.PurchaseOrders
                     join prouducts in context.Products on orders.purchaseorder_producid equals prouducts.product_id
                     where orders.purchaseorder_orderid == PurchaseID && orders.purchaseorder_remover == null
                     orderby orders.purchaseorder_pid descending
                     select new OrderView
                     {
                         PO_OrderID = orders.purchaseorder_pid,
                         Product_Pid = orders.purchaseorder_producid,
                         Product_Name = prouducts.product_name,
                         Product_Num = orders.purchaseorder_productnum,
                         Product_Price = prouducts.product_price
                     };

                List<OrderView> result = orderslist.ToList();

                FullPrice = 0;
                foreach (var item in result)
                {
                    FullPrice += item.TotalPrice;
                }
                TotalPage = (result.Count / pageSize) + 1;
                return result;
            }
        }

        public void DelOrderProduct(List<string> id)
        {
            using (var context = new PSOrderSystemContext())
            {
                List<OrderView> TempOrder = new List<OrderView>();
                foreach (var item in PStaticModel.NowProduct)
                {
                    TempOrder.Add(item);
                }

                foreach (var item in id)
                {
                    int idtemp = Convert.ToInt32(item);
                    if (idtemp > 0)
                    {
                        var delorder =
                            context.PurchaseOrders.Where(obj => obj.purchaseorder_pid == idtemp && obj.purchaseorder_remover == null).FirstOrDefault();
                        if (delorder != null)
                        {
                            delorder.purchaseorder_remover = "鍾學武";
                            delorder.purchaseorder_removedate = DateTime.Now;
                            var prodprice =
                                context.Products.Where(obj => obj.product_id == delorder.purchaseorder_producid).FirstOrDefault();

                            PStaticModel.ProductTotal -= prodprice.product_price * delorder.purchaseorder_productnum;
                            PStaticModel.NowProduct.Remove(PStaticModel.NowProduct.Where(obj => obj.PO_OrderID == idtemp).FirstOrDefault());
                        }

                    }
                    else
                    {
                        PStaticModel.NowProduct.Remove(PStaticModel.NowProduct.Where(obj => obj.PO_OrderID == idtemp).FirstOrDefault());
                    }
                }
                context.SaveChanges();
            }
        }

        public void InsertPurchase(string pur, DateTime purdate, decimal assests, List<OrderView> orders)
        {
            LoginInfo info = HttpContext.Current.Session["IsLogined"] as LoginInfo;
            using (var context = new PSOrderSystemContext())
            {
                var updpurchase =
                         context.PurchaseOrders.Where(obj => obj.purchaseorder_orderid == pur && obj.purchaseorder_remover == null).FirstOrDefault();
                if (updpurchase == null)
                {
                    foreach (var item in orders)
                    {
                        PurchaseOrder addpur = new PurchaseOrder()
                        {
                            purchaseorder_orderid = pur,
                            purchaseorder_userid = info.UserID,
                            purchaseorder_date = purdate,
                            purchaseorder_producid = item.Product_Pid,
                            purchaseorder_productnum = item.Product_Num,
                            purchaseorder_totalcost = (item.Product_Price * item.Product_Num),
                            purchaseorder_creator = "Daniel",
                            purchaseorder_createdate = DateTime.Now
                        };
                        context.PurchaseOrders.Add(addpur);
                        context.SaveChanges();
                    }
                }
                else
                {
                    return;
                }
            }
        }

        public void UpdatePurchase(string pur, DateTime purdate, decimal assests, List<OrderView> orders)
        {
            LoginInfo info = HttpContext.Current.Session["IsLogined"] as LoginInfo;
            using (var context = new PSOrderSystemContext())
            {
                var updpurchase =
                         context.PurchaseOrders.Where(obj => obj.purchaseorder_orderid == pur && obj.purchaseorder_remover == null).FirstOrDefault();
                decimal lastassets = assests + updpurchase.purchaseorder_totalcost;
                if (updpurchase != null)
                {
                    foreach (var item in orders)
                    {
                        var updorder =
                            context.PurchaseOrders.Where(obj => obj.purchaseorder_pid == item.PO_OrderID && obj.purchaseorder_remover == null).FirstOrDefault();
                        if (updorder == null)
                        {
                            PurchaseOrder addpur = new PurchaseOrder()
                            {
                                purchaseorder_orderid = pur,
                                purchaseorder_userid = info.UserID,
                                purchaseorder_date = purdate,
                                purchaseorder_producid = item.Product_Pid,
                                purchaseorder_productnum = item.Product_Num,
                                purchaseorder_totalcost = (item.Product_Price * item.Product_Num),
                                purchaseorder_creator = "Daniel",
                                purchaseorder_createdate = DateTime.Now
                            };
                            context.PurchaseOrders.Add(addpur);
                            context.SaveChanges();
                        }
                    }
                }
                else
                {
                    return;
                }
            }
        }
    }
}