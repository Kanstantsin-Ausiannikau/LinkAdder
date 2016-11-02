using AngleSharp.Dom;
using AngleSharp.Dom.Html;
using AngleSharp.Parser.Html;
using LinkAdder.Code;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkAdder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // int? articleId = Data.GetArticleIDFromUrlString("special-nost-tehnologicheskoe-oborudovanie-maschinostroitel-nogo-proizvodstva", 520);

            var vuzList = Data.GetArticlesFromCategoryID(5);

            foreach (int vuzID in vuzList)
            {
               BudnyUrlParser.ParseVuz(vuzID);
            }
           
        }

        private void btnLinksNormalize_Click(object sender, EventArgs e)
        {

            Data.connection.Open();
            var vuzList = Data.GetArticlesFromCategoryID(5);

           // BudnyUrlParser.NormalizeArticle(8, textBox1);

            int count = 0;

            foreach(int articleID in vuzList)
            {
                BudnyUrlParser.NormalizeArticle(articleID, textBox1);

                textBox1.AppendText((count++).ToString() + " " + articleID.ToString()+Environment.NewLine);
            }
            textBox1.AppendText("vuz ok"+Environment.NewLine);

            var specialnosty = Data.GetArticlesFromCategoryID(29);

            foreach (int articleID in specialnosty)
            {
                BudnyUrlParser.NormalizeArticle(articleID, textBox1);
                textBox1.AppendText((count++).ToString() + " " + articleID.ToString() + Environment.NewLine);
            }
            textBox1.AppendText("spec ok" + Environment.NewLine);

            var spsearch2013 = Data.GetArticlesFromCategoryID(34);

            foreach (int articleID in spsearch2013)
            {
                BudnyUrlParser.NormalizeArticle(articleID, textBox1);
                textBox1.AppendText((count++).ToString() + " " + articleID.ToString() + Environment.NewLine);
            }
            textBox1.AppendText("2013 ok" + Environment.NewLine);

            var spsearch2014 = Data.GetArticlesFromCategoryID(43);

            foreach (int articleID in spsearch2014)
            {
                BudnyUrlParser.NormalizeArticle(articleID, textBox1);
                textBox1.AppendText((count++).ToString() + " " + articleID.ToString() + Environment.NewLine);
            }

            textBox1.AppendText("2014 ok" + Environment.NewLine);

            var spsearch2015 = Data.GetArticlesFromCategoryID(72);

            foreach (int articleID in spsearch2015)
            {
                BudnyUrlParser.NormalizeArticle(articleID, textBox1);
                textBox1.AppendText((count++).ToString() + " " + articleID.ToString() + Environment.NewLine);
            }
            textBox1.AppendText("2015 ok" + Environment.NewLine);

            Data.connection.Close();
        }

        private void btnOpenDay_Click(object sender, EventArgs e)
        {
            Data.connection.Open();
            var dayList = Data.GetArticlesFromCategoryID(31);

            // BudnyUrlParser.NormalizeArticle(8, textBox1);

            int count = 0;

            foreach (int articleID in dayList)
            {
                BudnyUrlParser.NormalizeArticle(articleID, textBox1);

                textBox1.AppendText((count++).ToString() + " " + articleID.ToString() + Environment.NewLine);
            }
            textBox1.AppendText("day ok" + Environment.NewLine);

            Data.connection.Close();
        }

        private void btnSetLinks_Click(object sender, EventArgs e)
        {
            Data.connection.Open();
            
            var specialnosty = Data.GetArticlesFromCategoryID(29);

            Hashtable links = BudnyUrlParser.GetLinksFromVuzList();

            foreach (int articleID in specialnosty)
            {
                BudnyUrlParser.SetLinksToSpeciality(articleID, links);

                textBox1.AppendText(articleID.ToString() + Environment.NewLine);
            }

            Data.connection.Close();

        }

        private void btnSetLinksNewVer_Click(object sender, EventArgs e)
        {
            const int SPECIALITY_CATEGORY_ID = 29;
            const int VUZ_CATEGORY_ID = 5;

            Data.connection.Open();

            var articles = Data.GetArticlesFromCategoryID(SPECIALITY_CATEGORY_ID);

            articles.AddRange(Data.GetArticlesFromCategoryID(VUZ_CATEGORY_ID));




            Data.connection.Close();
        }
    }
}
