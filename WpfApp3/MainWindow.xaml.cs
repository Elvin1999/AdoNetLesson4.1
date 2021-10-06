
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int Count()
        {
            Thread.Sleep(5000);
            int count = 50000;
            return count;
        }
        //Task Task<T>

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            //Task<int> task = new Task<int>(Count);
            //task.Start();
            //txtBlock.Text = "Process Starting : ";
            //var result =  await task;
            //txtBlock.Text += result;
            //txtBlock.Text += "\n Process Ended";

            var result = await GetDataAsync("myfile.txt");
            txtBlock.Text = "Before async call\n";
            txtBlock.Text += result;
            txtBlock.Text += "\nAfter async call\n";
        }

        private async Task<string> GetDataAsync(string filename)
        {
            byte[] data = null;

            using (FileStream fs=File.Open(filename,FileMode.OpenOrCreate))
            {
                data = new byte[fs.Length];
                await fs.ReadAsync(data, 0, (int)fs.Length);
            }
            return Encoding.UTF8.GetString(data);
        }
    }
}
