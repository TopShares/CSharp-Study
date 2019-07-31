using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrategyDesignPattern4
{
    public partial class FrmBlance : Form
    {
        private double totalMoney = 0.0;
        public FrmBlance()
        {
            InitializeComponent();

            //初始化下拉框（应该从数据库中获取，或者相关的策略文件中（joson、xml，序列化的文件...)
            cbbCalType.Items.AddRange(new object[] { "正常收费", "每满300减100", "打8折", "打7折", "打6折" });
            cbbCalType.SelectedIndex = 0;
        }

        //确定
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            ////使用简单工厂获得具体的收费对象
            ////SettlementAbstract settlement =
            ////    SettlementFactory.GetSettlementType(this.cbbCalType.Text);

            //应用策略上下文对象，完成策略的选择
            StrategyContext contex = new StrategyContext(this.cbbCalType.Text);

            //基于多态实现计算（非常容易）
            double subTotal = contex.GetSettlementResult(
                Convert.ToDouble(this.txtUnitPrice.Text.Trim()) *
                Convert.ToDouble(this.txtQuantity.Text.Trim()));

            //结算列表
            string data = $"单价：{this.txtUnitPrice.Text }\t数量：{txtQuantity.Text}\t小计金额：{subTotal}";
            this.lbDataList.Items.Add(data);

            //累计的总金额
            totalMoney += subTotal;
            this.lblResult.Text = totalMoney.ToString();
        }
        //清除
        private void btnClear_Click(object sender, EventArgs e)
        {
            totalMoney = 0.00;
            txtUnitPrice.Text = "0.00";
            txtQuantity.Text = "1";
            lbDataList.Items.Clear();
            lblResult.Text = "0.00";
        }
    }
}
