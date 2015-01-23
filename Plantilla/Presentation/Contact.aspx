<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Presentation.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Tecnología, Información y Comunicaciones (TIC)</h2>
    </hgroup>

    <div class="container_center">
        <section class="contact">
            <header>
                <h3>Teléfono:</h3>
            </header>
            <p>
                <span class="label">Principal:</span>
                <span>8473127 - Ext: 223</span>
            </p>
            <p>
                <span class="label">Fuera del horario laboral:</span>
                <span>Cel: 3207771587</span>
            </p>
        </section>

        <section class="contact">
            <header>
                <h3>Correo electrónico:</h3>
            </header>
            <p>
                <span class="label">Soporte técnico:</span>
                <span><a href="mailto:Support@example.com">calvarez@agrosan.com.com</a></span>
                <span><a href="mailto:Support@example.com">cflorez@agrosan.com.com</a></span>
                <span><a href="mailto:Support@example.com">fospina@agrosan.com.com</a></span>
            </p>
        </section>

        <section class="contact">
            <header>
                <h3>Dirección:</h3>
            </header>
            <p>
                Vereda Pie de Cuesta <br />
                Amaga-Antioquia
            </p>
        </section>
    </div>
</asp:Content>