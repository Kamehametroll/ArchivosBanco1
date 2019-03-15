using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mensajes
{
    //Para añadir esta librería a sus çodigos, creen un proyecto de tipo class Library dentro de su solucion y 
    //despues hagan referencias de ella en las partes de su programa que vayan a usar.
    //Atención: Todos deben de generar sus propios constructores.
    //A Los constructores que están creados, solo se les puede agregar, si se va a modificar, favor avisar.
    //Los string son nulleable types, y el el decimal tambien, por lo que si en sus códigos no tienen
    //algun dato de un cliente(como la cuenta a la que se le va a transferir dinero), es bueno darle un valor null.
    //Usar el reloj del sistema para rellenar los datetime de las transacciones.

    public class Cliente
    {
        string codigo;
        string nombres;
        string apellidos;
        decimal balance;
        string cedula;

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombres { get => nombres; set => nombres = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public decimal Balance { get => balance; set => balance = value; }
        public string Cedula { get => cedula; set => cedula = value; }
    }

    public enum TipoPedido {transferencia, retiro, deposito, datosPersonales}
    public enum TipoRespuesta {confimacion, DatosPersonales}

    public class Pedido
    {
        public TipoPedido tipo { get; internal set; }
    }

    public class Respuesta
    {
        public TipoRespuesta tipo { get; internal set; }
    }

    #region Pedidos

    public class Transferencia : Pedido
    {
        Transferencia()
        {
            tipo = (TipoPedido)0;
        }
        Cliente cuentaOrigen;
        Cliente cuentaDestino;
        decimal monto;
        DateTime fecha;

        public Cliente CuentaOrigen { get => cuentaOrigen; set => cuentaOrigen = value; }
        public Cliente CuentaDestino { get => cuentaDestino; set => cuentaDestino = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }

    public class Retiro : Pedido
    {
        Retiro()
        {
            tipo = (TipoPedido)1;
        }
        Cliente cuenta;
        decimal monto;
        DateTime fecha;

        public Cliente Cuenta { get => cuenta; set => cuenta = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }

    public class Deposito : Pedido
    {
        Deposito()
        {
            tipo = (TipoPedido)2;
        }
        Cliente cuenta;
        decimal monto;
        DateTime fecha;

        public Cliente Cuenta { get => cuenta; set => cuenta = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
    public class RequestDatosPersonales : Pedido
    {
        RequestDatosPersonales()
        {
            tipo = (TipoPedido)3;
        }
        public Cliente datos; //Aqui me dan un cliente con algun campo incompleto(null) y yo les devuelvo el cliente completo (es como un find).
    }
    #endregion

    #region Respuestas

    public class Confirmacion : Respuesta
    {
        Confirmacion()
        {
            tipo = (TipoRespuesta)0;
        }
        public string mensajeConfirmación { get; internal set; }
    }

    public class ResponseDatosPersonales : Respuesta
    {
        ResponseDatosPersonales()
        {
            tipo = (TipoRespuesta)1;
        }
        public Cliente datos; //Aqui me dan un cliente con algun campo incompleto(null) y yo les devuelvo el cliente completo (es como un find).
    }
    #endregion


}
