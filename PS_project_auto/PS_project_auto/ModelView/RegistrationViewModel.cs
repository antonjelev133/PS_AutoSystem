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

namespace PS_project_auto.ModelView
{
    public class RegistrationViewModel: Window,INotifyPropertyChanged
    {

      
        private String user;
        public String User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                NotifyPropertyChanged();
            }

        }
       private String password;
        private  int idd;
    
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
        private String name;
        public String Name1
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }

        }
       private String egn;
       public String Egn
       {
           get
           {
               return egn;
           }
           set
           {
               egn = value;
               NotifyPropertyChanged();
           }

       }
       private String adress;
       public String Adress
       {
           get
           {
               return adress;
           }
           set
           {
               adress = value;
               NotifyPropertyChanged();
           }

       }
        
       public int generateID()
        {
            Random rnd = new Random();
            int r= rnd.Next(1,111111111);
           return r;
        }

        AutoDBEntities ctx = new AutoDBEntities();
        public void FillUsers()
        {
            var q = (from a in ctx.USERS
                     select a).ToList();
            this.Users = new ObservableCollection<USER>(q); 
            foreach (object o in Users)
            { Console.WriteLine(o); }
            ctx.Dispose();
        }
        ObservableCollection<USER> Users;

        public  RegistrationViewModel()
        {
            FillUsers();
            BackButtonCommand = new RelayCommand(BackButton, param => this.canExecute);
            RegistrationButtonCommand = new RelayCommand(RegistrationButton, param => this.canExecute);
        }
        public void RegistrationButton(object sender)
        {
            bool alreadyExists = Users.Any(x => x.USER1 == User);
            if ((User == " " || User == null || User.Contains(" ") || User.Length > 20 || User.Length <= 8) || (Password == " " || Password == null || Password.Contains(" ") || Password.Length < 6 || Password.Length > 20))
            {
                MessageBox.Show("Wrong username or password format!");
            }
            else if (alreadyExists)
            {
                MessageBox.Show("User already exist!");
            }
            else
            {
                addNewOwner();
                addNewUser();
                MessageBox.Show("Registration successfull");
            }
           



        }
        OWNER a;
        public void addNewOwner()
        {
            ctx = new AutoDBEntities();
            int id = findIdOfOwner();
            if (id != 0) { return; }
             a = new OWNER();
            if(Egn.Length!=10)
            { MessageBox.Show("EGN ERROR!"); return; }
             a.NAME = Name1;

            a.EGN = Egn;
            if (Adress.Length > 20 && Adress.Length!=0)
            { MessageBox.Show("ADRESS ERROR!"); return; }
            a.ADDRESS = Adress;
            idd = generateID();
          //  a.ID = idd;
            ctx.OWNERS.Add(a);
      
            ctx.SaveChanges();
            ctx.Dispose();

        }

        public void addNewUser()
        {
            ctx = new AutoDBEntities();
            USER u = new USER();
         //   u.Id = generateID();
            u.USER1 = User;
            u.PASSWORD = Password;
            u.OWNER = a;
         //   u.OWNERS_ID = idd;
            Console.WriteLine(u.USER1 + " " + u.PASSWORD + " " + u.OWNERS_ID);
            ctx.USERS.Add(u);
            ctx.SaveChanges();
            ctx.Dispose();

        }

        public int findIdOfOwner()
        {
            int res=0;
            ObservableCollection<OWNER> Owners;
            var q = (from a in ctx.OWNERS
                     select a).ToList();
            Owners = new ObservableCollection<OWNER>(q);
            foreach (OWNER o in Owners)
            {
                if (o.NAME == Name && o.ADDRESS == Adress && o.EGN == Egn)
                {
                    return o.ID;
                }
            }
            
            return res;
        }

        public void BackButton(object sender)
        {

            if (MainWindowViewModel.rr != null)
            {
                MainWindowViewModel.rr.Close();
                MainWindowViewModel.rr = null;
            }
           MainWindowViewModel.ww = new MainWindow();
            MainWindowViewModel.ww.Show();

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
