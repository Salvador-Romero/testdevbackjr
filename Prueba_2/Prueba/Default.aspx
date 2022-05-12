<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 150px;
        }
        .auto-style3 {
            height: 23px;
            width: 150px;
        }
    </style>

<body>
    
    <div>
    
        Usuarios<br />
        <br />
        <asp:Panel ID ="RegistroUsuario" runat="server" Visible ="false">
        <table style="width:46%;">
        <tr>
            <asp:Label ID="lblTexto" runat="server"></asp:Label>
        </tr>
            <tr>
                <td class="auto-style2">Login:</td>
                <td>
                    <asp:TextBox ID="txtLogin" runat="server" Font-Size="14pt" Width="303px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style2">Nombre:</td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" Font-Size="14pt" Width="303px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td class="auto-style2">Apellido Paterno:</td>
                <td>
                    <asp:TextBox ID="txtApellidoPaterno" runat="server" Font-Size="14pt" Width="303px"></asp:TextBox>
                </td>
               
            </tr>
            <tr>
                <td class="auto-style2">Apellido Materno:</td>
                <td>
                    <asp:TextBox ID="txtApellidoMaterno" runat="server" Font-Size="14pt" Width="303px"></asp:TextBox>
                </td>
               
            </tr>
            
            <tr>
                <td class="auto-style2"><asp:Label ID="lblsueldo" runat="server"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtSueldo" runat="server" Font-Size="14pt" Width="303px"></asp:TextBox>
                </td>
               
            </tr>
            
        </table>
    <p>
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
        </p>
        <p>
        </asp:Panel>
            <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar" />
            <asp:Button ID="btnAgregar2" runat="server" OnClick="btnAgregar2_Click" Text="Agregar" Visible="false"/>
&nbsp;<asp:Button ID="btnCambiar" runat="server" OnClick="btnCambiar_Click" Text="Cambiar Sueldo" />
&nbsp;<asp:Button ID="btnCambiar2" runat="server" OnClick="btnCambiar2_Click" Text="Cambiar Sueldo" Visible="false"/>
&nbsp;<asp:Button ID="btnListar" runat="server" OnClick="btnListar_Click" Text="Listar" />
&nbsp;<asp:Button ID="btnDescargar" runat="server" OnClick="btnDescargar_Click" Text="Descargar CVS" />
&nbsp;<asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Retroceder" Visible="false" />
        </p>

    </div>
    <asp:Panel ID="Listado" runat="server">
        <asp:GridView ID="TOpPersonas" runat="server">
        </asp:GridView>
   </asp:Panel>
</body>
</html>