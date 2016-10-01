<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaPersona.aspx.cs" Inherits="Personas.Consultas.ConsultaPersona" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <center>
        <p>
            Buscar Por:<asp:DropDownList ID="DropDownListBucarPor" runat="server">
                <asp:ListItem>PersonaId</asp:ListItem>
                <asp:ListItem>Nombre</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            =<asp:TextBox ID="TextBoxBuscarPor" runat="server"></asp:TextBox>
            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" />
        </p> 
        </center>
    </div>

    <div>
        <center>
        <p>
            <asp:GridView ID="GridViewPersona" runat="server" AutoGenerateColumns="False" Width="395px">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PersonaConnectionString %>" SelectCommand="SELECT Persona.*, PersonaTelefono.TipoTelefono, PersonaTelefono.Telefono FROM Persona CROSS JOIN PersonaTelefono"></asp:SqlDataSource>
        </p>
        </center>
    </div>

</asp:Content>
