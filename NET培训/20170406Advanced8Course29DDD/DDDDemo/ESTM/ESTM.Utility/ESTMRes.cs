using ESTM.Common.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ESTM.Utility
{
    [DataContract]
    public class ESTMRes<DTO> where DTO : DTO_BASEMODEL
    {
        public const string ERRCODE_SUCCESS = "0x0000";
        public const string PROP_ERRCODE = "errcode";
        public const string PROP_RES = "res";

        //常用属性
        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public DTO DTOModel { get; set; }

        [DataMember]
        public List<DTO> lstDTOModel { get; set; }


        [DataMember]
        public string SerialiseObj { get; set; }
        [DataMember]
        public List<string> SerialiseObjs { get; set; }

        [DataMember]
        public object SerialiseLst { get; set; }
        [DataMember]
        public string ErrCode { get { return this.m_strErrCode; } set { this.m_strErrCode = value; } }
        private string m_strErrCode = ERRCODE_SUCCESS;

        //取实体类的列表数据
        public List<T> GetEntityList<T>()
        {
            List<T> lstRes = new List<T>();
            if (SerialiseLst != null)
            {
                lstRes = (List<T>)SerialiseLst;
            }
            return lstRes;
        }

        ////常用方法
        //#region 序列化
        ////使用的是Newtonsoft.Json这个第三方的dll
        //public static string ObjToJsonStr<T>(T obj)
        //{
        //    string strRes = string.Empty;
        //    try
        //    {
        //        //将对象序列化为string
        //        strRes = JsonConvert.SerializeObject(obj);
        //    }
        //    catch { }

        //    return strRes;
        //}

        ////使用的是Newtonsoft.Json这个第三方的dll
        //public static List<string> ObjsToJsonLst<T>(List<T> lstObj)
        //{
        //    List<string> lstRes = new List<string>();
        //    try
        //    {
        //        foreach (var strObj in lstObj)
        //        {
        //            //将对象序列化为string
        //            var oRes = JsonConvert.SerializeObject(strObj);
        //            lstRes.Add(oRes);
        //        }
        //    }
        //    catch { }

        //    return lstRes;
        //}
        //#endregion

        //#region 反序列化
        ////使用的是Newtonsoft.Json这个第三方的dll
        //public static T JsonStrToObj<T>(string strJson)
        //{
        //    T oRes = default(T);
        //    try
        //    {
        //        //将string反序列化为对象
        //        oRes = JsonConvert.DeserializeObject<T>(strJson);
        //    }
        //    catch { }

        //    return oRes;
        //}

        ////使用的是Newtonsoft.Json这个第三方的dll
        //public static List<T> JsonLstToObjs<T>(List<string> lstJson)
        //{
        //    List<T> lstRes = new List<T>();
        //    try
        //    {
        //        foreach (var strObj in lstJson)
        //        {
        //            //将string反序列化为对象
        //            var oRes = JsonConvert.DeserializeObject<T>(strObj);
        //            lstRes.Add(oRes);
        //        }
        //    }
        //    catch { }

        //    return lstRes;
        //}

        ////使用的是Newtonsoft.Json这个第三方的dll
        //public static List<T> JsonStrToObjs<T>(string strJson)
        //{
        //    List<T> lstObj = new List<T>();
        //    try
        //    {
        //        lstObj = JsonConvert.DeserializeObject<List<T>>(strJson);
        //    }
        //    catch { }
        //    return lstObj;
        //}
        //#endregion
    }
}
