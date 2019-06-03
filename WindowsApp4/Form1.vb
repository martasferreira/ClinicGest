Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Imports WindowsApp4

Public Class Form1

    Private Const connectionString = "Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101;Initial Catalog=p4g9;User ID=p4g9;Password=ClinicG3st;Connection Timeout=50;"
    Dim CN As SqlConnection
    Dim currentPaciente As Integer
    Dim adding As Boolean
    Dim currentMedico As Integer
    Dim currentEnfermeiro As Integer
    Dim currentInternamento As Integer
    Dim currentIntervencao As Integer
    Dim currentServico As Integer
    Dim currentMedicamento As Integer
    Dim currentFatura As Integer
    Dim currentProdutoIntervencao As Integer
    Dim currentFaturasPaciente As Integer
    Dim currentInternamentoPaciente As Integer
    Dim currentIntervencaoPaciente As Integer
    Dim currentProdutoIntervencaoPaciente As Integer
    Dim currentSeguroPaciente As Integer
    Dim currentMedicoServico As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'nao sei o que é para escrever

        ShowButtonsPaciente()
        ShowButtonsMedico()
        ShowButtonsEnfermeiro()
        ShowButtonsMedicamento()

        CN = New SqlConnection(connectionString)
        TerPacientes()
        TerMedicos()
        TerEnfermeiros()
        TerInternamentos()
        TerFaturas()
        TerServiços()
        TerMedicamentos()

    End Sub

#Region "Show Buttons"

    Private Sub ShowButtonsPaciente()
        LockControlsPaciente()
        btnAddPaciente.Visible = True
        btnEditPaciente.Visible = True
        btnOkPaciente.Visible = False
        btnCancelPaciente.Visible = False

        btnListFaturasPaciente.Visible = True
        btnListSegurosPaciente.Visible = True
        btnListInternamentosPaciente.Visible = True
    End Sub

    Private Sub ShowButtonsMedico()
        LockControlsMedico()
        btnAddMedico.Visible = True
        btnEditMedico.Visible = True
        btnOkMedico.Visible = False
        btnCancelMedico.Visible = False

        btnListInternamentosMedico.Visible = True
        btnListIntervencoesMedico.Visible = True
        btnListServicosMedico.Visible = True
    End Sub

    Private Sub ShowButtonsEnfermeiro()
        LockControlsEnfermeiro()
        btnAddEnfermeiro.Visible = True
        btnEditEnfermeiro.Visible = True
        btnOkEnfermeiro.Visible = False
        btnCancelEnfermeiro.Visible = False

        btnListInternamentosEnfermeiro.Visible = True
        btnListIntervencoesEnfermeiro.Visible = True
        btnListReceitasExecEnfermeiro.Visible = True
    End Sub

    Private Sub ShowButtonsMedicamento()
        LockControlsMedicamento()
        btnAddMedicamento.Visible = True
        btnEditMedicamento.Visible = True
        btnOkMedicamento.Visible = False
        btnCancelMedicamento.Visible = False
    End Sub

#End Region

#Region "Hide Buttons"

    Private Sub HideButtonsPaciente()
        UnLockControlsPaciente()
        btnAddPaciente.Visible = False
        btnEditPaciente.Visible = False
        btnOkPaciente.Visible = True
        btnCancelPaciente.Visible = True

        btnListFaturasPaciente.Visible = False
        btnListSegurosPaciente.Visible = False
        btnListInternamentosPaciente.Visible = False
    End Sub

    Private Sub HideButtonsMedico()
        UnLockControlsMedico()
        btnAddMedico.Visible = False
        btnEditMedico.Visible = False
        btnOkMedico.Visible = True
        btnCancelMedico.Visible = True

        btnListInternamentosMedico.Visible = False
        btnListIntervencoesMedico.Visible = False
        btnListServicosMedico.Visible = False
    End Sub

    Private Sub HideButtonsEnfermeiro()
        UnLockControlsEnfermeiro()
        btnAddEnfermeiro.Visible = False
        btnEditEnfermeiro.Visible = False
        btnOkEnfermeiro.Visible = True
        btnCancelEnfermeiro.Visible = True

        btnListInternamentosEnfermeiro.Visible = False
        btnListIntervencoesEnfermeiro.Visible = False
        btnListReceitasExecEnfermeiro.Visible = False

    End Sub

    Private Sub HideButtonsMedicamento()
        UnlockControlsMedicamento()
        btnAddMedicamento.Visible = False
        btnEditMedicamento.Visible = False
        btnOkMedicamento.Visible = True
        btnCancelMedicamento.Visible = True
    End Sub

#End Region

#Region "Add To List"

    Private Sub TerPacientes()
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.Pessoa " &
            "JOIN ClinicGest.Paciente ON Pessoa.cc = Paciente.cc_pac"
        }
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListPacientes.Items.Clear()
        While RDR.Read
            Dim P As New Paciente
            P.Nome = RDR.Item("nome")
            P.Codigo = RDR.Item("codigo_pac")
            P.CC = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("cc")), "", RDR.Item("cc")))
            P.DataDeNascimento = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_nasc")), "", RDR.Item("data_nasc")))
            P.Email = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("email")), "", RDR.Item("email")))
            P.Sexo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("sexo")), "", RDR.Item("sexo")))
            P.Endereço = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("endereco")), "", RDR.Item("endereco")))
            P.CodigoPostal = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigopostal")), "", RDR.Item("codigopostal")))
            P.Nacionalidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nacionalidade")), "", RDR.Item("nacionalidade")))
            P.Telemovel = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telemovel")), "", RDR.Item("telemovel")))
            P.Telefone = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telefone")), "", RDR.Item("telefone")))

            ListPacientes.Items.Add(P)
        End While
        CN.Close()
        currentPaciente = 0
        ShowPaciente()

    End Sub

    Private Sub TerEnfermeiros()
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * from ClinicGest.Pessoa AS pessoa " &
            "JOIN ClinicGest.Staff AS staff ON pessoa.cc = staff.cc_staff " &
            "JOIN ClinicGest.Enfermeiro AS enfermeiro ON staff.codigo_staff = enfermeiro.codigo_staff"
        }
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListEnfermeiros.Items.Clear()
        While RDR.Read
            Dim M As New Enfermeiro
            M.Nome = RDR.Item("nome")
            M.Codigo = RDR.Item("codigo_enf")
            M.CC = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("cc")), "", RDR.Item("cc")))
            M.DataDeNascimento = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_nasc")), "", RDR.Item("data_nasc")))
            M.Email = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("email")), "", RDR.Item("email")))
            M.Sexo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("sexo")), "", RDR.Item("sexo")))
            M.Endereço = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("endereco")), "", RDR.Item("endereco")))
            M.CodigoPostal = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigopostal")), "", RDR.Item("codigopostal")))
            M.Nacionalidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nacionalidade")), "", RDR.Item("nacionalidade")))
            M.Telemovel = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telemovel")), "", RDR.Item("telemovel")))
            M.Telefone = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telefone")), "", RDR.Item("telefone")))
            M.Salario = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("salario")), "", RDR.Item("salario")))

            ListEnfermeiros.Items.Add(M)
        End While
        CN.Close()
        currentEnfermeiro = 0
        ShowEnfermeiro()

    End Sub

    Private Sub TerMedicos()

        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * from ClinicGest.Pessoa AS pessoa " &
            "JOIN ClinicGest.Staff AS staff ON pessoa.cc = staff.cc_staff " &
            "JOIN ClinicGest.Medico AS medico ON staff.codigo_staff = medico.codigo_staff"
        }
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListMedicos.Items.Clear()
        While RDR.Read
            Dim M As New Medico
            M.Nome = RDR.Item("nome")
            M.Codigo = RDR.Item("codigo_med")
            M.Especialidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("especialidade")), "", RDR.Item("especialidade")))
            M.CC = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("cc")), "", RDR.Item("cc")))
            M.DataDeNascimento = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_nasc")), "", RDR.Item("data_nasc")))
            M.Email = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("email")), "", RDR.Item("email")))
            M.Sexo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("sexo")), "", RDR.Item("sexo")))
            M.Endereço = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("endereco")), "", RDR.Item("endereco")))
            M.CodigoPostal = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigopostal")), "", RDR.Item("codigopostal")))
            M.Nacionalidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nacionalidade")), "", RDR.Item("nacionalidade")))
            M.Telemovel = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telemovel")), "", RDR.Item("telemovel")))
            M.Telefone = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telefone")), "", RDR.Item("telefone")))
            M.Salario = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("salario")), "", RDR.Item("salario")))

            ListMedicos.Items.Add(M)
        End While
        CN.Close()
        currentMedico = 0
        ShowMedico()

    End Sub

    Private Sub TerMedicamentos()

        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.Medicamento"
        }
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListMedicamentos.Items.Clear()
        While RDR.Read
            Dim M As New Medicamento
            M.Codigo = RDR.Item("codigo_medicamento")
            M.Nome = RDR.Item("nome")
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("preco_unitario")), "", RDR.Item("preco_unitario")))
            ListMedicamentos.Items.Add(M)
        End While
        CN.Close()
        currentMedicamento = 0
        ShowMedicamento()

    End Sub

    Private Sub TerServiços()

        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.Servico "
        }
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListServicos.Items.Clear()
        While RDR.Read
            Dim M As New Servico
            M.CodigoServico = RDR.Item("codigo_servico")
            M.NomeServico = RDR.Item("nome")
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            M.MedicoResponsavel = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("medico_responsavel")), "", RDR.Item("medico_responsavel")))
            M.EnfermeiroResponsavel = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("enfermeiro_responsavel")), "", RDR.Item("enfermeiro_responsavel")))
            ListServicos.Items.Add(M)
        End While
        CN.Close()
        currentServico = 0
        ShowServico()

    End Sub

    Private Sub TerInternamentos()

        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT Servico.codigo_servico as codigoServico, Servico.nome as nomeServico,Pessoa.nome as nomePessoa, num_internamento, custo, data_entrada, data_saida, patologia FROM ClinicGest.Internamento AS internamento " &
            "JOIN ClinicGest.Servico AS servico ON internamento.codigo_servico = servico.codigo_servico " &
            "JOIN ClinicGest.Paciente as paciente on internamento.codigo_pac = paciente.codigo_pac " &
            "JOIN ClinicGest.Pessoa as pessoa on paciente.cc_pac = pessoa.cc"
        }
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListInternamentos.Items.Clear()
        While RDR.Read
            Dim M As New Internamento
            M.NumeroInternamento = RDR.Item("num_internamento")
            M.CodigoServico = RDR.Item("codigoServico")
            M.NomeServico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nomeServico")), "", RDR.Item("nomeServico")))
            M.NomePaciente = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nomePessoa")), "", RDR.Item("nomePessoa")))
            M.CustoServico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            M.DataInicio = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_entrada")), "", RDR.Item("data_entrada")))
            M.DataFim = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_saida")), "", RDR.Item("data_saida")))
            M.Patologia = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("patologia")), "", RDR.Item("patologia")))

            ListInternamentos.Items.Add(M)
        End While
        CN.Close()
        currentInternamento = 0
        ShowInternamento()

    End Sub

    Private Sub TerIntervencoesInternamento()

        If ListInternamentos.Items.Count = 0 Or currentInternamento < 0 Then Exit Sub
        Dim internamento As New Internamento
        internamento = CType(ListInternamentos.Items.Item(currentInternamento), Internamento)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.Intervencao WHERE num_internamento = @internamento"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@internamento", internamento.NumeroInternamento)
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListIntervencoes.Items.Clear()
        While RDR.Read
            Dim M As New Intervencao
            M.NumeroInternamento = RDR.Item("num_internamento")
            M.NumeroIntervencao = RDR.Item("num_intervencao")
            M.CodigoStaff = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo_staff")), "", RDR.Item("codigo_staff")))
            ListIntervencoes.Items.Add(M)
        End While
        CN.Close()
        currentIntervencao = 0
        ShowIntervencaoInternamento()

    End Sub

    Private Sub TerProdutosIntervencao()

        If ListIntervencoes.Items.Count = 0 Or currentIntervencao < 0 Then Exit Sub
        Dim intervencao As New Intervencao
        intervencao = CType(ListIntervencoes.Items.Item(currentIntervencao), Intervencao)

        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.ProdutoIntervencao gp " &
            "RIGHT JOIN ClinicGest.Produto p ON gp.codigo_produto = p.codigo_produto " &
            "WHERE gp.numero_intervencao = @intervencao"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@intervencao", intervencao.NumeroIntervencao)
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListProdutosIntervencao.Items.Clear()
        While RDR.Read
            Dim M As New Produto
            M.CodigoProduto = RDR.Item("codigo_produto")
            M.TipoProduto = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("tipo_produto")), "", RDR.Item("tipo_produto")))
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            M.CustoLimpeza = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo_de_limp")), "", RDR.Item("custo_de_limp")))
            M.Quantidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("quantidade")), "", RDR.Item("quantidade")))
            ListProdutosIntervencao.Items.Add(M)
        End While
        CN.Close()
        currentProdutoIntervencao = 0
        ShowProdutoIntervencao()

    End Sub



    Private Sub TerFaturas()
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.Fatura as Fatura Join  ClinicGest.Paciente as Paciente on Fatura.fatura_paciente = Paciente.codigo_pac Join ClinicGest.Pessoa as Pessoa on  Paciente.cc_pac = Pessoa.cc"
        }
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListFaturas.Items.Clear()
        While RDR.Read
            Dim P As New Fatura
            P.NomePaciente = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            P.CodigoSeguro = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo_seguro")), "", RDR.Item("codigo_seguro")))
            P.CodigoFatura = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("num_fatura")), "", RDR.Item("num_fatura")))
            P.CustoFatura = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            P.DataPagamento = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_pagamento")), "", RDR.Item("data_pagamento")))

            ListFaturas.Items.Add(P)
        End While
        CN.Close()
        currentFatura = 0
        ShowFatura()

    End Sub

    Private Sub TerFaturasPaciente()

        If ListPacientes.Items.Count = 0 Or currentPaciente < 0 Then Exit Sub
        Dim paciente As New Paciente
        paciente = CType(ListPacientes.Items.Item(currentPaciente), Paciente)


        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.Fatura as Fatura Join  ClinicGest.Paciente as Paciente on Fatura.fatura_paciente = Paciente.codigo_pac Join ClinicGest.Pessoa as Pessoa on  Paciente.cc_pac = Pessoa.cc where codigo_pac = @paciente"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@paciente", paciente.Codigo)
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListFaturasPaciente.Items.Clear()
        While RDR.Read
            Dim P As New Fatura
            P.NomePaciente = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            P.CodigoSeguro = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo_seguro")), "", RDR.Item("codigo_seguro")))
            P.CodigoFatura = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("num_fatura")), "", RDR.Item("num_fatura")))
            P.CustoFatura = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            P.DataPagamento = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_pagamento")), "", RDR.Item("data_pagamento")))

            ListFaturasPaciente.Items.Add(P)
        End While
        CN.Close()
        currentFaturasPaciente = 0
        ShowFaturasPaciente()

    End Sub

    Private Sub TerInternamentosPaciente()

        If ListPacientes.Items.Count = 0 Or currentPaciente < 0 Then Exit Sub
        Dim paciente As New Paciente
        paciente = CType(ListPacientes.Items.Item(currentPaciente), Paciente)


        Dim cmd = New SqlCommand With {
           .Connection = CN,
           .CommandText = "SELECT Servico.codigo_servico as codigoServico, Servico.nome as nomeServico,Pessoa.nome as nomePessoa, num_internamento, custo, data_entrada, data_saida, patologia FROM ClinicGest.Internamento AS internamento " &
           "JOIN ClinicGest.Servico AS servico ON internamento.codigo_servico = servico.codigo_servico " &
           "JOIN ClinicGest.Paciente as paciente on internamento.codigo_pac = paciente.codigo_pac " &
           "JOIN ClinicGest.Pessoa as pessoa on paciente.cc_pac = pessoa.cc where internamento.codigo_pac = @paciente_codigo"
       }
        CN.Open()
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@paciente_codigo", paciente.Codigo)
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListInternamentosPaciente.Items.Clear()
        While RDR.Read
            Dim M As New Internamento
            M.NumeroInternamento = RDR.Item("num_internamento")
            M.CodigoServico = RDR.Item("codigoServico")
            M.NomeServico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nomeServico")), "", RDR.Item("nomeServico")))
            M.NomePaciente = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nomePessoa")), "", RDR.Item("nomePessoa")))
            M.CustoServico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            M.DataInicio = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_entrada")), "", RDR.Item("data_entrada")))
            M.DataFim = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_saida")), "", RDR.Item("data_saida")))
            M.Patologia = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("patologia")), "", RDR.Item("patologia")))

            ListInternamentosPaciente.Items.Add(M)
        End While
        CN.Close()
        currentInternamentoPaciente = 0
        ShowInternamentoPaciente()


    End Sub

    Private Sub TerIntervencoesInternamentoPaciente()

        If ListInternamentosPaciente.Items.Count = 0 Or currentInternamentoPaciente < 0 Then Exit Sub
        Dim internamento As New Internamento
        internamento = CType(ListInternamentosPaciente.Items.Item(currentInternamentoPaciente), Internamento)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.Intervencao WHERE num_internamento = @internamento"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@internamento", internamento.NumeroInternamento)
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListIntervencaoPaciente.Items.Clear()
        While RDR.Read
            Dim M As New Intervencao
            M.NumeroInternamento = RDR.Item("num_internamento")
            M.NumeroIntervencao = RDR.Item("num_intervencao")
            M.CodigoStaff = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo_staff")), "", RDR.Item("codigo_staff")))
            ListIntervencaoPaciente.Items.Add(M)
        End While
        CN.Close()
        currentIntervencaoPaciente = 0
        ShowIntervencaoInternamentoPaciente()

    End Sub

    Private Sub TerProdutosIntervencaoPaciente()

        If ListIntervencaoPaciente.Items.Count = 0 Or currentIntervencaoPaciente < 0 Then Exit Sub
        Dim intervencao As New Intervencao
        intervencao = CType(ListIntervencaoPaciente.Items.Item(currentIntervencaoPaciente), Intervencao)

        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "SELECT * FROM ClinicGest.ProdutoIntervencao gp " &
            "RIGHT JOIN ClinicGest.Produto p ON gp.codigo_produto = p.codigo_produto " &
            "WHERE gp.numero_intervencao = @intervencao"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@intervencao", intervencao.NumeroIntervencao)
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListProdutosIntervencaoPaciente.Items.Clear()
        While RDR.Read
            Dim M As New Produto
            M.CodigoProduto = RDR.Item("codigo_produto")
            M.TipoProduto = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("tipo_produto")), "", RDR.Item("tipo_produto")))
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            M.CustoLimpeza = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo_de_limp")), "", RDR.Item("custo_de_limp")))
            M.Quantidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("quantidade")), "", RDR.Item("quantidade")))
            ListProdutosIntervencaoPaciente.Items.Add(M)
        End While
        CN.Close()
        currentProdutoIntervencaoPaciente = 0
        ShowProdutoIntervencaoPaciente()

    End Sub

    Private Sub TerSegurosPaciente()

        If ListPacientes.Items.Count = 0 Or currentPaciente < 0 Then Exit Sub
        Dim paciente As New Paciente
        paciente = CType(ListPacientes.Items.Item(currentPaciente), Paciente)


        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "Select * from ClinicGest.TemSeguro as temseguro join ClinicGest.Seguro as seguro on temseguro.cod_seguro = seguro.codigo_seguro where  cod_paciente = @paciente"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@paciente", paciente.Codigo)
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListSegurosPaciente.Items.Clear()
        While RDR.Read
            Dim P As New Seguro
            P.NomeSeguro = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("entidade")), "", RDR.Item("entidade")))
            P.CodigoSeguro = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigo_seguro")), "", RDR.Item("codigo_seguro")))
            P.DescontoSeguro = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("desconto")), "", RDR.Item("desconto")))
            P.CodigoPaciente = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("cod_paciente")), "", RDR.Item("cod_paciente")))

            ListSegurosPaciente.Items.Add(P)
        End While
        CN.Close()
        currentSeguroPaciente = 0
        ShowSegurosPaciente()

    End Sub

    Private Sub TerMedicosServico()

        If ListServicos.Items.Count = 0 Or currentServico < 0 Then Exit Sub
        Dim servico As New Servico
        servico = CType(ListServicos.Items.Item(currentServico), Servico)


        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "Select * from ClinicGest.Medicoemservico as medicoemservico 
            join ClinicGest.Medico as Medico on medicoemservico.codigo_med = Medico.codigo_med 
            join clinicGest.Staff as Staff on Staff.codigo_staff = Medico.codigo_staff 
            join ClinicGest.Pessoa as pessoa on Staff.cc_staff = pessoa.cc where codigo_servico = @servico"
        }

        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@servico", servico.CodigoServico)
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = cmd.ExecuteReader
        ListMedicosServico.Items.Clear()
        While RDR.Read
            Dim M As New Medico
            M.Nome = RDR.Item("nome")
            M.Codigo = RDR.Item("codigo_med")
            M.Especialidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("especialidade")), "", RDR.Item("especialidade")))
            M.CC = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("cc")), "", RDR.Item("cc")))
            M.DataDeNascimento = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_nasc")), "", RDR.Item("data_nasc")))
            M.Email = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("email")), "", RDR.Item("email")))
            M.Sexo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("sexo")), "", RDR.Item("sexo")))
            M.Endereço = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("endereco")), "", RDR.Item("endereco")))
            M.CodigoPostal = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("codigopostal")), "", RDR.Item("codigopostal")))
            M.Nacionalidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nacionalidade")), "", RDR.Item("nacionalidade")))
            M.Telemovel = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telemovel")), "", RDR.Item("telemovel")))
            M.Telefone = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telefone")), "", RDR.Item("telefone")))
            M.Salario = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("salario")), "", RDR.Item("salario")))

            ListMedicosServico.Items.Add(M)
        End While
        CN.Close()
        currentMedicoServico = 0
        ShowMedicoServico()

    End Sub


#End Region

#Region "Show Element"

    Private Sub ShowPaciente()
        If ListPacientes.Items.Count = 0 Or currentPaciente < 0 Then Exit Sub
        Dim paciente As New Paciente
        paciente = CType(ListPacientes.Items.Item(currentPaciente), Paciente)
        NomePaciente.Text = paciente.Nome
        TelemovelPaciente.Text = paciente.Telemovel
        CcPaciente.Text = paciente.CC
        EmailPaciente.Text = paciente.Email
        EnderecoPaciente.Text = paciente.Endereço
        NacionalidadePaciente.Text = paciente.Nacionalidade
        TelefonePaciente.Text = paciente.Telefone
        DataPaciente.Text = paciente.DataDeNascimento
        SexoPaciente.Text = paciente.Sexo
        CodigoPaciente.Text = paciente.Codigo
        CodPostalPaciente.Text = paciente.CodigoPostal

    End Sub

    Private Sub ShowEnfermeiro()

        If ListEnfermeiros.Items.Count = 0 Or currentEnfermeiro < 0 Then Exit Sub
        Dim enfermeiro As New Enfermeiro
        enfermeiro = CType(ListEnfermeiros.Items.Item(currentEnfermeiro), Enfermeiro)
        NomeEnfermeiro.Text = enfermeiro.Nome
        TelemovelEnfermeiro.Text = enfermeiro.Telemovel
        CcEnfermeiro.Text = enfermeiro.CC
        EmailEnfermeiro.Text = enfermeiro.Email
        EnderecoEnfermeiro.Text = enfermeiro.Endereço
        NacionalidadeEnfermeiro.Text = enfermeiro.Nacionalidade
        TelefoneEnfermeiro.Text = enfermeiro.Telefone
        DataEnfermeiro.Text = enfermeiro.DataDeNascimento
        SexoEnfermeiro.Text = enfermeiro.Sexo
        CodigoEnfermeiro.Text = enfermeiro.Codigo
        CodPostalEnfermeiro.Text = enfermeiro.CodigoPostal
        SalarioEnfermeiro.Text = enfermeiro.Salario

    End Sub

    Private Sub ShowMedico()

        If ListMedicos.Items.Count = 0 Or currentMedico < 0 Then Exit Sub
        Dim medico As New Medico
        medico = CType(ListMedicos.Items.Item(currentMedico), Medico)
        NomeMedico.Text = medico.Nome
        EspecialidadeMedico.Text = medico.Especialidade
        TelemovelMedico.Text = medico.Telemovel
        CcMedico.Text = medico.CC
        EmailMedico.Text = medico.Email
        EnderecoMedico.Text = medico.Endereço
        NacionalidadeMedico.Text = medico.Nacionalidade
        TelefoneMedico.Text = medico.Telefone
        DataMedico.Text = medico.DataDeNascimento
        SexoMedico.Text = medico.Sexo
        CodigoMedico.Text = medico.Codigo
        CodPostalMedico.Text = medico.CodigoPostal
        SalarioMedico.Text = medico.Salario

    End Sub

    Private Sub ShowInternamento()

        If ListInternamentos.Items.Count = 0 Or currentInternamento < 0 Then Exit Sub
        Dim internamento As New Internamento
        internamento = CType(ListInternamentos.Items.Item(currentInternamento), Internamento)
        NumeroInternameto.Text = internamento.NumeroInternamento
        CodigoServicoInternamento.Text = internamento.CodigoServico
        NomePacienteInternamento.Text = internamento.NomePaciente
        NomeServicoInternamento.Text = internamento.NomeServico
        CustoServicoInternamento.Text = internamento.CustoServico
        DataInicioInternamento.Text = internamento.DataInicio
        DataFimInternamento.Text = internamento.DataFim
        PatologiaInternamento.Text = internamento.Patologia

    End Sub

    Private Sub ShowIntervencaoInternamento()

        If ListIntervencoes.Items.Count = 0 Or currentIntervencao < 0 Then Exit Sub
        Dim intervencao As New Intervencao
        intervencao = CType(ListIntervencoes.Items.Item(currentIntervencao), Intervencao)
        NumeroIntervencao.Text = intervencao.NumeroInternamento
        NumInternamentoIntervencao.Text = intervencao.NumeroIntervencao
        CustoIntervencao.Text = intervencao.CodigoStaff

        TerProdutosIntervencao()

    End Sub

    Private Sub ShowProdutoIntervencao()

        If ListProdutosIntervencao.Items.Count = 0 Or currentProdutoIntervencao < 0 Then Exit Sub
        Dim produto As New Produto
        produto = CType(ListProdutosIntervencao.Items.Item(currentProdutoIntervencao), Produto)
        CodigoProdutoIntervencao.Text = produto.CodigoProduto
        TipoProdutoIntervencao.Text = produto.TipoProduto
        CustoProdutoIntervencao.Text = produto.Custo
        CustoLimpezaIntervencao.Text = produto.CustoLimpeza
        ProdutoQuantidade.Text = produto.Quantidade

    End Sub

    Private Sub ShowMedicamento()
        If ListMedicamentos.Items.Count = 0 Or currentMedicamento < 0 Then Exit Sub
        Dim medicamento As New Medicamento
        medicamento = CType(ListMedicamentos.Items.Item(currentMedicamento), Medicamento)
        NomeMedicamento.Text = medicamento.Nome
        CodigoMedicamento.Text = medicamento.Codigo
        CustoMedicamento.Text = medicamento.Custo
    End Sub

    Private Sub ShowServico()

        If ListServicos.Items.Count = 0 Or currentServico < 0 Then Exit Sub
        Dim servico As New Servico
        servico = CType(ListServicos.Items.Item(currentServico), Servico)
        CodigoServico.Text = servico.CodigoServico
        NomeServico.Text = servico.NomeServico
        CustoServico.Text = servico.Custo
        EnfermeiroServico.Text = servico.EnfermeiroResponsavel
        MedicoServico.Text = servico.MedicoResponsavel

    End Sub

    Private Sub ShowFatura()
        If ListFaturas.Items.Count = 0 Or currentFatura < 0 Then Exit Sub
        Dim fatura As New Fatura
        fatura = CType(ListFaturas.Items.Item(currentFatura), Fatura)
        FaturaPaciente.Text = fatura.NomePaciente
        FaturaSeguro.Text = fatura.CodigoSeguro
        CodigoFatura.Text = fatura.CodigoFatura
        CustoFatura.Text = fatura.CustoFatura
        DataPagamentoFatura.Text = fatura.DataPagamento

    End Sub

    Private Sub ShowFaturasPaciente()
        If ListFaturasPaciente.Items.Count = 0 Or currentFaturasPaciente < 0 Then Exit Sub
        Dim fatura As New Fatura
        fatura = CType(ListFaturasPaciente.Items.Item(currentFaturasPaciente), Fatura)
        FaturaPacienteNome.Text = fatura.NomePaciente
        FaturaPacienteSeguro.Text = fatura.CodigoSeguro
        CodigoFaturaPaciente.Text = fatura.CodigoFatura
        CustoFaturaPaciente.Text = fatura.CustoFatura
        DataPagamentoFaturaPaciente.Text = fatura.DataPagamento

    End Sub

    Private Sub ShowInternamentoPaciente()

        If ListInternamentosPaciente.Items.Count = 0 Or currentInternamentoPaciente < 0 Then Exit Sub
        Dim internamento As New Internamento
        internamento = CType(ListInternamentosPaciente.Items.Item(currentInternamentoPaciente), Internamento)
        NumeroInternamentoPaciente.Text = internamento.NumeroInternamento
        CodigoServicoInternamentoPaciente.Text = internamento.CodigoServico
        NomePacienteInternamentoPaciente.Text = internamento.NomePaciente
        NomeServicoInternamentoPaciente.Text = internamento.NomeServico
        CustoServicoInternamentoPaciente.Text = internamento.CustoServico
        DataInicioInternamentoPaciente.Text = internamento.DataInicio
        DataFimInternamentoPaciente.Text = internamento.DataFim
        PatologiaInternamentoPaciente.Text = internamento.Patologia

    End Sub

    Private Sub ShowIntervencaoInternamentoPaciente()


        If ListIntervencaoPaciente.Items.Count = 0 Or currentIntervencaoPaciente < 0 Then Exit Sub
        Dim intervencao As New Intervencao
        intervencao = CType(ListIntervencaoPaciente.Items.Item(currentIntervencaoPaciente), Intervencao)
        NumeroIntervencaoPaciente.Text = intervencao.NumeroInternamento
        NumeroInternamentoIntervencaoPaciente.Text = intervencao.NumeroIntervencao
        CustoIntervencaoPaciente.Text = intervencao.CodigoStaff

        TerProdutosIntervencaoPaciente()

    End Sub

    Private Sub ShowProdutoIntervencaoPaciente()

        If ListProdutosIntervencaoPaciente.Items.Count = 0 Or currentProdutoIntervencaoPaciente < 0 Then Exit Sub
        Dim produto As New Produto
        produto = CType(ListProdutosIntervencaoPaciente.Items.Item(currentProdutoIntervencaoPaciente), Produto)
        CodigoProdutoIntervencaoPaciente.Text = produto.CodigoProduto
        TipoProdutoIntervencaoPaciente.Text = produto.TipoProduto
        CustoProdutoIntervencaoPaciente.Text = produto.Custo
        CustoLimpezaIntervencaoPaciente.Text = produto.CustoLimpeza
        ProdutoQuantidadePaciente.Text = produto.Quantidade

    End Sub

    Private Sub ShowSegurosPaciente()
        If ListSegurosPaciente.Items.Count = 0 Or currentSeguroPaciente < 0 Then Exit Sub
        Dim seguro As New Seguro
        seguro = CType(ListSegurosPaciente.Items.Item(currentSeguroPaciente), Seguro)
        NomeSeguroPaciente.Text = seguro.NomeSeguro
        CodigoSeguroPaciente.Text = seguro.CodigoSeguro
        DescontoSeguroPaciente.Text = seguro.DescontoSeguro


    End Sub

    Private Sub ShowMedicoServico()

        If ListMedicosServico.Items.Count = 0 Or currentMedicoServico < 0 Then Exit Sub
        Dim medico As New Medico
        medico = CType(ListMedicosServico.Items.Item(currentMedicoServico), Medico)
        NomeMedicoServico.Text = medico.Nome
        EspecialidadeMedicoServico.Text = medico.Especialidade
        TelemovelMedicoServico.Text = medico.Telemovel
        ccMedicoServico.Text = medico.CC
        EmailMedicoServico.Text = medico.Email
        MoradaMedicoServico.Text = medico.Endereço
        NacionalidadeMedicoServico.Text = medico.Nacionalidade
        TelefoneMedicoServico.Text = medico.Telefone
        DataNascimentoMedicoServico.Text = medico.DataDeNascimento
        GeneroMedicoServico.Text = medico.Sexo
        CodigMedicoServico.Text = medico.Codigo
        CodigoPostalMedicoServico.Text = medico.CodigoPostal
        SalarioMedicoServico.Text = medico.Salario

    End Sub

#End Region

#Region "Submit"

    Private Sub SubmitPaciente(ByRef P As Paciente)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "INSERT INTO ClinicGest.Pessoa " &
            "(nome, telemovel, cc, email, endereco, nacionalidade, telefone, data_nasc, sexo,codigopostal) VALUES " &
            "(@nome, @telemovel, @cc, @email, @endereco, @nacionalidade, @telefone, @data_nasc, @sexo, @codigopostal); " &
            "INSERT INTO ClinicGest.Paciente (cc_pac) VALUES (@cc); SELECT SCOPE_IDENTITY()"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@nome", P.Nome)
        cmd.Parameters.AddWithValue("@telemovel", P.Telemovel)
        cmd.Parameters.AddWithValue("@cc", P.CC)
        cmd.Parameters.AddWithValue("@email", P.Email)
        cmd.Parameters.AddWithValue("@endereco", P.Endereço)
        cmd.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        cmd.Parameters.AddWithValue("@telefone", P.Telefone)
        cmd.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        cmd.Parameters.AddWithValue("@sexo", P.Sexo)
        cmd.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        CN.Open()
        Try
            P.Codigo = cmd.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitMedico(ByRef P As Medico)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "INSERT ClinicGest.Pessoa " &
            "(nome, telemovel, cc, email, endereco, nacionalidade, telefone, sexo,codigopostal) VALUES " &
            "(@nome, @telemovel, @cc, @email, @endereco, @nacionalidade, @telefone, @sexo, @codigopostal); " &
            "INSERT ClinicGest.Staff (cc_staff,salario) VALUES (@cc, @salario);" &
            "INSERT ClinicGest.Medico (codigo_staff, especialidade) VALUES " &
            "((SELECT codigo_staff FROM ClinicGest.Staff WHERE cc_staff = @cc), @especialidade);" &
            "SELECT SCOPE_IDENTITY()"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@nome", P.Nome)
        cmd.Parameters.AddWithValue("@especialidade", P.Especialidade)
        cmd.Parameters.AddWithValue("@telemovel", P.Telemovel)
        cmd.Parameters.AddWithValue("@cc", P.CC)
        cmd.Parameters.AddWithValue("@email", P.Email)
        cmd.Parameters.AddWithValue("@endereco", P.Endereço)
        cmd.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        cmd.Parameters.AddWithValue("@telefone", P.Telefone)
        cmd.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        cmd.Parameters.AddWithValue("@sexo", P.Sexo)
        cmd.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        cmd.Parameters.AddWithValue("@salario", P.Salario)
        CN.Open()
        Try
            P.Codigo = cmd.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitEnfermeiro(ByRef P As Enfermeiro)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "INSERT ClinicGest.Pessoa " &
            "(nome, telemovel, cc, email, endereco, nacionalidade, telefone, sexo,codigopostal) VALUES " &
            "(@nome, @telemovel, @cc, @email, @endereco, @nacionalidade, @telefone, @sexo, @codigopostal); " &
            "INSERT ClinicGest.Staff (cc_staff,salario) VALUES (@cc, @salario); " &
            "INSERT ClinicGest.Enfermeiro (codigo_enf) VALUES (SELECT codigo_staff FROM ClinicGest.Staff WHERE cc_staff = @cc); " &
            "SELECT SCOPE_IDENTITY()"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@nome", P.Nome)
        cmd.Parameters.AddWithValue("@telemovel", P.Telemovel)
        cmd.Parameters.AddWithValue("@cc", P.CC)
        cmd.Parameters.AddWithValue("@email", P.Email)
        cmd.Parameters.AddWithValue("@endereco", P.Endereço)
        cmd.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        cmd.Parameters.AddWithValue("@telefone", P.Telefone)
        cmd.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        cmd.Parameters.AddWithValue("@sexo", P.Sexo)
        cmd.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        cmd.Parameters.AddWithValue("@salario", P.Salario)
        CN.Open()
        Try
            P.Codigo = cmd.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitMedicamento(ByRef P As Medicamento)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "INSERT ClinicGest.Medicamento (nome, preco_unitario) VALUES (@nome, @custo); " &
            "SELECT SCOPE_IDENTITY()"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@nome", P.Nome)
        cmd.Parameters.AddWithValue("@custo", P.Custo)
        CN.Open()
        Try
            P.Codigo = cmd.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

#End Region

#Region "Update"

    Private Sub UpdatePaciente(ByVal P As Paciente)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "UPDATE ClinicGest.Pessoa " &
            "SET nome = @nome, " &
            "    telemovel = @telemovel, " &
            "    cc = @cc, " &
            "    email = @email, " &
            "    endereco = @endereco, " &
            "    nacionalidade = nacionalidade, " &
            "    telefone = @telefone, " &
            "    data_nasc = @data_nasc, " &
            "    sexo = @sexo, " &
            "    codigopostal = @codigopostal " &
            "WHERE cc = @cc"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@nome", P.Nome)
        cmd.Parameters.AddWithValue("@telemovel", P.Telemovel)
        cmd.Parameters.AddWithValue("@cc", P.CC)
        cmd.Parameters.AddWithValue("@email", P.Email)
        cmd.Parameters.AddWithValue("@endereco", P.Endereço)
        cmd.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        cmd.Parameters.AddWithValue("@telefone", P.Telefone)
        cmd.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        cmd.Parameters.AddWithValue("@sexo", P.Sexo)
        cmd.Parameters.AddWithValue("@codigo", P.Codigo)
        cmd.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        CN.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub UpdateMedico(ByVal P As Medico)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "UPDATE ClinicGest.Pessoa " &
            "SET nome = @nome, " &
            "    telemovel = @telemovel, " &
            "    cc = @cc, " &
            "    email = @email, " &
            "    endereco = @endereco, " &
            "    nacionalidade = nacionalidade, " &
            "    telefone = @telefone, " &
            "    sexo = @sexo, " &
            "    codigopostal = @codigopostal " &
            "WHERE cc = @cc; UPDATE ClinicGest.Staff SET salario = @salario, cc_staff = @cc WHERE cc_staff = @cc"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@nome", P.Nome)
        cmd.Parameters.AddWithValue("@telemovel", P.Telemovel)
        cmd.Parameters.AddWithValue("@cc", P.CC)
        cmd.Parameters.AddWithValue("@email", P.Email)
        cmd.Parameters.AddWithValue("@endereco", P.Endereço)
        cmd.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        cmd.Parameters.AddWithValue("@telefone", P.Telefone)
        cmd.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        cmd.Parameters.AddWithValue("@sexo", P.Sexo)
        cmd.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        cmd.Parameters.AddWithValue("@salario", P.Salario)
        CN.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub UpdateEnfermeiro(ByVal P As Enfermeiro)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "UPDATE ClinicGest.Pessoa " &
            "SET nome = @nome, " &
            "    telemovel = @telemovel, " &
            "    cc = @cc, " &
            "    email = @email, " &
            "    endereco = @endereco, " &
            "    nacionalidade = nacionalidade, " &
            "    telefone = @telefone, " &
            "    sexo = @sexo, " &
            "    codigopostal = @codigopostal " &
            "WHERE cc = @cc; UPDATE ClinicGest.Staff SET salario = @salario, cc_staff = @cc WHERE cc_staff = @cc"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@nome", P.Nome)
        cmd.Parameters.AddWithValue("@telemovel", P.Telemovel)
        cmd.Parameters.AddWithValue("@cc", P.CC)
        cmd.Parameters.AddWithValue("@email", P.Email)
        cmd.Parameters.AddWithValue("@endereco", P.Endereço)
        cmd.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        cmd.Parameters.AddWithValue("@telefone", P.Telefone)
        cmd.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        cmd.Parameters.AddWithValue("@sexo", P.Sexo)
        cmd.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        cmd.Parameters.AddWithValue("@salario", P.Salario)
        CN.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub UpdateMedicamento(ByVal P As Medicamento)
        Dim cmd = New SqlCommand With {
            .Connection = CN,
            .CommandText = "UPDATE ClinicGest.Medicamento " &
            "SET nome = @nome, " &
            "    preco_unitario = @custo, " &
            "WHERE codigo_medicamento = @codigo"
        }
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@nome", P.Nome)
        cmd.Parameters.AddWithValue("@codigo", P.Codigo)
        cmd.Parameters.AddWithValue("@custo", P.Custo)
        CN.Open()
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

#End Region

#Region "Save"

    Private Sub SavePaciente()
        Dim paciente As New Paciente

        paciente.Nome = NomePaciente.Text
        paciente.Telemovel = TelemovelPaciente.Text
        paciente.CC = CcPaciente.Text
        paciente.Email = EmailPaciente.Text
        paciente.Endereço = EnderecoPaciente.Text
        paciente.Nacionalidade = NacionalidadePaciente.Text
        paciente.Telefone = TelefonePaciente.Text
        paciente.DataDeNascimento = DataPaciente.Text
        paciente.Sexo = SexoPaciente.Text
        paciente.Codigo = CodigoPaciente.Text
        paciente.CodigoPostal = CodPostalPaciente.Text

        If adding Then
            SubmitPaciente(paciente)
            ListPacientes.Items.Add(paciente)
        Else
            UpdatePaciente(paciente)
            ListPacientes.Items(currentPaciente) = paciente
        End If
    End Sub

    Private Sub SaveMedico()
        Dim medico As New Medico

        medico.Nome = NomeMedico.Text
        medico.Especialidade = EspecialidadeMedico.Text
        medico.CC = CcMedico.Text
        medico.DataDeNascimento = DataMedico.Text
        medico.Email = EmailMedico.Text
        medico.Sexo = SexoMedico.Text
        medico.Endereço = EnderecoMedico.Text
        medico.CodigoPostal = CodPostalMedico.Text
        medico.Nacionalidade = NacionalidadeMedico.Text
        medico.Telemovel = TelemovelMedico.Text
        medico.Telefone = TelefoneMedico.Text
        medico.Salario = SalarioMedico.Text

        If adding Then
            SubmitMedico(medico)
            ListMedicos.Items.Add(medico)
        Else
            UpdateMedico(medico)
            ListMedicos.Items(currentMedico) = medico
        End If

    End Sub

    Private Function SaveEnfermeiro() As Boolean
        Dim enfermeiro As New Enfermeiro
        Try

            enfermeiro.Nome = NomeEnfermeiro.Text
            enfermeiro.CC = CcEnfermeiro.Text
            enfermeiro.DataDeNascimento = DataEnfermeiro.Text
            enfermeiro.Email = EmailEnfermeiro.Text
            enfermeiro.Sexo = SexoEnfermeiro.Text
            enfermeiro.Endereço = EnderecoEnfermeiro.Text
            enfermeiro.CodigoPostal = CodPostalEnfermeiro.Text
            enfermeiro.Nacionalidade = NacionalidadeEnfermeiro.Text
            enfermeiro.Telemovel = TelemovelEnfermeiro.Text
            enfermeiro.Telefone = TelefoneEnfermeiro.Text
            enfermeiro.Salario = SalarioEnfermeiro.Text

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        If adding Then
            SubmitEnfermeiro(enfermeiro)
            ListEnfermeiros.Items.Add(enfermeiro)
        Else
            UpdateEnfermeiro(enfermeiro)
            ListEnfermeiros.Items(currentEnfermeiro) = enfermeiro
        End If
        Return True
    End Function

    Private Function SaveMedicamento() As Boolean
        Dim medicamento As New Medicamento
        Try
            medicamento.Nome = NomeMedicamento.Text
            medicamento.Codigo = CodigoMedicamento.Text
            medicamento.Custo = CustoMedicamento.Text

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        If adding Then
            SubmitMedicamento(medicamento)
            ListMedicamentos.Items.Add(medicamento)
        Else
            UpdateMedicamento(medicamento)
            ListMedicamentos.Items(currentMedico) = medicamento
        End If
        Return True
    End Function

#End Region

#Region "Helper routines"

    Sub LockControlsPaciente()
        NomePaciente.ReadOnly = True
        TelemovelPaciente.ReadOnly = True
        CcPaciente.ReadOnly = True
        EmailPaciente.ReadOnly = True
        EnderecoPaciente.ReadOnly = True
        NacionalidadePaciente.ReadOnly = True
        TelefonePaciente.ReadOnly = True
        DataPaciente.ReadOnly = True
        SexoPaciente.ReadOnly = True
        CodigoPaciente.ReadOnly = True
        CodPostalPaciente.ReadOnly = True
    End Sub

    Sub LockControlsEnfermeiro()
        NomeEnfermeiro.ReadOnly = True
        CodigoEnfermeiro.ReadOnly = True
        CcEnfermeiro.ReadOnly = True
        DataEnfermeiro.ReadOnly = True
        EmailEnfermeiro.ReadOnly = True
        SexoEnfermeiro.ReadOnly = True
        EnderecoEnfermeiro.ReadOnly = True
        CodPostalEnfermeiro.ReadOnly = True
        NacionalidadeEnfermeiro.ReadOnly = True
        TelemovelEnfermeiro.ReadOnly = True
        TelefoneEnfermeiro.ReadOnly = True
        SalarioEnfermeiro.ReadOnly = True
    End Sub

    Sub LockControlsMedico()
        NomeMedico.ReadOnly = True
        EspecialidadeMedico.ReadOnly = True
        CcMedico.ReadOnly = True
        DataMedico.ReadOnly = True
        CodigoMedico.ReadOnly = True
        EmailMedico.ReadOnly = True
        SexoMedico.ReadOnly = True
        EnderecoMedico.ReadOnly = True
        CodPostalMedico.ReadOnly = True
        NacionalidadeMedico.ReadOnly = True
        TelemovelMedico.ReadOnly = True
        TelefoneMedico.ReadOnly = True
        SalarioMedico.ReadOnly = True
    End Sub

    Sub LockControlsMedicamento()
        CustoMedicamento.ReadOnly = True
        NomeMedicamento.ReadOnly = True
    End Sub

    Sub UnLockControlsPaciente()
        NomePaciente.ReadOnly = False
        TelemovelPaciente.ReadOnly = False
        CcPaciente.ReadOnly = False
        EmailPaciente.ReadOnly = False
        EnderecoPaciente.ReadOnly = False
        NacionalidadePaciente.ReadOnly = False
        TelefonePaciente.ReadOnly = False
        DataPaciente.ReadOnly = False
        SexoPaciente.ReadOnly = False
        CodigoPaciente.ReadOnly = False
        CodPostalPaciente.ReadOnly = False
    End Sub

    Sub UnLockControlsEnfermeiro()
        NomeEnfermeiro.ReadOnly = False
        CcEnfermeiro.ReadOnly = False
        DataEnfermeiro.ReadOnly = False
        EmailEnfermeiro.ReadOnly = False
        SexoEnfermeiro.ReadOnly = False
        EnderecoEnfermeiro.ReadOnly = False
        CodPostalEnfermeiro.ReadOnly = False
        NacionalidadeEnfermeiro.ReadOnly = False
        TelemovelEnfermeiro.ReadOnly = False
        TelefoneEnfermeiro.ReadOnly = False
        SalarioEnfermeiro.ReadOnly = False
    End Sub

    Sub UnLockControlsMedico()
        NomeMedico.ReadOnly = False
        EspecialidadeMedico.ReadOnly = False
        CcMedico.ReadOnly = False
        DataMedico.ReadOnly = False
        EmailMedico.ReadOnly = False
        SexoMedico.ReadOnly = False
        EnderecoMedico.ReadOnly = False
        CodPostalMedico.ReadOnly = False
        NacionalidadeMedico.ReadOnly = False
        TelemovelMedico.ReadOnly = False
        TelefoneMedico.ReadOnly = False
        SalarioMedico.ReadOnly = False
    End Sub

    Sub UnlockControlsMedicamento()
        CustoMedicamento.ReadOnly = False
        NomeMedicamento.ReadOnly = False
    End Sub

    Sub ClearFieldsPaciente()
        NomePaciente.Clear()
        TelemovelPaciente.Clear()
        CcPaciente.Clear()
        EmailPaciente.Clear()
        EnderecoPaciente.Clear()
        NacionalidadePaciente.Clear()
        TelefonePaciente.Clear()
        DataPaciente.Clear()
        SexoPaciente.Clear()
        CodigoPaciente.Clear()
        CodPostalPaciente.Clear()
    End Sub

    Sub ClearFieldsEnfermeiro()
        NomeEnfermeiro.Clear()
        CcEnfermeiro.Clear()
        DataEnfermeiro.Clear()
        EmailEnfermeiro.Clear()
        SexoEnfermeiro.Clear()
        EnderecoEnfermeiro.Clear()
        CodPostalEnfermeiro.Clear()
        NacionalidadeEnfermeiro.Clear()
        TelemovelEnfermeiro.Clear()
        TelefoneEnfermeiro.Clear()
        SalarioEnfermeiro.Clear()
    End Sub

    Sub ClearFieldsMedico()
        NomeMedico.Clear()
        CodigoMedico.Clear()
        EspecialidadeMedico.Clear()
        CcMedico.Clear()
        DataMedico.Clear()
        EmailMedico.Clear()
        SexoMedico.Clear()
        EnderecoMedico.Clear()
        CodPostalMedico.Clear()
        NacionalidadeMedico.Clear()
        TelemovelMedico.Clear()
        TelefoneMedico.Clear()
        SalarioMedico.Clear()
    End Sub

    Sub ClearFieldsMedicine()
        CustoMedicamento.Clear()
        CodigoMedicamento.Clear()
        NomeMedicamento.Clear()
    End Sub

#End Region

#Region "Change Selection Handlers"

    Private Sub ListPacientes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPacientes.SelectedIndexChanged
        If ListPacientes.SelectedIndex > -1 Then
            currentPaciente = ListPacientes.SelectedIndex
            ShowPaciente()
        End If
    End Sub

    Private Sub ListMedicos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMedicos.SelectedIndexChanged
        If ListMedicos.SelectedIndex > -1 Then
            currentMedico = ListMedicos.SelectedIndex
            ShowMedico()
        End If
    End Sub

    Private Sub ListEnfermeiros_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListEnfermeiros.SelectedIndexChanged
        If ListEnfermeiros.SelectedIndex > -1 Then
            currentEnfermeiro = ListEnfermeiros.SelectedIndex
            ShowEnfermeiro()
        End If
    End Sub

    Private Sub ListInternamentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListInternamentos.SelectedIndexChanged
        If ListInternamentos.SelectedIndex > -1 Then
            currentInternamento = ListInternamentos.SelectedIndex
            ShowInternamento()
        End If
    End Sub

    Private Sub ListIntervencoes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListIntervencoes.SelectedIndexChanged
        If ListIntervencoes.SelectedIndex > -1 Then
            currentIntervencao = ListIntervencoes.SelectedIndex
            ShowIntervencaoInternamento()
        End If
    End Sub

    Private Sub ListServicos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListServicos.SelectedIndexChanged
        If ListServicos.SelectedIndex > -1 Then
            currentServico = ListServicos.SelectedIndex
            ShowServico()
        End If
    End Sub

    Private Sub ListMedicamentos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMedicamentos.SelectedIndexChanged
        If ListMedicamentos.SelectedIndex > -1 Then
            currentMedicamento = ListMedicamentos.SelectedIndex
            ShowMedicamento()
        End If
    End Sub

    Private Sub ListProdutosIntervencao_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListProdutosIntervencao.SelectedIndexChanged
        If ListProdutosIntervencao.SelectedIndex > -1 Then
            currentProdutoIntervencao = ListProdutosIntervencao.SelectedIndex
            ShowProdutoIntervencao()
        End If
    End Sub

    Private Sub ListFaturas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFaturas.SelectedIndexChanged
        If ListFaturas.SelectedIndex > -1 Then
            currentFatura = ListFaturas.SelectedIndex
            ShowFatura()
        End If
    End Sub

    Private Sub ListFaturasPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListFaturasPaciente.SelectedIndexChanged
        If ListFaturasPaciente.SelectedIndex > -1 Then
            currentFaturasPaciente = ListFaturasPaciente.SelectedIndex
            ShowFaturasPaciente()
        End If
    End Sub

    Private Sub ListInternamentosPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListInternamentosPaciente.SelectedIndexChanged
        If ListInternamentosPaciente.SelectedIndex > -1 Then
            currentInternamentoPaciente = ListInternamentosPaciente.SelectedIndex
            ShowInternamentoPaciente()
        End If
    End Sub

    Private Sub ListProdutosIntervencaoPaciente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListProdutosIntervencaoPaciente.SelectedIndexChanged
        If ListProdutosIntervencaoPaciente.SelectedIndex > -1 Then
            currentProdutoIntervencaoPaciente = ListProdutosIntervencaoPaciente.SelectedIndex
            ShowProdutoIntervencaoPaciente()
        End If
    End Sub


    Private Sub ListIntervencaoPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListIntervencaoPaciente.SelectedIndexChanged
        If ListIntervencaoPaciente.SelectedIndex > -1 Then
            currentIntervencaoPaciente = ListIntervencaoPaciente.SelectedIndex
            ShowIntervencaoInternamentoPaciente()
        End If
    End Sub


    Private Sub ListSegurosPaciente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListSegurosPaciente.SelectedIndexChanged
        If ListSegurosPaciente.SelectedIndex > -1 Then
            currentSeguroPaciente = ListSegurosPaciente.SelectedIndex
            ShowSegurosPaciente()
        End If
    End Sub

    Private Sub ListMedicosServico_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListMedicosServico.SelectedIndexChanged
        If ListMedicosServico.SelectedIndex > -1 Then
            currentMedicoServico = ListMedicosServico.SelectedIndex
            ShowMedicoServico()
        End If
    End Sub

#End Region

#Region "Search Handlers"

    Private Sub SearchMedicamento_Click(sender As Object, e As EventArgs) Handles btnSearchMedicamento.Click
        For Each lbItem As Object In ListMedicamentos.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchMedicamento.Text Then
                ' Match found: set as selected item and exit procedure
                ListMedicamentos.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchMedicoSercivo_Click(sender As Object, e As EventArgs) Handles btnSearchMedicoServico.Click
        For Each lbItem As Object In ListMedicosServico.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchMedicoServico.Text Then
                ' Match found: set as selected item and exit procedure
                ListMedicosServico.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub



    Private Sub SearchPaciente_Click(sender As Object, e As EventArgs) Handles btnSearchPaciente.Click
        For Each lbItem As Object In ListPacientes.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchPaciente.Text Then
                ' Match found: set as selected item and exit procedure
                ListPacientes.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchEnfermeiro_Click(sender As Object, e As EventArgs) Handles btnSearchEnfermeiro.Click
        For Each lbItem As Object In ListEnfermeiros.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchEnfermeiro.Text Then
                ' Match found: set as selected item and exit procedure
                ListEnfermeiros.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchMedico_Click(sender As Object, e As EventArgs) Handles btnSearchMedico.Click
        For Each lbItem As Object In ListMedicos.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchMedico.Text Then
                ' Match found: set as selected item and exit procedure
                ListMedicos.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchInternamento_Click(sender As Object, e As EventArgs) Handles btnSearchInternamento.Click
        For Each lbItem As Object In ListInternamentos.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchInternamento.Text Then
                ' Match found: set as selected item and exit procedure
                ListInternamentos.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchIntervencaoInternamento_Click(sender As Object, e As EventArgs) Handles btnSearchIntervencao.Click
        For Each lbItem As Object In ListIntervencoes.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchIntervencao.Text Then
                ' Match found: set as selected item and exit procedure
                ListIntervencoes.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchServico_Click(sender As Object, e As EventArgs) Handles btnSearchServico.Click
        For Each lbItem As Object In ListServicos.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchServico.Text Then
                ' Match found: set as selected item and exit procedure
                ListServicos.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub


    Private Sub btnSearchFaturasPaciente_Click(sender As Object, e As EventArgs) Handles btnSearchFaturasPaciente.Click
        For Each lbItem As Object In ListFaturasPaciente.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchFaturasPaciente.Text Then
                ' Match found: set as selected item and exit procedure
                ListFaturasPaciente.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchInternamentoPaciente_Click(sender As Object, e As EventArgs) Handles btnSearchInternamentoPaciente.Click
        For Each lbItem As Object In ListInternamentosPaciente.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchInternamentoPaciente.Text Then
                ' Match found: set as selected item and exit procedure
                ListInternamentosPaciente.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchSegurosPaciente_Click(sender As Object, e As EventArgs) Handles btnSearchSegurosPaciente.Click
        For Each lbItem As Object In ListSegurosPaciente.Items
            ' Case-sensitive match
            If lbItem.ToString = SearchSegurosPaciente.Text Then
                ' Match found: set as selected item and exit procedure
                ListSegurosPaciente.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

#End Region

#Region "Add Handlers"

    Private Sub AddPaciente_Click(sender As Object, e As EventArgs) Handles btnAddPaciente.Click
        adding = True
        ClearFieldsPaciente()
        HideButtonsPaciente()
        ListPacientes.Enabled = False
    End Sub

    Private Sub AddEnfermeiro_Click(sender As Object, e As EventArgs) Handles btnAddEnfermeiro.Click
        adding = True
        ClearFieldsEnfermeiro()
        HideButtonsEnfermeiro()
        ListEnfermeiros.Enabled = False
    End Sub

    Private Sub AddMedico_Click(sender As Object, e As EventArgs) Handles btnAddMedico.Click
        adding = True
        ClearFieldsMedico()
        HideButtonsMedico()
        ListMedicos.Enabled = False
    End Sub

    Private Sub AddMedicamento_Click(sender As Object, e As EventArgs) Handles btnAddMedicamento.Click
        adding = True
        ClearFieldsMedicine()
        HideButtonsMedicamento()
        ListMedicamentos.Enabled = False
    End Sub

#End Region

#Region "Edit Handlers"

    Private Sub EditPaciente_Click(sender As Object, e As EventArgs) Handles btnEditPaciente.Click
        currentPaciente = ListPacientes.SelectedIndex
        If currentPaciente < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtonsPaciente()
        ListPacientes.Enabled = False
    End Sub

    Private Sub EditMedico_Click(sender As Object, e As EventArgs) Handles btnEditMedico.Click
        currentMedico = ListMedicos.SelectedIndex
        If currentMedico < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtonsMedico()
        ListMedicos.Enabled = False
    End Sub

    Private Sub EditEnfermeiro_Click(sender As Object, e As EventArgs) Handles btnEditEnfermeiro.Click
        currentEnfermeiro = ListEnfermeiros.SelectedIndex
        If currentEnfermeiro < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtonsEnfermeiro()
        ListEnfermeiros.Enabled = False
    End Sub

    Private Sub EditMedicamento_Click(sender As Object, e As EventArgs) Handles btnEditMedicamento.Click
        currentMedicamento = ListMedicamentos.SelectedIndex
        If currentMedicamento < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtonsMedicamento()
        ListMedicamentos.Enabled = False
    End Sub

#End Region

#Region "Ok Handlers"

    Private Sub OkPaciente_Click(sender As Object, e As EventArgs) Handles btnOkPaciente.Click
        Try
            SavePaciente()
            ListPacientes.Enabled = True
            Dim idx As Integer = ListPacientes.FindString(NomePaciente.Text)
            ListPacientes.SelectedIndex = idx
            ShowButtonsPaciente()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub OkMedico_Click(sender As Object, e As EventArgs) Handles btnOkMedico.Click
        Try
            SaveMedico()
            ListMedicos.Enabled = True
            Dim idx As Integer = ListMedicos.FindString(NomeMedico.Text)
            ListMedicos.SelectedIndex = idx
            ShowButtonsMedico()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub OkEnfermeiro_Click(sender As Object, e As EventArgs) Handles btnOkEnfermeiro.Click
        Try
            SaveEnfermeiro()
            ListEnfermeiros.Enabled = True
            Dim idx As Integer = ListEnfermeiros.FindString(NomeEnfermeiro.Text)
            ListEnfermeiros.SelectedIndex = idx
            ShowButtonsEnfermeiro()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub OkMedicamento_Click(sender As Object, e As EventArgs) Handles btnOkMedicamento.Click
        Try
            SaveMedicamento()
            ListMedicamentos.Enabled = True
            Dim idx As Integer = ListMedicamentos.FindString(NomeMedicamento.Text)
            ListMedicamentos.SelectedIndex = idx
            ShowButtonsMedicamento()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region

#Region "Cancel Handlers"

    Private Sub CancelPaciente_Click(sender As Object, e As EventArgs) Handles btnCancelPaciente.Click
        ListPacientes.Enabled = True
        If ListPacientes.Items.Count > 0 Then
            currentPaciente = ListPacientes.SelectedIndex
            If currentPaciente < 0 Then currentPaciente = 0
            ShowPaciente()
        Else
            ClearFieldsPaciente()
            LockControlsPaciente()
        End If
        ShowButtonsPaciente()
    End Sub

    Private Sub CancelMedico_Click(sender As Object, e As EventArgs) Handles btnCancelMedico.Click
        ListMedicos.Enabled = True
        If ListMedicos.Items.Count > 0 Then
            currentMedico = ListMedicos.SelectedIndex
            If currentMedico < 0 Then currentMedico = 0
            ShowMedico()
        Else
            ClearFieldsMedico()
            LockControlsMedico()
        End If
        ShowButtonsMedico()
    End Sub

    Private Sub CancelEnfermeiro_Click(sender As Object, e As EventArgs) Handles btnCancelEnfermeiro.Click
        ListEnfermeiros.Enabled = True
        If ListEnfermeiros.Items.Count > 0 Then
            currentEnfermeiro = ListEnfermeiros.SelectedIndex
            If currentEnfermeiro < 0 Then currentEnfermeiro = 0
            ShowEnfermeiro()
        Else
            ClearFieldsEnfermeiro()
            LockControlsEnfermeiro()
        End If
        ShowButtonsEnfermeiro()
    End Sub

    Private Sub CancelMedicamento_Click(sender As Object, e As EventArgs) Handles btnCancelMedicamento.Click
        ListMedicamentos.Enabled = True
        If ListMedicamentos.Items.Count > 0 Then
            currentMedicamento = ListMedicamentos.SelectedIndex
            If currentMedicamento < 0 Then currentMedicamento = 0
            ShowMedicamento()
        Else
            ClearFieldsMedicine()
            LockControlsMedicamento()
        End If
        ShowButtonsMedicamento()
    End Sub

#End Region

#Region "Other Click Handlers"

    Private Sub ListIntervencoesInternamento_Click(sender As Object, e As EventArgs) Handles btnListIntervencoesInternamento.Click
        TerIntervencoesInternamento()
        GroupIntervencoesInternamento.Visible = True
    End Sub

    Private Sub ListFaturasPaciente_Click(sender As Object, e As EventArgs) Handles btnListFaturasPaciente.Click
        TerFaturasPaciente()
        GroupFaturasPaciente.Visible = True
    End Sub

    Private Sub ListInternamentosPaciente_Click(sender As Object, e As EventArgs) Handles btnListInternamentosPaciente.Click
        TerInternamentosPaciente()
        GroupInternamentosPaciente.Visible = True
    End Sub

    Private Sub ExitIntervencoesInternamento_Click(sender As Object, e As EventArgs) Handles btnExitIntervencoesInternamento.Click
        GroupIntervencoesInternamento.Visible = False
    End Sub

    Private Sub btbSairFaturasPaciente_Click(sender As Object, e As EventArgs) Handles btbSairFaturasPaciente.Click
        GroupFaturasPaciente.Visible = False
    End Sub

    Private Sub btnSairInternamentosPaciente_Click(sender As Object, e As EventArgs) Handles btnSairInternamentosPaciente.Click
        GroupInternamentosPaciente.Visible = False
    End Sub

    Private Sub ListIntervencoesInternamentoPaciente_Click(sender As Object, e As EventArgs) Handles ListarIntervencoesInternamentoPaciente.Click
        TerIntervencoesInternamentoPaciente()
        GroupIntervencoesInternamentosPaciente.Visible = True
        GroupInternamentosPaciente.Visible = False
    End Sub

    Private Sub btnExitIntervencoesInternamentoPaciente_Click(sender As Object, e As EventArgs) Handles btnExitIntervencoesInternamentoPaciente.Click
        GroupIntervencoesInternamentosPaciente.Visible = False
        GroupInternamentosPaciente.Visible = True
    End Sub

    Private Sub btnListSegurosPaciente_Click(sender As Object, e As EventArgs) Handles btnListSegurosPaciente.Click
        TerSegurosPaciente()
        GroupSegurosPaciente.Visible = True
    End Sub

    Private Sub SairSegurosPaciente_Click(sender As Object, e As EventArgs) Handles SairSegurosPaciente.Click
        GroupSegurosPaciente.Visible = False
    End Sub

    Private Sub btnSairMedicosServico_Click(sender As Object, e As EventArgs) Handles btnSairMedicosServico.Click
        GroupMedicosServico.Visible = False
    End Sub

    Private Sub btnListMedicosServico_Click(sender As Object, e As EventArgs) Handles btnListMedicosServico.Click
        TerMedicosServico()
        GroupMedicosServico.Visible = True
    End Sub


#End Region

End Class
