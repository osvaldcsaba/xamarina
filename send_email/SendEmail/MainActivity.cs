using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SendEmail
{
    [Activity (Label = "Email k�ld�", MainLauncher = true)]
    public class MainActivity : Activity
    {

        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            SetContentView (Resource.Layout.Main);

            Button button = FindViewById<Button> (Resource.Id.myButton);
            
            button.Click += (sender,e) =>
            {              
                var email = new Intent (Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail, "csaba.osvald@gmail.com");
                email.PutExtra(Android.Content.Intent.ExtraCc, "csaba.osvald@freemail.hu");
                email.PutExtra(Android.Content.Intent.ExtraSubject, "Pr�ba lev�l");
                email.PutExtra(Android.Content.Intent.ExtraText, "Szia! Ez egy pr�ba lev�l sz�vege.");
                email.SetType("message/rfc822");
                StartActivity(email);
            };
 
        }
    }
}


