using Suduko.Application.Services;

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

        private async void UpdateSuduko()
        {

            string txt = "";

            List<string> txts = await sudukoClass.WriteSuduko();

            Thread.Sleep(1000);

            foreach (var item in txts)
            {
                txt += "\n";
                txt += item;
            }

            SudukoText.Text = txt;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            UpdateSuduko();
        }

    }
}
