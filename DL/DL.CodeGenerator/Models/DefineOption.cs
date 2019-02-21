using System;
using System.Collections.Generic;
using System.Text;

namespace DL.CodeGenerator.Options
{
    public class DefineOption : DBOption
    {
        /// <summary>
        /// 作者
        /// </summary>
        public string Author { get; set; }

        /// <summary>
        /// 代码生成时间
        /// </summary>
        public string GeneratorTime { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 输出路径
        /// </summary>
        public string OutputPath { get; set; }

        /// <summary>
        /// 实体命名空间
        /// </summary>
        public string ModelsNamespace { get; set; }

        /// <summary>
        /// 仓储接口命名空间
        /// </summary>
        public string IRepositoryNamespace { get; set; }

        /// <summary>
        /// 仓储命名空间
        /// </summary>
        public string RepositoryNamespace { get; set; }

        /// <summary>
        /// 服务层接口命名空间
        /// </summary>
        public string IServiceNamespace { get; set; }

        /// <summary>
        /// 服务层命名空间
        /// </summary>
        public string ServiceNamespace { get; set; }
    }
}
