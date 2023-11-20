using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace Producto3.Models
{
    public class Helper
    {
        Root root;
        public string Error { get; set; }
        string DirBase;


        HttpMessageHandler Handler;

        public Helper()
        {
            
        }

        //Entrada valores de textbox
        public string state { get; set; }
        public string countrycode { get; set; }


        public async Task ObtenerCoordenadasAsync() //utilizar el primer API y obtener coordenadas
        {

            DirBase = "https://nominatim.openstreetmap.org";
            string SolicitudClienteURI = $"search?q={state}&countrycodes={countrycode}&format=json&addressdetails=0";

            try
            {
                using (var Cliente = new HttpClient(new HttpClientHandler()))
                {
                    Cliente.BaseAddress = new Uri(DirBase);
                    Cliente.DefaultRequestHeaders.Accept.Clear();
                    Cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));
                    Cliente.DefaultRequestHeaders.Add("User-Agent", "Producto3");//Se tiene que agregar un encabezado de usuario para utilizar el api

                    HttpResponseMessage respuesta = await Cliente.GetAsync($"{SolicitudClienteURI}");
                    respuesta.EnsureSuccessStatusCode();

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var jsoncadena = await respuesta.Content.ReadAsStringAsync();
                        //root = JsonConvert.DeserializeObject<Root>(jsoncadena);

                        /* Root Está entrando como una lista de objetos entonces se
                         Deserializa la cadena JSON en una lista de objetos Root
                        */
                        root = JsonConvert.DeserializeObject<List<Root>>(jsoncadena).FirstOrDefault();// Toma el primer elemento de la lista si no existe es igual a default
                    }
                    else
                    {
                        Error = "Se ha producido un error al solicitar el servicio web";
                        throw new Exception();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Error = $"Se produjo un error: {ex.Message}";
            }

        }
        //Obtener coordenadas del estado            
        public string Lat_()
        {
            return root.lat;
        }

        public string Lon_()
        {

            return root.lon;
        }

        public string Name()
        {
            return (root.name);
        }

        //Utilizar segundo API y obtener datos del clima etc.
        Clima Clima;
        
        public string apikey = "06b86652022e63756bceade342db692d";
        public async Task ObtenerClimaAsync() //utilizar el primer API y obtener coordenadas
        {

            DirBase = "https://api.openweathermap.org";
            string SolicitudClienteURI = $"data/2.5/weather?lat={Lat_()}&lon={Lon_()}&appid={apikey}&lang=es";

            try
            {
                using (var Cliente = new HttpClient(new HttpClientHandler()))
                {
                    Cliente.BaseAddress = new Uri(DirBase);
                    Cliente.DefaultRequestHeaders.Accept.Clear();
                    Cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

                    HttpResponseMessage respuesta = await Cliente.GetAsync($"{SolicitudClienteURI}");
                    respuesta.EnsureSuccessStatusCode();

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var jsoncadena = await respuesta.Content.ReadAsStringAsync();

                        Clima = JsonConvert.DeserializeObject<Clima>(jsoncadena);
                    }
                    else
                    {
                        Error = "Se ha producido un error al solicitar el servicio web";
                        throw new Exception();
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Error = ex.Message;
            }
            catch (Exception ex)
            {
                Error = $"Se produjo un error: {ex.Message}";
            }

        }

        //Obtener datos del clima
        public double TemperaturaActual()
        {
            if (Clima != null && Clima.main != null)
            {
                double TempActual = Clima.main.temp - 273.15;
                return TempActual;
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        public double TemperaturaMaxima()
        {
            if (Clima != null && Clima.main != null)
            {
                double TempMax = Clima.main.temp_max - 273.15;
                return TempMax;
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        public double TemperaturaMinima()
        {
            if (Clima != null && Clima.main != null)
            {
                double TempMin = Clima.main.temp_min - 273.15;
                return TempMin;
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        public string ImagenDescriptivaDelClima()
        {
            if (Clima != null && Clima.weather != null && Clima.weather.Count > 0)
            {
                var img = Clima.weather[0].icon;
                var urlImg = $"http://openweathermap.org/img/wn/{img}.png";
                return urlImg;
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        public string DescripcionDelClima()
        {
            if (Clima != null && Clima.weather != null && Clima.weather.Count > 0)
            {
                return Clima.weather[0].description;
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        public int Nubosidad()
        {
            if (Clima != null && Clima.clouds != null)
            {
                return Clima.clouds.all;
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        public int Humedad()
        {
            if (Clima != null && Clima.main != null)
            {
                return Clima.main.humidity;
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        public DateTime HoraSalidaDelSol()
        {
            if (Clima != null && Clima.sys != null)
            {
                return UnixTimeStampToDateTime(Clima.sys.sunrise);
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        public DateTime HoraPuestaDeSol()
        {
            if (Clima != null && Clima.sys != null)
            {
                return UnixTimeStampToDateTime(Clima.sys.sunset);
            }
            else
            {
                throw new InvalidOperationException("Datos de clima no disponibles.");
            }
        }

        // Método para convertir el tiempo Unix a DateTime
        private DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(unixTimeStamp).ToLocalTime();
        }







    }
}
            

        
