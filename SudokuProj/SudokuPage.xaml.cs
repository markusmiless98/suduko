using System;
using System.Numerics;
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
        private bool IsSolved = false;
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
                Thread.Sleep(1000);
            }
        }

        List<ImageButton> imgButList = new List<ImageButton>();

        private async void OnSpawnSuduko()
        {
            int i = 0;
            SudokuPageViewModel.Instance.Suduko = await APIHandler.GetSuduko();
            Thread.Sleep(1000);
            SudukoLayout puzzle = SudokuPageViewModel.Instance.Suduko;
            int x = 0;
            int y = 0;
            while (i < 81)
            {
                ImageButton imgBut = new ImageButton
                {
                    Source = $"{puzzle.PuzzleImages[i].NumberImg}",
                    ZIndex = 1
                };
                ImagePar.Add(
                    imgBut,
                    x,
                    y
                );
                if (puzzle.PuzzleImages[i].NumberImg == "square_bg_norm.png")
                {
                    imgBut.Pressed += ImageButton_Pressed;
                }
                else
                {
                    ImagePar.Add(new Microsoft.Maui.Controls.Image
                    {
                        Source = "square_fg_num.png",
                        ZIndex = 2,
                    },x, y);
                }
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
            try
            {
                Thread.Sleep(500);
                SudukoLayout layout = SudokuPageViewModel.Instance.Suduko;

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
            catch
            {
                return "Failed to Load Suduko.";
            }
        }

        private int selected_element = -1;
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
                if (SudokuPageViewModel.Instance != null)
                {
                    end_res = SudokuPageViewModel.Instance.Suduko.Puzzle[y][x].ToString();
                }
            }
            test.Text = "Selected Space is " + end_res;
            test.Text += " compared to; ";
            ImageButton but = await GetImageSearch(0, 0); // Temp for tests to show i know linq
            test.Text += but.Source.ToString();
        }

        // Gui
        private async void SudukoChangeNumber(object sender, EventArgs e)
        {
            try
            {
                if (selected_element <= -1 || img == null)
                {
                    return;
                }
                if (sender is ImageButton)
                {
                    ImageButton send = sender as ImageButton;
                    Func<double, double, int> num_sel = (x, y) =>
                    {
                        return (int)(x + (y * 3)) + 1;
                    };
                    int x = send.X.GetNumOfSud();
                    int y = send.Y.GetNumOfSud();

                    img.Source = SudokuGUIInfo.gui_info[num_sel(x,y).ToString()];
                    test2.Text = "The change is; " + num_sel(x,y).ToString();

                    SudukoCheckSolution(num_sel(x, y));
                }
            }
            catch
            {
                // Idk fail I guess
            }
        }

        private async void SudukoCheckSolution(int num)
        {
            SudokuPageViewModel.Instance.Suduko.Puzzle.ElementAt(img.Y.GetNumOfSud())[img.X.GetNumOfSud()] = num;
            TXT.Text = await OnSpawnSudukoText();

            if (SudokuPageViewModel.Instance.IsSudukoSolved())
            {
                // VICTORY
                win_text.Text = "Completed!";
            }
            else
            {
                win_text.Text = "Incomplete";
            }
        }

        private async Task<ImageButton> GetImageSearch(int x, int y)
        {
            IEnumerable<ImageButton> imgBut = imgButList.Where(c => c.Bounds.X.GetNumOfSud() == x && c.Bounds.Y.GetNumOfSud() == y);

            return (ImageButton)imgBut.ToList()[0];
        }
    }
}