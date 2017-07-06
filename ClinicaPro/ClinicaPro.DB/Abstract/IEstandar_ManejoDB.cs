using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Abstract
{
    /// <summary> Interface General , define una abstracción minima de lo que deberia llevar cada clase 
    ///  que Accede a la Base de Datos
    /// </summary>    
   public interface IEstandar_ManejoDB<T> 
   {
       /// <typeparam name="T">Indica que para implemtar método hay que especificar el Tipo de Clase</typeparam>
       /// <example>Como cuando se crea una lista 
       ///          List<T> nombreObjeto = new List<T>() 
       /// </example>
       /// <seealso cref="https://msdn.microsoft.com/en-us/library/kwtft8ak.aspx"/>          

       /// <param name="isModificar">Se utiliza como parametro para indicar si el metodo va añadir o actualizar un registro</param>
       /// <param name="idTipoUsuario">Parametro para añadir seguridad </param>
       /// <remarks>Dejar estos valors -1 por defecto ,se hace en el constructor de la clase que implementa la interface </remarks>
             
         /// <param name="Entidad">Alguna de Entidad mapeada de la Base datos ejemplo "Usuario"</param>
         /// <param name="isModificar">En caso  agregar un nuevo registro su valor es, false</param>
         
         int Agregar_Modificar(T Entidad, Boolean isModificar);
         bool Eliminar(int idCliente,int idTipoUsuario);
       /// <summary> Selecciona todos los datos , usarlo  para  llenar los DataGrids
       /// </summary>
       /// <returns>Lista de objetos de Clase </returns>       
         List<T> Listar();
    }
}
