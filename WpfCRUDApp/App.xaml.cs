using MySql.Data.MySqlClient;
using System.Windows;

namespace WpfCRUDApp
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        public static MySqlConnection connection;
    }
}
