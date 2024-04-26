﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Producto3.Index" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Jscript/PlayerYouTube.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=Material+Symbols+Outlined:opsz,wght,FILL,GRAD@24,400,0,0" />
    <link href="estilos/esitlo.css" rel="stylesheet" />

</head>
<body onload="onYouTubeIframeAPIReady()">
    <!-- Se agrega el Onload -->
    <header align="center">
        <div class="container">
            <div id="headerbg" runat="server">
                <br />
                <h1>BIENVENIDO</h1>
            </div>
        </div>
    </header>
    <form id="form1" runat="server">
        <!-- Contenido -->
        <div class="container mt-5">
            <h2 class="text-center">Datos Climatológicos</h2>
        <asp:Label ID="Label1" runat="server" CssClass="text-danger" Text="" align="center"></asp:Label>
            <br />

            <!-- Formulario de búsqueda -->
            <div class="row">
                <div class="col-md-4">
                    <span class="h4">Ingresar Ciudad a buscar</span>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Ciudad" required="true" minlength="3"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <span class="h4">Ingresar Código de País</span>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Código País" required="true" MaxLength="3"></asp:TextBox>
                </div>
                <div class="col-md-4 text-center">
                    <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" CssClass="btn" /><br />
                </div>
            </div>
            <br />

            <!-- Presentación de datos climatológicos -->
            <div class="row">
                <!-- Mapa izquierdo -->
                <div class="col-md-4">
                    <iframe id="mapa" width="400" height="480" frameborder="0" runat="server"></iframe>
                </div>

                <!-- Datos climatológicos en el centro -->
                <div class="col-md-4">
                    <div class="container mt-4">
                        <div class="row mt-4">
                            <div class="col-md-12 text-center">
                                <asp:Image ID="Image1" runat="server" CssClass="img-fluid rounded-circle" Width="150" />
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12 text-center">
                                <h2 class="h2">
                                    <asp:Label ID="Label120" runat="server" Text=""></asp:Label>
                                    <asp:Label ID="Label121" runat="server" Text=""></asp:Label>
                                </h2>
                            </div>
                        </div>


                        <div class="row mt-4">
                            <div class="col-sm-12 col-md-6 text-center h5">
                                <span class="h4">Datos Tiempo</span><br />
                                <br />
                                <span class="material-symbols-outlined">thermometer
                                </span>
                                <asp:Label ID="Label2" runat="server" Text="&nbsp;"></asp:Label><br />
                                <span class="material-symbols-outlined">thermometer_gain
                                </span>
                                <asp:Label ID="Label3" runat="server" Text="Temperatura"></asp:Label><br />
                                <span class="material-symbols-outlined">thermometer_loss
                                </span>
                                <asp:Label ID="Label4" runat="server" Text="Lon"></asp:Label><br />
                                <span class="material-symbols-outlined">nest_farsight_weather
                                </span>
                                <asp:Label ID="Label5" runat="server" Text="Lat"></asp:Label><br />
                            </div>

                            <div class="col-sm-12 col-md-6 text-center h5">
                                <span class="h4">Datos Clima</span><br />
                                <br />
                                <span class="material-symbols-outlined">partly_cloudy_day
                                </span>
                                <asp:Label ID="Label6" runat="server" Text="&nbsp;"></asp:Label><br />
                                <span class="material-symbols-outlined">humidity_percentage
                                </span>
                                <asp:Label ID="Label7" runat="server" Text="Temperatura"></asp:Label><br />
                                <span class="material-symbols-outlined">clear_day
                                </span>
                                <asp:Label ID="Label8" runat="server" Text="Lon"></asp:Label><br />
                                <span class="material-symbols-outlined">dark_mode
                                </span>
                                <asp:Label ID="Label9" runat="server" Text="Lat"></asp:Label><br />
                            </div>
                        </div>
                    </div>
                </div>
                <!--MAPAS DE LOCALIZACIÓN Y CLIMA -->
                <div class="col-md-4">
                    <iframe id="mapaclima" width="420" height="500" frameborder="0" runat="server"></iframe>
                </div>
            </div>
        </div>

        <!-- Aquí termina EL clima-->

        <!-- Aquí inicia GASOLINAS -->

        <div class="container" align="center">
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <br />
                    <br />
                    <div class="embed-responsive embed-responsive-16by9" id="player"></div>
                    <br />
                    <br />
                    <h4 align="center">Precio Por litro de Gasolina en México</h4>
                    <br />
                        <iframe src="https://petrointelligence.com/api/api_precios.html?consulta=estado&estado=PUE" width="680" frameborder="0" runat="server" id="gasolina"></iframe>
                </div>
            </div>
        </div>
        <!-- Aquí termina GASOLINAS-->
        <div class="container" align="center">
            <div class="row">
                <div class="col-sm-12 col-md-12 col-mt-12">
                    <h1>Conversor de Divisas</h1>
                    <!-- Botón que abre el modal -->
                    <button type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modaldivisas">
                        Abrir Conversor de Divisas
                    </button>
                </div>
            </div>
        </div>

        <!-- Modal -->
        <div class="modal" id="modaldivisas" role="dialog">
            <div class="modal-dialog">
                <!-- Contenido del modal -->
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title">Conversor de Divisas</h4>
                        <button type="button" class="close" data-bs-dismiss="modal">x</button>
                    </div>
                    <div class="modal-body">
                        <label for="ddlMonedaOrigen" class="h4">Moneda Origen:</label><br />
                        <asp:DropDownList ID="ddlMonedaOrigen" runat="server"></asp:DropDownList>
                        <br />
                        <label for="ddlMonedaDestino" class="h4">Moneda Destino:</label><br />
                        <asp:DropDownList ID="ddlMonedaDestino" runat="server"></asp:DropDownList>
                        <br />
                        <label for="txtCantidad" class="h4">Cantidad a Convertir: </label>
                        <asp:TextBox ID="txtCantidad" runat="server" placeholder="Cantidad"></asp:TextBox>

                        <asp:Button ID="Button2" runat="server" Text="Calcular" OnClick="btnConvertir_Click" CssClass="btn btn-success" />
                        <br />

                        <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
                    </div>
                </div>
            </div>
        </div>
        <br />
        <br />


        <!--Aquí deberá terminar conversor -->
    </form>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.esm.min.js"></script>
</body>
</html>
