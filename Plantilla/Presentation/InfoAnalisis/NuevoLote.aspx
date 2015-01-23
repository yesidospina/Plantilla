<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoLote.aspx.cs" Inherits="Presentation.InfoAnalisis.NuevoLote" %>
<%@ Register Src="~/Controles/ctrlCreacionLote.ascx" TagPrefix="uc" TagName="ctrlCreacionLote" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
     <hgroup class="title">
        <h1>Crear Lote</h1>
    </hgroup>
    <fieldset>
        <LEGEND>CREACION DE LOTE</LEGEND>
        <div class="container_center">
            <uc:ctrlCreacionLote ID="CtrlCreacionLote1" runat="server" />    
        </div>
    
    </fieldset>
</asp:Content>
