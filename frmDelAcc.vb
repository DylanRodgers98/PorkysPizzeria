Public Class frmDelAcc
    Private Sub btnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        'Close current form
        Me.Close()
    End Sub

    Private Sub btnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        'Declare variables
        Dim CustFile As String = Application.StartupPath & "\cust.dat"
        Dim RecPos As Integer

        'Open CustFile in random access mode
        FileOpen(1, CustFile, OpenMode.Random, , , Len(CustRec))
        'Start at the first record in the file
        RecPos = 1
        Do While Not EOF(1)
            'Read in the record from file
            FileGet(1, CustRec, RecPos)
            'If the ID in the file matches the ID of the user logged in then
            If CustRec.CustID = LoggedInUser Then
                'Make user's ID a negative number
                CustRec.CustID = -Val(LoggedInUser)
                'Write the customer's record back to the file
                FilePut(1, CustRec, RecPos)
                'Close CustFile
                FileClose(1)
                'Close current form and User Area form, and open the Home form
                Me.Close()
                frmUser.Close()
                frmHome.Show()
                Exit Sub
            End If
            'Move on to next record in file
            RecPos = RecPos + 1
        Loop
    End Sub
End Class