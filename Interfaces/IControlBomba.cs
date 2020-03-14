namespace GasolineraKalum.Interfaces
{
    public interface IControlBomba
    {
        void Despachar(int cantidad);
        int VerNivelCapacidad();

    }
}