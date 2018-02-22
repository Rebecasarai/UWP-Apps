using Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Capa_DAL
{
    public class ManejadoraDAL
    {

        /// <summary>
        /// Eliminamos con el verbo delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> eliminarPlaneta(int id)
        {
            Conexion mConexion = new Conexion();
            int mResultado = 0;
            HttpClient client = new HttpClient();
            HttpResponseMessage respuesta;
            Uri mUri = new Uri(mConexion.Api + "/" + id);
            try
            {
                respuesta = await client.DeleteAsync(mUri);
                client.Dispose();

                if (respuesta.IsSuccessStatusCode)
                {
                    mResultado = 1;
                }
            }
            catch (Exception e) { throw e; }

            return mResultado;

        }

        /// <summary>
        /// Este metodo crea con Post
        /// </summary>
        /// <param name="persona">Recibe un objeto persona</param>
        /// <returns>Devuelve un 1 si se ha creado correctamente. Un 0 si ha fallado.</returns>
        public async Task<int> crearPlaneta(Planeta planeta)
        {
            Conexion miConexion = new Conexion();
            int resultado = 0;
            HttpClient client = new HttpClient();
            String body;
            HttpStringContent mContenido;
            HttpResponseMessage mRespuesta;
            try
            {
                // Serializamos al objeto persona que recibe
                body = JsonConvert.SerializeObject(planeta);

                mContenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

                mRespuesta = await client.PostAsync(miConexion.Api, mContenido);

                if (mRespuesta.IsSuccessStatusCode)
                {
                    resultado = 1;
                }
            }
            catch (Exception e) { throw e; }


            return (resultado);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public async Task<HttpStatusCode> updatePlaneta(Planeta planeta)
        {
            Conexion miConexion = new Conexion();
            HttpClient client = new HttpClient();
            String body;
            HttpStringContent mContenido;
            HttpResponseMessage mRespuesta;
            Uri mUri = new Uri(miConexion.Api + "/" + planeta.id);
            try
            {
                // Serializamos al objeto persona que recibe
                body = JsonConvert.SerializeObject(planeta);

                mContenido = new HttpStringContent(body, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");

                mRespuesta = await client.PutAsync(mUri, mContenido);

            }
            catch (Exception e) { throw e; }

            return mRespuesta.StatusCode;

        }

        public async Task<Planeta> getPlanetaDAL(int id)
        {
            Conexion mCon = new Conexion();
            HttpClient client = new HttpClient();
            String resultadoJSON;
            Uri uri = new Uri(mCon.Api + "/" + id);
            Planeta persona;

            try
            {
                resultadoJSON = await client.GetStringAsync(uri);
                client.Dispose();
                //JsonConvert
                persona = JsonConvert.DeserializeObject<Planeta>(resultadoJSON);


            }
            catch (Exception e) { throw e; }
            return persona;

        }
    }
}
