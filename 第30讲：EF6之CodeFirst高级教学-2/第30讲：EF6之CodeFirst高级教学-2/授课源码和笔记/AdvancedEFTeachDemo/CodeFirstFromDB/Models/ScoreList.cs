namespace CodeFirstFromDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScoreList")]
    public partial class ScoreList
    {
        [Key]
        public int SocreId { get; set; }

        public int StudentId { get; set; }

        public int? CSharp { get; set; }

        public int? SQLDB { get; set; }
    }
}
