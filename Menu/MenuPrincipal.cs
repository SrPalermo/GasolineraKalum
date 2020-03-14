using static GasolineraKalum.Util.Printer;
using static System.Console;
using System;
using GasolineraKalum.Controllers;
using GasolineraKalum.Entities;

namespace GasolineraKalum.Menu
{
    public class MenuPrincipal
    {
        private GasolineraController controller = new GasolineraController();
        public void MostrarMenu()
        {
            try
            {
                int opcion = 0;
                do
                {
                    Clear();
                    WriteTitle("Administración de Bombas");
                    WriteLine("1. Agregar");
                    WriteLine("2. Eliminar");
                    WriteLine("3. Buscar");
                    WriteLine("4. Listar");
                    WriteLine("5. Modificar");
                    WriteLine("0. Salir");
                    WriteLine("Ingrese una opción===>");
                    string respuesta = ReadLine();
                    opcion = Convert.ToByte(respuesta); 
                    switch (opcion)
                    {
                        case 1:
                            agregarTipoBomba();
                            break;
                        case 2:
                            Eliminar();
                            break;
                        case 3:
                            buscar();
                            break;
                        case 4:
                            listarBombas(); 
                            break;
                        case 5:
                            Modificar();
                            break;
                        case 0:
                            break;
                        default:
                            WriteLine("No existe la opción");
                            break;
                    }

                } while (opcion != 0);
            }
            catch (Exception e)
            {
                WriteLine(e.Message);
            }
        }

        private void agregarTipoBomba()
        {             
            WriteTitle("Tipo de Bomba");
            WriteLine("1. Super");
            WriteLine("2. Regular");
            WriteLine("3. Diesel");
            WriteLine("0. Salir");
            WriteLine("Seleccione una opción==>");
            string respuesta = ReadLine();
            if(respuesta.Equals("1")){
                Bomba super = new Super();
                agregarElemento(super);                
            }else if(respuesta.Equals("2")){
                Bomba regular = new Regular();
                agregarElemento(regular);
            }else if(respuesta.Equals("3"))
            {   
                Bomba diesel = new Diesel();
                agregarElemento(diesel);
            }
        }

        private void agregarElemento(Bomba elemento)
        {
            WriteLine("Ingrese un precio");
            elemento.Precio = Convert.ToDouble(ReadLine());
            WriteLine("Ingrese una medida");
            elemento.Medida = ReadLine();
            WriteLine("Ingrese una cantidad");
            elemento.Capacidad = Convert.ToInt16(ReadLine());
            if(elemento.GetType() == typeof(Super))
            {
                WriteLine("Ingrese numero de aditivos");
                ((Super)elemento).Aditivo = Convert.ToInt16(ReadLine());
            }else if(elemento.GetType() == typeof(Diesel)){
                WriteLine("Ingrese formula");
                ((Diesel)elemento).Formula = ReadLine();
            }
            controller.agregar(elemento);
        }  
        private void listarBombas()
        {
            controller.listar();
            PresionarEnter();
        } 
        private void Eliminar()
        {
            controller.listar();
            WriteLine("Ingrese el id a eliminar: ");
            string id = Console.ReadLine();
            object elemento = buscar(id);
            if(elemento != null)
            {
                WriteLine("Esta seguro de eliminar (S/N)");
                string respuesta = Console.ReadLine();
                if(respuesta.Equals("s"))
                {
                    controller.eliminar(elemento);
                    WriteLine("Registro eliminar!!!");
                    ReadKey();
                }
                
            } 

        } 
        private object buscar(string id)
        {
            return controller.buscar(id);
        }

        public void buscar()
        {
            WriteLine("Ingrese el id");
            string id = ReadLine();
            object elemento = controller.buscar(id);
            if(elemento != null)
            {
                WriteLine(elemento);
            }
            else
            {
                WriteLine("No Existen Registros");
            }
            ReadKey();

        }

        public void Modificar()
        {
            controller.listar();
            WriteLine("Ingrese el Id del objeto que desea modificar: ");
            string id = ReadLine();
            object elemento = buscar(id);
            if (elemento != null)
            {
                ((Bomba)elemento).Capacidad = 2020;
                WriteLine("Registro Modificado!");
            }
            else
            {
                WriteLine("No existen registros!");
            }
            ReadKey();
        }
    }
}