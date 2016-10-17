using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MySql.Data.MySqlClient;
using System.Data;


namespace Estacionamiento_Entrada_Android
{
    [Activity(Label = "Estacionamiento Entrada", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.button1);

            button.Click += delegate {
                string connsqlstring = "Server=192.168.0.30Port=3306;database=estacionamiento;User Id=root;Password=root;charset=utf8";
                try
                {
                    DateTime thisDay = DateTime.Now;

                    MySqlConnection db = new MySqlConnection(connsqlstring);
                    db.Open();

                    string consulta = "INSERT INTO android(hora_entrada,minutos_entrada,segundos_entrada,dia_entrada,mes_entrada,año_entrada) VALUES ({0},{1},{2},{3},{4},{5});";
                    consulta = string.Format(consulta, thisDay.Hour, thisDay.Minute, thisDay.Second, thisDay.Day, thisDay.Month, thisDay, thisDay.Year);
                    MySqlCommand instruccion = new MySqlCommand(consulta, db);
                    instruccion.ExecuteNonQuery();
                    db.Close();
                    Toast.MakeText(this, "Datos Guardados", ToastLength.Long).Show();
  }
                catch (Exception ex)
                {
                    Toast.MakeText(this, ex.Message, ToastLength.Long).Show();
                }
            };
        }
    }
}

