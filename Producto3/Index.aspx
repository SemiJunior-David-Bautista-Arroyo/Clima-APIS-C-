﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Producto3.Index" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Jscript/PlayerYouTube.js"></script>
    <link href="estilos/esitlo.css" rel="stylesheet" />

</head>
<body onload="onYouTubeIframeAPIReady()">
    <!-- Se agrega el Onload -->
    <header align="center">
        <div id="headerbg" runat="server">
            <br />
            <h1>BIENVENIDO</h1>
        </div>
    </header>
    <form id="form1" runat="server">
        <!-- Contenido -->
        <asp:Label ID="Label1" runat="server" Text="" align="center"></asp:Label>
        <div class="container mt-5">
            <h2 class="text-center">Datos Climatológicos</h2>
            <br />
            <asp:Label ID="Label121" runat="server" Text=""></asp:Label>

            <!-- Contenido de los datos climatológicos -->
            <div class="row">
                <div class="col-md-6 mb-3">
                    <span class="h4">Ingresar Ciudad a buscar</span>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Ciudad" required="true"></asp:TextBox>
                </div>
                <div class="col-md-6 mb-3">
                    <span class="h4">Ingresar Código de País a buscar</span>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Código País" required="true"></asp:TextBox>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-md-12 text-center">
                    <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" CssClass="btn" /><br />
                </div>
            </div>
            <br />

            <!-- Presentar las cosas -->
            <div class="container mt-4">
                <div class="row">
                    <div class="col-md-12 text-center">
                        <h2 class="h2">
                            <asp:Label ID="Label120" runat="server" Text=""></asp:Label>
                        </h2>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col-sm-12 col-md-6 text-sm-end h5">
                        <asp:Label ID="Label2" runat="server" Text="&nbsp;"></asp:Label><br />
                        <asp:Label ID="Label3" runat="server" Text="Temperatura"></asp:Label><br />
                        <asp:Label ID="Label4" runat="server" Text="Lon"></asp:Label><br />
                        <asp:Label ID="Label5" runat="server" Text="Lat"></asp:Label><br />
                    </div>
                    <div class="col-sm-12 col-md-6 text-sm-start h5">
                        <asp:Label ID="Label6" runat="server" Text="&nbsp;"></asp:Label><br />
                        <asp:Label ID="Label7" runat="server" Text="Temperatura"></asp:Label><br />
                        <asp:Label ID="Label8" runat="server" Text="Lon"></asp:Label><br />
                        <asp:Label ID="Label9" runat="server" Text="Lat"></asp:Label><br />
                    </div>
                </div>

                <div class="row mt-4">
                    <div class="col-md-12 text-center">
                        <asp:Image ID="Image1" runat="server" CssClass="img-fluid rounded-circle" Width="120" />
                    </div>
                </div>
            </div>
        </div>
        <!-- Aquí termina EL clima-->
        <!-- Aquí inicia GASOLINAS Y VIDEO DE YOUTUBE-->

        <div class="container" align="center">
            <div class="row">
                <div class="col-sm-12 col-md-12">
                    <br />
                    <br />
                    <div id="player"></div>
                    <br />
                    <br />
                    <h4 align="center">Precio Por litro de Gasolina en México</h4>
                    <br />
                    <iframe width="380" height="580" frameborder="0" runat="server" id="gasolina"></iframe>
                </div>
            </div>
        </div>
        <!-- Aquí termina GASOLINAS Y VIDEO DE YOUTUBE-->
    </form>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
