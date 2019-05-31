Friend Class Servico
    Public Property CodigoServico As Object
    Public Property NomeServico As Object
    Public Property Custo As String
    Public Property MedicoResponsavel As String
    Public Property EnfermeiroResponsavel As String


    Overrides Function ToString() As String
        Return CodigoServico & "   " & NomeServico
    End Function
End Class
