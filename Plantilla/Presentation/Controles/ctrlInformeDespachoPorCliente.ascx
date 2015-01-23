<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlInformeDespachoPorCliente.ascx.cs" Inherits="Presentation.Controles.ctrlInformeDespachoPorCliente" %>


<fieldset>
           <legend>Lotes Despachados</legend> 
            
            <div class="divForm">
                <div class="container_center_form">        
                    <asp:Label ID="lblDespachoCliente" runat="server" Text="Buscar Cliente:" AssociatedControlID="ddlDespachoCliente" CssClass="divLabel"/>
                    <asp:DropDownList runat="server" ID="ddlDespachoCliente" AppendDataBoundItems="true" OnSelectedIndexChanged="DespachoCliente_SelectedIndexChanged" 
                        AutoPostBack="true">
                        <asp:ListItem Value="0" Text="Seleccionar Cliente"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="text-align:center;">             
                    <asp:GridView ID="gdvDespachoCliente" runat="server" PageSize="20" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" 
                         ForeColor="#333333" GridLines="Vertical" Width="100%" OnPageIndexChanging="gdvDespachoCliente_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                        <Columns>
                            
                            <asp:TemplateField HeaderText="PRODUCTO">
                                <ItemTemplate>
                                    <asp:Label ID="lblproducto" runat="server" Width="100%" Text='<%# Bind("nombreProducto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        
                            <asp:TemplateField HeaderText="LOTE">
                                <ItemTemplate>
                                    <asp:Label ID="lblLote" runat="server" Width="100%" Text='<%# Bind("lote") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DESPACHO">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Width="100%" Text='<%# Bind("consecutivo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CANTIDAD">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidadDespacho" runat="server" Width="100%" Text='<%# Bind("cantidadDespacho") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="TONELADAS">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidadToneladas" runat="server" Width="100%" Text='<%# Bind("cantidadToneladas") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FECHA">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaMovimiento" runat="server" Width="100%" Text='<%# Bind("fechaMovimiento") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            
                        </Columns>
                        <FooterStyle BackColor="Brown" Font-Bold="true" ForeColor="White" />
                        <HeaderStyle BackColor="#009900" ForeColor="white" Font-Size="Small" Font-Names="italic" Font-Italic="true" />
                        <PagerStyle BackColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                        <RowStyle BackColor="#FFFFFF" ForeColor="#333333" Width="100%" />
                        <SelectedRowStyle BackColor="red" Font-Bold="true" ForeColor="#333333"/>
                    </asp:GridView>
                </div>
            </div>
            
         </fieldset>