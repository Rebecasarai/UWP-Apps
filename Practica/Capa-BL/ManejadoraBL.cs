using Capa_DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Capa_BL
{
    class ManejadoraBL
    {
        /// <summary>
        /// Metodo que obtiene la persona por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Planeta> getPersona(int id)
        {
            Planeta person = new Planeta();
            ManejadoraBL manejadoraDAL = new ManejadoraBL();
            await manejadoraDAL.getPersona(id);

            return person;
        }

        /// <summary>
        /// Metodo que actualiza la persona
        /// </summary>
        /// <param name="p">Recibe al objeto de persona</param>
        /// <returns>Retorna un entero que representa el numero de filas afectadas</returns>
        public async Task<HttpStatusCode> updatePersonaAsync(Planeta p)
        {
            ManejadoraDAL manejadoraDAL = new ManejadoraDAL();
            return await manejadoraDAL.updatePlaneta(p);
        }

        /// <summary>
        /// Metodo que borra la persona por su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> borrarPersonaAsync(int id)
        {
            int filasAfectadas = 0;
            ManejadoraDAL manejadora = new ManejadoraDAL();
            filasAfectadas = await manejadora.eliminarPlaneta(id);

            return filasAfectadas;
        }

        /// <summary>
        /// Metodo que añade la persona, la inserta a la BD
        /// </summary>
        /// <param name="p"></param>
        public async Task addPersonaAsync(Planeta p)
        {
            ManejadoraDAL manejadora = new ManejadoraDAL();
            await manejadora.crearPlaneta(p);

        }
    }

}
