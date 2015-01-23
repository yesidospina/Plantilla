<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Despacho.aspx.cs" Inherits="Presentation.InfoAnalisis.Despacho" %>
<%@ Register Src="~/Controles/ctrlDespacho.ascx" TagPrefix="uc" TagName="ctrlDespacho" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Crear Certificado de Harinas</h1>
    </hgroup>
    <uc:ctrlDespacho ID="ctrlDespacho" runat="server" />
</asp:Content>
