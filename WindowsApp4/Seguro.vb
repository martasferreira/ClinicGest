Friend Class Seguro
    Public Property NomeSeguro As String
    Public Property CodigoSeguro As String
    Public Property DescontoSeguro As String
    Public Property CodigoPaciente As String

    Overrides Function ToString() As String
        Return NomeSeguro
    End Function
End Class
