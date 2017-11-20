<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmin))
        Me.btnNewCust = New System.Windows.Forms.Button()
        Me.btnNewPizza = New System.Windows.Forms.Button()
        Me.btnEditPizza = New System.Windows.Forms.Button()
        Me.btnEditCust = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnCreateOrder = New System.Windows.Forms.Button()
        Me.btnViewOrders = New System.Windows.Forms.Button()
        Me.btnHK = New System.Windows.Forms.Button()
        Me.btnSales = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnNewCust
        '
        Me.btnNewCust.Location = New System.Drawing.Point(12, 47)
        Me.btnNewCust.Name = "btnNewCust"
        Me.btnNewCust.Size = New System.Drawing.Size(75, 35)
        Me.btnNewCust.TabIndex = 0
        Me.btnNewCust.Text = "Add New Customer"
        Me.btnNewCust.UseVisualStyleBackColor = True
        '
        'btnNewPizza
        '
        Me.btnNewPizza.Location = New System.Drawing.Point(93, 47)
        Me.btnNewPizza.Name = "btnNewPizza"
        Me.btnNewPizza.Size = New System.Drawing.Size(75, 35)
        Me.btnNewPizza.TabIndex = 1
        Me.btnNewPizza.Text = "Add New Pizza"
        Me.btnNewPizza.UseVisualStyleBackColor = True
        '
        'btnEditPizza
        '
        Me.btnEditPizza.Location = New System.Drawing.Point(93, 88)
        Me.btnEditPizza.Name = "btnEditPizza"
        Me.btnEditPizza.Size = New System.Drawing.Size(75, 35)
        Me.btnEditPizza.TabIndex = 4
        Me.btnEditPizza.Text = "Pizzas"
        Me.btnEditPizza.UseVisualStyleBackColor = True
        '
        'btnEditCust
        '
        Me.btnEditCust.Location = New System.Drawing.Point(12, 88)
        Me.btnEditCust.Name = "btnEditCust"
        Me.btnEditCust.Size = New System.Drawing.Size(75, 35)
        Me.btnEditCust.TabIndex = 3
        Me.btnEditCust.Text = "Customers"
        Me.btnEditCust.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Firebrick
        Me.Label11.Location = New System.Drawing.Point(24, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(213, 33)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "ADMIN AREA"
        '
        'btnBack
        '
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.Location = New System.Drawing.Point(93, 158)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(75, 23)
        Me.btnBack.TabIndex = 8
        Me.btnBack.Text = "Log Out"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnCreateOrder
        '
        Me.btnCreateOrder.Location = New System.Drawing.Point(174, 47)
        Me.btnCreateOrder.Name = "btnCreateOrder"
        Me.btnCreateOrder.Size = New System.Drawing.Size(75, 35)
        Me.btnCreateOrder.TabIndex = 2
        Me.btnCreateOrder.Text = "Create New Order"
        Me.btnCreateOrder.UseVisualStyleBackColor = True
        '
        'btnViewOrders
        '
        Me.btnViewOrders.Location = New System.Drawing.Point(174, 88)
        Me.btnViewOrders.Name = "btnViewOrders"
        Me.btnViewOrders.Size = New System.Drawing.Size(75, 35)
        Me.btnViewOrders.TabIndex = 5
        Me.btnViewOrders.Text = "Orders"
        Me.btnViewOrders.UseVisualStyleBackColor = True
        '
        'btnHK
        '
        Me.btnHK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHK.Location = New System.Drawing.Point(12, 129)
        Me.btnHK.Name = "btnHK"
        Me.btnHK.Size = New System.Drawing.Size(115, 23)
        Me.btnHK.TabIndex = 6
        Me.btnHK.Text = "Housekeeping"
        Me.btnHK.UseVisualStyleBackColor = True
        '
        'btnSales
        '
        Me.btnSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSales.Location = New System.Drawing.Point(134, 129)
        Me.btnSales.Name = "btnSales"
        Me.btnSales.Size = New System.Drawing.Size(115, 23)
        Me.btnSales.TabIndex = 7
        Me.btnSales.Text = "Sales"
        Me.btnSales.UseVisualStyleBackColor = True
        '
        'frmAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(262, 187)
        Me.Controls.Add(Me.btnSales)
        Me.Controls.Add(Me.btnHK)
        Me.Controls.Add(Me.btnViewOrders)
        Me.Controls.Add(Me.btnCreateOrder)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnEditPizza)
        Me.Controls.Add(Me.btnEditCust)
        Me.Controls.Add(Me.btnNewPizza)
        Me.Controls.Add(Me.btnNewCust)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admin Area"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNewCust As Button
    Friend WithEvents btnNewPizza As Button
    Friend WithEvents btnEditPizza As Button
    Friend WithEvents btnEditCust As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents btnBack As Button
    Friend WithEvents btnCreateOrder As Button
    Friend WithEvents btnViewOrders As Button
    Friend WithEvents btnHK As Button
    Friend WithEvents btnSales As Button
End Class
