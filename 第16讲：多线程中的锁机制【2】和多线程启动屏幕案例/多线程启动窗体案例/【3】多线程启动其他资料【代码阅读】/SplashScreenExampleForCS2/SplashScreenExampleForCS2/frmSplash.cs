using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace SplashScreenExampleForCS
{
    //��ʾ����
    public delegate void ShowProgressDelegate(string ProgressInfo);
    //�ر�������Ļ
    public delegate void CloseSplashDelegate();
    //Ҫ��ɵ�ϵͳ��ʼ������
    public delegate void DoWorkDelegate(Object frm);

    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private Thread worker;

        //���ҽӵ����ڳ����ϳ�ʱ�乤���ĺ���
        //����ϵͳ��ʼ��
        public DoWorkDelegate DoWork;
       

        #region"���̵Ŀ��ӻ���ʾ"

            //��ʾ��ʼ������,��������
            public  ShowProgressDelegate ShowProgress ;
            //�ر�Splash���壬��������
            public  CloseSplashDelegate CloseSplash;
            
            //��ʾ��ʼ�����̣������ڴ˶���������Ҫ����ʾ��ʽ
            private void ShowProgressInForm(String ProgressInfo)
            {
                lblInfo.Text = string.Format("���ڳ�ʼ����{0}��", ProgressInfo);
                progressBar1.Value = Convert.ToInt32(ProgressInfo);
            }

        #endregion

        //��װ�봰��Ĺ��������׼������
        private void frmSplash_Load(object sender, EventArgs e)
        {
            ShowProgress = ShowProgressInForm;
            CloseSplash = this.Close;

            if (DoWork != null)
            {
                //�������ϵͳ��ʼ�������ĸ����̲߳���������
                worker = new Thread(new ParameterizedThreadStart(DoWork));
                worker.Start(this); //������������Ϊ�����������߳�
            }
        }

        
        }
}