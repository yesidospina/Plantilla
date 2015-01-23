<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InformeAnalisis.aspx.cs" Inherits="Presentation.InfoAnalisis.InformeAnalisis" %>
<%@ Register Src="~/Controles/ctrlInfomeAnalisis.ascx" TagPrefix="uc" TagName="ctrlInfomeAnalisis" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <hgroup class="title">
        <h1>Informe de Analisis</h1>
    </hgroup>
    <uc:ctrlInfomeAnalisis ID="ctrlInfomeAnalisis" runat="server" />

</asp:Content>
