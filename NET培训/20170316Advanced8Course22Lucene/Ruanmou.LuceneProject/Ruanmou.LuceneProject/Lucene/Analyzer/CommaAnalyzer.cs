using System;
using System.IO;

namespace Lucene.Net.Analysis
{
    /// <summary>
    /// 逗号分词器
    /// </summary>
    public class CommaAnalyzer : Analyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            return new CommaTokenizer(reader);
        }
        public override TokenStream ReusableTokenStream(string fieldName, TextReader reader)
        {
            Tokenizer tokenizer = (Tokenizer)this.PreviousTokenStream;
            if (tokenizer == null)
            {
                tokenizer = new CommaTokenizer(reader);
                this.PreviousTokenStream = tokenizer;
            }
            else
            {
                tokenizer.Reset(reader);
            }
            return tokenizer;
        }
    }
}
