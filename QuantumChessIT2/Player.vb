Public Class Player
    Private name As String
    Private colour As Char
    Private score As Integer
    Private noOfQuantum As Integer
    Private turn As Boolean

    'Pieces
    Private King As Integer = 1

    'Current Co-ords
    Private x, y As Integer
    Private quantumClick As Boolean

    Public Sub New(ByVal type As Char)
        colour = type
        If colour = "w" Then
            name = "Player 1"
            turn = True
        ElseIf colour = "b" Then
            name = "Player 2"
            turn = False
        End If

        score = 0
        noOfQuantum = 0
    End Sub
    'Get Functions
    Public Function getScore()
        Return score
    End Function
    Public Function getNoOfQuantum()
        Return noOfQuantum
    End Function
    Public Function getTurn()
        Return turn
    End Function
    Public Function getColour()
        Return colour
    End Function
    Public Function getName()
        Return name
    End Function
    Public Function getCords()
        Return CStr(x) & ", " & CStr(y)
    End Function
    Public Function getQClick()
        Return quantumClick
    End Function

    'Set Subs
    Public Sub setNoOfQuantum(ByVal value As Integer)
        noOfQuantum += value
    End Sub
    Public Sub setScore(ByVal value As Integer)
        score += value
    End Sub
    Public Sub setTurn(ByVal state As Boolean)
        turn = state
    End Sub
    Public Sub turnFinsihed()
        If Me.colour = "w" And Me.turn = True Then
            Me.turn = False
            Game.bPlayer.turn = True
            Game.currentPlayer = Game.bPlayer
        ElseIf Me.colour = "b" And Me.turn = True Then
            Game.wPlayer.turn = True
            Game.currentPlayer = Game.wPlayer
            Me.turn = (False)
        End If
    End Sub
    Public Sub setCords(ByVal xAxis As Integer, ByVal yAxis As Integer)
        x = xAxis
        y = yAxis
    End Sub
    Public Sub setQClick(ByVal state As Boolean)
        quantumClick = state
    End Sub
End Class