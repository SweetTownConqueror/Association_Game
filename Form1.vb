Public Class Assiociation_Game
    Private form As Integer
    Private colour As Integer
    Private goodAnswer As Integer = 0
    Private wrongAnswer As Integer = 0
    Private nbTry As Integer = 0
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Start()
        Timer1.Interval = 1000
        Dim timer As New Stopwatch
        timer.Start()
        Label1.ForeColor = Color.Black
        Label1.Text = Val(Label1.Text) - 1
        If Label1.Text < 60 Then
            Label1.ForeColor = Color.Red
            If Label1.Text <= 0 Then
                Timer1.Enabled = False
                MsgBox("Time's up! Résultat : " + goodAnswer.ToString() + "/" + (goodAnswer + wrongAnswer).ToString() + " soit " + ((goodAnswer * 100) / (goodAnswer + wrongAnswer)).ToString("00.00") + "% de bonnes réponses")
            End If
        End If
        ' Initialize the random-number generator.
        Randomize()
        ' Generate random value between 1 and 4.
        form = CInt(Int((3 * Rnd()) + 1))
        colour = CInt(Int((4 * Rnd()) + 1))
        While timer.ElapsedMilliseconds < 500

            Dim MyGraphics As Graphics = Me.CreateGraphics
            Dim redBrush As SolidBrush = New SolidBrush(Color.Red)
            Dim greenBrush As SolidBrush = New SolidBrush(Color.LawnGreen)
            Dim blueBrush As SolidBrush = New SolidBrush(Color.Blue)
            Dim yellowBrush As SolidBrush = New SolidBrush(Color.Yellow)
            If form = 1 Then
                If colour = 1 Then
                    MyGraphics.FillEllipse(redBrush, 80, 80, 70, 70)
                ElseIf colour = 2 Then
                    MyGraphics.FillEllipse(greenBrush, 80, 80, 70, 70)
                ElseIf colour = 3 Then
                    MyGraphics.FillEllipse(blueBrush, 80, 80, 70, 70)
                ElseIf colour = 4 Then
                    MyGraphics.FillEllipse(yellowBrush, 80, 80, 70, 70)
                End If
            ElseIf form = 2 Then
                If colour = 1 Then
                    MyGraphics.FillRectangle(redBrush, 80, 80, 70, 70)
                ElseIf colour = 2 Then
                    MyGraphics.FillRectangle(greenBrush, 80, 80, 70, 70)
                ElseIf colour = 3 Then
                    MyGraphics.FillRectangle(blueBrush, 80, 80, 70, 70)
                ElseIf colour = 4 Then
                    MyGraphics.FillRectangle(yellowBrush, 80, 80, 70, 70)
                End If
            ElseIf form = 3 Then
                If colour = 1 Then
                    Dim ptsArray As PointF() = {New PointF(160.0F, 120.0F), New PointF(110.0F, 80.0F), New PointF(60.0F, 120.0F), New PointF(110.0F, 160.0F)}
                    Dim gp As New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)
                    gp.AddLines(ptsArray)
                    gp.CloseFigure()
                    MyGraphics.FillPath(redBrush, gp)
                    'MyGraphics.DrawLines(Pens.Black, ptsArray)
                    'MyGraphics.FillEllipse(redBrush, 80, 80, 70, 70)
                ElseIf colour = 2 Then
                    Dim ptsArray As PointF() = {New PointF(160.0F, 120.0F), New PointF(110.0F, 80.0F), New PointF(60.0F, 120.0F), New PointF(110.0F, 160.0F)}
                    Dim gp As New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)
                    gp.AddLines(ptsArray)
                    gp.CloseFigure()
                    MyGraphics.FillPath(greenBrush, gp)
                    'MyGraphics.FillEllipse(greenBrush, 80, 80, 70, 70)
                ElseIf colour = 3 Then
                    Dim ptsArray As PointF() = {New PointF(160.0F, 120.0F), New PointF(110.0F, 80.0F), New PointF(60.0F, 120.0F), New PointF(110.0F, 160.0F)}
                    Dim gp As New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)
                    gp.AddLines(ptsArray)
                    gp.CloseFigure()
                    MyGraphics.FillPath(blueBrush, gp)
                    'MyGraphics.FillEllipse(blueBrush, 80, 80, 70, 70)
                ElseIf colour = 4 Then
                    Dim ptsArray As PointF() = {New PointF(160.0F, 120.0F), New PointF(110.0F, 80.0F), New PointF(60.0F, 120.0F), New PointF(110.0F, 160.0F)}
                    Dim gp As New Drawing2D.GraphicsPath(Drawing2D.FillMode.Alternate)
                    gp.AddLines(ptsArray)
                    gp.CloseFigure()
                    MyGraphics.FillPath(yellowBrush, gp)
                    'MyGraphics.FillEllipse(yellowBrush, 80, 80, 70, 70)
                End If
            End If
            't2
        End While
        Me.Invalidate()
        nbTry = nbTry + 1
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Timer1.Enabled = True Then
            Timer1.Start()
            'Form1_Load()
        Else
            Label1.Text = 360
            Timer1.Start()
        End If
    End Sub

    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        Dim bHandled As Boolean = False
        If keyData = Keys.Left Then
            bHandled = True
            If form = 1 And (colour <> 1) Then
                'Label2.Text = "bonne forme rond ! "
                goodAnswer = goodAnswer + 1
            Else
                If nbTry < 90 Then
                    Timer1.Stop()
                    MsgBox("Raté. Rappel : gauche : rond vert bleu jaune")
                    If MsgBoxResult.Ok Then
                        Timer1.Start()
                    End If
                End If
                wrongAnswer = wrongAnswer + 1
            End If
        ElseIf keyData = Keys.Down Then
            bHandled = True
            If form = 2 And (colour <> 2) Then
                'Label2.Text = "bonne forme carre ! "
                goodAnswer = goodAnswer + 1
            Else
                If nbTry < 90 Then
                    Timer1.Stop()
                    MsgBox("Raté. Rappel : bas : carre rouge bleu jaune")
                    If MsgBoxResult.Ok Then
                        Timer1.Start()
                    End If
                End If
                wrongAnswer = wrongAnswer + 1
            End If
        ElseIf keyData = Keys.Right Then
            bHandled = True
            If form = 3 And (colour <> 3) Then
                'Label2.Text = "bonne forme losange ! "
                goodAnswer = goodAnswer + 1
            Else
                If nbTry < 90 Then
                    Timer1.Stop()
                    MsgBox("Raté. rappel : droite : losange rouge vert jaune")
                    If MsgBoxResult.Ok Then
                        Timer1.Start()
                    End If
                End If
                wrongAnswer = wrongAnswer + 1
            End If
        End If
        Return bHandled
    End Function
End Class