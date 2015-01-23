<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DespachoPorCliente.aspx.cs" Inherits="Presentation.InfoAnalisis.DespachoPorCliente" %>
<%@ Register Src="~/Controles/ctrlInformeDespachoPorCliente.ascx" TagPrefix="uc" TagName="ctrlInformeDespachoPorCliente" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Informe Despacho por Cliente</h1>
    </hgroup>
    <uc:ctrlInformeDespachoPorCliente ID="ctrlInformeDespachoPorCliente" runat="server" />
</asp:Content>