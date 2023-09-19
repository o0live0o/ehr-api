using System;

namespace Ehr.Core.Aop.Attriutes
{
    public class ExFieldAttribute : Attribute
    {
        private string _exName { get; set; }

        private string _fieldType { get; set; }

        private object _default { get; set; }

        private int _val { get; set; }


        /// <summary>
        /// 标记外部实体映射字段
        /// </summary>
        /// <param name="exName">外部实体字段名称</param>
        /// <param name="fieldType">类型</param>
        /// <param name="default">默认值</param>
        /// <param name="val">1 - 获取Code 2-获取Name</param>
        public ExFieldAttribute(string exName, string fieldType = "", object @default = null, int val = 1)
        {
            this._exName = exName;
            this._fieldType = fieldType;
            this._default = @default;
            this._val = val;
        }

        public string ExName { get => _exName; }
        public string FieldType { get => _fieldType; }
        public object Default { get => _default; }
        public int Val { get => _val; }

    }
}