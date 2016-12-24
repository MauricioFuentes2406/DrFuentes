using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.DB.Abstract
{
    /// <summary>
    /// Para hacer una lista de cada Consulta por Cliente se requiere que exista esta funcion, no aplica si va preferir crear una vista
    /// </summary>
    interface IListarExpediente<T>
    {
        List<T> ListaPorConsulta(int IdConsulta);
    }
}
