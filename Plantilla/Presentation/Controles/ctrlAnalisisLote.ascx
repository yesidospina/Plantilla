<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAnalisisLote.ascx.cs" Inherits="Presentation.Controles.ctrlAnalisisLote" %>
        
         <fieldset>
           <legend>Nuevo Analisis</legend> 
            
            <div class="divForm">
                <div class="container_center_form">        
                    <asp:Label ID="lblBuscarLote" runat="server" Text="Buscar Lote:" AssociatedControlID="txtBuscarLote" CssClass="divLabel"/>
                    <asp:TextBox ID="txtBuscarLote" runat="server" Width="100px" Text=""  CssClass="input textarea"/>
                    <asp:Button ID="btnBuscar" runat="server" Text="Buscar"  OnClick="btnBuscar_OnClick" CssClass="button"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBuscarLote" CssClass="field-validation-error" ErrorMessage="Debe digitar el lote"/>
                </div>
                <div style="text-align:center;">             
                    <asp:ScriptManager ID="scrManager" runat="server"/>    
                    <asp:UpdatePanel ID="updAnalisisLote" runat="server">
                       <ContentTemplate>
                <asp:GridView ID="gdvAnalisisLote" runat="server" PageSize="4" AllowPaging="true" AutoGenerateColumns="false" 
                    CellPadding="4" EnableModelValidation="true" ForeColor="#333333" GridLines="Vertical" Width="100%" >
                    <AlternatingRowStyle BackColor="#CCCCCC" ForeColor="#333333"  BorderColor="#333333"/>
                    <Columns>
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

                        <asp:TemplateField HeaderText="BULTOS">
                            <ItemTemplate>
                                <asp:Label ID="lblAnalisisBultos" runat="server" Width="100%" Text='<%# Bind("entrada") %>' />
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
            </div>
            
         </fieldset>

        <fieldset>
            <legend>Analisis</legend>
            <div class="container">
                <div class="divForm">
                    <asp:Label ID="lblProteina" runat="server" Text="Proteina:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtProteina" runat="server" CssClass="styleButton input textarea" Text="0"/>
                    <asp:label ID="label1" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div>
                <div class="divForm">
                    <asp:Label ID="lblHumedad" runat="server" Text="Humedad:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtHumedad" runat="server" Text="0" CssClass="styleButton input textarea"/>
                    <asp:label ID="label2" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div>
                <div class="divForm">
                    <asp:Label ID="lblCeniza" runat="server" Text="Ceniza:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtCeniza" runat="server" Text="0" CssClass="styleButton input textarea"/>
                    <asp:label ID="label3" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div> 
                <div class="divForm">
                    <asp:Label ID="lblGrasa" runat="server" Text="Grasa:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtGrasa" runat="server" Text="0" CssClass="styleButton input textarea" />
                    <asp:label ID="label4" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div>
            </div>
            <div class="container">
                <div class="divForm">
                    <asp:Label ID="lblPestina" runat="server" Text="Digest. Pestina:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtPestina" runat="server" Text="0" CssClass="styleButton input textarea" />
                    <asp:label ID="label5" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div>
                <div class="divForm">
                    <asp:Label ID="lblAcidez" runat="server" Text="Acidez:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtAcidez" runat="server" Text="0" CssClass="styleButton input textarea" />
                    <asp:label ID="label6" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div>
                <div class="divForm">
                    <asp:Label ID="lblPeroxido" runat="server" Text="Indice de Peroxidos:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtPeroxido" runat="server" Text="0" CssClass="styleButton input textarea" />
                    <asp:label ID="label7" runat="server" Text=" meq/Kg" Width="10" Font-Bold="true"/>
                </div>
                 <div class="divForm">
                    <asp:Label ID="lblTamiz" runat="server" Text="Retiene Tamiz:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtTamiz" runat="server" Text="0" CssClass="styleButton input textarea" />
                    <asp:label ID="label8" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div>
                
            </div>
            <div class="container">
                <div class="divForm">
                    <asp:Label ID="lblCalcio" runat="server" Text="Calcio:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtCalcio" runat="server" Text="0" Width="55" CssClass="input textarea"/>
                    <asp:label ID="label9" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div>
                <div class="divForm">
                    <asp:Label ID="lblFosforo" runat="server" Text="Fosforo:" CssClass="divLabel"/>
                    <asp:TextBox ID="txtFosforo" runat="server" Text="0" Width="55" CssClass="input textarea"/>
                    <asp:label ID="label11" runat="server" Text=" %" Width="10" Font-Bold="true"/>
                </div>
                <div class="divForm">
                    <asp:Label ID="lblEstado" runat="server" Text="Estado:" AssociatedControlID="ddlEstado" CssClass="divLabel"/>
                    <asp:DropDownList ID="ddlEstado" runat="server" AppendDataBoundItems="false"/>
                    <%--<asp:RequiredFieldValidator id="validaValores" ControlToValidate="ddlEstado" InitialValue="" runat="server"/>--%>
                </div>
                <div class="divForm">
                    <asp:Label ID="lblSumatoria" runat="server" Text="SUMATORIA:" CssClass="divLabel"/>
                    <asp:Button ID="btnSumatoriaTotal" runat="server" Text="0" CssClass="styleButton" OnClientClick="return false;" Height="50"/>
                </div> 
            </div>
        </fieldset>
        <fieldset>
            <legend></legend>
            <div class="container">
                <div class="divForm">
                    <asp:Label ID="lblCumple" runat="server" Text="Analisis Organolepticos:" AssociatedControlID="ddlCumple" CssClass="divLabel"/>
                    <asp:DropDownList runat="server" ID="ddlCumple" AppendDataBoundItems="true">
                         <asp:ListItem Value="NA" Text="Seleccionar"></asp:ListItem>
                         <asp:ListItem Value="CUMPLE" Text="CUMPLE"></asp:ListItem>
                         <asp:ListItem Value="NO CUMPLE" Text="NO CUMPLE"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div id="divObservacion" class="container">
                <asp:Label ID="lblObservacion" runat="server" Text="Observaciones:" CssClass="divLabel" AssociatedControlID="txaObservacion"/>
                <asp:TextBox id="txaObservacion" TextMode="multiline" Rows="3" runat="server" />
            </div>
        </fieldset>
        <fieldset>
            <legend></legend>
            <div style="text-align:center;">
                <asp:Button ID="btnGuardarAnalisis" runat="server" Text="Guardar" CssClass="button" OnClick="guardaAnalsis_OnClick" />
            </div>
        </fieldset>

<%------------------------- FORM DE LA PROTEINA -------------------%>    
        <div id="form_Proteina" title="Analisis Proteina" class="form_Proteina">
          <form>
          
            <asp:Label ID="lblVolumenHCI" runat="server" Text="Vol gastado de HCI: " AssociatedControlID="txtVolumenHCI" CssClass="label"/>
            <asp:TextBox ID="txtVolumenHCI" runat="server" Text="" Width="150"  Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblConcentracionHCL" runat="server" Text="Concentracion de HCL: " AssociatedControlID="txtConcentracionHCL" CssClass="label"/>
            <asp:TextBox ID="txtConcentracionHCL" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoMuestraProteina" runat="server" Text="Peso de la muestra: " AssociatedControlID="txtPesoMuestraProteina" CssClass="label"/>
            <asp:TextBox ID="txtPesoMuestraProteina" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>
            
          </form>
        </div>   
<%--------------------- ------------------- ----------------------%>        
<%--------------------- FORM DE LA HUMEDAD ----------------------%>
        <div id="form_Humedad" title="Analisis Humedad" class="form_Humedad">
          <form>
          
            <asp:Label ID="lblPesoPlatoMuestra" runat="server" Text="Peso Plato Con Muestra: " AssociatedControlID="txtPesoPlatoMuestra" CssClass="label"/>
            <asp:TextBox ID="txtPesoPlatoMuestra" runat="server" Text="" Width="150"  Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoPlatoVacio" runat="server" Text="Peso plato vacío: " AssociatedControlID="txtPesoPlatoVacio" CssClass="label"/>
            <asp:TextBox ID="txtPesoPlatoVacio" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoMuestraHumedad" runat="server" Text="Peso de la muestra: " AssociatedControlID="txtPesoMuestraHumedad" CssClass="label"/>
            <asp:TextBox ID="txtPesoMuestraHumedad" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>
            
          </form>
        </div>
<%--------------------- ------------------- ----------------------%>
<%---------------------- FORM DE LA CENIZA  -----------------------%>    
        <div id="form_Ceniza" title="Analisis Ceniza" class="form_Ceniza">
          <form>
          
            <asp:Label ID="lblPesoCrisolMuestra" runat="server" Text="Peso Crisol con Muestra: " AssociatedControlID="txtPesoCrisolMuestra" CssClass="label"/>
            <asp:TextBox ID="txtPesoCrisolMuestra" runat="server" Text="" Width="150"  Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoCrisolVacio" runat="server" Text="Peso Crisol Vacio: " AssociatedControlID="txtPesoCrisolVacio" CssClass="label"/>
            <asp:TextBox ID="txtPesoCrisolVacio" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoMuestraCeniza" runat="server" Text="Peso de la muestra: " AssociatedControlID="txtPesoMuestraCeniza" CssClass="label"/>
            <asp:TextBox ID="txtPesoMuestraCeniza" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>
            
          </form>
        </div>
<%--------------------- ------------------- ----------------------%>
<%---------------------- FORM DE LA GRASA  -----------------------%>    
        <div id="form_Grasa" title="Analisis Grasa" class="form_Grasa">
          <form>
          
            <asp:Label ID="lblPesoBalon" runat="server" Text="Peso Balon: " AssociatedControlID="txtPesoBalon" CssClass="label"/>
            <asp:TextBox ID="txtPesoBalon" runat="server" Text="" Width="150"  Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblGrasaAnalisis" runat="server" Text="Grasa: " AssociatedControlID="txtGrasaAnalisis" CssClass="label"/>
            <asp:TextBox ID="txtGrasaAnalisis" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoBalonVacio" runat="server" Text="Peso Balon Vacio: " AssociatedControlID="txtPesoBalonVacio" CssClass="label"/>
            <asp:TextBox ID="txtPesoBalonVacio" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>
            
            <asp:Label ID="lblPesoMuestraGrasa" runat="server" Text="Peso Muestra: " AssociatedControlID="txtPesoMuestraGrasa" CssClass="label"/>
            <asp:TextBox ID="txtPesoMuestraGrasa" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

          </form>
        </div>
<%--------------------- ------------------- ----------------------%>
<%---------------------- FORM DE DIGEST PESTINA  -----------------------%>    
        <div id="form_Pestina" title="Analisis Pestina" class="form_Pestina">
          <form>
          
            <asp:Label ID="lblVolumenHCIPestina" runat="server" Text="Vol gastado de HCI: " AssociatedControlID="txtVolumenHCIPestina" CssClass="label"/>
            <asp:TextBox ID="txtVolumenHCIPestina" runat="server" Text="" Width="150"  Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblConcentracionHCLPestina" runat="server" Text="Concentracion de HCL: " AssociatedControlID="txtConcentracionHCL" CssClass="label"/>
            <asp:TextBox ID="txtConcentracionHCLPestina" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoMuestraPestina" runat="server" Text="Peso de la muestra: " AssociatedControlID="txtPesoMuestraProteina" CssClass="label"/>
            <asp:TextBox ID="txtPesoMuestraPestina" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>
            
          </form>
        </div>
<%--------------------- ------------------- ----------------------%>
<%---------------------- FORM ACIDEZ  -----------------------%>    
        <div id="form_Acidez" title="Analisis ACIDEZ" class="form_Acidez">
          <form>
          
            <asp:Label ID="lblVolumenGastadoNAOH" runat="server" Text="Volumen Gastado NaOH: " AssociatedControlID="txtVolumenGastadoNAOH" CssClass="label"/>
            <asp:TextBox ID="txtVolumenGastadoNAOH" runat="server" Text="" Width="150"  Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblConcentracionNAOH" runat="server" Text="Concentracion NaOH: " AssociatedControlID="txtConcentracionNAOH" CssClass="label"/>
            <asp:TextBox ID="txtConcentracionNAOH" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoMuestraAcidez" runat="server" Text="Peso de la muestra: " AssociatedControlID="txtPesoMuestraAcidez" CssClass="label"/>
            <asp:TextBox ID="txtPesoMuestraAcidez" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>
            
          </form>
        </div>
<%--------------------- ------------------- ----------------------%>   

<%---------------------- FORM INDICE PEROXIDO  -----------------------%>    
        <div id="form_Peroxido" title="Analisis INDICE PEROXIDO" class="form_Peroxido">
          <form>
          
            <asp:Label ID="lblVolGastadoTiosulfato" runat="server" Text="Volumen Gastado de Tiosulfato: " AssociatedControlID="txtVolGastadoTiosulfato" CssClass="label"/>
            <asp:TextBox ID="txtVolGastadoTiosulfato" runat="server" Text="" Width="150"  Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblVolumenBlanco" runat="server" Text="Volumen del Blanco: " AssociatedControlID="txtVolumenBlanco" CssClass="label"/>
            <asp:TextBox ID="txtVolumenBlanco" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblConcentracionTiosulfato" runat="server" Text="Conc. Tiosulfato de Sodio: " AssociatedControlID="txtConcentracionTiosulfato" CssClass="label"/>
            <asp:TextBox ID="txtConcentracionTiosulfato" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoMuestraPeroxido" runat="server" Text="Peso Muestra:" AssociatedControlID="txtPesoMuestraPeroxido" CssClass="label"/>
            <asp:TextBox ID="txtPesoMuestraPeroxido" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>
            
          </form>
        </div>
<%--------------------- ------------------- ----------------------%> 
<%---------------------- FORM INDICE RETENIDO DE TAMIZ  -----------------------%>    
        <div id="form_Tamiz" title="Analisis RETENIDO DE TAMIZ" class="form_Tamiz">
          <form>
          
            <asp:Label ID="lblPesoRetenido" runat="server" Text="Peso Retenido: " AssociatedControlID="txtPesoRetenido" CssClass="label"/>
            <asp:TextBox ID="txtPesoRetenido" runat="server" Text="" Width="150"  Height="8" CssClass="input textarea"/>

            <asp:Label ID="lblPesoMuestraTamix" runat="server" Text="Peso Muestra: " AssociatedControlID="txtPesoMuestraTamix" CssClass="label"/>
            <asp:TextBox ID="txtPesoMuestraTamix" runat="server" Text="" Width="150" Height="8" CssClass="input textarea"/>
            
          </form>
        </div>
<%--------------------- ------------------- ----------------------%>                   

                   
