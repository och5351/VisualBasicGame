Public Class Form1

    '게임 사운드 선언
    Dim player As New GameSounds

    '케릭터 초기 위치 저장 및 케릭터 위치 저장 변수
    Dim moveX As Double = Me.Width
    Dim moveY As Double = Me.Height

    '오브젝트 모음 구조체 선언
    Dim stageO As StageO

    '이동 방지 함수
    Private Sub noWalk()
        If flagAhead = 1 Then
            moveY -= 10
        ElseIf flagAhead = 2 Then
            moveY += 10
        ElseIf flagAhead = 3 Then
            moveX += 10
        Else
            moveX -= 10
        End If
    End Sub

    '그림그려주는 함수
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint

        '배경 그리기
        e.Graphics.DrawImage(backImage, New Rectangle(0, 0, Me.Width, Me.Height))


        If arrowOn = True Then
            e.Graphics.DrawImage(objectList(0), New Rectangle(arrowLocationXL, arrowLocation, 50, 50))
            e.Graphics.DrawImage(objectList(1), New Rectangle(arrowLocationXR, arrowLocation, 50, 50))
        Else
            '주인공 그려주기
            e.Graphics.DrawImage(heroimage, New Rectangle(moveX, moveY, heroimage.Width, heroimage.Height))
            If stageNum = 2 And lightOn = False Then
                Dim backDark As New System.Drawing.SolidBrush(System.Drawing.Color.Black)
                e.Graphics.FillRectangle(backDark, New Rectangle(0, 0, Me.Width, moveY - 40)) '2스테이지 윗 쪽 어둠
                e.Graphics.FillRectangle(backDark, New Rectangle(0, moveY + heroimage.Height + 40, Me.Width, Me.Height)) '2스테이지 아래쪽 어둠
                e.Graphics.FillRectangle(backDark, New Rectangle(0, moveY - 40, moveX - 40, moveY + heroimage.Height + 40)) '2스테이지 왼쪽 어둠
                e.Graphics.FillRectangle(backDark, New Rectangle(moveX + heroimage.Width + 40, moveY - 40, Me.Width, moveY + heroimage.Height + 40)) '2스테이지 오른쪽 어둠
                backDark.Dispose()
            End If

            If stageNum = 3 And explanation = False Then
                e.Graphics.DrawImage(objectList(2), stageO.zerg) '괴물 그리기
                e.Graphics.DrawImage(objectList(3), New Rectangle(Me.Width / 2 - 250, 0, 503, 75)) '괴물 위의 벽 그리기
            End If

            If (stageNum = 4 And menuOn = False) And ghostArr.Count > 0 Then ' 망자 그리기
                For i = 0 To ghostArr.Count - 1
                    Dim gtv = CType(ghostArr(i), ghost)
                    e.Graphics.DrawImage(gtv.ghostImage, New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height))
                Next
            End If
        End If

    End Sub

    'stageStart
    Private Sub stageStart()
        If returndead = 0 Then
            If stageBowl = 5 Then
                stageBowl = 0
                Sleep(2000)
            End If
            If explanation = False Then
                backImage = backList(0)
                arrowOn = True
            Else
                backImage = backList(8)
            End If
        Else
            If returndead = 3 Then '3스테이지에서 죽었을 경우
                stageBowl = 3
                Sleep(1000)
            ElseIf returndead = 4 Then '4스테이지에서 죽었을 경우
                stageBowl = 4
                ghostArr.Clear()
                Sleep(1000)
            End If
            returndead = 1
            If explanation = False Then
                backImage = backList(6)
                arrowOn = True
            Else
                backImage = backList(8)
            End If
        End If

        If goxy = 1 Then
            If arrowSet < 2 Then
                arrowLocation += 43
                arrowSet += 1
            End If
        ElseIf goxy = 2 Then
            If arrowSet > 0 Then
                arrowLocation -= 43
                arrowSet -= 1
            End If
        End If

        If arrowLocation = 550 And functionKey = True Then
            functionKey = False
            If returndead = 0 Then
                Dim result As Integer = MessageBox.Show("새로운 게임을 시작하시겠습니까?", "", MessageBoxButtons.YesNo)
                If result = DialogResult.Yes Then
                    stage1L.Text = ""
                    arrowOn = False
                    moveX = Me.Width / 2 - 400
                    moveY = Me.Height / 2 - 100
                    stage1EventOn = False
                    stage2EventOn = False
                    stage3EventOn = False
                    stage4EventOn = False
                    bookAdd = False
                    tableEvent = False
                    open2Door = False
                    result3stage = 0
                    result3stageOn = False
                    result4stageOn = False
                    stage4event = False
                    lightOn = False
                    life = 0
                    stage1EventOn = False
                    stage2EventOn = False
                    stage3EventOn = False
                    stage4EventOn = False
                    stage1R = ""
                    stage2R = ""
                    ghostArr.Clear()
                    heroimage = heroList(1)
                    openTimer.Stop()
                    stageNum = 1
                    Timer1.Start()
                    gameTimer.Start()
                    player.Pause("startsound")
                    player.Play("stage1") 'msgbox는 다른 컴퓨터에서 실행이 안될경우가 있으므로 경로를 확실히 잡아주거나 messagebox를 사용한다.
                    Microsoft.VisualBasic.Interaction.MsgBox(stage1Str1 & vbCrLf & vbCrLf & stage1Str2 & vbCrLf & vbCrLf & stage1Str3 & vbCrLf & vbCrLf & stage1Str4 & vbCrLf & vbCrLf & stage1Str5,, "독백")
                End If
            ElseIf stageBowl = 3 Then '3스테이지에서 넘어왔을경우
                Dim result As Integer = MessageBox.Show("이어서 하시겠습니까" & vbCrLf & "(새로 시작하시려면 아니오" & vbCrLf & "를 눌러주세요.)", "", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Yes Then
                    Timer1.Start()
                    openTimer.Stop()
                    gameTimer.Start()
                    arrowOn = False
                    heroimage = heroList(1)
                    moveX = 110
                    moveY = Me.Height - 270
                    stageNum = 3
                ElseIf result = DialogResult.No Then
                    arrowOn = False
                    heroimage = heroList(1)
                    iTimeCount = 0
                    Timedisplay = TimeToString()
                    gameTimer.Start()
                    player.Pause("stage3")
                    player.Play("stage1")
                    moveX = Me.Width / 2 - 400
                    moveY = Me.Height / 2 - 100
                    bookAdd = False
                    tableEvent = False
                    open2Door = False
                    result3stage = 0
                    result3stageOn = False
                    result4stageOn = False
                    stage4event = False
                    lightOn = False
                    life = 0
                    stage1EventOn = False
                    stage2EventOn = False
                    stage3EventOn = False
                    stage4EventOn = False
                    stage1R = ""
                    stage2R = ""
                    openTimer.Stop()
                    stageNum = 1
                    Timer1.Start()
                    Microsoft.VisualBasic.Interaction.MsgBox(stage1Str1 & vbCrLf & vbCrLf & stage1Str2 & vbCrLf & vbCrLf & stage1Str3 & vbCrLf & vbCrLf & stage1Str4 & vbCrLf & vbCrLf & stage1Str5,, "독백")
                End If
            ElseIf stageBowl = 4 Then
                Dim result As Integer = MessageBox.Show("이어서 하시겠습니까" & vbCrLf & "(새로 시작하시려면 아니오" & vbCrLf & "를 눌러주세요.)", "", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Yes Then
                    Timer1.Start()
                    openTimer.Stop()
                    gameTimer.Start()
                    arrowOn = False
                    heroimage = heroList(1)
                    moveX = Me.Width / 2
                    moveY = 150
                    stageNum = 4
                ElseIf result = DialogResult.No Then
                    arrowOn = False
                    openTimer.Stop()
                    iTimeCount = 0
                    Timedisplay = TimeToString()
                    gameTimer.Start()
                    Timer1.Start()
                    stageNum = 1
                    player.Pause("stage4")
                    player.Play("stage1")
                    heroimage = heroList(1)
                    moveX = Me.Width / 2 - 400
                    moveY = Me.Height / 2 - 100
                    bookAdd = False
                    tableEvent = False
                    open2Door = False
                    result3stage = 0
                    result3stageOn = False
                    result4stageOn = False
                    stage4event = False
                    lightOn = False
                    life = 0
                    stage1EventOn = False
                    stage2EventOn = False
                    stage3EventOn = False
                    stage4EventOn = False
                    stage1R = ""
                    stage2R = ""
                    Microsoft.VisualBasic.Interaction.MsgBox(stage1Str1 & vbCrLf & vbCrLf & stage1Str2 & vbCrLf & vbCrLf & stage1Str3 & vbCrLf & vbCrLf & stage1Str4 & vbCrLf & vbCrLf & stage1Str5,, "독백")
                End If
            End If
        ElseIf arrowLocation = 593 And functionKey = True Then '게임설명
            heroimage = heroList(9)
            functionKey = False
            arrowOn = False
            explanation = True
            player.Play("select")
            backImage = backList(8)

        ElseIf arrowLocation = 636 And functionKey = True Then
            player.Play("select")
            functionKey = False
            Dim result As Integer = MessageBox.Show("게임을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Me.Close()
            End If
        End If
        If functionKey2 = True Then
            player.Play("select")
            functionKey2 = False
            explanation = False

        End If
    End Sub

    'stageMenu
    Private Sub stageMenu()
        heroimage = heroList(9)
        If explanation = False Then
            backImage = backList(9)
            arrowOn = True
        End If
        If goxy = 1 Then
            If arrowSet < 2 Then
                arrowLocation += 135
                arrowSet += 1
            End If
        ElseIf goxy = 2 Then
            If arrowSet > 0 Then
                arrowLocation -= 135
                arrowSet -= 1
            End If
        End If

        If arrowLocation = 285 And functionKey = True Then
            player.Play("select")
            functionKey = False
            Dim result As Integer = MessageBox.Show("메인메뉴로 돌아가시겠습니까?", "", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                menuOn = False
                arrowOn = False
                returndead = 0
                gameTimer.Stop()
                iTimeCount = 0
                Timedisplay = TimeToString()
                arrowLocationXL = 460
                arrowLocationXR = 630
                arrowLocation = 550
                If stageNum = 1 Then
                    player.Pause("stage1")
                    player.Play("startsound")
                ElseIf stageNum = 2 Then
                    player.Pause("stage2")
                    player.Play("startsound")
                ElseIf stageNum = 3 Then
                    player.Pause("stage3")
                    player.Play("startsound")
                ElseIf stageNum = 4 Then
                    player.Pause("stage4")
                    player.Play("startsound")
                End If
                stageNum = 0
            End If
        ElseIf arrowLocation = 420 And functionKey = True Then
            player.Play("select")
            functionKey = False
            If stageNum = 1 And stage1EventOn = True Then
                arrowOn = False
                explanation = True
                backImage = backList(10)
            ElseIf stageNum = 2 And stage2EventOn = True Then
                If lightOn = False Then
                    menu2light = True
                    lightOn = True
                End If
                arrowOn = False
                explanation = True
                backImage = backList(11)
            ElseIf stageNum = 3 And stage3EventOn = True Then
                arrowOn = False
                explanation = True
                backImage = backList(12)
            ElseIf stageNum = 4 And stage4EventOn = True Then
                arrowOn = False
                explanation = True
                backImage = backList(13)
                backImage = backList(13)
                backImage = backList(13)
            End If
        ElseIf arrowLocation = 555 And functionKey = True Then
            player.Play("select")
            functionKey = False
            Dim result As Integer = MessageBox.Show("게임을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo)
            If result = DialogResult.Yes Then
                Me.Close()
            End If
        End If

        If explanation = True And functionKey2 = True Then
            player.Play("select")
            If menu2light = True Then
                lightOn = False
                menu2light = False
            End If
            functionKey2 = False
            explanation = False
            arrowOn = True
            backImage = backList(9)
        End If

        '메인 메뉴 나가기
        If functionKey2 = True Then
            arrowLocationXL = 460
            arrowLocationXR = 630
            arrowLocation = 550
            menuOn = False
            player.Play("select")
            arrowOn = False
            functionKey2 = False
            If stageNum = 4 Then
                ghostTimer.Start()
            End If
            gameTimer.Start()
            Timer1.Start()
            openTimer.Stop()
            heroimage = heroList(1)
        End If

    End Sub

    '오프닝화면 키 조정 타이머스레드
    Private Sub openTimer_Tick(sender As Object, e As EventArgs) Handles openTimer.Tick
        If stageNum = 0 Then
            stageStart()
            If player.IsStopped("startsound") Then
                player.Play("startsound")
            End If
        ElseIf menuOn = True Then

            stageMenu()
        End If
        Invalidate()
    End Sub

    '플레이 시간 측정
    Private Function TimeToString() As String

        millisecond = ((iTimeCount Mod 1000) \ 10)

        second = (iTimeCount - millisecond) \ 1000
        second = second Mod 60

        minute = (iTimeCount - millisecond) \ 1000
        minute = minute \ 60

        hour = (iTimeCount - millisecond) \ 1000
        hour = (hour \ 60) \ 60

        Dim sMillisecond As String
        Dim sSecond As String
        Dim sMinute As String

        If millisecond < 10 Then
            sMillisecond = "0" + CStr(millisecond)
        Else
            sMillisecond = millisecond
        End If

        If second >= 10 Then
            sSecond = second
        Else
            sSecond = "0" + CStr(second)
        End If

        If minute >= 10 Then
            sMinute = minute
        Else
            sMinute = "0" + CStr(minute)
        End If

        Return sMinute + ":" + sSecond + ":" + sMillisecond
    End Function

    'stage1
    Private Sub stage1Ob()

        backImage = backList(1)

        pTop = 150
        pBottom = 185
        pLeft = 36
        pRight = 70

        stageO.door = New Rectangle(CInt(Me.Width / 2 - 30), 1, 60, 150)
        stageO.table = New Rectangle(CInt(Me.Width / 2) - 5, 327, 165, 150)
        stageO.hint1 = New Rectangle(CInt(Me.Width / 2) + 32, 320, 60, 20)
        stageO.bookshelf = New Rectangle(56, 330, 50, 50)
        stageO.rook = New Rectangle(200, 460, 60, 65)
        stageO.rook2 = New Rectangle(CInt(Me.Width / 2) + 285, 340, 60, 65)

        If stageO.rook2.Contains(moveX, moveY) Then
            noWalk()
        End If

        If stageO.door.Contains(moveX, moveY) Then
            If stage1R = "12001" Then
                stage1L.Text = "문이 열렸다."
                scriptOn = True
                moveX = Me.Width / 2
                moveY = Me.Height - 240
                stageNum = 2
                player.Pause("stage1")
                player.Play("stage2")
            ElseIf functionKey = True Then
                If resultForm.Visible = False Then
                    player.Play("function")
                    functionKey = False
                    resultForm.ShowDialog()
                    If Not stage1R = "12001" Then
                        stage1L.Text = "오답인 듯 하다."
                        scriptOn = True
                        functionKey = False
                    Else
                        player.Play("openDoor")
                        player.Pause("stage1")
                    End If
                End If
            End If
        End If


        If stageO.table.Contains(moveX, moveY) Then
            noWalk()
        ElseIf (stageO.table.Contains(moveX + 10, moveY + 10) Or stageO.table.Contains(moveX - 10, moveY - 10)) And functionKey = True Then
            If stageO.hint1.Contains(moveX, moveY + 10) And functionKey = True Then
                player.Play("function")
                functionKey = False
                Microsoft.VisualBasic.Interaction.MsgBox(hint1,, "쪽지")
                stage1EventOn = True
            Else
                player.Play("function")
                stage1L.Text = "테이블 위에 무언가가 있다!"
                scriptOn = True
                functionKey = False
            End If
        End If

        If stageO.bookshelf.Contains(moveX, moveY) Then
            noWalk()
        ElseIf (stageO.bookshelf.Contains(moveX + heroimage.Width + 1, moveY) Or
                stageO.bookshelf.Contains(moveX, moveY + heroimage.Height + 1) Or
                stageO.bookshelf.Contains(moveX - 1, moveY) Or
                stageO.bookshelf.Contains(moveX, moveY - heroimage.Height - 1)) And functionKey = True Then
            functionKey = False
            stage1L.Text = "비주얼베이직 교과서군 .."
            scriptOn = True
        End If

        If stageO.rook.Contains(moveX, moveY) Then
            noWalk()
        End If

    End Sub

    'stage2
    Private Sub stage2Ob()
        If stage2R = "카로" Then
            backImage = backList(3)
        Else
            backImage = backList(2)
        End If

        pTop = 200
        pBottom = 180
        pLeft = 80
        pRight = 110

        stageO.door = New Rectangle(CInt(Me.Width / 2 - 120), Me.Height - heroList(1).Height - pBottom, 220, 150)
        stageO.door2 = New Rectangle(CInt(Me.Width / 2 - 120), 0, 220, pTop + 5)
        stageO.bookshelf = New Rectangle(CInt(Me.Width / 2 + 175), 0, 290, pTop + 5)
        stageO.shelf = New Rectangle(CInt(Me.Width / 2 - 490), 0, 290, pTop + 5)
        stageO.table = New Rectangle(CInt(Me.Width / 2 + 390), 220, 80, 80)
        stageO.switchLight = New Rectangle(pLeft, 390, 60, 80)
        stageO.deads = New Rectangle(CInt(Me.Width / 2) - 40, 320, 70, 80)
        stageO.deadstone = New Rectangle(CInt(Me.Width / 2) - 50, 400, 75, 50)

        If stageO.door2.Contains(moveX, moveY) Then
            If stage2R = "카로" Then
                stage1L.Text = "문이 열렸다."
                scriptOn = True
                moveX = 110
                moveY = Me.Height - 270
                zergTimer.Start()
                stageNum = 3
                player.Pause("stage2")
                player.Play("stage3")
            ElseIf functionKey = True Then
                If resultForm.Visible = False Then
                    functionKey = False
                    player.Play("function")
                    resultForm.ShowDialog()
                    If Not stage2R = "카로" Then
                        stage1L.Text = "오답인 듯 하다."
                        scriptOn = True
                        functionKey = False
                    Else
                        player.Play("openDoor")
                        player.Pause("stage2")
                    End If
                End If
            End If
        End If

        If stageO.door.Contains(moveX, moveY) Then
            stageNum = 1
            moveX = Me.Width / 2
            moveY = 170
            player.Pause("stage2")
            player.Play("stage1")
        End If


        If stageO.shelf.Contains(moveX, moveY) And functionKey = True Then
            player.Play("function")
            stage1L.Text = stage2Str1
            scriptOn = True
            functionKey = False
        End If

        If stageO.bookshelf.Contains(moveX, moveY) And functionKey = True Then
            If tableEvent = False Then
                player.Play("function")
                stage1L.Text = stage2Str2
                scriptOn = True
                functionKey = False
            ElseIf tableEvent = True Then
                player.Play("function")
                stage1L.Font = New Font("Comic Sans MS", 20)
                stage1L.Text = stage2Str3
                scriptOn = True
                bookAdd = True
            End If
        End If

        If stageO.table.Contains(moveX, moveY) Then
            noWalk()
        ElseIf (stageO.table.Contains(moveX + 10, moveY + 10) Or stageO.table.Contains(moveX - 10, moveY - 10)) And functionKey = True Then
            If bookAdd = False Then
                player.Play("function")
                stage1L.Text = stage2Str4
                scriptOn = True
                tableEvent = True
            ElseIf bookAdd = True Then
                player.Play("function")
                functionKey = False
                stage2EventOn = True
                Microsoft.VisualBasic.Interaction.MsgBox(hint2,, "문제")
            End If
            functionKey = False
        End If

        If stageO.switchLight.Contains(moveX, moveY) Then
            noWalk()
        ElseIf (stageO.switchLight.Contains(moveX + 10, moveY + 10) Or stageO.switchLight.Contains(moveX - 10, moveY - 10)) And functionKey = True Then
            player.Play("function")
            If lightOn = False Then
                lightOn = True
            ElseIf lightOn = True Then
                lightOn = False
            End If
            functionKey = False
        End If

        If stageO.deads.Contains(moveX, moveY) Then
            noWalk()
        ElseIf (stageO.deads.Contains(moveX + 10, moveY + 10) Or stageO.deads.Contains(moveX - 10, moveY + 10)) And functionKey = True Then
            player.Play("function")
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage2Str5
            scriptOn = True
            functionKey = False
        End If

        If stageO.deadstone.Contains(moveX, moveY) Then
            noWalk()
        ElseIf (stageO.deadstone.Contains(moveX + 10, moveY + 10) Or stageO.deadstone.Contains(moveX - 10, moveY - 10)) And functionKey = True Then
            player.Play("function")
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage2Str6
            scriptOn = True
            functionKey = False
        End If

    End Sub

    'stage3
    Private Sub stage3Ob()

        backImage = backList(4)
        pTop = 110
        pBottom = 180
        pLeft = 30
        pRight = 75

        stageO.door = New Rectangle(55, Me.Height - heroList(1).Height - pBottom, 110, 150)
        stageO.door2 = New Rectangle(Me.Width - 195, Me.Height - heroList(1).Height - pBottom, 110, 150)
        stageO.deads = New Rectangle(55, Me.Height - heroList(1).Height - pBottom, 1, 1)
        stageO.deadstone = New Rectangle(30, 170, 40, 60)
        stageO.zerg = New Rectangle(Me.Width / 2 + zergX, zergY, 300, 230)
        stageO.tWall = New Rectangle(Me.Width / 2 - 410, 250, 350, 140)
        stageO.tWall2 = New Rectangle(Me.Width / 2 + 40, 250, 350, 140)
        stageO.lWall = New Rectangle(Me.Width / 2 - 410, 250, 60, 350)
        stageO.rWall = New Rectangle(Me.Width / 2 + 330, 250, 60, 350)
        stageO.result1 = New Rectangle(Me.Width / 2 - 350, 465, 170, 200)
        stageO.result2 = New Rectangle(Me.Width / 2 - 110, 465, 190, 200)
        stageO.result3 = New Rectangle(Me.Width / 2 + 150, 465, 190, 200)

        If stageO.door.Contains(moveX, moveY) Then
            zergTimer.Stop()

            stageNum = 2
            player.Pause("stage3")
            player.Play("stage2")
            moveX = Me.Width / 2
            moveY = 205

        End If

        If stageO.door2.Contains(moveX, moveY) Then
            If result3stageOn = True Then
                zergTimer.Stop()
                ghostTimer.Start()

                stageNum = 4
                player.Pause("stage3")
                player.Play("stage4")
                errorclear = True

            ElseIf functionKey = True Then
                functionKey = False
                If result3stageOn = False Then
                    stage1L.Text = "문이 잠겨 있어서 갈 수 없다."
                    scriptOn = True
                End If
            End If
        End If

        If stageO.tWall.Contains(moveX, moveY) Then
            noWalk()
        End If

        If stageO.tWall2.Contains(moveX, moveY) Then
            noWalk()
        End If

        If stageO.lWall.Contains(moveX, moveY) Then
            noWalk()
        End If

        If stageO.rWall.Contains(moveX, moveY) Then
            noWalk()
        End If

        If stageO.result1.Contains(moveX, moveY) Then
            If result3stage = 2 And result3stageOn = False Then
                player.Play("openDoor")
                stage1L.Text = "문이 열렸다."
                scriptOn = True
                result3stageOn = True
            Else
                result3stage = 0
            End If
        End If

        If stageO.result2.Contains(moveX, moveY) Then
            If result3stage = 0 And result3stageOn = False Then
                result3stage += 1
            ElseIf Not (result3stage = 1) Then
                result3stage = 0
            End If
        End If

        If stageO.result3.Contains(moveX, moveY) Then
            If result3stage = 1 And result3stageOn = False Then
                result3stage += 1
            ElseIf Not (result3stage = 2) Then
                result3stage = 0
            End If
        End If

        If stageO.zerg.Contains(moveX, moveY) Then

            openTimer.Start()
            Timer1.Stop()
            arrowOn = False
            gameTimer.Stop()
            stage1L.Text = ""
            stageNum = 0
            heroimage = heroList(9)
            backImage = backList(7)

            returndead = 3
            life += 1

        End If

        If stageO.deadstone.Contains(moveX, moveY) Then
            noWalk()
        ElseIf (stageO.deadstone.Contains(moveX + 10, moveY + 10) Or stageO.deadstone.Contains(moveX + 10, moveY - 10) Or
                stageO.deadstone.Contains(moveX - 10, moveY)) And functionKey = True Then
            functionKey = False
            player.Play("function")
            stage3EventOn = True
            Microsoft.VisualBasic.Interaction.MsgBox(stage3Str1,, "묘비")
        End If
    End Sub

    '괴물 출현 타이머
    Private Sub zergTimer_Tick(sender As Object, e As EventArgs) Handles zergTimer.Tick
        If stageNum = 3 Then
            If zergY = -160 Then
                player.Play("monserSound")
                zergX = rd.Next(-240, -59)
                zergY += 15
                zergOn = True
            ElseIf (zergY > -160 And zergY < 65) And zergOn = True Then
                zergY += 15
            ElseIf zergY = 65 Or zergOn = False Then
                zergOn = False
                zergY -= 15
            End If
        End If
    End Sub

    '망자 소환 함수
    Private Sub ghostadd(x, y)
        Dim gt As ghost
        gt.posX = x
        gt.posY = y
        gt.ghostImage = ghostList(1)
        gt.gtrt = New Rectangle(gt.posX, gt.posY, gt.ghostImage.Width, gt.ghostImage.Height)
        ghostArr.Add(gt)
    End Sub

    'stage4
    Private Sub stage4Ob()
        If errorclear = True Then
            Sleep(100)
            moveX = Me.Width / 2
            moveY = 160
            errorclear = False
        End If

        backImage = backList(5)

        pTop = 140
        pBottom = 100
        pLeft = 65
        pRight = 105

        stageO.door = New Rectangle((Me.Width / 2) - 80, 0, 100, 140)
        stageO.door2 = New Rectangle((Me.Width / 2) - 80, Me.Height - heroList(1).Height - 100, 100, 140)
        stageO.deadstone = New Rectangle((Me.Width / 2) - 480, 0, 80, 140)

        If stageO.deadstone.Contains(moveX, moveY - 1) And functionKey = True Then
            functionKey = False
            player.Play("function")
            stage4EventOn = True
            Microsoft.VisualBasic.Interaction.MsgBox(stage4Str1,, "알림판")
            stage4event = True
        End If

        For i = 0 To 11
            coffinOpen(i) = False
        Next

        Dim coffinY As Integer = 150 '왼쪽 첫번째 관 Y
        For i = 0 To 11 '관 규격 설정
            If i < 6 Then
                coffin(i) = New Rectangle(40, coffinY, 20, 70)
                coffinY += 90
                If i = 5 Then
                    coffinY = 150
                End If
            Else
                coffin(i) = New Rectangle(Me.Width - 110, coffinY, 20, 70)
                coffinY += 90
            End If
        Next

        For i = 0 To 11 '망자 관
            If Not (i = rdkey) Then
                If coffin(i).Contains(moveX - 1, moveY) And functionKey = True Then
                    functionKey = False
                    If coffinOpen(i) = False And stage4event = True Then
                        coffinOpen(i) = True
                        player.Play("function")
                        If i < 6 Then
                            ghostadd(coffin(i).X - 60, coffin(i).Y + 50)
                            'ghostadd(coffin(i).X - 60, coffin(i).Y + 100)
                        Else
                            ghostadd(coffin(i).X + 80, coffin(i).Y + 50)
                            'ghostadd(coffin(i).X + 80, coffin(i).Y + 100)
                        End If
                        stage1L.Text = "이 관이 아닌것 같다..."
                            scriptOn = True
                        ElseIf coffinOpen(i) = False Then
                            stage1L.Text = "관이 있군..."
                        scriptOn = True
                    End If
                End If
            End If
        Next

        If coffin(rdkey).Contains(moveX - 1, moveY) And functionKey = True Then '열쇠 관
            functionKey = False
            coffinOpen(rdkey) = True
            player.Play("function")
            stage1L.Text = "열쇠를 찾았다!!"
            scriptOn = True
            result4stageOn = True
        End If

        If stageO.door.Contains(moveX, moveY - 1) Then
            ghostTimer.Stop()
            zergTimer.Start()

            stageNum = 3
            moveX = Me.Width - 140
            moveY = Me.Height - 250

            player.Pause("stage4")
            player.Play("stage3")
        End If

        If stageO.door2.Contains(moveX, moveY + 1) Then
            If result4stageOn = True And functionKey = True Then
                functionKey = False
                gameTimer.Stop()
                ghostTimer.Stop()
                stageNum = 5
                heroimage = heroList(9)
                backImage = backList(14)
                scriptOn = True
                stage5.Start()
                Timer1.Stop()
                player.Pause("stage4")
                ghostArr.Clear()

            End If
        End If

        If ghostArr.Count > 0 Then
            For i = 0 To ghostArr.Count - 1 '망자와 부딪혔을 때 게임 종료
                Dim gtv = CType(ghostArr(i), ghost)
                If gtv.gtrt.Contains(moveX + (heroimage.Width / 2), moveY + (heroimage.Height / 2)) Or
                    gtv.gtrt.Contains(moveX + (heroimage.Width / 2), moveY + 5) Or
                    gtv.gtrt.Contains(moveX + (heroimage.Width / 2), moveY + heroimage.Height - 5) Or
                    gtv.gtrt.Contains(moveX + (heroimage.Width / 2) + 5, moveY + (heroimage.Height / 2)) Or
                    gtv.gtrt.Contains(moveX + (heroimage.Width / 2) - 5, moveY + (heroimage.Height / 2)) Then

                    Timer1.Stop()
                    openTimer.Start()
                    gameTimer.Stop()
                    arrowOn = False
                    stage1L.Text = ""
                    backImage = backList(7)
                    heroimage = heroList(9)
                    returndead = 4
                    life += 1
                    stageNum = 0
                End If
            Next
        End If

    End Sub

    'stage5
    Private Sub stage5Ob()
        heroimage = heroList(9)
        Invalidate()
        If stage1L.Text = "" Then
            functionKey = False
            player.Play("stage1")
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str1
        ElseIf functionKey = True And stage1L.Text = stage5Str1 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str2
        ElseIf functionKey = True And stage1L.Text = stage5Str2 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str3
        ElseIf functionKey = True And stage1L.Text = stage5Str3 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str4
        ElseIf functionKey = True And stage1L.Text = stage5Str4 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str5
        ElseIf functionKey = True And stage1L.Text = stage5Str5 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str6
        ElseIf functionKey = True And stage1L.Text = stage5Str6 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str7
        ElseIf functionKey = True And stage1L.Text = stage5Str7 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str8
        ElseIf functionKey = True And stage1L.Text = stage5Str8 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            stage1L.Text = stage5Str9
        ElseIf functionKey = True And stage1L.Text = stage5Str9 Then
            functionKey = False
            stage1L.Font = New Font("Comic Sans MS", 20)
            backImage = backList(15)
            stage1L.Text = " "
            lifeLabel.Text = "죽은횟수  :  " + Str(life)
            timerLabel.Text = "플레이타임  :  " + Timedisplay
        ElseIf functionKey = True And lifeLabel.Text.Length > 0 Then
            functionKey = False
            backImage = backList(16)
            lifeLabel.Text = ""
            timerLabel.Text = ""
            returndead = 0
            stage5.Stop()
            stageNum = 0
            stageBowl = 5
            openTimer.Start()
        End If

    End Sub

    'stage5 스레드
    Private Sub stage5_Tick(sender As Object, e As EventArgs) Handles stage5.Tick
        stage5Ob()

    End Sub

    '망자 이동 타이머 스레드
    Private Sub ghostTimer_Tick(sender As Object, e As EventArgs) Handles ghostTimer.Tick
        For i = 0 To ghostArr.Count - 1
            Dim gtv = CType(ghostArr(i), ghost)
            If rd.Next(0, 2) = 1 Then
                If rd.Next(0, 2) = 1 Then
                    gtv.posX += 10
                    gtv.ghostImage = ghostList(8)
                    gtv.gtrt = New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height)
                Else
                    gtv.posX -= 10
                    gtv.ghostImage = ghostList(6)
                    gtv.gtrt = New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height)
                End If
            Else
                If rd.Next(0, 2) = 1 Then
                    gtv.posY += 10
                    gtv.ghostImage = ghostList(2)
                    gtv.gtrt = New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height)
                Else
                    gtv.posY -= 10
                    gtv.ghostImage = ghostList(4)
                    gtv.gtrt = New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height)
                End If
            End If
            ghostArr(i) = gtv
        Next
        For i = 0 To ghostArr.Count - 1
            Dim gtv = CType(ghostArr(i), ghost)
            If gtv.posX < 65 Then
                gtv.posX += 10
                gtv.gtrt = New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height)
            ElseIf gtv.posX > Me.Width - pRight Then
                gtv.posX -= 10
                gtv.gtrt = New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height)
            End If
            If gtv.posY < 140 Then
                gtv.posY += 10
                gtv.gtrt = New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height)
            ElseIf gtv.posY > Me.Height - gtv.ghostImage.Height - 100 Then
                gtv.posY -= 10
                gtv.gtrt = New Rectangle(gtv.posX, gtv.posY, gtv.ghostImage.Width, gtv.ghostImage.Height)
            End If
            ghostArr(i) = gtv
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '효과음 불러오기
        player.AddSound("startsound", "gameSound/startbgm(ib-memory).mp3") '로딩 음악
        player.AddSound("stage1", "gameSound/stage1.mp3") '스테이지1 음악
        player.AddSound("stage2", "gameSound/stage2.mp3") '스테이지2 음악
        player.AddSound("stage3", "gameSound/stage3.mp3") '스테이지3 음악
        player.AddSound("stage4", "gameSound/stage4.mp3") '스테이지4 음악
        player.AddSound("function", "gameSound/functionsound.mp3") 'Function소리
        player.AddSound("openDoor", "gameSound/openDoor.mp3") '문여는소리
        player.AddSound("select", "gameSound/selectSound.mp3") '선택하는 소리
        player.AddSound("monserSound", "gameSound/monsterSound.mp3") '몬스터 사운드
        player.SetVolume("stage1", 300)
        player.SetVolume("stage2", 500)
        player.SetVolume("stage3", 300)
        player.SetVolume("stage4", 300)
        'player.Play("startsound")

        'hero 이미지 불러오기
        Dim i As Integer
        For i = 1 To 9 Step 1
            heroList(i) = Image.FromFile("gameImage/heroImage/h" + Str(i) + "ero.png")
        Next i
        '배경 이미지 불러오기
        For i = 0 To 16 Step 1
            backList(i) = Image.FromFile("gameImage/mapImage/_" + Str(i) + "Room.png")
        Next i
        '오브젝트 이미지 불러오기
        For i = 0 To 3 Step 1
            objectList(i) = Image.FromFile("gameImage/objectImage/_" + Str(i) + ".png")
        Next i

        '망자 이미지 불러오기
        For i = 1 To 8 Step 1
            ghostList(i) = Image.FromFile("gameImage/objectImage/_" + Str(i) + "mang.png")
        Next
        '4스테이지 열쇠 관
        rdkey = rd.Next(0, 11)
        'Timer1.Start()
        openTimer.Start()
        heroimage = heroList(9)
        backImage = backList(0)
        objectImage = objectList(0)

        '@@@@@@@@@@@@@@@@@@@@@!!!!!!!!임시조정!!!!!!@@@@@@@@@@@@@@@@@@@@@@@@@@
        'stageNum = 4

    End Sub

    '초 타이머
    Private Sub gameTimer_Tick(sender As Object, e As EventArgs) Handles gameTimer.Tick
        iTimeCount += 14
        Timedisplay = TimeToString()
    End Sub

    '메인 타이머 스레드
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '방향 키
        If Not stageNum = 0 Then
            If goxy = 1 Then
                If flagDown = 0 Then '아래 방향 키
                    If moveY < Me.Height - heroList(1).Height - pBottom Then
                        moveY += ySpeed
                    End If
                    flagAhead = 1
                    flagDown = 1
                    heroimage = heroList(2)
                ElseIf flagDown = 1 Then
                    If moveY < Me.Height - heroList(1).Height - pBottom Then
                        moveY += ySpeed
                    End If
                    flagAhead = 1
                    flagDown = 0
                    heroimage = heroList(1)
                End If
            ElseIf goxy = 2 Then '윗 방향키
                If flagUp = 0 Then
                    If moveY > pTop Then
                        moveY -= ySpeed
                    End If
                    flagAhead = 2
                    flagUp = 1
                    heroimage = heroList(4)
                ElseIf flagUp = 1 Then
                    If moveY > pTop Then
                        moveY -= ySpeed
                    End If
                    flagAhead = 2
                    flagUp = 0
                    heroimage = heroList(3)
                End If
            ElseIf goxy = 3 Then '왼 방향키
                If flagLeft = 0 Then
                    If moveX > pLeft Then
                        moveX -= xSpeed
                    End If
                    flagAhead = 3
                    flagLeft = 1
                    heroimage = heroList(6)
                ElseIf flagLeft = 1 Then
                    If moveX > pLeft Then
                        moveX -= xSpeed
                    End If
                    flagAhead = 3
                    flagLeft = 0
                    heroimage = heroList(5)
                End If
            ElseIf goxy = 4 Then '오른 방향키
                If flagRight = 0 Then
                    If moveX < Me.Width - pRight Then
                        moveX += xSpeed
                    End If
                    flagAhead = 4
                    flagRight = 1
                    heroimage = heroList(8)
                ElseIf flagRight = 1 Then
                    If moveX < Me.Width - pRight Then
                        moveX += xSpeed
                    End If
                    flagAhead = 4
                    flagRight = 0
                    heroimage = heroList(7)
                End If
            End If
        End If

        If stageNum = 1 Then
            stage1Ob()
            If player.IsStopped("stage1") Then
                player.Play("stage1")
            End If
        ElseIf stageNum = 2 Then
            stage2Ob()
            If player.IsStopped("stage2") Then
                player.Play("stage2")
            End If
        ElseIf stageNum = 3 Then
            stage3Ob()
            If player.IsStopped("stage3") Then
                player.Play("stage3")
            End If
        ElseIf stageNum = 4 Then
            stage4Ob()
            If player.IsStopped("stage4") Then
                player.Play("stage4")
            End If
        End If

        If functionKey2 = True Then
            functionKey2 = False
            menuOn = True
            arrowSet = 0
            stageMenu()
            heroimage = heroList(9)
            arrowLocationXL = 70
            arrowLocationXR = 390
            arrowLocation = 285
            gameTimer.Stop()
            ghostTimer.Stop()
            Timer1.Stop()
            openTimer.Start()
        End If

        ToolStripStatusLabel1.Text = "x좌표 : " + Str(moveX) + "  y좌표 : " + Str(moveY) + "                      죽은횟수 : " + Str(life) + "                      플레이 시간 : " + Timedisplay
        Invalidate()
    End Sub

    '스크립트 on/off timer
    Private Sub scriptTimer_Tick(sender As Object, e As EventArgs) Handles scriptTimer.Tick
        If scriptOn = True Then
            stage1L.Text = ""
            scriptOn = False
        End If
    End Sub

    '키가 눌러졌을 때
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Down Then
            goxy = 1
        ElseIf e.KeyCode = Keys.Up Then '윗 방향 키
            goxy = 2
        ElseIf e.KeyCode = Keys.Left Then  '왼쪽 방향 키
            goxy = 3
        ElseIf e.KeyCode = Keys.Right Then  '오른쪽 방향 키
            goxy = 4
        End If
        If e.KeyCode = Keys.Z Then
            functionKey = True
        End If
        If e.KeyCode = Keys.X Then
            functionKey2 = True
        End If

    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        '케릭터가 서있는지 확인 하는 if 문
        If flagAhead = 1 Then
            heroimage = heroList(1)
            flagAhead = 0
            flagDown = 0
        ElseIf flagAhead = 2 Then
            heroimage = heroList(3)
            flagAhead = 0
            flagUp = 0
        ElseIf flagAhead = 3 Then
            heroimage = heroList(5)
            flagAhead = 0
            flagLeft = 0
        ElseIf flagAhead = 4 Then
            heroimage = heroList(7)
            flagAhead = 0
            flagRight = 0
        End If

        If e.KeyCode = Keys.Z Then
            functionKey = False
        End If
        If e.KeyCode = Keys.X Then
            functionKey2 = False
        End If
        goxy = 0
        Invalidate()
    End Sub


End Class
