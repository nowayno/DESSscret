using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DESSscret.Tools;
using System.Threading;

namespace DESSscret
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        bool des = true;
        int length = 0;
        int time = 2000;
        const string keytag = "正在生成密钥，请稍等...";
        const string encrypttag = "正在进行加密，请稍等...";
        const string decrypttag = "正在进行解密，请稍等...";
        private void button_Click(object sender, RoutedEventArgs e)
        {
            //以下是测试十六进制明文的加解密，用来验证加密解密是否正确
            //textBox1.Text = DESTool.getInstace().DESencrypt("0123456789ABCDEF", "133457799BBCDFF1");
            //textBox2.Text = DESTool.getInstace().DESdecrypt("a28b7a0e74430f5e", "133457799BBCDFF1");
            Random r = new Random();
            string key = "";
            for (int index = 0; index < 16; index++)
            {
                int number = r.Next(0, 16);
                key += number.ToString("X");
            }
            textBox3.Text = key;

            if (des)
            {
                des = false;
                string text = textBox1.Text.ToString();
                textBox1.Text = "";
                length = text.Length;
                textBox2.Text = DESTool.getInstace().DESencrypt(text, textBox3.Text.ToString().Trim());
                button.IsEnabled = false;
                button2.IsEnabled = true;
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (des == false)
            {
                des = true;
                string text = textBox2.Text.ToString();
                textBox2.Text = "";
                textBox1.Text = DESTool.getInstace().DESdecrypt(text, textBox3.Text.ToString().Trim()).Substring(0, length);
                button.IsEnabled = true;
                button2.IsEnabled = false;
            }
        }
    }
}
