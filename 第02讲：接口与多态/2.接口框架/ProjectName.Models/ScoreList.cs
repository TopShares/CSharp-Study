using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectName.Models
{
    [Serializable]
    public class ScoreList
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CSharp { get; set; }
        public int SQLServerDB { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
