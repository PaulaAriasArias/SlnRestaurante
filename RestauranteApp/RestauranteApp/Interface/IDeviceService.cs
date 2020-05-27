using System;
using System.Collections.Generic;
using System.Text;

namespace RestauranteApp.Interface
{
    public interface IDeviceService
    {
        bool CheckConnectivity();

        void OpenBrowser(string url);

        void Call(string phone);

    }
}
