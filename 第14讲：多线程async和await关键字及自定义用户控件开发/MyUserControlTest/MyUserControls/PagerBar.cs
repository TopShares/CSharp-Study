using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUserControls
{
    //【1】定义按钮单击事件的“委托”
    public delegate void PagerQueryDelegate(string sqlString);


    public partial class PagerBar : UserControl
    {
        //【2】定义分页按钮对应的事件
        public event PagerQueryDelegate ExecuteQueryEventHandler;


        public PagerBar()
        {
            InitializeComponent();
            //初始化            
            this.btnFirst.Enabled = false;
            this.btnPre.Enabled = false;
            this.btnNext.Enabled = false;
            this.btnLast.Enabled = false;
            this.btnGoTo.Enabled = false;
        }

        #region 定义分页属性和方法

        /// <summary>
        /// 当前页码
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 要查询的表或视图名称
        /// </summary>
        public string TableName { get; set; }
        /// <summary>
        /// 要显示的字段名数组
        /// </summary>
        public string[] FileNameArray { get; set; }

        /// <summary>
        /// 主键或关键字（not int）
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        /// 分页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 查询条件（where Id=100000）
        /// </summary>
        public string WhereString { get; set; }

        /// <summary>
        /// 排序条件
        /// </summary>
        public string SortString { get; set; }

        /// <summary>
        ///记录总数
        /// </summary>
        public int RecordCount { get; set; }

        /// <summary>
        /// 查询记录总数
        /// </summary>
        public int PageCount
        {
            get
            {
                if (this.RecordCount % PageSize == 0)
                {
                    return RecordCount / PageSize;
                }
                else
                {
                    return RecordCount / PageSize + 1;
                }
            }
        }
        /// <summary>
        /// 获取完整的分页SQL语句
        /// </summary>
        /// <returns></returns>
        private string GetSqlString()
        {
            string fileds = string.Empty;
            foreach (string filed in FileNameArray)
            {
                fileds += filed + ",";
            }
            fileds = fileds.Substring(0, fileds.LastIndexOf(","));//这个可以写一个简化的代码
            StringBuilder sql = new StringBuilder();

            sql.Append("select top " + PageSize.ToString() + " " + fileds + " from " + TableName);
            sql.Append(" where " + Keyword + " not in (select top " +
                ((CurrentPageIndex - 1) * PageSize).ToString() + " " + Keyword + " from "
                + TableName + " where " + WhereString + " " + SortString +
                ") and " + WhereString + SortString + ";");
            sql.Append("select count(*) from  " + TableName + " where " + WhereString);

            return sql.ToString();
        }



        #endregion

        //设置按钮的有效性（在查询之后调用的）
        public void SetButtonEnable()
        {
            this.lblCount.Text = this.RecordCount.ToString();
            this.lblCurrentPagerIndex.Text = CurrentPageIndex.ToString();


            //如果只有1页数据或没有数据
            if (PageCount <= 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPre.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnGoTo.Enabled = false;
                return;
            }
            //如果数据总页数>1
            this.btnFirst.Enabled = true;
            this.btnPre.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;
            this.btnGoTo.Enabled = true;

            if (CurrentPageIndex == 1)
            {
                this.btnFirst.Enabled = false;
                this.btnPre.Enabled = false;
            }
            else if (CurrentPageIndex == PageCount)
            {
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
            }
        }
        //首次查询的方法(每次点击查询按钮需要调用)
        public void Search()
        {
            this.CurrentPageIndex = 1;
            ExecuteQueryEventHandler(GetSqlString());//激发事件
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex--;
            ExecuteQueryEventHandler(GetSqlString());//激发事件
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex++;
            ExecuteQueryEventHandler(GetSqlString());//激发事件
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = PageCount;
            ExecuteQueryEventHandler(GetSqlString());//激发事件
        }

        private void btnGoTo_Click(object sender, EventArgs e)
        {
            //判断输入是否是数字...
            int toPageIndex = Convert.ToInt32(this.txtGoTo.Text.Trim());

            if (toPageIndex > PageCount)
            {
                MessageBox.Show("最大页数不能超过：" + PageCount.ToString());
                return;
            }

            this.CurrentPageIndex = toPageIndex;
            ExecuteQueryEventHandler(GetSqlString());//激发事件
        }
    }
}
