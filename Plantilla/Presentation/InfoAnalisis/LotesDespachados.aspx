<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LotesDespachados.aspx.cs" Inherits="Presentation.InfoAnalisis.LotesDespachados" %>
<%@ Register Src="~/Controles/ctrLoteDespachado.ascx" TagPrefix="uc" TagName="ctrLoteDespachado" %>



<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Informe Lotes Despachados</h1>
    </hgroup>
    <uc:ctrLoteDespachado ID="ctrLoteDespachado" runat="server" />
</asp:Content>
