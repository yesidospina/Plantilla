<%@ Page Title="Iniciar sesión" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Presentation.Account.Login" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    
    
    <div class="container_center">
    
           <asp:Login ID="Login1" runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" onauthenticate="Login1_Authenticate" BorderPadding="4" ForeColor="#333333" Width="267px" DisplayRememberMe="False">
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            <LoginButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="1.3em" ForeColor="#045C03" Width="8.8em"/>
            <TextBoxStyle Font-Size="1.6em" />
            <TitleTextStyle BackColor="#045C03" Font-Bold="True" ForeColor="#FFFFFF" Font-Size="1.7em" />
          </asp:Login>
    
    </div>

</asp:Content>
