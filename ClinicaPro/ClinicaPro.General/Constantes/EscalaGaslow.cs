using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaPro.General.Constantes
{
   public class EscalaGaslow
    {
       public class AperturaOcular
       {
           public const int Espontanea = 4;
           public const int A_la_orden = 3;
           public const int Ante_un_estímulo_doloroso = 2;
           public const int Ausencia_de_apertura_ocular =1;       
       }
       public class RespuestaVerbal
       {
           public const int Orientado_correctamente=5;
           public const int Paciente_confuso = 4;
           public const int Lenguaje_inapropiado = 3;
           public const int Lenguaje_incomprensible = 2;
           public const int Carencia_de_actividad_verbal = 1;
       }
       public class RespuestaMotora
       {
           public const int Obedece_órdenes_correctamente=6;
           public const int Localiza_estímulos_dolorosos = 5;
           public const int Evita_estímulos_dolorosos_retirando_segmento_corporal_explorado = 4;
           public const int Respuesta_con_flexión_anormal_miembros = 3;
           public const int Respuesta_con_extensión_anormal_miembros = 2;
           public const int Ausencia_de_respuesta_motora = 1;
       }
       public class idResultadoSuma
       {
           public const int Entre_14y15 = 1;
           public const int Entre_9y13 =2;
           public const int Entre_3y8 = 3;   // El  puntaje minimo es 3 
       }

       public static int idResultado_deSumas(int SumaResultados)
       {
           if (SumaResultados >= 14)
           {
               return idResultadoSuma.Entre_14y15;
           } if (SumaResultados >= 9 && SumaResultados  <= 13)
            return idResultadoSuma.Entre_9y13;
           else
             return idResultadoSuma.Entre_3y8;
       }
    }
}
