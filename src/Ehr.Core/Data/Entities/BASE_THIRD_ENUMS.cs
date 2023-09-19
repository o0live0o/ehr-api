using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ehr.Core.Data.Entities
{
    [Table("BASE_THIRD_ENUMS")]
    public class BASE_THIRD_ENUMS : BaseEntity
    {
        [Key]
        public int KeyId { get; set; }

        public string TypeName { get; set; }

        public string EHRCode { get; set; }

        public string EHRName { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Remark { get; set; }

    }
}