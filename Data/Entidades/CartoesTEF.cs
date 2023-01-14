using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entidades
{
    public class CartoesTEF
    {
        [Column("Id")]
        public int Id { get; set; }
        public string VisasRedeCardAmexTEF { get; set; }
        public bool VisasRedeCardAmexTEFHabilitar { get; set; }
        public string TEFBanriCompras { get; set; }
        public bool TEFBanriComprasHabilitar { get; set; }
        public string TEFHipercard { get; set; }
        public bool TEFHipercardHabilitar { get; set; }
        public string EDMCard { get; set; }
        public bool EDMCardHabilitar { get; set; }
        public string EDMCardViasCupom { get; set; }
        public string UC { get; set; }
        public bool UCHabilitar { get; set; }
        public string FuncionalCard { get; set; }
        public bool FuncionalCardHabilitar { get; set; }
        public string VidaLink { get; set; }
        public bool VidaLinkHabilitar { get; set; }
        public string EPharma { get; set; }
        public bool EPharmaHabilitar { get; set; }
        public string Integracao4s { get; set; }
        public bool Integracao4sHabilitar { get; set; }
        public string IntegracaoAfdar { get; set; }
        public bool IntegracaoAfdarHabilitar { get; set; }

    }
}
