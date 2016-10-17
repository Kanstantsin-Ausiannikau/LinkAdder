using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkAdder.Code
{
    class Article
    {
        public CFData CustomFieldsValue { get;  set; }

        public int ArticleID { get; set; }
        public int PortalID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string ArticleText { get; set; }
        public string ArticleImage { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime LastModified { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int NumberOfViews { get; set; }
        public decimal RatingValue { get; set; }
        public int RatingCount { get; set; }
        public string TitleLink { get; set; }
        public string DetailType { get; set; }
        public string DetailTypeData { get; set; }
        public string DetailsTemplate { get; set; }
        public string DetailsTheme { get; set; }
        public string GalleryPosition { get; set; }
        public string GalleryDisplayType { get; set; }
        public string CommentsTheme { get; set; }
        public string ArticleImageFolder { get; set; }
        public int NumberOfComments { get; set; }
        public string MetaDecription { get; set; }
        public string MetaKeywords { get; set; }
        public string DisplayStyle { get; set; }
        public string DetailTarget { get; set; }
        public string CleanArticleData { get; set; }
        public bool ArticleFromRSS { get; set; }
        public bool HasPermissions { get; set; }
        public bool EventArticle { get; set; }
        public string DetailMediaType { get; set; }
        public string DetailMediaData { get; set; }
        public string AuthorAliasName { get; set; }
        public bool ShowGallery { get; set; }
        public int? ArticleGalleryID { get; set; }
        public string MainImageTitle { get; set; }
        public string MainImageDescription { get; set; }
        public bool HideDefaultLocale { get; set; }

        public bool Featured { get; set; }
        public bool Approved { get; set; }
        public bool AllowComments { get; set; }
        public bool Active { get; set; }


        public bool ShowMainImage { get; set; }
        public bool ShowMainImageFront { get; set; }
        public bool ArticleImageSet { get; set; }
        public int CFGroupeID { get; set; }

        public string DetailsDocumentsTemplate { get; set; }
        public string DetailsLinksTemplate { get; set; }
        public string DetailsRelatedArticlesTemplate { get; set; }

        public int FieldElementID { get; set; }
        public int CustomFieldID { get; set; }

    }
}
