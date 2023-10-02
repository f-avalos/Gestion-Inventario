using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_Almacen.Presentacion

{

    public partial class Frm_articulos : Form
    {
        public Frm_articulos()
        {
            InitializeComponent();
        }

        #region "Variables"

        int nCodigo_ar = 0;
        int nEstadoguarda = 0;
        int nCodigo_um = 0;
        int nCodigo_ca = 0;

        #endregion

        #region "Mis Metodos"

        private void Formato_ar()
        {
            Dgv_articulos.Columns[0].Width = 80;
            Dgv_articulos.Columns[0].HeaderText = "Código";
            Dgv_articulos.Columns[1].Width = 250;
            Dgv_articulos.Columns[1].HeaderText = "Artículo";
            Dgv_articulos.Columns[2].Width = 150;
            Dgv_articulos.Columns[2].HeaderText = "Marca";
            Dgv_articulos.Columns[3].Width = 80;
            Dgv_articulos.Columns[3].HeaderText = "Medida";
            Dgv_articulos.Columns[4].Width = 150;
            Dgv_articulos.Columns[4].HeaderText = "Categoria";
            Dgv_articulos.Columns[5].Width = 150;
            Dgv_articulos.Columns[5].HeaderText = "Stock Actual";
            Dgv_articulos.Columns[6].Visible = false;
            Dgv_articulos.Columns[7].Visible = false;
        }
        private void Listado_ar(string cTexto)
        {
            D_Articulos Datos = new D_Articulos();
            Dgv_articulos.DataSource = Datos.Listado_Ar(cTexto);
            this.Formato_ar();
        }

        private void Estado_texto(bool lEstado)
        {
            Txt_descripcion_ar.ReadOnly = !lEstado;
            Txt_marca_ar.ReadOnly = !lEstado;
            Txt_stock_actual.ReadOnly = !lEstado;
        }

        private void Estado_botones_procesos(bool lEstado)
        {
            Btn_lupa_um.Enabled = lEstado;
            Btn_lupa_ca.Enabled = lEstado;

            Btn_cancelar.Visible = lEstado;
            Btn_guardar.Visible = lEstado;

            //Detalles

            Txt_buscar.ReadOnly = lEstado;
            Btn_buscar.Enabled = !lEstado;
            Dgv_articulos.Enabled = !lEstado;

        }

        private void Estado_botones_principales(bool lEstado)
        {
            Btn_nuevo.Enabled = lEstado;
            Btn_actualizar.Enabled = lEstado;
            Btn_eliminar.Enabled = lEstado;
            Btn_reporte.Enabled = lEstado;
            Btn_salir.Enabled = lEstado;
        }

        private void Limpia_texto()
        {
            Txt_descripcion_ar.Text = "";
            Txt_marca_ar.Text = "";
            Txt_descripcion_um.Text = "";
            Txt_descripcion_ca.Text = "";
            Txt_stock_actual.Text = "0";
        }

        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_articulos.CurrentRow.Cells["codigo_ar"].Value)))
            {
                MessageBox.Show("Selecciona un registro", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo_ar = Convert.ToInt32(Dgv_articulos.CurrentRow.Cells["codigo_ar"].Value);
                Txt_descripcion_ar.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["descripcion_ar"].Value);
                Txt_marca_ar.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["marca_ar"].Value);
                Txt_descripcion_um.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["descripcion_um"].Value);
                Txt_descripcion_ca.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["descripcion_ca"].Value);
                Txt_stock_actual.Text = Convert.ToString(Dgv_articulos.CurrentRow.Cells["stock_actual"].Value);
                this.nCodigo_um = Convert.ToInt32(Dgv_articulos.CurrentRow.Cells["codigo_um"].Value);
                this.nCodigo_ca = Convert.ToInt32(Dgv_articulos.CurrentRow.Cells["codigo_ca"].Value);
            }
        }

        #endregion

        #region "Métodos medidas/categorias"

        private void Formato_um()
        {
            Dgv_um.Columns[0].Width = 200;
            Dgv_um.Columns[0].HeaderText = "Medidas";
            Dgv_um.Columns[1].Visible = false;
        }
        private void Listado_um()
        {
            D_Articulos Datos = new D_Articulos();
            Dgv_um.DataSource = Datos.Listado_um();
            this.Formato_um();
        }

        private void Formato_ca()
        {
            Dgv_ca.Columns[0].Width = 200;
            Dgv_ca.Columns[0].HeaderText = "Categorias";
            Dgv_ca.Columns[1].Visible = false;
        }
        private void Listado_ca()
        {
            D_Articulos Datos = new D_Articulos();
            Dgv_ca.DataSource = Datos.Listado_ca();
            this.Formato_ca();
        }

        private void Selecciona_item_um()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_um.CurrentRow.Cells["codigo_um"].Value)))
            {
                MessageBox.Show("Selecciona un elemento", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo_um = Convert.ToInt32(Dgv_um.CurrentRow.Cells["codigo_um"].Value);
                Txt_descripcion_um.Text = Convert.ToString(Dgv_um.CurrentRow.Cells["descripcion_um"].Value);
                
            }
        }

        private void Selecciona_item_ca()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_ca.CurrentRow.Cells["codigo_ca"].Value)))
            {
                MessageBox.Show("Selecciona un elemento", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.nCodigo_ca = Convert.ToInt32(Dgv_ca.CurrentRow.Cells["codigo_ca"].Value);
                Txt_descripcion_ca.Text = Convert.ToString(Dgv_ca.CurrentRow.Cells["descripcion_ca"].Value);

            }
        }

        #endregion
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Frm_articulos_Load(object sender, EventArgs e)
        {
            this.Listado_ar("%");
            this.Listado_um();
            this.Listado_ca();
        }
        

        private void Btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_ar("%"+Txt_buscar.Text.Trim()+"%");
        }

        private void Btn_nuevo_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 1;
            this.Limpia_texto();
            this.Estado_texto(true);
            this.Estado_botones_procesos(true);
            this.Estado_botones_principales(false);
            Txt_descripcion_ar.Focus();
        }

        private void Btn_cancelar_Click(object sender, EventArgs e)
        {
            nCodigo_ar = 0;
            nEstadoguarda = 0;
            this.Limpia_texto();
            this.Estado_texto(false);
            this.Estado_botones_procesos(false);
            this.Estado_botones_principales(true);
            Txt_buscar.Focus();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            string Rpta = "";
            P_Articulos oAr = new P_Articulos();
            oAr.Codigo_ar = nCodigo_ar;
            oAr.Descripcion_ar = Txt_descripcion_ar.Text.Trim();
            oAr.Marca_ar = Txt_marca_ar.Text.Trim();
            oAr.Codigo_um = this.nCodigo_um;
            oAr.Codigo_ca = this.nCodigo_ca;
            oAr.Stock_actual = Convert.ToDecimal(Txt_stock_actual.Text);
            oAr.Fecha_crea = DateTime.Now.ToString("yyyy-MM-dd");
            oAr.Fecha_modifica = DateTime.Now.ToString("yyyy-MM-dd");

            D_Articulos Datos = new D_Articulos();

            
            Rpta = Datos.Guardar_ar(nEstadoguarda, oAr);

            if (Rpta.Equals("Ok"))
            {
                this.Estado_texto(false);
                this.Estado_botones_procesos(false);
                this.Estado_botones_principales(true);
                this.Listado_ar("%");
                nCodigo_ar = 0;
                nEstadoguarda = 0;
                nCodigo_um = 0;
                nCodigo_ca= 0;
                MessageBox.Show("¡Datos guardados correctamente!", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Btn_actualizar_Click(object sender, EventArgs e)
        {
            nEstadoguarda = 2; //Actualizar registro
            this.Estado_texto(true);
            this.Estado_botones_procesos(true);
            this.Estado_botones_principales(false);
            Txt_descripcion_ar.Focus();
        }

        private void Dgv_articulos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item();
        }

        private void Btn_eliminar_Click(object sender, EventArgs e)
        {
            if(nCodigo_ar > 0)
            {
                string Rpta = "";
                D_Articulos Datos = new D_Articulos();
                Rpta = Datos.Eliminar_ar(nCodigo_ar);
                if (Rpta.Equals("Ok"))
                {
                    this.Limpia_texto();
                    this.Listado_ar("%");
                    nCodigo_ar = 0;
                    MessageBox.Show("¡Registro eliminado!", "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("No se tiene seleccionado ningún registro", "Aviso del sistema", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Btn_reporte_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Articulos oRpt = new Frm_Rpt_Articulos();
            oRpt.ShowDialog();
        }

        private void Btn_lupa_um_Click(object sender, EventArgs e)
        {
            Pnl_um.Location = Btn_lupa_um.Location;
            Pnl_um.Visible = true;
        }

        private void Btn_lupa_ca_Click(object sender, EventArgs e)
        {
            Pnl_ca.Location = Btn_lupa_um.Location;
            Pnl_ca.Visible = true;
        }

        private void Btn_retornar_um_Click(object sender, EventArgs e)
        {
            Pnl_um.Visible=false;
        }

        private void Btn_retornar_ca_Click(object sender, EventArgs e)
        {
            Pnl_ca.Visible=false;
        }

        private void Dgv_um_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item_um();
            Pnl_um.Visible = false;
        }

        private void Dgv_ca_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_item_ca();
            Pnl_ca.Visible = false;
        }
    }
}
