using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias Añadidas
using ClinicaPro.DB.Inventario;
using ClinicaPro.General.Constantes;	
		 
	
namespace ClinicaPro.Inventario
{
    public partial class MantenimientoInventario : Form
    {
        //~~~~ Atribrutos
        int IdTipoUsuario;
        /// <summary>
        /// -1
        /// </summary>
        private int IdInventarioNuevo = -1; 


        public MantenimientoInventario(int TipoUsuario)
        {
            InitializeComponent();
            this.IdTipoUsuario = TipoUsuario;
        }
        private void cargarGrid()
        {
            InventarioDB.Listar(this.dgConsulta);
            colorFilasCantidadAlerta();
        }
        private void colorFilasCantidadAlerta()
        {

            int CantidadExistente;
            int CantidadAlerta;

            foreach (DataGridViewRow fila in dgConsulta.Rows)
            {
                CantidadExistente = (int)fila.Cells[5].Value; // CantidadExistente
                CantidadAlerta = (int)fila.Cells[6].Value; // CantidadAlerta

                if (CantidadExistente < CantidadAlerta)
                {
                    fila.DefaultCellStyle.ForeColor = SystemColors.HotTrack;
                }
            }            
        }
        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            var frmInv = new ClinicaPro.Inventario.frmAgregarInventario(IdInventarioNuevo);
            frmInv.ShowDialog(this);
            cargarGrid();
                  
        }
        private void MantenimientoInventario_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void brnModificar_Click(object sender, EventArgs e)
        {
            if (this.dgConsulta.SelectedRows.Count == 1)
            {
                int IdInventario = (int)this.dgConsulta.SelectedRows[0].Cells["IdArticulo"].Value;
                var frmInv = new ClinicaPro.Inventario.frmAgregarInventario(IdInventario);
                frmInv.ShowDialog(this);
                cargarGrid();
            }else
            {
                MessageBox.Show(this,Mensajes.Seleccione_Una_Fila,Mensajes.Upss_Falto_Algo,MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
           if(this.dgConsulta.SelectedRows.Count == 1)
           {
               if(ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
               {
                   int Id =(int) this.dgConsulta.SelectedRows[0].Cells["IdArticulo"].Value;
                   bool result = InventarioDB.Eliminar(Id);
                   if (result)
                   {
                       ClinicaPro.BL.Mensaje.MensajeGuardadoEnDB("Inventario");
                   }
               }
           }else
           MessageBox.Show(this,Mensajes.Seleccione_Una_Fila,Mensajes.Upss_Falto_Algo,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }        
    }
}
