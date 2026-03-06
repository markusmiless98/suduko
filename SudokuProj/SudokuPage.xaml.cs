using System;
using SudokuProj.Delegates;
using SudokuProj.Model;
using SudokuProj.SudAPI;
using SudokuProj.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace SudokuProj
{
    public partial class SudokuPage : ContentPage
    {
        public SudokuPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.SudokuPageViewModel();
            OnRespawnSuduko();
        }

        private async void OnListViewitemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var product = ((ListView)sender).SelectedItem as Model.SudukoLayout;
            if (product != null)
            {
                var page = new SudokuPage();
                page.BindingContext = product;
                await Navigation.PushAsync(page);
            }
        }

        private async void OnRespawnSuduko()
        {
            SudukoLayout layout = await APIHandler.GetSuduko();
            // Temp
            List<string> puzzle = layout.Puzzle.GetStringFromIntArray();
            int square_amnt = 3;
            int row_amnt = 9;
            int i = 0;
            int row_prog = 0;
            string txt = "";
            foreach (var item in puzzle)
            {
                if (i == 0)
                {
                    txt += "|";
                }
                i++;
                txt += " " + item + " ";
                if (i % square_amnt == 0)
                {
                    txt += "|";
                }
                if (i == row_amnt)
                {
                    txt += "\n";
                    i = 0;
                    row_prog++;
                    if (row_prog >= square_amnt)
                    {
                        txt += "--------------------------\n";
                        row_prog = 0;
                    }
                }
            }
            TXT.Text = txt;
        }
    }
}