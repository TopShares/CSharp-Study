using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Common.DtoModel
{

	/// <summary>
    /// TB_ROLE
    /// </summary>
	[DataContract]
    public class DTO_TB_ROLE : DTO_BASEMODEL
	{
		/// <summary>
        /// 角色ID
        /// </summary>
		[DataMember]
		public string ROLE_ID { get; set; }
		/// <summary>
        /// 角色名称
        /// </summary>
		[DataMember]
		public string ROLE_NAME { get; set; }
		/// <summary>
        /// 角色描述
        /// </summary>
		[DataMember]
		public string DESCRIPTION { get; set; }
		/// <summary>
        /// 创建日期
        /// </summary>
		[DataMember]
		public Nullable<DateTime> CREATETIME { get; set; }
		/// <summary>
        /// 修改日期
        /// </summary>
		[DataMember]
		public Nullable<DateTime> MODIFYTIME { get; set; }
		/// <summary>
        /// 默认页面
        /// </summary>
		[DataMember]
		public string ROLE_DEFAULTURL { get; set; }
	}
}