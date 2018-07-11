using System;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Get_Windows_Spotlight_Pictures_WPF
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            start.Visibility = Visibility.Hidden;
            sourcePath.Visibility = Visibility.Hidden;
            allFiles.Visibility = Visibility.Hidden;
            startOutPut.Visibility = Visibility.Hidden;
            outPut.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// 所选目标文件夹路径
        /// </summary>
        private static string path = "";
        /// <summary>
        /// 源文件夹下所有文件集合
        /// </summary>
        private static string[] allFiles0;
        /// <summary>
        /// 源文件夹下符合大小要求的文件集合
        /// </summary>
        private static string[] selectedFiles0;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "选择图片保存位置"
            };
            if (folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = folderBrowserDialog.SelectedPath;
                showPath.Text = path;
            }
            Thread.Sleep(600);
            System.Windows.Forms.Application.DoEvents();

            ShowAllFiles();
            
        }

        /// <summary>
        /// 查找源文件夹下所有文件
        /// </summary>
        private void ShowAllFiles()
        {
            string sourceLoc1 = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string sourceLoc2 = @"\Packages\Microsoft.Windows.ContentDeliveryManager_cw5n1h2txyewy\LocalState\Assets";
            start.Visibility = Visibility.Visible;
            sourcePath.Visibility = Visibility.Visible;
            sourcePath.Content = sourceLoc1 + sourceLoc2;

            Thread.Sleep(1000);
            System.Windows.Forms.Application.DoEvents();

            allFiles.Visibility = Visibility.Visible;
            allFiles0 = Directory.GetFiles(sourcePath.Content.ToString());
            for (int i = 0; i < allFiles0.Length; i++)
            {
                allFiles.Items.Add(allFiles0[i]);
            }

            Thread.Sleep(1000);
            System.Windows.Forms.Application.DoEvents();

            OutPutSelectedFiles();
        }

        /// <summary>
        /// 筛选符合大小要求的文件输出至目标文件夹
        /// </summary>
        private void OutPutSelectedFiles()
        {
            FilesOperating filesOperating = new FilesOperating();
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OK;

            selectedFiles0 = filesOperating.GetFilesBySize(allFiles0,allFiles0.Length,Settings.requestSize);
            if (selectedFiles0 != null)
            {
                startOutPut.Visibility = Visibility.Visible;
                outPut.Visibility = Visibility.Visible;
                filesOperating.CopyJPGFiles(selectedFiles0, path);
                for (int i = 0; i < selectedFiles0.Length; i++)
                {
                    outPut.Items.Add(Directory.GetFiles(path)[i]);
                }
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("获取成功，请去目标文件夹查看（￣︶￣）↗　", "提示", messageBoxButtons);
                if (dialogResult == System.Windows.Forms.DialogResult.OK) 
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
            else
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("没有找到符合要求的图片，过几天再来看看(⊙o⊙)？", "提示", messageBoxButtons);
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }         
        }

        /// <summary>
        /// 非独占性延时
        /// </summary>
        /// <param name="milliseconds">延时毫秒数</param>
        private void Delay(int milliseconds)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) > milliseconds)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        
    }
}
