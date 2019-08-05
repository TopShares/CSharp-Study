﻿using System;
using ORM.Common;

namespace ORM.Models
{
    ///// <summary>
    ///// 学员实体类
    ///// </summary>
    //[Serializable]
    //public class Students
    //{
    //    /// <summary>
    //    /// 给StudentId增加了标识列和主键列属性
    //    /// </summary>
    //    [Identity]
    //    [PrimaryKey]
    //    public int StudentId { get; set; }

    //    #region 普通属性

    //    public string StudentName { get; set; }
    //    public DateTime Birthday { get; set; }
    //    public string Gender { get; set; }
    //    public string StudentIdNo { get; set; }
    //    public int Age { get; set; }
    //    public string StuImage { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public string StudentAddress { get; set; }
    //    public string CardNo { get; set; }
    //    public int ClassId { get; set; }

    //    #endregion

    //    //以下三个属性，都表示非数据库映射字段
    //    [NonTable]
    //    public string ClassName { get; set; }
    //    [NonTable]
    //    public string CSharp { get; set; }
    //    [NonTable]
    //    public string SQLServerDB { get; set; }
    //}

    /// <summary>
    /// 学员实体类（添加特性验证）
    /// </summary>
    [Serializable]
    public class Students
    {
        /// <summary>
        /// 给StudentId增加了标识列和主键列属性
        /// </summary>
        [Identity]
        [PrimaryKey]
        public int StudentId { get; set; }

        #region 普通属性

        [Required("学员姓名")]
        public string StudentName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }

        [FixedLength("身份证号", 18)]
        public string StudentIdNo { get; set; }

        [Range("学员年龄", 18, 25)]
        public int Age { get; set; }
        public string StuImage { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentAddress { get; set; }
        public string CardNo { get; set; }
        public int ClassId { get; set; }

        #endregion

        //以下三个属性，都表示非数据库映射字段
        [NonTable]
        public string ClassName { get; set; }
        [NonTable]
        public string CSharp { get; set; }
        [NonTable]
        public string SQLServerDB { get; set; }
    }
}
