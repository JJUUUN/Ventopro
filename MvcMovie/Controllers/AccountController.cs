﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MvcMovie.MVC6.Controllers
{
    public class AccountController : Controller
    {




        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            //ID, 비밀번호 - 필수
            if (ModelState.IsValid)
            {
                using (var db = new AspnetNoteDbContext())
                {
                    //Linq - 메서드 체이닝
                    // => :  A Go to B

                    var user = db.Users
                        .FirstOrDefault(u => u.UserId.Equals(model.UserId)
                        && u.UserPassword.Equals(model.UserPassword));
                    if (user != null)
                    {
                        //로그인에 성공했을때 
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY",
                                                     user.UserNo);
                        return RedirectToAction("Index", "Home"); //로그인 성공 페이지 이동
                    }

                }
                //로그인에 실패했을 때 
                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");


            }
            return View(model);
        }

        public IActionResult Logout()
        {
            //HttpContext.Session.Clear();
            HttpContext.Session.Remove("USER_LOGIN_KEY");
            return RedirectToAction("Index", "Home");

        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>

        public IActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 회원가입 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {

                using (var db = new AspnetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }



    }
}