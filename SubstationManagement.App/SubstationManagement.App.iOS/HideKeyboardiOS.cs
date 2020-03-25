using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using SubstationManagement.App.Utils;
using UIKit;

namespace SubstationManagement.App.iOS
{
	class HideKeyboardiOS : KeyBoard
	{
		public void DismissKeyboard()
		{
            UIApplication.SharedApplication.InvokeOnMainThread(() =>
            {
                var window = UIApplication.SharedApplication.KeyWindow;
                var vc = window.RootViewController;
                while (vc.PresentedViewController != null)
                {
                    vc = vc.PresentedViewController;
                }

                vc.View.EndEditing(true);
            });
        }
	}
}