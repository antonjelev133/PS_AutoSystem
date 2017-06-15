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
using System;
namespace PS_project_auto.ModelView
{
   public class NavigationViewModel : Window
    { 
      public NavigationViewModel()
       {
           AddCarButtonCommand = new RelayCommand(AddCarButton, param => this.canExecute);
           CheckButtonCommand = new RelayCommand(CheckButtonButton, param => this.canExecute);
           InsuranceButtonCommand = new RelayCommand(InsuranceButtonButton, param => this.canExecute);
           ComprehensiveCoverButtonCommand = new RelayCommand(ComprehensiveCoverButton, param => this.canExecute);
       }
      
       private void AddCarButton(object sender)
      {
          NavigationPage.page.NavigationService.Navigate(new Uri("View/CarPage.xaml", UriKind.Relative));
      }
       private void CheckButtonButton(object sender)
       {
           NavigationPage.page.NavigationService.Navigate(new Uri("View/PrintPage.xaml", UriKind.Relative));
       }
       private void InsuranceButtonButton(object sender)
       {
           NavigationPage.page.NavigationService.Navigate(new Uri("View/InsurancePage.xaml", UriKind.Relative));
       }
       private void ComprehensiveCoverButton(object sender)
       {
           NavigationPage.page.NavigationService.Navigate(new Uri("View/ComprahensivePage.xaml", UriKind.Relative));
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
      private ICommand checkButtonCommand;
      public ICommand CheckButtonCommand
      {
          get
          {
              return checkButtonCommand;
          }
          set
          {
              checkButtonCommand = value;
          }
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
      private ICommand comprehensiveCoverButtonCommand;
      public ICommand ComprehensiveCoverButtonCommand
      {
          get
          {
              return comprehensiveCoverButtonCommand;
          }
          set
          {
              comprehensiveCoverButtonCommand = value;
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
    }
}
