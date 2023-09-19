using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ehr.Core.Data.Entities
{
    [Table("BASE_SYSTEM_USERS")]
    public class BASE_SYSTEM_USERS:BaseEntity
    {

        public int USERID { get; set; }
        
        public string USERNAME { get; set; }

        [Key]
        public string USERCODE { get; set; }
    }
}