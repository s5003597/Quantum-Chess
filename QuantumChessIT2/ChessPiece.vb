Public MustInherit Class ChessPiece
    Protected srcRec As Rectangle
    Protected posX, posY As Integer
    Protected uniqueID As Integer
    Protected type As Char
    Protected name As String
    Protected noOfMoves As Integer
    Protected tileSize As Integer
    Protected classical As Boolean = True

    'QUANTUM
    Protected quantumClick As Boolean
    Protected quantumX As Integer = -1
    Protected quantumY As Integer = -1

    Public Sub New()
        tileSize = Game.graphicsOb.getTileSize
    End Sub

    'GET FUNCTIONS
    Public Function getSrcRec()
        Return srcRec
    End Function
    Public Function getPosX()
        Return posX
    End Function
    Public Function getPosY()
        Return posY
    End Function
    Public Function getUniqueID()
        Return uniqueID
    End Function
    Public Function getName()
        Return name
    End Function
    Public Function getColour()
        Return type
    End Function
    Protected Overridable Function validPath(ByVal secondClickX As Integer, ByVal secondClickY As Integer) As Boolean
        Return Nothing
    End Function
    Public Function positionCheck(ByVal secondClickX As Integer, ByVal secondClickY As Integer, ByVal colour As Char)
        If secondClickX = posX And secondClickY = posY Then
            quantumClick = False
            Return "MOVE CANCELLED"
        End If
        If type = colour Then
            quantumClick = False
            Return "CANNOT ATTACK SAME PIECE"
        End If
        Return Nothing
    End Function
    Public Function getState()
        Return classical
    End Function
    Public Function getQuantumClick()
        Return quantumClick
    End Function

    'SET SUBS
    Public Sub setClassical(ByVal state As Boolean)
        classical = state
    End Sub
    Public Sub setMovementCounter()
        noOfMoves += 1
    End Sub
    Public MustOverride Sub setMove(ByVal secondClickX As Integer, ByVal secondClickY As Integer, ByVal colour As Char)
    Public Sub setSwap(ByVal secondClickX As Integer, ByVal secondClickY As Integer)
        Dim piece As ChessPiece
        If Game.gameBoard.getPiece(secondClickX, secondClickY) IsNot Nothing Then
            piece = Game.gameBoard.getPiece(secondClickX, secondClickY)

            If piece.getState = False Then 'Checks if it is not classical
                ' If CInt(Int((2 * Rnd()) + 1)) = 1 Then 'Does the probability to check if it is real
                If (Int(Rnd() * 100) + 1) <= 50 Then
                    piece.classical = True
                    If secondClickX = piece.posX And secondClickY = piece.posY Then
                        piece.posX = piece.quantumX 'Corrects the position of the piece
                        piece.posY = piece.quantumY
                    End If
                Else
                    Game.gameBoard.setMapNULL(piece.quantumX, piece.quantumY)
                    Game.gameBoard.setMapNULL(piece.getPosX, piece.getPosY)
                End If

                If piece.getColour = "w" Then
                    Game.wPlayer.setNoOfQuantum(-1)
                Else
                    Game.bPlayer.setNoOfQuantum(-1)
                End If

            End If
        End If

        Game.gameBoard.setMapNULL(posX, posY)
        posX = secondClickX
        posY = secondClickY
        setMovementCounter()
        Game.gameBoard.setMapInfo(Me, posX, posY)

        Game.currentPlayer.turnFinsihed()
    End Sub

    'Quantum Set
    Public Sub setQuantumClick(ByVal state As String)
        If state = "True" Then 'To turn it on and off on the clicking event
            quantumClick = True
        ElseIf state = "False" Then 'When it finishes the move, it needs to disable it.
            quantumClick = False
        End If
    End Sub
    Public Sub setQuantumMove(ByVal secondClickX As Integer, ByVal secondClickY As Integer)
        quantumX = secondClickX
        quantumY = secondClickY
        classical = False
        quantumClick = False
        Game.gameBoard.setMapInfo(Me, quantumX, quantumY)

        Game.currentPlayer.turnFinsihed()
        If Me.type = "w" Then
            Game.wPlayer.setNoOfQuantum(1)
        Else
            Game.bPlayer.setNoOfQuantum(1)
        End If
    End Sub

End Class

