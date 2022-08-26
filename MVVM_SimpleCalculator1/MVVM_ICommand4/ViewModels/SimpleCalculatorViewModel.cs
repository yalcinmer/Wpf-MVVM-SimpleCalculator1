using MVVM_ICommand4.Commands;
using MVVM_ICommand4.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_ICommand4.ViewModels
{
    public class SimpleCalculatorViewModel:INotifyPropertyChanged
    {
        CalculatorModel model;

        public SimpleCalculatorViewModel()
        {
            model = new CalculatorModel();
            //model.FirstNumber = 0;
            //model.SecondNumber = 0;
        }
        public double FirstNumber
        {
            get { return model.FirstNumber; }
            set
            {
                model.FirstNumber = value;
                OnPropertyChanged("FirstNumber");
            }
        }

        public double SecondNumber
        {
            get { return model.SecondNumber; }
            set
            {
                model.SecondNumber= value;
                OnPropertyChanged("SecondNumber");
            }
        }

        public double Result
        {
            get { return model.Result; }
            set 
            { 
                model.Result = value;
                OnPropertyChanged("Result");
            }
        }

        public void Plus()
        {
            Result = FirstNumber + SecondNumber;
        }

        private ICommand plusCommand;
        public ICommand PlusCommand
        {
            get
            {
                if (plusCommand == null)
                    plusCommand = new RelayCommand(Plus);
                return plusCommand;
            }
        }

        public void Minus()
        {
            Result = FirstNumber - SecondNumber;
        }

        private ICommand minusCommand;

        public ICommand MinusCommand
        {
            get
            {
                if(minusCommand == null)
                    minusCommand = new RelayCommand(Minus);
                return minusCommand;
            }
        }

        public void Multiply()
        {
            Result = FirstNumber * SecondNumber;
        }

        private ICommand multiplyCommand;
        public ICommand MultiplyCommand
        {
            get
            {
                if(multiplyCommand == null)
                    multiplyCommand = new RelayCommand(Multiply);
                return multiplyCommand;
            }
        }


        public void Division()
        {
            Result = FirstNumber / SecondNumber;
        }

        private ICommand divisionCommand;
        public ICommand DivisionCommand
        {
            get
            {
                if (divisionCommand == null)
                    divisionCommand = new RelayCommand(Division);
                return divisionCommand;
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string arg)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(arg));
        }
    }
}
