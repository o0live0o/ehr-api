using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ehr.Core.Data.Entities
{
    [Table("BASE_PARAMETER_ENUMVALUE")]
    [Keyless]
    public class BASE_PARAMETER_ENUMVALUE:BaseEntity
    {

        /// <summary>
        /// 获取或设置SENUMVALUE
        /// </summary>
        public string SENUMVALUE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置NDISPINDEX
        /// </summary>
        public int NDISPINDEX
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ISACTIVE
        /// </summary>
        public int ISACTIVE
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SENUMID
        /// </summary>
        public int SENUMID
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SENUMVALUENAME
        /// </summary>
        public string SENUMVALUENAME
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置ISDEFAULT
        /// </summary>
        public int ISDEFAULT
        {
            get;
            set;
        }

        /// <summary>
        /// 获取或设置SENUMTYPE
        /// </summary>
        public string SENUMTYPE
        {
            get;
            set;
        }
    }
}
