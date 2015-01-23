<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MemorandoDespachos.aspx.cs" Inherits="Presentation.InfoAnalisis.MemorandoDespachos" %>
<%@ Register Src="~/Controles/ctrlMemorandoDespacho.ascx" TagPrefix="uc" TagName="ctrMemorandoDespacho" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Crear Memorando Despacho</h1>
    </hgroup>
    <uc:ctrMemorandoDespacho ID="ctrMemorandoDespacho" runat="server" />
</asp:Content>
