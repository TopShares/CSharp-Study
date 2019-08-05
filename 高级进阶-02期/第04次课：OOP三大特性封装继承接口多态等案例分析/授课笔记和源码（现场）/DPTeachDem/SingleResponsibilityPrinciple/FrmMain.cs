using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleResponsibilityPrinciple
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        //保存到数据库
        private void btnSaveToDB_Click(object sender, EventArgs e)
        {
            //定义SQL语句
            string sql = "insert into Course (CourseName,CourseContent,ClassHour," +
                "Credit,CategoryId,TeacherId) values (@CourseName,@CourseContent," +
                "@ClassHour,@Credit,@CategoryId,@TeacherId)";
            //封装参数
            SqlParameter[] param = new SqlParameter[]
            {
                     new SqlParameter("@CourseName",this.txtCourseName.Text .Trim ()),
                     new SqlParameter("@CourseContent",this.txtCourseContent.Text.Trim ()),
                     new SqlParameter("@ClassHour",this.txtClassHour.Text.Trim ()),
                     new SqlParameter("@Credit",this.txtCredit.Text.Trim ())
            };

            //--------------------以上内容，应该放到数据访问类中
            //创建连接
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "server=.;DataBase=CourseManageDB;Uid=sa;Pwd=password01!";
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                if (param != null) cmd.Parameters.AddRange(param);

                cmd.ExecuteNonQuery();

                //在这里显示新添加的课程

            }
            catch (Exception ex)
            {
                MessageBox.Show("插入数据出现问题：" + ex.Message, "保存提示");
            }
            finally
            {
                conn.Close();
            }
            //--这部分内容应该放到通用数据访问类中

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }



}
