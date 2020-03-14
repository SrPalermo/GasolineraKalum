using System;
using GasolineraKalum.Interfaces;

namespace GasolineraKalum.Entities
{
    public abstract class Bomba : IControlBomba
    {
        private double precio;
        public Bomba()
        {
            this.Id = GenerarId();
        }

        public Bomba(double precio, int capacidad, string medida)
        {
            this.Id = GenerarId();
            this.Precio = precio;
            this.Capacidad = capacidad;
            this.Medida = medida;
        }
        public string Id { get; set; }
        public double Precio { get; set; }
        public int Capacidad { get; set; }
        public string Medida { get; set; }

        public void Despachar(int cantidad)
        {
            if(this.Capacidad >= cantidad)
            {
                this.Capacidad -= cantidad;
            }
        }

        public int VerNivelCapacidad()
        {
            return this.Capacidad;
        }

        private string GenerarId()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        public override string ToString(){
            return $"{{ \"Id\" : \"{this.Id}\", \"Capacidad\" : {this.Capacidad}, \"Tipo\" : { this.GetType().ToString().Substring(this.GetType().ToString().LastIndexOf(".") + 1)} }}";
            
        }

    }
}