Public Class Bishop
    Inherits Queen
    Public Sub New(ByVal colour As Char, ByVal var As String)
        MyBase.New(colour, var)
        name = var
        type = colour

        If var.Substring(1, 4) = "Left" Then
            posX = 2
        ElseIf var.Substring(1, 5) = "Right" Then
            posX = 5
        End If
        'This checks the substring in the name in order to determine its position

        If colour = "w" Then
            posY = 7
            srcRec = New Rectangle(0, 128, tileSize, tileSize)
        Else
            posY = 0
            srcRec = New Rectangle(128, 128, tileSize, tileSize)
        End If
        'Checks its colour type to allocate the appropriate image location

        Game.gameBoard.setMapInfo(Me, posX, posY)

    End Sub

    Public Overrides Sub setMove(secondClickX As Integer, secondClickY As Integer, colour As Char)
        bishopMove(secondClickX, secondClickY, colour)
    End Sub
End Class
