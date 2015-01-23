<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlMenu.ascx.cs" Inherits="Presentation.Controles.ctrlMenu" %>
	
	<div class="container_center">
		<div class="clear hideSkiplink">
			<asp:Menu ID="mnMenu" runat="server" Orientation="Horizontal" 
				IncludeStyleBlock="False" EnableViewState="false" 
				StaticEnableDefaultPopOutImage="False" CssClass="menu" RenderingMode="List">
				<Items>
                    <asp:MenuItem ImageUrl="~/Images/btnProduccion.jpg">
                        <asp:MenuItem ImageUrl="~/Images/btnNuevoLote.jpg" NavigateUrl="~/InfoAnalisis/NuevoLote.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/Images/btnModificaLote.jpg" NavigateUrl="~/InfoAnalisis/ModificaLote.aspx"></asp:MenuItem>
                    </asp:MenuItem>
					
                    <asp:MenuItem ImageUrl="~/Images/btnCalidad.jpg" NavigateUrl="~/InfoAnalisis/NuevoAnalisis.aspx">
					    <asp:MenuItem ImageUrl="~/Images/btnNuevoAnalisis.jpg" NavigateUrl="~/InfoAnalisis/NuevoAnalisis.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/Images/btnAnalisisLote.jpg"  NavigateUrl="~/InfoAnalisis/ProductoLote.aspx"></asp:MenuItem>
					</asp:MenuItem>

                    <asp:MenuItem ImageUrl="~/Images/btnNuevoDespacho.jpg">
                        <asp:MenuItem ImageUrl="~/Images/btnHarinas.jpg"  NavigateUrl="~/InfoAnalisis/Despacho.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/Images/btnCebos.jpg" NavigateUrl="~/InfoAnalisis/CertificadoCebos.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/Images/btnMemorando.jpg" NavigateUrl="~/InfoAnalisis/MemorandoDespachos.aspx"></asp:MenuItem>
                    </asp:MenuItem>

                    <asp:MenuItem ImageUrl="~/Images/btnInformes.jpg">
                        <asp:MenuItem ImageUrl="~/Images/btnExistencias.jpg"  NavigateUrl="~/InfoAnalisis/ReporteExistencias.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/Images/btnLoteDespachado.jpg"  NavigateUrl="~/InfoAnalisis/LotesDespachados.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/Images/btnInformeAnalisis.jpg"  NavigateUrl="~/InfoAnalisis/InformeAnalisis.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/Images/btnDespachoDia.jpg"  NavigateUrl="~/InfoAnalisis/DespachoPorDia.aspx"></asp:MenuItem>
                        <asp:MenuItem ImageUrl="~/Images/btnDespachoCliente.jpg"  NavigateUrl="~/InfoAnalisis/DespachoPorCliente.aspx"></asp:MenuItem>
                    </asp:MenuItem>
					
				</Items>
			</asp:Menu>
		</div>
	</div>