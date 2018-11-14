using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Text;

namespace Presentacion.Practica
{
    
    public partial class catAsignaturas : System.Web.UI.Page
    {
        asignaturaCatalogoBLL bl = new asignaturaCatalogoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillDsAsignaturas();
                fillDdlAsignaturasRequisitos();
                ModoEdicion(false);

            }
        }

        protected void fillDsAsignaturas()
        {

            List<asignaturaCatalogoDAL.AsignaturasVM> lstAsignaturas = new List<asignaturaCatalogoDAL.AsignaturasVM>();
            lstAsignaturas = bl.lstAsignaturas();

            grdAsignaturas.DataSource = lstAsignaturas;
            grdAsignaturas.DataBind();
            grdAsignaturas.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

        protected void fillDdlAsignaturasRequisitos()
        {
            List<asignaturaCatalogoDAL.AsignaturasVM> lstAsignaturas = new List<asignaturaCatalogoDAL.AsignaturasVM>();
            lstAsignaturas = bl.lstAsignaturasRequisitos();

            ddlAsignaturaRequisito.DataSource = lstAsignaturas;
            ddlAsignaturaRequisito.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            bool ban = false;
            asignaturas asig = new asignaturas();

            if(txtID.Text==string.Empty)
            {
                asig.idAsignatura = 0;
                asig.nombreAsignatura = txtAsignatura.Text;
                asig.codigoAsignatura = txtCodigo.Text;
                asig.idPadre = Convert.ToInt32(ddlAsignaturaRequisito.SelectedItem.Value);
                asig.activo = true;

                ban = bl.Guardar(asig);

            }
            else
            {
                asig.idAsignatura = Convert.ToInt32(txtID.Text);
                asig.nombreAsignatura = txtAsignatura.Text;
                asig.codigoAsignatura = txtCodigo.Text;
                asig.idPadre = Convert.ToInt32(ddlAsignaturaRequisito.SelectedItem.Value);
                asig.activo = ckbAvtivo.Checked;
               ban= bl.Guardar(asig);
                //catPais.fyvCatPaisID = Convert.ToInt32(txtID.Text);
                //catPais.Descripcion = txtDescripcion.Text;
                //catPais.Simbolo = txtSimbolo.Text;
                //catPais.Activo = chkActivo.Checked;
                //bGuardado = _bl.Guardar(catPais);


            }

            if (ban)
            {
                fillDsAsignaturas();
                Limpiar();
                ModoEdicion(false);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registro exitoso')", true);

            }

        }


        private void Limpiar()
        {

            txtAsignatura.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            txtID.Text = string.Empty;


        }

        protected void grdAsignaturas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            int id = 0;

            try
            {
                index = Convert.ToInt32(e.CommandArgument);
                //    ID = Convert.ToInt32(grd_catpais.DataKeys[index].Value);
                id = Convert.ToInt32(grdAsignaturas.DataKeys[index].Value);
                AsignarValores(id);

                if (e.CommandName.Equals("VerDetalle"))
                {
                    ModoEdicion(false);
                }
                if (e.CommandName.Equals("Editar"))
                {
                    ModoEdicion(true);
                }
            }
            catch (Exception)
            {

                throw;
            }
            

           
        }

        private void AsignarValores(int id)
        {
            asignaturaCatalogoDAL.AsignaturasVM asig = new asignaturaCatalogoDAL.AsignaturasVM();

            try
            {
                asig = bl.ListarAsignaturaId(id);

                if (asig!=null)
                {
                    txtID.Text = asig.id.ToString();
                    txtAsignatura.Text = asig.asignatura;
                    txtCodigo.Text = asig.codigoAsignatura;
                    ckbAvtivo.Checked = asig.activo;
                    ddlAsignaturaRequisito.SelectedValue = asig.asignaturaRequisitoId.ToString();
                }
            }
            catch (Exception ex)
            {
                string msjError = ex.ToString();
                throw;
            }



        }

        protected void grdAsignaturas_PreRender(object sender, EventArgs e)
        {
            
            if (grdAsignaturas.Rows.Count > 0)
            {
                grdAsignaturas.UseAccessibleHeader = true;
                grdAsignaturas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

        private void ModoEdicion(bool ban)
        {
            txtAsignatura.Enabled = ban;
            txtCodigo.Enabled = ban;
            ddlAsignaturaRequisito.Enabled = ban;
            ckbAvtivo.Enabled = ban;



        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            ModoEdicion(true);
        }
    }
}