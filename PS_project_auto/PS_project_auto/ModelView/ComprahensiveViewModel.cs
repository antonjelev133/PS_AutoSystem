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
    public class ComprahensiveViewModel : Window, INotifyPropertyChanged
    {
        

        AutoDBEntities ctx = new AutoDBEntities();
        public  ComprahensiveViewModel()
        {
            initListBox();
            InsuranceButtonCommand = new RelayCommand(InsuranceCarButton, param => this.canExecute);
        }
        private void InsuranceCarButton(object sender)
        {
            if ( insurancePrice == null || insuranceDate == null )
            {
                MessageBox.Show("всички полета са задължителни");
                return;
            }
            
            COMPREHENSIVE_COVER c = new COMPREHENSIVE_COVER();
            c.FINAL_PRICE = finalPrice;
            c.PRICE_CAR = insurancePrice;
            c.DATE_EXPIRE = insuranceDate;
         
            INFO_COMPREHENSIVE_COVER i = new INFO_COMPREHENSIVE_COVER();
            i.CAR = SelectedCar;
           
            if(SelectedCar == null){
                 MessageBox.Show("Моля изберете автомобил!");
                 return;
            }
            i.COMPREHENSIVE_COVER = c;
        
            
             ctx.INFO_COMPREHENSIVE_COVER.Add(i);
             ctx.SaveChanges();
             MessageBox.Show("Каското е създадено!");
            
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
        private float insurancePrice;
        public String InsurancePrice
        {
            get
            {
                String res = insurancePrice.ToString();
                return res;
            }
            set
            {
                float res;

                bool isFloat = float.TryParse(value.ToString(), out res);
                if (!isFloat)
                {
                    MessageBox.Show("грешен формат цена");
                    return ;
                }
                insurancePrice = res;
                FinalPrice = "0";
                NotifyPropertyChanged();
            }

        }
        private float finalPrice;
        public String FinalPrice
        {
            get
            {
                String res = finalPrice.ToString();
                return res;
            }
            set
            {
                float res;

                bool isFloat = float.TryParse(value.ToString(), out res);
                if (!isFloat)
                {
                     return;
                }
               finalPrice = res;
                finalPrice = insurancePrice*(float)0.07;
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
