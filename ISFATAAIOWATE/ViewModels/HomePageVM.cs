using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Avalonia.Controls;
using ISFATAAIOWATE.Entities;
using ISFATAAIOWATE.Views;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;

namespace ISFATAAIOWATE.ViewModels;

public class HomePageVM : ViewModelBase
{
    private Employee _selectedEmployee;
    private ObservableCollection<Employee> _employees;
    private ObservableCollection<EmployeeClothing> _employeeClothings;

    public ObservableCollection<Employee> Employees
    {
        get => _employees;
        set => this.RaiseAndSetIfChanged(ref _employees, value);
    }
    
    public ObservableCollection<EmployeeClothing> EmployeeClothings
    {
        get => _employeeClothings;
        set => this.RaiseAndSetIfChanged(ref _employeeClothings, value);
    }
    private void OpenWindowImpl1(Window obj)
    {
        EmployeeRegistrationWindow employeeRegistrationWindow = new EmployeeRegistrationWindow();
        employeeRegistrationWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl2(Window obj)
    {
        EmployeeEditingWindow employeeEditingWindow = new EmployeeEditingWindow();
        employeeEditingWindow.ShowDialog(obj);
        Employees = new ObservableCollection<Employee>(Helper.GetContext().Employees.Include(e => e.Position).ToList());
    }
    private void OpenWindowImpl3(Window obj)
    {
        ClothingDeliveryWindow clothingDeliveryWindow = new ClothingDeliveryWindow();
        clothingDeliveryWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl4(Window obj)
    {
        ClothesIssuanceLogsWindow clothesIssuanceLogsWindow = new ClothesIssuanceLogsWindow();
        clothesIssuanceLogsWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl5(Window obj)
    {
        RentingOutClothesWindow rentingOutClothesWindow = new RentingOutClothesWindow();
        rentingOutClothesWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl6(Window obj)
    {
        EditingAndDeletingClothesWindow editingAndDeletingClothesWindow = new EditingAndDeletingClothesWindow();
        editingAndDeletingClothesWindow.ShowDialog(obj);
    }
    private void OpenWindowImpl7(Window obj)
    {
        AuthorizationWindow authorizationWindow = new AuthorizationWindow();
        authorizationWindow.Show();
        obj.Close();
    }
    public ReactiveCommand<Window, Unit> OpenWindow1 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow2 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow3 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow4 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow5 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow6 { get; }
    public ReactiveCommand<Window, Unit> OpenWindow7 { get; }
    public HomePageVM()
    {
        OpenWindow1 = ReactiveCommand.Create<Window>(OpenWindowImpl1);
        OpenWindow2 = ReactiveCommand.Create<Window>(OpenWindowImpl2);
        OpenWindow3 = ReactiveCommand.Create<Window>(OpenWindowImpl3);
        OpenWindow4 = ReactiveCommand.Create<Window>(OpenWindowImpl4);
        OpenWindow5 = ReactiveCommand.Create<Window>(OpenWindowImpl5);
        OpenWindow6 = ReactiveCommand.Create<Window>(OpenWindowImpl6);
        OpenWindow7 = ReactiveCommand.Create<Window>(OpenWindowImpl7);
        Employees = new ObservableCollection<Employee>(Helper.GetContext().Employees.Include(e => e.Position).ToList());
        EmployeeClothings = new ObservableCollection<EmployeeClothing>(Helper.GetContext().EmployeeClothings.Include(e => e.Clothing).ToList());
    }
}