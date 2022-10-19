using MailKit.Net.Smtp;
using Messenger.core;
using Messenger.core.Data;
using Messenger.core.DTO;
using Messenger.core.Repoisitory;
using Messenger.core.Service;
using Microsoft.AspNetCore.Hosting;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messenger.infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository UserRepository;
        private readonly ILoginService LoginService;
        private readonly IWebHostEnvironment webHostEnvironmet;
        private static bool falg = true;

        public UserService(IUserRepository UserRepository, ILoginService LoginService, IWebHostEnvironment webHostEnvironmet)
        {
            this.UserRepository = UserRepository;
            this.webHostEnvironmet = webHostEnvironmet;
            this.LoginService = LoginService;
        }

        public bool DeleteUser(int UserId)
        {
            return UserRepository.DeleteUser(UserId);
        }

        public List<Userr> GetAllUsers()
        {
            return UserRepository.GetAllUsers();
        }

        public Userr GetUserById(int userId)
        {
            return UserRepository.GetUserById(userId);
        }

        public Userr GetUserByUserName(string userName)
        {
            return UserRepository.GetUserByUserName(userName);
        }

        public bool InsertUser(UserLogDTO userLog)
        {
            Thread thr = new Thread(() => addUserLogData(userLog));
            thr.Start();
            return UserRepository.InsertUser(userLog);
        }

        public bool UpdateUser(Userr user)
        {
            return UserRepository.UpdateUser(user);
        }

        public void addUserLogData(UserLogDTO userLog)
        {
            Random r = new Random();
            int rInt = r.Next(1000, 100000);
            userLog.verificationCode = rInt.ToString();
            Thread sendEmail = new Thread(() => sendEmailCode(userLog));
            DateTime sendEmailTreadStart = DateTime.Now;
            Console.WriteLine("sendEmailTreadStart: " + sendEmailTreadStart);
            sendEmail.Start();


            Thread addUser = new Thread(() => LoginService.InsertLog(userLog));
            DateTime addUserTreadStart = DateTime.Now;
            Console.WriteLine("addUserTreadStart: " + addUserTreadStart);
            addUser.Start();

            Thread removeCodee = new Thread(removeCode);
            DateTime removeCodeTreadStart = DateTime.Now;
            Console.WriteLine("removeCodeTreadStart: " + removeCodeTreadStart);
            removeCodee.Start();


        }

        public bool reSendVerificationCode(UserLogDTO userLog)
        {

            Random r = new Random();
            int rInt = r.Next(1000, 100000);
            userLog.verificationCode = rInt.ToString();
            Thread sendEmail = new Thread(() => sendEmailCode(userLog));
            DateTime sendEmailTreadStart = DateTime.Now;
            Console.WriteLine("sendEmailTreadStart: " + sendEmailTreadStart);
            sendEmail.Start();


            Thread addUser = new Thread(() => LoginService.UpdateVerificationCode(userLog));
            DateTime addUserTreadStart = DateTime.Now;
            Console.WriteLine("addUserTreadStart: " + addUserTreadStart);
            addUser.Start();

            Thread removeCodee = new Thread(removeCode);
            DateTime removeCodeTreadStart = DateTime.Now;
            Console.WriteLine("removeCodeTreadStart: " + removeCodeTreadStart);
            removeCodee.Start();


            return true;
        }



            void sendEmailCode(UserLogDTO userLog)
        {
            MimeMessage obj = new MimeMessage();
            MailboxAddress emailfrom = new MailboxAddress("user", "teeeeeestemail@gmail.com");
            MailboxAddress emailto = new MailboxAddress(userLog.userName, userLog.Email);

            obj.From.Add(emailfrom);
            obj.To.Add(emailto);
            obj.Subject = "verificationCode";
            BodyBuilder bb = new BodyBuilder();
            //onclick="window.location.href='https://w3docs.com';">
            //bb.HtmlBody = "<html>" + "<button window.location.href="+"'"+"https://localhost:44353/api/Authen/verificationCode/" + api_LoginAuth.verificationCode+"';"+">"+ 
            //    "verificationCode" + "</button>" + "</html>";
            //bb.HtmlBody = "<html>" + "<h1>" + userLog.verificationCode + "</h1>" + "</html>";
            bb.HtmlBody = Email(userLog.verificationCode);

            //< a href = 'http://www.example.com' ></ a > "
            ///bb.HtmlBody = "<html>" + "<a href = " + "https://localhost:44318/api/user/ConfirmEmail/" + userLog.verificationCode + ">" + "</a>" + "</html>";
            obj.Body = bb.ToMessageBody();

            SmtpClient emailClinet = new SmtpClient();
            emailClinet.Connect("smtp.gmail.com", 465, true);
            emailClinet.Authenticate("deia3.123.ds@gmail.com", "lpuesonkyibstcqt"); 
            emailClinet.Send(obj);

            emailClinet.Disconnect(true);
            emailClinet.Dispose();

            DateTime sendEmailTreadEnd = DateTime.Now;
            Console.WriteLine("sendEmailTreadEnd: " + sendEmailTreadEnd);
        }

        void removeCode()
        {
            Thread.Sleep(300000);
            //300000
            //Task.Delay(20000);
            if (falg)
            {
                Login log = new Login();
                log.verificationCode = null;
                log.User_Id = Global.userLog.UserId;
                log.Email = Global.userLog.Email;
                log.Password = Global.userLog.Password;
                log.userName = Global.userLog.userName;

                LoginService.UpdateLog(log);
            }

            DateTime removeCodeTreadEnd = DateTime.Now;
            Console.WriteLine("removeCodeTreadEnd: " + removeCodeTreadEnd);

        }
        public string confirmEmail(string code)
        {
            if (code.Equals(Global.userLog.verificationCode))
            {

                Login log = new Login();
                log.verificationCode = "1";
                log.User_Id = Global.userLog.UserId;
                log.Email = Global.userLog.Email;
                log.Password = Global.userLog.Password;
                log.userName = Global.userLog.userName;

                falg = false;

                LoginService.UpdateLog(log);

                return "email confirmed";
            }
            return "false";
        }

        public bool IsBlocked(Userr user)
        {
            return UserRepository.IsBlocked(user);

        }
        public bool UnBlock(Userr user)
        {
            return UserRepository.UnBlock(user);

        }

        public bool activationChange(Userr user)
        {
            return UserRepository.activationChange(user);
        }


        public string Email(string code)
        {
            var pathToFile = "C:\\Users\\yazan\\source\\repos\\MessengerAPI\\MessengerAPI\\EmailView\\Email\\EEmail.html";


            var subject = "Confirm Account Registration";
            string HtmlBody = "";
            using(StreamReader streamReader= System.IO.File.OpenText(pathToFile))
            {
                HtmlBody = streamReader.ReadToEnd();
            }

            string massageBody = string.Format(HtmlBody,string.Format(code), "https://themes.pixelstrap.com/chitchat/assets/images/start-up.png");

            return massageBody;
        }
    }
}
