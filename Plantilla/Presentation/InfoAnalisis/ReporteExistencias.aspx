<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteExistencias.aspx.cs" Inherits="Presentation.InfoAnalisis.ReporteExistencias" %>
<%@ Register Src="~/Controles/ctrlReporteExistencia.ascx" TagPrefix="uc" TagName="ctrReporteExistencia" %>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Existencias</h1>
    </hgroup>
    <uc:ctrReporteExistencia ID="ctrReporteExistencia" runat="server" />
</asp:Content>
