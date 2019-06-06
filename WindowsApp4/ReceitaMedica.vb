Friend Class ReceitaMedica
    Public Property NumeroReceita As Object
    Public Property NomePaciente As Object
    Public Property NumeroInternamento As String

    Overrides Function ToString() As String
        Return NumeroReceita
    End Function
End Class
