using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
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
            BindingContext = new SudokuPageViewModel();
            OnSpawnSuduko();
        }

        private async void OnListViewitemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var product = ((ListView)sender).SelectedItem as Model.SudukoLayout;
            if (product != null)
            {
                var page = new SudokuPage();
                page.BindingContext = product;
                await Navigation.PushAsync(page);
                Thread.Sleep(4000);
            }
        }

        List<ImageButton> imgButList = new List<ImageButton>();
        private async void OnSpawnSuduko()
        {
            int i = 0;
            BindingContext.GetSudukoPageViewFromBinding().Suduko = await APIHandler.GetSuduko();
            Thread.Sleep(4000);
            SudukoLayout puzzle = BindingContext.GetSudukoFromBinding();
            int x = 0;
            int y = 0;
            while (i < 81)
            {
                ImageButton imgBut = new ImageButton
                {
                    Source = $"{puzzle.PuzzleImages[i].NumberImg}",
                    
                };
                ImagePar.Add(
                    imgBut,
                    x,
                    y
                );
                imgBut.Pressed += ImageButton_Pressed;
                imgButList.Add(imgBut);
                i++;
                if (x >= 8)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }
            }
            TXT.Text = await OnSpawnSudukoText();
        }

        // Text Version
        private async Task<string> OnSpawnSudukoText()
        {
            Thread.Sleep(500);
            var bin = BindingContext.GetSudukoPageViewFromBinding();
            SudukoLayout layout = bin.Suduko;

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
            return txt;
        }

        private int selected_element = 0;
        private ImageButton img = null;

        private async void ImageButton_Pressed(object sender, EventArgs e)
        {
            string end_res = "";
            if (sender is ImageButton)
            {
                img = sender as ImageButton;
                Func<double, double, int> num_sel = (x, y) =>
                {
                    return (int)(x + (y * 9));
                };
                int x = img.X.GetNumOfSud();
                int y = img.Y.GetNumOfSud();
                selected_element = num_sel(x,y);
                if (BindingContext.GetSudukoPageViewFromBinding() != null)
                {
                    var bin = BindingContext.GetSudukoPageViewFromBinding();
                    end_res = bin.Suduko.Puzzle[y][x].ToString();
                }
            }
            test.Text = "Selected Space is " + end_res;
            test.Text += " compared to; ";
            ImageButton but = await GetImageSearch(0, 0); // Temp for tests to show i know linq
            test.Text += but.Source.ToString();
        }

        private async void SudukoChangeNumber()
        {

        }

        private async Task<ImageButton> GetImageSearch(int x, int y)
        {
            IEnumerable<ImageButton> imgBut = imgButList.Where(c => c.Bounds.X.GetNumOfSud() == x && c.Bounds.Y.GetNumOfSud() == y);

            return (ImageButton)imgBut.ToList()[0];
        }
    }
}