using Data.Infrastructure;
using Domain;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class ServiceCagnotte : Service<Cagnotte>, IServiceCagnotte
    {
        public ServiceCagnotte(IUnitOfWork utwk) : base(utwk)
        {

        }


        //Service1
        public IEnumerable<Cagnotte> Encours()
        {
            return GetMany().Where(c => c.DateLimite.CompareTo(DateTime.Now) > 0);
        }
        //Service2
        public int Montant(int id)
        {
            IDataBaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            var req = utwk.getRepository<Participation>().GetMany().Where(p => p.CagnotteFk == id);
            int m = 0;
            foreach (var item in req)
            {
                m = m + item.Montant;
            }

            return m;
        }
        //Service3
        public int NbrCagnottes(int id)
        {
            IDataBaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            return utwk.getRepository<Participant>().GetMany().Where(p => p.ParticipantId == id).Select(p => p.Participations).Count();
        }

        //Service4
        public IEnumerable<Entreprise> Top2Entreprise(string Type)
        {
            IDataBaseFactory factory = new DataBaseFactory();
            IUnitOfWork utwk = new UnitOfWork(factory);
            var linq = (from i in utwk.getRepository<Entreprise>().GetMany()
                        join j in GetMany() on i.EntrepriseId equals j.Entreprise.EntrepriseId
                        where j.Type.ToString() == Type
                        orderby i.Cagnottes.Count()
                        select i).Take(2);
            return linq;


        }


    }
}
