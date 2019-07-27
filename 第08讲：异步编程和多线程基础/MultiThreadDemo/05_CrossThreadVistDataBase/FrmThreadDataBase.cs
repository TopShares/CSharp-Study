using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace _05_CrossThreadVistDataBase
{
    public partial class FrmThreadDataBase : Form
    {
        public FrmThreadDataBase()
        {
            InitializeComponent();
        }
        //访问数据库
        private void btnExecute1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(() =>
              {
                  Thread.Sleep(2000);
                  string classCount = DBUtility.SQLHelper.GetSingleResult("select count(*) from StudentClass").ToString();
                  this.lblResult1.Invoke(new Action<string>(c => { this.lblResult1.Text = c; }), classCount);
              });
            thread1.IsBackground = true;
            thread1.Start();
        }
        private void btnExecute2_Click(object sender, EventArgs e)
        {

        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            Thread thread3 = new Thread(() =>
            {
                Thread.Sleep(2000);


                DataSet ds = DBUtility.SQLHelper.GetDataSet("select *  from StudentClass;select StudentName,Gender,PhoneNumber from Students");

                DataTable dt1 = ds.Tables[0];
                DataTable dt2 = ds.Tables[1];

                this.dgv1.Invoke(new Action<DataTable>(c => { this.dgv1.DataSource = c; }), dt1);
                Thread.Sleep(2000);

                this.dgv2.Invoke(new Action<DataTable>(c => { this.dgv2.DataSource = c; }), dt2);
            });
            thread3.IsBackground = true;
            thread3.Start();
        }
    }
}
