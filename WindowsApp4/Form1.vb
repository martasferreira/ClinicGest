Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Data.SqlClient

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
        Faturas.Hide()
        Intervencoes.Hide()
        Internamentos.Hide()
        Seguros.Hide()
        GroupBox1.Hide()
        GroupBox2.Hide()
        ShowButtons()

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

    Private Sub TerMedicamentos(cN As SqlConnection)
        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Medicamento"
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
        ListBox14.Items.Clear()
        While RDR.Read
            Dim M As New Medicamento
            M.Codigo = RDR.Item("codigo_medicamento")
            M.Nome = RDR.Item("nome")
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("preco_unitario")), "", RDR.Item("preco_unitario")))
            ListBox14.Items.Add(M)
        End While
        cN.Close()
        currentMedicamento = 0
        ShowMedicamento()
    End Sub

    Private Sub ShowMedicamento()
        If ListBox14.Items.Count = 0 Or currentMedicamento < 0 Then Exit Sub
        Dim medicamento As New Medicamento
        medicamento = CType(ListBox14.Items.Item(currentMedicamento), Medicamento)
        TextBox79.Text = medicamento.Nome
        TextBox78.Text = medicamento.Codigo
        TextBox77.Text = medicamento.Custo

    End Sub

    Private Sub TerServiços(cN As SqlConnection)

        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Servico"
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
        ListBox8.Items.Clear()
        While RDR.Read
            Dim M As New Servico
            M.CodigoServico = RDR.Item("codigo_servico")
            M.NomeServico = RDR.Item("nome")
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            M.MedicoResponsavel = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("medico_responsavel")), "", RDR.Item("medico_responsavel")))
            M.EnfermeiroResponsavel = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("enfermeiro_responsavel")), "", RDR.Item("enfermeiro_responsavel")))
            ListBox8.Items.Add(M)
        End While
        cN.Close()
        currentServico = 0
        ShowServico()


    End Sub

    Private Sub ShowServico()

        If ListBox8.Items.Count = 0 Or currentServico < 0 Then Exit Sub
        Dim servico As New Servico
        servico = CType(ListBox8.Items.Item(currentServico), Servico)
        TextBox50.Text = servico.CodigoServico
        TextBox49.Text = servico.NomeServico
        TextBox45.Text = servico.Custo
        TextBox51.Text = servico.EnfermeiroResponsavel
        TextBox76.Text = servico.MedicoResponsavel


    End Sub

    Private Sub TerIntervencoes(cN As SqlConnection)
        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Intervencao as intervencao join ClinicGest.GastaProduto as gastaproduto on intervencao.num_intervencao = gastaproduto.gasta_intervencao join ClinicGest.Produto as produto on gastaproduto.gasta_prod =produto.codigo_produto "
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
        ListBox4.Items.Clear()
        While RDR.Read
            Dim M As New Intervencao
            M.NumeroInternamento = RDR.Item("int_internamento")
            M.NumeroIntervencao = RDR.Item("num_intervencao")
            M.Custo = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            ListBox4.Items.Add(M)
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
        ListBox3.Items.Clear()
        While RDR.Read
            Dim M As New Internamento
            M.NumeroInternamento = RDR.Item("num_internamento")
            M.CodigoServico = RDR.Item("internamento_servico")
            M.NomeServico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nome")), "", RDR.Item("nome")))
            M.CustoServico = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("custo")), "", RDR.Item("custo")))
            M.DataInicio = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_entrada")), "", RDR.Item("data_entrada")))
            M.DataFim = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("data_saida")), "", RDR.Item("data_aida")))
            M.Patologia = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("patologia")), "", RDR.Item("patologia")))

            ListBox3.Items.Add(M)
        End While
        cN.Close()
        currentInternamento = 0
        ShowInternamento()

    End Sub


    Private Sub TerEnfermeiros(cN As SqlConnection)

        CMD1 = New SqlCommand
        CMD1.Connection = cN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "Select * from ClinicGest.Pessoa as pessoa join ClinicGest.Staff as staff on pessoa.cc =staff.cc_staff join ClinicGest.Enfermeiro as enfermeiro on staff.codigo_staff =enfermeiro.codigo_emp"
        cN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
        ListBox9.Items.Clear()
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

            ListBox9.Items.Add(M)
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
        ListBox2.Items.Clear()
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

            ListBox2.Items.Add(M)
        End While
        cN.Close()
        currentMedico = 0
        ShowMedico()

    End Sub

    Private Sub ShowMedico()

        If ListBox2.Items.Count = 0 Or currentMedico < 0 Then Exit Sub
        Dim medico As New Medico
        medico = CType(ListBox2.Items.Item(currentMedico), Medico)
        TextBox22.Text = medico.Nome
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

    End Sub

    Private Sub ShowInternamento()

        If ListBox3.Items.Count = 0 Or currentInternamento < 0 Then Exit Sub
        Dim internamento As New Internamento
        internamento = CType(ListBox3.Items.Item(currentInternamento), Internamento)
        TextBox35.Text = internamento.NumeroInternamento
        TextBox24.Text = internamento.CodigoServico
        TextBox33.Text = internamento.NomeServico
        TextBox26.Text = internamento.CustoServico
        TextBox32.Text = internamento.DataInicio
        TextBox27.Text = internamento.DataFim
        TextBox31.Text = internamento.Patologia


    End Sub


    Private Sub ShowIntervencao()

        If ListBox4.Items.Count = 0 Or currentIntervencao < 0 Then Exit Sub
        Dim intervencao As New Intervencao
        intervencao = CType(ListBox4.Items.Item(currentIntervencao), Intervencao)
        TextBox35.Text = intervencao.NumeroInternamento
        TextBox24.Text = intervencao.NumeroIntervencao
        TextBox33.Text = intervencao.Custo

    End Sub

    Sub TerPacientes(CN)
        CMD1 = New SqlCommand
        CMD1.Connection = CN
        'nao sei qual é o comando porque temos que ir buscar atributos de pessoa e de paciente
        CMD1.CommandText = "SELECT *
  FROM ClinicGest.Pessoa JOIN ClinicGest.Paciente
    ON Pessoa.cc = Paciente.cc_pac"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD1.ExecuteReader
        ListBox1.Items.Clear()
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

            ListBox1.Items.Add(P)
        End While
        CN.Close()
        currentPaciente = 0
        ShowPaciente()
    End Sub


    ' Helper routines
    Sub LockControls()
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        TextBox3.ReadOnly = True
        TextBox4.ReadOnly = True
        TextBox5.ReadOnly = True
        TextBox6.ReadOnly = True
        TextBox7.ReadOnly = True
        TextBox8.ReadOnly = True
        TextBox9.ReadOnly = True
        TextBox10.ReadOnly = True
        TextBox11.ReadOnly = True
    End Sub

    Sub UnlockControls()
        TextBox1.ReadOnly = False
        TextBox2.ReadOnly = False
        TextBox3.ReadOnly = False
        TextBox4.ReadOnly = False
        TextBox5.ReadOnly = False
        TextBox6.ReadOnly = False
        TextBox7.ReadOnly = False
        TextBox8.ReadOnly = False
        TextBox9.ReadOnly = False
        TextBox10.ReadOnly = False
        TextBox11.ReadOnly = False
    End Sub

    Sub ClearFields()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
    End Sub

    Sub ShowPaciente()
        If ListBox1.Items.Count = 0 Or currentPaciente < 0 Then Exit Sub
        Dim paciente As New Paciente
        paciente = CType(ListBox1.Items.Item(currentPaciente), Paciente)
        TextBox1.Text = paciente.Nome
        TextBox2.Text = paciente.Telemovel
        TextBox3.Text = paciente.CC
        TextBox4.Text = paciente.Email
        TextBox5.Text = paciente.Endereço
        TextBox6.Text = paciente.Nacionalidade
        TextBox7.Text = paciente.Telefone
        TextBox8.Text = paciente.DataDeNascimento
        TextBox9.Text = paciente.Sexo
        TextBox10.Text = paciente.Codigo
        TextBox11.Text = paciente.CodigoPostal

    End Sub

    Private Sub ShowEnfermeiro()

        If ListBox9.Items.Count = 0 Or currentEnfermeiro < 0 Then Exit Sub
        Dim enfermeiro As New Enfermeiro
        enfermeiro = CType(ListBox9.Items.Item(currentEnfermeiro), Enfermeiro)
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

    End Sub

    Private Sub SubmitPaciente(ByVal P As Paciente)
        CMD1.CommandText = "INSERT Paciente (nome, telemovel, cc, email, " &
                          "endereco, nacionalidade, telefone, data_nasc, sexo, codigo,codigopostal) " &
                          "VALUES (@nome, @telemovel, @cc, @email, " &
                          "@endereco, @nacionalidade, @telefone, @data_nasc, @sexo, @codigo, @codigopostal) "
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
        CN.Close()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentPaciente = ListBox1.SelectedIndex
            ShowPaciente()
        End If
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex > -1 Then
            currentMedico = ListBox2.SelectedIndex
            ShowMedico()
        End If
    End Sub

    Private Sub ListBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox9.SelectedIndexChanged
        If ListBox9.SelectedIndex > -1 Then
            currentEnfermeiro = ListBox9.SelectedIndex
            ShowEnfermeiro()
        End If
    End Sub

    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
        If ListBox3.SelectedIndex > -1 Then
            currentInternamento = ListBox3.SelectedIndex
            ShowInternamento()
        End If
    End Sub

    Private Sub ListBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox4.SelectedIndexChanged
        If ListBox4.SelectedIndex > -1 Then
            currentIntervencao = ListBox4.SelectedIndex
            ShowIntervencao()
        End If
    End Sub

    Private Sub ListBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox8.SelectedIndexChanged
        If ListBox8.SelectedIndex > -1 Then
            currentServico = ListBox8.SelectedIndex
            ShowServico()
        End If
    End Sub


    Private Sub ListBox14_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox14.SelectedIndexChanged
        If ListBox14.SelectedIndex > -1 Then
            currentMedicamento = ListBox14.SelectedIndex
            ShowMedicamento()
        End If
    End Sub



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

    Private Function SaveContact() As Boolean
        Dim paciente As New Paciente
        Try

            paciente.Nome = TextBox1.Text
            paciente.Telemovel = TextBox2.Text
            paciente.CC = TextBox3.Text
            paciente.Email = TextBox4.Text
            paciente.Endereço = TextBox5.Text
            paciente.Nacionalidade = TextBox6.Text
            paciente.Telefone = TextBox7.Text
            paciente.DataDeNascimento = TextBox8.Text
            paciente.Sexo = TextBox9.Text
            paciente.Codigo = TextBox10.Text
            paciente.CodigoPostal = TextBox11.Text

        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
        If adding Then
            SubmitPaciente(paciente)
            ListBox1.Items.Add(paciente)
        Else
            UpdatePaciente(paciente)
            ListBox1.Items(currentPaciente) = paciente
        End If
        Return True
    End Function

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        ListBox1.Enabled = True
        If ListBox1.Items.Count > 0 Then
            currentPaciente = ListBox1.SelectedIndex
            If currentPaciente < 0 Then currentPaciente = 0
            ShowPaciente()
        Else
            ClearFields()
            LockControls()
        End If
        ShowButtons()
    End Sub

    Private Sub ShowButtons()
        LockControls()
        btnAdd.Visible = True
        btnEdit.Visible = True
        btnOk.Visible = False
        btnCancel.Visible = False

        Button1.Visible = True
        Button2.Visible = True
        Button3.Visible = True
        Button4.Visible = True
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Try
            SaveContact()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        ListBox1.Enabled = True
        Dim idx As Integer = ListBox1.FindString(TextBox1.Text)
        ListBox1.SelectedIndex = idx
        ShowButtons()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        adding = True
        ClearFields()
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub HideButtons()
        UnlockControls()
        btnAdd.Visible = False
        btnEdit.Visible = False
        btnOk.Visible = True
        btnCancel.Visible = True

        Button1.Visible = False
        Button2.Visible = False
        Button3.Visible = False
        Button4.Visible = False
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        currentPaciente = ListBox1.SelectedIndex
        If currentPaciente < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        adding = False
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Faturas.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Faturas.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Intervencoes.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Intervencoes.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Internamentos.Show()
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Internamentos.Hide()
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        Seguros.Show()
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        Seguros.Hide()
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Intervencoes1.Show()
        Internamentos.Hide()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

    End Sub

    Private Sub Seguros_Enter(sender As Object, e As EventArgs) Handles Seguros.Enter

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        GroupBox1.Show()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        GroupBox1.Hide()
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        GroupBox2.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        GroupBox2.Show()
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        Intervencoes1.Hide()
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        For Each lbItem As Object In ListBox14.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox99.Text Then
                ' Match found: set as selected item and exit procedure
                ListBox14.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        For Each lbItem As Object In ListBox9.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox101.Text Then
                ' Match found: set as selected item and exit procedure
                ListBox9.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        For Each lbItem As Object In ListBox2.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox102.Text Then
                ' Match found: set as selected item and exit procedure
                ListBox2.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        For Each lbItem As Object In ListBox4.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox103.Text Then
                ' Match found: set as selected item and exit procedure
                ListBox4.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        For Each lbItem As Object In ListBox3.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox104.Text Then
                ' Match found: set as selected item and exit procedure
                ListBox3.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        For Each lbItem As Object In ListBox8.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox105.Text Then
                ' Match found: set as selected item and exit procedure
                ListBox8.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        For Each lbItem As Object In ListBox1.Items
            ' Case-sensitive match
            If lbItem.ToString = TextBox106.Text Then
                ' Match found: set as selected item and exit procedure
                ListBox1.SelectedItem = lbItem
                Return
            End If
        Next
    End Sub
End Class
