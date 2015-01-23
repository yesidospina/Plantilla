<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoLote.aspx.cs" Inherits="Presentation.InfoAnalisis.ProductoLote" %>
<%@ Register Src="~/Controles/ctrlLotePorProducto.ascx" TagPrefix="uc" TagName="ctrLoteProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc:ctrLoteProducto ID="ctrLoteProducto" runat="server" />
</asp:Content>
