namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ScoreList")]
    public partial class ScoreList
    {
        public int Id { get; set; }

        public int StudentId { get; set; }

        public int? CSharp { get; set; }

        public int? SQLServerDB { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime UpdateTime { get; set; }

        public virtual Students Students { get; set; }
    }
}
