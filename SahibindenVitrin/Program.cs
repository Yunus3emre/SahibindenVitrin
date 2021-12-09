using HtmlAgilityPack;
using System;
using System.Linq;

namespace SahibindenVitrin
{
    class Program
    {
        static void Main(string[] args)
        {            
            Sahibinden();            
        }

        private static void Sahibinden()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://www.sahibinden.com/");
            
            String detayLink="";            
            String sahibindenLink = "https://www.sahibinden.com";

            for (int j = 1; j < 56; j++)
            {                
                var link = document.DocumentNode.SelectNodes("//*[@id=\"container\"]/div[3]/div/div[3]/div[3]/ul/li["+j+"]/a");
                int last = 0;
                link.ToList().ForEach(i => last = (i.OuterHtml.IndexOf(" title=")));
                link.ToList().ForEach(i => detayLink = (i.OuterHtml.Substring(9, last - 10)));
                Console.WriteLine(j+". ilan");
                Details(sahibindenLink + detayLink);
                System.Threading.Thread.Sleep(10000);
            }      
        }
        private static void Details(String url)
        {   
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(url);

            var title = document.DocumentNode.SelectNodes("//*[@id=\"classifiedDetail\"]/div/div[1]/h1/text()").First().InnerText;
            var price = document.DocumentNode.SelectNodes("//*[@id=\"classifiedDetail\"]/div/div[2]/div[2]/h3/text()").First().InnerText;
            var link = url;

            Console.WriteLine(title);
            Console.WriteLine(price.Trim());
            Console.WriteLine(url);
            Console.WriteLine(""); 
        }
    }
}
