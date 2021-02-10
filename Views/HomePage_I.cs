using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerVanzari.Views
{
    interface HomePage_I
    {

        event EventHandler HomePageLoaded;
        event EventHandler ButtonInregistrareVanzarePressed;
        event EventHandler BindGridProduseServicii;

        event EventHandler VanzariAziRequested;


    }
}
