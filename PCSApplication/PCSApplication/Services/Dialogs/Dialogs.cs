using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace PCSApplication.Services.Dialogs
{
    class Dialogs : IDialogs
    {
        public IUserDialogs dialog { get; private set; }
        public bool IsLock { get; set; }

        public Dialogs()
        {
            dialog = Acr.UserDialogs.UserDialogs.Instance;
            IsLock = false;
        }
        public void StartLoadingDialoge(string loader_message)
        {
            dialog.ShowLoading(loader_message);
        }

        public async void HideLoadingDialogeAsync()
        {
            await Task.Delay(300);
            dialog.HideLoading();
        }

        public void LockDialog()
        {
            IsLock = true;
        }

        public void UnlockDialog()
        {
            IsLock = false;
        }
    }
}
