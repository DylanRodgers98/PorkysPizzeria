Public Class frmCustEdit
    'Declare global variables
    Dim CustFile As String = Application.StartupPath & "\cust.dat"
    Dim RecPos As Integer
    Dim NumRecs As Integer

    Private Sub frmCustEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declare variables
        Dim Forename As String
        Dim Surname As String
        Dim CustID As String
        Dim NumRecsFound As Integer

        'Clear list box 
        lstCust.Items.Clear()

        'Disable Print and Edit buttons
        btnPrint.Enabled = False
        btnEdit.Enabled = False

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
            'Add 0's to customer ID to make it 4 digits in length
            Do While Len(CustID) < 4
                CustID = "0" & CustID
            Loop

            'If the customer hasn't been deleted
            If CustRec.CustID > 0 Then
                'Add customer details to the list box
                lstCust.Items.Add(CustID & "        " & Forename & " " & Surname)

                'Increase number of records found by 1
                NumRecsFound = NumRecsFound + 1
            End If
        Next
        'Close file
        FileClose(1)

        'If no matching records are found
        If NumRecsFound = 0 Then
            'Input error message into list box
            lstCust.Items.Add("NO CUSTOMERS FOUND")
        End If
    End Sub

    Private Sub lstCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCust.SelectedIndexChanged
        'Declare variables
        Dim SearchID As Integer
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
        'Enable Print and Edit buttons
        If lstCust.Text <> "" Or lstCust.Text <> "NO CUSTOMERS FOUND" Then
            btnPrint.Enabled = True
            btnEdit.Enabled = True
        End If
        'Change the Save button to read Edit
        btnEdit.Text = "Edit"
        btnEdit.Height = 50

        'Find the selected customer ID
        SearchID = Val(Microsoft.VisualBasic.Left(lstCust.Text, 4))

        'Open customers file
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))

        'Read in records from file
        RecPos = 1

        'Get the first record store
        Do While Not EOF(1)
            'Read in record from file
            FileGet(1, CustRec, RecPos)

            'If the record matches selected customer, display their details
            If CustRec.CustID = SearchID Then
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

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'If button reads "Edit" (i.e. form isn't in edit mode)
        If btnEdit.Text = "Edit" Then
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
            btnEdit.Text = "Save"
            btnEdit.Height = 24
            'If button reads "Save" (i.e. form is in edit mode)
        ElseIf btnEdit.Text = "Save" Then
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
                'If telephone number isn't correct length, or isn't a numeric value
            ElseIf Len(txtTel.Text) <> 11 Or Not IsNumeric(txtTel.Text) Then
                'Display error message
                MsgBox("Please ensure your Telephone/Mobile Number is 11 digits long, with no spaces, and contains no letters." & vbNewLine & "EXAMPLE: 07852134695", MessageBoxIcon.Error)
                Exit Sub
            End If

            'Read in fields of the customer record
            With CustRec
                .CustID = Val(txtCustID.Text)
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
            'Write the customers record back to the file
            FilePut(1, CustRec, RecPos)
            'Close CustFile
            FileClose(1)

            'Reload form
            Call frmCustEdit_Load(Me, e)
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
            btnEdit.Text = "Edit"
            btnEdit.Height = 50
            'Clear the Search text box
            txtSearch.ForeColor = Color.DarkGray
            txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
            txtSearch.Text = "Search..."
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Declare variable for Order File and set up the file path
        Dim OrderFile As String = Application.StartupPath & "\orders.dat"
        Dim POFile As String = Application.StartupPath & "\pizzaOrdered.dat"
        Dim PONumRecs As Integer
        Dim PORecPos As Integer

        'DELETE CUSTOMER
        'Make customer's ID a negative number
        CustRec.CustID = -Val(txtCustID.Text)
        'Open CustFile in random access mode
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
        'Write the customers record back to the file
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

                'Set the order's ID to be negative (i.e. marked for deletion)
                OrdersRec.OrderID = -Val(OrdersRec.OrderID)
                'Write record to file
                FilePut(2, OrdersRec, RecPos)
            End If
            'Move on to next record
        Next
        'Close Order file
        FileClose(2)

        'Reload form
        Call frmCustEdit_Load(Me, e)
        'Lock and clear textboxes
        txtCustID.Text = ""
        txtPassword.Enabled = False
        txtPassword.Text = ""
        txtForename.Enabled = False
        txtForename.Text = ""
        txtSurname.Enabled = False
        txtSurname.Text = ""
        txtHouse.Enabled = False
        txtHouse.Text = ""
        txtStreet.Enabled = False
        txtStreet.Text = ""
        txtDistrict.Enabled = False
        txtDistrict.Text = ""
        txtTown.Enabled = False
        txtTown.Text = ""
        txtCounty.Enabled = False
        txtCounty.Text = ""
        txtPostcode.Enabled = False
        txtPostcode.Text = ""
        txtTel.Enabled = False
        txtTel.Text = ""
        'Change the Save button to read Edit
        btnEdit.Text = "Edit"
        btnEdit.Height = 50
        'Clear the Search text box
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
        txtSearch.Text = "Search..."
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Close current form and show admin form
        frmAdmin.Show()
        Me.Close()
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        'Lock and clear textboxes
        txtCustID.Text = ""
        txtPassword.Enabled = False
        txtPassword.Text = ""
        txtForename.Enabled = False
        txtForename.Text = ""
        txtSurname.Enabled = False
        txtSurname.Text = ""
        txtHouse.Enabled = False
        txtHouse.Text = ""
        txtStreet.Enabled = False
        txtStreet.Text = ""
        txtDistrict.Enabled = False
        txtDistrict.Text = ""
        txtTown.Enabled = False
        txtTown.Text = ""
        txtCounty.Enabled = False
        txtCounty.Text = ""
        txtPostcode.Enabled = False
        txtPostcode.Text = ""
        txtTel.Enabled = False
        txtTel.Text = ""
        'Change the Save button to read Edit
        btnEdit.Text = "Edit"
        btnEdit.Height = 50
        'If nothing is input into Search text box (i.e. in it's original state)
        If txtSearch.Text = "Search..." Then
            'Clear Search box and change font
            txtSearch.ForeColor = Color.Black
            txtSearch.Text = ""
            txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Regular)
        End If
    End Sub

    Private Sub txtSearch_Leave(sender As Object, e As EventArgs) Handles txtSearch.Leave
        'If no search term is input
        If txtSearch.Text = "" Then
            'Set Search text box font
            txtSearch.ForeColor = Color.DarkGray
            txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
            'Write "Search..." into text box
            txtSearch.Text = "Search..."
            'Reload form
            Call frmCustEdit_Load(Me, e)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'Declare variables
        Dim SearchValue As String
        Dim Forename As String
        Dim Surname As String
        Dim CustID As String
        Dim NumRecsFound As Integer

        'If nothing is input into the search text box
        If txtSearch.Text = "" Or txtSearch.Text = "Search..." Then
            'Reload the form
            Call frmCustEdit_Load(Me, e)
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
            SearchValue = LCase(txtSearch.Text)

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
                'Add 0's to customer ID to make it 4 digits in length
                Do While Len(CustID) < 4
                    CustID = "0" & CustID
                Loop

                'If ID contains the searched value, or the Forename, Surname, or full name (made lowercase for easy comparison to SearchValue) contains the searched value
                If InStr(CustID, SearchValue) Or InStr(LCase(Forename), SearchValue) Or InStr(LCase(Surname), SearchValue) Or InStr(LCase(Forename) & " " & LCase(Surname), SearchValue) Then
                    'If CustID is greater than 0 (i.e. not marked for deletion)
                    If CustRec.CustID > 0 Then
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        'Set the document to preview
        PrintPreviewDialog1.Document = PrintDocument1
        'Open the print preview dialog
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        'Declare variables
        Dim x As Integer
        Dim y As Integer
        Dim FontHeight As Integer
        'Set up fonts
        Dim TitleFont As New Font("Gill Sans Ultra Bold", 26, FontStyle.Bold)
        Dim BodyFont As New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
        'Read in logo image
        Dim Logo As Image = PictureBox1.Image

        'Print the logo
        e.Graphics.DrawImage(Logo, 600, 20)

        'Set up location to start printing
        FontHeight = BodyFont.GetHeight(e.Graphics)
        x = 50
        y = 50

        'Print the title on the page
        e.Graphics.DrawString("CUSTOMER: " & txtCustID.Text, TitleFont, Brushes.Firebrick, x, y)
        'Move down to print the body of the document
        y = 100

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
    End Sub
End Class