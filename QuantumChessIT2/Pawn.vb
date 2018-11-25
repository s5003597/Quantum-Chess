Public Class Pawn
    Inherits ChessPiece

    Public Sub New(ByVal colour As Char, ByVal var As String)
        name = var
        type = colour
        posX = Convert.ToInt32(var.Substring(5, 1)) 'Gets the x value which is stored in the name

        If colour = "w" Then
            posY = 6
            srcRec = New Rectangle(64, 0, tileSize, tileSize)
        Else
            posY = 1
            srcRec = New Rectangle(192, 0, tileSize, tileSize)
        End If

        Game.gameBoard.setMapInfo(Me, posX, posY)
    End Sub


    Public Overrides Sub setMove(secondClickX As Integer, secondClickY As Integer, colour As Char)
        Dim valid As Boolean = False

        If noOfMoves = 0 And Math.Abs(secondClickY - posY) = 2 Then 'Checks if it can move two squares up
            valid = True
        ElseIf Math.Abs(secondClickY - posY) = 1 Then 'Checks if trying to move one up or attack
            valid = True
        End If

        If valid = True Then
            If colour = Nothing And secondClickX = posX Then 'Checks if path is blocked
                If (type = "b" And secondClickY - posY > 0) Or (type = "w" And secondClickY - posY < 0) Then
                    'Prevents pawn from moving back
                    setSwap(secondClickX, secondClickY)
                End If
            ElseIf Math.Abs(secondClickX - posX) = 1 And colour <> Nothing Then ' Checks if piece is there
                If (type = "b" And secondClickY - posY = 1) Or (type = "w" And secondClickY - posY = -1) Then
                    setSwap(secondClickX, secondClickY)
                End If
            End If
        End If
    End Sub

End Class

