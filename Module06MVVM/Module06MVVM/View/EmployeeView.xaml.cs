using Module06MVVM.ViewModel;
using Module06MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Module06MVVM.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmployeeView : ContentPage
    {
        //Set a Variable
        EmployeeViewModel _viewModel;
        bool _isUpdate;
        int employeeID;
        public EmployeeView()
        {
            InitializeComponent();
            //BindingContext = new EmployeeViewModel(); 

            _viewModel = new EmployeeViewModel();
            _isUpdate = false;
        }

        public EmployeeView(EmployeeModel obj)
        {
            InitializeComponent();
            _viewModel = new EmployeeViewModel();
            if (obj != null )
            {
                employeeID = obj.Id;
                txtName.Text = obj.Name;
                txtEmail.Text = obj.Email;
                txtAddress.Text = obj.Address;
                _isUpdate |= true;
            }
        }

        public async void btnSaveUpdate_Clicked(Object sender, EventArgs e)
        {
            EmployeeModel obj = new EmployeeModel();
            obj.Name = txtName.Text;
            obj.Email = txtEmail.Text;
            obj.Address = txtAddress.Text;

            if(_isUpdate)
            {
                obj.Id = employeeID;
                await _viewModel.UpdateEmployee(obj);
            }
            else
            {
                _viewModel.InsertEmployee(obj);
            }
            await this.Navigation.PopAsync();
        }
    }
}