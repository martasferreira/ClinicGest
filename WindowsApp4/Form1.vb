Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient
Imports WindowsApp4

Public Class Form1

    Dim CN As SqlConnection
    Dim CMD1 As SqlCommand
    Dim currentPaciente As Integer
    Dim adding As Boolean
    Dim currentMedico As Integer
    Dim currentEnfermeiro As Integer
    Dim currentInternamento As Integer
    Dim currentIntervencao As Integer
    Dim currentServico As Integer
    Dim currentMedicamento As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'nao sei o que é para escrever

        ShowButtonsPaciente()
        ShowButtonsMedico()
        ShowButtonsEnfermeiro()
        ShowButtonsMedicine()


        CN = New SqlConnection("Data Source=tcp:mednat.ieeta.pt\SQLSERVER,8101;Initial Catalog=p4g9;User ID=p4g9;Password=ClinicG3st;Connection Timeout=50;")
        TerPacientes(CN)
        TerMedicos(CN)
        TerEnfermeiros(CN)
        TerInternamentos(CN)
        TerIntervencoes(CN)
        'TerFaturas(CN)
        TerServiços(CN)
        TerMedicamentos(CN)

    End Sub

#Region "Show Buttons"

    Private Sub ShowButtonsPaciente()
        LockControlsPaciente()
        btnAddPaciente.Visible = True
        btnEditPaciente.Visible = True
        btnOkPaciente.Visible = False
        btnCancelPaciente.Visible = False

        btnListFaturasPaciente.Visible = True
        btnListIntervencoesPaciente.Visible = True
        btnListSegurosPaciente.Visible = True
        btnListInternamentosPaciente.Visible = True
    End Sub

    Private Sub ShowButtonsMedico()
        LockControlsDoc()
        btnAddMedico.Visible = True
        btnEditMedico.Visible = True
        btnOkMedico.Visible = False
        btnCancelMedico.Visible = False

        btnListInternamentosMedico.Visible = True
        btnListIntervencoesMedico.Visible = True
        btnListServicosMedico.Visible = True
    End Sub

    Private Sub ShowButtonsEnfermeiro()
        LockControlsEnf()
        btnAddEnfermeiro.Visible = True
        btnEditEnfermeiro.Visible = True
        btnOkEnfermeiro.Visible = False
        btnCancelEnfermeiro.Visible = False

        btnListInternamentosEnfermeiro.Visible = True
        btnListIntervencoesEnfermeiro.Visible = True
        btnListReceitasExecEnfermeiro.Visible = True
    End Sub

    Private Sub ShowButtonsMedicine()
        LockControlsMedicine()
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
        btnListIntervencoesPaciente.Visible = False
        btnListSegurosPaciente.Visible = False
        btnListInternamentosPaciente.Visible = False
    End Sub

    Private Sub HideButtonsDoc()
        UnLockControlsDoc()
        btnAddMedico.Visible = False
        btnEditMedico.Visible = False
        btnOkMedico.Visible = True
        btnCancelMedico.Visible = True

        btnListInternamentosMedico.Visible = False
        btnListIntervencoesMedico.Visible = False
        btnListServicosMedico.Visible = False
    End Sub

    Private Sub HideButtonsEnf()
        UnLockControlsEnf()
        btnAddEnfermeiro.Visible = False
        btnEditEnfermeiro.Visible = False
        btnOkEnfermeiro.Visible = True
        btnCancelEnfermeiro.Visible = True

        btnListInternamentosEnfermeiro.Visible = False
        btnListIntervencoesEnfermeiro.Visible = False
        btnListReceitasExecEnfermeiro.Visible = False

    End Sub

    Private Sub HideButtonsMedinine()
        btnAddMedicamento.Visible = False
        btnEditMedicamento.Visible = False
        btnOkMedicamento.Visible = True
        btnCancelMedicamento.Visible = True
    End Sub

#End Region

#Region "Add To List"

    Private Sub TerPacientes(CN As SqlConnection)
        CMD1 = New SqlCommand
        CMD1.Connection = CN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "SELECT * FROM ClinicGest.Pessoa JOIN ClinicGest.Paciente ON Pessoa.cc = Paciente.cc_pac"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
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

    Private Sub TerEnfermeiros(cN As SqlConnection)

        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Pessoa as pessoa join ClinicGest.Staff as staff on pessoa.cc =staff.cc_staff join ClinicGest.Enfermeiro as enfermeiro on staff.codigo_staff =enfermeiro.codigo_emp"
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
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
        cN.Close()
        currentEnfermeiro = 0
        ShowEnfermeiro()


    End Sub

    Private Sub TerMedicos(cN As SqlConnection)
        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Pessoa as pessoa join ClinicGest.Staff as staff on pessoa.cc =staff.cc_staff join ClinicGest.Medico as medico on staff.codigo_staff =medico.codigo_emp"
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
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
        cN.Close()
        currentMedico = 0
        ShowMedico()

    End Sub

    Private Sub TerMedicamentos(cN As SqlConnection)
        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Medicamento"
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
        ListMedicamentos.Items.Clear()
        While RDR.Read
            Dim M As New Medicamento
            M.Codigo = RDR.Item("codigo_medicamento")
            M.Nome = RDR.Item("nome")
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("preco_unitario")), "", RDR.Item("preco_unitario")))
            ListMedicamentos.Items.Add(M)
        End While
        cN.Close()
        currentMedicamento = 0
        ShowMedicamento()
    End Sub

    Private Sub TerServiços(cN As SqlConnection)

        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Servico"
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
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
        cN.Close()
        currentServico = 0
        ShowServico()


    End Sub

    Private Sub TerIntervencoes(cN As SqlConnection)
        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Intervencao as intervencao join ClinicGest.GastaProduto as gastaproduto on intervencao.num_intervencao = gastaproduto.gasta_intervencao join ClinicGest.Produto as produto on gastaproduto.gasta_prod =produto.codigo_produto "
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
        ListIntervencoes.Items.Clear()
        While RDR.Read
            Dim M As New Intervencao
            M.NumeroInternamento = RDR.Item("int_internamento")
            M.NumeroIntervencao = RDR.Item("num_intervencao")
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            ListIntervencoes.Items.Add(M)
        End While
        cN.Close()
        currentIntervencao = 0
        ShowIntervencao()

    End Sub

    Private Sub TerInternamentos(cN As SqlConnection)
        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Internamento as internamento join ClinicGest.Servico  as servico on internamento.internamento_servico = servico.codigo_servico "
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
        ListInternamentos.Items.Clear()
        While RDR.Read
            Dim M As New Internamento
            M.NumeroInternamento = RDR.Item("num_internamento")
            M.CodigoServico = RDR.Item("internamento_servico")
            M.NomeServico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            M.CustoServico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            M.DataInicio = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_entrada")), "", RDR.Item("data_entrada")))
            M.DataFim = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_saida")), "", RDR.Item("data_aida")))
            M.Patologia = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("patologia")), "", RDR.Item("patologia")))

            ListInternamentos.Items.Add(M)
        End While
        cN.Close()
        currentInternamento = 0
        ShowInternamento()

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
        TextBox62.Text = enfermeiro.Nome
        TextBox61.Text = enfermeiro.Telemovel
        TextBox60.Text = enfermeiro.CC
        TextBox59.Text = enfermeiro.Email
        TextBox58.Text = enfermeiro.Endereço
        TextBox57.Text = enfermeiro.Nacionalidade
        TextBox56.Text = enfermeiro.Telefone
        TextBox55.Text = enfermeiro.DataDeNascimento
        TextBox54.Text = enfermeiro.Sexo
        TextBox53.Text = enfermeiro.Codigo
        TextBox52.Text = enfermeiro.CodigoPostal
        TextBox38.Text = enfermeiro.Salario

    End Sub

    Private Sub ShowMedico()

        If ListMedicos.Items.Count = 0 Or currentMedico < 0 Then Exit Sub
        Dim medico As New Medico
        medico = CType(ListMedicos.Items.Item(currentMedico), Medico)
        NomeMedico.Text = medico.Nome
        TextBox23.Text = medico.Especialidade
        TextBox21.Text = medico.Telemovel
        TextBox20.Text = medico.CC
        TextBox19.Text = medico.Email
        TextBox18.Text = medico.Endereço
        TextBox17.Text = medico.Nacionalidade
        TextBox16.Text = medico.Telefone
        TextBox15.Text = medico.DataDeNascimento
        TextBox14.Text = medico.Sexo
        TextBox13.Text = medico.Codigo
        TextBox12.Text = medico.CodigoPostal
        TextBox39.Text = medico.Salario

    End Sub

    Private Sub ShowInternamento()

        If ListInternamentos.Items.Count = 0 Or currentInternamento < 0 Then Exit Sub
        Dim internamento As New Internamento
        internamento = CType(ListInternamentos.Items.Item(currentInternamento), Internamento)
        TextBox35.Text = internamento.NumeroInternamento
        TextBox24.Text = internamento.CodigoServico
        TextBox33.Text = internamento.NomeServico
        TextBox26.Text = internamento.CustoServico
        TextBox32.Text = internamento.DataInicio
        TextBox27.Text = internamento.DataFim
        TextBox31.Text = internamento.Patologia


    End Sub

    Private Sub ShowMedicamento()
        If ListMedicamentos.Items.Count = 0 Or currentMedicamento < 0 Then Exit Sub
        Dim medicamento As New Medicamento
        medicamento = CType(ListMedicamentos.Items.Item(currentMedicamento), Medicamento)
        TextBox79.Text = medicamento.Nome
        TextBox78.Text = medicamento.Codigo
        TextBox77.Text = medicamento.Custo
    End Sub

    Private Sub ShowServico()

        If ListServicos.Items.Count = 0 Or currentServico < 0 Then Exit Sub
        Dim servico As New Servico
        servico = CType(ListServicos.Items.Item(currentServico), Servico)
        TextBox50.Text = servico.CodigoServico
        TextBox49.Text = servico.NomeServico
        TextBox45.Text = servico.Custo
        TextBox51.Text = servico.EnfermeiroResponsavel
        TextBox76.Text = servico.MedicoResponsavel


    End Sub

    Private Sub ShowIntervencao()

        If ListIntervencoes.Items.Count = 0 Or currentIntervencao < 0 Then Exit Sub
        Dim intervencao As New Intervencao
        intervencao = CType(ListIntervencoes.Items.Item(currentIntervencao), Intervencao)
        TextBox35.Text = intervencao.NumeroInternamento
        TextBox24.Text = intervencao.NumeroIntervencao
        TextBox33.Text = intervencao.Custo

    End Sub

#End Region

#Region "Submit"

    Private Sub SubmitPaciente(ByRef P As Paciente)
        CMD1.CommandText = "INSERT INTO ClinicGest.Pessoa " &
            "(nome, telemovel, cc, email, endereco, nacionalidade, telefone, data_nasc, sexo,codigopostal) VALUES " &
            "(@nome, @telemovel, @cc, @email, @endereco, @nacionalidade, @telefone, @data_nasc, @sexo, @codigopostal); " &
            "INSERT INTO ClinicGest.Paciente (cc_pac) VALUES (@cc); SELECT SCOPE_IDENTITY()"
        CMD1.Parameters.Clear()
        CMD1.Parameters.AddWithValue("@nome", P.Nome)
        CMD1.Parameters.AddWithValue("@telemovel", P.Telemovel)
        CMD1.Parameters.AddWithValue("@cc", P.CC)
        CMD1.Parameters.AddWithValue("@email", P.Email)
        CMD1.Parameters.AddWithValue("@endereco", P.Endereço)
        CMD1.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        CMD1.Parameters.AddWithValue("@telefone", P.Telefone)
        CMD1.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        CMD1.Parameters.AddWithValue("@sexo", P.Sexo)
        CMD1.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        CN.Open()
        Try
            P.Codigo = CMD1.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitMedico(ByRef P As Medico)
        CMD1.CommandText = "INSERT ClinicGest.Pessoa " &
            "(nome, telemovel, cc, email, endereco, nacionalidade, telefone, sexo,codigopostal) VALUES " &
            "(@nome, @telemovel, @cc, @email, @endereco, @nacionalidade, @telefone, @sexo, @codigopostal); " &
            "INSERT ClinicGest.Staff (cc_staff,salario) VALUES (@cc, @salario);" &
            "INSERT ClinicGest.Medico (codigo_emp, especialidade) VALUES " &
            "((SELECT codigo_staff FROM ClinicGest.Staff WHERE cc_staff = @cc), @especialidade);" &
            "SELECT SCOPE_IDENTITY()"
        CMD1.Parameters.Clear()
        CMD1.Parameters.AddWithValue("@nome", P.Nome)
        CMD1.Parameters.AddWithValue("@especialidade", P.Especialidade)
        CMD1.Parameters.AddWithValue("@telemovel", P.Telemovel)
        CMD1.Parameters.AddWithValue("@cc", P.CC)
        CMD1.Parameters.AddWithValue("@email", P.Email)
        CMD1.Parameters.AddWithValue("@endereco", P.Endereço)
        CMD1.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        CMD1.Parameters.AddWithValue("@telefone", P.Telefone)
        CMD1.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        CMD1.Parameters.AddWithValue("@sexo", P.Sexo)
        CMD1.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        CMD1.Parameters.AddWithValue("@salario", P.Salario)
        CN.Open()
        Try
            P.Codigo = CMD1.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitEnfermeiro(ByRef P As Enfermeiro)
        CMD1.CommandText = "INSERT ClinicGest.Pessoa " &
            "(nome, telemovel, cc, email, endereco, nacionalidade, telefone, sexo,codigopostal) VALUES " &
            "(@nome, @telemovel, @cc, @email, @endereco, @nacionalidade, @telefone, @sexo, @codigopostal); " &
            "INSERT ClinicGest.Staff (cc_staff,salario) VALUES (@cc, @salario); " &
            "INSERT ClinicGest.Enfermeiro (codigo_enf) VALUES (SELECT codigo_staff FROM ClinicGest.Staff WHERE cc_staff = @cc); " &
            "SELECT SCOPE_IDENTITY()"
        CMD1.Parameters.Clear()
        CMD1.Parameters.AddWithValue("@nome", P.Nome)
        CMD1.Parameters.AddWithValue("@telemovel", P.Telemovel)
        CMD1.Parameters.AddWithValue("@cc", P.CC)
        CMD1.Parameters.AddWithValue("@email", P.Email)
        CMD1.Parameters.AddWithValue("@endereco", P.Endereço)
        CMD1.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        CMD1.Parameters.AddWithValue("@telefone", P.Telefone)
        CMD1.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        CMD1.Parameters.AddWithValue("@sexo", P.Sexo)
        CMD1.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        CMD1.Parameters.AddWithValue("@salario", P.Salario)
        CN.Open()
        Try
            P.Codigo = CMD1.ExecuteScalar()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
        CN.Close()
    End Sub

    Private Sub SubmitMedicamento(ByRef P As Medicamento)
        CMD1.CommandText = "INSERT ClinicGest.Medicamento (nome, preco_unitario) VALUES (@nome, @custo); " &
            "SELECT SCOPE_IDENTITY()"
        CMD1.Parameters.Clear()
        CMD1.Parameters.AddWithValue("@nome", P.Nome)
        CMD1.Parameters.AddWithValue("@custo", P.Custo)
        CN.Open()
        Try
            P.Codigo = CMD1.ExecuteScalar()
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
        CMD1.CommandText = "UPDATE ClinicGest.Pessoa " &
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
        CMD1.Parameters.Clear()
        CMD1.Parameters.AddWithValue("@nome", P.Nome)
        CMD1.Parameters.AddWithValue("@telemovel", P.Telemovel)
        CMD1.Parameters.AddWithValue("@cc", P.CC)
        CMD1.Parameters.AddWithValue("@email", P.Email)
        CMD1.Parameters.AddWithValue("@endereco", P.Endereço)
        CMD1.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        CMD1.Parameters.AddWithValue("@telefone", P.Telefone)
        CMD1.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        CMD1.Parameters.AddWithValue("@sexo", P.Sexo)
        CMD1.Parameters.AddWithValue("@codigo", P.Codigo)
        CMD1.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        CN.Open()
        Try
            CMD1.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub UpdateMedico(ByVal P As Medico)
        CMD1.CommandText = "UPDATE ClinicGest.Pessoa " &
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
        CMD1.Parameters.Clear()
        CMD1.Parameters.AddWithValue("@nome", P.Nome)
        CMD1.Parameters.AddWithValue("@telemovel", P.Telemovel)
        CMD1.Parameters.AddWithValue("@cc", P.CC)
        CMD1.Parameters.AddWithValue("@email", P.Email)
        CMD1.Parameters.AddWithValue("@endereco", P.Endereço)
        CMD1.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        CMD1.Parameters.AddWithValue("@telefone", P.Telefone)
        CMD1.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        CMD1.Parameters.AddWithValue("@sexo", P.Sexo)
        CMD1.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        CMD1.Parameters.AddWithValue("@salario", P.Salario)
        CN.Open()
        Try
            CMD1.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub UpdateEnfermeiro(ByVal P As Enfermeiro)
        CMD1.CommandText = "UPDATE ClinicGest.Pessoa " &
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
        CMD1.Parameters.Clear()
        CMD1.Parameters.AddWithValue("@nome", P.Nome)
        CMD1.Parameters.AddWithValue("@telemovel", P.Telemovel)
        CMD1.Parameters.AddWithValue("@cc", P.CC)
        CMD1.Parameters.AddWithValue("@email", P.Email)
        CMD1.Parameters.AddWithValue("@endereco", P.Endereço)
        CMD1.Parameters.AddWithValue("@nacionalidade", P.Nacionalidade)
        CMD1.Parameters.AddWithValue("@telefone", P.Telefone)
        CMD1.Parameters.AddWithValue("@data_nasc", P.DataDeNascimento)
        CMD1.Parameters.AddWithValue("@sexo", P.Sexo)
        CMD1.Parameters.AddWithValue("@codigopostal", P.CodigoPostal)
        CMD1.Parameters.AddWithValue("@salario", P.Salario)
        CN.Open()
        Try
            CMD1.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    Private Sub UpdateMedicamento(P As Medicamento)
        CMD1.CommandText = "UPDATE ClinicGest.Medicamento " &
            "SET nome = @nome, " &
            "    preco_unitario = @custo, " &
            "WHERE codigo_medicamento = @codigo"
        CMD1.Parameters.Clear()
        CMD1.Parameters.AddWithValue("@nome", P.Nome)
        CMD1.Parameters.AddWithValue("@codigo", P.Codigo)
        CMD1.Parameters.AddWithValue("@custo", P.Custo)
        CN.Open()
        Try
            CMD1.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to update contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

#End Region

#Region "Save"

    Private Sub SaveContact()
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
        medico.Especialidade = TextBox23.Text
        medico.CC = TextBox20.Text
        medico.DataDeNascimento = TextBox15.Text
        medico.Email = TextBox19.Text
        medico.Sexo = TextBox14.Text
        medico.Endereço = TextBox18.Text
        medico.CodigoPostal = TextBox12.Text
        medico.Nacionalidade = TextBox17.Text
        medico.Telemovel = TextBox21.Text
        medico.Telefone = TextBox16.Text
        medico.Salario = TextBox39.Text

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

            enfermeiro.Nome = TextBox62.Text
            enfermeiro.CC = TextBox60.Text
            enfermeiro.DataDeNascimento = TextBox55.Text
            enfermeiro.Email = TextBox59.Text
            enfermeiro.Sexo = TextBox54.Text
            enfermeiro.Endereço = TextBox58.Text
            enfermeiro.CodigoPostal = TextBox52.Text
            enfermeiro.Nacionalidade = TextBox57.Text
            enfermeiro.Telemovel = TextBox61.Text
            enfermeiro.Telefone = TextBox56.Text
            enfermeiro.Salario = TextBox38.Text

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
            medicamento.Nome = TextBox79.Text
            medicamento.Codigo = TextBox78.Text
            medicamento.Custo = TextBox77.Text

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

    Sub LockControlsEnf()
        TextBox62.ReadOnly = True
        TextBox53.ReadOnly = True
        TextBox60.ReadOnly = True
        TextBox55.ReadOnly = True
        TextBox59.ReadOnly = True
        TextBox54.ReadOnly = True
        TextBox58.ReadOnly = True
        TextBox52.ReadOnly = True
        TextBox57.ReadOnly = True
        TextBox61.ReadOnly = True
        TextBox56.ReadOnly = True
        TextBox38.ReadOnly = True
    End Sub

    Sub LockControlsDoc()
        NomeMedico.ReadOnly = True
        TextBox23.ReadOnly = True
        TextBox20.ReadOnly = True
        TextBox15.ReadOnly = True
        TextBox13.ReadOnly = True
        TextBox19.ReadOnly = True
        TextBox14.ReadOnly = True
        TextBox18.ReadOnly = True
        TextBox12.ReadOnly = True
        TextBox17.ReadOnly = True
        TextBox21.ReadOnly = True
        TextBox16.ReadOnly = True
        TextBox39.ReadOnly = True
    End Sub

    Sub LockControlsMedicine()
        TextBox77.ReadOnly = False
        TextBox79.ReadOnly = False
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

    Sub UnLockControlsEnf()
        TextBox62.ReadOnly = False
        TextBox60.ReadOnly = False
        TextBox55.ReadOnly = False
        TextBox59.ReadOnly = False
        TextBox54.ReadOnly = False
        TextBox58.ReadOnly = False
        TextBox52.ReadOnly = False
        TextBox57.ReadOnly = False
        TextBox61.ReadOnly = False
        TextBox56.ReadOnly = False
        TextBox38.ReadOnly = False
    End Sub

    Sub UnLockControlsDoc()
        NomeMedico.ReadOnly = False
        TextBox23.ReadOnly = False
        TextBox20.ReadOnly = False
        TextBox15.ReadOnly = False
        TextBox19.ReadOnly = False
        TextBox14.ReadOnly = False
        TextBox18.ReadOnly = False
        TextBox12.ReadOnly = False
        TextBox17.ReadOnly = False
        TextBox21.ReadOnly = False
        TextBox16.ReadOnly = False
        TextBox39.ReadOnly = False
    End Sub

    Sub ClearFieldsPaciente()
        NomePaciente.Text = ""
        TelemovelPaciente.Text = ""
        CcPaciente.Text = ""
        EmailPaciente.Text = ""
        EnderecoPaciente.Text = ""
        NacionalidadePaciente.Text = ""
        TelefonePaciente.Text = ""
        DataPaciente.Text = ""
        SexoPaciente.Text = ""
        CodigoPaciente.Text = ""
        CodPostalPaciente.Text = ""
    End Sub

    Sub ClearFieldsEnf()
        TextBox62.Text = ""
        TextBox60.Text = ""
        TextBox55.Text = ""
        TextBox59.Text = ""
        TextBox54.Text = ""
        TextBox58.Text = ""
        TextBox52.Text = ""
        TextBox57.Text = ""
        TextBox61.Text = ""
        TextBox56.Text = ""
        TextBox38.Text = ""
    End Sub

    Sub ClearFieldsDoc()
        NomeMedico.Text = ""
        TextBox13.Text = ""
        TextBox23.Text = ""
        TextBox20.Text = ""
        TextBox15.Text = ""
        TextBox19.Text = ""
        TextBox14.Text = ""
        TextBox18.Text = ""
        TextBox12.Text = ""
        TextBox17.Text = ""
        TextBox21.Text = ""
        TextBox16.Text = ""
        TextBox39.Text = ""
    End Sub

    Sub ClearFieldsMedicine()
        TextBox77.Text = ""
        TextBox78.Text = ""
        TextBox79.Text = ""
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
            ShowIntervencao()
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

#End Region

#Region "Search Handlers"

    Private Sub SearchMedicamento_Click(sender As Object, e As EventArgs) Handles btnSearchMedicamento.Click
        For Each lbItem As Object In ListMedicamentos.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox99.Text Then
                ' Match found: set as selected item and exit procedure
                ListMedicamentos.SelectedItem = lbItem
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
            If lbItem.ToString = TextBox101.Text Then
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

    Private Sub SearchIntervencao_Click(sender As Object, e As EventArgs) Handles btnSearchIntervencao.Click
        For Each lbItem As Object In ListIntervencoes.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox103.Text Then
                ' Match found: set as selected item and exit procedure
                ListIntervencoes.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchInternamento_Click(sender As Object, e As EventArgs) Handles btnSearchInternamento.Click
        For Each lbItem As Object In ListInternamentos.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox104.Text Then
                ' Match found: set as selected item and exit procedure
                ListInternamentos.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub SearchServico_Click(sender As Object, e As EventArgs) Handles btnSearchServico.Click
        For Each lbItem As Object In ListServicos.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox105.Text Then
                ' Match found: set as selected item and exit procedure
                ListServicos.SelectedItem = lbItem
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
        ClearFieldsEnf()
        HideButtonsEnf()
        ListEnfermeiros.Enabled = False
    End Sub

    Private Sub AddMedico_Click(sender As Object, e As EventArgs) Handles btnAddMedico.Click
        adding = True
        ClearFieldsDoc()
        HideButtonsDoc()
        ListMedicos.Enabled = False
    End Sub

    Private Sub AddMedicamento_Click(sender As Object, e As EventArgs) Handles btnAddMedicamento.Click
        adding = True
        ClearFieldsMedicine()
        HideButtonsMedinine()
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
        HideButtonsDoc()
        ListMedicos.Enabled = False
    End Sub

    Private Sub EditEnfermeiro_Click(sender As Object, e As EventArgs) Handles btnEditEnfermeiro.Click
        currentEnfermeiro = ListEnfermeiros.SelectedIndex
        If currentEnfermeiro < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtonsEnf()
        ListEnfermeiros.Enabled = False
    End Sub

    Private Sub EditMedicamento_Click(sender As Object, e As EventArgs) Handles btnEditMedicamento.Click
        currentMedicamento = ListMedicamentos.SelectedIndex
        If currentMedicamento < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtonsMedinine()
        ListMedicamentos.Enabled = False
    End Sub

#End Region

#Region "Ok Handlers"

    Private Sub OkPaciente_Click(sender As Object, e As EventArgs) Handles btnOkPaciente.Click
        Try
            SaveContact()
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
            Dim idx As Integer = ListEnfermeiros.FindString(TextBox62.Text)
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
            Dim idx As Integer = ListMedicamentos.FindString(TextBox79.Text)
            ListMedicamentos.SelectedIndex = idx
            ShowButtonsMedicine()
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
            ClearFieldsDoc()
            LockControlsDoc()
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
            ClearFieldsEnf()
            LockControlsEnf()
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
            LockControlsMedicine()
        End If
        ShowButtonsMedicine()
    End Sub

#End Region

End Class
