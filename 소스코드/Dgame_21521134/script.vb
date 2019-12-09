Module script
    '스크립트 발생 판별 변수
    Public scriptOn As Boolean = False

    '스크립트 변수 모음
    '1스테이지
    Public stage1Str1 As String = "음 ...? 여기는 어디지 ..?"
    Public stage1Str2 As String = "분명히 비주얼베이직 시간이였는데..."
    Public stage1Str3 As String = "아!! 방금 카트 1등 중이였는데!!"
    Public stage1Str4 As String = "이럴수가.. 1등 놓쳤잖아 .."
    Public stage1Str5 As String = "일단 둘러보고 빨리 빠져나가보자!"
    Public stage1Str6 As String = "빨리 카트 하고 피파해야해!!"
    Public hint1 As String = "방탈출 게임에 초대 된 것을 환영합니다" & vbCrLf &
        "당신이 사랑하는 비주얼 베이직 시간을 위하여 제작된 게임으로" & vbCrLf &
        "각종 단서나 문제등을 풀어야만이 방을 탈출 할 수 있게 됩니다." & vbCrLf & vbCrLf &
        "이번 방은 가벼운 몸 풀기 문제로 시작해보려 합니다." & vbCrLf &
        "문으로 가보세요~" & vbCrLf & vbCrLf &
        "                                                           Professor.Kang"
    '2스테이지
    Public stage2Str1 As String = "먹음직스런 음식들이 보인다."
    Public stage2Str2 As String = "책들이 보인다."
    Public stage2Str3 As String = "저기 뭔가 다른 책들과는 다른 책이 보인다." & vbCrLf & "책을 얻었습니다!"
    Public stage2Str4 As String = "책을 가져와서 읽어볼까 ?"
    Public stage2Str5 As String = "알고리즘을 풀다 못 풀어서" & vbCrLf & " 죽은 시체인 듯 하다.."
    Public stage2Str6 As String = "묘비 : 몬테카를로 망해랏!!" & vbCrLf & "아무래도 작년 교수님 파이썬 수업을 들은 모양이다 .."
    Public hint2 As String = "알고리즘 문제" & vbCrLf &
        "방을 탈출 하고 싶다면 이 문제를 풀어서 번호를 입력해야만 탈출 하실 수 있습니다." & vbCrLf & vbCrLf &
        "문제입니다." & vbCrLf & vbCrLf &
        "몬테카를로는 모나코를 구성하는 10개 행정구 가운데 하나이다." & vbCrLf &
        "종종 모나코의 수도로 오해되기도 하나 이는 사실이 아니며,  " & vbCrLf &
        "도시 국가인 모나코의 수도는 모나코 영토 전체이다." & vbCrLf &
        "지중해 연안의 리비에라 해안에 위치하고 있는 몬테카를로는" & vbCrLf &
        "프랑스가 그 주변을 둘러싸고 있으며, 이탈리아와도 매우 가깝다." & vbCrLf &
        "거주 인구는 약 3,000명이다. 카지노와 도박장으로 유명하다." & vbCrLf & vbCrLf &
        "다음 몬테카를로를 array[5] 배열에 넣어, 배열의 0보다 큰" & vbCrLf &
        "짝수번째만 골랐을 때 나오는 문자는?" & vbCrLf & vbCrLf &
        "                                                               Professor.Kang"
    '3스테이지
    Public stage3Str1 As String = "많이 깨져서 읽기 힘들지만 이렇게 적혀있다." & vbCrLf &
        "앞의 괴물을 조심..라" & vbCrLf & vbCrLf & "'다음 방.. 번호.. " & vbCrLf & "시험과제 제출..에서 0..다 큰 수 중" & vbCrLf & "가장 작은 수부터..' 라고한다."

    '4스테이지
    Public stage4Str1 As String = "이 방은 알고리즘을 풀지 못해 잠든 이들이 묻힌 곳입니다." & vbCrLf & vbCrLf & "알고리즘은 운도 따라줘야 빠르게 생각해낼 수가 있습니다." & vbCrLf &
     "당신의 알고리즘 실력도 운이 따라줘야한다는 말입니다." & vbCrLf & "고로 당신의 운을 시험해 보겠습니다." & vbCrLf & vbCrLf & "아래의 관을 열어서 마지막 탈출구의 열쇠를 찾아내보세요" & vbCrLf &
     "만약 열쇠가 들어있지 않은 관을 열었다면 ... " & vbCrLf & "묻혀 있는 이들이 깨어날지도 몰라요. " & vbCrLf & "닫히지도 않을거에요... 하하하하 " & vbCrLf & vbCrLf &
        "                                                               Professor.Kang"

    '5스테이지
    Public stage5Str1 As String = "음 ...."
    Public stage5Str2 As String = "'눈을 떠 보니 교실이다.'"
    Public stage5Str3 As String = "꿈이였나 ..."
    Public stage5Str4 As String = "'너무나도 생생한 꿈이였다.'"
    Public stage5Str5 As String = "'교수님께서 종강을 하신다고 한다.'"
    Public stage5Str6 As String = "'수업이 끝나고 교실을 나서면서 혼잣말을 했다.'"
    Public stage5Str7 As String = "아.. 꿈이 너무 생생했어.."
    Public stage5Str8 As String = "과연 꿈이였을까요? 하하하.."
    Public stage5Str9 As String = "'앞에 교수님께서는 돌아보시지도 않은 채 의미심장한" & vbCrLf & "말씀을 남기시고 방으로 들어가신다.'"


End Module
