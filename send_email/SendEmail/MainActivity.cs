
using Android.App;
using Android.Content;
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
                var email = new Intent (Intent.ActionSend);
                email.PutExtra(Intent.ExtraEmail, "csaba.osvald@gmail.com");
                email.PutExtra(Intent.ExtraCc, "csaba.osvald@freemail.hu");
                email.PutExtra(Intent.ExtraSubject, "Pr�ba lev�l");
                email.PutExtra(Intent.ExtraText, "Szia! Ez egy pr�ba lev�l sz�vege.");
                email.SetType("message/rfc822");
                StartActivity(email);
            };
 
        }
    }
}


