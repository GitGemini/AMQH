using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AMQH.Models.BookModel;
using System.Web.Security;
using AMQH.Views.Models.BookModel;
using System.Data.Common;

namespace AMQH.Controllers
{
    public class UserController : Controller
    {
        private BookDb db = new BookDb();
       
        // GET: User
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="strSource">需要加密的明文</param>
        /// <returns>返回32位加密结果</returns>
        public static string Get_MD5(string strSource, string sEncode)
        {
            //new 
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            //获取密文字节数组
            byte[] bytResult = md5.ComputeHash(System.Text.Encoding.GetEncoding(sEncode).GetBytes(strSource));
            //转换成字符串，并取9到25位 
            //string strResult = BitConverter.ToString(bytResult, 4, 8);  
            //转换成字符串，32位
            string strResult = BitConverter.ToString(bytResult);
            //BitConverter转换出来的字符串会在每个字符中间产生一个分隔符，需要去除掉 
            strResult = strResult.Replace("-", "");
            return strResult.ToLower();
        }
        /// <summary>
        /// 用户注册页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Register([Bind(Exclude = "RegisterOn")]User user)
        {
            var chk_member = db.User.Where(p => p.Phone
                == user.Phone).FirstOrDefault();
            if (chk_member != null)
            {
                ModelState.AddModelError("Phone",
                    "该手机号已被注册");
            }
            if (ModelState.IsValid)
            {
                //user.Password = Get_MD5(user.Password, "utf-8");
                user.Password = user.Password;
                if (user.UserIcon == null)
                {
                    user.UserIcon = "default.png";
                }
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        /// <summary>
        /// 登陆页面
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        public ActionResult Login(string url)
        {
            ViewBag.url = url;
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(string phone, string password)
        {
            //password = Get_MD5(password, "utf-8");
            if (ValidateUser(phone, password))
            {
                FormsAuthentication.SetAuthCookie(phone, false);
                Session["userPhone"] = phone;
               
                //TempData["userPhone"] = phone;                            
                return RedirectToAction("Index", "Home");                                                 
            }
            ModelState.AddModelError("", "你输入的帐号或密码错误");
            return View();
        }
        /// <summary>
        /// 验证用户登录时输入的手机号和密码是否与数据库中的匹配
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ValidateUser(string phone, string password)
        {
           
            var member = (from p in db.User
                          where p.Phone == phone &&
                          p.Password == password
                          select p).FirstOrDefault();
            if(member!=null)
            {
                //TempData["userName"] = member.Name;
                if(member.Name.Equals(""))
                {
                    Session["userName"] = "用户名";
                }else
                {
                   Session["userId"] = member.Id;
                   Session["userName"] = member.Name;
                   Session["userIcon"] = member.UserIcon;
                }
                
            }
            return member != null;
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <returns></returns>
        public ActionResult Logout()
        {
            //清除窗体验证的cookie
            FormsAuthentication.SignOut();

            //清除所有曾经写入过的Session
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult ShowInfo()
        {
            int id;
            if (Session["userId"] == null)
            {
                return RedirectToAction("Login", "User"); 
            }
            else
            {
                id = (int)Session["userId"];
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View(user);
        }


        /// <summary>
        /// 编辑个人信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
           
                db.User.Attach(user);
                //user1.Name = user.Name;
                //user1.Nickname = user.Nickname;
                //user1.Email = user.Email;
                //user1.Gender = user.Gender;
                db.Entry(user).Property("Name").IsModified = true;
                db.Entry(user).Property("Nickname").IsModified = true;
                db.Entry(user).Property("Email").IsModified = true;
                db.Entry(user).Property("Gender").IsModified = true;
                //db.Entry(user).State = EntityState.Modified;
               
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            
           // return View(user);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.User.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        /// <summary>
        /// 忘记
        /// </summary>
        /// <returns></returns>
        public ActionResult ChangePassword()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passwordViewModel"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel passwordViewModel)
        {
           
            if (ModelState.IsValid)
            {
                if (!passwordViewModel.Password.Equals(passwordViewModel.ConfirmPassword))
                {
                    ModelState.AddModelError("", "两次密码不一致");
                }else
                {
                    var user = db.User.Find(Session["userId"]);
                    passwordViewModel.Password = Get_MD5(passwordViewModel.Password, "utf-8");
                    passwordViewModel.OriginalPassword = Get_MD5(passwordViewModel.OriginalPassword, "utf-8");
                    if (user.Password == (passwordViewModel.OriginalPassword))
                    {
                        db.User.Attach(user);
                        user.Password = passwordViewModel.Password;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                        ModelState.AddModelError("", "修改密码成功");
                    }
                    else
                        ModelState.AddModelError("", "原密码错误");
                }
                
            }

            return View(passwordViewModel);
        }
        /// <summary>
        /// 忘记
        /// </summary>
        /// <returns></returns>
        public ActionResult ForgetPassword()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="passwordViewModel"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ForgetPassword(ForgetPassword passwordViewModel)
        {

            if (ModelState.IsValid)
            {
                if (!passwordViewModel.Password.Equals(passwordViewModel.ConfirmPassword))
                {
                    ModelState.AddModelError("", "两次密码不一致");
                }
                else
                {
                    var user = db.User.Where(p => p.Phone
                    == passwordViewModel.Phone).FirstOrDefault();
                    if(user == null)
                    {
                        ModelState.AddModelError("", "该手机号尚未被注册");
                    }
                    else
                    {
                        passwordViewModel.Password = Get_MD5(passwordViewModel.Password, "utf-8");
                        db.User.Attach(user);
                        user.Password = passwordViewModel.Password;
                        //db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                        ModelState.AddModelError("", "修改密码成功");
                        return RedirectToAction("Login", "User");
                    }
                   
                }

            }

            return View(passwordViewModel);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
