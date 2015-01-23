<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DespachoPorDia.aspx.cs" Inherits="Presentation.InfoAnalisis.DespachoPorDia" %>
<%@ Register Src="~/Controles/ctrlInformeDespachoPorDia.ascx" TagPrefix="uc" TagName="ctrlInformeDespachoPorDia" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <hgroup class="title">
        <h1>Informe Despacho por Dia</h1>
    </hgroup>
    <uc:ctrlInformeDespachoPorDia ID="ctrlInformeDespachoPorDia" runat="server" />

</asp:Content>
