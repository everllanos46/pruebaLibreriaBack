using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class User
    {
        [Key]
        public string usuario { get; set; }
        public string passwordd { get; set; }
        public string Tokenn { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
    }
}