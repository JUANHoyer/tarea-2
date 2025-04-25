using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_return
{
    public class clasereturn
    {
        ClaseDatos objd = new ClaseDatos();

        public DataTable listar_Empleados() 
        {
            return objd.listar_E();
        }
        public DataTable Buscar_Empleados(ClaseEntidad obje) 
        {
            return objd.Buscar_E(obje);
        }

        public string Mantenimiento_Empleado(ClaseEntidad obje)
        {
            return objd.Mantenimiento_E(obje);
        }
    }
}
