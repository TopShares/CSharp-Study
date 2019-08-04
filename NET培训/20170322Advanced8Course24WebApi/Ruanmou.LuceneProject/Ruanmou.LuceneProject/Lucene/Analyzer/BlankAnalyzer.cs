using Lucene.Net.Analysis;
using System;
using System.IO;

namespace Lucene.Net.Analysis
{
    /// <summary>
    /// 空格分词器
    /// </summary>
    public class BlankAnalyzer : Analyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            return new BlankTokenizer(reader);
        }
        public override TokenStream ReusableTokenStream(string fieldName, TextReader reader)
        {
            Tokenizer tokenizer = (Tokenizer)this.PreviousTokenStream;
            if (tokenizer == null)
            {
                tokenizer = new BlankTokenizer(reader);
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
