using System;
using System.Collections.Generic;


namespace GoogleSearch
{
    class OpenLenk
    {
        string LINKS= "<a href=\"/url?q=http";

       
        public string HTML_Text { set; get; }
        public List<String> Link_List { set; get; }
        public OpenLenk() { }
        public OpenLenk(string html_txt) {
            HTML_Text = html_txt;
            Link_List = new List<String>();
            SearchLinks();
        }
        public void SearchLinks()
        {
            string tmpStr, link;
            int end, strat;    

            while (HTML_Text.IndexOf(LINKS)>0)
            {
                strat = HTML_Text.IndexOf(LINKS) + LINKS.Length - 4;
                tmpStr = HTML_Text.Substring(strat);
                end = tmpStr.IndexOf("&amp");
                link = HTML_Text.Substring(strat, end);
                tmpStr = HTML_Text.Substring(strat + end);              
                HTML_Text = tmpStr;
                if (link.Contains("25")) link = link.Replace("25", "");//remove 25 for hebrew       
                Link_List.Add(link);     
          }
            
        }
    }
}
