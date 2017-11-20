Public Class frmOrderAdd
    'Declare global variables, and set up file paths
    Dim CustFile As String = Application.StartupPath & "\cust.dat" 'File 1
    Dim PizzaFile As String = Application.StartupPath & "\pizzas.dat" 'File 2
    Dim OrderFile As String = Application.StartupPath & "\orders.dat" 'File 3
    Dim POFile As String = Application.StartupPath & "\pizzaOrdered.dat" 'File 4
    Dim TempFile As String = Application.StartupPath & "\tempOrder.dat" 'File 5
    Dim RecPos As Integer
    Dim NumRecs As Integer

    Private Sub frmOrderAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declare variables
        Dim Forename As String
        Dim Surname As String
        Dim OrderID As String
        Dim CustID As String
        Dim PizzaName As String
        Dim PizzaSize As String
        Dim PizzaRecPos As Integer
        Dim Total As Decimal = 1.5

        'Open orders file in random access mode
        FileOpen(3, OrderFile, OpenMode.Random, , , Len(OrdersRec))
        'Calculate the number of records in the file
        NumRecs = LOF(3) / Len(OrdersRec)
        'Set Order ID to be the next record in the file
        OrderID = NumRecs + 1
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read record from file
            FileGet(3, OrdersRec, RecPos)
            'If OrderID matches the ID of the record in the file
            If OrdersRec.OrderID = OrderID Then
                'Increase OrderID by 1
                OrderID = OrderID + 1
            End If
            'Move on to next record 
        Next
        'Add 0's to order ID to make it 4 digits in length
        Do While Len(OrderID) < 4
            OrderID = "0" & OrderID
        Loop
        'Display next Order ID in text box
        txtOrderID.Text = OrderID
        'Close file
        FileClose(3)

        'Clear text boxes, combo boxes, radio buttons and labels
        cmbPizza.Text = ""
        cmbPizza.Items.Clear()
        radSml.Checked = False
        radSml.Enabled = False
        radMed.Checked = False
        radMed.Enabled = False
        radLrg.Checked = False
        radLrg.Enabled = False
        txtQuantity.Text = ""
        txtQuantity.Enabled = False
        btnAdd.Enabled = False
        btnRemove.Enabled = False
        txtSubtotal.Text = ""
        txtTotal.Text = ""
        lstOrder.Items.Clear()
        lblSml.Text = ""
        lblMed.Text = ""
        lblLrg.Text = ""

        'Open pizza ordered file in random access mode
        FileOpen(5, TempFile, OpenMode.Random, , , Len(TempRec))
        'Calculate number of records in file
        NumRecs = LOF(5) / Len(TempRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read in the record from the file
            FileGet(5, TempRec, RecPos)

            'If order ID in the file matches the order ID of the current order being processed then
            If TempRec.OrderID = txtOrderID.Text Then
                'Open pizza file in random access mode
                FileOpen(2, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
                'Set record position for pizza file
                PizzaRecPos = 1
                'Read each record in the file until pizza is found
                While Not EOF(2) And PizzaRec.PizzaID <> TempRec.PizzaID
                    FileGet(2, PizzaRec, PizzaRecPos)
                    PizzaRecPos = PizzaRecPos + 1
                End While
                'Close pizza file
                FileClose(2)

                'Read the pizza name
                PizzaName = PizzaRec.PizzaName
                'Remove blank spaces from field
                Do While Microsoft.VisualBasic.Right(PizzaName, 1) = " "
                    PizzaName = Mid(PizzaName, 1, Len(PizzaName) - 1)
                Loop

                'Determine size of pizza and read into variable
                If TempRec.Size = "7" Then
                    PizzaSize = "Small"
                ElseIf TempRec.Size = "9" Then
                    PizzaSize = "Medium"
                ElseIf TempRec.Size = "14" Then
                    PizzaSize = "Large"
                End If

                'If the record's ID is greater than 0 (i.e. not marked for deletion)
                If Val(TempRec.TempID) > 0 Then
                    'Read pizza details into list box
                    lstOrder.Items.Add(TempRec.TempID & ") " & TempRec.Quantity & "x " & PizzaSize & " " & PizzaName & " - £" & TempRec.Subtotal)
                    'Calculate total price and display in text box
                    Total = Total + TempRec.Subtotal
                    txtTotal.Text = FormatCurrency(Total)
                End If
            End If
            'Move to the next record in the file
        Next
        'Close file
        FileClose(5)

        'Open Customers file in random access mode
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
        'Calculate the number of records in the file
        NumRecs = LOF(1) / Len(CustRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(1, CustRec, RecPos)

            'Read the forename
            Forename = CustRec.Forename
            'Remove blank spaces from field
            Do While Microsoft.VisualBasic.Right(Forename, 1) = " "
                Forename = Mid(Forename, 1, Len(Forename) - 1)
            Loop

            'Read the surname
            Surname = CustRec.Surname
            'Remove blank spaces from field
            Do While Microsoft.VisualBasic.Right(Surname, 1) = " "
                Surname = Mid(Surname, 1, Len(Surname) - 1)
            Loop

            'Read the Customer ID
            CustID = CustRec.CustID
            'Add 0's to customer ID to make it 4 digits in length
            Do While Len(CustID) < 4
                CustID = "0" & CustID
            Loop

            'If the customer hasn't been deleted
            If CustRec.CustID > 0 Then
                'Add customer details to the list box
                cmbCust.Items.Add(CustID & "   " & Forename & " " & Surname)
            End If
        Next
        'Close file
        FileClose(1)

        'Open Pizzas file in random access mode
        FileOpen(2, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
        'Calculate the number of records in the file
        NumRecs = LOF(2) / Len(PizzaRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(2, PizzaRec, RecPos)

            'Read the pizza name
            PizzaName = PizzaRec.PizzaName
            'Remove blank spaces from field
            Do While Microsoft.VisualBasic.Right(PizzaName, 1) = " "
                PizzaName = Mid(PizzaName, 1, Len(PizzaName) - 1)
            Loop

            'If the pizza hasn't been deleted 
            If PizzaRec.PizzaID > 0 Then
                'Add customer details to the list box
                cmbPizza.Items.Add(PizzaRec.PizzaID & "   " & PizzaName)
            End If
        Next
        'Close file
        FileClose(2)
    End Sub

    Private Sub frmOrderAdd_FormClosing(sender As Object, e As EventArgs) Handles MyBase.FormClosing
        'As the form is closing, delete the temporary order file
        Kill(TempFile)
    End Sub

    Private Sub cmbCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCust.SelectedIndexChanged
        'Declare SearchID variable and read the selected customer's ID into it
        Dim SearchID As String = Val(Microsoft.VisualBasic.Left(cmbCust.Text, 10))

        'Open customers file in random access mode
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
        'Start at the beginning of the file
        RecPos = 1
        'Read the first record stored
        FileGet(1, CustRec, RecPos)
        'If record isn't found, retrive next record until it is found
        Do While Not EOF(1) And CustRec.CustID <> SearchID
            RecPos = RecPos + 1
            FileGet(1, CustRec, RecPos)
        Loop
        'Close file
        FileClose(1)

        'If record is found, display the customer's details in the file
        With CustRec
            If .CustID = SearchID Then
                txtForename.Text = .Forename
                txtSurname.Text = .Surname
                txtHouse.Text = .House
                txtStreet.Text = .Street
                txtDistrict.Text = .District
                txtTown.Text = .Town
                txtCounty.Text = .County
                txtPostcode.Text = .Postcode
                txtTel.Text = .TelNo
            End If
        End With
    End Sub

    Private Sub cmbPizza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPizza.SelectedIndexChanged
        'Declare SearchID variable and read the selected pizza's ID into it
        Dim SearchID As String = Val(Microsoft.VisualBasic.Left(cmbPizza.Text, 10))

        'When a pizza is selected, enable the Size radio buttons, the Quantity text box & the Add button
        radSml.Enabled = True
        radMed.Enabled = True
        radLrg.Enabled = True
        btnAdd.Enabled = True

        'Open customers file in random access mode
        FileOpen(2, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
        'Start at the beginning of the file
        RecPos = 1
        'Read the first record stored
        FileGet(2, PizzaRec, RecPos)
        'If record isn't found, retrive next record until it is found
        Do While Not EOF(2) And PizzaRec.PizzaID <> SearchID
            RecPos = RecPos + 1
            FileGet(2, PizzaRec, RecPos)
        Loop
        'Close file
        FileClose(2)

        'If record is found, display the customer's details in the file
        With PizzaRec
            If .PizzaID = SearchID Then
                lblSml.Text = "   " & FormatCurrency(.PriceSmall)
                lblSml.ForeColor = Color.Red
                lblMed.Text = "   " & FormatCurrency(.PriceMedium)
                lblMed.ForeColor = Color.Red
                lblLrg.Text = "   " & FormatCurrency(.PriceLarge)
                lblLrg.ForeColor = Color.Red
            End If
        End With
    End Sub

    Private Sub radSml_CheckedChanged(sender As Object, e As EventArgs) Handles radSml.CheckedChanged
        'Enable quantity text box
        txtQuantity.Enabled = True

        'If a pizza is selected then
        If cmbPizza.Text <> "" Then
            'If no quantity is input then
            If txtQuantity.Text = "" Then
                'Set quantity to 1
                txtQuantity.Text = "1"
            End If
            'Calculate subtotal for selected size multiplied by the desired quantity
            txtSubtotal.Text = FormatCurrency(PizzaRec.PriceSmall * txtQuantity.Text)
        End If
    End Sub

    Private Sub radMed_CheckedChanged(sender As Object, e As EventArgs) Handles radMed.CheckedChanged
        'Enable quantity text box
        txtQuantity.Enabled = True

        'If a pizza is selected then
        If cmbPizza.Text <> "" Then
            'If no quantity is input then
            If txtQuantity.Text = "" Then
                'Set quantity to 1
                txtQuantity.Text = "1"
            End If
            'Calculate subtotal for selected size multiplied by the desired quantity
            txtSubtotal.Text = FormatCurrency(PizzaRec.PriceMedium * txtQuantity.Text)
        End If
    End Sub

    Private Sub radLrg_CheckedChanged(sender As Object, e As EventArgs) Handles radLrg.CheckedChanged
        'Enable quantity text box
        txtQuantity.Enabled = True

        'If a pizza is selected then
        If cmbPizza.Text <> "" Then
            'If no quantity is input then
            If txtQuantity.Text = "" Then
                'Set quantity to 1
                txtQuantity.Text = "1"
            End If
            'Calculate subtotal for selected size multiplied by the desired quantity
            txtSubtotal.Text = FormatCurrency(PizzaRec.PriceLarge * txtQuantity.Text)
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(sender As Object, e As EventArgs) Handles txtQuantity.TextChanged
        'If quantity text box is blank then
        If txtQuantity.Text = "" Then
            'Set subtotal to £0.00
            txtSubtotal.Text = "£0.00"
            'Otherwise
        Else
            'If Small radio button is selected then
            If radSml.Checked = True Then
                'Calculate subtotal for selected size multiplied by the desired quantity
                txtSubtotal.Text = FormatCurrency(PizzaRec.PriceSmall * txtQuantity.Text)
                'If Medium radio button if selected then
            ElseIf radMed.Checked = True Then
                'Calculate subtotal for selected size multiplied by the desired quantity
                txtSubtotal.Text = FormatCurrency(PizzaRec.PriceMedium * txtQuantity.Text)
                'If Large radio button is selected then
            ElseIf radLrg.Checked = True Then
                'Calculate subtotal for selected size multiplied by the desired quantity
                txtSubtotal.Text = FormatCurrency(PizzaRec.PriceLarge * txtQuantity.Text)
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        'If a customer hasn't been selected then
        If cmbCust.Text = "" Then
            'Display error message
            MsgBox("Please select a customer!", MessageBoxIcon.Error)
            Exit Sub
            'If a pizza size hasn't been selected then
        ElseIf radSml.Checked = False And radMed.Checked = False And radLrg.Checked = False Then
            'Display error message
            MsgBox("Please select a pizza size!", MessageBoxIcon.Error)
            Exit Sub
            'If a pizza quantity hasn't been input then
        ElseIf txtQuantity.Text = "" Or txtQuantity.Text = "0" Then
            'Display error message
            MsgBox("Please select a pizza quantity!", MessageBoxIcon.Error)
            Exit Sub
            'Otherwise
        Else
            'Read in fields of record from text boxes
            With TempRec
                .OrderID = Val(Microsoft.VisualBasic.Left(txtOrderID.Text, 4))
                .PizzaID = Val(Microsoft.VisualBasic.Left(cmbPizza.Text, 3))
                .Quantity = txtQuantity.Text
                If radSml.Checked = True Then
                    .Size = "7"
                ElseIf radMed.Checked = True Then
                    .Size = "9"
                ElseIf radLrg.Checked = True Then
                    .Size = "14"
                End If
                .Subtotal = txtSubtotal.Text
            End With

            'Open temporary order file in random access mode
            FileOpen(5, TempFile, OpenMode.Random, , , Len(TempRec))
            'Calculate number of records in the file
            NumRecs = LOF(5) / Len(TempRec)
            'Store the new record position
            RecPos = NumRecs + 1
            'Set record's ID in the temporary order file
            TempRec.TempID = RecPos
            'Write the record to the pizza ordered file
            FilePut(5, TempRec, RecPos)
            'Close file
            FileClose(5)

            'Clear customer text boxes and combo boxes
            cmbCust.Items.Clear()
            'Reload form
            Call frmOrderAdd_Load(Me, e)
        End If
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        'Declare variables
        Dim PORecPos As Integer
        Dim PONumRecs As Integer

        'If Order list box is empty, display error message
        If lstOrder.Items.Count = 0 Then
            MsgBox("YOU HAVEN'T ADDED ANYTHING TO YOUR ORDER!" & vbNewLine & "Please add a pizza using the dropdown menu above.", MessageBoxIcon.Error)
            Exit Sub
        Else
            'Open temporary order file in random access file
            FileOpen(5, TempFile, OpenMode.Random, , , Len(TempRec))
            'Calculate the number of records in the file
            NumRecs = LOF(5) / Len(TempRec)
            'For each record in the file
            For RecPos = 1 To NumRecs
                'Read the record from the file
                FileGet(5, TempRec, RecPos)
                'If item hasn't been marked for deletion (i.e. ID > 0)
                If TempRec.TempID > 0 Then
                    'Read in fields of the temp record and store in new record
                    PORec.OrderID = TempRec.OrderID
                    PORec.PizzaID = TempRec.PizzaID
                    PORec.Quantity = TempRec.Quantity
                    PORec.Size = TempRec.Size
                    PORec.Subtotal = TempRec.Subtotal

                    'Open pizza ordered file in random access mode
                    FileOpen(4, POFile, OpenMode.Random, , , Len(PORec))
                    'Calculate number of records in the file
                    PONumRecs = LOF(4) / Len(PORec)
                    'Set the record position to the next record in the file
                    PORecPos = PONumRecs + 1
                    'Write the new record to the pizza ordered file
                    FilePut(4, PORec, PORecPos)
                    'Close file
                    FileClose(4)
                End If
            Next
            'Close File
            FileClose(5)
            'Delete TempFile
            Kill(TempFile)

            'Read in fields of record
            With OrdersRec
                .OrderID = Val(Microsoft.VisualBasic.Left(txtOrderID.Text, 4))
                .CustID = Val(Microsoft.VisualBasic.Left(cmbCust.Text, 4))
                .OrderDate = Date.Today
                .Total = txtTotal.Text
            End With

            'Open order file in random access mode
            FileOpen(3, OrderFile, OpenMode.Random, , , Len(OrdersRec))
            'Calculate number of records in the file
            NumRecs = LOF(3) / Len(OrdersRec)
            'Store the new record position
            RecPos = NumRecs + 1
            'Write the record to the order file
            FilePut(3, OrdersRec, RecPos)
            'Close file
            FileClose(3)

            'Clear customer text boxes and combo boxes
            cmbCust.Text = ""
            cmbCust.Items.Clear()
            txtForename.Text = ""
            txtSurname.Text = ""
            txtHouse.Text = ""
            txtStreet.Text = ""
            txtDistrict.Text = ""
            txtTown.Text = ""
            txtCounty.Text = ""
            txtPostcode.Text = ""
            txtTel.Text = ""
            'Reload form
            Call frmOrderAdd_Load(Me, e)
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Close current from and show Admin form
        frmAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        'Open CustFile in random access mode
        FileOpen(5, TempFile, OpenMode.Random, , , Len(TempRec))
        'Calculate number of records in the file
        NumRecs = LOF(5) / Len(TempRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(5, TempRec, RecPos)

            'Make ID negative (i.e. marked for deletion)
            If TempRec.TempID = Val(Microsoft.VisualBasic.Left(lstOrder.Text, 3)) Then
                TempRec.TempID = -Val(TempRec.TempID)
            End If

            'Write the record back to the file
            FilePut(5, TempRec, RecPos)
        Next
        'Close CustFile
        FileClose(5)

        'Reload form
        Call frmOrderAdd_Load(Me, e)
    End Sub

    Private Sub lstOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrder.SelectedIndexChanged
        'If an ordered item is selected, enable the Remove Item button
        btnRemove.Enabled = True
    End Sub
End Class