using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entidad;
namespace Logica
{
    public class Response <T>
    {
        public Response(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }

        public Response(T entity, string mensaje)
        {
            Error = false;
            Object = entity;
            Mensaje = mensaje;
        }

        public Response(List<T> entity, string mensaje)
        {
            Error = false;
            Objects = entity;
            Mensaje = mensaje;
        }

        public bool Error { get; set; }
        public string? Mensaje { get; set; }
        public T? Object { get; set; }
        public List<T>? Objects { get; set; }
    }
}