using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Common.DtoModel
{
    [DataContract]
    public class DTO_TB_USERS : DTO_BASEMODEL
    {
        [DataMember]
        public string USER_ID { get; set; }

        [DataMember]
        public string USER_NAME { get; set; }

        [DataMember]
        public string USER_PASSWORD { get; set; }

        [DataMember]
        public string FULLNAME { get; set; }

        [DataMember]
        public string DEPARTMENT_ID { get; set; }

        [DataMember]
        public string STATUS { get; set; }

        [DataMember]
        public Nullable<System.DateTime> CREATETIME { get; set; }

        [DataMember]
        public Nullable<System.DateTime> MODIFYTIME { get; set; }

        [DataMember]
        public string REMARK { get; set; }
    }
}
