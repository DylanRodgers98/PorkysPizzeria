Public Class frmHome
    'Declare variables
    Dim NumRecs As Integer
    Dim RecPos As Integer
    Dim Password As String
    'Set up paths to files
    Dim CustFile As String = Application.StartupPath & "\cust.dat"
    Dim LoggedIn As String = Application.StartupPath & "\loggedIn.dat"

    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        'Open the customers file in random access mode
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
        'Calculate the number of records in the file
        NumRecs = LOF(1) / Len(CustRec)

        'For each record from the file
        For RecPos = 1 To NumRecs
            'Read the record from the file
            FileGet(1, CustRec, RecPos)

            'Read in the password
            Password = CustRec.Password
            'Remove blank spaces from password
            Do While Microsoft.VisualBasic.Right(Password, 1) = " "
                Password = Mid(Password, 1, Len(Password) - 1)
            Loop

            'Check if ID and password in the record match the ID and password input
            If Val(CustRec.CustID) = Val(txtID.Text) And Password = txtPassword.Text Then
                'Open the loggedIn file in output mode
                FileOpen(2, LoggedIn, OpenMode.Output)
                'Save logged in user's ID to the loggedIn file
                Print(2, CustRec.CustID)
                'Close files
                FileClose(1)
                FileClose(2)
                'Show user home form and hide current form
                frmUser.Show()
                Me.Close()
                Exit Sub
            End If

            'Move on to next record
        Next RecPos

        'If no matching ID and password are found in the file, display error message
        MsgBox("Login failed." & vbNewLine & "Check ID and Password are correct and try again.", MessageBoxIcon.Error)
        'Close file
        FileClose(1)
    End Sub

    Private Sub btnAdmin_Click(sender As Object, e As EventArgs) Handles btnAdmin.Click
        'Show Admin Login form
        frmAdminLogin.Show()
    End Sub

    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        'Hide current from and show Sign Up form
        frmSignUp.Show()
        Me.Close()
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtID.KeyDown
        'If the enter key is pressed
        If e.KeyCode = Keys.Enter Then
            'Open the customers file in random access mode
            FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
            'Calculate the number of records in the file
            NumRecs = LOF(1) / Len(CustRec)

            'For each record from the file
            For RecPos = 1 To NumRecs
                'Read the record from the file
                FileGet(1, CustRec, RecPos)

                'Read in the password
                Password = CustRec.Password
                'Remove blank spaces from password
                Do While Microsoft.VisualBasic.Right(Password, 1) = " "
                    Password = Mid(Password, 1, Len(Password) - 1)
                Loop

                'Check if ID and password in the record match the ID and password input
                If Val(CustRec.CustID) = Val(txtID.Text) And Password = txtPassword.Text Then
                    'Open the loggedIn file in output mode
                    FileOpen(2, LoggedIn, OpenMode.Output)
                    'Save logged in user's ID to the loggedIn file
                    Print(2, CustRec.CustID)
                    'Close files
                    FileClose(1)
                    FileClose(2)
                    'Show user home form and hide current form
                    frmUser.Show()
                    Me.Close()
                    Exit Sub
                End If

                'Move on to next record
            Next RecPos

            'If no matching ID and password are found in the file, display error message
            MsgBox("Login failed." & vbNewLine & "Check ID and Password are correct and try again.", MessageBoxIcon.Error)
            'Close file
            FileClose(1)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        'If the enter key is pressed
        If e.KeyCode = Keys.Enter Then
            'Open the customers file in random access mode
            FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
            'Calculate the number of records in the file
            NumRecs = LOF(1) / Len(CustRec)

            'For each record from the file
            For RecPos = 1 To NumRecs
                'Read the record from the file
                FileGet(1, CustRec, RecPos)

                'Read in the password
                Password = CustRec.Password
                'Remove blank spaces from password
                Do While Microsoft.VisualBasic.Right(Password, 1) = " "
                    Password = Mid(Password, 1, Len(Password) - 1)
                Loop

                'Check if ID and password in the record match the ID and password input
                If Val(CustRec.CustID) = Val(txtID.Text) And Password = txtPassword.Text Then
                    'Open the loggedIn file in output mode
                    FileOpen(2, LoggedIn, OpenMode.Output)
                    'Save logged in user's ID to the loggedIn file
                    Print(2, CustRec.CustID)
                    'Close files
                    FileClose(1)
                    FileClose(2)
                    'Show user home form and hide current form
                    frmUser.Show()
                    Me.Close()
                    Exit Sub
                End If

                'Move on to next record
            Next RecPos

            'If no matching ID and password are found in the file, display error message
            MsgBox("Login failed." & vbNewLine & "Check ID and Password are correct and try again.", MessageBoxIcon.Error)
            'Close file
            FileClose(1)
        End If
    End Sub
End Class