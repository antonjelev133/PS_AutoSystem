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
   public class PrintViewModel: Window,INotifyPropertyChanged
   {
       AutoDBEntities ctx = new AutoDBEntities();
       public PrintViewModel()
       {
           initListBox();
           PrintToFileButtonCommand = new RelayCommand(PrintFileButton, param => this.canExecute);
       }
       private void PrintFileButton(object sender)
    {
        if (SelectedCar == null)
        {
            MessageBox.Show("Моля изберете автомобил!");
            return;
        }
        INSURANCE_INFO  i= GetInfo();
        INFO_COMPREHENSIVE_COVER c = GetCover();
        if (i == null && c == null)
        {
            MessageBox.Show("no data!");
        }
        String result = "car: " + SelectedCar.MARK + " registration" + SelectedCar.REGISTRATION + " model: " + SelectedCar.MODEL + " date: " + SelectedCar.DATA + " engine L: " + SelectedCar.ENGINE_LITERS + "Environment.NewLine" 
            + "Owner name " + SelectedCar.OWNER.NAME + " Owner adress " + SelectedCar.OWNER.ADDRESS + "Environment.NewLine";

        if (i != null)
        {
            result += "Insurance date: " + i.INSURANCE.DATE_EXPIRE + " period " + i.INSURANCE.PERIOD + " price " + i.INSURANCE.PRICE + "Environment.NewLine";
        }
         if(c != null)
         {
             result += "Comprehensice date" + c.COMPREHENSIVE_COVER.DATE_EXPIRE + " final price " + c.COMPREHENSIVE_COVER.FINAL_PRICE + "Environment.NewLine";
         }
         System.IO.File.WriteAllText("test.txt", result);
    }


       public INFO_COMPREHENSIVE_COVER GetCover()
       {
           var q = (from a in ctx.INFO_COMPREHENSIVE_COVER
                    select a).ToList();
           ObservableCollection<INFO_COMPREHENSIVE_COVER> covers = new ObservableCollection<INFO_COMPREHENSIVE_COVER>(q);
           foreach(INFO_COMPREHENSIVE_COVER c in covers){
               if (c.CAR.ID == SelectedCar.ID)
               {
                   return c;
               }

           }
           return null;
       }


       public INSURANCE_INFO GetInfo()
       {
           var q = (from a in ctx.INSURANCE_INFO
                    select a).ToList();
           ObservableCollection<INSURANCE_INFO> infos = new ObservableCollection<INSURANCE_INFO>(q);
           foreach (INSURANCE_INFO c in infos)
           {
               if (c.CAR.ID == SelectedCar.ID)
               {
                   return c;
               }

           }
           return null;
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
    private ICommand printToFileButtonCommand;
    public ICommand PrintToFileButtonCommand
    {
        get
        {
            return printToFileButtonCommand;
        }
        set
        {
            printToFileButtonCommand = value;
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
