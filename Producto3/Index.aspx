<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Producto3.Index" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css" />
    <link href="estilos/esitlo.css" rel="stylesheet" />

</head>
<body>
    <header align="center" >    
        <div id="headerbg" runat="server">
            <br />
            <h1 >BIENVENIDO</h1>
        </div>
    </header>
    <form id="form1" runat="server">
        <!-- Contenido -->
        <div class="container mt-5">
        <asp:Label ID="Label1" runat="server" Text="&nbsp;"></asp:Label>
            <h2 class="text-center">Datos Climatológicos</h2>
            <br />

            <!-- Contenido de los datos climatológicos -->
            <div class="row">
                <div class="col-md-6 mb-3">
                    <span class="h4">Ingresar Ciudad a buscar</span>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Ciudad" required="true" ></asp:TextBox>
                </div>
                <div class="col-md-6 mb-3">
                    <span class="h4">Ingresar País a buscar</span>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="País" required="true" ></asp:TextBox>
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

    </form>
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
