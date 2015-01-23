<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoAnalisis.aspx.cs" Inherits="Presentation.InfoAnalisis.NuevoAnalisis" %>
<%@ Register Src="~/Controles/ctrlAnalisisLote.ascx" TagPrefix="uc" TagName="ctrNuevoAnalisis" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
          <uc:ctrNuevoAnalisis ID="ctrNuevoAnalisis" runat="server" />
</asp:Content>
