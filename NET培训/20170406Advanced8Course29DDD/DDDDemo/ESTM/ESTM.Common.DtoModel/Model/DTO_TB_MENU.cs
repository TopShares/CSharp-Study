using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Common.DtoModel
{
	/// <summary>
    /// TB_MENU
    /// </summary>
	[DataContract]
    public class DTO_TB_MENU : DTO_BASEMODEL
	{
		/// <summary>
        /// 菜单ID
        /// </summary>
		[DataMember]
		public string MENU_ID { get; set; }
		/// <summary>
        /// 菜单名称
        /// </summary>
		[DataMember]
		public string MENU_NAME { get; set; }
		/// <summary>
        /// 菜单URL
        /// </summary>
		[DataMember]
		public string MENU_URL { get; set; }
		/// <summary>
        /// 父级菜单
        /// </summary>
		[DataMember]
		public string PARENT_ID { get; set; }
		/// <summary>
        /// 菜单级别
        /// </summary>
		[DataMember]
		public string MENU_LEVEL { get; set; }
		/// <summary>
        /// 排序
        /// </summary>
		[DataMember]
		public string SORT_ORDER { get; set; }
		/// <summary>
        /// 状态
        /// </summary>
		[DataMember]
		public string STATUS { get; set; }
		/// <summary>
        /// 备注
        /// </summary>
		[DataMember]
		public string REMARK { get; set; }
		/// <summary>
        /// 菜单图标名称
        /// </summary>
		[DataMember]
		public string MENU_ICO { get; set; }
	}
}