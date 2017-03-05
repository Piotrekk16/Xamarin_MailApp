using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace Mail_App
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            EditText email = FindViewById<EditText>(Resource.Id.Email);
            EditText subject = FindViewById<EditText>(Resource.Id.Subject);
            EditText bodyMail = FindViewById<EditText>(Resource.Id.BodyMail);
            Button sendButton = FindViewById<Button>(Resource.Id.SendButton);
            sendButton.Click += (object sender, EventArgs e) =>
            {
                var sendIntent = new Intent(Intent.ActionSend);
                sendIntent.PutExtra(Intent.ExtraEmail, new string[] { email.Text });
                sendIntent.PutExtra(Intent.ExtraSubject, subject.Text);
                sendIntent.PutExtra(Intent.ExtraText,
                bodyMail.Text);
                sendIntent.SetType("message/rfc822");
                StartActivity(sendIntent);
            };

        }
    }
}

