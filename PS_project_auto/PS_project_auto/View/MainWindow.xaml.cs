using System.Windows;
using PS_project_auto.ModelView;
using PS_project_auto.View;
namespace PS_project_auto.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

    
    }
}
