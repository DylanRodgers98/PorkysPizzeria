Public Class frmSignUp
    'Declare global variables and set up path to the customers file
    Dim CustFile As String = Application.StartupPath & "\cust.dat"
    Dim NumRecs As Integer

    Private Sub frmSignUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declare variables
        Dim CustID As String
        Dim RecPos As Integer

        'Open the customers file in random access mode
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
        'Caluclate the number of records in the file
        NumRecs = LOF(1) / Len(CustRec)
        'Set CustID to be the next record in the file
        CustID = NumRecs + 1
        'For each record in file
        For RecPos = 1 To NumRecs
            'Read record from file
            FileGet(1, CustRec, RecPos)
            'If CustID matches the ID of the record in the file
            If CustRec.CustID = CustID Then
                'Increase CustID by 1
                CustID = CustID + 1
            End If
            'Move on to next record
        Next

        'Add 0's to customer's ID to make it 4 digits in length
        Do While Len(CustID) < 4
            CustID = "0" & CustID
        Loop
        'Set the CustID to be the next record
        txtCustID.Text = CustID
        'Close the file
        FileClose(1)
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        'Declare variables and set up path to the loggedIn file
        Dim LoggedIn As String = Application.StartupPath & "\loggedIn.dat"
        Dim RecPos As Integer

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

        'Read textbox values into fields of record
        CustRec.CustID = Val(txtCustID.Text)
        CustRec.Password = txtPassword.Text
        CustRec.Forename = txtForename.Text
        CustRec.Surname = txtSurname.Text
        CustRec.House = txtHouse.Text
        CustRec.Street = txtStreet.Text
        CustRec.District = txtDistrict.Text
        CustRec.Town = txtTown.Text
        CustRec.County = txtCounty.Text
        CustRec.Postcode = txtPostcode.Text
        CustRec.TelNo = txtTel.Text

        'Open the customers file in random access mode
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
        'Caluclate the number of records in the file
        NumRecs = LOF(1) / Len(CustRec)
        'Write the record to the next space in the file
        RecPos = NumRecs + 1
        FilePut(1, CustRec, RecPos)
        'Close the file
        FileClose(1)

        'Display message box showing where in the file the customer details have been saved
        MsgBox("Hello, " & txtForename.Text & "!" & vbNewLine & "Your ID is " & txtCustID.Text & ". REMEMBER THIS, as you will need it to log in.", MessageBoxIcon.Information)

        'LOG NEW USER IN
        'Open the loggedIn file in output mode
        FileOpen(2, LoggedIn, OpenMode.Output)
        'Save logged in user's ID to the loggedIn file
        Print(2, txtCustID.Text)
        'Close files
        FileClose(2)
        'Close SignUp form and open User home
        frmUser.Show()
        frmHome.Close()
        Me.Close()
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Close current form and show admin form
        frmHome.Show()
        Me.Close()
    End Sub
End Class