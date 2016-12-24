﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Librerias añadidas
using ClinicaPro.BL;
using System.Data.Entity.Core;

namespace ClinicaPro.DB.Consulta
{
   public class VAntecedentePatologico
    {
        public static List<Entities.VistaAntecedentesPatologicos> ListaPorConsulta (int idConsulta)
        {
            using (ClinicaPro.Entities.ClinicaDrFuentesEntities Contexto = new Entities.ClinicaDrFuentesEntities())
            {
                List<Entities.VistaAntecedentesPatologicos> lista = (from tabla in Contexto.VistaAntecedentesPatologicos.AsNoTracking()
                                                                     where tabla.Número_Consulta == idConsulta
                                                                     select tabla).ToList();
                return lista;
            }
        }
    }
}
