using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SudokuProj.Model;
using SudokuProj.SudAPI;

namespace SudokuProj.ViewModels
{
    public class SudokuPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private static SudokuPageViewModel instance;

        public static SudokuPageViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SudokuPageViewModel();
                }
                return instance;
            }
        }


        public SudokuPageViewModel()
        {
            // Load Sudoku Async
            LoadSudukoAsync();
        }

        private async void LoadSudukoAsync()
        {
            Suduko = await APIHandler.GetSuduko();
        }

        public string temp { get; set; }

        private SudukoLayout suduko;
        public SudukoLayout Suduko
        {
            get { return suduko; }
            set
            {
                suduko = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Suduko)));
            }
        }

        public bool IsSudukoSolved()
        {
            int i = 0;
            int x = 0;
            int y = 0;
            while (i < 81)
            {
                if (suduko.Puzzle.ElementAt(x)[y] == -1)
                {
                    return false;
                }
                else if (suduko.Solution.ElementAt(x)[y] != suduko.Puzzle.ElementAt(x)[y])
                {
                    return false;
                }
                if (x >= 8)
                {
                    x = 0;
                    y++;
                }
                else
                {
                    x++;
                }
                i++;
            }
            return true;
        }

        // Temporary public while I figure out other stuff
        public async Task<List<string>> LoadSudokuFromSelection()
        {
            List<string> i = new List<string>();

            foreach (var item in suduko.Puzzle)
            {
                string txt = "";
                int count = item.Count() - 1;
                int item_square = (int)Math.Sqrt(item.Count());
                while (count >= 0)
                {
                    int num = item[count];
                    if (count == item.Count() - 1)
                    {
                        txt += "|";
                    }
                    else
                    {
                        txt += " ";
                    }
                    if (num <= -1)
                    {
                        txt += "X";
                    }
                    else
                    {
                        txt += num.ToString();
                    }
                    if (count == 0 || count % item_square == 0)
                    {
                        txt += "|";
                    }
                    count--;
                }
                i.Add(txt);
            }

            return i;
        }
    }
}
