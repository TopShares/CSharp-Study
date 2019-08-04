using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SOA.WCF.Model
{
    [DataContract]
    public class WCFUser
    {
        //[DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int Sex { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }

    public enum WCFUserSex
    {
        Famale,
        Male,
        Other
    }
}
