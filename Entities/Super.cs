namespace GasolineraKalum.Entities
{
    public class Super : Bomba
    {
        public Super() : base()        
        {

        }
        public Super(int aditivo, double precio, int capacidad, string medida) 
            : base(precio,capacidad,medida)
        {
            this.Aditivo = aditivo;

        }
        public int Aditivo { get; set; }
    }
}