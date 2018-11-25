Public Class King
    Inherits ChessPiece

    Public Sub New(ByVal colour As Char, ByVal var As String)
        posX = 4
        If colour = "w" Then
            srcRec = New Rectangle(64, 128, tileSize, tileSize)
            posY = 7
        ElseIf colour = "b" Then
            srcRec = New Rectangle(192, 128, tileSize, tileSize)
            posY = 0
        End If
        type = colour
        name = var

        Game.gameBoard.setMapInfo(Me, posX, posY)

    End Sub

    Public Overrides Sub setMove(ByVal secondClickX As Integer, ByVal secondClickY As Integer, colour As Char)
        Dim enabled As Boolean
        If Math.Abs(secondClickX - posX) = 1 And Math.Abs(secondClickY - posY) = 1 Then
            'Checks if both changes are = 1
            enabled = True
        ElseIf Math.Abs(secondClickX - posX) = 1 And secondClickY = posY Then
            enabled = True
        ElseIf Math.Abs(secondClickY - posY) = 1 And secondClickX = posX Then
            enabled = True
        End If

        If enabled = True Then 'Checks if it is a legal move
            If classical = True Then 'Checks if it is in classical state
                If quantumClick = True Then 'Checks if user chose a quantum click
                    If colour = Nothing Then 'Make sure it doesnt take a square that is occupied.
                        setQuantumMove(secondClickX, secondClickY)
                    End If
                Else
                    setSwap(secondClickX, secondClickY)
                End If
            End If
        End If

    End Sub
End Class

