<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CertificadoCebos.aspx.cs" Inherits="Presentation.InfoAnalisis.CertificadoCebos" %>
<%@ Register Src="~/Controles/ctrlCertificadoCebos.ascx" TagPrefix="uc" TagName="ctrlCertificadoCebos" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1>Crear Certificado Sebos</h1>
    </hgroup>
    <uc:ctrlCertificadoCebos ID="ctrlCertificadoCebos" runat="server" />
</asp:Content>
