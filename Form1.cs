using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace taskshots
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // 画像のサイズを指定し、Bitmapオブジェクトのインスタンスを作成
            Bitmap bm = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            // Bitmap bm = new Bitmap(500, 300);   // 幅500ピクセル × 高さ300ピクセルの場合

            // Graphicsオブジェクトのインスタンスを作成
            Graphics gr = Graphics.FromImage(bm);
            // 画面全体をコピー
            gr.CopyFromScreen(new Point(0, 0), new Point(0, 0), bm.Size);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "JPEGファイル(*.jpg;*.jpeg)|*.jpg;*.jpeg|bmpファイル(*.bmp)|*.bmp;";
            dialog.Title = "保存してあ♡げ♡る";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //File.WriteAllText(dialog.FileName, txt_memo.Text);
                bm.Save(dialog.FileName + "", System.Drawing.Imaging.ImageFormat.Png);
            }
        }

        private void 終了ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            properties pro = new properties();
            pro.Show();
        }

        private void 終了ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //アプリケーションを終了する
            Application.Exit();
        }

        private void アップデート確認ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadString("http://piefile.starfree.jp/software/taskshots/ver");
                wc.Dispose();
                //アクセス可能な場合の処理
                if (Password("http://piefile.starfree.jp/software/taskshots/ver","1.0.0.0"))
                { 
                    MessageBox.Show("最新のバージョンです。\r\nいやぁいいですねぇ...",
                        "👍",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
                else
                {
                    DialogResult result = MessageBox.Show("新しいバージョンが見つかりました。\r\n新しいバージョンをインストールしますか？",
                        "🙌",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Asterisk,
                        MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start("https://piennu777.ml/software/");
                    }
                    else if (result == DialogResult.No)
                    {

                    }
                }


            }
            catch (WebException)
            {
                //アクセスできない場合の処理
                MessageBox.Show("ネットに繋がっていないか、サーバーが停止されている可能性があります。",
    "Error 404",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error);
            }
        }

        private bool Password(string url, string password)
        {

            WebClient client = new WebClient();
            string webps = client.DownloadString(url);

            byte[] input = Encoding.ASCII.GetBytes(password);
            System.Security.Cryptography.SHA256 sha = new System.Security.Cryptography.SHA256CryptoServiceProvider();
            byte[] hash_sha256 = sha.ComputeHash(input);

            string hash = "";

            for (int i = 0; i < hash_sha256.Length; i++)
            {
                hash = hash + string.Format("{0:X2}", hash_sha256[i]);
            }
            if (webps == hash)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
