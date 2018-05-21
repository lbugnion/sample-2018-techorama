using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Net.Http;

namespace SharedFiles.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private const string Url = "https://lbxamnamesample.azurewebsites.net/api/hello/name/{name}";

        private RelayCommand<string> _executeCommand;
        private string _name = string.Empty;
        private string _result = "Nothing yet";

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                Set(ref _name, value);
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                Set(ref _result, value);
            }
        }

        public RelayCommand<string> ExecuteCommand
        {
            get
            {
                return _executeCommand
                    ?? (_executeCommand = new RelayCommand<string>(
                    async p =>
                    {
                        Result = "Please wait";

                        try
                        {
                            var client = new HttpClient();
                            var url = Url.Replace("{name}", Name);
                            Result = await client.GetStringAsync(url);
                        }
                        catch (Exception ex)
                        {
                            Result = "There was an error";
                        }
                    }));
            }
        }
    }
}
