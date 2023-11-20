using Producto3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Producto3
{
    public partial class Index : System.Web.UI.Page
    {
        Helper Sw;
        public Index()
        {
            Sw = new Helper();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)  // Verifica si es la primera carga de la página
            {
                Sw.state = "Puebla";
                Sw.countrycode = "MX";
            }

            try
            {
                await Sw.ObtenerCoordenadasAsync();
                Label2.Text = Sw.Lat_();
                Label4.Text = Sw.Lon_();

                await Sw.ObtenerClimaAsync();
                Label3.Text = Sw.Temperatura().ToString();
            }
            catch (Exception)
            {
                Label1.Text = Sw.Error;
            }

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            /* Utiliza el operador de fusión nula(??) para asignar TextBox1.Text a Sw.state.
             Si TextBox1.Text es nulo o una cadena vacía, se asigna "Puebla" como valor predeterminado. */

            Sw.state = TextBox1.Text ?? "Puebla";
            Sw.countrycode = TextBox2.Text ?? "MX";

            try
            {
                await Sw.ObtenerCoordenadasAsync();
                Label2.Text = Sw.Lat_();
                Label4.Text = Sw.Lon_();
                Label5.Text = Sw.Lat_();

                
            }
            catch (Exception)
            {
                Label1.Text = Sw.Error;
            }
        }
    }
}