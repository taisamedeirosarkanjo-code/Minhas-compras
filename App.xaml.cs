namespace MauiAppMinhasCompras
{
    public partial class App : Application
    {
        public static Helpers.SQLiteDatabaseHelper Db { get; private set; }

        public App()
        {
            InitializeComponent();

            string path = System.IO.Path.Combine(
                FileSystem.AppDataDirectory,
                "banco_sqlite_compras.db3"
            );

            Db = new Helpers.SQLiteDatabaseHelper(path);

            MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}
