using Ruanmou.CoreDemo.Framework;
using System;
using System.Text;

namespace Ruanmou.CoreDemo
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //控制台支持中文 nuget System.Text.Encoding.CodePages 
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                Console.WriteLine("Hello World!");
                var user = new
                {
                    Id = 11,
                    Name = "Eleven"
                };
                Console.WriteLine(JsonHelper.Serialize(user));

                Console.WriteLine("**************************************");
                {
                    SharpSix six = new SharpSix();
                    People people = new People()
                    {
                        Id = 505,
                        Name = "马尔凯蒂"
                    };
                    six.Show(people);
                }

                Console.WriteLine("**************************************");
                {
                    SharpSeven seven = new SharpSeven();
                    seven.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            Console.Read();
        }
    }
}