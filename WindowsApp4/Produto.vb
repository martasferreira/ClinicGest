Friend Class Produto
    Public Property CodigoProduto As String
    Public Property TipoProduto As String
    Public Property Custo As String
    Public Property CustoLimpeza As String

    Overrides Function ToString() As String
        Return CodigoProduto
    End Function
End Class
