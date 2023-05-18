using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool disposedValue;

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: supprimer l'état managé (objets managés)
                    DisposeCore();
                }

                // TODO: libérer les ressources non managées (objets non managés) et substituer le finaliseur
                // TODO: affecter aux grands champs une valeur null
                disposedValue = true;
            }
        }

        // // TODO: substituer le finaliseur uniquement si 'Dispose(bool disposing)' a du code pour libérer les ressources non managées
        ~Disposable()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Ne changez pas ce code. Placez le code de nettoyage dans la méthode 'Dispose(bool disposing)'
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        protected virtual void DisposeCore()
        {
            //insert code
        }
    }
}
