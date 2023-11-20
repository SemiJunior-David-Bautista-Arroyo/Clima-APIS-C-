<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Producto3.Index"  Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <header align="center">
        <h1>header</h1>
    </header>
    <form id="form1" runat="server">
        <!-- Contenido -->
        <asp:Label ID="Label1" runat="server" Text="&nbsp;"></asp:Label>
        <div class="container mt-5">
            <h2>Datos Climatológicos</h2><br />
            <asp:Label ID="Label2" runat="server" Text="&nbsp;"></asp:Label><br />
            <asp:Label ID="Label3" runat="server" Text="Temperatura"></asp:Label><br />
            <!-- Contenido de los datos climatológicos -->
            <span class="h4">Ingresar Estado a buscar</span>
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Estado"></asp:TextBox>
            <span class="h4">Ingresar País a buscar</span>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="País"></asp:TextBox>

            <asp:Label ID="Label5" runat="server" Text="Lat"></asp:Label><br />
            <asp:Label ID="Label4" runat="server" Text="Lon"></asp:Label><br />
            <asp:Button ID="Button1" runat="server" Text="Buscar" OnClick="Button1_Click" />

        </div>

        <div class="container mt-5">
            <h2>Video sobre Puebla</h2>
            <!-- Agregar contenido relacionado con el clima -->
        </div>

        <div class="container mt-5">
            <h2>Precios de Gasolina</h2>
            <!-- Agregar contenido relacionado con el clima -->
        </div>

        <div class="container mt-5">
            <h2>Convertidor de Divisas</h2>
            <div class="row">
                <div class="col-md-6">
                    <!-- Dropdown para la moneda origen -->
                    <select class="form-select mt-3">
                        <!-- Agregar opciones del dropdown -->
                    </select>
                </div>
                <div class="col-md-6">
                    <!-- Dropdown para la moneda destino -->
                    <select class="form-select mt-3">
                        <!-- Agregar opciones del dropdown -->
                    </select>
                </div>
            </div>
            <div class="row mt-3">
                <div class="col-md-6">
                    <!-- Campo para la cantidad a convertir -->
                    <label for="TextBox8" class="form-label">Cantidad a convertir:</label>
                    <input type="text" id="TextBox9" class="form-control" placeholder="Insertar cantidad" />
                </div>
                <div class="col-md-6">
                    <!-- Resultado de la conversión -->
                    <label for="txtResultado" class="form-label">Resultado:</label>
                    <input type="text" id="txtResultado" class="form-control" readonly="true" />
                </div>
            </div>
        </div>
    </form>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
