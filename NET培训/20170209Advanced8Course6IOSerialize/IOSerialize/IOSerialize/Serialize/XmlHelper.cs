using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace IOSerialize.Serialize
{
    public class XmlHelper
    {
        private static string CurrentXMLPath = ConfigurationManager.AppSettings["CurrentXMLPath"];
        /// <summary>
        /// 通过XmlSerializer序列化实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ToXml<T>(T t) where T : new()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
            Stream stream = new MemoryStream();
            xmlSerializer.Serialize(stream, t);
            stream.Position = 0;  
            StreamReader reader = new StreamReader( stream );  
            string text = reader.ReadToEnd();  
            return text;

            //string fileName = Path.Combine(CurrentXMLPath, @"Person.xml");//文件名称与路径
            //using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            //{
            //    XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            //    xmlFormat.Serialize(fStream, t);
            //}
            //string[] lines = File.ReadAllLines(fileName);
            //return string.Join("", lines);
        }

        /// <summary>
        /// 字符串序列化成XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T ToObject<T>(string content) where T : new()
        {
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content)))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T)xmlFormat.Deserialize(stream);
            }

            //string fileName = Path.Combine(CurrentXMLPath, @"Person.xml");
            //using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            //{
            //    XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
            //    return (T)xmlFormat.Deserialize(fStream);
            //}
        }

        /// <summary>
        /// 文件反序列化成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T FileToObject<T>(string fileName) where T : new()
        {
            fileName = Path.Combine(CurrentXMLPath, @"Student.xml");
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T)xmlFormat.Deserialize(fStream);
            }
        }

        /*   linq to xml
                public static IEnumerable<Hero<T>> GetHeroEntity(string fileName)
                {
                    XDocument xdoc = XDocument.Load(fileName);
                    XElement root = xdoc.Root;
                    foreach (XElement element in root.Elements())
                    {
                        Hero<T> entity = new Hero<T>();
                        entity.Name = element.Element("Name").Value;
                        foreach (XElement item in element.Element("StoryCollection").Elements())
                        {
                            var story = ReflectionUtils<T>.ElementToEntity(item);
                            entity.list.Add(story);
                        }
                        yield return entity;
                    }
                }

                /// <summary>
                /// 将XElement转换为T类型的实体类
                /// </summary>
                /// <param name="xe">XElement</param>
                /// <returns>T类型的实体类</returns>
                public static T ElementToEntity<T>(XElement xe)
                {
                    T entity = Activator.CreateInstance<T>(); //T entity = new T();
                    Type type = typeof(T);
                    PropertyInfo[] properties = type.GetProperties();
                    foreach (PropertyInfo p in properties)
                    {
                        string propertyName = p.Name;
                        Type propertyType = p.PropertyType;
                        object obj = xe.Element(propertyName).Value;
                        object value = Convert.ChangeType(obj, propertyType);
                        p.SetValue(entity, value);
                    }
                    return entity;
                }
                */
    }
}
