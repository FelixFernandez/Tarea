<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroPersona.aspx.cs" Inherits="Personas.Registros.RegistroPersona" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:panel ID="panel" runat="server" BackColor="blue" BorderStyle="None">
            <div style="margin-left: 1px">
                    <div class="panel panel-default">
                        
                           <div class="panel-body" style="background-color: #0099FF">
                                <div style="margin-left: 361px">
                                    <strong><span class="auto-style1">PersonaId: </span></strong>
                                    <asp:TextBox ID="TextBoxPersonaId" runat="server" BorderWidth="1px" TextMode="Number" Width="93px"></asp:TextBox>
                                    &nbsp;<asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" BackColor="Gray" BorderStyle="None" ForeColor="White" Height="28px" />

                                </div>
                                        <br />
                                <div style="margin-left: 374px">
                                    &nbsp;<strong><span class="auto-style1">Nombre: </span></strong> <asp:TextBox ID="TextBoxNombre" runat="server" MaxLength="20" Width="446px" BorderWidth="1px"></asp:TextBox></div>
                                        <br />
                                <div style="margin-left: 404px">
                                    <strong><span class="auto-style1">Sexo: </span></strong><asp:DropDownList ID="DropDownListSexo" runat="server">
                                    <asp:ListItem>Masculino</asp:ListItem>
                                    <asp:ListItem>Femenina</asp:ListItem>
                                    <asp:ListItem>Otros</asp:ListItem>
                                    </asp:DropDownList>
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong><span class="auto-style1">Tipo Telefono: </span></strong><asp:DropDownList ID="DropDownListTipoTelefono" runat="server">
                                        <asp:ListItem>Casa</asp:ListItem>
                                        <asp:ListItem>Celular</asp:ListItem>
                                        <asp:ListItem>Trabajo</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                        <br />
                               <div style="margin-left: 372px">
                                   <span class="auto-style1"><strong>Telefono: </strong></span> <asp:TextBox ID="TextBoxTelefono" runat="server" TextMode="Phone" Width="446px" BorderWidth="1px"></asp:TextBox>
                                   &nbsp;<asp:Button ID="ButtonAgregar" runat="server" OnClick="ButtonAgregar_Click" Text="Agregar" BackColor="#009900" BorderStyle="None" ForeColor="White" Height="28px" Width="79px"  />
                               </div>
                               <br />
                                <div style="margin-left: 483px">
                                    <asp:Button ID="ButtonGuardar" runat="server" Text="Guardar" OnClick="ButtonGuardar_Click" BackColor="#3333FF" BorderStyle="None" ForeColor="White" Height="32px" Width="90px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="ButtonNuevo" runat="server" OnClick="Button1_Click" Text="Nuevo" BackColor="Gray" BorderStyle="None" ForeColor="White" Height="32px" Width="90px" />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="ButtonEliminar" runat="server" OnClick="Button2_Click" Text="Eliminar" BackColor="Red" BorderStyle="None" ForeColor="White" Height="32px" Width="90px" />
                                </div>
                           </div>
                        </div>
                </div>
        </asp:panel>  
      </div>   

        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
        <center>                    
   </center>

</asp:Content>