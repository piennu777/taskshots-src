using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskshots
{
    public partial class properties : Form
    {
        public properties()
        {
            InitializeComponent();
            //ユーザーがサイズを変更できないようにする
            //最大化、最小化はできる
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //フォームが最大化されないようにする
            this.MaximizeBox = false;
            //フォームが最小化されないようにする
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //自分自身のフォームをCloseメソッドで閉じると、アプリケーションが終了する
            this.Close();
        }

        private void properties_Load(object sender, EventArgs e)
        {
            //フォームを画面の中央に配置
            this.SetBounds((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2, this.Width,
                this.Height);
        }
    }
}
