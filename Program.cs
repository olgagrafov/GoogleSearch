using System.Diagnostics;

namespace GoogleSearch
{
       class Program
    {
        static string GOOGLE_SEARCH = @"https://www.google.com/search?q=";
        static string GOOGLE_QUERY = "LexisNexis";
        static int NUMBER_LINK_OPEN = 2;
        static void Main(string[] args)
        {
            Crawl cr = new Crawl(GOOGLE_SEARCH + GOOGLE_QUERY);
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Program Files\Internet Explorer\iexplore.exe", GOOGLE_SEARCH + GOOGLE_QUERY);
            Process.Start(info);

            OpenLenk opl = new OpenLenk(cr.HTML_String);
            string linkOpen = opl.Link_List.ToArray().GetValue(NUMBER_LINK_OPEN).ToString();
            info = new ProcessStartInfo(@"C:\Program Files\Internet Explorer\iexplore.exe", linkOpen);
            Process.Start(info);
        }
    }
}
