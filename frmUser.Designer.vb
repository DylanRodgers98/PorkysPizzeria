<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUser))
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabOrderAdd = New System.Windows.Forms.TabPage()
        Me.txtOrderID = New System.Windows.Forms.TextBox()
        Me.btnOrder = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.lstOrder = New System.Windows.Forms.ListBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblLrg = New System.Windows.Forms.Label()
        Me.lblMed = New System.Windows.Forms.Label()
        Me.lblSml = New System.Windows.Forms.Label()
        Me.cmbPizza = New System.Windows.Forms.ComboBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSubtotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.radSml = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.radMed = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.radLrg = New System.Windows.Forms.RadioButton()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tabOrderView = New System.Windows.Forms.TabPage()
        Me.lblOrder = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lstPrevOrders = New System.Windows.Forms.ListBox()
        Me.lstItems = New System.Windows.Forms.ListBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lstOrders = New System.Windows.Forms.ListBox()
        Me.tabAccount = New System.Windows.Forms.TabPage()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtCustID = New System.Windows.Forms.TextBox()
        Me.txtForename = New System.Windows.Forms.TextBox()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.txtHouse = New System.Windows.Forms.TextBox()
        Me.txtCounty = New System.Windows.Forms.TextBox()
        Me.txtTel = New System.Windows.Forms.TextBox()
        Me.txtPostcode = New System.Windows.Forms.TextBox()
        Me.txtDistrict = New System.Windows.Forms.TextBox()
        Me.txtStreet = New System.Windows.Forms.TextBox()
        Me.txtTown = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.tabLogOut = New System.Windows.Forms.TabPage()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabControl1.SuspendLayout()
        Me.tabOrderAdd.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabOrderView.SuspendLayout()
        Me.tabAccount.SuspendLayout()
        Me.tabLogOut.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Firebrick
        Me.lblTitle.Location = New System.Drawing.Point(12, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(302, 33)
        Me.lblTitle.TabIndex = 26
        Me.lblTitle.Text = "WELCOME, [NAME]!"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.tabOrderAdd)
        Me.TabControl1.Controls.Add(Me.tabOrderView)
        Me.TabControl1.Controls.Add(Me.tabAccount)
        Me.TabControl1.Controls.Add(Me.tabLogOut)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Font = New System.Drawing.Font("Gill Sans Ultra Bold", 11.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 45)
        Me.TabControl1.Multiline = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(500, 393)
        Me.TabControl1.TabIndex = 27
        '
        'tabOrderAdd
        '
        Me.tabOrderAdd.Controls.Add(Me.txtOrderID)
        Me.tabOrderAdd.Controls.Add(Me.btnOrder)
        Me.tabOrderAdd.Controls.Add(Me.GroupBox3)
        Me.tabOrderAdd.Controls.Add(Me.Label7)
        Me.tabOrderAdd.Controls.Add(Me.txtTotal)
        Me.tabOrderAdd.Controls.Add(Me.GroupBox1)
        Me.tabOrderAdd.Controls.Add(Me.Label18)
        Me.tabOrderAdd.Location = New System.Drawing.Point(4, 32)
        Me.tabOrderAdd.Name = "tabOrderAdd"
        Me.tabOrderAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOrderAdd.Size = New System.Drawing.Size(492, 357)
        Me.tabOrderAdd.TabIndex = 0
        Me.tabOrderAdd.Text = "Place An Order"
        Me.tabOrderAdd.UseVisualStyleBackColor = True
        '
        'txtOrderID
        '
        Me.txtOrderID.Enabled = False
        Me.txtOrderID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrderID.Location = New System.Drawing.Point(70, 5)
        Me.txtOrderID.Name = "txtOrderID"
        Me.txtOrderID.Size = New System.Drawing.Size(70, 20)
        Me.txtOrderID.TabIndex = 80
        '
        'btnOrder
        '
        Me.btnOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrder.Location = New System.Drawing.Point(434, 175)
        Me.btnOrder.Name = "btnOrder"
        Me.btnOrder.Size = New System.Drawing.Size(47, 24)
        Me.btnOrder.TabIndex = 71
        Me.btnOrder.Text = "Order!"
        Me.btnOrder.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnRemove)
        Me.GroupBox3.Controls.Add(Me.lstOrder)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(249, 29)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(231, 144)
        Me.GroupBox3.TabIndex = 79
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Order"
        '
        'btnRemove
        '
        Me.btnRemove.Enabled = False
        Me.btnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(21, 113)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(189, 24)
        Me.btnRemove.TabIndex = 8
        Me.btnRemove.Text = "Remove Selected Item(s) From Order"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'lstOrder
        '
        Me.lstOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstOrder.FormattingEnabled = True
        Me.lstOrder.Location = New System.Drawing.Point(5, 15)
        Me.lstOrder.Name = "lstOrder"
        Me.lstOrder.Size = New System.Drawing.Size(221, 95)
        Me.lstOrder.TabIndex = 48
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(247, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(111, 13)
        Me.Label7.TabIndex = 75
        Me.Label7.Text = "Total (w/ delivery)"
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(358, 177)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(70, 20)
        Me.txtTotal.TabIndex = 77
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtQuantity)
        Me.GroupBox1.Controls.Add(Me.lblLrg)
        Me.GroupBox1.Controls.Add(Me.lblMed)
        Me.GroupBox1.Controls.Add(Me.lblSml)
        Me.GroupBox1.Controls.Add(Me.cmbPizza)
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSubtotal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.radSml)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.radMed)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.radLrg)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(227, 170)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pizza"
        '
        'txtQuantity
        '
        Me.txtQuantity.Enabled = False
        Me.txtQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(58, 115)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(70, 20)
        Me.txtQuantity.TabIndex = 49
        '
        'lblLrg
        '
        Me.lblLrg.AutoSize = True
        Me.lblLrg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLrg.Location = New System.Drawing.Point(134, 93)
        Me.lblLrg.Name = "lblLrg"
        Me.lblLrg.Size = New System.Drawing.Size(0, 13)
        Me.lblLrg.TabIndex = 48
        '
        'lblMed
        '
        Me.lblMed.AutoSize = True
        Me.lblMed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMed.Location = New System.Drawing.Point(134, 70)
        Me.lblMed.Name = "lblMed"
        Me.lblMed.Size = New System.Drawing.Size(0, 13)
        Me.lblMed.TabIndex = 47
        '
        'lblSml
        '
        Me.lblSml.AutoSize = True
        Me.lblSml.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSml.Location = New System.Drawing.Point(133, 47)
        Me.lblSml.Name = "lblSml"
        Me.lblSml.Size = New System.Drawing.Size(0, 13)
        Me.lblSml.TabIndex = 46
        '
        'cmbPizza
        '
        Me.cmbPizza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPizza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPizza.FormattingEnabled = True
        Me.cmbPizza.Location = New System.Drawing.Point(58, 18)
        Me.cmbPizza.Name = "cmbPizza"
        Me.cmbPizza.Size = New System.Drawing.Size(159, 21)
        Me.cmbPizza.TabIndex = 2
        '
        'btnAdd
        '
        Me.btnAdd.Enabled = False
        Me.btnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(134, 138)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(83, 24)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add To Order"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Pizza ID"
        '
        'txtSubtotal
        '
        Me.txtSubtotal.Enabled = False
        Me.txtSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSubtotal.Location = New System.Drawing.Point(58, 140)
        Me.txtSubtotal.Name = "txtSubtotal"
        Me.txtSubtotal.Size = New System.Drawing.Size(70, 20)
        Me.txtSubtotal.TabIndex = 44
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "Size"
        '
        'radSml
        '
        Me.radSml.AutoSize = True
        Me.radSml.Enabled = False
        Me.radSml.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radSml.Location = New System.Drawing.Point(58, 45)
        Me.radSml.Name = "radSml"
        Me.radSml.Size = New System.Drawing.Size(70, 17)
        Me.radSml.TabIndex = 3
        Me.radSml.TabStop = True
        Me.radSml.Text = "Small (7"")"
        Me.radSml.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Subtotal"
        '
        'radMed
        '
        Me.radMed.AutoSize = True
        Me.radMed.Enabled = False
        Me.radMed.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radMed.Location = New System.Drawing.Point(58, 68)
        Me.radMed.Name = "radMed"
        Me.radMed.Size = New System.Drawing.Size(82, 17)
        Me.radMed.TabIndex = 4
        Me.radMed.TabStop = True
        Me.radMed.Text = "Medium (9"")"
        Me.radMed.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 13)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Quantity"
        '
        'radLrg
        '
        Me.radLrg.AutoSize = True
        Me.radLrg.Enabled = False
        Me.radLrg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.radLrg.Location = New System.Drawing.Point(58, 91)
        Me.radLrg.Name = "radLrg"
        Me.radLrg.Size = New System.Drawing.Size(78, 17)
        Me.radLrg.TabIndex = 5
        Me.radLrg.TabStop = True
        Me.radLrg.Text = "Large (14"")"
        Me.radLrg.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(17, 8)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 13)
        Me.Label18.TabIndex = 73
        Me.Label18.Text = "Order ID"
        '
        'tabOrderView
        '
        Me.tabOrderView.Controls.Add(Me.lblOrder)
        Me.tabOrderView.Controls.Add(Me.Label22)
        Me.tabOrderView.Controls.Add(Me.Label21)
        Me.tabOrderView.Controls.Add(Me.Label20)
        Me.tabOrderView.Controls.Add(Me.lstPrevOrders)
        Me.tabOrderView.Controls.Add(Me.lstItems)
        Me.tabOrderView.Controls.Add(Me.Label19)
        Me.tabOrderView.Controls.Add(Me.lstOrders)
        Me.tabOrderView.Location = New System.Drawing.Point(4, 32)
        Me.tabOrderView.Name = "tabOrderView"
        Me.tabOrderView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOrderView.Size = New System.Drawing.Size(492, 357)
        Me.tabOrderView.TabIndex = 3
        Me.tabOrderView.Text = "My Orders"
        Me.tabOrderView.UseVisualStyleBackColor = True
        '
        'lblOrder
        '
        Me.lblOrder.AutoSize = True
        Me.lblOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrder.Location = New System.Drawing.Point(180, 20)
        Me.lblOrder.Name = "lblOrder"
        Me.lblOrder.Size = New System.Drawing.Size(38, 13)
        Me.lblOrder.TabIndex = 79
        Me.lblOrder.Text = "Order"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(5, 85)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(136, 13)
        Me.Label22.TabIndex = 78
        Me.Label22.Text = "ID      Date          Cost"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label21.Location = New System.Drawing.Point(4, 3)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(124, 13)
        Me.Label21.TabIndex = 77
        Me.Label21.Text = "Orders Being Processed:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label20.Location = New System.Drawing.Point(4, 69)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(85, 13)
        Me.Label20.TabIndex = 76
        Me.Label20.Text = "Previous Orders:"
        '
        'lstPrevOrders
        '
        Me.lstPrevOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPrevOrders.FormattingEnabled = True
        Me.lstPrevOrders.Location = New System.Drawing.Point(4, 98)
        Me.lstPrevOrders.Name = "lstPrevOrders"
        Me.lstPrevOrders.Size = New System.Drawing.Size(171, 69)
        Me.lstPrevOrders.TabIndex = 75
        '
        'lstItems
        '
        Me.lstItems.Enabled = False
        Me.lstItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstItems.FormattingEnabled = True
        Me.lstItems.Location = New System.Drawing.Point(181, 33)
        Me.lstItems.Name = "lstItems"
        Me.lstItems.Size = New System.Drawing.Size(307, 134)
        Me.lstItems.TabIndex = 74
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(5, 20)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(136, 13)
        Me.Label19.TabIndex = 73
        Me.Label19.Text = "ID      Date          Cost"
        '
        'lstOrders
        '
        Me.lstOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstOrders.FormattingEnabled = True
        Me.lstOrders.Location = New System.Drawing.Point(4, 33)
        Me.lstOrders.Name = "lstOrders"
        Me.lstOrders.Size = New System.Drawing.Size(171, 30)
        Me.lstOrders.TabIndex = 0
        '
        'tabAccount
        '
        Me.tabAccount.Controls.Add(Me.btnDelete)
        Me.tabAccount.Controls.Add(Me.btnEdit)
        Me.tabAccount.Controls.Add(Me.Label12)
        Me.tabAccount.Controls.Add(Me.txtPassword)
        Me.tabAccount.Controls.Add(Me.txtCustID)
        Me.tabAccount.Controls.Add(Me.txtForename)
        Me.tabAccount.Controls.Add(Me.txtSurname)
        Me.tabAccount.Controls.Add(Me.txtHouse)
        Me.tabAccount.Controls.Add(Me.txtCounty)
        Me.tabAccount.Controls.Add(Me.txtTel)
        Me.tabAccount.Controls.Add(Me.txtPostcode)
        Me.tabAccount.Controls.Add(Me.txtDistrict)
        Me.tabAccount.Controls.Add(Me.txtStreet)
        Me.tabAccount.Controls.Add(Me.txtTown)
        Me.tabAccount.Controls.Add(Me.Label10)
        Me.tabAccount.Controls.Add(Me.Label9)
        Me.tabAccount.Controls.Add(Me.Label8)
        Me.tabAccount.Controls.Add(Me.Label2)
        Me.tabAccount.Controls.Add(Me.Label11)
        Me.tabAccount.Controls.Add(Me.Label13)
        Me.tabAccount.Controls.Add(Me.Label14)
        Me.tabAccount.Controls.Add(Me.Label15)
        Me.tabAccount.Controls.Add(Me.Label16)
        Me.tabAccount.Controls.Add(Me.Label17)
        Me.tabAccount.Location = New System.Drawing.Point(4, 32)
        Me.tabAccount.Name = "tabAccount"
        Me.tabAccount.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAccount.Size = New System.Drawing.Size(492, 357)
        Me.tabAccount.TabIndex = 1
        Me.tabAccount.Text = "My Account"
        Me.tabAccount.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(164, 291)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(90, 23)
        Me.btnDelete.TabIndex = 77
        Me.btnDelete.Text = "Delete Account"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(260, 291)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(90, 23)
        Me.btnEdit.TabIndex = 76
        Me.btnEdit.Text = "Edit Details"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(172, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 75
        Me.Label12.Text = "Password"
        '
        'txtPassword
        '
        Me.txtPassword.Enabled = False
        Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(239, 30)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(127, 20)
        Me.txtPassword.TabIndex = 55
        '
        'txtCustID
        '
        Me.txtCustID.Enabled = False
        Me.txtCustID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustID.Location = New System.Drawing.Point(239, 4)
        Me.txtCustID.Name = "txtCustID"
        Me.txtCustID.Size = New System.Drawing.Size(127, 20)
        Me.txtCustID.TabIndex = 56
        '
        'txtForename
        '
        Me.txtForename.Enabled = False
        Me.txtForename.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtForename.Location = New System.Drawing.Point(239, 56)
        Me.txtForename.Name = "txtForename"
        Me.txtForename.Size = New System.Drawing.Size(127, 20)
        Me.txtForename.TabIndex = 58
        '
        'txtSurname
        '
        Me.txtSurname.Enabled = False
        Me.txtSurname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurname.Location = New System.Drawing.Point(239, 82)
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(127, 20)
        Me.txtSurname.TabIndex = 59
        '
        'txtHouse
        '
        Me.txtHouse.Enabled = False
        Me.txtHouse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHouse.Location = New System.Drawing.Point(239, 108)
        Me.txtHouse.Name = "txtHouse"
        Me.txtHouse.Size = New System.Drawing.Size(127, 20)
        Me.txtHouse.TabIndex = 62
        '
        'txtCounty
        '
        Me.txtCounty.Enabled = False
        Me.txtCounty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCounty.Location = New System.Drawing.Point(239, 212)
        Me.txtCounty.Name = "txtCounty"
        Me.txtCounty.Size = New System.Drawing.Size(127, 20)
        Me.txtCounty.TabIndex = 69
        '
        'txtTel
        '
        Me.txtTel.Enabled = False
        Me.txtTel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTel.Location = New System.Drawing.Point(239, 264)
        Me.txtTel.Name = "txtTel"
        Me.txtTel.Size = New System.Drawing.Size(127, 20)
        Me.txtTel.TabIndex = 74
        '
        'txtPostcode
        '
        Me.txtPostcode.Enabled = False
        Me.txtPostcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostcode.Location = New System.Drawing.Point(239, 238)
        Me.txtPostcode.Name = "txtPostcode"
        Me.txtPostcode.Size = New System.Drawing.Size(127, 20)
        Me.txtPostcode.TabIndex = 71
        '
        'txtDistrict
        '
        Me.txtDistrict.Enabled = False
        Me.txtDistrict.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDistrict.Location = New System.Drawing.Point(239, 160)
        Me.txtDistrict.Name = "txtDistrict"
        Me.txtDistrict.Size = New System.Drawing.Size(127, 20)
        Me.txtDistrict.TabIndex = 65
        '
        'txtStreet
        '
        Me.txtStreet.Enabled = False
        Me.txtStreet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStreet.Location = New System.Drawing.Point(239, 134)
        Me.txtStreet.Name = "txtStreet"
        Me.txtStreet.Size = New System.Drawing.Size(127, 20)
        Me.txtStreet.TabIndex = 64
        '
        'txtTown
        '
        Me.txtTown.Enabled = False
        Me.txtTown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTown.Location = New System.Drawing.Point(239, 186)
        Me.txtTown.Name = "txtTown"
        Me.txtTown.Size = New System.Drawing.Size(127, 20)
        Me.txtTown.TabIndex = 67
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(193, 215)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 13)
        Me.Label10.TabIndex = 73
        Me.Label10.Text = "County"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(135, 267)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 13)
        Me.Label9.TabIndex = 72
        Me.Label9.Text = "Telephone Number"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(181, 241)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(52, 13)
        Me.Label8.TabIndex = 70
        Me.Label8.Text = "Postcode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(199, 189)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Town"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(194, 163)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 13)
        Me.Label11.TabIndex = 66
        Me.Label11.Text = "District"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(198, 137)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(35, 13)
        Me.Label13.TabIndex = 63
        Me.Label13.Text = "Street"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(122, 111)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(111, 13)
        Me.Label14.TabIndex = 61
        Me.Label14.Text = "House Number/Name"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(184, 85)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 13)
        Me.Label15.TabIndex = 60
        Me.Label15.Text = "Surname"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(179, 59)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 13)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Forename"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(161, 7)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(76, 13)
        Me.Label17.TabIndex = 54
        Me.Label17.Text = "Customer ID"
        '
        'tabLogOut
        '
        Me.tabLogOut.Controls.Add(Me.btnLogOut)
        Me.tabLogOut.Controls.Add(Me.Label1)
        Me.tabLogOut.Location = New System.Drawing.Point(4, 32)
        Me.tabLogOut.Name = "tabLogOut"
        Me.tabLogOut.Size = New System.Drawing.Size(492, 357)
        Me.tabLogOut.TabIndex = 2
        Me.tabLogOut.Text = "Log Out"
        Me.tabLogOut.UseVisualStyleBackColor = True
        '
        'btnLogOut
        '
        Me.btnLogOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogOut.Location = New System.Drawing.Point(168, 31)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(155, 30)
        Me.btnLogOut.TabIndex = 1
        Me.btnLogOut.Text = "Yes, log me out."
        Me.btnLogOut.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(124, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(244, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Are you sure you want to log out?"
        '
        'frmUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(500, 438)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmUser"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Porky's Pizzeria"
        Me.TabControl1.ResumeLayout(False)
        Me.tabOrderAdd.ResumeLayout(False)
        Me.tabOrderAdd.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabOrderView.ResumeLayout(False)
        Me.tabOrderView.PerformLayout()
        Me.tabAccount.ResumeLayout(False)
        Me.tabAccount.PerformLayout()
        Me.tabLogOut.ResumeLayout(False)
        Me.tabLogOut.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tabOrderAdd As TabPage
    Friend WithEvents tabAccount As TabPage
    Friend WithEvents tabLogOut As TabPage
    Friend WithEvents btnLogOut As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtOrderID As TextBox
    Friend WithEvents btnOrder As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnRemove As Button
    Friend WithEvents lstOrder As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents txtQuantity As NumericUpDown
    Friend WithEvents lblLrg As Label
    Friend WithEvents lblMed As Label
    Friend WithEvents lblSml As Label
    Friend WithEvents cmbPizza As ComboBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents txtSubtotal As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents radSml As RadioButton
    Friend WithEvents Label6 As Label
    Friend WithEvents radMed As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents radLrg As RadioButton
    Friend WithEvents Label18 As Label
    Friend WithEvents tabOrderView As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtCustID As TextBox
    Friend WithEvents txtForename As TextBox
    Friend WithEvents txtSurname As TextBox
    Friend WithEvents txtHouse As TextBox
    Friend WithEvents txtCounty As TextBox
    Friend WithEvents txtTel As TextBox
    Friend WithEvents txtPostcode As TextBox
    Friend WithEvents txtDistrict As TextBox
    Friend WithEvents txtStreet As TextBox
    Friend WithEvents txtTown As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents lstOrders As ListBox
    Friend WithEvents Label19 As Label
    Friend WithEvents lstItems As ListBox
    Friend WithEvents Label20 As Label
    Friend WithEvents lstPrevOrders As ListBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents lblOrder As Label
End Class
