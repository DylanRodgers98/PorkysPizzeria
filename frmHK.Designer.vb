<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHK
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHK))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabCust = New System.Windows.Forms.TabPage()
        Me.txtCustSearch = New System.Windows.Forms.TextBox()
        Me.btnBack1 = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnDelCust = New System.Windows.Forms.Button()
        Me.btnRestoreCust = New System.Windows.Forms.Button()
        Me.lstCust = New System.Windows.Forms.ListBox()
        Me.tabPizzas = New System.Windows.Forms.TabPage()
        Me.txtPizzaSearch = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBack2 = New System.Windows.Forms.Button()
        Me.btnDelPizza = New System.Windows.Forms.Button()
        Me.btnRestorePizza = New System.Windows.Forms.Button()
        Me.lstPizza = New System.Windows.Forms.ListBox()
        Me.tabOrders = New System.Windows.Forms.TabPage()
        Me.txtOrderSearch = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBack3 = New System.Windows.Forms.Button()
        Me.btnDelOrder = New System.Windows.Forms.Button()
        Me.btnRestoreOrder = New System.Windows.Forms.Button()
        Me.lstOrders = New System.Windows.Forms.ListBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabCust.SuspendLayout()
        Me.tabPizzas.SuspendLayout()
        Me.tabOrders.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.tabCust)
        Me.TabControl1.Controls.Add(Me.tabPizzas)
        Me.TabControl1.Controls.Add(Me.tabOrders)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 37)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(280, 228)
        Me.TabControl1.TabIndex = 29
        '
        'tabCust
        '
        Me.tabCust.BackColor = System.Drawing.Color.Transparent
        Me.tabCust.Controls.Add(Me.txtCustSearch)
        Me.tabCust.Controls.Add(Me.btnBack1)
        Me.tabCust.Controls.Add(Me.Label13)
        Me.tabCust.Controls.Add(Me.btnDelCust)
        Me.tabCust.Controls.Add(Me.btnRestoreCust)
        Me.tabCust.Controls.Add(Me.lstCust)
        Me.tabCust.Location = New System.Drawing.Point(4, 32)
        Me.tabCust.Name = "tabCust"
        Me.tabCust.Size = New System.Drawing.Size(272, 192)
        Me.tabCust.TabIndex = 0
        Me.tabCust.Text = "Customers"
        '
        'txtCustSearch
        '
        Me.txtCustSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustSearch.ForeColor = System.Drawing.Color.DarkGray
        Me.txtCustSearch.Location = New System.Drawing.Point(0, 0)
        Me.txtCustSearch.Name = "txtCustSearch"
        Me.txtCustSearch.Size = New System.Drawing.Size(272, 20)
        Me.txtCustSearch.TabIndex = 89
        Me.txtCustSearch.Text = "Search Deleted Customers..."
        '
        'btnBack1
        '
        Me.btnBack1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack1.Location = New System.Drawing.Point(186, 157)
        Me.btnBack1.Name = "btnBack1"
        Me.btnBack1.Size = New System.Drawing.Size(86, 35)
        Me.btnBack1.TabIndex = 88
        Me.btnBack1.Text = "Back"
        Me.btnBack1.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(1, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(82, 13)
        Me.Label13.TabIndex = 87
        Me.Label13.Text = "ID            Name"
        '
        'btnDelCust
        '
        Me.btnDelCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelCust.Location = New System.Drawing.Point(93, 157)
        Me.btnDelCust.Name = "btnDelCust"
        Me.btnDelCust.Size = New System.Drawing.Size(86, 35)
        Me.btnDelCust.TabIndex = 2
        Me.btnDelCust.Text = "Permanently Delete All"
        Me.btnDelCust.UseVisualStyleBackColor = True
        '
        'btnRestoreCust
        '
        Me.btnRestoreCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestoreCust.Location = New System.Drawing.Point(0, 157)
        Me.btnRestoreCust.Name = "btnRestoreCust"
        Me.btnRestoreCust.Size = New System.Drawing.Size(86, 35)
        Me.btnRestoreCust.TabIndex = 1
        Me.btnRestoreCust.Text = "Restore Customer"
        Me.btnRestoreCust.UseVisualStyleBackColor = True
        '
        'lstCust
        '
        Me.lstCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCust.FormattingEnabled = True
        Me.lstCust.Location = New System.Drawing.Point(0, 43)
        Me.lstCust.Name = "lstCust"
        Me.lstCust.Size = New System.Drawing.Size(272, 108)
        Me.lstCust.TabIndex = 0
        '
        'tabPizzas
        '
        Me.tabPizzas.BackColor = System.Drawing.Color.Transparent
        Me.tabPizzas.Controls.Add(Me.txtPizzaSearch)
        Me.tabPizzas.Controls.Add(Me.Label6)
        Me.tabPizzas.Controls.Add(Me.btnBack2)
        Me.tabPizzas.Controls.Add(Me.btnDelPizza)
        Me.tabPizzas.Controls.Add(Me.btnRestorePizza)
        Me.tabPizzas.Controls.Add(Me.lstPizza)
        Me.tabPizzas.Location = New System.Drawing.Point(4, 32)
        Me.tabPizzas.Name = "tabPizzas"
        Me.tabPizzas.Size = New System.Drawing.Size(272, 192)
        Me.tabPizzas.TabIndex = 1
        Me.tabPizzas.Text = "Pizzas"
        '
        'txtPizzaSearch
        '
        Me.txtPizzaSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPizzaSearch.ForeColor = System.Drawing.Color.DarkGray
        Me.txtPizzaSearch.Location = New System.Drawing.Point(0, 0)
        Me.txtPizzaSearch.Name = "txtPizzaSearch"
        Me.txtPizzaSearch.Size = New System.Drawing.Size(272, 20)
        Me.txtPizzaSearch.TabIndex = 91
        Me.txtPizzaSearch.Text = "Search Deleted Pizzas..."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1, 27)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "ID       Pizza Name"
        '
        'btnBack2
        '
        Me.btnBack2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack2.Location = New System.Drawing.Point(186, 157)
        Me.btnBack2.Name = "btnBack2"
        Me.btnBack2.Size = New System.Drawing.Size(86, 35)
        Me.btnBack2.TabIndex = 89
        Me.btnBack2.Text = "Back"
        Me.btnBack2.UseVisualStyleBackColor = True
        '
        'btnDelPizza
        '
        Me.btnDelPizza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelPizza.Location = New System.Drawing.Point(93, 157)
        Me.btnDelPizza.Name = "btnDelPizza"
        Me.btnDelPizza.Size = New System.Drawing.Size(86, 35)
        Me.btnDelPizza.TabIndex = 5
        Me.btnDelPizza.Text = "Permanently Delete All"
        Me.btnDelPizza.UseVisualStyleBackColor = True
        '
        'btnRestorePizza
        '
        Me.btnRestorePizza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestorePizza.Location = New System.Drawing.Point(0, 157)
        Me.btnRestorePizza.Name = "btnRestorePizza"
        Me.btnRestorePizza.Size = New System.Drawing.Size(86, 35)
        Me.btnRestorePizza.TabIndex = 4
        Me.btnRestorePizza.Text = "Restore Pizza"
        Me.btnRestorePizza.UseVisualStyleBackColor = True
        '
        'lstPizza
        '
        Me.lstPizza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPizza.FormattingEnabled = True
        Me.lstPizza.Location = New System.Drawing.Point(0, 43)
        Me.lstPizza.Name = "lstPizza"
        Me.lstPizza.Size = New System.Drawing.Size(272, 108)
        Me.lstPizza.TabIndex = 3
        '
        'tabOrders
        '
        Me.tabOrders.BackColor = System.Drawing.Color.Transparent
        Me.tabOrders.Controls.Add(Me.txtOrderSearch)
        Me.tabOrders.Controls.Add(Me.Label1)
        Me.tabOrders.Controls.Add(Me.btnBack3)
        Me.tabOrders.Controls.Add(Me.btnDelOrder)
        Me.tabOrders.Controls.Add(Me.btnRestoreOrder)
        Me.tabOrders.Controls.Add(Me.lstOrders)
        Me.tabOrders.Location = New System.Drawing.Point(4, 32)
        Me.tabOrders.Name = "tabOrders"
        Me.tabOrders.Size = New System.Drawing.Size(272, 192)
        Me.tabOrders.TabIndex = 2
        Me.tabOrders.Text = "Orders"
        '
        'txtOrderSearch
        '
        Me.txtOrderSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderSearch.ForeColor = System.Drawing.Color.DarkGray
        Me.txtOrderSearch.Location = New System.Drawing.Point(0, 0)
        Me.txtOrderSearch.Name = "txtOrderSearch"
        Me.txtOrderSearch.Size = New System.Drawing.Size(272, 20)
        Me.txtOrderSearch.TabIndex = 92
        Me.txtOrderSearch.Text = "Search Deleted Orders..."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 13)
        Me.Label1.TabIndex = 91
        Me.Label1.Text = "ID        Date              Customer (ID: Name)    Cost"
        '
        'btnBack3
        '
        Me.btnBack3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack3.Location = New System.Drawing.Point(186, 157)
        Me.btnBack3.Name = "btnBack3"
        Me.btnBack3.Size = New System.Drawing.Size(86, 35)
        Me.btnBack3.TabIndex = 90
        Me.btnBack3.Text = "Back"
        Me.btnBack3.UseVisualStyleBackColor = True
        '
        'btnDelOrder
        '
        Me.btnDelOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelOrder.Location = New System.Drawing.Point(93, 157)
        Me.btnDelOrder.Name = "btnDelOrder"
        Me.btnDelOrder.Size = New System.Drawing.Size(86, 35)
        Me.btnDelOrder.TabIndex = 5
        Me.btnDelOrder.Text = "Permanently Delete All"
        Me.btnDelOrder.UseVisualStyleBackColor = True
        '
        'btnRestoreOrder
        '
        Me.btnRestoreOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRestoreOrder.Location = New System.Drawing.Point(0, 157)
        Me.btnRestoreOrder.Name = "btnRestoreOrder"
        Me.btnRestoreOrder.Size = New System.Drawing.Size(86, 35)
        Me.btnRestoreOrder.TabIndex = 4
        Me.btnRestoreOrder.Text = "Restore Order"
        Me.btnRestoreOrder.UseVisualStyleBackColor = True
        '
        'lstOrders
        '
        Me.lstOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstOrders.FormattingEnabled = True
        Me.lstOrders.Location = New System.Drawing.Point(0, 43)
        Me.lstOrders.Name = "lstOrders"
        Me.lstOrders.Size = New System.Drawing.Size(272, 108)
        Me.lstOrders.TabIndex = 3
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Firebrick
        Me.lblTitle.Location = New System.Drawing.Point(18, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(246, 33)
        Me.lblTitle.TabIndex = 28
        Me.lblTitle.Text = "HOUSEKEEPING"
        '
        'frmHK
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 265)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHK"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Housekeeping"
        Me.TabControl1.ResumeLayout(False)
        Me.tabCust.ResumeLayout(False)
        Me.tabCust.PerformLayout()
        Me.tabPizzas.ResumeLayout(False)
        Me.tabPizzas.PerformLayout()
        Me.tabOrders.ResumeLayout(False)
        Me.tabOrders.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabCust As TabPage
    Friend WithEvents tabPizzas As TabPage
    Friend WithEvents tabOrders As TabPage
    Friend WithEvents lblTitle As Label
    Friend WithEvents btnDelCust As Button
    Friend WithEvents btnRestoreCust As Button
    Friend WithEvents lstCust As ListBox
    Friend WithEvents btnDelPizza As Button
    Friend WithEvents btnRestorePizza As Button
    Friend WithEvents lstPizza As ListBox
    Friend WithEvents btnDelOrder As Button
    Friend WithEvents btnRestoreOrder As Button
    Friend WithEvents lstOrders As ListBox
    Friend WithEvents Label13 As Label
    Friend WithEvents btnBack1 As Button
    Friend WithEvents btnBack2 As Button
    Friend WithEvents btnBack3 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCustSearch As TextBox
    Friend WithEvents txtPizzaSearch As TextBox
    Friend WithEvents txtOrderSearch As TextBox
End Class
