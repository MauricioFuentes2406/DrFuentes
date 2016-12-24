using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.General.Constantes
{
    /// <summary>
    /// Clase para agrupar los Mensajes del sistema en una sola seccion, facilita el mantenimiento
    /// y mantiene la uniformidad de los mensajes 
    /// </summary>

   public class Mensajes
    {
       

       public const String Agregar_Modificar = "Los Datos se han actualizado correctamente ";
       public const String DeseaAbrirFRM_AgregarConsulta = "\n Desea abrir el formulario de consulta  ";
       public const String Seleccione_Una_Fila = " Seleccione una fila para continuar  ";
       public const String Detalles_Cargados ="Detalles Cargados"; // Usado para frmExpediente txtMensajeInformativo
       public const String DetallesActualizados = "Detalles Actualizados";   // Usado para frmExpediente txtMensajeInformativo

       #region Para las  Validaciones

       public const String Campo_Requerido = " No puede quedar en blanco \n";
       public const String Numero_Mayor_Cero = " Deberia ser un número mayor a Cero  \n";
       public const String Upss_Falto_Algo = " Upss, falto algo ";
       public const String No_Se_Elimina_No_Se_Encontro = " No se puede Eliminar un registro que no existe";
       public const String Numero_Paciente_NoExiste = " Número de paciente inexistente";
       public const String No_Se_Encontro_Ningun_Registro = "No se encontro ningún Registro con los criterios de Busqueda ";
       public const String Descuento_No_Aplicable = " No se  aplicara descuento a este servicio"; // Referencia la Tabla GeneralServicio , isPrecioEditable
       public const String No_hay_Servicios = "No ha añadido  servicios ";
       public const String No_hay_Cliente = "No se podrá guardar Los datos si no hay asignado un cliente,\n regrese y asigne un cliente ";
       public const String No_Eliminar_idUno = "No Se Puede Eliminar las Opciones por Defecto  ";

       public const String Para_Buen_Funcionamiento = "Para un buen funcionamiento del Sistema no intentes este Cambio ";

       #endregion
       
       // Otros

       public const String LLenadoRapido = "Llenado Rapido";

    }
}
