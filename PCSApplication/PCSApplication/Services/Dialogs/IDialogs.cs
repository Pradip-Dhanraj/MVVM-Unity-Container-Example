using System;
using System.Collections.Generic;
using System.Text;

namespace PCSApplication.Services.Dialogs
{
    public interface IDialogs
    {
        void StartLoadingDialoge(string loader_message);
        void HideLoadingDialogeAsync();
        void LockDialog();
        void UnlockDialog();

    }
}
