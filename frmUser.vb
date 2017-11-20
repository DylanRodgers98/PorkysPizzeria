Public Class frmUser
    'Declare global variable
    Dim LIFile As String = Application.StartupPath & "\loggedIn.dat"
    Dim CustFile As String = Application.StartupPath & "\cust.dat" 'File 1
    Dim PizzaFile As String = Application.StartupPath & "\pizzas.dat" 'File 2
    Dim OrderFile As String = Application.StartupPath & "\orders.dat" 'File 3
    Dim POFile As String = Application.StartupPath & "\pizzaOrdered.dat" 'File 4
    Dim TempFile As String = Application.StartupPath & "\tempOrder.dat" 'File 5
    Dim RecPos As Integer
    Dim NumRecs As Integer
    Dim LoggedInUser As Integer

    Private Sub frmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declare variables
        Dim CustID As String
        Dim Password As String
        Dim Forename As String
        Dim Surname As String
        Dim House As String
        Dim Street As String
        Dim District As String
        Dim Town As String
        Dim County As String
        Dim Postcode As String
        Dim OrderID As String
        Dim PizzaName As String
        Dim PizzaSize As String
        Dim PizzaRecPos As Integer
        Dim Total As Decimal = 1.5

        'Open LoggedIn File
        FileOpen(1, LIFile, OpenMode.Input)
        'Read data from file into variable
        Input(1, LoggedInUser)
        'Close file
        FileClose(1)


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        'READ CUSTOMER'S NAME INTO TITLE

        'Open CustFile
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
        'Calculate length of record
        NumRecs = LOF(1) / Len(CustRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(1, CustRec, RecPos)

            'If ID in record matches ID saved in variable
            If Val(CustRec.CustID) = LoggedInUser Then
                'Read in the forename
                Forename = CustRec.Forename
                'Remove black spaces from forename
                Do While Microsoft.VisualBasic.Right(Forename, 1) = " "
                    Forename = Mid(Forename, 1, Len(Forename) - 1)
                Loop

                'Write that user's name into Title label
                lblTitle.Text = "WELCOME, " & UCase(Forename) & "!"
            End If
            'Move on to next record
        Next
        'Close file
        FileClose(1)
        'Center the title
        lblTitle.Left = (Width / 2) - (lblTitle.Width / 2)


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        'SET ORDER ID AND DISPLAY IT IN A TEXT BOX

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


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        'READ IN ANY PIZZAS ADDED TO THE ORDER (I.E. IN THE TEMPORARY ORDER FILE)

        'Open temporary pizza ordered file in random access mode
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


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        'READ ALL PIZZAS FROM PIZZA FILE INTO A COMBO BOX

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
            Do While Microsoft.VisualBasic.Right(PizzaName, 1) = " Then "
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


        '~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        'READ CUSTOMER'S DETAILS INTO TEXT BOXES ON 'MY ACCOUNT' TAB

        'Open customers file
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))

        'Read in records from file
        RecPos = 1

        'Get the first record stored in the file
        Do While Not EOF(1)
            'Read in record from file
            FileGet(1, CustRec, RecPos)

            'If the record matches selected customer, display their details
            If CustRec.CustID = LoggedInUser Then
                With CustRec
                    'Read Customer's ID into variable
                    CustID = .CustID
                    'Add 0's to customer ID to make it 4 digits in length
                    Do While Len(CustID) < 4
                        CustID = "0" & CustID
                    Loop
                    'Read ID into text box
                    txtCustID.Text = CustID

                    'Read password into variable
                    Password = .Password
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(Password, 1) = " "
                        Password = Mid(Password, 1, Len(Password) - 1)
                    Loop
                    'Read variable into text box
                    txtPassword.Text = Password

                    'Read Forename into variable
                    Forename = .Forename
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(Forename, 1) = " "
                        Forename = Mid(Forename, 1, Len(Forename) - 1)
                    Loop
                    'Read variable into text box
                    txtForename.Text = Forename

                    'Read Surname into variable
                    Surname = .Surname
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(Surname, 1) = " "
                        Surname = Mid(Surname, 1, Len(Surname) - 1)
                    Loop
                    'Read variable into text box
                    txtSurname.Text = Surname

                    'Read House into variable
                    House = .House
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(House, 1) = " "
                        House = Mid(House, 1, Len(House) - 1)
                    Loop
                    'Read variable into text box
                    txtHouse.Text = House

                    'Read Street into variable
                    Street = .Street
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(Street, 1) = " "
                        Street = Mid(Street, 1, Len(Street) - 1)
                    Loop
                    'Read variable into text box
                    txtStreet.Text = Street

                    'Read District into variable
                    District = .District
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(District, 1) = " "
                        District = Mid(District, 1, Len(District) - 1)
                    Loop
                    'Read variable into text box
                    txtDistrict.Text = District

                    'Read Town into variable
                    Town = .Town
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(Town, 1) = " "
                        Town = Mid(Town, 1, Len(Town) - 1)
                    Loop
                    'Read variable into text box
                    txtTown.Text = Town

                    'Read County into variable
                    County = .County
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(County, 1) = " "
                        County = Mid(County, 1, Len(County) - 1)
                    Loop
                    'Read variable into text box
                    txtCounty.Text = County

                    'Read Postcode into variable
                    Postcode = .Postcode
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(Postcode, 1) = " "
                        Postcode = Mid(Postcode, 1, Len(Postcode) - 1)
                    Loop
                    'Read variable into text box
                    txtPostcode.Text = Postcode

                    'Read Telephone Number into text box
                    txtTel.Text = .TelNo
                End With

                'Close file
                FileClose(1)
                Exit Sub
            Else
                'If records don't match then get the next record
                RecPos = RecPos + 1
            End If
            'Get the next record
        Loop
        'Close file
        FileClose(1)
    End Sub

    Private Sub frmUser_Closing(sender As Object, e As EventArgs) Handles MyBase.Closing
        'Delete loggedIn file and temporary order file
        Kill(LIFile)
        Kill(TempFile)
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
        If radSml.Checked = False And radMed.Checked = False And radLrg.Checked = False Then
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

            Call frmUser_Load(Me, e)
        End If
    End Sub

    Private Sub btnOrder_Click(sender As Object, e As EventArgs) Handles btnOrder.Click
        'Declare variables
        Dim PORecPos As Integer
        Dim PONumRecs As Integer

        'If Order list box is empty, display error message
        If lstOrder.Items.Count = 0 Then
            MsgBox("YOU HAVEN'T ADDED ANYTHING TO YOUR ORDER!" & vbNewLine & "Please add a pizza using the dropdown menu on the left.", MessageBoxIcon.Error)
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
                .CustID = LoggedInUser
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

            'Reload form
            Call frmUser_Load(Me, e)
        End If
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
        Call frmUser_Load(Me, e)
    End Sub

    Private Sub lstOrder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrder.SelectedIndexChanged
        'If an ordered item is selected, enable the Remove Item button
        If lstOrder.Text <> "" Then
            btnRemove.Enabled = True
        End If
    End Sub

    Private Sub tabOrderAdd_Enter(sender As Object, e As EventArgs) Handles tabOrderAdd.Enter
        'Change the size of the form and tab control when the Create An Order tab is entered
        Height = 330
        TabControl1.Height = 246
    End Sub

    Private Sub tabAccount_Enter(sender As Object, e As EventArgs) Handles tabAccount.Enter
        'Change the size of the form and tab control when the My Account tab is entered
        Height = 437
        TabControl1.Height = 353
    End Sub

    Private Sub tabLogOut_Enter(sender As Object, e As EventArgs) Handles tabLogOut.Enter
        'Change the size of the form and tab control when the Log Out tab is entered
        Height = 196
        TabControl1.Height = 112
    End Sub

    Private Sub tabOrderView_Enter(sender As Object, e As EventArgs) Handles tabOrderView.Enter
        'Declare variables
        Dim OrderID As String
        Dim CustRecPos As Integer

        'Change the size of the form and tab control when the My Orders tab is entered
        Height = 292
        TabControl1.Height = 208

        'Clear list boxes
        lstOrders.Items.Clear()
        lstPrevOrders.Items.Clear()
        lstItems.Items.Clear()

        'Open Orders file in random access mode
        FileOpen(3, OrderFile, OpenMode.Random, , , Len(OrdersRec))
        'Calculate the number of records in the file
        NumRecs = LOF(3) / Len(OrdersRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read in each record
            FileGet(3, OrdersRec, RecPos)

            'Open Customers file in random access mode
            FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
            'Get the first record stored in the file
            custRecPos = 1
            'Read through the file until the record belonging to the logged in user is found
            While Not EOF(1) And CustRec.CustID <> LoggedInUser
                'Read in the record from the file
                FileGet(1, CustRec, custRecPos)
                'Move on to next record
                custRecPos = custRecPos + 1
            End While
            'Close the Customers File
            FileClose(1)

            'If the customer is found then
            If CustRec.CustID = OrdersRec.CustID Then
                'Read in Order ID
                OrderID = OrdersRec.OrderID
                'If Order ID is negative
                If Microsoft.VisualBasic.Left(OrderID, 1) = "-" Then
                    'Replace "-" symbol with a "0"
                    Mid(OrderID, 1, 1) = "0"
                End If
                'Add 0's to order ID to make it 4 digits in length
                Do While Len(OrderID) < 4
                    OrderID = "0" & OrderID
                Loop

                With OrdersRec
                    'If OrderID is greater than 0 (i.e. not marked for deletion)
                    If Val(.OrderID) > 0 Then
                        'Display order details in the list box
                        lstOrders.Items.Add(OrderID & "    " & .OrderDate & "    " & FormatCurrency(.Total))
                        'If OrderID is less than 0 (i.e. negative, marked for deletion)
                    ElseIf Val(.OrderID) < 0 Then
                        'Display order details in the list box
                        lstPrevOrders.Items.Add(OrderID & "    " & .OrderDate & "    " & FormatCurrency(.Total))
                    End If
                End With
            End If
            'Move on to next record in file
        Next

        'If no orders are loaded into the list boxes, display "NO ORDERS FOUND" messsage
        If lstOrders.Items.Count = 0 Then
            lstOrders.Items.Add("NO ORDERS FOUND")
        End If
        If lstPrevOrders.Items.Count = 0 Then
            lstPrevOrders.Items.Add("NO ORDERS FOUND")
        End If
        'Close Orders file
        FileClose(3)
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        'Show the Home form and close the current form
        frmHome.Show()
        Me.Close()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'If button reads "Edit Details" (i.e. form isn't in edit mode)
        If btnEdit.Text = "Edit Details" Then
            'Unlock textboxes for editing
            txtPassword.Enabled = True
            txtForename.Enabled = True
            txtSurname.Enabled = True
            txtHouse.Enabled = True
            txtStreet.Enabled = True
            txtDistrict.Enabled = True
            txtTown.Enabled = True
            txtCounty.Enabled = True
            txtPostcode.Enabled = True
            txtTel.Enabled = True

            'Change the edit button to read Save
            btnEdit.Text = "Save Details"
            'If button reads "Save Details" (i.e. form is in edit mode)
        ElseIf btnEdit.Text = "Save Details" Then
            'If password isn't correct length
            If Len(txtPassword.Text) < 8 Or Len(txtPassword.Text) > 16 Then
                'Display error message
                MsgBox("Please enter a password between 8 and 16 characters.", MessageBoxIcon.Error)
                Exit Sub
                'If text boxes empty, display error messages
            ElseIf txtForename.Text = "" Then
                MsgBox("Please enter your Forename." & vbNewLine & "EXAMPLE: Michael", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtSurname.Text = "" Then
                MsgBox("Please enter your Surname." & vbNewLine & "EXAMPLE: Hunt", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtHouse.Text = "" Then
                MsgBox("Please enter your House Number/Name." & vbNewLine & "EXAMPLE: 40", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtStreet.Text = "" Then
                MsgBox("Please enter your Street." & vbNewLine & "EXAMPLE: Oak Street", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtDistrict.Text = "" Then
                MsgBox("Please enter the District you live in" & vbNewLine & "EXAMPLE: New Inn", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtTown.Text = "" Then
                MsgBox("Please enter the Town you live in" & vbNewLine & "EXAMPLE: Pontypool", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtCounty.Text = "" Then
                MsgBox("Please enter your County." & vbNewLine & "EXAMPLE: Torfaen", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtPostcode.Text = "" Then
                MsgBox("Please enter your Postcode." & vbNewLine & "EXAMPLE: NP44 6DW", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtTel.Text = "" Then
                MsgBox("Please enter your main Telephone/Mobile Number." & vbNewLine & "EXAMPLE: 07852134695", MessageBoxIcon.Error)
                Exit Sub
                'If password isn't correct length
            ElseIf Len(txtPostcode.Text) < 6 Or Len(txtPostcode.Text) > 8 Then
                'Display error message
                MsgBox("Your postcode is not in the correct format." & vbNewLine & "Please ensure it is in the format LLNN NLL, LNN NLL, or LN NLL." & vbNewLine & "EXAMPLE: NP12 8WJ, NP4 6DW, or W1 7JK.", MessageBoxIcon.Error)
                Exit Sub
                'If telephone number isn't correct length, or is not a numeric value
            ElseIf Len(txtTel.Text) <> 11 Or Not IsNumeric(txtTel.Text) Then
                'Display error message
                MsgBox("Please ensure your Telephone/Mobile Number is 11 digits long, with no spaces." & vbNewLine & "EXAMPLE: 07852134695", MessageBoxIcon.Error)
                Exit Sub
            End If

            'Read in fields of the customer record
            With CustRec
                .Password = txtPassword.Text
                .Forename = txtForename.Text
                .Surname = txtSurname.Text
                .House = txtHouse.Text
                .Street = txtStreet.Text
                .District = txtDistrict.Text
                .Town = txtTown.Text
                .County = txtCounty.Text
                .Postcode = txtPostcode.Text
                .TelNo = txtTel.Text
            End With

            'Open CustFile in random access mode
            FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
            'Set Record's position to be the same as the customer's ID
            RecPos = Val(txtCustID.Text)
            'Write the customers record back to the file
            FilePut(1, CustRec, RecPos)
            'Close CustFile
            FileClose(1)

            'Reload form
            Call frmUser_Load(Me, e)
            'Lock textboxes for editing
            txtPassword.Enabled = False
            txtForename.Enabled = False
            txtSurname.Enabled = False
            txtHouse.Enabled = False
            txtStreet.Enabled = False
            txtDistrict.Enabled = False
            txtTown.Enabled = False
            txtCounty.Enabled = False
            txtPostcode.Enabled = False
            txtTel.Enabled = False
            'Change the Save button to read Edit
            btnEdit.Text = "Edit Details"
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Declare variables
        Dim PORecPos As Integer
        Dim PONumRecs As Integer
        'Declare variable for a Yes/No MsgBox
        Dim Box As MsgBoxResult = MsgBox("Leaving us so soon?" & vbNewLine & "Are you sure you want to delete your account?", MsgBoxStyle.YesNo)
        'If yes is selected on the MsgBox, delete the customer
        If Box = MsgBoxResult.Yes Then
            'Open CustFile in random access mode
            FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
            'Start at the first record in the file
            RecPos = 1
            Do While Not EOF(1)
                'Read in the record from file
                FileGet(1, CustRec, RecPos)
                'If the ID in the file matches the ID of the user logged in then
                If CustRec.CustID = LoggedInUser Then
                    'DELETE CUSTOMER
                    'Make user's ID a negative number
                    CustRec.CustID = -Val(LoggedInUser)
                    'Write the customer's record back to the file
                    FilePut(1, CustRec, RecPos)
                    'Close CustFile
                    FileClose(1)

                    'DELETE ORDERS MADE BY CUSTOMER
                    'Open Order File in random access mode
                    FileOpen(2, OrderFile, OpenMode.Random, , , Len(OrdersRec))
                    'Calculate number of records in OrderFile
                    NumRecs = LOF(2) / Len(OrdersRec)
                    'For each record in the file
                    For RecPos = 1 To NumRecs
                        'Read in the record
                        FileGet(2, OrdersRec, RecPos)
                        'If the order record belongs to the customer being deleted
                        If OrdersRec.CustID = Val(txtCustID.Text) Then
                            'Set that order's ID to be negative (i.e. marked for deletion)
                            OrdersRec.OrderID = -Val(OrdersRec.OrderID)
                            'Write record to file
                            FilePut(2, OrdersRec, RecPos)

                            'Open Pizza Ordered file in random access mode
                            FileOpen(3, POFile, OpenMode.Random, , , Len(PORec))
                            'Calcuate number of records in POFile
                            PONumRecs = LOF(3) / Len(PORec)
                            'For each record in the file
                            For PORecPos = 1 To PONumRecs
                                'Read in the record
                                FileGet(3, PORec, PORecPos)
                                'If the order record belongs to the customer being deleted
                                If PORec.OrderID = OrdersRec.OrderID Then
                                    'Set that order's ID to be negative (i.e. marked for deletion)
                                    PORec.OrderID = -Val(PORec.OrderID)
                                    'Write record to file
                                    FilePut(3, PORec, PORecPos)
                                End If
                            Next
                            'Close POFile
                            FileClose(3)
                        End If
                        'Move on to next record
                    Next
                    'Close Order file
                    FileClose(2)

                    'Close current form and open the Home form
                    frmHome.Show()
                    Me.Close()
                    Exit Sub
                End If
                'Move on to next record in file
                RecPos = RecPos + 1
            Loop
        End If
    End Sub

    Private Sub lstOrders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrders.SelectedIndexChanged
        'Declare variables
        Dim PizzaRecPos As Integer
        Dim OrderID As String
        Dim PizzaName As String
        Dim PizzaSize As String
        'Declare variable for Total Cost and set to 1.5 for £1.50 delivery charge
        Dim Total As Decimal = 1.5

        'Clear Items list box
        lstItems.Items.Clear()

        'Find the selected order ID
        OrderID = Val(Microsoft.VisualBasic.Left(lstOrders.Text, 4))

        'Add 0's to order ID to make it 4 digits in length
        Do While Len(OrderID) < 4
            OrderID = "0" & OrderID
        Loop
        'Read OrderID into title label
        lblOrder.Text = "Order " & OrderID & ": "

        'Open pizza ordered file in random access mode
        FileOpen(4, POFile, OpenMode.Random, , , Len(PORec))
        'Calculate number of records in file
        NumRecs = LOF(4) / Len(PORec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read in each record
            FileGet(4, PORec, RecPos)
            'If order ID in the file matches the order ID of the current order being processed then
            If PORec.OrderID = Val(OrderID) Then
                'Open pizza file in random access mode
                FileOpen(2, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
                'Set record position for pizza file
                PizzaRecPos = 1
                'Read each record in the file until pizza is found
                While Not EOF(2) And PizzaRec.PizzaID <> PORec.PizzaID
                    FileGet(2, PizzaRec, PizzaRecPos)
                    PizzaRecPos = PizzaRecPos + 1
                End While
                'Close pizza file
                FileClose(2)

                If PizzaRec.PizzaID <> PORec.PizzaID Then
                    'Display "UNKNOWN PIZZA" as the pizza name
                    PizzaName = "[UNKNOWN PIZZA]"
                    'Otherwise
                Else
                    'Read the pizza name
                    PizzaName = PizzaRec.PizzaName
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(PizzaName, 1) = " "
                        PizzaName = Mid(PizzaName, 1, Len(PizzaName) - 1)
                    Loop
                End If

                'Determine size of pizza and read into variable
                If PORec.Size = "7" Then
                    PizzaSize = "Small"
                    'Add Price multiplied by Quantity onto Total
                    Total = Total + (PizzaRec.PriceSmall * PORec.Quantity)
                ElseIf PORec.Size = "9" Then
                    PizzaSize = "Medium"
                    'Add Price multiplied by Quantity onto Total
                    Total = Total + (PizzaRec.PriceMedium * PORec.Quantity)
                ElseIf PORec.Size = "14" Then
                    PizzaSize = "Large"
                    'Add Price multiplied by Quantity onto Total
                    Total = Total + (PizzaRec.PriceLarge * PORec.Quantity)
                End If

                'Read pizza details into list box
                lstItems.Items.Add(PORec.Quantity & "x " & PizzaSize & " " & PizzaName & " - £" & PORec.Subtotal)
            End If
            'Move on to next record in file
        Next

        'Add delivery charge and total into list box
        lstItems.Items.Add("")
        lstItems.Items.Add("DELIVERY CHARGE - £1.50")
        lstItems.Items.Add("TOTAL - " & FormatCurrency(Total))
        'Close file
        FileClose(4)
    End Sub

    Private Sub lstPrevOrders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPrevOrders.SelectedIndexChanged
        'Declare variables
        Dim PizzaRecPos As Integer
        Dim OrderID As String
        Dim PizzaName As String
        Dim PizzaSize As String
        'Declare variable for Total Cost and set to 1.5 for £1.50 delivery charge
        Dim Total As Decimal = 1.5

        'Clear Items list box
        lstItems.Items.Clear()

        'Find the selected order ID
        OrderID = Val(Microsoft.VisualBasic.Left(lstPrevOrders.Text, 4))
        'Add 0's to order ID to make it 4 digits in length
        Do While Len(OrderID) < 4
            OrderID = "0" & OrderID
        Loop
        'Read OrderID into title label
        lblOrder.Text = "Order " & OrderID & ":"

        'Open pizza ordered file in random access mode
        FileOpen(4, POFile, OpenMode.Random, , , Len(PORec))
        'Calculate number of records in file
        NumRecs = LOF(4) / Len(PORec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read in each record
            FileGet(4, PORec, RecPos)
            'If order ID in the file matches the order ID of the current order being processed then
            If PORec.OrderID = -Val(OrderID) Then
                'Open pizza file in random access mode
                FileOpen(2, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
                'Set record position for pizza file
                PizzaRecPos = 1
                'Read each record in the file until pizza is found
                While Not EOF(2) And PizzaRec.PizzaID <> PORec.PizzaID
                    FileGet(2, PizzaRec, PizzaRecPos)
                    PizzaRecPos = PizzaRecPos + 1
                End While
                'Close pizza file
                FileClose(2)

                If PizzaRec.PizzaID <> PORec.PizzaID Then
                    'Display "UNKNOWN PIZZA" as the pizza name
                    PizzaName = "[UNKNOWN PIZZA]"
                    'Otherwise
                Else
                    'Read the pizza name
                    PizzaName = PizzaRec.PizzaName
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(PizzaName, 1) = " "
                        PizzaName = Mid(PizzaName, 1, Len(PizzaName) - 1)
                    Loop
                End If

                'Determine size of pizza and read into variable
                If PORec.Size = "7" Then
                    PizzaSize = "Small"
                    'Add Price multiplied by Quantity onto Total
                    Total = Total + (PizzaRec.PriceSmall * PORec.Quantity)
                ElseIf PORec.Size = "9" Then
                    PizzaSize = "Medium"
                    'Add Price multiplied by Quantity onto Total
                    Total = Total + (PizzaRec.PriceMedium * PORec.Quantity)
                ElseIf PORec.Size = "14" Then
                    PizzaSize = "Large"
                    'Add Price multiplied by Quantity onto Total
                    Total = Total + (PizzaRec.PriceLarge * PORec.Quantity)
                End If

                'Read pizza details into list box
                lstItems.Items.Add(PORec.Quantity & "x " & PizzaSize & " " & PizzaName & " - £" & PORec.Subtotal)
            End If
            'Move on to next record in file
        Next

        'Add delivery charge and total into list box
        lstItems.Items.Add("")
        lstItems.Items.Add("DELIVERY CHARGE - £1.50")
        lstItems.Items.Add("TOTAL - " & FormatCurrency(Total))
        'Close file
        FileClose(4)
    End Sub

    Private Sub lstOrders_Leave(sender As Object, e As EventArgs) Handles lstOrders.Leave
        'Deselect items in Orders list box
        lstOrders.ClearSelected()
    End Sub

    Private Sub lstPrevOrders_Leave(sender As Object, e As EventArgs) Handles lstPrevOrders.Leave
        'Deselect items in Previous Orders list box
        lstPrevOrders.ClearSelected()
    End Sub
End Class