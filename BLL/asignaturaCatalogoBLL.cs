using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
   public class asignaturaCatalogoBLL
    {
        asignaturaCatalogoDAL dl = new asignaturaCatalogoDAL();
        public List<asignaturaCatalogoDAL.AsignaturasVM> lstAsignaturas()
        {
            List<asignaturaCatalogoDAL.AsignaturasVM> lstAsignaturas = new List<asignaturaCatalogoDAL.AsignaturasVM>();
            lstAsignaturas = dl.ListarAsignaturas();
            return lstAsignaturas;


        }


        public List<asignaturaCatalogoDAL.AsignaturasVM> lstAsignaturasRequisitos()
        {
            List<asignaturaCatalogoDAL.AsignaturasVM> lstAsignaturas = new List<asignaturaCatalogoDAL.AsignaturasVM>();
            lstAsignaturas = dl.ListarAsignaturasRequisitos();
            return lstAsignaturas;


        }

        public asignaturaCatalogoDAL.AsignaturasVM ListarAsignaturaId(int id)
        {

            try
            {
                asignaturaCatalogoDAL.AsignaturasVM asig = new asignaturaCatalogoDAL.AsignaturasVM();
                asig = dl.ListarAsignaturasId(id);
                return asig;
            }
            catch (Exception ex)
            {
                string msjError = ex.ToString();
                throw;
            }
           


        }

        public bool Guardar(asignaturas asig)
        {
            try
            {
                dl.Guardar(asig);
                return true;
            }
            catch ( Exception ex)
            {
                return false;
                throw;
            }

        }


    }
}
