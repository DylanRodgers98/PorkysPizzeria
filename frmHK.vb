Public Class frmHK
    'Declare global variables, and set up file paths
    Dim CustFile As String = Application.StartupPath & "\cust.dat" 'File 1
    Dim PizzaFile As String = Application.StartupPath & "\pizzas.dat" 'File 2
    Dim OrderFile As String = Application.StartupPath & "\orders.dat" 'File 3
    Dim POFile As String = Application.StartupPath & "\pizzaOrdered.dat" 'File 4
    Dim RecPos As Integer
    Dim NumRecs As Integer

    Private Sub tabCust_Enter(sender As Object, e As EventArgs) Handles tabCust.Enter
        'Declare variables 
        Dim Forename As String
        Dim Surname As String
        Dim CustID As String

        'Clear list box 
        lstCust.Items.Clear()

        'Disable Print and Edit buttons
        btnRestoreCust.Enabled = False

        'Open the customers file in random access mode
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

            'Read the customer's ID
            CustID = CustRec.CustID
            'If Customer ID is negative
            If Microsoft.VisualBasic.Left(CustID, 1) = "-" Then
                'Replace "-" symbol with a "0"
                Mid(CustID, 1, 1) = "0"
            End If
            'Add 0's to customer ID to make it 4 digits in length
            Do While Len(CustID) < 4
                CustID = "0" & CustID
            Loop

            'If the customer hasn't been deleted
            If CustRec.CustID < 0 Then
                'Add customer details to the list box
                lstCust.Items.Add(CustID & "        " & Forename & " " & Surname)
            End If
        Next
        'Close file
        FileClose(1)

        'If no matching records are found
        If lstCust.Items.Count = 0 Then
            'Input error message into list box
            lstCust.Items.Add("NO CUSTOMERS FOUND")
        End If
    End Sub

    Private Sub tabPizzas_Enter(sender As Object, e As EventArgs) Handles tabPizzas.Enter
        'Declare variables
        Dim PizzaName As String
        Dim PizzaID As Integer

        'Clear list box and add title
        lstPizza.Items.Clear()

        'Disable Edit and Print buttons
        btnRestorePizza.Enabled = False

        'Open the customers file in random access mode
        FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
        'Calculate the number of records in the file
        NumRecs = LOF(1) / Len(PizzaRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(1, PizzaRec, RecPos)

            'Read the pizza name
            PizzaName = PizzaRec.PizzaName
            'Remove blank spaces from field
            Do While Microsoft.VisualBasic.Right(PizzaName, 1) = " "
                PizzaName = Mid(PizzaName, 1, Len(PizzaName) - 1)
            Loop

            'Read the pizza ID
            PizzaID = PizzaRec.PizzaID
            'If Pizza ID is negative
            If Microsoft.VisualBasic.Left(PizzaID, 1) = "-" Then
                'Replace "-" symbol with a blank space
                Mid(PizzaID, 1, 1) = " "
            End If

            'If the pizza hasn't been deleted, add customer details to the list box
            If PizzaRec.PizzaID < 0 Then
                lstPizza.Items.Add(PizzaID & "        " & PizzaName)
            End If
            'Move on to next record in file
        Next

        'Close file
        FileClose(1)

        'If no matching records are found
        If lstPizza.Items.Count = 0 Then
            'Input error message into list box
            lstPizza.Items.Add("NO PIZZAS FOUND")
        End If
    End Sub

    Private Sub tabOrders_Enter(sender As Object, e As EventArgs) Handles tabCust.Enter
        'Declare variables
        Dim Forename As String
        Dim Surname As String
        Dim OrderID As String
        Dim CustID As String
        Dim CustRecPos As Integer

        'Clear Orders list box
        lstOrders.Items.Clear()

        'Disable Edit and Print buttons
        btnRestoreOrder.Enabled = False

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
            custRecPos = 1
            'Read each record in the file until the customer is found
            While Not EOF(1) And CustRec.CustID <> OrdersRec.CustID
                FileGet(1, CustRec, custRecPos)
                custRecPos = custRecPos + 1
            End While
            'Close Customers file
            FileClose(1)

            'If the customer is found then
            If CustRec.CustID = OrdersRec.CustID Then
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

                'Read in customer's ID
                CustID = OrdersRec.CustID
                'Add 0's to customer's ID to make it 4 digits in length
                Do While Len(CustID) < 4
                    CustID = "0" & CustID
                Loop
            End If

            With OrdersRec
                'If OrderID is greater than 0 (i.e. not marked for deletion)
                If Val(.OrderID) < 0 Then
                    'Display order details in the list box
                    lstOrders.Items.Add(OrderID & "   " & .OrderDate & "   " & CustID & ": " & Forename & " " & Surname & "   " & FormatCurrency(.Total))
                End If
            End With
            'Move on to next record in file
        Next

        'Close Orders file
        FileClose(3)

        'If no matching records are found
        If lstOrders.Items.Count = 0 Then
            'Input error message into list box
            lstOrders.Items.Add("NO ORDERS FOUND")
        End If
    End Sub

    Private Sub lstCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCust.SelectedIndexChanged
        'Enable Restore Customer button
        If lstCust.Text <> "NO CUSTOMERS FOUND" Or lstCust.Text <> "" Then
            btnRestoreCust.Enabled = True
        End If
    End Sub

    Private Sub lstPizza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPizza.SelectedIndexChanged
        'Enable Restore Pizza button
        If lstPizza.Text <> "NO PIZZAS FOUND" Or lstPizza.Text <> "" Then
            btnRestorePizza.Enabled = True
        End If
    End Sub

    Private Sub lstOrders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrders.SelectedIndexChanged
        'Enable Restore Order button
        If lstOrders.Text <> "NO ORDERS FOUND" Or lstOrders.Text <> "" Then
            btnRestoreOrder.Enabled = True
        End If
    End Sub

    Private Sub btnRestoreCust_Click(sender As Object, e As EventArgs) Handles btnRestoreCust.Click
        'Declare variable for a Yes/No MsgBox
        Dim Box As MsgBoxResult = MsgBox("Are you sure you want to restore this customer?", MsgBoxStyle.YesNo)
        'If yes is selected on the MsgBox, restore the customer
        If Box = MsgBoxResult.Yes Then
            'Open CustFile in random access mode
            FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
            'Calculate number of records in file
            NumRecs = LOF(1) / Len(CustRec)
            'For each record in the file
            For RecPos = 1 To NumRecs
                'Read the record from file
                FileGet(1, CustRec, RecPos)

                'If ID of record in file matches negative value (i.e. marked for deletion) of ID of the customer selected
                If CustRec.CustID = -Val(lstCust.Text) Then
                    'Make ID a positive number (i.e. not marked for deletion)
                    CustRec.CustID = Val(lstCust.Text)
                End If

                'Write the customers record back to the file
                FilePut(1, CustRec, RecPos)
            Next
            'Close CustFile
            FileClose(1)

            'Reload tab
            Call tabCust_Enter(Me, e)
        End If
    End Sub

    Private Sub btnRestorePizza_Click(sender As Object, e As EventArgs) Handles btnRestorePizza.Click
        'Declare variable for a Yes/No MsgBox
        Dim Box As MsgBoxResult = MsgBox("Are you sure you want to restore this pizza?", MsgBoxStyle.YesNo)
        'If yes is selected on the MsgBox, restore the pizza
        If Box = MsgBoxResult.Yes Then
            'Open CustFile in random access mode
            FileOpen(2, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
            'Calculate number of records in file
            NumRecs = LOF(2) / Len(PizzaRec)
            'For each record in the file
            For RecPos = 1 To NumRecs
                'Read the record from file
                FileGet(2, PizzaRec, RecPos)

                'If ID of record in file matches negative value (i.e. marked for deletion) of ID of the pizza selected
                If PizzaRec.PizzaID = -Val(lstPizza.Text) Then
                    'Make ID a positive number (i.e. not marked for deletion)
                    PizzaRec.PizzaID = Val(lstPizza.Text)
                End If

                'Write the customers record back to the file
                FilePut(2, PizzaRec, RecPos)
            Next
            'Close CustFile
            FileClose(2)

            'Reload tab
            Call tabPizzas_Enter(Me, e)
        End If
    End Sub

    Private Sub btnRestoreOrder_Click(sender As Object, e As EventArgs) Handles btnRestoreOrder.Click
        'Declare variable for a Yes/No MsgBox
        Dim Box As MsgBoxResult = MsgBox("Are you sure you want to restore this order?", MsgBoxStyle.YesNo)
        'If yes is selected on the MsgBox, restore the order
        If Box = MsgBoxResult.Yes Then
            'Open CustFile in random access mode
            FileOpen(3, OrderFile, OpenMode.Random, , , Len(OrdersRec))
            'Calculate number of records in the file
            NumRecs = LOF(3) / Len(OrdersRec)
            'For each record in the file
            For RecPos = 1 To NumRecs
                'Read the record from the file
                FileGet(3, OrdersRec, RecPos)

                'If ID of record in file matches negative value (i.e. marked for deletion) of ID of the order selected
                If OrdersRec.OrderID = -Val(Microsoft.VisualBasic.Left(lstOrders.Text, 4)) Then
                    'Make ID positive (i.e. not marked for deletion)
                    OrdersRec.OrderID = Val(Microsoft.VisualBasic.Left(lstOrders.Text, 4))
                End If

                'Write the record back to the file
                FilePut(3, OrdersRec, RecPos)
                'Move on to next record in file
            Next
            'Close CustFile
            FileClose(3)

            'Open Pizza Ordered File in random access mode
            FileOpen(4, POFile, OpenMode.Random, , , Len(PORec))
            'Calculate number of records in the file
            NumRecs = LOF(4) / Len(PORec)
            'For each record in the file
            For RecPos = 1 To NumRecs
                'Read the record from the file
                FileGet(4, PORec, RecPos)

                'If ID of record in file matches negative value (i.e. marked for deletion) of ID of the Order selected
                If PORec.OrderID = -Val(Microsoft.VisualBasic.Left(lstOrders.Text, 4)) Then
                    'Make ID positive (i.e. not marked for deletion)
                    PORec.OrderID = Val(Microsoft.VisualBasic.Left(lstOrders.Text, 4))
                End If

                'Write the record back to the file
                FilePut(4, PORec, RecPos)
                'Move on to next record in file
            Next
            'Close POFile
            FileClose(4)

            'Reload tab
            Call tabOrders_Enter(Me, e)
        End If
    End Sub

    Private Sub btnBack1_Click(sender As Object, e As EventArgs) Handles btnBack1.Click
        'Close current form and show Admin form
        frmAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnBack2_Click(sender As Object, e As EventArgs) Handles btnBack2.Click
        'Close current form and show Admin form
        frmAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnBack3_Click(sender As Object, e As EventArgs) Handles btnBack3.Click
        'Close current form and show Admin form
        frmAdmin.Show()
        Me.Close()
    End Sub

    Private Sub btnDelCust_Click(sender As Object, e As EventArgs) Handles btnDelCust.Click
        'Declare variables
        Dim OldCustFile As String = Application.StartupPath & "\oldCust.dat"
        Dim NewCustFile As String = Application.StartupPath & "\newCust.dat" 'File 5
        Dim NewNumRecs As Integer
        Dim NewRecPos As Integer
        'Declare variable for a Yes/No MsgBox
        Dim Box As MsgBoxResult = MsgBox("Are you sure you want to permanently delete all customers?", MsgBoxStyle.YesNo)
        'If yes is selected on the MsgBox, delete all customers
        If Box = MsgBoxResult.Yes Then
            'If the customers' file exists
            If Dir(CustFile) <> "" Then
                'Open the customers' file
                FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
                'Calculate number of records in file
                NumRecs = LOF(1) / Len(CustRec)
                'For each record in the file
                For RecPos = 1 To NumRecs
                    'Read in the record from file
                    FileGet(1, CustRec, RecPos)
                    'If customer is not deleted
                    If Val(CustRec.CustID) > 0 Then
                        'Open New Customers' file
                        FileOpen(5, NewCustFile, OpenMode.Random, , , Len(CustRec))
                        'Calculate number of records in new file 
                        NewNumRecs = LOF(5) / Len(CustRec)
                        'Set record position to next available record in the file
                        NewRecPos = NewNumRecs + 1
                        'Write record to file
                        FilePut(5, CustRec, NewRecPos)
                        'Close new file
                        FileClose(5)
                    Else
                        'Open New Customers' file
                        FileOpen(5, NewCustFile, OpenMode.Random, , , Len(CustRec))
                        'Close new file
                        FileClose(5)
                    End If
                    'Read in next record
                Next
                'Close the original file
                FileClose(1)

                'If old customers' file exists
                If Dir(OldCustFile) <> "" Then
                    'Delete the file
                    Kill(OldCustFile)
                End If
                'Rename the customers' file to become the archived file
                Rename(CustFile, OldCustFile)
                'If the current customer's file exists
                If Dir(CustFile) <> "" Then
                    'Delete the file
                    Kill(CustFile)
                End If
                'Rename the new customers' file to become the original file (using Try statement to ignore any FileNotFound error messages)
                Rename(NewCustFile, CustFile)
            End If

            'Reload tab
            Call tabCust_Enter(Me, e)
        End If
    End Sub

    Private Sub btnDelPizza_Click(sender As Object, e As EventArgs) Handles btnDelPizza.Click
        'Declare variables
        Dim OldPizzaFile As String = Application.StartupPath & "\oldPizzas.dat"
        Dim NewPizzaFile As String = Application.StartupPath & "\newPizzas.dat" 'File 6
        Dim NewNumRecs As Integer
        Dim NewRecPos As Integer
        'Declare variable for a Yes/No MsgBox
        Dim Box As MsgBoxResult = MsgBox("Are you sure you want to permanently delete all pizzas?", MsgBoxStyle.YesNo)
        'If yes is selected on the MsgBox, delete all pizzas
        If Box = MsgBoxResult.Yes Then
            'If the pizza file exists
            If Dir(PizzaFile) <> "" Then
                'Open the pizza file
                FileOpen(2, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
                'Calculate number of records in file
                NumRecs = LOF(2) / Len(PizzaRec)
                'For each record in the file
                For RecPos = 1 To NumRecs
                    'Read in the record from file
                    FileGet(2, PizzaRec, RecPos)
                    'If customer is not deleted
                    If Val(PizzaRec.PizzaID) > 0 Then
                        'Open New Pizza file
                        FileOpen(6, NewPizzaFile, OpenMode.Random, , , Len(PizzaRec))
                        'Calculate number of records in new file 
                        NewNumRecs = LOF(6) / Len(PizzaRec)
                        'Set record position to next available record in the file
                        NewRecPos = NewNumRecs + 1
                        'Write record to file
                        FilePut(6, PizzaRec, NewRecPos)
                        'Close new file
                        FileClose(6)
                    Else
                        'Open New Pizza file
                        FileOpen(6, NewPizzaFile, OpenMode.Random, , , Len(PizzaRec))
                        'Close new file
                        FileClose(6)
                    End If
                    'Read in next record
                Next
                'Close the original file
                FileClose(2)

                'If old pizza file exists
                If Dir(OldPizzaFile) <> "" Then
                    'Delete the file
                    Kill(OldPizzaFile)
                End If
                'Rename the pizza file to become the archived file
                Rename(PizzaFile, OldPizzaFile)
                'If the current pizza file exists
                If Dir(PizzaFile) <> "" Then
                    'Delete the file
                    Kill(PizzaFile)
                End If
                'Rename the new pizza file to become the original file (using Try statement to ignore any FileNotFound error messages)
                Rename(NewPizzaFile, PizzaFile)
            End If

            'Reload tab
            Call tabPizzas_Enter(Me, e)
        End If
    End Sub

    Private Sub btnDelOrder_Click(sender As Object, e As EventArgs) Handles btnDelOrder.Click
        'Declare variables
        Dim OldOrderFile As String = Application.StartupPath & "\oldOrders.dat"
        Dim NewOrderFile As String = Application.StartupPath & "\newOrders.dat" 'File 7
        Dim OldPOFile As String = Application.StartupPath & "\oldPizzaOrdered.dat"
        Dim NewPOFile As String = Application.StartupPath & "\newPizzaOrdered.dat" 'File 8
        Dim NewNumRecs As Integer
        Dim NewRecPos As Integer
        'Declare variable for a Yes/No MsgBox
        Dim Box As MsgBoxResult = MsgBox("Are you sure you want to permanently delete all orders?", MsgBoxStyle.YesNo)
        'If yes is selected on the MsgBox, delete all orders
        If Box = MsgBoxResult.Yes Then
            'If the orders file exists
            If Dir(OrderFile) <> "" Then
                'Open the orders' file
                FileOpen(3, OrderFile, OpenMode.Random, , , Len(OrdersRec))
                'Calculate number of records in file
                NumRecs = LOF(3) / Len(OrdersRec)
                'For each record in the file
                For RecPos = 1 To NumRecs
                    'Read in the record from file
                    FileGet(3, OrdersRec, RecPos)
                    'If order is not deleted
                    If Val(OrdersRec.OrderID) > 0 Then
                        'Open New Orders file
                        FileOpen(7, NewOrderFile, OpenMode.Random, , , Len(OrdersRec))
                        'Calculate number of records in new file 
                        NewNumRecs = LOF(7) / Len(OrdersRec)
                        'Set record position to next available record in the file
                        NewRecPos = NewNumRecs + 1
                        'Write record to file
                        FilePut(7, OrdersRec, NewRecPos)
                        'Close new file
                        FileClose(7)
                    Else
                        'Open New Orders file
                        FileOpen(7, NewOrderFile, OpenMode.Random, , , Len(OrdersRec))
                        'Close new file
                        FileClose(7)
                    End If
                    'Read in next record
                Next
                'Close the original file
                FileClose(3)

                'If old orders file exists
                If Dir(OldOrderFile) <> "" Then
                    'Delete the file
                    Kill(OldOrderFile)
                End If
                'Rename the orders file to become the archived file
                Rename(OrderFile, OldOrderFile)
                'If the current orders file exists
                If Dir(OrderFile) <> "" Then
                    'Delete the file
                    Kill(OrderFile)
                End If
                'Rename the new orders file to become the original file (using Try statement to ignore any FileNotFound error messages)
                Rename(NewOrderFile, OrderFile)
            End If

            'If the Pizza Ordered file exists
            If Dir(POFile) <> "" Then
                'Open the Pizza Ordered file
                FileOpen(4, POFile, OpenMode.Random, , , Len(PORec))
                'Calculate number of records in file
                NumRecs = LOF(4) / Len(PORec)
                'For each record in the file
                For RecPos = 1 To NumRecs
                    'Read in the record from file
                    FileGet(4, PORec, RecPos)
                    'If order is not deleted
                    If Val(PORec.OrderID) > 0 Then
                        'Open New Pizza Ordered file
                        FileOpen(8, NewPOFile, OpenMode.Random, , , Len(PORec))
                        'Calculate number of records in new file 
                        NewNumRecs = LOF(8) / Len(PORec)
                        'Set record position to next available record in the file
                        NewRecPos = NewNumRecs + 1
                        'Write record to file
                        FilePut(8, PORec, NewRecPos)
                        'Close new file
                        FileClose(8)
                    Else
                        'Open New Pizza Ordered file
                        FileOpen(8, NewPOFile, OpenMode.Random, , , Len(PORec))
                        'Close new file
                        FileClose(8)
                    End If
                    'Read in next record
                Next
                'Close the original file
                FileClose(4)

                'If old Pizza Ordered file exists
                If Dir(OldPOFile) <> "" Then
                    'Delete the file
                    Kill(OldPOFile)
                End If
                'Rename the Pizza Ordered file to become the archived file
                Rename(POFile, OldPOFile)
                'If the current Pizza Ordered file exists
                If Dir(POFile) <> "" Then
                    'Delete the file
                    Kill(POFile)
                End If
                'Rename the new Pizza Ordered file to become the original file (using Try statement to ignore any FileNotFound error messages)
                Rename(NewPOFile, POFile)
            End If

            'Reload tab
            Call tabOrders_Enter(Me, e)
        End If
    End Sub

    Private Sub txtCustSearch_Enter(sender As Object, e As EventArgs) Handles txtCustSearch.Enter
        'If nothing is input into Search text box (i.e. reads "Search...")
        If txtCustSearch.Text = "Search Deleted Customers..." Then
            'Clear Search box and change font
            txtCustSearch.ForeColor = Color.Black
            txtCustSearch.Text = ""
            txtCustSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
        End If
    End Sub

    Private Sub txtCustSearch_Leave(sender As Object, e As EventArgs) Handles txtCustSearch.Leave
        'If nothing is input into Search text box (i.e. reads "Search...")
        If txtCustSearch.Text = "" Then
            'Write "Search..." and change font
            txtCustSearch.ForeColor = Color.DarkGray
            txtCustSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
            txtCustSearch.Text = "Search Deleted Customers..."
            'Reload the form
            Call tabCust_Enter(Me, e)
        End If
    End Sub

    Private Sub txtCustSearch_TextChanged(sender As Object, e As EventArgs) Handles txtCustSearch.TextChanged
        'Declare variables
        Dim SearchValue As String
        Dim Forename As String
        Dim Surname As String
        Dim CustID As String
        Dim NumRecsFound As Integer

        'If nothing is input into the search text box
        If txtCustSearch.Text = "" Or txtCustSearch.Text = "Search Deleted Customer..." Then
            'Reload the form
            Call tabCust_Enter(Me, e)
        Else
            'Clear list box and add title
            lstCust.Items.Clear()

            'Open customers file in random access mode
            FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))

            'Calculate the number of records in the file
            NumRecs = LOF(1) / Len(CustRec)
            'Set RecPos to 1
            RecPos = 1

            'Read the searched name, and make it lower case
            SearchValue = LCase(txtCustSearch.Text)

            'Get the first record stored
            Do While Not EOF(1)
                'Read record from file
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

                'Read the customer's ID
                CustID = CustRec.CustID
                'If Customer ID is negative
                If Microsoft.VisualBasic.Left(CustID, 1) = "-" Then
                    'Replace "-" symbol with a "0"
                    Mid(CustID, 1, 1) = "0"
                End If
                'Add 0's to customer ID to make it 4 digits in length
                Do While Len(CustID) < 4
                    CustID = "0" & CustID
                Loop

                'If ID contains the searched value, or the Forename, Surname, or full name (made lowercase for easy comparison to SearchValue) contains the searched value
                If InStr(CustID, SearchValue) Or InStr(LCase(Forename), SearchValue) Or InStr(LCase(Surname), SearchValue) Or InStr(LCase(Forename) & " " & LCase(Surname), SearchValue) Then
                    'If CustID is less than 0 (i.e. marked for deletion)
                    If CustRec.CustID < 0 Then
                        'Add customer details to the list box
                        lstCust.Items.Add(CustID & "        " & Forename & " " & Surname)
                        'Increase number of records found by 1
                        NumRecsFound = NumRecsFound + 1
                    End If
                End If

                'Retrieve the next record
                RecPos = RecPos + 1
            Loop

            'Close the customers file
            FileClose(1)

            'If no matching records are found
            If NumRecsFound = 0 Then
                'Input error message into list box
                lstCust.Items.Add("NO MATCHING CUSTOMERS FOUND")
            End If
        End If
    End Sub

    Private Sub txtPizzaSearch_Enter(sender As Object, e As EventArgs) Handles txtPizzaSearch.Enter
        'If nothing is input into Search text box (i.e. reads "Search...")
        If txtPizzaSearch.Text = "Search Deleted Pizzas..." Then
            'Clear Search box and change font
            txtPizzaSearch.ForeColor = Color.Black
            txtPizzaSearch.Text = ""
            txtPizzaSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
        End If
    End Sub

    Private Sub txtPizzaSearch_Leave(sender As Object, e As EventArgs) Handles txtPizzaSearch.Leave
        'If nothing is input into Search text box (i.e. reads "Search...")
        If txtPizzaSearch.Text = "" Then
            'Write "Search..." and change font
            txtPizzaSearch.ForeColor = Color.DarkGray
            txtPizzaSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
            txtPizzaSearch.Text = "Search Deleted Pizzas..."
            'Reload the form
            Call tabPizzas_Enter(Me, e)
        End If
    End Sub

    Private Sub txtPizzaSearch_TextChanged(sender As Object, e As EventArgs) Handles txtPizzaSearch.TextChanged
        'Declare variables
        Dim SearchName As String
        Dim Pizza As String
        Dim PizzaID As Integer
        Dim NumPizzasFound As Integer

        'If nothing is input into the search text box
        If txtPizzaSearch.Text = "" Or txtPizzaSearch.Text = "Search Deleted Pizzas..." Then
            'Reload the form
            Call tabPizzas_Enter(Me, e)
        Else
            'Clear list box and add title
            lstPizza.Items.Clear()

            'Open customers file in random access mode
            FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))

            'Calculate the number of records in the file
            NumRecs = LOF(1) / Len(PizzaRec)

            'Read the searched name, and make it lower case
            SearchName = LCase(txtPizzaSearch.Text)

            'Get the first record stored
            RecPos = 1
            Do While Not EOF(1)
                'Read the record from the file
                FileGet(1, PizzaRec, RecPos)

                'Read the pizza ID
                PizzaID = PizzaRec.PizzaID
                'If Pizza ID is negative
                If Microsoft.VisualBasic.Left(PizzaID, 1) = "-" Then
                    'Replace "-" symbol with a blank space
                    Mid(PizzaID, 1, 1) = " "
                End If

                'Read the pizza name
                Pizza = PizzaRec.PizzaName
                'Remove blank spaces from field
                Do While Microsoft.VisualBasic.Right(Pizza, 1) = " "
                    Pizza = Mid(Pizza, 1, Len(Pizza) - 1)
                Loop

                'If ID (converted to string for easy comparison to SearchName) matches the searched name, or the pizza name matches the searched name
                If InStr(PizzaRec.PizzaID, SearchName) Or InStr(LCase(Pizza), SearchName) Then
                    'If pizza ID is less than 0 (i.e. marked for deletion)
                    If PizzaRec.PizzaID < 0 Then
                        'Add pizza details to list box
                        lstPizza.Items.Add(PizzaID & "        " & Pizza)
                        'Increase number of records found by 1
                        NumPizzasFound = NumPizzasFound + 1
                    End If
                End If

                'Retrieve the next record
                RecPos = RecPos + 1
                'Move on to next record
            Loop

            'Close the customers file
            FileClose(1)

            'If no matching records are found
            If NumPizzasFound = 0 Then
                'Input error message into list box
                lstPizza.Items.Add("NO MATCHING PIZZAS FOUND")
            End If
        End If
    End Sub

    Private Sub txtOrderSearch_Enter(sender As Object, e As EventArgs) Handles txtOrderSearch.Enter
        'If nothing is input into Search text box (i.e. reads "Search...")
        If txtOrderSearch.Text = "Search Deleted Orders..." Then
            'Clear Search box and change font
            txtOrderSearch.ForeColor = Color.Black
            txtOrderSearch.Text = ""
            txtOrderSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
        End If
    End Sub

    Private Sub txtOrderSearch_Leave(sender As Object, e As EventArgs) Handles txtOrderSearch.Leave
        'If nothing is input into Search text box (i.e. reads "Search...")
        If txtOrderSearch.Text = "" Then
            'Write "Search..." and change font
            txtOrderSearch.ForeColor = Color.DarkGray
            txtOrderSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
            txtOrderSearch.Text = "Search Deleted Orders..."
            'Reload the form
            Call tabOrders_Enter(Me, e)
        End If
    End Sub

    Private Sub txtOrderSearch_TextChanged(sender As Object, e As EventArgs) Handles txtOrderSearch.TextChanged
        'Declare variables
        Dim SearchValue As String
        Dim Forename As String
        Dim Surname As String
        Dim NumRecsFound As Integer
        Dim OrderID As String
        Dim CustID As String
        Dim CustRecPos As Integer

        'If nothing is input into the search text box
        If txtOrderSearch.Text = "" Or txtOrderSearch.Text = "Search Deleted Orders..." Then
            'Reload the form
            Call tabOrders_Enter(Me, e)
            'Otherwise
        Else
            'Clear list box and add title
            lstOrders.Items.Clear()

            'Open customers file in random access mode
            FileOpen(3, OrderFile, OpenMode.Random, , , Len(OrdersRec))
            'Calculate the number of records in the file
            NumRecs = LOF(3) / Len(OrdersRec)
            'Get the first record stored
            RecPos = 1
            Do While Not EOF(3)
                'Read the record from the file
                FileGet(3, OrdersRec, RecPos)

                'Read in Order ID
                OrderID = OrdersRec.OrderID
                'If Customer ID is negative
                If Microsoft.VisualBasic.Left(OrderID, 1) = "-" Then
                    'Replace "-" symbol with a "0"
                    Mid(OrderID, 1, 1) = "0"
                End If
                'Add 0's to order ID to make it 4 digits in length
                Do While Len(OrderID) < 4
                    OrderID = "0" & OrderID
                Loop

                'Read in Customer's ID
                CustID = OrdersRec.CustID
                'If Customer ID is negative
                If Microsoft.VisualBasic.Left(CustID, 1) = "-" Then
                    'Replace "-" symbol with a "0"
                    Mid(CustID, 1, 1) = "0"
                End If
                'Add 0's to order ID to make it 4 digits in length
                Do While Len(CustID) < 4
                    CustID = "0" & CustID
                Loop

                'Open Customers file in random access mode
                FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
                CustRecPos = 1
                'Read each record in the file until the customer is found
                While Not EOF(1) And CustRec.CustID <> OrdersRec.CustID
                    FileGet(1, CustRec, CustRecPos)
                    CustRecPos = CustRecPos + 1
                End While
                'Close Customers file
                FileClose(1)
                'If the customer is found then
                If CustRec.CustID = OrdersRec.CustID Then
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
                End If

                'Read text from search box into variable and make it lower case (for easier comparison)
                SearchValue = LCase(txtOrderSearch.Text)

                'If OrderID, CustID, or the Customer's name (made lowercase for easier comparison) contains the searched value
                If InStr(OrderID, SearchValue) Or InStr(CustID, SearchValue) Or InStr(LCase(Forename), SearchValue) Or InStr(LCase(Surname), SearchValue) Or InStr(LCase(Forename) & " " & LCase(Surname), SearchValue) Then
                    'If the Order has been deleted (i.e. ID has a negative value)
                    If OrdersRec.OrderID < 0 Then
                        'Display order details in the list box
                        lstOrders.Items.Add(OrderID & "   " & OrdersRec.OrderDate & "   " & CustID & ": " & Forename & " " & Surname & "   " & FormatCurrency(OrdersRec.Total))
                        'Increase number of records found by 1
                        NumRecsFound = NumRecsFound + 1
                    End If
                End If

                'Retrieve the next record
                RecPos = RecPos + 1
            Loop
            'Close Orders file
            FileClose(3)

            'If no matching records are found
            If NumRecsFound = 0 Then
                'Input error message into list box
                lstOrders.Items.Add("NO MATCHING ORDERS FOUND")
            End If
        End If
    End Sub
End Class