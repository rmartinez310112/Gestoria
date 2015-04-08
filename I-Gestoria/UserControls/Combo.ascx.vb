Imports System.Data
Partial Class UserControls_Combo
    Inherits System.Web.UI.UserControl

    Public _idmes As Int32
    Public Property IdMes As Int32
        Get
            _idmes = Integer.Parse(rcMes.SelectedValue)
            Return _idmes
        End Get
        Set(value As Int32)
            _idmes = value
            If (rcMes.Items.Count = 0) Then
                Me.LlenaCombo()
            End If
            rcMes.SelectedItem.Selected = False
            'rcMes.Items.FindItemByValue(value.ToString()).Selected = True
        End Set
    End Property

    Public Function LlenaCombo()
        'creamos un datatable que almacenará nuestros meses.
        Dim dsMeses As New DataTable("meses")
        'Añadimos las columnas codigo y descripcion
        dsMeses.Columns.Add("codigo", GetType(Integer))
        dsMeses.Columns.Add("descripcion", GetType(String))

        'Añadimos los meses al dataset
        'dsMeses.Rows.Add(New Object() {-1, "Seleccione"})
        dsMeses.Rows.Add(New Object() {1, "Enero"})
        dsMeses.Rows.Add(New Object() {2, "Febrero"})
        dsMeses.Rows.Add(New Object() {3, "Marzo"})
        dsMeses.Rows.Add(New Object() {4, "Abril"})
        dsMeses.Rows.Add(New Object() {5, "Mayo"})
        dsMeses.Rows.Add(New Object() {6, "Junio"})
        dsMeses.Rows.Add(New Object() {7, "Julio"})
        dsMeses.Rows.Add(New Object() {8, "Agosto"})
        dsMeses.Rows.Add(New Object() {9, "Septiembre"})
        dsMeses.Rows.Add(New Object() {10, "Octubre"})
        dsMeses.Rows.Add(New Object() {11, "Noviembre"})
        dsMeses.Rows.Add(New Object() {12, "Diciembre"})
        dsMeses.AcceptChanges()

        'Establecemos la datatable como la fuente de datos de nuestro combo.
        rcMes.DataSource = dsMeses
        rcMes.DataValueField = "codigo"
        rcMes.DataTextField = "descripcion"
        rcMes.DataBind()
        rcMes.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("Seleccione", "0"))
    End Function

    Protected Sub rcMes_DataBound(sender As Object, e As System.EventArgs) 'Handles rcMes.DataBound
        ' var combo = (rcMes)sender; 
        'combo.Items.Insert(0, new RadComboBoxItem("Select a country", string.Empty)); 

    End Sub

    Protected Sub rcMes_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) 'Handles rcMes.SelectedIndexChanged

    End Sub

    Protected Sub rcMes_TextChanged(sender As Object, e As System.EventArgs) 'Handles rcMes.TextChanged

    End Sub
    Private Sub Combo_Load(sender As Object, e As EventArgs) Handles rcMes.Load
        If Not Page.IsPostBack Then
            If rcMes.Items.Count = 0 Then
                Me.LlenaCombo()
            End If
            rcMes_TextChanged(sender, e)
        End If
    End Sub

End Class




