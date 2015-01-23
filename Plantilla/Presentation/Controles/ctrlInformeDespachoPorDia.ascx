<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlInformeDespachoPorDia.ascx.cs" Inherits="Presentation.Controles.ctrlInformeDespachoPorDia" %>


        <div class="container_center_form">        
                    <asp:Label ID="lblFechaInicial" runat="server" Text="Fecha Inicial:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtFechaInicial" runat="server" CssClass="inCalendar" Width="100px" Height="20px"/>
                </div>

                <div class="container_center_form">        
                    <asp:Label ID="lblFechaFinal" runat="server" Text="Fecha Final:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtFechaFinal" runat="server" CssClass="inCalendar" Width="100px" Height="20px"/>
                </div>

                <div style="margin-left:380px; margin-top:10px;">
                    <asp:Button ID="btnConsultaFechas" runat="server" Text="Buscar"  CssClass="crearLote button" OnClick="btnConsultaFechas_Click"/>
                </div>
                

                <div style="text-align:center;">             
                    <asp:GridView ID="gdvInfoAnalisisFechaPorDia" runat="server" PageSize="20" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" 
                         ForeColor="#333333" GridLines="Vertical" Width="100%" >
                        <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                        <Columns>
                            
                            <asp:TemplateField HeaderText="PRODUCTO">
                                <ItemTemplate>
                                    <asp:Label ID="lblProducto" runat="server" Width="100%" Text='<%# Bind("nombreProducto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        
                            <asp:TemplateField HeaderText="CLIENTE">
                                <ItemTemplate>
                                    <asp:Label ID="lblCliente" runat="server" Width="100%" Text='<%# Bind("nombreCliente") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CANTIDAD">
                                <ItemTemplate>
                                    <asp:Label ID="lblCantidad" runat="server" Width="100%" Text='<%# Bind("cantidadDespacho") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DESPACHO">
                                <ItemTemplate>
                                    <asp:Label ID="lblDespacho" runat="server" Width="100%" Text='<%# Bind("consecutivo") %>' />
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