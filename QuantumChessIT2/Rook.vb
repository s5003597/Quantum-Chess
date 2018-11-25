Public Class Rook
    Inherits Queen

    Public Sub New(ByVal colour As Char, ByVal var As String)
        MyBase.New(colour, var)
        name = var
        type = colour

        If var.Substring(1, 4) = "Left" Then
            posX = 0
        ElseIf var.Substring(1, 5) = "Right" Then
            posX = 7
        End If

        If colour = "w" Then
            posY = 7
            srcRec = New Rectangle(0, 64, tileSize, tileSize)
        Else
            posY = 0
            srcRec = New Rectangle(128, 64, tileSize, tileSize)
        End If

        Game.gameBoard.setMapInfo(Me, posX, posY)
    End Sub

    Public Overrides Sub setMove(secondClickX As Integer, secondClickY As Integer, ByVal colour As Char)
        rookMove(secondClickX, secondClickY, colour)
    End Sub
End Class
