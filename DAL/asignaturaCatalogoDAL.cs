using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class asignaturaCatalogoDAL
    {

        public List<AsignaturasVM> ListarAsignaturas()
        {

            List<AsignaturasVM> lstAsignatura = new List<AsignaturasVM>();

            using (var contexto = new ControlAlumnosEntities())
            {

                lstAsignatura = contexto.ListarAsignaturas(0).Select(x => new AsignaturasVM {

                    id = x.asignaturaId,
                    asignatura=x.asignatura,
                    codigoAsignatura=x.codigoAsignatura,
                    asignaturaRequisitoId=x.asignaturaRequisitoId,
                    codigoAsignaturaRequisito=x.codigoAsignaturaRequisito,
                    asignaturasRequisito=x.asignaturaRequisito,
                    activo=(bool)x.activoAsignatura

                }).ToList();


                return lstAsignatura;
            }

        }


        public AsignaturasVM ListarAsignaturasId(int Id)
        {

            AsignaturasVM lstAsignatura = new AsignaturasVM();

            using (var contexto = new ControlAlumnosEntities())
            {

                lstAsignatura = contexto.ListarAsignaturas(Id).Select(x => new AsignaturasVM
                {

                    id = x.asignaturaId,
                    asignatura = x.asignatura,
                    codigoAsignatura = x.codigoAsignatura,
                    asignaturaRequisitoId = x.asignaturaRequisitoId,
                    codigoAsignaturaRequisito = x.codigoAsignaturaRequisito,
                    asignaturasRequisito = x.asignaturaRequisito,
                    activo = (bool)x.activoAsignatura

                }).FirstOrDefault();


                return lstAsignatura;
            }

        }


        public List<AsignaturasVM> ListarAsignaturasRequisitos()
        {

            List<AsignaturasVM> lstAsignatura = new List<AsignaturasVM>();

            using (var contexto = new ControlAlumnosEntities())
            {

                lstAsignatura = contexto.ListarAsignaturas(0).Select(x => new AsignaturasVM
                {

                    id = x.asignaturaId,
                    asignatura = x.asignatura,
                    codigoAsignatura = x.codigoAsignatura,
                    asignaturaRequisitoId = x.asignaturaRequisitoId,
                    codigoAsignaturaRequisito = x.codigoAsignaturaRequisito,
                    asignaturasRequisito = x.asignaturaRequisito,
                    activo = (bool)x.activoAsignatura

                }).ToList();


                return lstAsignatura;
            }

        }

        public bool Guardar(asignaturas asig)
        {
            asignaturas asignatura = new asignaturas();
                int idAsig = 0;
            bool ban=false;

            try
            {
                using (var contexto= new ControlAlumnosEntities())
                {

                    //iCatPais = (from p in context.fyvCatPais where p.fyvCatPaisID.Equals(pCatPais.fyvCatPaisID) select p.fyvCatPaisID).Count();
                    idAsig = (from p in contexto.asignaturas where p.idAsignatura.Equals(asig.idAsignatura) select p.idAsignatura).Count();
                    //primer if, se guarda nuevo registro
                    if(idAsig==0)
                    {
                        asignatura.nombreAsignatura = asig.nombreAsignatura;
                        asignatura.codigoAsignatura = asig.codigoAsignatura;
                        asignatura.idPadre = asig.idPadre;
                        asignatura.activo = true;

                        contexto.asignaturas.Add(asignatura);
                        contexto.SaveChanges();
                        ban = true;

                    }
                    else
                    {
                        //para cuando el registro ya existe, y se edita.
                        //catPais = context.fyvCatPais.Where(p => p.fyvCatPaisID.Equals(pCatPais.fyvCatPaisID)).FirstOrDefault();
                        asignatura = contexto.asignaturas.Where(p => p.idAsignatura.Equals(asig.idAsignatura)).FirstOrDefault();

                        if(asignatura!=null)
                        {
                            asignatura.nombreAsignatura = asig.nombreAsignatura;
                            asignatura.codigoAsignatura = asig.codigoAsignatura;
                            asignatura.idPadre = asig.idPadre;
                            asignatura.activo = asig.activo;

                            
                            contexto.SaveChanges();
                            ban = true;

                        }



                    }

                }

                return ban;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }

           
        }


        //Clase asignatura
        public class AsignaturasVM
        {
        public long? id { get; set; }
     
        public string codigoAsignatura { get; set; }
       
        public string asignatura { get; set; }
        public Nullable<long> asignaturaRequisitoId { get; set; }
        public string codigoAsignaturaRequisito { get; set; }
        
        public string asignaturasRequisito { get; set; }
        public bool activo { get; set; }



    }


        //



    }
}
