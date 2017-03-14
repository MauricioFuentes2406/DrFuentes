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
using ClinicaPro.DB.Laboratorio;
using ClinicaPro.General.Constantes;

namespace ClinicaPro.Laboratorio
{
    public partial class MantenimientoExa : Form
    {
        public MantenimientoExa()
        {
            InitializeComponent();
        }

        private void MantenimientoExa_Load(object sender, EventArgs e)
        {
            cargarGrid();            
        }
        private void cargarGrid()
        {
            new ExamenesDB().vistaExamenes(this.dgExamenes);
            this.dgExamenes.Columns[0].Visible = false;
            this.dgExamenes.Columns[1].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            new AgregarExamenes().ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cargarGrid();
        }
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (this.dgExamenes.SelectedRows.Count == 1)
            {
                int IdExamen = (int)this.dgExamenes.CurrentRow.Cells["IdExamen"].Value;
                AgregarExamenes frmExamen = new AgregarExamenes(IdExamen);
                frmExamen.ShowDialog();
                frmExamen.Dispose();
                cargarGrid();
            }
            else
            {
                MessageBox.Show(Mensajes.Seleccione_Una_Fila, "Para Modificar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ClinicaPro.BL.Mensaje.isSeguroDeEliminar())
            {
                if (this.dgExamenes.SelectedRows.Count == 1)
                {
                    int IdExamen = (int)this.dgExamenes.CurrentRow.Cells["IdExamen"].Value;
                    bool result = new ExamenesDB().Eliminar(IdExamen, 0);
                    if (result)
                        MessageBox.Show("Base Dato de Actualizada", " ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    else
                        MessageBox.Show(Mensajes.Seleccione_Una_Fila, "Para Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                    MessageBox.Show(Mensajes.Seleccione_Una_Fila, "Para Eliminar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
