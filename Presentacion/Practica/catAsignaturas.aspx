<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="catAsignaturas.aspx.cs" Inherits="Presentacion.Practica.catAsignaturas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/datatables.js"></script>
          <script>

            $(document).ready(function () {
                $('#grdAsignaturas').DataTable({
                    "language": {
                        "lengthMenu": "Mostrar _MENU_ registros por página",
                        "zeroRecords": "No hay resultados",
                        "info": "Página _PAGE_ de _PAGES_",
                        "infoEmpty": "No hay resultados",
                        "infoFiltered": "(filtrados de _MAX_ registros)",
                        "search": "Buscar:",
                        "paginate": {
                            "first": " Primero ",
                            "last": " Último ",
                            "next": " Siguiente ",
                            "previous": "Previo "
                        },


                    }
                });
            });
    </script>

    <div class="form-horizontal">
        <div  class="form-horizontal">
            
             <div class="control-group">
           <label class="control-label" for="txtID">
                    ID</label>
                     <div class="controls">
                        <asp:TextBox ID="txtID" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>

                    </div>
                    </div>

             <div class="control-group">
           <label class="control-label" for="txtDescripcion">
                    Asignatura</label>
                     <div class="controls">

                        <asp:TextBox ID="txtAsignatura" CssClass="form-control" runat="server"></asp:TextBox>
                   </div>
                   </div>



                    <div class="control-group">
           <label class="control-label" for="txtDescripcion">
                    Codigo</label>
                     <div class="controls">
                        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    </div>


                    
                    <div class="control-group">
           <label class="control-label" for="txtDescripcion">
                    Asignatura Requisito</label>
                     <div class="controls">
                         <asp:DropDownList ID="ddlAsignaturaRequisito" CssClass="form-control" runat="server" DataTextField="asignatura" DataValueField="id"></asp:DropDownList>
                   </div>
                    </div>

                 <div class="control-group">
           <label class="control-label" for="txtDescripcion">
                    Activo</label>
                     <div class="controls">
                        <asp:CheckBox ID="ckbAvtivo" runat="server" />
                   </div>
                    </div>

        </div>

           <div class="form-actions">
          
               <div class="controls" >
                  
               <asp:Button  ID="btnGuardar" runat="server" Text="Guardar" 
                             Width="148px" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                </div>
                <br/>

                 <div class="controls">
                        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" ClientIDMode="Static" 
                              Width="148px" CssClass="btn btn-success" OnClick="btnNuevo_Click"/>
                  </div>
                  </div>

                   
     </div>

          <div>
    <h4>Catalogo Asignaturas</h4>
      </div>
        <div class="span12">
         <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <asp:GridView ID="grdAsignaturas" ClientIDMode="Static" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="id" EnableSortingAndPagingCallbacks="True" OnPreRender="grdAsignaturas_PreRender" OnRowCommand="grdAsignaturas_RowCommand">

                        <Columns>
                            <asp:BoundField DataField="id" HeaderText="idAsignatura" Visible="False" />
                            <asp:BoundField DataField="asignatura" HeaderText="Asignatura" />
                            <asp:BoundField DataField="codigoAsignatura" HeaderText="Codigo" />
                            <asp:BoundField DataField="asignaturaRequisitoId" HeaderText="asignaturaRequisitoId" Visible="False" />
                            <asp:BoundField DataField="codigoAsignaturaRequisito" HeaderText="codigoAsignaturaRequisito" Visible="False" />
                            <asp:BoundField DataField="asignaturasRequisito" HeaderText="Asignaturas Requisito" />
                            <asp:CheckBoxField DataField="activo" HeaderText="Activo" />
                            <asp:ButtonField ButtonType="Button" CommandName="Editar" HeaderText="Editar" Text="Editar">
                            <ControlStyle CssClass="btn btn-primary" />
                            </asp:ButtonField>
                            <asp:ButtonField ButtonType="Button" CommandName="VerDetalle" HeaderText="Ver Detalle" Text="Ver Detalle">
                            <ControlStyle CssClass="btn btn-primary" />
                            </asp:ButtonField>
                        </Columns>
                        <FooterStyle BackColor="White" ForeColor="#000066" />
                        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                        <RowStyle ForeColor="#000066" />
                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#007DBB" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#00547E" />

                    </asp:GridView>
  <%--              </ContentTemplate>
                  <Triggers>
            <asp:AsyncPostBackTrigger ControlID="grdAsignaturas" EventName="PreRender" />
           
        </Triggers>
            </asp:UpdatePanel>--%>

        </div>


<%--        <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/bootstrap.js"></script>
      <script src="../Scripts/jquery-1.10.2.js"></script>
    <script src="../Scripts/datatables.js"></script>--%>
    
    


        

</asp:Content>
