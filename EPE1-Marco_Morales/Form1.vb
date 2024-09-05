Imports Excel = Microsoft.Office.Interop.Excel
Public Class Form1
    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim ExcelApp As New Excel.Application()

        Dim excelWorkbook As Excel.Workbook = ExcelApp.Workbooks.Open("C:\Users\usuario\Desktop\PUNTO NET\Lista.xls")
        Dim excelWorksheet As Excel.Worksheet = excelWorkbook.Sheets(1)
        Dim excelRange As Excel.Range = excelWorksheet.UsedRange

        cmbProductos.Items.Clear()
        For i As Integer = 2 To excelRange.Rows.Count
            Dim nombreProducto As String = excelRange.Cells(i, 1).Value
            cmbProductos.Items.Add(nombreProducto)
        Next
        excelWorkbook.Close()
        ExcelApp.Quit()

        btnCargar.Enabled = False
    End Sub

    Private Sub cmbProductos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductos.SelectedIndexChanged
        Dim excelApp As New Excel.Application()
        Dim excelWorkbook As Excel.Workbook = Nothing
        Try
            excelWorkbook = excelApp.Workbooks.Open("C:\Users\usuario\Desktop\PUNTO NET\Lista.xls")
            Dim excelWorksheet As Excel.Worksheet = excelWorkbook.Sheets(1)
            Dim excelRange As Excel.Range = excelWorksheet.UsedRange

            For i As Integer = 2 To excelRange.Rows.Count
                If cmbProductos.SelectedItem.ToString() = excelRange.Cells(i, 1).Value Then
                    txtDescripcion.Text = excelRange.Cells(i, 2).Value.ToString()
                    txtPrecio.Text = excelRange.Cells(i, 6).Value.ToString()
                    txtStock.Text = excelRange.Cells(i, 7).Value.ToString()
                    MessageBox.Show("Datos ingresados correctamente", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    Exit For
                End If
            Next

        Catch ex As Exception
            MessageBox.Show("Error al abrir el archivo: " & ex.Message)
        Finally

            If excelWorkbook IsNot Nothing Then
                excelWorkbook.Close()
            End If
            excelApp.Quit()
        End Try
    End Sub
End Class