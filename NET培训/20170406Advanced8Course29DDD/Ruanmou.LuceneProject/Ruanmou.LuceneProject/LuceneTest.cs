using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Ruanmou.LuceneProject.Interface;
using Ruanmou.LuceneProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Ruanmou.LuceneProject
{
    /// <summary>
    /// lucene show
    /// </summary>
    public class LuceneTest
    {
        private static string TestIndexPath = ConfigurationManager.AppSettings["TestIndexPath"];
        public static void Show()
        {
            FSDirectory dir = FSDirectory.Open(TestIndexPath);
            IndexSearcher searcher = new IndexSearcher(dir);//查找器
            {
                TermQuery query = new TermQuery(new Term("title", "英文"));//包含
                TopDocs docs = searcher.Search(query, null, 10000);//找到的数据
                foreach (ScoreDoc sd in docs.ScoreDocs)
                {
                    Document doc = searcher.Doc(sd.Doc);
                    Console.WriteLine(string.Format("{0} {1}  {2} id={3}", doc.Get("title"), doc.Get("time"), doc.Get("price"), doc.Get("id")));
                }
                Console.WriteLine("1一共命中了{0}个", docs.TotalHits);
            }

            QueryParser parser = new QueryParser(Lucene.Net.Util.Version.LUCENE_30, "title", new PanGuAnalyzer());//解析器
            {
                string keyword = "旧时光咖啡打几个给答复是加快了高科技打瞌睡了加工费拉的方式及规范了卡迪夫空间是梵蒂冈加工费";
                //string keyword = "旧时光 咖啡 打几个 给答复 是加快了 高科技 打瞌睡 了加工费 拉的方式及规范了卡迪夫空间是梵蒂冈加工费";
                Query query = parser.Parse(keyword);
                {
                    TopDocs docs = searcher.Search(query, null, 10000);//找到的数据
                    foreach (ScoreDoc sd in docs.ScoreDocs)
                    {
                        Document doc = searcher.Doc(sd.Doc);
                        Console.WriteLine(string.Format("{0} {1}  {2} id={3}", doc.Get("title"), doc.Get("time"), doc.Get("price"), doc.Get("id")));
                    }
                    Console.WriteLine("2一共命中了{0}个", docs.TotalHits);
                }
                {
                    NumericRangeFilter<int> timeFilter = NumericRangeFilter.NewIntRange("time", 20150000, 20151822, true, true);//过滤
                    SortField sortPrice = new SortField("price", SortField.DOUBLE, false);//降序
                    SortField sortTime = new SortField("time", SortField.INT, true);//升序
                    Sort sort = new Sort(sortPrice, sortTime);//排序

                    TopDocs docs = searcher.Search(query, timeFilter, 10000, sort);//找到的数据
                    string result = "";
                    foreach (ScoreDoc sd in docs.ScoreDocs)
                    {
                        Document doc = searcher.Doc(sd.Doc);
                        Console.WriteLine(string.Format("{0} {1} {2} id={3}", doc.Get("title"), doc.Get("time"), doc.Get("price"), doc.Get("id")));
                        if (doc.Get("title").Contains("金币卡"))
                        {
                            result += doc.Get("title");
                        }
                    }
                    Console.WriteLine("3一共命中了{0}个", docs.TotalHits);
                    //Console.WriteLine("result={0}", result);
                }
            }


        }

        /// <summary>
        /// 初始化索引
        /// </summary>
        public static void InitIndex()
        {
            FSDirectory directory = FSDirectory.Open(TestIndexPath);//文件夹
            using (IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), true, IndexWriter.MaxFieldLength.LIMITED))//索引写入器
            {
                for (int i = 0; i < 10000; i++)
                {
                    Document doc = new Document();//一条数据
                    doc.Add(new Field("id", i.ToString(), Field.Store.NO, Field.Index.NOT_ANALYZED));//一个字段  列名  值   是否保存值  是否分词
                    doc.Add(new Field("title", TitleArray[i % TitleArray.Length] + i, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("content", "this is lucene working,powerful tool " + i, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new NumericField("price", Field.Store.YES, true).SetDoubleValue(0.0001 * new Random().Next(20140000, 20141231)));
                    doc.Add(new NumericField("time", Field.Store.YES, true).SetIntValue(20150000 + i));
                    writer.AddDocument(doc);//写进去
                }
                writer.Optimize();//优化  就是合并
            }
        }



        private static string AnalyzerKeyword(string keyword)
        {
            StringBuilder queryStringBuilder = new StringBuilder();
            ILuceneAnalyze analyzer = new LuceneAnalyze();
            string[] words = analyzer.AnalyzerKey(keyword);
            if (words.Length == 1)
            {
                queryStringBuilder.AppendFormat("{0}:{1}* ", "title", words[0]);
            }
            else
            {
                StringBuilder fieldQueryStringBuilder = new StringBuilder();
                foreach (string word in words)
                {
                    queryStringBuilder.AppendFormat("{0}:{1} ", "title", word);
                }
            }
            string result = queryStringBuilder.ToString().TrimEnd();
            Console.WriteLine("AnalyzerKeyword 将 keyword={0}转换为{1}", keyword, result);
            return result;
        }

        #region 一些数据

        private static string[] TitleArray = new string[] {
                "想简简单单的活着"
                ,"苍老师是中国的 "
                ,"Lucene.net并不是一个爬行搜索引擎，也不会自动地索引内容"
                ,"追梦者"
                ,"源字符串首先经过analyzer处理，包括：分词，分成一个个单词；去除stopword（可选）。"
                ,"将源中需要的信息加入Document的各个Field中，并把需要索引的Field索引起来，把需要存储的Field存储起来。",
                "    将索引写入存储器，存储器可以是内存或磁盘。","冲杯三鹿给党喝","没问题","7302020","在这里分享一下商业人像精修的心得，或者说是思路，因为有了思路才能定下具体的后期方向。","小叉","标准的步骤是先初始化一个Analyzer、打开一个IndexWriter、然后再将文档一个接一个地加进去。","AQ","/生气/输啦/雪花真的猛士敢于面对惨淡的人生，敢于正视淋漓的鲜血","蛮子","吃饭","冲杯三鹿给党喝","蛮三刀","一剑","肚子有问题了",
                "小叉","一旦完成这些步骤，索引就可以在关闭前得到优化，同时所做的改变也会生效。","爱你狠伤-(60-爱你狠伤-男)","nopcommerce是国外的一个高质量的开源b2c网站系统","清光(110-清光-男)","Spread支持 85 种丰富多彩的图表效果。基于工作表的数据直接生成图表，操作简单。同时，软件人员还可以在Visual Studio设计环境中定制图表的所有元素，包括标题、序列、轴、样","式、图例等","小叉","这个过程可能比开发者习惯的方式更加手工化一些，但却在数据的索引上给予你更多的灵活性，而且其效率也很高。","帘外月朦明","本页设置单机的MAC地址和IP地址的匹配规则","ya丶丨誓言ぃ ","太棒了","Miss💯君叶","求妹纸","SuMMer丶(SuMMer)","红塔山","小新是也(软谋-小新)","我选择沉默","啊啊a","同意","◎.昱瞳寒夜"," 傲之追猎者 雷恩加尔&影流之主 劫已于4月14日解禁，如之前公告，我们将向所有补偿范围内的玩家补偿“4胜金币卡一张”。如果您同时属于两个英雄的补偿范围，将可以获得2张“4胜金","币卡”","只想简简单单的活着","阿帕奇？","謹記妳容顏(黄慧嫦)","E神威武霸气","什么也不是(什么也不是)","微信公众号","只想简简单单的活着","最强直升机？","SuMMer丶(SuMMer)","吸烟有害健康  今早戒烟有益健康","希望大溪(32-希望大溪-男)","习大大想干什么","小叉","","低调(低调)","好孤独啊,还是听课比较实,不想上班,不想上班,不想上班,重要的事情说3遍","Run","抽查显示全国人口超13.73亿 男女性别比下降" ,"原来是你的问题，不是我的事。。。哈哈"
                ,"发了个电磁脉冲弹"
                ,"上面有我的名字，说明我上期说过了"
                ,"放大四平【 u佛典范欧IP大事记哦你发票骄傲的司法部分顾客了【旧时光咖啡打几个给答复是加快了高科技打瞌睡了加工费拉的方式及规范了卡迪夫空间是梵蒂冈加工费"
                ,"Lucene是apache软件基金会4 jakarta项目组的一个子项目，是一个开放源代码的全文检索引擎工具包，即它不是一个完整的全文检索引擎，而是一个全文检索引擎的架构，提供","了,完整的查询引擎和索引引擎，部分文本分析引擎（英文与德文两种西方语言）。Lucene的目的是为软件开发人员提供一个简单易用的工具包，以方便的在目标系统中实现全文检索,的功能，或者是以此为基础建立起完整的全文检索引擎。"
                ,"我家儿子在用手机玩游戏，还带自己下载地，牛不牛呀"
                ,"我的网名是：微笑向暖，landon是我的英文名，大家平时都叫我landon"
                ,"为了艾泽拉斯"
                ,"莲花未开时"
                ,"快，胖大海顶上。老师晕倒了。师娘要悠着点，老师吃不消了。"
                ,"好困好困啊 我左手边又瓶加多宝 我鼠标键盘都会发光 很厉害"
                ,"遗忘的过去也是一种财富 必须从中挖掘出属于自己的那一份 只有在现实与过去相互对比的过程中我们才能拥有未来"
                ,"诺福克郡北诺福克地区政务委员会的负责人称，引入的山羊就像免费的除草剂，它们会啃食所有多余的灌木，减少杂草，从而改善景区植被质量。但是事实上，山羊似乎并不能区分杂,草和珍稀品种，它们对植被来者不拒，几乎啃食了整个悬崖上的植被，包括罕见的野生花卉、迷人的灌木丛甚至篱笆。"
                ,"新京报快讯(记者贾世煜)今日下午，记者从国防科工局获悉，嫦娥三号着陆器于7月28日按时进入第33月夜休眠期，再次刷新国际探测器月面工作时间最长纪录。在此前的33个月昼工,作期间，嫦娥三号开展了“测月、巡天、观地”科学探测，取得了大量科学数据。"
                ,"今天又要下雨了，好冷，买的电风扇到现在还没用啊。哈哈，羡慕我吧！！！！！"
                ,"在公司是太热阿 空调坏了"
                ,"中国南海菲律宾水果批发市场"
                ,"China Joy"
                ,"有组织无纪律"
                ,"间隔5个字，是5个汉字还是5个英文啊"
                ,"MongoDB[2]  是一个介于关系数据库和非关系数据库之间的产品，是非关系数据库当中功能最丰富，最像关系数据库的。他支持的数据结构非常松散，是类似json的bson格式，因此,可以存储比较复杂的数据类型。Mongo最大的特点是他支持的查询语言非常强大，其语法有点类似于面向对象的查询语言，几乎可以实现类似关系数据库单表查询的绝大部分功=能，,而且还支持对数据建立索引。[3] "
                ,"lucene是不是类似一个数据库的形式"
                ,"管理软件开发"
                ,"老师要保重身体，尽量学习丹田发音，保护喉咙。老师喝口水吧"
                ,"莲花未开时"
                ,"公司太热 同事的的裤子坏了。"
                ,"微笑的汤圆"
                ,"应该是感冒了"
                ,"一剑封尘"
                ,"7月28日，交通运输部正式发布的《网络预约出租汽车经营服务管理暂行办法》（以下简称《办法》）。《办法》删除了征求意见稿中对网约车辆“使用性质登记为出租客运”的要求，,而是表示要按地方标准审核后，“符合条件的车辆登记为预约出租客运，并发放《预约出租汽车运输证》。”"
                ,"落单的候鸟"
                ,"upika了。没审核隐了。"
                ,"看，这个世界"
                ,"少用 暗规则太多、学习成本大的插件或框架。 少写 让别人看不懂、让自己看不懂的代码。 少做 让使用者用户不知所措，非要解释半天才明白的的功能。"
                ,"Ken@SZX(Ken)"
                ,"南海是中国的，台湾也是中国的"
                ,"落单的候鸟"
                ,"没声音呢、、"
                ,"♡木云得"
                ,"我也听不到"
                ,"黑色泉沙"
                ,"鬼厉身形掠去，耳边还传来鬼先生那怪异的呼喊声，心中也是为之惊疑不定。这十年来鬼先生在鬼王宗内神秘莫测，但一身道行和见识学问，连他也要忌惮几分，不料今日竟变作这般怪样。正思索间，他身形何等之快，眼看就要掠到洞口离开这疯狂的血池洞窟"
                ,"lucene索引建立和查询DEMO"
                ,"索引增删改查和分词处理"
                ,"针对京东数据建立索引和查询接口"
                ,"作业部署"
                  };

        #endregion
    }
}
