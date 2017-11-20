Public Class frmAdminLogin
    Private Sub btnLogIn_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        'If password entered correctly then
        If txtPassword.Text = "admin" Then
            'Log the user into the admin area
            frmAdmin.Show()
            frmHome.Close()
            Me.Close()
        Else
            'If password incorrect, display error message
            MsgBox("Incorrect password entered." & vbNewLine & "Please try again.", MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        'If enter key is pressed
        If e.KeyCode = Keys.Enter Then
            'If password entered correctly then
            If txtPassword.Text = "admin" Then
                'Log the user into the admin area
                frmAdmin.Show()
                frmHome.Close()
                Me.Close()
            Else
                'If password incorrect, display error message
                MsgBox("Incorrect password entered." & vbNewLine & "Please try again.", MessageBoxIcon.Error)
            End If
        End If
    End Sub
End Class