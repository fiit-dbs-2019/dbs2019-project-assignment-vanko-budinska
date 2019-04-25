using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Json_into_sqltable
{
    class obr_urls
    {
        private string path = @"urls.txt";

        public void get_urls()
        {
            
            int max = 999999;
            WebRequest request;
            WebResponse response;
            string url_pre = "https://r-ak.bstatic.com/images/hotel/max500/150/150";
            for (int i = 447779; i < max; i++)
            {
                Console.WriteLine(String.Format(url_pre + "{0:000000}", i));
                try
                {
                    request = WebRequest.Create(String.Format(url_pre + "{0:000000}" + ".jpg", i));
                    response = request.GetResponse();
                    response.Close();
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(String.Format(url_pre + "{0:000000}" + ".jpg", i));
                    }
                    System.Threading.Thread.Sleep(10);
                    
                }
                catch (WebException e)
                {
                    if (e.Status == WebExceptionStatus.ProtocolError)
                    {
                        Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
                        Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
                    }
                }
                
            }
        }
    }
}
