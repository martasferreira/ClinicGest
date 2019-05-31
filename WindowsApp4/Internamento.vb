Friend Class Internamento
    Public Property NumeroInternamento As Object
    Public Property CodigoServico As Object
    Public Property NomeServico As String
    Public Property CustoServico As String
    Public Property DataInicio As String
    Public Property DataFim As String
    Public Property Patologia As String


    Overrides Function ToString() As String
        Return NumeroInternamento
    End Function

End Class
