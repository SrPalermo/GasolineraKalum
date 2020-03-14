using System;
using System.Collections.Generic;
using GasolineraKalum.Entities;
using GasolineraKalum.Interfaces;
using static GasolineraKalum.Util.Printer;
using static System.Console;
namespace GasolineraKalum.Controllers
{
    public class GasolineraController : IMantenimiento
    {
        private List<Bomba> listaDeBombas = new List<Bomba>();

        public void agregar(object elemento)
        {
            this.listaDeBombas.Add((Bomba)elemento);
        }

        public object buscar(string id)
        {
            Bomba resultado = null;
            foreach (var item in listaDeBombas)
            {
                if(item.Id.Equals(id,StringComparison.Ordinal)){
                    resultado = item;
                    break;
                }
            }
            return resultado;
        }

        public void eliminar(object elemento)
        {
            this.listaDeBombas.Remove((Bomba)elemento);
        }

        public void listar()
        {
            WriteTitle("Lista de bombas de gasolina");
            foreach (var item in this.listaDeBombas)
            {
                WriteLine(item);
            }
        }

        public void modificar(object elemento)
        { 
            
        }
    }
}