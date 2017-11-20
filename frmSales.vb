Public Class frmSales
    'Declare global variable
    Dim SelectedDate As Date = Date.Today()

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'Store selected date from DateTimePicker in variable
        SelectedDate = DateTimePicker1.Value.Date()
        'Reload form
        Call frmSales_Load(Me, e)
    End Sub

    Private Sub frmSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declare variables and set up paths to files
        Dim PizzaFile As String = Application.StartupPath & "\pizzas.dat" 'File 1
        Dim POFile As String = Application.StartupPath & "\pizzaOrdered.dat" 'File 2
        Dim OrdersFile As String = Application.StartupPath & "\orders.dat" 'File 3
        Dim RecPos As Integer
        Dim NumRecs As Integer
        Dim PORecPos As Integer
        Dim PONumRecs As Integer
        Dim OrdersNumRecs As Integer
        Dim OrdersRecPos As Integer
        Dim NumPizzasFound As Integer
        Dim Subtotal As Decimal
        Dim TotalPizzas As Integer
        Dim TotalOrders As Integer
        Dim TotalRevenue As Decimal

        'Clear list box and add title
        lstPizza.Items.Clear()
        lstPizza.Items.Add("Sales Data For " & SelectedDate & ":")
        lstPizza.Items.Add("")


        'Open the customers file in random access mode
        FileOpen(1, PizzaFile, OpenMode.Random, , , Len(PizzaRec))
        'Calculate the number of records in the file
        NumRecs = LOF(1) / Len(PizzaRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Set NumPizzasFound and Subtotal to 0
            NumPizzasFound = 0
            Subtotal = 0

            'Read the record from the file
            FileGet(1, PizzaRec, RecPos)
            'If the pizza hasn't been deleted
            If PizzaRec.PizzaID > 0 Then
                'Open Orders File in random access mode
                FileOpen(3, OrdersFile, OpenMode.Random, , , Len(OrdersRec))
                'Calculate number of records in orders file
                OrdersNumRecs = LOF(3) / Len(OrdersRec)
                'For each record in orders file
                For OrdersRecPos = 1 To OrdersNumRecs
                    'Read in record from file
                    FileGet(3, OrdersRec, OrdersRecPos)
                    'If Order Date in record is today's date
                    If OrdersRec.OrderDate = SelectedDate Then
                        'Open Pizza Ordered file in random access mode
                        FileOpen(2, POFile, OpenMode.Random, , , Len(PORec))
                        'Calculate number of records in the file
                        PONumRecs = LOF(2) / Len(PORec)
                        'For each record in the file
                        For PORecPos = 1 To PONumRecs
                            'Read in the record from file
                            FileGet(2, PORec, PORecPos)
                            'If the Pizza ID in the POFile record matches the pizza ID in the PizzaFile record
                            If PORec.PizzaID = PizzaRec.PizzaID And PORec.OrderID = OrdersRec.OrderID Then
                                'Increase Number of Pizzas Found by the quantity in the order
                                NumPizzasFound = NumPizzasFound + PORec.Quantity
                                TotalPizzas = TotalPizzas + PORec.Quantity
                                'Add cost of pizza in the order to the Subtotal
                                Subtotal = Subtotal + PORec.Subtotal
                            End If
                            'Move on to next record
                        Next
                        'Close POFile 
                        FileClose(2)
                    End If
                    'Move on to next record in file
                Next
                'Close Orders File
                FileClose(3)
                'Add pizza's sales details to the list box
                lstPizza.Items.Add(UCase(PizzaRec.PizzaName))
                lstPizza.Items.Add("Sold: " & NumPizzasFound & "    Revenue: " & FormatCurrency(Subtotal))
            End If
        Next
        'Close Pizza File
        FileClose(1)

        'Open Orders File in random access mode
        FileOpen(3, OrdersFile, OpenMode.Random, , , Len(OrdersRec))
        'Calculate number of records in file
        NumRecs = LOF(3) / Len(OrdersRec)
        'For each record in the file
        For RecPos = 1 To NumRecs
            'Read in the record from file
            FileGet(3, OrdersRec, RecPos)
            'If OrderID > 0 (i.e. not marked for deletion)
            If OrdersRec.OrderDate = SelectedDate Then
                'Add the cost of the order to the Total Revenue
                TotalRevenue = TotalRevenue + OrdersRec.Total
                'Increase total number of orders by 1
                TotalOrders = TotalOrders + 1
            End If
            'Move on to next record in file
        Next
        'Close File
        FileClose(3)

        'Add deliveries details to the list box
        lstPizza.Items.Add("DELIVERIES:")
        lstPizza.Items.Add("Sold: " & TotalOrders & "    Revenue: " & FormatCurrency(TotalOrders * 1.5))
        'Add a blank space to the list box
        lstPizza.Items.Add("")
        'Add total sales data to the list box
        lstPizza.Items.Add("TOTAL NUMBER OF ORDERS: " & TotalOrders)
        lstPizza.Items.Add("TOTAL NUMBER OF PIZZAS SOLD: " & TotalPizzas)
        lstPizza.Items.Add("TOTAL REVENUE: " & FormatCurrency(TotalRevenue))
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        'Close the current form and show the Admin form
        frmAdmin.Show()
        Me.Close()
    End Sub
End Class