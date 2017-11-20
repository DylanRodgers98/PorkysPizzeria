Public Class frmPizzaEdit
    'Declare global variables and set up path to the pizzas file
    Dim PizzaFile As String = Application.StartupPath & "\pizzas.dat"
    Dim RecPos As Integer
    Dim NumRecs As Integer

    Private Sub frmPizzaEdit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declare variables
        Dim PizzaName As String
        Dim NumRecsFound As Integer

        'Clear list box and add title
        lstPizza.Items.Clear()

        'Disable Edit and Print buttons
        btnEdit.Enabled = False
        btnPrint.Enabled = False

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

            'If the pizza hasn't been deleted, add pizza details to the list box
            If PizzaRec.PizzaID > 0 Then
                lstPizza.Items.Add(PizzaRec.PizzaID & "        " & PizzaName)

                'Increase number of records found by 1
                NumRecsFound = NumRecsFound + 1
            End If
            'Move on to next record in file
        Next

        'Close file
        FileClose(1)

        'If no matching records are found
        If NumRecsFound = 0 Then
            'Input error message into list box
            lstPizza.Items.Add("NO PIZZAS FOUND")
        End If
    End Sub

    Private Sub lstPizza_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPizza.SelectedIndexChanged
        'Declare variables
        Dim SearchID As Integer
        Dim PizzaName As String
        Dim Desc As String

        'Lock textboxes for editing
        txtPizzaName.Enabled = False
        txtDesc.Enabled = False
        txtSml.Enabled = False
        txtMed.Enabled = False
        txtLrg.Enabled = False

        'Enable Print and Edit buttons
        If lstPizza.Text <> "" Or lstPizza.Text <> "NO PIZZAS FOUND" Then
            btnEdit.Enabled = True
            btnPrint.Enabled = True
        End If

        'Change the Save button to read Edit
        btnEdit.Text = "Edit"
        btnEdit.Height = 50

        'Find the selected customer ID
        SearchID = Val(Microsoft.VisualBasic.Left(lstPizza.Text, 3))

        'Open customers file
        FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))

        'Read in records from file
        RecPos = 1
        Do While Not EOF(1)
            'Read in record from file
            FileGet(1, PizzaRec, RecPos)

            'If the record matches selected customer, display their details
            If PizzaRec.PizzaID = SearchID Then
                With PizzaRec
                    'Read ID into text box
                    txtPizzaID.Text = .PizzaID

                    'Read PizzaName into variable
                    PizzaName = .PizzaName
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(PizzaName, 1) = " "
                        PizzaName = Mid(PizzaName, 1, Len(PizzaName) - 1)
                    Loop
                    'Read variable into text box
                    txtPizzaName.Text = PizzaName

                    'Read PizzaName into variable
                    Desc = .Description
                    'Remove blank spaces from field
                    Do While Microsoft.VisualBasic.Right(Desc, 1) = " "
                        Desc = Mid(Desc, 1, Len(Desc) - 1)
                    Loop
                    'Read variable into text box
                    txtDesc.Text = Desc

                    'Read prices into text boxes
                    txtSml.Text = FormatCurrency(.PriceSmall)
                    txtMed.Text = FormatCurrency(.PriceMedium)
                    txtLrg.Text = FormatCurrency(.PriceLarge)
                End With

                'Close file
                FileClose(1)
                Exit Sub
            Else
                'If records don't match then get the next record
                RecPos = RecPos + 1
            End If
            'Move on to next record in file
        Loop
        'Close file
        FileClose(1)
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        'If button reads "Edit" (i.e. form isn't in editing mode)
        If btnEdit.Text = "Edit" Then
            'Unlock textboxes for editing
            txtPizzaName.Enabled = True
            txtDesc.Enabled = True
            txtSml.Enabled = True
            txtMed.Enabled = True
            txtLrg.Enabled = True

            'Change the edit button to read Save
            btnEdit.Text = "Save"
            btnEdit.Height = 24
            'If button reads "Save" (i.e. form is in editing mode)
        ElseIf btnEdit.Text = "Save" Then
            'If text boxes are empty
            If txtPizzaName.Text = "" Then
                'Display error message
                MsgBox("Please enter the pizza's name." & vbNewLine & "EXAMPLE: Cheese & Tomato", MessageBoxIcon.Error)
                Exit Sub
            ElseIf txtDesc.Text = "" Then
                'Display error message
                MsgBox("Please enter a description for the pizza." & vbNewLine & "EXAMPLE: Rich Tomato with Mozzarella", MessageBoxIcon.Error)
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

            'Read in fields of the customer record
            With PizzaRec
                .PizzaID = Val(txtPizzaID.Text)
                .Description = txtDesc.Text
                .PizzaName = txtPizzaName.Text
                .PriceSmall = txtSml.Text
                .PriceMedium = txtMed.Text
                .PriceLarge = txtLrg.Text
            End With

            'Open CustFile in random access mode
            FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
            'Write the customers record back to the file
            FilePut(1, PizzaRec, RecPos)
            'Close CustFile
            FileClose(1)

            'Reload form
            Call frmPizzaEdit_Load(Me, e)
            'Lock textboxes for editing
            txtPizzaName.Enabled = False
            txtDesc.Enabled = False
            txtSml.Enabled = False
            txtMed.Enabled = False
            txtLrg.Enabled = False
            'Change the Save button to read Edit
            btnEdit.Text = "Edit"
            btnEdit.Height = 50
            'Change font of search box
            txtSearch.ForeColor = Color.DarkGray
            txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
            'Write "Search..." into search box
            txtSearch.Text = "Search..."
        End If
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        'Make ID a negative number
        PizzaRec.PizzaID = -Val(txtPizzaID.Text)

        'Open CustFile in random access mode
        FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
        'Write the customers record back to the file
        FilePut(1, PizzaRec, RecPos)
        'Close CustFile
        FileClose(1)

        'Reload form
        Call frmPizzaEdit_Load(Me, e)
        'Lock and clear textboxes
        txtPizzaID.Text = ""
        txtPizzaName.Enabled = False
        txtPizzaName.Text = ""
        txtDesc.Text = ""
        txtDesc.Enabled = False
        txtSml.Enabled = False
        txtSml.Text = ""
        txtMed.Enabled = False
        txtMed.Text = ""
        txtLrg.Enabled = False
        txtLrg.Text = ""
        'Change the Save button to read Edit
        btnEdit.Text = "Edit"
        btnEdit.Height = 50
        'Change font of search box
        txtSearch.ForeColor = Color.DarkGray
        txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
        'Read "Search..." into search box
        txtSearch.Text = "Search..."
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Close current from and show Admin form
        Me.Close()
        frmAdmin.Show()
    End Sub

    Private Sub txtSearch_Enter(sender As Object, e As EventArgs) Handles txtSearch.Enter
        'Lock and clear textboxes
        txtPizzaID.Text = ""
        txtPizzaName.Enabled = False
        txtPizzaName.Text = ""
        txtDesc.Enabled = False
        txtDesc.Text = ""
        txtSml.Enabled = False
        txtSml.Text = ""
        txtMed.Enabled = False
        txtMed.Text = ""
        txtLrg.Enabled = False
        txtLrg.Text = ""
        'Change the Save button to read Edit
        btnEdit.Text = "Edit"
        btnEdit.Height = 50
        'If nothing is input into Search text box (i.e. reads "Search...")
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
            'Write "Search..." and change font
            txtSearch.ForeColor = Color.DarkGray
            txtSearch.Font = New Font("Microsoft Sans Serif", 8.25, FontStyle.Italic)
            txtSearch.Text = "Search..."
            'Reload the form
            Call frmPizzaEdit_Load(Me, e)
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        'Declare variables
        Dim SearchName As String
        Dim Pizza As String
        Dim NumPizzasFound As Integer

        'If nothing is input into the search text box
        If txtSearch.Text = "" Or txtSearch.Text = "Search..." Then
            'Reload the form
            Call frmPizzaEdit_Load(Me, e)
        Else
            'Clear list box and add title
            lstPizza.Items.Clear()

            'Open customers file in random access mode
            FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))

            'Calculate the number of records in the file
            NumRecs = LOF(1) / Len(PizzaRec)

            'Read the searched name, and make it lower case
            SearchName = LCase(txtSearch.Text)

            'Get the first record stored
            RecPos = 1
            Do While Not EOF(1)
                'Read the record from the file
                FileGet(1, PizzaRec, RecPos)

                'Read the pizza name
                Pizza = PizzaRec.PizzaName
                'Remove blank spaces from field
                Do While Microsoft.VisualBasic.Right(Pizza, 1) = " "
                    Pizza = Mid(Pizza, 1, Len(Pizza) - 1)
                Loop

                'If ID (converted to string for easy comparison to SearchName) matches the searched name, or the pizza name matches the searched name
                If InStr(PizzaRec.PizzaID, SearchName) Or InStr(LCase(Pizza), SearchName) Then
                    'If pizza ID is greater than 0 (i.e. not marked for deletion)
                    If PizzaRec.PizzaID > 0 Then
                        'Add pizza details to list box
                        lstPizza.Items.Add(PizzaRec.PizzaID & "        " & Pizza)
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
        Dim TitleFont As New Font("Gill Sans Ultra Bold", 20, FontStyle.Bold)
        Dim BodyFont As New Font("Microsoft Sans Serif", 10, FontStyle.Regular)
        'Read in logo image
        Dim Logo As Image = PictureBox1.Image

        'Print the logo
        e.Graphics.DrawImage(Logo, 600, 75)

        'Set up location to start printing
        FontHeight = BodyFont.GetHeight(e.Graphics)
        x = 50
        y = 50

        'Print the title on the page
        e.Graphics.DrawString(UCase(txtPizzaName.Text) & " PIZZA", TitleFont, Brushes.Firebrick, x, y)
        'Move down to print the body of the document
        y = 100

        'Print the Pizza name and ID number 
        e.Graphics.DrawString("Pizza Name: " & txtPizzaName.Text & " (ID: " & txtPizzaID.Text & ")", BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight

        'Print the description
        e.Graphics.DrawString("Description: " & txtDesc.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight

        'Print the prices
        e.Graphics.DrawString("Price for Small: " & txtSml.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
        e.Graphics.DrawString("Price for Medium: " & txtMed.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
        e.Graphics.DrawString("Price for Large: " & txtLrg.Text, BodyFont, Brushes.Black, x, y)
        'Move to the next line
        y = y + FontHeight
    End Sub
End Class