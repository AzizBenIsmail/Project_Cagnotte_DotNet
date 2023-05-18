using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
 public class Entreprise
    {
        public int EntrepriseId { get; set; }
        public String NomEntreprise { get; set; }
        public String AdresseEntreprise { get; set; }
        public String MailEntreprise { get; set; }

        //prop navigation
        public virtual ICollection<Cagnotte> Cagnottes { get; set; }

    }
}
