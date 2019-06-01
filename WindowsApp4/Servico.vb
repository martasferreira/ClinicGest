Friend Class Servico
    Public Property CodigoServico As String
    Public Property NomeServico As String
    Public Property Custo As String
    Public Property MedicoResponsavel As String
    Public Property EnfermeiroResponsavel As String


    Overrides Function ToString() As String
        Return CodigoServico & "   " & NomeServico
    End Function
End Class
