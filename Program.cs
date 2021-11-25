using HtmlAgilityPack;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using MailKit.Net.Smtp;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GovernmentBidding
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var _db = new ApplicationDbContext())
            {
                int pageIndex = 1;
                bool all = true;
                int count = 0;
                List<string> caseNumList = _db.CaseInfoes.Select(x=>x.CaseNumber).ToList();
                while (all)
                {
                    string url = $"https://web.pcc.gov.tw/tps/pss/tender.do?searchMode=common&searchType=basic&method=search&isSpdt=&pageIndex={pageIndex}";
                    string htmlString = GetWebContent(url);

                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.LoadHtml(htmlString);
                    var tableNodes = htmlDoc.DocumentNode.SelectSingleNode("/html[1]/body[1]/table[1]/tr[2]/td[2]/table[1]/tr[5]/td[1]/table[1]/tr[3]/td[1]/table[1]/tbody[1]/tr[1]/td[1]/div[1]/table[1]");
                    if (rmLineUp(tableNodes.SelectSingleNode("./tr[2]")) == "無符合條件資料")
                    {
                        all = false;
                        break;
                    }
                    var trNodes = tableNodes.SelectNodes("./tr");
                    foreach (HtmlNode trNode in trNodes)
                    {
                        //今日比對
                        DateTime dateTime = DateTime.Parse(rmLineUp(trNode.SelectSingleNode("//td[7]"))).AddYears(1911);
                        DateTime today = Convert.ToDateTime(DateTime.Today.ToString("d"));
                        if (dateTime.CompareTo(today) != 0)
                        {
                            all = false;
                            break;
                        }
                        //關鍵字比對 目前只比對案件名稱
                        var tdNodes = trNode.SelectNodes("./td[3]/a");
                        if (tdNodes == null) continue;
                        foreach (HtmlNode tdNode in tdNodes)
                        {
                            string keyWord = ConfigurationManager.AppSettings["keyWord"];
                            bool hasKeyWord = false;
                            if (keyWord == "" || !tdNode.Attributes["title"].Value.Contains(keyWord)) break;
                            string caseUrl = "https://web.pcc.gov.tw/tps" + tdNode.Attributes["href"].Value.Replace("..", "");
                            string caseHtmlString = GetWebContent(caseUrl);
                            var t = Task.Run(async delegate
                            {
                                await Task.Delay(1000);
                                return 42;
                            });
                            t.Wait();
                            HtmlDocument caseHtmlDoc = new HtmlDocument();
                            caseHtmlDoc.LoadHtml(caseHtmlString);
                            var caseTrNodes = caseHtmlDoc.DocumentNode.SelectNodes("/html[1]/body[1]/table[1]/tr[2]/td[2]/table[1]/tr[1]/td[2]/table[1]/tr[3]/td[1]/table[1]/tr[1]/td[1]/div[2]/table[1]/tr");

                            bool isSave = true;
                            CaseInfo caseInfo = new CaseInfo();
                            if (caseTrNodes == null) break;
                            foreach (HtmlNode tr in caseTrNodes)
                            {
                                switch (nodeThTostring(tr))
                                {
                                    case "機關名稱":
                                        caseInfo.AgencyName = nodeTdTostring(tr);
                                        //if (keyWord == "" || !caseInfo.AgencyName.Contains(keyWord)) isSave = false;
                                        break;
                                    case "標案案號":
                                        caseInfo.CaseNumber = nodeTdTostring(tr);
                                            if (caseNumList.Contains(caseInfo.CaseNumber))
                                            {
                                                all = false;
                                                isSave = false;
                                            }
                                        break;
                                    case "標案名稱":
                                        caseInfo.CaseName = nodeTdTostring(tr);
                                        break;
                                    case "新增公告傳輸次數":
                                        caseInfo.PublishCount = int.Parse(nodeTdTostring(tr));
                                        break;
                                    case "招標方式":
                                        caseInfo.TenderMethod = nodeTdTostring(tr);
                                        break;
                                    case "標的分類":
                                        caseInfo.CaseClassify = nodeTdTostring(tr);
                                        break;
                                    case "公告日":
                                        caseInfo.PublishDate = DateTime.Parse(nodeTdTostring(tr)).AddYears(1911);
                                        //if (DateTime.Compare(caseInfo.PublishDate, DateTime.Today) != 0) isSave = false;
                                        break;
                                    case "截止投標":
                                        caseInfo.EndDate = DateTime.Parse(nodeTdTostring(tr)).AddYears(1911);
                                        break;
                                    case "預算金額":
                                        caseInfo.Budget = int.Parse(nodeTdTostring(tr).Replace("元", "").Replace(",", ""));
                                        break;
                                }
                                if (!isSave) break;
                            }
                            if (isSave)
                            {
                                _db.CaseInfoes.Add(caseInfo);
                                _db.SaveChanges();
                                count++;
                            }

                        }
                    }
                    Console.WriteLine($"第{pageIndex}頁比對完");
                    pageIndex++;
                }
                
                Console.WriteLine($"全部比對完畢,一共有{count}筆");
                string htmlBody = $"今日{DateTime.Today.ToString("d")}比對完畢，一共有更新{count}筆";
                if(count>0) SendMail(htmlBody);
                Console.WriteLine("執行完畢");
                Console.ReadLine();

            }

        }
        private static string GetWebContent(string Url)
        {
            var uri = new Uri(Url);
            var request = WebRequest.Create(Url) as HttpWebRequest;
            WebClient wc = new WebClient();
            //REF: https://stackoverflow.com/a/39534068/288936
            ServicePointManager.SecurityProtocol =
                SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            string res = wc.DownloadString(Url);
            // If required by the server, set the credentials.
            request.UserAgent = "PostmanRuntime/7.26.5";
            request.Accept = "*/*";
            request.Credentials = CredentialCache.DefaultCredentials;
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            // 重點是修改這行
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                                   SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();
            return responseFromServer;
        }
        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
        public static string SendMail(string htmlbody)
        {
            string errMsg = "";
            string keyWord = ConfigurationManager.AppSettings["keyWord"];

            string fromAddress = ConfigurationManager.AppSettings["gmailAccount"];
            string fromName = "招標通知";

            string title = $"今日招標通知-關鍵字:{keyWord}";

            string toAddress = ConfigurationManager.AppSettings["toAccount"];
            string toName = "";

            string serverAddress = "smtp.gmail.com";
            int port = 587;
            string mailAccount = ConfigurationManager.AppSettings["gmailAccount"];
            string mailPassword = ConfigurationManager.AppSettings["gmailPassword"];


            //建立建立郵件
            MimeMessage mail = new MimeMessage();
            // 添加寄件者
            mail.From.Add(new MailboxAddress(fromName, fromAddress));
            // 添加收件者
            mail.To.Add(new MailboxAddress(toName, toAddress.Trim()));
            // 設定郵件標題
            mail.Subject = title;
            //使用 BodyBuilder 建立郵件內容
            BodyBuilder body = new BodyBuilder();
            //設定文字內容
            //body.TextBody = $"今日新增的招標案有{}筆";
            // 設定 HTML 內容
            body.HtmlBody = htmlbody;
            // 設定附件
            //body.Attachments.Add("檔案路徑");
            // 設定郵件內容
            mail.Body = body.ToMessageBody();

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                //client.CheckCertificateRevocation = false;
                //SSL加密
                bool useSsl = false;
                //連線Mail Server
                client.Connect(serverAddress, port, useSsl);
                //帳號驗證
                client.Authenticate(mailAccount, mailPassword);
                //送出信件
                client.Send(mail);
                //中斷連線
                client.Disconnect(true);
            }
            return errMsg;
        }
        private static string nodeTdTostring(HtmlNode node)
        {
            return rmLineUp(chooseLastTd(node));
        }
        private static string nodeThTostring(HtmlNode node)
        {
            node = node.SelectSingleNode("./th");
            return rmLineUp(node);
        }
        private static string rmLineUp(HtmlNode node)
        {
            string result = "";
            if (node == null) return result;
            result = node.InnerText;

            result = result.Replace("\t", "");
            result = result.Replace("\r", "");
            result = result.Replace("\n", "");
            return result;
        }
        private static HtmlNode chooseLastTd(HtmlNode node)
        {
            return node.SelectSingleNode("./td[last()]");
        }
    }
}
