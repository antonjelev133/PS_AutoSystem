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
    class CarViewModel : Window, INotifyPropertyChanged
    {
        public  CarViewModel()
        {
            Console.WriteLine("days : " + compare());
            AddCarButtonCommand = new RelayCommand(AddCarButton, param => this.canExecute);
          
        }

        double compare()
        {
            DateTime dtFromDate = DateTime.ParseExact("11/06/2017", "dd/MM/yyyy",
                                                   CultureInfo.InvariantCulture);
            DateTime dtToDate = DateTime.ParseExact("11/07/2017", "dd/MM/yyyy",
                                                              CultureInfo.InvariantCulture);
            TimeSpan difference = dtFromDate - dtToDate;
            double days = difference.TotalDays;

            return days;
        }

        private String mark;
        public String Mark
        {
            get
            {
                return mark;
            }
            set
            {
                mark = value;
                NotifyPropertyChanged();
            }

        }
       private String model;
       public String Model
       {
           get
           {
               return model;
           }
           set
           {
               model = value;
               NotifyPropertyChanged();
           }

       }
        private String registration;
        public String Registration
        {
            get
            {
                return registration;
            }
            set
            {
                registration = value;
                NotifyPropertyChanged();
            }

        }
        private String date;
        public String Date
        {
            get
            {
                return date;
            }
            set
            {
              
              
                date = value;
                NotifyPropertyChanged();
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
                NotifyPropertyChanged();
            }

        }
        AutoDBEntities ctx = new AutoDBEntities();
        private void AddCarButton(object sender)
        {
            Console.WriteLine(Mark);
            Console.WriteLine(model);
            Console.WriteLine(Registration);
            Console.WriteLine(Date); Console.WriteLine(engine);
            if (date == null || engine == 0 || mark == null || registration == null || model == null )
            {
                MessageBox.Show("всички полета са задължителни");
                return;
            }

            
            CAR c = new CAR();
           c.DATA = date;
            c.ENGINE_LITERS = engine;
            c.MARK = mark;
            c.REGISTRATION = registration;
            c.MODEL = model;
            bool flag = false;
            var q = (from a in ctx.OWNERS
                     select a).ToList();
            ObservableCollection<OWNER> owners =new ObservableCollection<OWNER>(q);
            foreach(OWNER  o in owners){
                if (o.NAME == NavigaterWindow.user.OWNER.NAME)
                {
                    o.CARS.Add(c);
                    ctx.Entry(o).State = System.Data.Entity.EntityState.Modified;
                    ctx.SaveChanges();
                    flag = true;
                    MessageBox.Show("adding car finished");
                }
            }
              if (!flag) MessageBox.Show("Error adding car");

        }


    
        private ICommand addCarButtonCommand;
        public ICommand AddCarButtonCommand
        {
            get
            {
                return addCarButtonCommand;
            }
            set
            {
                addCarButtonCommand = value;
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
