﻿using HtmlAgilityPack;
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
                Console.WriteLine("");                
                link.ToList().ForEach(i => Console.WriteLine(i.OuterHtml));
                Console.WriteLine("");
                link.ToList().ForEach(i => last = (i.OuterHtml.IndexOf(" title=")));

                if (last!=-1)
                {
                    link.ToList().ForEach(i => detayLink = (i.OuterHtml.Substring(9, last - 10)));
                    Console.WriteLine(j + ". ilan");
                    Details(sahibindenLink + detayLink);
                }
                else
                {
                    continue;
                }               
                
            }      
        }
        private static void Details(String url)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument document = web.Load(url);
                System.Threading.Thread.Sleep(3000);

                var title = document.DocumentNode.SelectNodes("//*[@id=\"classifiedDetail\"]/div/div[1]/h1/text()").First().InnerText;
                System.Threading.Thread.Sleep(3000);
                var price = document.DocumentNode.SelectNodes("//*[@id=\"classifiedDetail\"]/div/div[2]/div[2]/h3/text()").First().InnerText;
                System.Threading.Thread.Sleep(3000);

                Console.WriteLine("");
                Console.WriteLine(title);
                Console.WriteLine(price.Trim());
                Console.WriteLine(url);
                Console.WriteLine("");
                Console.WriteLine("");
            }
            catch (Exception)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Bu Bir Reklamdır");
                Console.WriteLine("");
                Console.WriteLine("");
            }


            
        }
    }
}
