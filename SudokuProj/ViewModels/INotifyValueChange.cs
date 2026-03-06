using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj.ViewModels
{
    internal interface INotifyValueChange
    {
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
