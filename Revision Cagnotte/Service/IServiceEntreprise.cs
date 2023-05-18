using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
  public  interface IServiceEntreprise : IService<Entreprise>
    {
        Entreprise PlusParticipants();
    }
}
