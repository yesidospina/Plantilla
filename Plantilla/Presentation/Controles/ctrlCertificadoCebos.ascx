<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCertificadoCebos.ascx.cs" Inherits="Presentation.Controles.ctrlCertificadoCebos" %>


    <fieldset>
        <legend>Certificado Cebos </legend>
        <div class="container_center">
            <div style="width:482px; float:left;">
                <div class="divForm">
                    <asp:Label ID="lblFechaSebos" runat="server" AssociatedControlID="txtFechaSebos" Text="Fecha: " CssClass="divLabel" />
                    <asp:TextBox ID="txtFechaSebos" runat="server" CssClass="inCalendar input textarea" Width="100px" Height="10px"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaSebos" CssClass="field-validation-error" ErrorMessage="Debe seleccionar una fecha" />
                </div>

                <div class="divForm">
                    <asp:Label ID="lblSebosCliente" runat="server" Text="Cliente:" CssClass="divLabel" />
                    <asp:DropDownList runat="server" ID="ddlSebosCliente" AppendDataBoundItems="true">
                        <asp:ListItem Value="0" Text="Seleccionar Cliente"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="divForm">
                    <asp:Label ID="lblVehiculoSebos" runat="server" AssociatedControlID="txtVehiculoSebos" Text="Vehiculo: " CssClass="divLabel" />
                        <asp:TextBox ID="txtVehiculoSebos" runat="server" Width="100px" Height="10px" MaxLength="8"  CssClass="input textarea"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVehiculoSebos" CssClass="field-validation-error" ErrorMessage="Digite la placa del vehiculo" />
                </div>

                <div class="divForm">
                    <asp:Label ID="lblSebosProducto" runat="server" AssociatedControlID="ddlSebosProducto" Text="Producto" CssClass="divLabel"/>
                        <asp:DropDownList runat="server" ID="ddlSebosProducto" AppendDataBoundItems="true" AutoPostBack="true" >
                        <asp:ListItem Value="0" Text="Seleccionar Producto"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="divForm" style="font-weight:bolder;">
                    <asp:Label ID="lblCantidadSebos" runat="server" AssociatedControlID="txtCantidadSebos" Text="Cantidad: " CssClass="divLabel" />
                    <asp:TextBox ID="txtCantidadSebos" runat="server" Width="50px" Height="10px" MaxLength="6"  CssClass="input textarea"/>
                    <asp:Label ID="lblKg" runat="server" Text="Kg"/>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCantidadSebos" CssClass="field-validation-error" ErrorMessage="Digite la temperatura" />
                    
                </div>

                <div class="divForm">
                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones: " CssClass="divLabel" />
                    <asp:TextBox id="txaObservaciones" TextMode="multiline" Rows="3" runat="server" />
                </div>
            </div>

            <div style="width:446px; float:left; text-align:center; font-weight:bolder;">
                <div class="divForm">
                    <div style="width:30%; float:left;">
                        <asp:Label ID="lblLote" runat="server" Text="LOTE " Width="150px" />
                    </div>
                    <div style="width:30%; float:left;">
                        <asp:Label ID="lblFechaFabricacion" runat="server" Text="FECHA FABRICACION " Width="150px" />
                    </div>
                    <div style="width:30%; float:left;">
                        <asp:Label ID="lblFechaVence" runat="server" Text="FECHA VENCIMIENTO " Width="150px" />
                    </div>
                </div>

                <div class="divForm" style="text-align:center;">
                    <div style="width:30%; float:left; margin-left:10px">
                        <asp:TextBox ID="txtLote1" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:30%; float:left; margin-right:10px;">
                        <asp:TextBox ID="txtFechaFab_1" runat="server" CssClass="inCalendar input" Width="100px" Height="10px"/>
                    </div>
                    <div style="width:25%; float:left; margin-left:-10px;">
                        <asp:TextBox ID="txtFechaVence_1" runat="server" Width="75px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:5%; float:left; margin-left:-10px; margin-top: 3px;">
                        <asp:Button ID="btnCalFecha1" runat="server" Text="Calc" OnClick="btnCalFecha1_Click"/>
                    </div>
                </div>

                <div class="divForm" style="text-align:center;">
                    <div style="width:30%; float:left; margin-left:10px">
                        <asp:TextBox ID="txtLote2" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:30%; float:left; margin-right:10px;">
                        <asp:TextBox ID="txtFechaFab_2" runat="server" CssClass="inCalendar input" Width="100px" Height="10px"/>
                    </div>
                    <div style="width:25%; float:left; margin-left:-10px;">
                        <asp:TextBox ID="txtFechaVence_2" runat="server" Width="75px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:5%; float:left; margin-left:-10px; margin-top: 3px;">
                        <asp:Button ID="btnCalFecha2" runat="server" Text="Calc" OnClick="btnCalFecha2_Click" />
                    </div>
                </div>

                <div class="divForm" style="text-align:center;">
                    <div style="width:30%; float:left; margin-left:10px">
                        <asp:TextBox ID="txtLote3" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:30%; float:left; margin-right:10px;">
                        <asp:TextBox ID="txtFechaFab_3" runat="server" CssClass="inCalendar input" Width="100px" Height="10px"/>
                    </div>
                    <div style="width:25%; float:left; margin-left:-10px;">
                        <asp:TextBox ID="txtFechaVence_3" runat="server" Width="75px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:5%; float:left; margin-left:-10px; margin-top: 3px;">
                        <asp:Button ID="btnCalfecha3" runat="server" Text="Calc" OnClick="btnCalfecha3_Click" />
                    </div>
                </div>

                <div class="divForm" style="text-align:center;">
                    <div style="width:30%; float:left; margin-left:10px">
                        <asp:TextBox ID="txtLote4" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:30%; float:left; margin-right:10px;">
                        <asp:TextBox ID="txtFechaFab_4" runat="server" CssClass="inCalendar input" Width="100px" Height="10px"/>
                    </div>
                    <div style="width:25%; float:left; margin-left:-10px;">
                        <asp:TextBox ID="txtFechaVence_4" runat="server" Width="75px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:5%; float:left; margin-left:-10px; margin-top: 3px;">
                        <asp:Button ID="btnCalfecha4" runat="server" Text="Calc" OnClick="btnCalfecha4_Click"/>
                    </div>
                </div>

                <div class="divForm" style="text-align:center;">
                    <div style="width:30%; float:left; margin-left:10px">
                        <asp:TextBox ID="txtLote5" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:30%; float:left; margin-right:10px;">
                        <asp:TextBox ID="txtFechaFab_5" runat="server" CssClass="inCalendar input" Width="100px" Height="10px"/>
                    </div>
                    <div style="width:25%; float:left; margin-left:-10px;">
                        <asp:TextBox ID="txtFechaVence_5" runat="server" Width="75px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:5%; float:left; margin-left:-10px; margin-top: 3px;">
                        <asp:Button ID="btnCalfecha5" runat="server" Text="Calc" OnClick="btnCalfecha5_Click"/>
                    </div>
                </div>
            </div>

            <div style="width:500px; float:left; font-weight:bolder;">
                <div class="divForm">
                    <div style="width:22%; float:left;">
                        <asp:Label ID="lblHumedad" runat="server" Text="% Humedad:" Width="80px" />
                    </div>
                    <div style=" float:left; width: 135px;">
                        <asp:TextBox ID="txtHumedad" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                </div>

                <div class="divForm">
                    <div style="width:16%; float:left;">
                        <asp:Label ID="lblPeroxido" runat="server" Text="I. Peroxido:" Width="80px" />
                    </div>
                    <div style=" float:left;">
                        <asp:TextBox ID="txtPeroxido" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:5%; float:left;">
                        <asp:Label ID="lblmeqKg" runat="server" Text=" meq/Kg" Width="20px" />
                    </div>
                </div>

                <div class="divForm">
                    <div style="width:22%; float:left;">
                        <asp:Label ID="lblAcidez" runat="server" Text="% Acidez:" Width="80px" />
                    </div>
                    <div style=" float:left; width: 135px;">
                        <asp:TextBox ID="txtAcidez" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                </div>

                <div class="divForm">
                    <div style="width:16%; float:left;">
                        <asp:Label ID="lblSolidos" runat="server" Text="% Solidos:" Width="80px" />
                    </div>
                    <div style=" float:left;">
                        <asp:TextBox ID="txtSolidos" runat="server" Width="100px" Height="10px" CssClass="input"/>
                    </div>
                    <div style="width:5%; float:left;">
                        <asp:Label ID="lblUnidadSolidos" runat="server" Text=" v/v" Width="20px" />
                    </div>
                </div>

            </div>
        </div>
    </fieldset>

    <div class="divForm" style="text-align:center;">
        <asp:Button ID="btnGuardaSebo" runat="server" Text="IMPRIMIR" CssClass="button" OnClick="btnGuardaSebo_Click"/>
    </div>
