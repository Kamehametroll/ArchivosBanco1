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
        public string codigo;
        public string Nombres;
        public string Apellidos;
        public decimal? Balance;
    }

    public enum TipoPedido {transaccion, retiro, deposito, datosPersonales}
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

    public class Transaccion : Pedido
    {
        Transaccion()
        {
            tipo = (TipoPedido)0;
        }
        public Cliente cuentaOrigen;
        public Cliente cuentaDestino;
        public decimal monto;
        public DateTime fecha;

    }
    public class retiro : Pedido
    {
        retiro()
        {
            tipo = (TipoPedido)1;
        }
        public Cliente cuenta;
        public decimal monto;
        public DateTime fecha;
    }
    public class Deposito : Pedido
    {
        Deposito()
        {
            tipo = (TipoPedido)2;
        }
        public Cliente cuenta;
        public decimal monto;
        public DateTime fecha;
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
