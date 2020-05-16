using OroGolden.WebApp.Data;
using OroGolden.WebApp.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OroGolden.WebApp.Business
{
    public class BusGolden
    {

        public void Agregar(EntGolden e)
        {

            DatGolden datos = new DatGolden();
            int filas = datos.Agregar(e.Nombre, e.Email, e.Telefono);

            if(filas != 1)
            {
                throw new ApplicationException("Error al agregar");
            }

        }

        public void NombreRepetido(EntGolden e)
        {
            DatGolden datos = new DatGolden();
            DataTable Dt = datos.NombreRepetido(e.Nombre);

            if (Dt.Rows.Count > 0)
            {
                throw new ApplicationException(e.Nombre + " ya tiene agendada una cita! ");
            }
        }

    }
}
