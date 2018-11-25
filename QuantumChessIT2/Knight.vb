Public Class Knight
    Inherits ChessPiece

    Public Sub New(ByVal colour As Char, ByVal var As String)
        name = var
        type = colour
        If name.Substring(1, 4) = "Left" Then
            posX = 1
        ElseIf name.Substring(1, 5) = "Right" Then
            posX = 6
        End If

        If type = "w" Then
            posY = 7
            srcRec = New Rectangle(64, 64, tileSize, tileSize)
        ElseIf type = "b" Then
            posY = 0
            srcRec = New Rectangle(192, 64, tileSize, tileSize)
        End If

        Game.gameBoard.setMapInfo(Me, posX, posY)

    End Sub

    Public Overrides Sub setMove(secondClickX As Integer, secondClickY As Integer, colour As Char)

        If Math.Abs(secondClickY - posY) = 2 Or Math.Abs(secondClickX - posX) = 2 Then ' Checks if it moves 2 squares on the y-axis
            Dim enabled As Boolean
            If Math.Abs(secondClickX - posX) = 1 Or Math.Abs(secondClickY - posY) = 1 Then ' Checks if it moves 1 squares on the x-axis
                enabled = True
            End If

            If enabled = True Then
                If classical = True Then
                    If quantumClick = True Then
                        If colour = Nothing Then
                            setQuantumMove(secondClickX, secondClickY)
                        End If
                    Else
                            setSwap(secondClickX, secondClickY)
                    End If
                End If
            End If
        End If

    End Sub
End Class
