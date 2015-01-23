<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrModificaLote.ascx.cs" Inherits="Presentation.Controles.ctrModificaLote" %>


                        <div style="text-align:center;">             
                            <asp:ScriptManager ID="scmUltimosLotes" runat="server" />
                            <asp:UpdatePanel ID="updatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gdvLotes" runat="server" AutoGenerateColumns="false" PageSize="10" ForeColor="#333333" GridLines="Vertical" Width="100%"
                                        AutoGenerateEditButton="true" 
                                        OnPageIndexChanging="gdvLotes_PageIndexChanging" 
                                        OnRowCancelingEdit="gdvLotes_RowCancelingEdit"  
                                        OnRowEditing="gdvLotes_RowEditing" 
                                        OnRowUpdating="gdvLotes_RowUpdating">
                                        <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333" BorderColor="#3333333" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="NOMBRE PRODUCTO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblNombreProducto" runat="server" Text='<%# Eval("nombreProducto") %>' Width="100%"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="LOTE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblLote" runat="server" Width="100%" Text='<%# Eval("lote") %>'  />
                                                </ItemTemplate>
                                                
                                            </asp:TemplateField>
                                                
                                            <asp:TemplateField HeaderText="FECHA LOTE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaLote" runat="server" Text='<%# Eval("fecha_lote") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            
                                            <asp:TemplateField HeaderText="FECHA MOVIMIENTO">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtFechaMovimiento" runat="server" Width="100%" CssClass="inCalendar" Text='<%# Bind("fecha_movimiento") %>'/>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="lblFechaMovimiento" runat="server" Text='<%# Bind("fecha_movimiento") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="FECHA MOVIMIENTO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUsuario" runat="server" Text='<%# Eval("usuario") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle BackColor="Brown" Font-Bold="true" ForeColor="White" />
                                        <HeaderStyle BackColor="#009900" ForeColor="white" Font-Size="Small" Font-Names="italic" Font-Italic="true" />
                                        <PagerStyle BackColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                                        <RowStyle BackColor="#FFFFFF" ForeColor="#333333" Width="100%" />
                                        <SelectedRowStyle BackColor="red" Font-Bold="true" ForeColor="#333333"/> 
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
