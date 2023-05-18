using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class ServiceEntreprise : Service<Entreprise>, IServiceEntreprise
    {
        public ServiceEntreprise(IUnitOfWork utwk) : base(utwk)
        {

        }

        //Service5
        public Entreprise PlusParticipants()
        {
            IDataBaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            var x = utwk.getRepository<Cagnotte>().GetMany().OrderBy((e => e.Participantions.Count())).First();

            return x.Entreprise;
        }


    }
}
