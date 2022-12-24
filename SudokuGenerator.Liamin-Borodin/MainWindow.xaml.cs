using System.IO;
using System.Windows;

namespace SudokuGenerator.Liamin_Borodin
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Start_Click(object sender, RoutedEventArgs e)
		{
			StartWindow startWindow = new();
			startWindow.Show();
		}

		private void Rules_Click(object sender, RoutedEventArgs e)
		{
			using StreamReader streamReader = new("rules.txt");
			string rules = streamReader.ReadToEnd();
			MessageBox.Show(rules);
		}

		private void Esc_Click(object sender, RoutedEventArgs e)
		{
			int b = 0;

			int a = 1 / b;
		}
	}
}