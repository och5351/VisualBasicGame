Public Class resultForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If stageNum = 1 Then
            stage1R = TextBox1.Text
            TextBox1.Text = ""
        ElseIf stageNum = 2 Then
            stage2R = TextBox1.Text
            TextBox1.Text = ""
        End If
        Me.Close()
    End Sub

    Private Sub resultForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If stageNum = 1 Then
            Label1.Text = "비주얼베이직시간의 강의자료 비밀번호는?"
        ElseIf stageNum = 2 Then
            Label1.Text = "단서를 찾아 답을 입력하시오."
        End If
    End Sub
End Class