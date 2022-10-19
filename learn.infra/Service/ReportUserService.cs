using learn.core.Data;
using learn.core.Repoisitory;
using learn.core.Service;
using Messenger.core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using MailKit.Net.Smtp;
using MimeKit;
using Messenger.core.Repoisitory;
using Messenger.core.Data;
using System.IO;

namespace learn.infra.Service
{
    public class ReportUserService : IReportUserService
    {
        private readonly IReportUserRepoisitory reportUserRepoisitory;
        private readonly ILoginRepository loginRepository;

        public ReportUserService(IReportUserRepoisitory reportUserRepoisitory, ILoginRepository loginRepository)
        {
            this.reportUserRepoisitory = reportUserRepoisitory;
            this.loginRepository = loginRepository;
        }

        public bool acceptingReportUser(int id)
        {
            ReportUser rep = reportUserRepoisitory.GetReportUsersById(id);
            var log = loginRepository.getById(rep.UserReportedId);
            sendEmailCode(log);
            return reportUserRepoisitory.acceptingReportUser(id);
        }

        public bool DeleteReportUser(int id)
        {
            return reportUserRepoisitory.DeleteReportUser(id);
        }

        public List<ReportUser> GetReportUsers()
        {
            return reportUserRepoisitory.GetReportUsers();
        }

        public ReportUser GetReportUsersById(int id)
        {
            return reportUserRepoisitory.GetReportUsersById(id);
        }

        public GetAllReportByUserName GetReportUsersByName(string name)

        {
            return reportUserRepoisitory.GetReportUsersByName(name);
        }

        public bool InsertReportUser(ReportUser report)
        {
            return reportUserRepoisitory.InsertReportUser(report);
        }

        public bool rejectreport(int id)
        {
            return reportUserRepoisitory.rejectreport(id);
        }

        public bool UpdateReportUser(ReportUser report)
        {
            return reportUserRepoisitory.UpdateReportUser(report);
        }

        void sendEmailCode(Login log)
        {
            MimeMessage obj = new MimeMessage();
            MailboxAddress emailfrom = new MailboxAddress("user", "teeeeeestemail@gmail.com");
            MailboxAddress emailto = new MailboxAddress(log.userName, log.Email);

            obj.From.Add(emailfrom);
            obj.To.Add(emailto);
            obj.Subject = "You Are Reported";
            BodyBuilder bb = new BodyBuilder();
            //onclick="window.location.href='https://w3docs.com';">
            //bb.HtmlBody = "<html>" + "<button window.location.href="+"'"+"https://localhost:44353/api/Authen/verificationCode/" + api_LoginAuth.verificationCode+"';"+">"+ 
            //    "verificationCode" + "</button>" + "</html>";
            //bb.HtmlBody = "<html>" + "<h1>" + "Our users reporeted you please read chatting rolse again and be carful" + "</h1>" + "</html>";
            bb.HtmlBody = Email();

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

        public string Email()
        {
            var pathToFile = "C:\\Users\\yazan\\source\\repos\\MessengerAPI\\MessengerAPI\\EmailView\\Email\\EEmail.html";


            string HtmlBody = "";
            using (StreamReader streamReader = System.IO.File.OpenText(pathToFile))
            {
                HtmlBody = streamReader.ReadToEnd();
            }

            string massageBody = string.Format(HtmlBody, "Our users reporeted you \n please readchatting rolse again and be carful" , "https://icones.pro/wp-content/uploads/2021/10/icone-de-rapport-avec-point-d-exclamation-rouge.png");

            return massageBody;
        }

        public List<GetAllReportByUserName> GetAllByusername()
        {
            return reportUserRepoisitory.GetAllByusername();
        }
    }
}