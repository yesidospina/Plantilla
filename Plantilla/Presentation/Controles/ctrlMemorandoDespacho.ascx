<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlMemorandoDespacho.ascx.cs" Inherits="Presentation.Controles.ctrlMemorandoDespacho" %>

    <fieldset>
    <legend>Memorando Despacho</legend>
    <div class="container_center">
        <div class="divForm">
            <asp:Label ID="lblMemorandoCliente" runat="server" Text="Cliente:" CssClass="divLabel" />
            <asp:DropDownList runat="server" ID="ddlMemorandoCliente" AppendDataBoundItems="true">
                <asp:ListItem Value="0" Text="Seleccionar Cliente"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="divForm">
            <asp:Label ID="lblFechaMemorando" runat="server" AssociatedControlID="txtFechaMemorando" Text="Fecha: " CssClass="divLabel" />
            <asp:TextBox ID="txtFechaMemorando" runat="server" CssClass="inCalendar input textarea" Width="100px" Height="10px"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaMemorando" CssClass="field-validation-error" ErrorMessage="Debe seleccionar una fecha" />
        </div>

        <div class="divForm">
            <asp:Label ID="lblVehiculoMemorando" runat="server" AssociatedControlID="txtVehiculoMemorando" Text="Vehiculo: " CssClass="divLabel" />
                <asp:TextBox ID="txtVehiculoMemorando" runat="server" Width="100px" Height="10px" MaxLength="8"  CssClass="input textarea"/>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVehiculoMemorando" CssClass="field-validation-error" ErrorMessage="Digite la placa del vehiculo" />
        </div>

        <div class="divForm">
            <asp:Label ID="lblMemorandoProducto" runat="server" AssociatedControlID="ddlMemorandoProducto" Text="Producto" CssClass="divLabel"/>
                <asp:DropDownList runat="server" ID="ddlMemorandoProducto" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlMemorandoProducto_OnSelectedIndexChanged" AutoPostBack="true" >
                <asp:ListItem Value="0" Text="Seleccionar Producto"></asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="divForm">
            <asp:Label ID="lblObseravaciones" runat="server" Text="Observaciones: " CssClass="divLabel" />
            <asp:TextBox id="txaObservaciones" TextMode="multiline" Rows="3" runat="server" />
        </div>

        <div>
            <asp:ScriptManager ID="scrManager" runat="server" EnablePartialRendering="false"/>    
               <asp:UpdatePanel ID="updMemorando" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <asp:GridView ID="gdvProductoDisponible" runat="server" PageSize="4" AllowPaging="true" AutoGenerateColumns="false" AutoGenerateEditButton="true" CellPadding="4" EnableModelValidation="true" ForeColor="#333333" GridLines="Vertical" Width="100%" OnPageIndexChanging="gdvProductoDisponible_OnPageIndexChanging" OnRowCancelingEdit="gdvProductoDisponible_OnRowCancelingEdit" OnRowEditing="gdvProductoDisponible_OnRowEditing" OnRowUpdating="gdvProductoDisponible_OnRowUpdating"  ShowFooter="true" OnRowDataBound="gdvProductoDisponible_OnRowDataBound">
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
                                    <asp:TextBox ID="txtValorDespachar" runat="server" Width="100%" Text='<%# Bind("SalidaMemorando") %>'  CssClass="txtBoxSize input textarea" />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblValorDespachar" runat="server" Width="100%" BackColor="Yellow" Text='<%# Bind("SalidaMemorando") %>'/>
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
                <asp:Button ID="btnGuardaMemorando" runat="server" Text="IMPRIMIR" CssClass="button" OnClick="btnGuardaMemorando_OnClick"/>
            </div>
    </div>
</fieldset>

