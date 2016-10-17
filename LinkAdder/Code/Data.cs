using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAdder.Code
{
    class Data
    {//Data Source=w05.hosterby.com;Initial Catalog=budnyby_test;User ID=budnyby_admin;Password=dthtcthtdta1!
        public static SqlConnection connection = new SqlConnection(@"Data Source=w05.hosterby.com;Initial Catalog=budnyby_test;User ID=budnyby_admin;Password=dthtcthtdta1!");

        public static List<int> GetArticlesFromCategoryID(int id)
        {
            
          //  connection.Open();

            SqlCommand listCommand = new SqlCommand("SELECT * FROM [budnyby_test].[dbo].[EasyDNNNewsCategories] where categoryid="+id, connection);


            SqlDataReader reader = listCommand.ExecuteReader();

            List<int> vuzList = new List<int>();

            using (reader)
            {
                while (reader.Read())
                {
                    vuzList.Add((int)reader["ArticleID"]);
                }
            }


            //connection.Close();

            return vuzList;
        }


  



   

        private static string GetTitleFromArticleId(int articleId)
        {
          //  connection.Open();

            SqlCommand articleListCommand = new SqlCommand("SELECT Title FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE articleID=" + articleId, connection);

            articleListCommand.CommandTimeout = 1000000;

            string title = (string)articleListCommand.ExecuteScalar();

         //   connection.Close();

            return title;
        }

        private static int? GetArticleIDFromOldUrlString(int id)
        {
         //   connection.Open();

            SqlCommand articleIDCommand = new SqlCommand("SELECT ArticleID FROM EasyDNNnewsUrlProviderData WHERE id=" + id, connection);

            articleIDCommand.CommandTimeout = 1000000;

            int? articleId = (int)articleIDCommand.ExecuteScalar();


          //  connection.Close();

            return articleId;
        }

        private static int? GetArticleIDFromNewUrlString(string url, int moduleId)
        {
          //  connection.Open();

            SqlCommand articleIDCommand = new SqlCommand("SELECT ArticleID FROM EasyDNNnewsUrlNewProviderData WHERE linktitle='"+
                url+"' and Moduleid=" + moduleId, connection);

            articleIDCommand.CommandTimeout = 1000000;

            int? articleId = articleIDCommand.ExecuteScalar() as int?;


         //   connection.Close();

            return articleId;
        }

        public static int? GetArticleIDFromUrlString(string url, int moduleId)
        {
            int? articleId = GetArticleIDFromNewUrlString(url, moduleId);

            if (articleId==null)
            {
                articleId = GetArticleIDFromOldUrlString(GetUrlID(url));
            }

            return articleId;
        }

        public static bool IsOldUrlStringFormat(string url)
        {
           // connection.Open();

            SqlCommand articleIDCommand = new SqlCommand("SELECT ArticleID FROM EasyDNNnewsUrlNewProviderData WHERE linktitle='" +
                url + "'", connection);

            articleIDCommand.CommandTimeout = 1000000;

            int? articleId = articleIDCommand.ExecuteScalar() as int?;

         //   connection.Close();

            return articleId == null;
        }

        private static int GetUrlID(string url)
        {
            int urlId = int.Parse(url.Substring(url.LastIndexOf('-') + 1, url.Length - url.LastIndexOf('-') - 1));

            return urlId;
        }

        public static string GetArticleTextFromID(int ID)
        {
          //  connection.Open();

            SqlCommand articleDataCommand = new SqlCommand("select article from EasyDNNNews where ArticleID=" + ID, connection);

            articleDataCommand.CommandTimeout = 1000000;

            string articleData = (string)articleDataCommand.ExecuteScalar();

          //  connection.Close();

            return articleData;
        }

        private static string GetSubTitleFromArticleId(int articleId)
        {
          //  connection.Open();

            SqlCommand articleListCommand = new SqlCommand("SELECT SubTitle FROM [budnyby_test].[dbo].[EasyDNNNews] WHERE articleID=" + articleId, connection);

            articleListCommand.CommandTimeout = 1000000;

            string title = (string)articleListCommand.ExecuteScalar();

          //  connection.Close();

            return title;
        }





        internal static string GetNewUrlFromIdAndCategoryId(int? articleId, int categoryId)
        {
         //   connection.Open();

            SqlCommand urlCommand = new SqlCommand(string.Format("SELECT LinkTitle FROM EasyDNNnewsUrlNewProviderData where ArticleID={0} and ModuleID={1}", articleId, categoryId), connection);

            urlCommand.CommandTimeout = 1000000;

            string url = (string)urlCommand.ExecuteScalar();

         //   connection.Close();

            return url;
        }

        internal static void UpdateArticleText(int articleID, string articleText)
        {
        //    connection.Open();

            string upd = string.Format("update [budnyby_test].[DBO].[EasyDNNNews] SET [Article]=@articletext where [ArticleID]= {0}",
                articleID.ToString());

            SqlCommand updateNewArticle = new SqlCommand(upd, connection);

            updateNewArticle.CommandTimeout = 1000000;

            updateNewArticle.Parameters.Add("@articletext", System.Data.SqlDbType.NVarChar);
            updateNewArticle.Parameters["@articletext"].Value = articleText;

            updateNewArticle.ExecuteNonQuery();

          //  connection.Close();
        }


    }
}
