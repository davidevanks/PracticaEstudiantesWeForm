//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class estudianteNotas
    {
        public long idEstudianteNotas { get; set; }
        public Nullable<long> id_estudiante { get; set; }
        public Nullable<long> id_docente { get; set; }
        public Nullable<long> id_carrera { get; set; }
        public Nullable<long> id_asignatura { get; set; }
        public Nullable<double> nota_final { get; set; }
        public Nullable<double> nota_rescate { get; set; }
        public string nota_letras { get; set; }
        public Nullable<long> id_periodo { get; set; }
        public Nullable<long> activo { get; set; }
        public Nullable<System.DateTime> fecha_grabacion { get; set; }
    
        public virtual asignaturas asignaturas { get; set; }
        public virtual docentes docentes { get; set; }
        public virtual docentes docentes1 { get; set; }
        public virtual estudiante estudiante { get; set; }
    }
}
