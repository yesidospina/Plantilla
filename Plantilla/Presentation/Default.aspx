<%@ Page Title="SISTEMA DE INFORMACION DE ANALISIS" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentation._Default" %>
<%@ Register Src="~/Controles/ctrlMenu.ascx" TagPrefix="uc" TagName="ctrMenu" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <img id="imgTitle" runat="server" src="~/Images/titulo.png" />
        </div>
    </section>
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="content-wrapper">

        <div class="container_center_menu">
            <uc:ctrMenu ID="ctrMenu" runat="server" />
        </div>

        <div class="container_center_form" style="float:left; margin-left:380px">
            <img id="Img1" runat="server" src="~/Images/agrosan.jpg" alt="Agrosan S.A." width="260" height="260" />
        </div>



   </div>

</asp:Content>
