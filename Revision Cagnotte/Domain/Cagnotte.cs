using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{

    public enum Type { CadeauCommun, DépenseàPlusieurs, ProjetSolidaire, Autres }
    public class Cagnotte
    {
        public int CagnotteId { get; set; }

        [Required(ErrorMessage ="Le titre est obligatoire")]
        public string Titre { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Range(0, int.MaxValue)]
        public int SommeDemandée { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DateLimite { get; set; }
        public string Photo { get; set; }
        public Type Type { get; set; }

        //prop navigation
        public int EntrepriseId { get; set; }
        public virtual Entreprise Entreprise { get; set; }
        public virtual ICollection<Participation> Participantions { get; set; }
    }
}