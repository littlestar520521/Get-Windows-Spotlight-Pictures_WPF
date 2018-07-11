using System.Windows;

namespace Get_Windows_Spotlight_Pictures_WPF
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

        /// <summary>
        /// 选项窗口数值缓存，checkbox1值
        /// </summary>
        public static int cacheCheck1 = 0;
        /// <summary>
        /// 选项窗口数值缓存，checkbox2值
        /// </summary>
        public static int cacheCheck2 = 0;
        /// <summary>
        /// 选项窗口数值缓存，textbox值
        /// </summary>
        public static int cacheText = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings();
            settings.Show();
        }
    }
}
