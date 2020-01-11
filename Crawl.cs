using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;


namespace GoogleSearch
{
    class Crawl
    {
        public string HTML_String { set; get; }
        public Crawl() { }
        public Crawl(string url)
        {
            StartCrawling(url);
        }
        public void StartCrawling(string url)
        {
            WebResponse response = GetWebResponse(url);
            // DisplayHeaderData(response);
            HTML_String=GetHtmlText(response);
        }
        public WebResponse GetWebResponse(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
           // Thread.Sleep(2000);
            return request.GetResponse();
        }
        public string GetHtmlText(WebResponse response)
        {
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            string htmlText = reader.ReadToEnd();
            // Console.WriteLine(htmlText);
            return htmlText;

        }
        private void DisplayHeaderData(WebResponse response)
        {
            Dictionary<string, string> headerData = new Dictionary<string, string>();
            for (int i = 0; i < response.Headers.AllKeys.Length; i++)
            {
                headerData.Add(response.Headers.AllKeys[i], response.Headers[i]);
            }
            foreach (var item in headerData)
            {
                Console.WriteLine(item.Key + "::" + item.Value);
            }
        }

    }
}
