using Microsoft.Maui.Controls;
using Suduko.Application.Services;
using Suduko.Infrastructure.Data;
using static System.Net.Mime.MediaTypeNames;

namespace Suduko.Front
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        SudukoClass sudukoClass;

        public MainPage()
        {
            InitializeComponent();
            sudukoClass = new SudukoClass();
        }

        List<ImageButton> imgButList = new List<ImageButton>();

        List<string> puzzle = new List<string>();

        private async void UpdateSuduko()
        {
            string txt = "";

            puzzle = await sudukoClass.WriteSuduko();

            Thread.Sleep(2000);

            int x = 0;
            int y = 0;

            foreach (var item in puzzle)
            {
                txt += "\n";
                txt += item;
                if (item.Length == 3)
                {
                    ImageButton imgBut = new ImageButton
                    {
                        Source = $"{SudukoImage.gui_info[item]}",
                        ZIndex = 1
                    };
                    ImagePar.Add(
                        imgBut,
                        x,
                        y
                    );
                    imgButList.Add(imgBut);

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
            }

            SudukoText.Text = txt;
        }

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
                    Func<double, int> GetNumOfSud = x =>
                    {
                        x += 80;
                        return (int)x / 80 - 1;
                    };
                    int x = GetNumOfSud(send.X);
                    int y = GetNumOfSud(send.Y);

                    string text = '[' + selected_element.ToString() + ']';
                    img.Source = SudukoImage.gui_info[text].ToString();

                    SudukoCheckSolution(num_sel(x, y));
                }
            }
            catch
            {
                // Idk fail I guess
            }
        }

        private async void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            UpdateSuduko();
        }

        ImageButton img;
        private int selected_element;

        private async void ImageButton_Pressed(object sender, EventArgs e)
        {
            string end_res = "";
            if (sender is ImageButton)
            {
                img = sender as ImageButton;
            }
            ImageButton but = await GetImageSearch(0, 0); // Temp for tests to show i know linq
        }

        private async Task<ImageButton> GetImageSearch(int x, int y)
        {
            Func<double, int> GetNumOfSud = x =>
            {

                x += 80;
                return (int)x / 80 - 1;
            };

            IEnumerable<ImageButton> imgBut = imgButList.Where(c => GetNumOfSud(c.Bounds.X) == x && GetNumOfSud(c.Bounds.Y) == y);

            return (ImageButton)imgBut.ToList()[0];
        }

        private async void SudukoCheckSolution(int num)
        {
            // 
        }
    }
}
