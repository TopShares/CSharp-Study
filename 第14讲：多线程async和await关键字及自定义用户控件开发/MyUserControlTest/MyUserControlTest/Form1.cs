using MyUserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUserControlTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //设置分页控件的相关属性
            this.MyCustomPagerBar.FileNameArray = new string[] { "BookId,BarCode,BookName" };
            this.MyCustomPagerBar.TableName = "Books";
            this.MyCustomPagerBar.PageSize = 5;
            this.MyCustomPagerBar.Keyword = "BookId";

            //将查询事件关联
            this.MyCustomPagerBar.ExecuteQueryEventHandler += new PagerQueryDelegate(Query);
        }

        //根据事件写方法
        private void Query(string sql)
        {
            DataSet ds = SQLHelper.GetDateSet(sql);
            this.dgvBookList.DataSource = ds.Tables[0];

            //获取满足条件的记录总数
            this.MyCustomPagerBar.RecordCount = Convert.ToInt32(ds.Tables[1].Rows[0][0]);

            //设置按钮的有效性
            this.MyCustomPagerBar.SetButtonEnable();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.MyCustomPagerBar.WhereString = $"BookName like '%{this.txtBookName.Text }%'";
            this.MyCustomPagerBar.SortString = "Order by BookId ASC";
            //调用首次查询的方法
            this.MyCustomPagerBar.Search();
        }
    }
}
