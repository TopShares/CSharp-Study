using Lucene.Net.Util;
using System;
using System.IO;

namespace Lucene.Net.Analysis
{
    public class CommaTokenizer : CharTokenizer
    {
        public CommaTokenizer(TextReader in_Renamed)
            : base(in_Renamed)
        {
        }
        public CommaTokenizer(AttributeSource source, TextReader in_Renamed)
            : base(source, in_Renamed)
        {
        }
        public CommaTokenizer(AttributeSource.AttributeFactory factory, TextReader in_Renamed)
            : base(factory, in_Renamed)
        {
        }
        protected override bool IsTokenChar(char c)
        {
            return c != ',';
        }
    }
}
