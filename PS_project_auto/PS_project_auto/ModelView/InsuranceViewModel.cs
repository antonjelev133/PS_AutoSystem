using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PS_project_auto.Model;
using PS_project_auto.View;
using System.Windows.Navigation;
using System.Windows.Controls;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Globalization;

namespace PS_project_auto.ModelView
{
    class InsuranceViewModel : Window, INotifyPropertyChanged
    { AutoDBEntities ctx = new AutoDBEntities();
    public InsuranceViewModel()
        {
            initListBox();
            InsuranceButtonCommand = new RelayCommand(InsuranceButton, param => this.canExecute);
        }
        private void InsuranceButton(object sender)
        {

            if (InsuranceDate == null || InsuranceDate == null || YearsOwner == null || Period == null || YearsCar== null)
            {
                  MessageBox.Show("всички полета са задължителни");
               return;
            }

            INSURANCE i = new INSURANCE();
            i.DATE_EXPIRE = insuranceDate;
            i.ENGINE_LITERS = engine;
            i.OWNERAGE = yearsOwner;
            i.PERIOD = period;
            i.PRICE = finalPrice;
            i.YEAROFCAR = yearsCar;
            INSURANCE_INFO info = new INSURANCE_INFO();
            if(SelectedCar == null){
              MessageBox.Show("Моля изберете автомобил!");
               return;
            }
            info.CAR = SelectedCar;
            info.INSURANCE = i;
            ctx.INSURANCE_INFO.Add(info);
            ctx.SaveChanges();
            MessageBox.Show("Гражданската отговорност е създадена!");
            
            
        }
        private ICommand insuranceButtonCommand;
        public ICommand InsuranceButtonCommand
        {
            get
            {
                return insuranceButtonCommand;
            }
            set
            {
                insuranceButtonCommand = value;
            }
        }
        private int engine;
        public String Engine
        {
            get
            {
                String res = engine.ToString();
                return res;
            }
            set
            {
                int res;

                bool isFloat = int.TryParse(value.ToString(), out res);
                if (!isFloat)
                {
                    MessageBox.Show("грешен формат двигател");
                    return;
                }
                engine = res;
                FinalPrice="0";

                NotifyPropertyChanged();
            }

        }
        private float finalPrice;
        public String FinalPrice
        {
            get
            {
                return finalPrice.ToString();
            }
            set
            {
               
                

                finalPrice = (engine*(float)0.07)+(100-yearsOwner);
                Console.WriteLine(finalPrice);
                NotifyPropertyChanged();
            }

        }
        private String insuranceDate;
        public String InsuranceDate
        {
            get
            {
                return insuranceDate;
            }
            set
            {
                insuranceDate = value;
                NotifyPropertyChanged();
            }

        }
        private int yearsCar;
        public String YearsCar
        {
            get
            {
                return yearsCar.ToString();
            }
            set
            {
                int res;

                bool isFloat = int.TryParse(value.ToString(), out res);
                if (!isFloat)
                {
                    MessageBox.Show("грешен формат година на автомобила");
                    return;
                }
                yearsCar = res;
               
                NotifyPropertyChanged();
            }

        }
        private int yearsOwner;
        public String YearsOwner
        {
            get
            {
                return yearsOwner.ToString();
            }
            set
            {
                int res;

                bool isINT = int.TryParse(value.ToString(), out res);
                if (!isINT)
                {
                    MessageBox.Show("грешен формат възраст на потребителя");
                    return;
                }
                if (res < 18 || res > 70)
                {
                    MessageBox.Show("грешен формат възраст на потребителя");
                    return;
                }
                yearsOwner = res;
                FinalPrice = "0";
                NotifyPropertyChanged();
            }

        }
        private int period;
        public String Period
        {
            get
            {
                return period.ToString();
            }
            set
            {
                int res;

                bool isFloat = int.TryParse(value.ToString(), out res);
                if (!isFloat)
                {
                    MessageBox.Show("грешен формат период в години");
                    return;
                }
                period = res;
                NotifyPropertyChanged();
            }

        }
       private ICollection<CAR> _cars;
        public ICollection<CAR> cars
        {
            get { return this._cars; }
            set
            {
                this._cars = value;

                NotifyPropertyChanged();

            }
        }
        public void initListBox()
        {
            bool flag = false;
            var q = (from a in ctx.OWNERS
                     select a).ToList();
            ObservableCollection<OWNER> owners = new ObservableCollection<OWNER>(q);
            foreach (OWNER o in owners)
            {
                if (o.NAME == NavigaterWindow.user.OWNER.NAME)
                {
                     cars = o.CARS;
                     foreach (CAR a in cars)
                     {
                         Console.WriteLine(a.MODEL);
                     }
              
                    flag = true;
                   
                }
            }
            if (!flag) MessageBox.Show("Please add a car!");
        }
        private CAR _selectedCar;
        public CAR SelectedCar
        {
            get
            {
                return this._selectedCar;
            }
            set
            {

                this._selectedCar = value;

                NotifyPropertyChanged();

            }
        }
        private bool canExecute = true;
        public bool CanExecute
        {
            get { return this.canExecute; }
            set
            {
                if (this.canExecute == value) { return; }
                this.canExecute = value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
