using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Text;

namespace Lista.Valaszto
{
    [Activity(Label = "Lista.Valaszto", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        ListView listView;
        public string[] napok = {"Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek", "Szombat", "Vasárnap"};

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            var valasztButton = FindViewById<Button>(Resource.Id.button1);
            valasztButton.Click += (e, s) =>
            {
                var builder = new StringBuilder();
                var sparseArray = FindViewById<ListView>(Resource.Id.listView1).CheckedItemPositions;

                for (int i = 0; i < sparseArray.Size(); i++)
                {
                    builder.AppendLine(string.Format("{0} - {1}", sparseArray.KeyAt(i), sparseArray.ValueAt(i)));
                }
                ShowAlert("Lista választó", builder.ToString());
            };

            listView = FindViewById<ListView>(Resource.Id.listView1);
            listView.Adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItemMultipleChoice, napok);
            listView.ChoiceMode = ChoiceMode.Multiple;

            RegisterForContextMenu(listView);
        }

        private void ShowAlert(string title, string message)
        {
            Android.App.AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog alertDialog = builder.Create();
            alertDialog.SetTitle(title);
            alertDialog.SetIcon(Android.Resource.Drawable.IcDialogAlert);
            alertDialog.SetMessage(message);
            alertDialog.SetButton("OK", (s, e) =>
            {
                // valami
            });
            alertDialog.Show();
        }

        public override void OnCreateContextMenu(IContextMenu menu, View v, IContextMenuContextMenuInfo menuInfo)
        {
            base.OnCreateContextMenu(menu, v, menuInfo);

            menu.Add("Másol");
            menu.Add("Töröl");
            menu.Add("Átnevez");
            menu.SetHeaderTitle("Fájlműveletek");
        }

        public override bool OnContextItemSelected(IMenuItem item)
        {
            var info = (AdapterView.AdapterContextMenuInfo)item.MenuInfo;
            var menuTitle = item.TitleFormatted.ToString();

            switch (menuTitle)
            {
                case "Másol":
                    var listItem = napok[info.Position];
                    ShowAlert("Másol","Másolás...");
                    break;
                case "Töröl":
                    break;
                case "Átnevez":
                    break;
                default:
                    break;
            }

            return base.OnContextItemSelected(item);
        }

    }
}

