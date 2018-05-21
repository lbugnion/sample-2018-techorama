using Android.App;
using Android.Widget;
using Android.OS;
using GalaSoft.MvvmLight.Helpers;
using System.Collections.Generic;
using SharedFiles.ViewModel;

namespace PortableDroid
{
    [Activity(Label = "PortableDroid", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private IList<Binding> _bindings = new List<Binding>();

        private MainViewModel _vm;

        private MainViewModel Vm => _vm ?? (_vm = new MainViewModel());

        private EditText _myEdit;
        private Button _myButton;
        private TextView _myText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _myEdit = FindViewById<EditText>(Resource.Id.MyEdit);
            _myText = FindViewById<TextView>(Resource.Id.MyText);
            _myButton = FindViewById<Button>(Resource.Id.MyButton);

            _bindings.Add(this.SetBinding(
                () => Vm.Result,
                () => _myText.Text));

            _bindings.Add(this.SetBinding(
                () => Vm.Name,
                () => _myEdit.Text,
                BindingMode.TwoWay));

            _myButton.SetCommand(Vm.ExecuteCommand);
        }
    }
}

