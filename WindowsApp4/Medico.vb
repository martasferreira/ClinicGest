Friend Class Medico
    Public Property Nome As Object
    Public Property Codigo As Object
    Public Property Especialidade As String
    Public Property CC As String
    Public Property DataDeNascimento As String
    Public Property Email As String
    Public Property Sexo As String
    Public Property CodigoPostal As String
    Public Property Nacionalidade As String
    Public Property Telemovel As String
    Public Property Telefone As String
    Public Property Endereço As String


    Overrides Function ToString() As String
        Return Nome
    End Function

End Class
