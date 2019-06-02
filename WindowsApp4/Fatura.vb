Friend Class Fatura
    Public Property NomePaciente As String
    Public Property CodigoSeguro As String
    Public Property CodigoFatura As String
    Public Property DataPagamento As String
    Public Property CustoFatura As String

    Overrides Function ToString() As String
        Return CodigoFatura
    End Function
End Class
