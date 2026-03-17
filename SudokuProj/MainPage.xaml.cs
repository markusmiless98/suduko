using SudokuProj.Delegates;
using SudokuProj.ViewModels;
using SudokuProj.Model;
using SudokuProj.SudAPI;

namespace SudokuProj
{
    public partial class MainPage : ContentPage
    {
        
        public MainPage()
        {
            InitializeComponent();
        }

        SudukoLayout layout;
        /*
        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            layout = await APIHandler.GetSuduko();

            if (layout != null)
            {
                string txt = "";
                // Make this not be created later and have it always present
                SudokuPageViewModel spvm = new SudokuPageViewModel();
                spvm.Suduko = layout;
                List<string> puzzle = spvm.Suduko.Puzzle.GetStringFromIntArray();
                int square_amnt = (int)Math.Sqrt(puzzle.Count);
                int i = 0;
                foreach (var item in puzzle)
                {
                    txt += "\n" + item;
                    i++;
                    if (i == square_amnt)
                    {
                        txt += "\n" + "--------------------------";
                        i = 0;
                    }
                }
                SodukoView.Text = txt;
            }

            SemanticScreenReader.Announce(SodukoView.Text);
        }
        */
        private async void OnSudokuPage(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new SudokuPage());
        }
    }
}
