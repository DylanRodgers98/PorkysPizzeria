Public Class frmAdmin
    Private Sub btnNewCust_Click(sender As Object, e As EventArgs) Handles btnNewCust.Click
        'Close current from and show Add Customer form
        frmCustAdd.Show()
        Me.Hide()
    End Sub

    Private Sub btnNewPizza_Click(sender As Object, e As EventArgs) Handles btnNewPizza.Click
        'Close current from and show Add Pizza form
        frmPizzaAdd.Show()
        Me.Hide()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Close current form and show home form
        frmHome.Show()
        Me.Close()
    End Sub

    Private Sub btnEditCust_Click(sender As Object, e As EventArgs) Handles btnEditCust.Click
        'Close current from and show Edit Customer form
        frmCustEdit.Show()
        Me.Hide()
    End Sub

    Private Sub btnEditPizza_Click(sender As Object, e As EventArgs) Handles btnEditPizza.Click
        'Close current form and show Edit Pizza form
        frmPizzaEdit.Show()
        Me.Hide()
    End Sub

    Private Sub btnCreateOrder_Click(sender As Object, e As EventArgs) Handles btnCreateOrder.Click
        'Close current form and show Add Order form
        frmOrderAdd.Show()
        Me.Hide()
    End Sub

    Private Sub btnViewOrders_Click(sender As Object, e As EventArgs) Handles btnViewOrders.Click
        'Close current form and show View Orders form
        frmOrderView.Show()
        Me.Hide()
    End Sub

    Private Sub btnHK_Click(sender As Object, e As EventArgs) Handles btnHK.Click
        'Close current form and show Housekeeping form
        frmHK.Show()
        Me.Hide()
    End Sub

    Private Sub btnSales_Click(sender As Object, e As EventArgs) Handles btnSales.Click
        'Close current form and show Sales form
        frmSales.Show()
        Me.Hide()
    End Sub
End Class