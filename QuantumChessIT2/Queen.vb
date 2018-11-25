Public Class Queen
    Inherits ChessPiece

    Public Sub New(ByVal colour As Char, ByVal var As String)
        posX = 3
        name = var
        type = colour

        If colour = "w" Then
            srcRec = New Rectangle(0, 192, tileSize, tileSize)
            posY = 7
        ElseIf colour = "b" Then
            srcRec = New Rectangle(128, 192, tileSize, tileSize)
            posY = 0
        End If

        Game.gameBoard.setMapInfo(Me, posX, posY)
    End Sub

    Public Overrides Sub setMove(secondClickX As Integer, secondClickY As Integer, colour As Char)
        'Differentiates between the two rules
        If Math.Abs(secondClickX - posX) = Math.Abs(secondClickY - posY) Then
            bishopMove(secondClickX, secondClickY, colour)
        ElseIf secondClickY = posY Xor secondClickX = posX Then
            rookMove(secondClickX, secondClickY, colour)
        End If
    End Sub

    Protected Sub rookMove(ByVal secondClickX As Integer, ByVal secondClickY As Integer, ByVal colour As Char)
        'Checks if it is a legal Rook move
        'Needs to be done so the rook class can also check for the move

        If secondClickY = posY Xor secondClickX = posX Then
            If classical = True Then
                If quantumClick = True Then
                    If colour = Nothing Then
                        setQuantumMove(secondClickX, secondClickY)
                    End If
                Else
                    validRookPath(secondClickX, secondClickY)
                End If
            End If
        End If

    End Sub

    Protected Function validRookPath(ByVal secondClickX As Integer, ByVal secondClickY As Integer) As Boolean
        'Local Variables
        Dim startPos, endPos, diff As Integer
        Dim isPathValid As Boolean = True
        Dim xAxis As Boolean

        If secondClickY = posY Then
            diff = Math.Abs(secondClickX - posX) - 1 'Gets the difference between the two positions
            xAxis = True
            startPos = posX
            endPos = secondClickX
        ElseIf secondClickX = posX Then
            diff = Math.Abs(secondClickY - posY) - 1
            xAxis = False
            startPos = posY
            endPos = secondClickY
        End If
        'Checks if it is going vertically or horizontally

        For count As Integer = 1 To diff
            If endPos - startPos < 0 Then ' Checks if it is a negative or positive, inorder to increment it
                startPos -= 1
            Else
                startPos += 1
            End If
            If xAxis = True Then 'Decides where to put the paramenters on the getPiece method
                If Game.gameBoard.getPiece(startPos, posY) IsNot Nothing Then
                    isPathValid = False
                    Return isPathValid
                End If
            Else
                If Game.gameBoard.getPiece(posX, startPos) IsNot Nothing Then
                    isPathValid = False
                    Return isPathValid
                End If
            End If
        Next

        setSwap(secondClickX, secondClickY)

        Return isPathValid
    End Function

    Protected Sub bishopMove(ByVal secondClickX As Integer, secondClickY As Integer, ByVal colour As Char)
        If Math.Abs(secondClickX - posX) = Math.Abs(secondClickY - posY) Then
            If classical = True Then
                If quantumClick = True Then
                    If colour = Nothing Then
                        setQuantumMove(secondClickX, secondClickY)
                    End If
                Else
                        validBishopPath(secondClickX, secondClickY)
                End If
            End If
        End If
    End Sub

    Protected Function validBishopPath(ByVal secondClickX As Integer, ByVal secondClickY As Integer) As Boolean
        'Local Variables
        Dim pathIsValid As Boolean = True
        Dim pathX As Integer = posX
        Dim pathY As Integer = posY
        Dim xOperation, yOperation As Integer
        Dim difference As Integer = Math.Abs(secondClickX - posX) - 1

        If secondClickX - pathX < 0 Then
            xOperation = -1
        Else
            xOperation = 1
        End If
        If secondClickY - pathY < 0 Then
            yOperation = -1
        Else
            yOperation = 1
        End If
        'Sets the operation in which way it will traverse the board

        For counter As Integer = 1 To difference

            pathX = pathX + xOperation
            pathY = pathY + yOperation
            'Traverses square by square

            If Game.gameBoard.getPiece(pathX, pathY) IsNot Nothing Then
                pathIsValid = False
                Return pathIsValid
            End If
            'Checks each square it traverse
        Next

        setSwap(secondClickX, secondClickY)
        'Does the swap as it hasnt been returned meaning path is valid
        Return pathIsValid

    End Function

End Class
