<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlInfomeAnalisis.ascx.cs" Inherits="Presentation.Controles.ctrlInfomeAnalisis" %>

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
                    <asp:GridView ID="gdvInfoAnalisisRangoFecha" runat="server" PageSize="20" AllowPaging="true" AutoGenerateColumns="false" CellPadding="4" EnableModelValidation="true" 
                         ForeColor="#333333" GridLines="Vertical" Width="100%" >
                        <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                        <Columns>
                            
                            <asp:TemplateField HeaderText="FECHA">
                                <ItemTemplate>
                                    <asp:Label ID="lblFecha" runat="server" Width="100%" Text='<%# Bind("fechaMovimiento") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                                                        
                            <asp:TemplateField HeaderText="LOTE">
                                <ItemTemplate>
                                    <asp:Label ID="lblLote" runat="server" Width="100%" Text='<%# Bind("lote") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ENTRADA">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntrada" runat="server" Width="100%" Text='<%# Bind("entrada") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="KILOS">
                                <ItemTemplate>
                                    <asp:Label ID="lblkilos" runat="server" Width="100%" Text='<%# Bind("kilos") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="PROTEINA">
                                <ItemTemplate>
                                    <asp:Label ID="lbl" runat="server" Width="100%" Text='<%# Bind("proteina") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="HUMEDAD">
                                <ItemTemplate>
                                    <asp:Label ID="lblHumedad" runat="server" Width="100%" Text='<%# Bind("humedad") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="GRASA">
                                <ItemTemplate>
                                    <asp:Label ID="lblGrasa" runat="server" Width="100%" Text='<%# Bind("grasa") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CALCIO">
                                <ItemTemplate>
                                    <asp:Label ID="lblCalcio" runat="server" Width="100%" Text='<%# Bind("calcio") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="CENIZA">
                                <ItemTemplate>
                                    <asp:Label ID="lblCeniza" runat="server" Width="100%" Text='<%# Bind("ceniza") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="DIGEST">
                                <ItemTemplate>
                                    <asp:Label ID="lblDigest" runat="server" Width="100%" Text='<%# Bind("digestibilidad") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="ACIDEZ">
                                <ItemTemplate>
                                    <asp:Label ID="lblAcidez" runat="server" Width="100%" Text='<%# Bind("acidez") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="PEROX">
                                <ItemTemplate>
                                    <asp:Label ID="lblPeroxido" runat="server" Width="100%" Text='<%# Bind("peroxido") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="T10">
                                <ItemTemplate>
                                    <asp:Label ID="lblT10" runat="server" Width="100%" Text='<%# Bind("t10") %>' />
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