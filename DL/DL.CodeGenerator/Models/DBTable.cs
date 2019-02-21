using System;
using System.Collections.Generic;
using System.Text;

namespace DL.CodeGenerator.Models
{
    /// <summary>
    /// 数据库中表属性
    /// </summary>
    [Serializable]
    public class DBTable
    {
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 表说明
        /// </summary>
        public string TableComment { get; set; }
        /// <summary>
        /// 字段集合
        /// </summary>
        public virtual List<DBTableColumn> Columns { get; set; } = new List<DBTableColumn>();
    }
}
