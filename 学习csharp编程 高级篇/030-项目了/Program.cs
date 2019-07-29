using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _030_项目了 {
    class Program {
        static void Main(string[] args) {
            //创建技能信息集合，用来存储所有的技能信息
            List<Skill> skillList = new List<Skill>();

            // XmlDocment专门用来解析xml文档的
            XmlDocument xmlDoc = new XmlDocument();
            //选择要加载解析的xml文档的名字
            //xmlDoc.Load("skillinfo.txt");
            xmlDoc.LoadXml(  File.ReadAllText("skillinfo.txt") );//传递一个字符串（xml格式的字符串）

            //得到根结点 (xmlnode用来代表一个结点)
            XmlNode rootNode = xmlDoc.FirstChild;//获取第一个结点 
            
            //得到根结点下面的子节点的集合
            XmlNodeList skillNodeList=  rootNode.ChildNodes;//获取当前结点下面的所有子节点

            foreach (XmlNode skillNode in skillNodeList)
            {
                Skill skill = new Skill();
                XmlNodeList fieldNodeList = skillNode.ChildNodes;//获取skill结点下面所有的结点 
                foreach (XmlNode fieldNode in fieldNodeList)
                {
                    if (fieldNode.Name == "id")//通过Name属性 可以获取一个结点的名字
                    {
                        int id = Int32.Parse(fieldNode.InnerText);//获取结点内部的文本
                        skill.Id = id;
                    }else if (fieldNode.Name == "name")
                    {
                        string name = fieldNode.InnerText;
                        skill.Name = name;
                        skill.Lang = fieldNode.Attributes[0].Value;
                    }
                    else
                    {
                        skill.Damage = Int32.Parse(fieldNode.InnerText);
                    }
                }
                skillList.Add(skill);
            }
            foreach (Skill skill in skillList)
            {
                Console.WriteLine(skill);
            }
            Console.ReadKey();
        }
    }
}
