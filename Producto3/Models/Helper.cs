using Newtonsoft.Json;
using PlayerYouTubeGasolinas.Models;
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

        /*Aquí termina el api de geolocalización*/
        //Inicia gasolinas


        /*Aquí termina GASOLINAS Y VIDEO*/
        public List<Codigos> DatosCodigos { get; set; }
        public string Ciudad { get; set; }
        public Helper()
        {
            DatosCodigos = new List<Codigos>();

            DatosCodigos.Add(new Codigos

            {
                Estado = "AGUASCALIENTES",
                Abreviatura = "AGS"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "BAJA CALIFORNIA",
                Abreviatura = "BC"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "BAJA CALIFORNIA SUR",
                Abreviatura = "BCS"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "CAMPECHE",
                Abreviatura = "CAMP"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "CHIAPAS",
                Abreviatura = "CHIS"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "CHIHUAHUA",
                Abreviatura = "CHIH"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "CIUDAD DE MÉXICO",
                Abreviatura = "CDMX"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "COAHUILA DE ZARAGOZA",
                Abreviatura = "COAH"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "COLIMA",
                Abreviatura = "COL"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "DURANGO",
                Abreviatura = "DGO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "ESTADO DE MÉXICO",
                Abreviatura = "MEX"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "GUANAJUATO",
                Abreviatura = "GTO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "GUERRERO",
                Abreviatura = "GRO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "HIDALGO",
                Abreviatura = "HGO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "JALISCO",
                Abreviatura = "JAL"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "MICHOACÁN DE OCAMPO",
                Abreviatura = "MICH"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "MORELOS",
                Abreviatura = "MOR "
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "NAYARIT",
                Abreviatura = "NAY "
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "NUEVO LEÓN",
                Abreviatura = "NL"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "OAXACA",
                Abreviatura = "OAX"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "PUEBLA",
                Abreviatura = "PUE"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "QUERÉTARO",
                Abreviatura = "QRO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "QUINTANA ROO",
                Abreviatura = "QROO"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "SAN LUIS POTOSÍ",
                Abreviatura = "SLP"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "SINALOA",
                Abreviatura = "SIN"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "SONORA",
                Abreviatura = "SON"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "TABASCO",
                Abreviatura = "TAB"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "TAMAULIPAS",
                Abreviatura = "TAMPS"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "TLAXCALA",
                Abreviatura = "TLAX"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "VERACRUZ",
                Abreviatura = "VER"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "YUCATÁN",
                Abreviatura = "YUC"
            });

            DatosCodigos.Add(new Codigos
            {
                Estado = "ZACATECAS",
                Abreviatura = "ZAC"
            });
        }
        //Aqui el cliente HTT´para la API de geolocalizacion
        //Aqui el cliente HTT´para la API de datos climatologicos

        public string ObtenerAbreviatura()
        {
            string abreviatura = "";
            for (int i = 0; i <= DatosCodigos.Count - 1; ++i)
            {
                if (DatosCodigos[i].Estado.ToUpper() == Ciudad.ToUpper())
                {
                    abreviatura = DatosCodigos[i].Abreviatura;
                    break;
                }
            }
            return abreviatura;
        }
        //Inicia divisas


        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double Amount { get; set; }
        public double ConvertedAmount { get; set; }

        public async Task ObtenerConversionAsync(string monedaOrigen, string monedaDestino, double cantidad)
        {
            try
            {
                string apiKey = "ffd0b5621a5e473dae99384e8dffdc1d";
                string baseUri = "https://exchange-rates.abstractapi.com";

                string requestUri = $"/v1/convert?api_key={apiKey}&base={monedaOrigen}&target={monedaDestino}&base_amount={cantidad}";

                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(baseUri);
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    cliente.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/Json"));

                    HttpResponseMessage respuesta = await cliente.GetAsync(requestUri);
                    respuesta.EnsureSuccessStatusCode();

                    if (respuesta.IsSuccessStatusCode)
                    {
                        var jsonCadena = await respuesta.Content.ReadAsStringAsync();

                        var resultadoConversion = JsonConvert.DeserializeObject<ConversionResponse>(jsonCadena);

                        ConvertedAmount = resultadoConversion.ConvertedAmount;
                    }
                    else
                    {
                        throw new Exception("Se ha producido un error al solicitar el servicio web");
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Error en la solicitud HTTP: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Se produjo un error: " + ex.Message);
            }




        }
    }
}
            

        
