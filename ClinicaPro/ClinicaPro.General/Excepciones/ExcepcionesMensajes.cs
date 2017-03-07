using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.General.Excepciones
{
   public class ExcepcionesMensajes
    {
       public const String Title_Exception = "Se encontró un error";
       public const String Void_Open="Void Open()";
       public const String Sin_ConexionDB = " No se pudo establecer una comunicación con la base datos ";
       public const String Null_Reference = " Algún Campo Obligatorio  o párametro de Busqueda al  que se hace referencia no existe en la BD ";
       public const String ExcepcionGeneral = " Ocurrío un  error ";
       public const String Id_Duplicada = " No se puede añadir un nuevo Registro , por que ya existe uno";
       public const String Error_En_BaseDatos = " Ocurrio un error en la Base de Datos  ";

        #region Recomendaciones
       public const String Revisar_Servicio_MSSQL = "\n *Revise  el estado del servicio MSSQLSERVER , o si no aparece  ";
       public const String Revisar_Servidor_Encendido = "\n *Revise si la computadora-servidor está encendida";
       public const String IntenteModificar = " Intente Modificar el registro en vez de crear uno nuevo ";
        
        #endregion
    }
}
