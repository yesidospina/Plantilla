<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlLotePorProducto.ascx.cs" Inherits="Presentation.Controles.ctrlLotePorProducto" %>



 <fieldset>
           <legend>Lotes Por Producto</legend> 
            
            <div class="divForm">
                <div class="container_center_form">        
                    <asp:Label ID="lblBuscarProductoLote" runat="server" Text="Buscar Lote:" AssociatedControlID="ddlProductoLote" CssClass="divLabel"/>
                    <asp:DropDownList runat="server" ID="ddlProductoLote" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlProductoLote_OnSelectedIndexChanged" 
                        AutoPostBack="true">
                        <asp:ListItem Value="0" Text="Seleccionar Producto"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div style="text-align:center;">             
                    <asp:GridView ID="gdvProductoLote" runat="server" PageSize="15" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" 
                         ForeColor="#333333" GridLines="Vertical" Width="100%" AutoGenerateEditButton="true" OnPageIndexChanging="gdvProductoLote_PageIndexChanging"
                         OnRowEditing="gdvProductoLote_RowEditing" OnRowCancelingEdit="gdvProductoLote_RowCancelingEdit" OnRowUpdating="gdvProductoLote_RowUpdating">
                        <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                        <Columns>
                            <%--<asp:ImageField HeaderText="IR ANALIZAR" NavigateUrl="~/InfoAnalisis/NuevoAnalisis.aspx" />--%>
                            
                            <asp:TemplateField HeaderText="SEL">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkLote" runat="server" CssClass="checkSelec" />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ANALIZAR">
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgBtnAnalizaLote" runat="server" ImageUrl="~/Images/science-icon.png" OnClick="imgBtnAnalizaLote_OnClick" CssClass="imgButton"/>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="NOMBRE PRODUCTO">
                                <ItemTemplate>
                                    <asp:Label ID="lblNombreProducto" runat="server" Width="100%" Text='<%# Bind("nombreProducto") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="LOTE">
                                <ItemTemplate>
                                    <asp:Label ID="lbllote" runat="server" Width="100%" Text='<%# Bind("lote") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="FECHA">
                                <ItemTemplate>
                                    <asp:Label ID="lblFechaMovimiento" runat="server" Width="100%" Text='<%# Bind("fechaMovimiento") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ESTADO">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstadoLote" runat="server" Width="100%" Text='<%# Bind("nombreEstado") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="BULTOS">
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtBultos" runat="server" Width="40" Text='<%# Bind("saldo") %>' />
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="lblBultos" runat="server" Width="100%" Text='<%# Bind("saldo") %>' />
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
