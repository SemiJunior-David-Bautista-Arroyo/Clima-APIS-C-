using Producto3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Producto3
{
    public partial class Index : System.Web.UI.Page
    {
        Helper Sw;
        Helper helper;
        public Index()
        {
            Sw = new Helper();
        }

        protected async void Page_Load(object sender, EventArgs e)
        {
            helper = new Helper();
            //CLIMA
            if (!IsPostBack)//Para que solo se cargue la primera vez
            {
                Sw.state = "Puebla";
                Sw.countrycode = "MX";
            }

            try
            {
                await Sw.ObtenerCoordenadasAsync();
                await Sw.ObtenerClimaAsync();
                MostrarDatosClimatologicos();//Metodo para mostrar los datos
                

            }
            catch (Exception)
            {
                Label1.Text = Sw.Error;
            }

        }

        protected async void Button1_Click(object sender, EventArgs e)
        {
            //Se obtienen los valores de los textbox y se mandan como valor de state y country code
            if (TextBox2.Text.Length < 4) {
                Sw.state = TextBox1.Text;
                Sw.countrycode = TextBox2.Text;
                helper.Ciudad = TextBox1.Text;


            try
            {
                await Sw.ObtenerCoordenadasAsync();
                await Sw.ObtenerClimaAsync();
                MostrarDatosClimatologicos();
                
            }
            catch (Exception)
            {
                Label1.Text = Sw.Error;
            }
            }
            else
            {
                Label121.Text = "Código de País no encontrado";
            }
        }

        private void MostrarDatosClimatologicos()
        {
            //Mostrar temperatura 
            Label120.Text = Sw.Name();
            

            Label2.Text = $"Temperatura Actual: {Sw.TemperaturaActual()} °C";
            Label3.Text = $"Temperatura Máxima: {Sw.TemperaturaMaxima()} °C";
            Label4.Text = $"Temperatura Mínima: {Sw.TemperaturaMinima()} °C";
            //Mostrar demás 
            Label5.Text = $"Descripción del Clima: {Sw.DescripcionDelClima()}";
            Label6.Text = $"Nubosidad: {Sw.Nubosidad()}%";
            Label7.Text = $"Humedad: {Sw.Humedad()}%";
            Label8.Text = $"Hora de Salida del Sol: {Sw.HoraSalidaDelSol().ToString("HH:mm:ss")}";
            Label9.Text = $"Hora de Puesta de Sol: {Sw.HoraPuestaDeSol().ToString("HH:mm:ss")}";
            //Imagen del clima
            Image1.Attributes.Add("src", Sw.ImagenDescriptivaDelClima());
            Image1.AlternateText = "Clima Icon";
            //Cambiar de color el head
            string color = "";
            string letra = "";

            if (Sw.DescripcionDelClima().ToLower() == "cielo claro")
            {
                color = "#BDECB6";
            }
            else if (Sw.DescripcionDelClima().ToLower() == "algo de nubes")
            {
                
                color = "aqua";
            }else if (Sw.DescripcionDelClima().ToLower() == "nubes dispersas")
            {
                
                color = "gray";
            }
            else if (Sw.DescripcionDelClima().ToLower() == "nubes")
            {
                
                color = "#C8A2C8";
            }else if (Sw.DescripcionDelClima().ToLower() == "lluvia ligera")
            {
                
                color = "#675f6d";
            }else if (Sw.DescripcionDelClima().ToLower() == "niebla")
            {
                color = "#000000";
                letra = "white";
            }else if (Sw.DescripcionDelClima().ToLower() == "muy nuboso")
            {
                color = "pink";
                letra = "white";
                
            }
            else if (Sw.DescripcionDelClima().ToLower() == "nieve")
            {
                color = "#9dcfdd";
            }

            headerbg.Style.Add("background", color);
            headerbg.Style.Add("color", letra);
            Button1.Style.Add("background",color);
            Button1.Style.Add("color",letra);
            

            //Aquí inicia GASOLINAS
            
            string abr = helper.ObtenerAbreviatura();

            if (!string.IsNullOrEmpty(abr))
            {
                gasolina.Src = "https://petrointelligence.com/api/api_precios.html?consulta=estado&estado=" + abr;
            }
            else
            {
                // Visualizar la imagen con la leyenda
                gasolina.Src = "https://petrointelligence.com/api/api_precios.html?consulta=estado&estado=-1";
            }
        }






    }
}
