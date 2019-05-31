Friend Class Medicamento
    Public Property Nome As Object
    Public Property Codigo As Object
    Public Property Custo As String


    Overrides Function ToString() As String
        Return Nome
    End Function
End Class
