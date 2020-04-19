using System;
using System.Windows;
using System.Windows.Media;

namespace Get_Windows_Spotlight_Pictures_WPF
{
    /// <summary>
    /// Settings.xaml 的交互逻辑
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
        {
            InitializeComponent();
            if (MainWindow.cacheCheck1 == 1)
            {
                function1.IsChecked = true;
            }

            if (MainWindow.cacheCheck2 == 1)
            {
                function2.IsChecked = true;
            }

            if (MainWindow.cacheText != 0)
            {
                setSize.Text = MainWindow.cacheText.ToString();
            }
        }

        /// <summary>
        /// 图片筛选大小，默认200KB
        /// </summary>
        public static int requestSize = 200;

        /*取消设置*/
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /*确认设置*/
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (function1.IsChecked == true)
            {
                requestSize = Convert.ToInt32(setSize.Text);
                MainWindow.cacheCheck1 = 1;
                MainWindow.cacheText = requestSize;
            }
            else
            {
                MainWindow.cacheCheck1 = 0;
                MainWindow.cacheText = 200;
            }
            if (function2.IsChecked == true)
            {
                MainWindow.cacheCheck2 = 1;
            }
            else
            {
                MainWindow.cacheCheck2 = 0;
            }
            Close();
        }

        /*勾选筛选图片大小选项*/
        private void Function1_Checked(object sender, RoutedEventArgs e)
        {
            setSize.IsReadOnly = false;
            SolidColorBrush brush = new SolidColorBrush(Colors.Black);
            setSize.Foreground = brush;
            sizeKB.Foreground = brush;
        }

        /*取消勾选筛选图片大小选项*/
        private void Function1_Unchecked(object sender, RoutedEventArgs e)
        {
            setSize.IsReadOnly = true;
            SolidColorBrush brush = new SolidColorBrush(Colors.Gray);
            setSize.Foreground = brush;
            sizeKB.Foreground = brush;
        }

        /*勾选图片按横竖分类选项*/
        private void Function2_Checked(object sender, RoutedEventArgs e)
        {

        }


    }
}
