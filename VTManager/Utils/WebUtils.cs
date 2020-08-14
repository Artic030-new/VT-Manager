using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Utils
{
    class WebUtils
    {
        public static VTManagerDialog error_msg = new VTManagerDialog();

        public static HttpWebRequest runHttp(string script)
        {
            var request = (HttpWebRequest)WebRequest.Create(StringUtils.buildFileUrl(script));
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            return request;
        }
        public static void login(string l, string p)
        {
            try
            {
                const String AuthText = "!OK";
                var request = runHttp("vtmanager_login.php");
                var post = "btn_auth=True";
                post += "&login=" + l;
                post += "&password=" + EncodingUtils.encode(p);
                var dat = Encoding.ASCII.GetBytes(post);
                request.ContentLength = dat.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(dat, 0, dat.Length);
                }
                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                if (responseString.Contains(AuthText))
                {
                    AuthWindow.ThisWindow.Close();
                    MainMenuWindow mmw = new MainMenuWindow();
                    mmw.Show();
                }
                else
                {
                    error_msg.dialog_label.Content = "Ошибка";
                    error_msg.contained_info.Text = "Неверные данные (Логин/Пароль)";
                    error_msg.Show();
                }
            }
            catch (WebException ex)
            {
                error_msg.dialog_label.Content = "Ошибка";
                error_msg.contained_info.Text = "Сервер не отвечает";
                error_msg.Show();
            }
        }
    }
}
