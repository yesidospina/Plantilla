<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrLoteDespachado.ascx.cs" Inherits="Presentation.Controles.ctrLoteDespachado" %>

        <fieldset>
           <legend>Lotes Despachados</legend> 
            
            <div class="divForm">
                <div class="container_center_form">        
                    <asp:Label ID="lblBuscarProductoDespachado" runat="server" Text="Buscar Lote Despachado:" AssociatedControlID="ddlProductoDespachado" CssClass="divLabel"/>
                    <asp:DropDownList runat="server" ID="ddlProductoDespachado" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlProductoDespachado_SelectedIndexChanged" 
                        AutoPostBack="true">
                        <asp:ListItem Value="0" Text="Seleccionar Producto"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="text-align:center;">             
                    <asp:GridView ID="gdvLoteDespachado" runat="server" PageSize="20" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" 
                         ForeColor="#333333" GridLines="Vertical" Width="100%" OnPageIndexChanging="gdvLoteDespachado_PageIndexChanging">
                        <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                        <Columns>
                            <asp:TemplateField HeaderText="VER">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnLoteDespacho" runat="server" ImageUrl="~/Images/report1.png" OnCommand="imgBtnLoteDespacho_Command" CssClass="imgButton" CommandName="verDetalle" CommandArgument='<%# Eval("lote") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LOTE">
                                <ItemTemplate>
                                    <asp:Label ID="lblLote" runat="server" Width="100%" Text='<%# Bind("lote") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FECHA">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Width="100%" Text='<%# Bind("fechaMovimiento") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CANTIDAD">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidadDespacho" runat="server" Width="100%" Text='<%# Bind("cantidadDespacho") %>' />
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

                <div style="text-align:center;">             
                    <asp:GridView ID="gdvLoteDespachadoDetalle" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" 
                         ForeColor="#333333" GridLines="Vertical" Width="100%">
                        <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                        <Columns>
                            <asp:TemplateField HeaderText="CLIENTE">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreCliente" runat="server" Width="100%" Text='<%# Bind("nombreCliente") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CANTIDAD">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidad" runat="server" Width="100%" Text='<%# Bind("cantidadDespacho") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="TONELADAS">
                                <ItemTemplate>
                                    <asp:Label ID="lblToneladas" runat="server" Width="100%" Text='<%# Bind("Toneladas") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FECHA">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Width="100%" Text='<%# Bind("fechaDespacho") %>' />
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
