using AngleSharp.Dom;
using AngleSharp.Parser.Html;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkAdder.Code
{
    class BudnyUrlParser
    {
        static Hashtable hash = new Hashtable();

        public static void ParseVuz(int id)
        {
            string vuzArticle = Data.GetArticleTextFromID(id);

            vuzArticle = StringToHtml(vuzArticle);

            var parser = new HtmlParser();
            var document = parser.Parse(vuzArticle);

            List<string> hrefTags = new List<string>();

            List<IElement> l = new List<IElement>();

            var ul = document.QuerySelector("ul");




            foreach (IElement element in document.QuerySelectorAll("ul"))
            {
                var collections = element.GetElementsByTagName("li");

                l.AddRange(collections);
            }

            //List<AngleSharp.Dom.Collections.> linkListFromVuzes = new List<HtmlElementCollection>();

            ArrayList list = new ArrayList();

            foreach (IElement element in l)
            {
                var r = element.GetElementsByTagName("a");

                if (r.Length > 0)
                {

                    list.Add(r);

                    var p = document.CreateElement("a");
                    p.SetAttribute("href", "/spsearch/fakeaddr");
                    p.TextContent = "fake link";


                    //var p = document.CreateElement("p");
                    //p.TextContent = "This is another paragraph.";



                    r[r.Length - 1].After(p);
                    //        var t = element.InnerHtml.Substring(0, element.InnerHtml.IndexOf('<')-1);
                    MessageBox.Show("");
                }
            }

        }

        private static string StringToHtml(string txt)
        {
            txt = txt.Replace("&lt;", "<");
            txt = txt.Replace("&gt;", ">");
            txt = txt.Replace("&amp;", "&");
            txt = txt.Replace("&quot;", @"""");
            return txt;
        }

        private static string HtmlToString(string html)
        {
            html = html.Replace("&", "&amp;");
            html = html.Replace("<", "&lt;");
            html = html.Replace(">", "&gt;");
            html = html.Replace(@"""", "&quot;");
            return html;
        }


        internal static void NormalizeArticle(int articleID, TextBox txt)
        {
            string article = Data.GetArticleTextFromID(articleID);

            article = StringToHtml(article);

            var parser = new HtmlParser();
            var document = parser.Parse(article);

            List<string> hrefTags = new List<string>();

            List<IElement> l = new List<IElement>();

            var links = document.QuerySelectorAll("a");

            foreach (var link in links)
            {
                string href = link.GetAttribute("href");

                if (hash[href] == null)
                {
                    string extractedLink = ExtractLink(href);

                    if (Data.IsOldUrlStringFormat(extractedLink))
                    {
                        string category = ExtractCategory(href);

                        if (category == "specialnosty")
                        {
                            string newLink = "/abiturient/specialnosty/" + Data.GetNewUrlFromIdAndCategoryId(Data.GetArticleIDFromUrlString(extractedLink, 520), 520);

                            Log.Write(href + ";" + newLink);
                            link.SetAttribute("href", newLink);
                            hash.Add(href, newLink);
                        }

                        if (category == "spsearch")
                        {
                            string newLink = "/abiturient/spsearch/" + Data.GetNewUrlFromIdAndCategoryId(Data.GetArticleIDFromUrlString(extractedLink, 493), 493);

                            Log.Write(href + ";" + newLink);
                            link.SetAttribute("href", newLink);
                            hash.Add(href, newLink);
                        }

                        if (category == "vuzspravochnik")
                        {
                            string newLink = "/vuzspravochnik/" + Data.GetNewUrlFromIdAndCategoryId(Data.GetArticleIDFromUrlString(extractedLink, 475), 475);

                            Log.Write(href + ";" + newLink);
                            link.SetAttribute("href", newLink);
                            hash.Add(href, newLink);
                        }
                    }
                    else
                    {
                        if (href.Length >= 15)
                        {
                            if (href.Substring(0, 15) == "http://budny.by")
                            {
                                string newHref = href.Remove(0, 15);

                                link.SetAttribute("href", newHref);
                                Log.Write(href + ";" + newHref);
                                hash.Add(href, newHref);
                            }
                        }
                    }

                }
                else
                {
                    link.SetAttribute("href", (string)hash[href]);
                    Log.Write(href + ";" + (string)hash[href]);
                }
            }

           ////////////////////////////////////////////// Data.UpdateArticleText(articleID, HtmlToString(document.Body.InnerHtml));

        }

        public static void SetLinksToSpeciality(int articleID, Hashtable links)
        {
            string article = Data.GetArticleTextFromID(articleID);

            bool isEdit = false;

            article = StringToHtml(article);

            var parser = new HtmlParser();
            var document = parser.Parse(article);

            List<IElement> l = new List<IElement>();

            foreach (IElement element in document.QuerySelectorAll("ul"))
            {
                var collections = element.GetElementsByTagName("li");

                l.AddRange(collections);
            }

            foreach (IElement element in l)
            {
                var r = element.GetElementsByTagName("a");

                if (r.Length > 0)
                {
                    if (links[r[r.Length-1].GetAttribute("href")]!=null)
                    {
                                var p = document.CreateElement("a");
                                p.SetAttribute("href", (string)links[r[r.Length-1].GetAttribute("href")]);
                                p.TextContent = "2015";

                                r[r.Length - 1].After(p);
                                //var t = element.InnerHtml.Substring(0, element.InnerHtml.IndexOf('<')-1);

                                element.InnerHtml = element.InnerHtml.Replace("a><a", "a>, <a");
                                Log.Write(articleID + ";" + (string)links[r[r.Length - 1].GetAttribute("href")] + ";added");

                                isEdit = true;

                    }
                }
            }

            if (isEdit)
            {
                Data.UpdateArticleText(articleID, HtmlToString(document.Body.InnerHtml));
            }
        }

        private static string ExtractCategory(string href)
        {
            string[] parts = href.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 1)
            {
                return parts[parts.Length - 2].ToLower();
            }

            return null;
        }

        private static string ExtractLink(string href)
        {
            if (href.LastIndexOf('/') > 0)
            {
                return href.Substring(href.LastIndexOf('/') + 1);
            }
            else
            {
                return null;
            }
        }

        public static Hashtable GetLinksFromVuzList()
        {
            Hashtable links = new Hashtable();

            var vuzList = Data.GetArticlesFromCategoryID(5);

            foreach (int vuzId in vuzList)
            {
                string article = Data.GetArticleTextFromID(vuzId);

                article = StringToHtml(article);

                var parser = new HtmlParser();
                var document = parser.Parse(article);

                List<IElement> l = new List<IElement>();

                foreach (IElement element in document.QuerySelectorAll("ul"))
                {
                    var collections = element.GetElementsByTagName("li");

                    l.AddRange(collections);
                }

                ArrayList list = new ArrayList();

                foreach (IElement element in l)
                {
                    var r = element.GetElementsByTagName("a");

                    if (r.Length == 4)
                    {
                        if (links.ContainsKey(r[2].GetAttribute("href")))
                        {
                            //MessageBox.Show(r[2].GetAttribute("href"));
                            Log.Write(vuzId + ";" + r[2].GetAttribute("href") + ";error");
                        }
                        else
                        {
                            links.Add(r[2].GetAttribute("href"), r[3].GetAttribute("href"));

                            Log.Write(r[2].GetAttribute("href") + ";" + r[3].GetAttribute("href"));

                            list.Add(r);
                        }
                    }
                }

            }
            return links;
        }

    }
}
