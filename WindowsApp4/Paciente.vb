﻿Friend Class Paciente
    Public Property Nome As String
    Public Property Codigo As String
    Public Property CC As String
    Public Property DataDeNascimento As Date
    Public Property Email As String
    Public Property Sexo As String
    Public Property Endereço As String
    Public Property CodigoPostal As String
    Public Property Nacionalidade As String
    Public Property Telemovel As String
    Public Property Telefone As String

    Overrides Function ToString() As String
        Return Nome
    End Function

End Class


