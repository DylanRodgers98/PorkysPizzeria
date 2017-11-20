Public Class frmPizzaAdd
    'Declare global variables and set up path to the pizzas file
    Dim PizzaFile As String = Application.StartupPath & "\pizzas.dat"
    Dim NumRecs As Integer
    Dim RecPos As Integer

    Private Sub frmPizzaAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declare variables
        Dim PizzaID As Integer

        'Open customers file in random access mode
        FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
        'Calculate the number of records in the file
        NumRecs = LOF(1) / Len(PizzaRec)
        'Set CustID to be the next record in the file
        PizzaID = NumRecs + 1
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(1, PizzaRec, RecPos)
            'If PizzaID matches the ID of the record in the file
            If PizzaRec.PizzaID = PizzaID Then
                'Increase PizzaID by 1
                PizzaID = PizzaID + 1
            End If
            'Move on to the next record
        Next
        'Set the PizzaID to be the next record
        txtPizzaID.Text = PizzaID
        'Close the file
        FileClose(1)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'If text boxes are empty
        If txtName.Text = "" Then
            'Display error message
            MsgBox("Please enter the pizza's name." & vbNewLine & "EXAMPLE: Cheese & Tomato", MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtDesc.Text = "" Then
            'Display error message
            MsgBox("Please enter a description for the pizza." & vbNewLine & "EXAMPLE: Rich Tomato with Mozzarella", MessageBoxIcon.Error)
            Exit Sub
        ElseIf Len(txtDesc.Text) > 200 Then
            'Display error message
            MsgBox("Pizza description must be up to 200 characters in length.", MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtSml.Text = "" Or Not IsNumeric(txtSml.Text) Then
            'Display error message
            MsgBox("Please enter the pizza's Small (7 inch) price, not including currency symbols." & vbNewLine & "EXAMPLE: 6.99", MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtMed.Text = "" Or Not IsNumeric(txtMed.Text) Then
            'Display error message
            MsgBox("Please enter the pizza's Medium (9 inch) price, not including currency symbols." & vbNewLine & "EXAMPLE: 8.99", MessageBoxIcon.Error)
            Exit Sub
        ElseIf txtLrg.Text = "" Or Not IsNumeric(txtLrg.Text) Then
            'Display error message
            MsgBox("Please enter the pizza's Large (14 inch) price, not including currency symbols." & vbNewLine & "EXAMPLE: 10.99", MessageBoxIcon.Error)
            Exit Sub
        End If

        'Read textbox values into fields of record
        With PizzaRec
            .PizzaID = Val(txtPizzaID.Text)
            .PizzaName = txtName.Text
            .Description = txtDesc.Text
            .PriceSmall = txtSml.Text
            .PriceMedium = txtMed.Text
            .PriceLarge = txtLrg.Text
        End With

        'Open the pizza file in random access mode
        FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
        'Calculate the number of records in the file
        NumRecs = LOF(1) / Len(PizzaRec)
        'Write the record to the next space in the file
        RecPos = NumRecs + 1
        FilePut(1, PizzaRec, RecPos)
        'Close file
        FileClose(1)

        'Display message box showing where in the file the customer details have been saved
        MsgBox("Pizza details saved to file." & vbNewLine & "(At file position " & Val(txtPizzaID.Text) & ")")

        'Clear text boxes
        txtName.Text = ""
        txtDesc.Text = ""
        txtSml.Text = ""
        txtMed.Text = ""
        txtLrg.Text = ""
        'Reload form
        Call frmPizzaAdd_Load(Me, e)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Close current from and show admin form
        frmAdmin.Show()
        Me.Close()
    End Sub
End Class