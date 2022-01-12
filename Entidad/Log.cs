using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class Log
    {
        [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string LogId { get; set; }
        public User UserLog { get; set; }
        public string LogName{get;set;}
    }
}