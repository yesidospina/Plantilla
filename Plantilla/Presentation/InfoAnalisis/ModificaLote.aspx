<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificaLote.aspx.cs" Inherits="Presentation.InfoAnalisis.ModificaLote" %>
<%@ Register Src="~/Controles/ctrModificaLote.ascx" TagPrefix="uc" TagName="ctrModificaLote" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Modificar Lote</h1>
    </hgroup>
    <uc:ctrModificaLote ID="ctrModificaLote" runat="server" />

</asp:Content>
