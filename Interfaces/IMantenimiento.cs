using System;

namespace GasolineraKalum.Interfaces
{
    public interface IMantenimiento
    {
        void agregar(object elemento);
        void modificar(object elemento);
        void eliminar(object elemento);
        object buscar(string id);
        void listar();
    }
}