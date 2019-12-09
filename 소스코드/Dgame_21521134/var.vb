Module var
    '주인공 위치 구조체
    Structure Hero
        Public pos As Point
        Public rect As Rectangle
    End Structure

    '오브젝트 위치 구조체
    Structure StageO
        Public door As Rectangle '매 스테이지 들어온 문
        Public door2 As Rectangle '매 스테이지 나가는 문 
        Public bookshelf As Rectangle
        Public shelf As Rectangle
        Public table As Rectangle
        Public rook As Rectangle '1스테이지 돌
        Public rook2 As Rectangle '1스테이지 돌
        Public hint1 As Rectangle '1스테이지 힌트 위치
        Public switchLight As Rectangle '2 스테이지 스위치 위치
        Public deads As Rectangle '2스테이지 시체 위치
        Public deadstone As Rectangle '묘비 위치
        Public zerg As Rectangle '3스테이지 괴물
        Public tWall As Rectangle '3스테이지 윗 왼쪽 벽
        Public tWall2 As Rectangle '3스테이지 윗 오른쪽 벽
        Public lWall As Rectangle '3스테이지 왼쪽 벽
        Public rWall As Rectangle '3스테이지 오른쪽 벽
        Public result1 As Rectangle '3스테이지 1번째 양탄자
        Public result2 As Rectangle '3스테이지 2번째 양탄자
        Public result3 As Rectangle '3스테이지 3번째 양탄자
    End Structure

    '오픈스테이지 화살표 끝 지정 플래그 변수
    Public arrowSet As Integer = 0

    Public arrowLocationXL As Integer = 460
    Public arrowLocationXR As Integer = 630
    Public arrowLocation As Integer = 550
    Public arrowOn As Boolean = True

    '2스테이지 불 확인 변수
    Public lightOn As Boolean = False

    '2스테이지 이벤트 변수
    Public bookAdd As Boolean = False
    Public tableEvent As Boolean = False
    Public open2Door As Boolean = False

    '3스테이지 괴물 지정 변수
    Public zergOn As Boolean = False '괴물의 움직임 포착 변수
    Public zergX As Integer = -240
    Public zergY As Integer = -160

    '3스테이지 답변수
    Public result3stage As Integer = 0
    Public result3stageOn As Boolean = False
    Public errorclear As Boolean = False

    '4스테이지 관
    Public coffin(12) As Rectangle
    Public coffinOpen(12) As Boolean
    Public rd As New Random '열쇠관랜덤함수
    Public rdkey As Integer '열쇠관변수
    Public result4stageOn As Boolean = False '열쇠관

    '4스테이지 망자 구조체
    Structure ghost
        Public posX As Integer '망자위치X
        Public posY As Integer '망자위치Y
        Public gtrt As Rectangle '망자범위
        Public ghostImage As Image '망자이미지
    End Structure

    Public ghostArr As New ArrayList '4스테이지 망자 배열
    Public stage4event As Boolean = False '4스테이지 이벤트 확인

    '이미지 리스트
    Public heroList(9) As Image
    Public backList(16) As Image
    Public objectList(8) As Image
    Public ghostList(8) As Image

    '이미지 불러오는 변수
    Public heroimage As Image '주인공 이미지
    Public backImage As Image '배경 이미지
    Public objectImage As Image '물체 및 장애물

    'stage 별 padding 변수
    Public pTop As Integer
    Public pLeft As Integer
    Public pBottom As Integer
    Public pRight As Integer

    'stage 판별 변수
    Public stageNum As Integer = 0
    Public returndead As Integer = 0
    Public stageBowl As Integer = 0

    '정답
    Public stage1R As String = ""
    Public stage1EventOn As Boolean = False
    Public stage2R As String = ""
    Public stage2EventOn As Boolean = False
    Public stage3EventOn As Boolean = False
    Public stage4EventOn As Boolean = False

    '생명 
    Public life As Integer = 0

    '플레이시간
    Public Timedisplay As String
    Public iTimeCount As Integer
    Public millisecond As Integer
    Public second As Integer
    Public minute As Integer
    Public hour As Integer

    'FunctionKey 입력신호
    Public functionKey As Boolean = False 'z키
    Public functionKey2 As Boolean = False 'x키
    Public explanation As Boolean = False
    Public menu2light As Boolean = False
    Public menuOn As Boolean = False

    '슬립 변수 선언
    Public Declare Sub Sleep Lib "kernel32.dll" (ByVal dwMilliseconds As Long)

    '키 입력 선언
    Private Declare Function GetAsynKeyState Lib "user32.dll" (ByVal keyCode As Integer) As Short

    '방향키 판별 변수 (아래1, 위2, 왼쪽3, 오른쪽4)
    Public goxy As Integer = 0

    '주인공 방향 저장 변수들
    Public flagAhead As Integer = 0
    Public flagDown As Integer = 0
    Public flagUp As Integer = 0
    Public flagLeft As Integer = 0
    Public flagRight As Integer = 0

    '주인공 이동속도
    Public xSpeed As Integer = 10
    Public ySpeed As Integer = 10
End Module
