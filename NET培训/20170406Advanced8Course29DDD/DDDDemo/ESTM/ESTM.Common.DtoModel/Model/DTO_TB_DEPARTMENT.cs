using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Common.DtoModel
{
	/// <summary>
    /// TB_DEPARTMENT
    /// </summary>
	[DataContract]
    public class DTO_TB_DEPARTMENT : DTO_BASEMODEL
	{
        [DataMember]
		public string DEPARTMENT_ID { get; set; }

        [DataMember]
		public string DEPARTMENT_NAME { get; set; }

        [DataMember]
		public string PARENT_ID { get; set; }

        [DataMember]
		public string DEPARTMENT_LEVEL { get; set; }

        [DataMember]
		public string STATUS { get; set; }
	}
}