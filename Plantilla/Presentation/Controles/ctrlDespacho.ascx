<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDespacho.ascx.cs" Inherits="Presentation.Controles.ctrlDespacho" %>

<fieldset>
    <legend>Despacho</legend>
    <div class="container_center">
        <div class="divForm">
            <asp:Label ID="lblDespachoCliente" runat="server" Text="Cliente:" CssClass="divLabel" />
            <asp:DropDownList runat="server" ID="ddlDespachoCliente" AppendDataBoundItems="true">
                <asp:ListItem Value="0" Text="Seleccionar Cliente"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="divForm">
            <asp:Label ID="lblFechaDespacho" runat="server" AssociatedControlID="txtFechaDespacho" Text="Fecha: " CssClass="divLabel" />
            <asp:TextBox ID="txtFechaDespacho" runat="server" CssClass="inCalendar input textarea" Width="100px" Height="10px"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaDespacho" CssClass="field-validation-error" ErrorMessage="Debe seleccionar una fecha" />
        </div>

        <div class="divForm">
            <asp:Label ID="lblVehiculoDespacho" runat="server" AssociatedControlID="txtVehiculoDespacho" Text="Vehiculo: " CssClass="divLabel" />
                <asp:TextBox ID="txtVehiculoDespacho" runat="server" Width="100px" Height="10px" MaxLength="8"  CssClass="input textarea"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVehiculoDespacho" CssClass="field-validation-error" ErrorMessage="Digite la placa del vehiculo" />
        </div>

        <div class="divForm">
            <asp:Label ID="lblDespachoProducto" runat="server" AssociatedControlID="ddlDespachoProducto" Text="Producto" CssClass="divLabel"/>
                <asp:DropDownList runat="server" ID="ddlDespachoProducto" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlDespachoProducto_OnSelectedIndexChanged" AutoPostBack="true" >
                <asp:ListItem Value="0" Text="Seleccionar Producto"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="divForm">
            <asp:Label ID="lblTemperatura" runat="server" AssociatedControlID="txtTemperatura" Text="Temperatura Max Desp C°: " CssClass="divLabel" />
                <asp:TextBox ID="txtTemperatura" runat="server" Width="50px" Height="10px" MaxLength="6"  CssClass="input textarea"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTemperatura" CssClass="field-validation-error" ErrorMessage="Digite la temperatura" />
        </div>

        <div>
            <asp:ScriptManager ID="scrManager" runat="server" EnablePartialRendering="false"/>    
               <asp:UpdatePanel ID="updDesapcho" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <asp:GridView ID="gdvProductoDisponible" runat="server" PageSize="4" AllowPaging="true" AutoGenerateColumns="false" AutoGenerateEditButton="true" CellPadding="4" EnableModelValidation="true" ForeColor="#333333" GridLines="Vertical" Width="100%" OnPageIndexChanging="despacho_OnPageIndexChanging" OnRowCancelingEdit="despacho_OnRowCancelingEdit" OnRowEditing="despacho_OnRowEditing" OnRowUpdating="gdvProductoDisponible_OnRowUpdating"  ShowFooter="true" OnRowDataBound="gdvProductoDisponible_OnRowDataBound">
                     <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333" />
                        <Columns>
                            <asp:TemplateField HeaderText="FECHA">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaProductoDisponible" runat="server" Width="100%" Text='<%# Bind("fecha") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LOTE">
                                <ItemTemplate>
                                    <asp:Label ID="lblloteDisponible" runat="server" Width="100%" Text='<%# Bind("lote") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DISPONIBLE">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidadDisponible" runat="server" Width="100%" Text='<%# Bind("cantidad_disponible") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="TONELADAS">
                                <ItemTemplate>
                                    <asp:Label ID="lblToneladaDisponible" runat="server" Width="100%" Text='<%# Bind("Toneladas") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DESPACHAR">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtValorDespachar" runat="server" Width="100%" Text='<%# Bind("salida") %>'  CssClass="txtBoxSize input textarea" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblValorDespachar" runat="server" Width="100%" BackColor="Yellow" Text='<%# Bind("salida") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                          </Columns>

                          <FooterStyle BackColor="#009900" Font-Bold="true" ForeColor="White" />
                          <HeaderStyle BackColor="#009900" ForeColor="white" Font-Size="Small" Font-Names="italic" Font-Italic="true" CssClass="headerStyle" />
                          <PagerStyle BackColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                          <RowStyle BackColor="#FFFFFF" ForeColor="#333333" Width="100%" />
                          <SelectedRowStyle BackColor="red" Font-Bold="true" ForeColor="#333333" CssClass="headerStyle"/>
                    </asp:GridView>
                    
                    </ContentTemplate>
                    <Triggers >
                        <asp:AsyncPostBackTrigger ControlID="gdvProductoDisponible" EventName="RowUpdating" />
                        <asp:AsyncPostBackTrigger ControlID="gdvProductoDisponible" EventName="RowCancelingEdit" />
                        <asp:AsyncPostBackTrigger ControlID="gdvProductoDisponible" EventName="RowEditing" />
                        <asp:AsyncPostBackTrigger ControlID="gdvProductoDisponible" EventName="RowDataBound" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>

            
            <asp:HiddenField ID="hdfTotalDespacho" runat="server"/>    
               
            <div class="divForm" style="text-align:center;">
                <asp:Button ID="btnGuardaDespacho" runat="server" Text="IMPRIMIR" CssClass="button" OnClick="btnGuardaDespacho_OnClick" OnClientClick="if(!confirm('!!! ESTA SEGURO QUE DESEA GUARDAR EL DESPACHO?\n ESTE PROCESO NO TIENE REVERSA ¡¡¡'))return false;"/>
            </div>
         
        <asp:Literal ID="pdfViewer2" runat="server"></asp:Literal>   
    </div>
</fieldset>
