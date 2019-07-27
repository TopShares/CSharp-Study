using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SplashScreenExampleForCS
{
    class SplashAppContext: ApplicationContext
    {
        Form realMainForm = null;
        //�Ƚ�������Ļ����ΪApplicationContext�����������
        public SplashAppContext(Form mainForm, Form splashForm)
            : base(splashForm)
        {
            this.realMainForm = mainForm;//���������������ȷ���˽���ֶ��б�������
        }

        protected override void OnMainFormClosed(object sender, EventArgs e)
        {
            if (sender is frmSplash)//������Ļ�رգ��л�Ϊ�����������壬����ʾ
            {
                base.MainForm = this.realMainForm;
                base.MainForm.Show();
            }
            else if (sender is frmMain ) //������رգ����û����������رշ������������߳�
            {
                base.OnMainFormClosed(sender, e);
            }
        }
    }
}
