Public Class frmOrderView
    'Declare global variables, and set up file paths
    Dim CustFile As String = Application.StartupPath & "\cust.dat" 'File 1
    Dim PizzaFile As String = Application.StartupPath & "\pizzas.dat" 'File 2
    Dim OrderFile As String = Application.StartupPath & "\orders.dat" 'File 3
    Dim POFile As String = Application.StartupPath & "\pizzaOrdered.dat" 'File 4
    Dim RecPos As Integer
    Dim CustRecPos As Integer
    Dim NumRecs As Integer

    Private Sub frmOrderView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declare variables
        Dim Forename As String
        Dim Surname As String
        Dim OrderID As String
        Dim CustID As String
        Dim NumRecsFound As Integer

        'Set width of form
        Me.Width = 308
        'Set location of title
        lblTitle.Location = New Point(35, 10)

        'Clear Orders list box
        lstOrders.Items.Clear()

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
                If Val(.OrderID) > 0 Then
                    'Display order details in the list box
                    lstOrders.Items.Add(OrderID & "    " & .OrderDate & "    " & CustID & ": " & Forename & " " & Surname & "    " & FormatCurrency(.Total))

                    'Increase number of records found by 1
                    NumRecsFound = NumRecsFound + 1
                End If
            End With
            'Move on to next record in file
        Next

        'Close Orders file
        FileClose(3)

        'If no matching records are found
        If NumRecsFound = 0 Then
            'Input error message into list box
            lstOrders.Items.Add("NO ORDERS FOUND")
        End If
    End Sub

    Private Sub lstOrders_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstOrders.SelectedIndexChanged
        'Declare variables
        Dim PizzaRecPos As Integer
        Dim SearchID As Integer
        Dim CustID As String
        Dim OrderID As String
        Dim PizzaName As String
        Dim PizzaSize As String
        Dim Forename As String
        Dim Surname As String
        Dim House As String
        Dim Street As String
        Dim District As String
        Dim Town As String
        Dim County As String
        Dim Postcode As String
        'Declare variable for Total Cost and set to 1.5 for £1.50 delivery charge
        Dim Total As Decimal = 1.5

        'If an order is selected (i.e. a blank space in the list box hasn't been clicked)
        If lstOrders.Text <> "" Or lstOrders.Text <> "NO ORDERS FOUND" Then
            'Change width of form
            Me.Width = 842
            'Move title
            lblTitle.Location = New Point(310, 10)
        End If

        'Clear Items list box
        lstItems.Items.Clear()

        'Find the selected order ID
        SearchID = Val(Microsoft.VisualBasic.Left(lstOrders.Text, 4))

        'Open pizza ordered file in random access mode
        FileOpen(4, POFile, OpenMode.Random, , , Len(PORec))
        'Calculate number of records in file
        NumRecs = LOF(4) / Len(PORec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read in each record
            FileGet(4, PORec, RecPos)

            'If order ID in the file matches the order ID of the current order being processed then
            If PORec.OrderID = SearchID Then

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

                'If the pizza that has been ordered has been deleted/isn't found in the file
                If PizzaRec.PizzaID <> PORec.PizzaID Then
                    'Display "UNKNOWN PIZZA" as the pizza name
                    PizzaName = "[UNKNOWN PIZZA]"
                    'Otherwise
                Else
                    'Read the Pizza Name from the file 
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

        'Open Orders file in random access mode
        FileOpen(3, OrderFile, OpenMode.Random, , , Len(OrdersRec))
        'Calculate number of records in the file
        NumRecs = LOF(3) / Len(OrdersRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read in each record
            FileGet(3, OrdersRec, RecPos)

            'If the record matches the selected order then
            If OrdersRec.OrderID = SearchID Then
                'Read in Order ID
                OrderID = OrdersRec.OrderID
                'Add 0's to order ID to make it 4 digits in length
                Do While Len(OrderID) < 4
                    OrderID = "0" & OrderID
                Loop
                'Display Order ID and Order Total as group box title
                grpOrder.Text = "Order " & OrderID & ": " & FormatCurrency(Total) & " expected on delivery"

                'Open Customers file in random access mode
                FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
                CustRecPos = 1
                'Read each record in the customers file until the matching customer is found
                While Not EOF(1) And CustRec.CustID <> OrdersRec.CustID
                    FileGet(1, CustRec, CustRecPos)
                    CustRecPos = CustRecPos + 1
                End While
                'Close Customers file
                FileClose(1)

                'If the customer is found then
                If CustRec.CustID = OrdersRec.CustID Then
                    With CustRec
                        'Read in Customer's ID
                        CustID = .CustID
                        'Add 0's to customer's ID to make it 4 digits in length
                        Do While Len(CustID) < 4
                            CustID = "0" & CustID
                        Loop
                        'Read ID into text box
                        txtCustID.Text = CustID

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

                        grpCust.Text = "Customer " & CustID & ": " & Forename & " " & Surname

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
                End If
            End If
            'Move on to next record in file
        Next
        'Close Orders file
        FileClose(3)
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        'Change width of form
        Me.Width = 308
        'If nothing is input into Search text box (i.e. in it's original state)
        If txtSearch.Text = "Search..." Then
            'Clear Search box and change font
            txtSearch.ForeColor = Color.Black
            txtSearch.Text = ""
            txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        'If nothing is input into Search text box
        If txtSearch.Text = "" Then
            'Change font of search box
            txtSearch.ForeColor = Color.DarkGray
            txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
            'Write "Search..." into search box
            txtSearch.Text = "Search..."
            'Reload form
            Call frmOrderView_Load(Me, e)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'Declare variables
        Dim SearchValue As String
        Dim Forename As String
        Dim Surname As String
        Dim NumRecsFound As Integer
        Dim OrderID As String
        Dim CustID As String

        'If nothing is input into the search text box
        If txtSearch.Text = "" Or txtSearch.Text = "Search..." Then
            'Reload the form
            Call frmOrderView_Load(Me, e)
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
                'Add 0's to order ID to make it 4 digits in length
                Do While Len(OrderID) < 4
                    OrderID = "0" & OrderID
                Loop

                'Read in Customer's ID
                CustID = OrdersRec.CustID
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
                SearchValue = LCase(txtSearch.Text)

                'If OrderID, CustID, or the Customer's name (made lowercase for easier comparison) contains the searched value
                If InStr(OrderID, SearchValue) Or InStr(CustID, SearchValue) Or InStr(LCase(Forename), SearchValue) Or InStr(LCase(Surname), SearchValue) Or InStr(LCase(Forename) & " " & LCase(Surname), SearchValue) Then
                    'If the Order hasn't been deleted (i.e. ID has a positive value)
                    If OrdersRec.OrderID > 0 Then
                        'Display order details in the list box
                        lstOrders.Items.Add(OrderID & "    " & OrdersRec.OrderDate & "    " & CustID & ": " & Forename & " " & Surname & "    " & FormatCurrency(OrdersRec.Total))
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

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Close current form and show Admin form
        Me.Close()
        frmAdmin.Show()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Declare variables
        Dim x As Integer
        Dim y As Integer
        Dim FontHeight As Integer
        'Set up fonts
        Dim TitleFont As New Font("Gill Sans Ultra Bold", 26, FontStyle.Bold)
        Dim SubtitleFont As New Font("Gill Sans Ultra Bold", 14, FontStyle.Bold)
        Dim BodyFont As New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
        'Read in logo image
        Dim Logo As Image = PictureBox1.Image
        'Read in Order list box as image
        Dim Order As Image = New Bitmap(lstItems.Width, lstItems.Height)
        lstItems.DrawToBitmap(Order, lstItems.ClientRectangle)

        'Print the logo
        e.Graphics.DrawImage(Logo, 600, 20)

        'Set up location to start printing
        FontHeight = BodyFont.GetHeight(e.Graphics)
        x = 50
        y = 50

        'Print the title on the page
        e.Graphics.DrawString("RECEIPT: " & Microsoft.VisualBasic.Left(grpOrder.Text, 10), TitleFont, Brushes.Firebrick, x, y)
        'Move down to print the body of the document
        y = 100

        'Print subtitle
        e.Graphics.DrawString("CUSTOMER DETAILS", SubtitleFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + 1.5 * FontHeight

        'Print the customer ID number 
        e.Graphics.DrawString("Name: " & txtForename.Text & " " & txtSurname.Text & " (ID: " & txtCustID.Text & ")", BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight

        'Print the customer's address
        e.Graphics.DrawString("Address: " & txtHouse.Text & " " & txtStreet.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
        e.Graphics.DrawString("               " & txtDistrict.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
        e.Graphics.DrawString("               " & txtTown.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
        e.Graphics.DrawString("               " & txtCounty.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
        e.Graphics.DrawString("               " & txtPostcode.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
        'Print the customer's telephone number
        e.Graphics.DrawString("Telephone: " & txtTel.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + 2 * FontHeight

        'Print subtitle
        e.Graphics.DrawString("ORDER DETAILS", SubtitleFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + 1.5 * FontHeight

        'Print the order ID
        e.Graphics.DrawString("Order ID: " & Microsoft.VisualBasic.Left(lstOrders.Text, 4), BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
        'Print the order date
        e.Graphics.DrawString("Date: " & Mid(lstOrders.Text, 9, 10), BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight

        'Print the Order list box image
        e.Graphics.DrawImage(Order, x, y)
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        'Set the document to preview
        PrintPreviewDialog1.Document = PrintDocument1
        'Open the print preview dialog
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Open CustFile in random access mode
        FileOpen(3, OrderFile, OpenMode.Random, , , Len(OrdersRec))
        'Calculate number of records in the file
        NumRecs = LOF(3) / Len(OrdersRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(3, OrdersRec, RecPos)

            'If ID of record in file matches ID of Order selected
            If OrdersRec.OrderID = Val(Microsoft.VisualBasic.Mid(grpOrder.Text, 7, 4)) Then
                'Make ID negative (i.e. marked for deletion)
                OrdersRec.OrderID = -Val(Microsoft.VisualBasic.Mid(grpOrder.Text, 7, 4))
            End If

            'Write the record back to the file
            FilePut(3, OrdersRec, RecPos)
            'Move on to next record in file
        Next

        'Open Pizza Ordered File in random access mode
        FileOpen(4, POFile, OpenMode.Random, , , Len(PORec))
        'Calculate number of records in the file
        NumRecs = LOF(4) / Len(PORec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(4, PORec, RecPos)

            'Make ID negative (i.e. marked for deletion)
            If PORec.OrderID = Val(Microsoft.VisualBasic.Mid(grpOrder.Text, 7, 4)) Then
                PORec.OrderID = -Val(Microsoft.VisualBasic.Mid(grpOrder.Text, 7, 4))
            End If

            'Write the record back to the file
            FilePut(4, PORec, RecPos)
            'Move on to next record in file
        Next

        'Close files
        FileClose(3)
        FileClose(4)

        'Reload form
        Call frmOrderView_Load(Me, e)
    End Sub
End Class