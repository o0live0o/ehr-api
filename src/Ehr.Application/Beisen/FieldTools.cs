using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ehr.Application.Beisen.Recruit.Dtos;
using Ehr.Core.Aop.Attriutes;
using Ehr.Core.Data.Entities;
using Ehr.Core.IRepository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Ehr.Application.Beisen
{
    public abstract class FieldTools
    {
        private static List<BASE_THIRD_ENUMS> _enums = new List<BASE_THIRD_ENUMS>();

        private static ILogger _logger = null;

        public static void SetEnums(BASE_THIRD_ENUMS[] enums)
        {
            _enums.Clear();
            _enums.AddRange(enums);
        }

        public static void SetLogger(ILogger logger)
        {
            _logger = logger;
        }

        public static List<TDst> FillEhrFieldList<TDst>(List<List<PropertyDto>> propertyDtos) where TDst : class
        {
            List<TDst> list = new List<TDst>();
            foreach (var item in propertyDtos)
            {
                list.Add(FillEhrField<TDst>(item));
            }
            return list;
        }

        public static TDst FillEhrField<TDst>(List<PropertyDto> propertyDtos) where TDst : class
        {
            List<string> errors = new List<string>();
            var dst = Activator.CreateInstance<TDst>();
            var props = typeof(TDst).GetProperties().Where(p => p.GetCustomAttributes(typeof(ExFieldAttribute), false).FirstOrDefault() != null);
            var attName = "NONE";
            PropertyDto dto = null;
            foreach (var propertyInfo in props)
            {
                try
                {
                    var attr = propertyInfo.GetCustomAttributes(typeof(ExFieldAttribute), false).FirstOrDefault() as ExFieldAttribute;
                    if (string.IsNullOrEmpty(attr.ExName)) continue;

                    attName = attr.ExName;

                    dto = propertyDtos.Where(p => p.PropertyName.ToLower().Equals(attr.ExName.ToLower())).FirstOrDefault();

                    if (dto == null) continue;

                    object val = dto.Value;


                    if (!string.IsNullOrEmpty(attr.FieldType))
                        val = GetEhrEnumByCode(attr, dto.Code) ?? val;

                    SetVal(dst, propertyInfo, val);
                }
                catch
                {
                    errors.Add($"[{attName}({dto?.Value ?? "NULL"})  to {propertyInfo.Name} ]");
                }
            }

            if (errors.Count > 0)
                _logger.LogError($"{typeof(TDst).Name} {string.Join(',', errors.ToArray())} 转换失败!");

            return dst;
        }

        public static void FillEhrField<TDst>(TDst dst, Extendinfo[] propertyDtos)
        {
            var props = typeof(TDst).GetProperties().Where(p => p.GetCustomAttributes(typeof(ExFieldAttribute), false).FirstOrDefault() != null);
            List<string> errors = new List<string>();
            string attrName = "NONE";

            foreach (var propertyInfo in props)
            {
                Extendinfo dto = null;
                try
                {
                    var attr = propertyInfo.GetCustomAttributes(typeof(ExFieldAttribute), false).FirstOrDefault() as ExFieldAttribute;
                    if (string.IsNullOrEmpty(attr.ExName)) continue;

                    attrName = attr.ExName;

                    dto = propertyDtos.Where(p => p.Name.ToLower().Equals(attr.ExName.ToLower())).FirstOrDefault();

                    if (dto == null) continue;

                    object val = dto.Value;

                    if (!string.IsNullOrEmpty(attr.FieldType))
                        val = GetEhrEnumByCode(attr, dto.Value) ?? val;

                    SetVal(dst, propertyInfo, val);
                }
                catch
                {
                    errors.Add($"[{attrName}({dto?.Value ?? "NULL"}) to {propertyInfo.Name} ]");
                }
            }
            if (errors.Count > 0)
                _logger.LogError($"{typeof(TDst).Name} {string.Join(',', errors.ToArray())} 转换失败!");
        }

        private static void SetVal<TDst>(TDst dst, PropertyInfo propertyInfo, object val)
        {
            if (!propertyInfo.PropertyType.IsGenericType)
            {
                propertyInfo.SetValue(dst, val == null ? null : Convert.ChangeType(val, propertyInfo.PropertyType), null);
            }
            else
            {
                Type genericTypeDefinition = propertyInfo.PropertyType.GetGenericTypeDefinition();
                if (genericTypeDefinition == typeof(Nullable<>))
                {
                    propertyInfo.SetValue(dst, val == null ? null : Convert.ChangeType(val, propertyInfo.PropertyType.GetGenericArguments()[0]), null);
                }
            }
        }


        private static object GetEhrEnumByCode(ExFieldAttribute attr, string code)
        {
            var @enum = _enums.Where(p => p.TypeName.Equals(attr.FieldType) && p.Code.Equals(code)).FirstOrDefault();
            object val = null;

            if (attr.Val == 1)
                val = @enum?.EHRCode;
            else
                val = @enum?.EHRName;

            if (val == null) val = attr.Default;

            return val;
        }


        private static object GetEhrEnumByName(ExFieldAttribute attr, string name)
        {
            var @enum = _enums.Where(p => p.TypeName.Equals(attr.FieldType) && p.Name.Equals(name)).FirstOrDefault();
            object val = null;

            if (attr.Val == 1)
                val = @enum?.EHRCode;
            else
                val = @enum?.EHRName;

            if (val == null) val = attr.Default;

            return val;
        }

    }
}