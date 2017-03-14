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

       public const String TamanoTextoMuyGrande = "El tamaño maximo de ese texto sobrepasa el maximo permitido para ese campo";
       public const String Campo_Requerido = " No puede quedar en blanco \n";
       public const String Campo_DatoIncompleto = " Está Incompleto, Llena el campo faltante  , o Elimínalo del todo";
       public const String Numero_Mayor_Cero = " Deberia ser un número mayor a Cero  \n";
       public const String Upss_Falto_Algo = " Upss, falto algo ";
       public const String No_Se_Elimina_No_Se_Encontro = " No se pudo Eliminar el  registro \n Tal vez no se encontró o ya no existe";
       public const String Numero_Paciente_NoExiste = " Número de paciente inexistente";
       public const String No_Se_Encontro_Ningun_Registro = "No se encontro ningún Registro con los criterios de Busqueda ";
       public const String Descuento_No_Aplicable = " No se  aplicara descuento a este servicio"; // Referencia la Tabla GeneralServicio , isPrecioEditable
       public const String No_hay_Servicios = "No ha añadido  servicios ";
       public const String No_hay_Cliente = "No se podrá guardar Los datos si no hay asignado un cliente,\n regrese y asigne un cliente ";
       public const String No_Eliminar_idUno = "No Se Puede Eliminar las Opciones por Defecto  ";
       public const String No_Se_Actualizo = "No se Actualizaron los datos, el registro que Intenta Actualizar  no existe en la Base Datos \n Actualize La lista de egistros ";
       public const String Para_Buen_Funcionamiento = "Para un buen funcionamiento del Sistema no intentes este Cambio ";
       public const String Esta_Seguro_Eliminar = "¿Esta Seguro que desea ELIMINARLO ?\n Si lo eliminas es probable que no puedas volver a recuperar la información ";
       public const String AlgoPaso = "Algo Sucedio";
       public const String Refresh =  "Precione el botón de recargar Datos ";
       public const String FechaAnterior = "Estas escogiendo una fecha anterior al día de hoy ,intenta una más actual ";
       public const String ContrasenaNoCoincide = " Las Contraseñas no Coinciden  ";
       public const String FraseIgualPassword = "La frase para recordar no debe  ser igual a la contraseña  por seguridad ";
       public const String CorreoEnviado = "El correo ya ha sido enviado  ";
       public const String GuardarPrimero = "Debes de guardar la consulta antes para poder realizar esta acción";
       public const String Suspended = "Has fallado los datos de ingresar  3 veces , mejor inténtalo en  5 Minutos ";
       #endregion 


       /// <summary>
       /// Conteo de Que?
       /// </summary>
       public const String HuboErrorConteo = "Hubo un error Con el Conteo Total"; // Contado filas en  DataGrid
       public const String fk_ConstraintDeleteConsulta = " No se puede eliminar el registro por que esta siendo usando en alguna Consulta,\n Primero Modifique o Elimine los registren que utilizen esta ópcion ";
       public const String fk_ConstraintDelete = " No se puede eliminar el registro por que esta siendo usado ,\n Primero Modifique o Elimine los registren que utilizen esta ópcion ";
       public const String Consulta_Sin_Servicios = " Esta Consulta no tiene Servicios ";
       public const String CitaChocan = " La fecha , hora o duración de la cita chocan con una cita ya existente";
       public const String NotieneCorreo = "No se puede enviar el mensaje por que el registro seleccionado no tiene asignado un correo ";
       public const String NosePuedoGuardar = "No se pudo guardar los datos en la Base de Datos";
       public const String PathTooLong = "El directorio donde desea guardar el es demasiado largo/nIntente guardarlo  en Documentos";
       public const String AccesoNoAutorizado = "No tienes los permisos para acceder a esa carpeta";
       public const String FraseNoseEncontro = "No se encontro Frase asociada a ese Usuario\n Digito correctamente el nombre del usuario?";
       /// <summary>
       /// Respuesta  para  System.Security.SecurityException
       /// </summary>
       public const String ViolacionSeguridad = "Violacion de Seguridad";
       
       // Otros
       public const String ExtencionImagen = "Asegúrate que estes cargando una imagen";
       public const String LLenadoRapido = "Llenado Rapido";
       public const String ErrorCargarImagen = "Hubo un error al cargar la Imagen";

    }
}
