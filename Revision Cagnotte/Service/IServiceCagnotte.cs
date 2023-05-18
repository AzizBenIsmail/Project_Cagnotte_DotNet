using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
 public interface IServiceCagnotte:IService<Cagnotte>
    {
        IEnumerable<Cagnotte> Encours();
        IEnumerable<Entreprise> Top2Entreprise(string Type);
        int Montant(int id);                               
    }
}
