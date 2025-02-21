using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Aplicacion
{
    public class GestorTareas
    {
        private static GestorTareas _instancia;
        private List<IObserver> observadores = new List<IObserver>();

        public static GestorTareas ObtenerInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new GestorTareas();
            }
            return _instancia;
        }

        public void AgregarObservador(IObserver observador)
        {
            if (!observadores.Contains(observador))
                observadores.Add(observador);
        }

        public void RemoverObservador(IObserver observador)
        {
            if (observadores.Contains(observador))
                observadores.Remove(observador);
        }

        public void NotificarObservadores()
        {
            foreach (var observador in observadores)
            {
                observador.Actualizar();
            }
        }
    }

}
