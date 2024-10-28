using ProductOrder.Parameters;
using ProductOrder.Enums;
using ProductOrder.Attributes;
using System.Text.Json;
using System.Reflection;

namespace ProductOrder.Functions
{
    public static class CommonFunction
    {
        /// <summary>
        /// Tạo câu query phân trang
        /// </summary>
        public static string BuildPagingQuery(int? skip, int? take)
        {
            string query = string.Empty;

            if (skip == null)
            {
                skip = 0;
            }

            if (take == null)
            {
                take = 20;
            }

            query = $" LIMIT {take} OFFSET {skip * take}";

            return query;
        }

        /// <summary>
        /// Tạo câu lọc
        /// </summary>
        public static string BuildFilterString(FilterParameter filter, string alias = "A")
        {
            string query = string.Empty;

            if (filter == null)
            {
                return query;
            }

            if (!string.IsNullOrEmpty(alias))
            {
                alias += ".";
            }

            JsonElement? jsonElement = (JsonElement?)filter.Value;

            object value = GetSqlValue(jsonElement);

            query += $"({alias}{filter.Column} ";

            switch (filter.Operator)
            {
                case FilterOperatorEnum.Equal:
                    query += $"= {filter.Value}";
                    break;
                case FilterOperatorEnum.NotEqual:
                    query += $"<> {filter.Value}";
                    break;
                case FilterOperatorEnum.GreaterThan:
                    query += $"> {filter.Value}";
                    break;
                case FilterOperatorEnum.GreaterThanOrEqual:
                    query += $">= {filter.Value}";
                    break;
                case FilterOperatorEnum.LessThan:
                    query += $"< {filter.Value}";
                    break;
                case FilterOperatorEnum.LessThanOrEqual:
                    query += $"<= {filter.Value}";
                    break;
                case FilterOperatorEnum.IsNull:
                    query += $"IS NULL";
                    break;
                case FilterOperatorEnum.IsNotNull:
                    query += $"IS NOT NULL";
                    break;
                case FilterOperatorEnum.StartWith:
                    query += $"LIKE \"{filter.Value}%\"";
                    break;
                case FilterOperatorEnum.EndWith:
                    query += $"LIKE \"%{filter.Value}\"";
                    break;
                case FilterOperatorEnum.Contains:
                    query += $"LIKE \"%{filter.Value}%\"";
                    break;
                default:
                    break;
            }

            if (filter.Ors == null || filter.Ors.Count == 0)
            {
                return query + ")";
            }

            foreach (var or in filter.Ors)
            {
                query += "OR (";
                query += BuildFilterString(or);
                query += ")";
            }

            query += ")";

            return query;
        }

        /// <summary>
        /// Tạo câu query select 1 bản ghi
        /// </summary>
        public static string BuildSelectRecordQuery<T>(Guid id) where T : class
        {
            string tableName = GetTableName<T>();

            PropertyInfo keyProperty = GetKeyProperty<T>();

            string query = $"SELECT * FROM {tableName} WHERE {keyProperty.Name} = N'{id}'";

            return query;
        }

        /// <summary>
        /// Tạo câu query lọc
        /// </summary>
        public static string BuildFilterQuery(List<FilterParameter> filters, string alias = "")
        {
            string query = string.Empty;

            if (filters == null || filters.Count == 0)
            {
                return query;
            }

            foreach (FilterParameter filter in filters)
            {
                if (filter == null || string.IsNullOrEmpty(filter.Column))
                {
                    continue;
                }

                if (filter == filters.First())
                {
                    query += $" WHERE ";
                }
                else
                {
                    query += $" AND ";
                }

                query += BuildFilterString(filter, alias);
            }

            return query;
        }

        /// <summary>
        /// Tạo câu query select
        /// </summary>
        public static string BuildSelectQuery<T>(PagingParameter parameter, string alias = "") where T : class
        {
            string query = string.Empty;

            if (parameter == null)
            {
                return query;
            }

            Type type = typeof(T);

            string tableName = GetTableName<T>();

            query += "SELECT ";

            string columnAlias = string.Empty;

            if (!string.IsNullOrEmpty(alias))
            {
                columnAlias = $"{alias}.";
            }

            foreach (string column in parameter.Columns)
            {
                if (column == parameter.Columns.First())
                {
                    query += $"{columnAlias}{column}";
                }
                else
                {
                    query += $", {columnAlias}{column}";
                }
            }

            query += $" FROM {tableName}";

            if (!string.IsNullOrEmpty(alias))
            {
                query += $"AS {alias}";
            }

            query += BuildFilterQuery(parameter.Filters, alias);
            query += BuildPagingQuery(parameter.Skip, parameter.Take);

            return query;
        }

        /// <summary>
        /// Lấy tên bảng
        /// </summary>
        public static string GetTableName<T>() where T : class
        {
            var tableAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;

            if (tableAttribute == null || string.IsNullOrEmpty(tableAttribute.Name))
            {
                throw new Exception("Chưa khai báo thuộc tính tên bảng");
            }

            return tableAttribute.Name;
        }

        /// <summary>
        /// Lấy giá trị sql theo jsonelement
        /// </summary>
        public static object? GetSqlValue(JsonElement? jsonElement)
        {
            if (jsonElement == null)
            {
                return null;
            }

            var jsonElementNotNull = (JsonElement)jsonElement;

            switch (jsonElementNotNull.ValueKind)
            {
                case JsonValueKind.String:
                    return $"N'{jsonElementNotNull.GetString()}'";
                case JsonValueKind.Number:
                    return jsonElementNotNull.GetDecimal();
                default:
                    return $"{jsonElementNotNull}";
            }
        }

        /// <summary>
        /// Tạo câu query thêm mới
        /// </summary>
        public static string BuildInsertQuery<T>(T item) where T : class
        {
            string query = String.Empty;

            if (item == null)
            {
                return query;
            }

            Type type = typeof(T);

            string tableName = GetTableName<T>();

            query += $"INSERT INTO {tableName} (";

            List<PropertyInfo> properties = type.GetProperties().ToList();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(item);

                if (value == null)
                {
                    continue;
                }

                if (property == properties.First())
                {
                    query += property.Name;
                }
                else
                {
                    query += $", {property.Name}";
                }
            }
            query += ") VALUES (";

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(item);

                if (value == null)
                {
                    continue;
                }

                value = GetSqlValue(value, property.PropertyType);

                Type? typeProperty = Nullable.GetUnderlyingType(property.GetType());

                if (property == properties.First())
                {
                    query += $"{value}";
                }
                else
                {
                    query += $", {value}";
                }
            }

            query += ")";

            return query;
        }

        /// <summary>
        /// Lấy dữ liệu Sql từ type
        /// </summary>
        public static object GetSqlValue(object? value, Type propertyType)
        {
            if (value == null)
            {
                return "NULL";
            }

            Type? type = Nullable.GetUnderlyingType(propertyType);

            if (type != null)
            {
                propertyType = type;
            }

            if (propertyType == typeof(string) || propertyType == typeof(Guid))
            {
                return $"N'{value}'";
            }

            return value;
        }

        /// <summary>
        /// Tạo câu query cập nhật
        /// </summary>
        public static string BuildUpdateQuery<T>(T item) where T : class
        {
            string query = String.Empty;

            if (item == null)
            {
                return query;
            }

            Type type = typeof(T);

            string tableName = GetTableName<T>();

            PropertyInfo keyProp = GetKeyProperty<T>();

            query += $"UPDATE {tableName} SET ";

            List<PropertyInfo> properties = type.GetProperties().ToList();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(item);

                if (value == null)
                {
                    continue;
                }

                value = GetSqlValue(value, property.PropertyType);

                if (property == properties.First())
                {
                    query += $"{property.Name} = {value}";
                }
                else
                {
                    query += $", {property.Name} = {value}";
                }
            }

            object keyValue = keyProp.GetValue(item);

            keyValue = GetSqlValue(keyValue, keyProp.PropertyType);

            query += $" WHERE {keyProp.Name} = {keyValue}";

            return query;
        }

        /// <summary>
        /// Lấy tên trường khóa
        /// </summary>
        public static PropertyInfo GetKeyProperty<T>() where T : class
        {
            PropertyInfo prop = typeof(T).GetProperties()
                                .ToList()
                                .FirstOrDefault(f => Attribute.IsDefined(f, typeof(KeyAttribute)));

            if (prop == null)
            {
                throw new Exception("Chưa khai báo thuộc tính khóa");
            }

            return prop;
        }

        /// <summary>
        /// Xóa nhiều bản ghi
        /// </summary>
        public static string BuildDeleteQuery<T>(List<string> ids) where T : class
        {
            string query = string.Empty;

            if (ids == null || ids.Count == 0)
            {
                return query;
            }

            string tableName = GetTableName<T>();

            PropertyInfo keyProperty = GetKeyProperty<T>();

            query += $"DELETE FROM {tableName} WHERE {keyProperty.Name} IN (";

            foreach (string id in ids)
            {
                if (id == ids.First())
                {
                    query += $"N'{id}'";
                }
                else
                {
                    query += $", N'{id}'";
                }
            }

            query += ")";

            return query;
        }
    }
}
