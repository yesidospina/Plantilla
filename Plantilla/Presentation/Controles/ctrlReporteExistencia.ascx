<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlReporteExistencia.ascx.cs" Inherits="Presentation.Controles.ctrlReporteExistencia" %>


<!-- EXISTENCIA TOTAL -->
        <div class="container_rigth">
            <asp:Label ID="lblExistenciaTotal" runat="server" Text="EXISTENCIA TOTAL" CssClass="titleReport" Width="312" />
            <asp:Panel ID="pnlExistenciaTotal" runat="server" Width="312" Height="212" BackColor="#ffffff">
                    <asp:GridView ID="gdvExitenciaTotal" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" ForeColor="#333333" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                    <Columns>
                        <asp:TemplateField HeaderText="NOMBRE PRODUCTO">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreProductoExistencia" runat="server" Text='<%# Bind("nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BULTOS">
                            <ItemTemplate>
                                <asp:Label ID="lblBultoExistenciaTotal" runat="server" Text='<%# Bind("bultos") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TONELADAS">
                            <ItemTemplate>
                                <asp:Label ID="lblToneladaExistenciaTotal" runat="server" Text='<%# Bind("toneladas") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                <FooterStyle BackColor="Brown" Font-Bold="true" ForeColor="White" />
                <HeaderStyle BackColor="#009900" ForeColor="white" Font-Size="Small" Font-Names="italic" Font-Italic="true" />
                <PagerStyle BackColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle BackColor="#FFFFFF" ForeColor="#333333" Font-Size="8"/>
                <SelectedRowStyle BackColor="red" Font-Bold="true" ForeColor="#333333"/>
                </asp:GridView>
            </asp:Panel>
        </div>
        

        <!-- EXISTENCIA DISPONIBLE -->
        <div class="container_center_panel">
            <asp:Label ID="lblExistenciaDisponible" runat="server" Text="EXISTENCIA DISPONIBLE" CssClass="titleReport" Width="314" />
            <asp:Panel ID="pnlExistenciaDisponible" runat="server" Width="314" Height="212" BackColor="#ffffff">
                <asp:GridView ID="gdvExistenciaDisponible" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" ForeColor="#333333" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                    <Columns>
                        <asp:TemplateField HeaderText="NOMBRE PRODUCTO">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreProductoExistenciaDisponible" runat="server" Text='<%# Bind("nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BULTOS">
                            <ItemTemplate>
                                <asp:Label ID="lblBultoExistenciaDisponible" runat="server" Text='<%# Bind("bultos") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TONELADAS">
                            <ItemTemplate>
                                <asp:Label ID="lblToneladaExistenciaDisponible" runat="server" Text='<%# Bind("toneladas") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                <FooterStyle BackColor="Brown" Font-Bold="true" ForeColor="White" />
                <HeaderStyle BackColor="#009900" ForeColor="white" Font-Size="Small" Font-Names="italic" Font-Italic="true" />
                <PagerStyle BackColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle BackColor="#FFFFFF" ForeColor="#333333" Font-Size="8"/>
                <SelectedRowStyle BackColor="red" Font-Bold="true" ForeColor="#333333"/>
                </asp:GridView>
            </asp:Panel>        
        </div>
        

        <!-- EXISTENCIA PENDIENTE -->
        <div class="container_left">
             <asp:Label ID="lblExistenciaPendiente" runat="server" Text="EXISTENCIA PENDIENTE" CssClass="titleReport" Width="314" />
             <asp:Panel ID="pnlExistenciaPendiente" runat="server" Width="314" Height="212" BackColor="#ffffff">
                <asp:GridView ID="gdvExistenciaPendiente" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" ForeColor="#333333" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                    <Columns>
                        <asp:TemplateField HeaderText="NOMBRE PRODUCTO">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreProductoExistenciaPendiente" runat="server" Text='<%# Bind("nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BULTOS">
                            <ItemTemplate>
                                <asp:Label ID="lblBultoExistenciaPendiente" runat="server" Text='<%# Bind("bultos") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TONELADAS">
                            <ItemTemplate>
                                <asp:Label ID="lblToneladaExistenciaPendiente" runat="server" Text='<%# Bind("toneladas") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                <FooterStyle BackColor="Brown" Font-Bold="true" ForeColor="White" />
                <HeaderStyle BackColor="#009900" ForeColor="white" Font-Size="Small" Font-Names="italic" Font-Italic="true" />
                <PagerStyle BackColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle BackColor="#FFFFFF" ForeColor="#333333" Font-Size="8" />
                <SelectedRowStyle BackColor="red" Font-Bold="true" ForeColor="#333333"/>
                </asp:GridView>
            </asp:Panel>
        </div>


        <!-- EXISTENCIA RETENIDA -->
        <div class="container_left">
             <asp:Label ID="lblExistenciaRetenida" runat="server" Text="EXISTENCIA RETENIDA" CssClass="titleReport" Width="314" />
             <asp:Panel ID="pnlExistenciaRetenida" runat="server" Width="314" Height="212" BackColor="#ffffff">
                <asp:GridView ID="gdvExistenciaRetenida" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" ForeColor="#333333" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                    <Columns>
                        <asp:TemplateField HeaderText="NOMBRE PRODUCTO">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreProductoExistenciaRetenida" runat="server" Text='<%# Bind("nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BULTOS">
                            <ItemTemplate>
                                <asp:Label ID="lblBultoExistenciaRetenida" runat="server" Text='<%# Bind("bultos") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TONELADAS">
                            <ItemTemplate>
                                <asp:Label ID="lblToneladaExistenciaRetenida" runat="server" Text='<%# Bind("toneladas") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                <FooterStyle BackColor="Brown" Font-Bold="true" ForeColor="White" />
                <HeaderStyle BackColor="#009900" ForeColor="white" Font-Size="Small" Font-Names="italic" Font-Italic="true" />
                <PagerStyle BackColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle BackColor="#FFFFFF" ForeColor="#333333" Font-Size="8" />
                <SelectedRowStyle BackColor="red" Font-Bold="true" ForeColor="#333333"/>
                </asp:GridView>
            </asp:Panel>
        </div>


        <!-- EXISTENCIA REPROCESO -->
        <div class="container_left">
             <asp:Label ID="lblExistenciaReproceso" runat="server" Text="EXISTENCIA REPROCESO" CssClass="titleReport" Width="314" />
             <asp:Panel ID="pnlExistenciaReproceso" runat="server" Width="314" Height="212" BackColor="#ffffff">
                <asp:GridView ID="gdvExistenciaReproceso" runat="server" PageSize="10" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" ForeColor="#333333" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                    <Columns>
                        <asp:TemplateField HeaderText="NOMBRE PRODUCTO">
                            <ItemTemplate>
                                <asp:Label ID="lblNombreProductoExistenciaReproceso" runat="server" Text='<%# Bind("nombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="BULTOS">
                            <ItemTemplate>
                                <asp:Label ID="lblBultoExistenciaReproceso" runat="server" Text='<%# Bind("bultos") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="TONELADAS">
                            <ItemTemplate>
                                <asp:Label ID="lblToneladaExistenciaReproceso" runat="server" Text='<%# Bind("toneladas") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        </Columns>
                <FooterStyle BackColor="Brown" Font-Bold="true" ForeColor="White" />
                <HeaderStyle BackColor="#009900" ForeColor="white" Font-Size="Small" Font-Names="italic" Font-Italic="true" />
                <PagerStyle BackColor="#FFFFFF" HorizontalAlign="Center" VerticalAlign="Middle" />
                <RowStyle BackColor="#FFFFFF" ForeColor="#333333" Font-Size="8" />
                <SelectedRowStyle BackColor="red" Font-Bold="true" ForeColor="#333333"/>
                </asp:GridView>
            </asp:Panel>
        </div>
