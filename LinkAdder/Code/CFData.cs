using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkAdder.Code
{
    class CFData
    {

        public string Title { get; set; }
        public int ArticleID { get; set; }
        public int GorodID { get; set; }
        public int VuzID { get; set; }
        public int FakultetID { get; set; }

        public bool? TypeObuchDnevnoe { get; set; }
        public bool? TypeObuchZaochnoe { get; set; }
        public bool? TypeObuchDistanc { get; set; }
        public bool? TypeObuchSokrasch { get; set; }

        public decimal? PrBallDnevnBudget { get; set; }
        public decimal? PrBallDnevnBudgetLgotn { get; set; }
        public decimal? PrBallDnevnPlatnoe { get; set; }
        public decimal? PrBallZaochnBudget { get; set; }
        public decimal? PrBallZaochnBudgetLgotn { get; set; }
        public decimal? PrBallZaochnPlatn { get; set; }
        public decimal? PrBallZaochnPlatnLgotn { get; set; }
        public decimal? PrBallSokrasch { get; set; }
        public decimal? PrBallSokraschLgotn { get; set; }
        public decimal? PrBallSokraschPlatn { get; set; }

        public bool? CertRusskiy { get; set; }
        public bool? CertMatemat { get; set; }
        public bool? CertHimia { get; set; }
        public bool? CertIstoriaBelorus { get; set; }
        public bool? CertInostrYazik { get; set; }
        public bool? CertSpecEkzamen { get; set; }
        public bool? CertBiologia { get; set; }

        public bool? CertFizika { get; set; }
        public bool? CertObschestvoved { get; set; }
        public bool? CertVsemirIstoria { get; set; }
        public bool? CertGeografia { get; set; }
        public bool? CertProfSobesed { get; set; }

        public int NapravleniePodgotovki { get; set; }
    }
}
