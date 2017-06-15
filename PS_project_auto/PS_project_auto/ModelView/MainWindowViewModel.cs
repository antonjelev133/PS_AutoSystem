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
namespace PS_project_auto.ModelView
{
    public class MainWindowViewModel : Window,INotifyPropertyChanged
    {
        AutoDBEntities ctx = new AutoDBEntities();
      public MainWindowViewModel()
        {
           FillUser2s();
            FillUsers();
           BackButtonCommand = new RelayCommand(BackButton, param => this.canExecute);
          ContactsButtonCommand = new RelayCommand(ContactsButton, param => this.canExecute);
          LogInButtonCommand = new RelayCommand(LogInButton, param => this.canExecute);
          RegistrationButtonCommand = new RelayCommand(RegistButton, param => this.canExecute);
         
          

       }
     public static Registration rr;
      public void RegistButton(object sender)
      {
          if (ww != null)
          {
              ww.Close();
              ww = null;
          }
          Application.Current.Windows[0].Close();
          rr = new Registration();
          rr.Show();
          ctx.Dispose();

      }
      public static NavigaterWindow nw;
      public void LogInButton(object sender)
      {
          bool flag = false;
         foreach(USER u in Users)
         {
            
             if (userName == u.USER1.Trim()&&Password==u.PASSWORD.Trim() )
             {
                 flag = true;
                 if (ww != null)
                 {
                     ww.Close();
                     ww = null;
                 }
                 Application.Current.Windows[0].Close();
                 nw = new NavigaterWindow(u);
                 nw.Show();
             }
            
         }
         if (!flag) MessageBox.Show("Wrong username or password!");

      }
      public ObservableCollection<USER> _Users;
      public ObservableCollection<USER> Users
      {
          get { return this._Users; }
          set
          {
              this._Users = value;

              NotifyPropertyChanged();

          }
      }
      public void FillUsers()
      {
          var q = (from a in ctx.USERS
                   select a).ToList();
          this.Users = new ObservableCollection<USER>(q); ;
          foreach(object o in Users)
          { Console.WriteLine(o); }
      }

      public void FillUser2s()
      {
          USER u = new USER();
          u.USER1 = "12345678";
          u.PASSWORD="12345678";
                  
          ctx.USERS.Add(u);
          ctx.SaveChanges();
         // ctx.Database.ExecuteSqlCommand("INSERT INTO OWNERS(ID,EGN,NAME,ADDRESS) values(5,'5','a','b')");
         // ctx.SaveChanges();
   
       
         

          
          }
      
      
        static Contacts cc;
     public static MainWindow ww;
       public void BackButton(object sender)
       {

           if (cc != null)
           {
               cc.Close();
               cc = null;
           }
           ww = new MainWindow();
           ww.Show();
          
       }

      
       public void ContactsButton(object sender)
       {


           if (ww != null)
           {
               ww.Close();
               ww = null;
           }

           Application.Current.Windows[0].Close();
           cc = new Contacts();
           cc.Show();
          

         
       }
       private ICommand registrationButtonCommand;
       public ICommand RegistrationButtonCommand
       {
           get
           {
               return registrationButtonCommand;
           }
           set
           {
               registrationButtonCommand = value;
           }
       }
       private ICommand loginButtonCommand;
       public ICommand LogInButtonCommand
       {
           get
           {
               return loginButtonCommand;
           }
           set
           {
               loginButtonCommand = value;
           }
       }
       private ICommand backButtonCommand;
       public ICommand BackButtonCommand
       {
           get
           {
               return backButtonCommand;
           }
           set
           {
               backButtonCommand = value;
           }
       }
       private ICommand contactsButtonCommand;
       public ICommand ContactsButtonCommand
       {
           get
           {
               return contactsButtonCommand;
           }
           set
           {
               contactsButtonCommand = value;
           }
       }
       private String userName;
       public String UserName
       {
           get
           {
               return userName;
           }
           set
           {
               userName = value;
               NotifyPropertyChanged();
           }

       }
       private String password;
       public String Password
       {
           get
           {
               return password;
           }
           set
           {
               password = value;
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
