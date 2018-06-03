using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInternetShopEx2
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Разрешить/Запретить покупку товара
        /// </summary>
        private void BlockUnblockToBuy()
        {
            if (Session["user"] == null) { ViewBag.blockUnBlockBuy = "show"; }
            else                         { ViewBag.blockUnBlockBuy = "hide"; }
        }
        /// <summary>
        /// Скрыть/Отобразить корзину
        /// </summary>
        private void CartDisplayHide()
        {
            if (Session["select"] == null) { ViewBag.cartBlockUnblock = "cartCountHide"; }
            else                           { ViewBag.cartBlockUnblock = "cartCount"; }
        }
        /// <summary>
        /// Колличество товаров в корзине
        /// </summary>
        /// <returns></returns>
        private int CountSelectedGoods()
        {
            int countSelGoods = 0;
            if (Session["select"] != null) { countSelGoods = (int)Session["select"]; }
            return countSelGoods;
        }
        /// <summary>
        /// Очистить сессию, отобразить ссылку на регистрацию
        /// </summary>
        private void SignOut()
        {
            ViewBag.usershowhide = "hide";
            ViewBag.showHideSignOutLink = "hide";
            ViewBag.showHideSignInLink = "myAccount";
            Session.Clear();
        }
        /// <summary>
        /// Проверить наличие товара в корзине
        /// </summary>
        private void CheckAvailabillity()
        {
            switch (Session["select"])
            {
                case null:
                    ViewBag.selGoods = "display";
                    ViewBag.displayTotal = "hide";
                    break;
                default:
                    ViewBag.selGoods = "hide";
                    ViewBag.displayTotal = "totalPrice";
                    break;
            }
        }
        /// <summary>
        /// Скрыть ссылку на регистрацию, отобразить ссылку на выход из сессии 
        /// </summary>
        private void CheckUserSession()
        {
            switch (Session["user"])
            {
                case null:
                    ViewBag.usershowhide = "hide";
                    ViewBag.showHideSignInLink = "myAccount";
                    ViewBag.showHideSignOutLink = "hide";
                    break;
                default:
                    {
                        RegistrUser user = (RegistrUser)Session["user"];
                        ViewBag.user = user.Name;
                        ViewBag.usershowhide = "userShow";
                        ViewBag.showHideSignInLink = "hide";
                        ViewBag.showHideSignOutLink = "link";
                        break;
                    }
            }
        }
        /// <summary>
        /// Добавление товара в корзину
        /// </summary>
        /// <param name="selected"></param>
        /// <returns></returns>
        private GoodsList AddedGoodsToCart(GoodsList selected)
        {
            int count = 0;
            for (int i = 0; i < selected.AllGoods.Count; i++)
            {
                if (Request.Form[selected.Buttons[i].Name] != null)
                {
                    selected.Buttons[i].PressBtn = !selected.Buttons[i].PressBtn;

                }
                if (selected.Buttons[i].PressBtn)
                {
                    count++;
                }
                CartDisplayHide();
                Session["select"] = count;
            }
            return selected;
        }       
        
        public ActionResult Index()
        {          
            CartDisplayHide();
            BlockUnblockToBuy();         
            CheckUserSession();
            GoodsList AllGoodsList = new GoodsList(new List<Button>());
            AllGoodsList.AllGoods = new DAOImplements().LoadAllGoods();
            for (int i = 0; i < AllGoodsList.AllGoods.Count; i++)
            {
                AllGoodsList.Buttons.Add(new Button(i + "", false));
            }
            return View(AllGoodsList);
        }
        [HttpPost]
        public ActionResult Index(GoodsList Selected, string action)
        {
            CheckUserSession();
            CartDisplayHide();
            BlockUnblockToBuy();
            switch (action)
            {
                case "Desktop":
                    return View("Desktops", Selected);
                case "GraphicsCards":
                    return View("GraphicsCards", Selected);
                case "Laptops":
                    return View("GraphicsCards", Selected);
                case "Monitors":
                    return View("GraphicsCards", Selected);
                case "Networking":
                    return View("GraphicsCards", Selected);
                case "Virtual Reality":
                    return View("GraphicsCards", Selected);
                case "Accessories":
                    return View("GraphicsCards", Selected);
                case "Components":
                    return View("GraphicsCards", Selected);
                case "Sign out":
                    SignOut();
                    return RedirectToAction("Authorization", "Account");
            }
            return View(Selected);
        }

        public ActionResult Desktops()
        {
            BlockUnblockToBuy();
            CartDisplayHide();
            CheckUserSession();
            CheckAvailabillity();
            return View();
        }
      
        [HttpPost]
        public ActionResult Desktops(GoodsList deskList, string action)
        {
            BlockUnblockToBuy();
            CartDisplayHide();
            CheckUserSession();
            CheckAvailabillity();
            switch (action)
            {
                case "Cart":
                    return View("ShoppingCart", deskList);
                case "Sign out":
                    SignOut();
                    return RedirectToAction("Authorization", "Account");
                default:
                    {
                        AddedGoodsToCart(deskList);
                        return View(deskList);
                    }
            }          
        }
      

        public ActionResult GraphicsCards()
        {
            BlockUnblockToBuy();
            CartDisplayHide();
            CheckUserSession();
            CheckAvailabillity();
            return View();
        }

        [HttpPost]
        public ActionResult GraphicsCards(GoodsList Selected, string action)
        {       
            BlockUnblockToBuy();
            CartDisplayHide();
            CheckUserSession();
            CheckAvailabillity();
            switch (action)
            {
                case "Cart":
                    return View("ShoppingCart", Selected);
                case "Sign out":
                    SignOut();
                    return RedirectToAction("Authorization", "Account");
                default:
                    {
                        AddedGoodsToCart(Selected);
                        return View(Selected);
                    }                    
            }
        }
        public ActionResult ShoppingCart(GoodsList Selected)
        {         
            CartDisplayHide();
            CheckUserSession();
            CheckAvailabillity();
            return View(Selected);    
        }

        [HttpPost]
        public ActionResult ShoppingCart(GoodsList Selected, string action)
        {
            CheckUserSession();
            CartDisplayHide();
            CheckAvailabillity();
            switch (action)
            {
                case "Buy":
                    return View("PostView", Selected);
                case "Sign out":
                    SignOut();
                    return RedirectToAction("Authorization", "Account");
                case "Continue":
                    CheckUserSession();
                    CartDisplayHide();
                    return View("Index", Selected);
                default:
                    {
                        CheckUserSession();
                        CartDisplayHide();
                        AddedGoodsToCart(Selected);                      
                        return View(Selected);
                    }
            }
        }

        public ActionResult PostView()
        {           
            return View();
        }

        [HttpPost]
        public ActionResult PostView(GoodsList Selected)
        {
            return View(Selected);
        } 
    }
}