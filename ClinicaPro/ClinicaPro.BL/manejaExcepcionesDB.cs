
namespace ClinicaPro.BL
{

    using System;
    using System.Collections.Generic;    
    using System.Text;
    using System.Threading.Tasks;
    
    // Librerias añadidas

    using System.Data.Entity.Core;
    using ClinicaPro.General.Excepciones;
    using System.Windows.Forms;
    using System.Data.SqlClient;
    using ClinicaPro.General.Constantes;

    

   public class manejaExcepcionesDB
    {
        public static void manejaEntityException(EntityException entityException)
        {
            //Void Open . No hay conexion con la base de datos
            if (entityException.TargetSite.ToString() == ExcepcionesMensajes.Void_Open)
            {
                if (!intentarAbrirServicioDeSQLServerLocalArea())
                    MessageBox.Show(ExcepcionesMensajes.Revisar_Servidor_Encendido + ExcepcionesMensajes.Revisar_Servicio_MSSQL, ExcepcionesMensajes.Title_Exception, MessageBoxButtons.OK, MessageBoxIcon.Error);
                else {
                    MessageBox.Show("El servicio de MSSQLSERVER no estaba funcionando , Intente de nuevo");
                    }
            }
            else
                MessageBox.Show(ExcepcionesMensajes.Sin_ConexionDB, ExcepcionesMensajes.Title_Exception, MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }
       public static void DbUpdateException(System.Data.Entity.Infrastructure.DbUpdateException DbUpdate)
       {
           string InnerEx = DbUpdate.InnerException.InnerException.ToString();
           if (InnerEx.Contains("Cannot insert duplicate key row in object") || InnerEx.Contains("Violation of UNIQUE KEY constraint"))
          {
              MessageBox.Show(ExcepcionesMensajes.NombresRepetidos,"Repetido",MessageBoxButtons.OK,MessageBoxIcon.Error);
          }else
          {                           
               manejaExcepcion(new Exception());
          }
       }      
        /// <summary>Maneja las excepciones en la Base Datos , añadir esta solo cuando se trabaja con los datos internos de la DB       
       /// </summary>
       /// <param name="sqlException"></param>
        public static void manejaSQLExcepciones(SqlException sqlException)  // No esta funcionando
        {
            if (sqlException.Number == 2016)   // Error expecifica si se duplica un Id (PK)  existente
            {

                MessageBox.Show(ExcepcionesMensajes.Id_Duplicada + "\n" + ExcepcionesMensajes.IntenteModificar,
                                      ExcepcionesMensajes.Title_Exception,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Error);

            }
            else    // Error generico
            { 
               MessageBox.Show(ExcepcionesMensajes.Error_En_BaseDatos+"\n"+ sqlException.Number,
                                 ExcepcionesMensajes.Title_Exception ,
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);                                  
            }        
        }
        public static void manejaNullReference(NullReferenceException nullReference)
        {
            String values = String.Empty;
            
            values += "\n" + nullReference.Message;
            values += "\n" + nullReference.Source;                        
            MessageBox.Show(ExcepcionesMensajes.Null_Reference + "\n" + values, ExcepcionesMensajes.Title_Exception, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void manejaExcepcion(Exception ex)
        {
            ///<summary>  
            /// Maneja otras excepciones  que no sean null reference ni de entity 
            /// y Guada los detalles en un EventLog
            ///</summary>           
            MessageBox.Show(ExcepcionesMensajes.ExcepcionGeneral, ExcepcionesMensajes.Title_Exception, MessageBoxButtons.OK, MessageBoxIcon.Error);            
        }       
       /// <summary>
       /// Intenta Iniciar el Servicio de MSSQLSERVer , en un entorno LocalHost
       /// </summary>
       /// <returns></returns>
       private static bool intentarAbrirServicioDeSQLServerLocalArea()
       {
           try
           {
               System.ServiceProcess.ServiceController serviceController1 = new System.ServiceProcess.ServiceController();
               serviceController1.ServiceName = "MSSQLSERVER";
               if (serviceController1.Status ==  System.ServiceProcess.ServiceControllerStatus.Stopped
                   ||
                   serviceController1.Status == System.ServiceProcess.ServiceControllerStatus.Paused)
               {
                   serviceController1.Start();                   
                   return true;
               }
               return false;
           }
           catch (Exception)
           {               
               return false;
           }
          

       }
    
#region Eliminar
       /// <summary>
       /// Verifica que el Id no sea uno, para que no elimine las respuestas por defecto, y para que nunca quede vacia
       /// </summary>
       /// <param name="IdEntidad"></param>
       /// <returns></returns>
        public static Boolean isID_distintodeUNO( int IdEntidad)
        {
            if (IdEntidad == 1)
            {
                MessageBox.Show( Mensajes.No_Eliminar_idUno, Mensajes.Para_Buen_Funcionamiento, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;

        }
       

#endregion
       
    }
}
