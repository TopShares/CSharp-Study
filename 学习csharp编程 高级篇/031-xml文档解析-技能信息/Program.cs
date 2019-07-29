using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace _031_xml文档解析_技能信息 {
    class Program {
        static void Main(string[] args) {
            List<Skill> skillList = new List<Skill>();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("xml技能信息.txt");

            //XmlNode skillInfoNode = xmlDoc.FirstChild;
            //XmlNode skillListNode = skillInfoNode.FirstChild;
            XmlNode skillListNode = xmlDoc.FirstChild.FirstChild;

            XmlNodeList skillNodeList = skillListNode.ChildNodes;
            foreach (XmlNode skillNode in skillNodeList)
            {
                Skill skill = new Skill();
                XmlElement ele = skillNode["Name"];
                skill.Name = ele.InnerText;
                XmlAttributeCollection col = skillNode.Attributes;//获取该结点属性的集合
                //skill.Id = Int32.Parse(col["SkillID"].Value);
                XmlAttribute idAttribute = col["SkillID"];//通过字符串索引器 获取一个属性对象
                skill.Id = Int32.Parse(idAttribute.Value);
                skill.EngName = col["SkillEngName"].Value;
                skill.TriggerType = Int32.Parse(col["TriggerType"].Value) ;
                skill.ImageFile = col["ImageFile"].Value;
                skill.AvailableRace = Int32.Parse(col["AvailableRace"].Value);
                skillList.Add(skill);
            }
            foreach (Skill s in skillList)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }
    }
}
