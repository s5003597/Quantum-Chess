
Public Class Game
    Public gameBoard As Board
    Public graphicsOb As GUI

    Private gameOn As Boolean = True

    'Mouse Click Event
    Private clickCounter As Integer
    Private clickX, clickY As Integer
    Private clickedPiece As ChessPiece
    Public currentPlayer As Player

    'Mouse Cords
    Public mouseMapX, mouseMapY As Integer

    'Player Declarations
    Public wPlayer, bPlayer As Player

    'King Declarations
    Public wKing, bKing As King

    'Pawn Declarations
    Public wPawnList(7) As Pawn
    Public bPawnList(7) As Pawn

    'Knight Declarations
    Public wLeftKnight, wRightKnight As Knight
    Public bLeftKnight, bRightKnight As Knight

    'Queen Declarations
    Public wQueen, bQueen As Queen

    'Rook Declarations
    Public wLeftRook, wRightRook As Rook
    Public bLeftRook, bRightRook As Rook

    'Bishop Declarations
    Public wLeftBishop, wRightBishop As Bishop
    Public bLeftBishop, bRightBishop As Bishop


    Private Sub Game_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        Me.Focus()

        'Intailising Board
        gameBoard = New Board()

        'Intailising Graphic Objects
        graphicsOb = New GUI()

        'Player
        wPlayer = New Player("w")
        bPlayer = New Player("b")
        currentPlayer = wPlayer

        'King
        wKing = New King("w", "wKing")
        bKing = New King("b", "bKing")

        'Knight
        wLeftKnight = New Knight("w", "wLeftKnight")
        wRightKnight = New Knight("w", "wRightKnight")
        bLeftKnight = New Knight("b", "bLeftKnight")
        bRightKnight = New Knight("b", "bRightKnight")

        'Rook
        wLeftRook = New Rook("w", "wLeftRook")
        wRightRook = New Rook("w", "wRightRook")
        bLeftRook = New Rook("b", "bLeftRook")
        bRightRook = New Rook("b", "bRightRook")

        'Bishop
        wLeftBishop = New Bishop("w", "wLeftBishop")
        wRightBishop = New Bishop("w", "wRightBishop")
        bLeftBishop = New Bishop("b", "bLeftBishop")
        bRightBishop = New Bishop("b", "bRightBishop")

        'Queen
        wQueen = New Queen("w", "wQueen")
        bQueen = New Queen("b", "bQueen")

        For i As Integer = 0 To 7
            wPawnList(i) = New Pawn("w", "wPawn" & i)
            bPawnList(i) = New Pawn("b", "bPawn" & i)
        Next

        gameLoop()
    End Sub

    Private Sub gameLoop()
        Do While gameOn = True
            Application.DoEvents()
            graphicsOb.graphicSetup()
        Loop
    End Sub

    Private Sub Game_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        mouseMapX = Math.Floor(e.X / graphicsOb.getTileSize)
        mouseMapY = Math.Floor(e.Y / graphicsOb.getTileSize)
    End Sub

    Private Sub Game_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        clickX = mouseMapX
        clickY = mouseMapY

        Dim temp As ChessPiece
        Dim type As Char
        Dim message As String

        If clickX < 8 And clickY < 8 Then
            'This is to validate it and make sure the user clicked within the boards co-ordinates
            clickCounter += 1 ' Increments the click counter
            If clickCounter = 1 Then
                If gameBoard.getPiece(clickX, clickY) IsNot Nothing Then
                    currentPlayer.setCords(clickX, clickY)
                    ' Validates there is piece before assigning it, otherwise it would crash
                    clickedPiece = gameBoard.getPiece(clickX, clickY)
                    If currentPlayer.getColour <> clickedPiece.getColour Then
                        clickCounter = 0
                        Exit Sub
                    End If
                    If e.Button = MouseButtons.Right Then
                        If currentPlayer.getNoOfQuantum < 2 Then 'Limits the amount of quantum pieces per player
                            clickedPiece.setQuantumClick("True")
                            currentPlayer.setQClick(True)
                        Else
                            clickCounter = 0
                        End If
                    End If
                    'Sets the quantumClick property to the value opposite it.
                Else
                    clickCounter = 0
                    'Resets the click counter
                End If
            ElseIf clickCounter = 2 Then
                'Checks to see if this is their second click (position the piece moves to)
                If gameBoard.getPiece(clickX, clickY) IsNot Nothing Then
                    'Checks to see if the second position has a piece
                    temp = gameBoard.getPiece(clickX, clickY)
                    type = temp.getColour
                    'Gets the colour of the enemy piece.
                Else
                    type = Nothing
                End If
                message = clickedPiece.positionCheck(clickX, clickY, type)
                'Does a validation check
                If message = Nothing Then
                    clickedPiece.setMove(clickX, clickY, type)
                Else
                    MsgBox(message)
                End If

                currentPlayer.setQClick(False)
                currentPlayer.setCords(0, 0)
                clickCounter = 0
                clickedPiece.setQuantumClick("False")
                clickedPiece = Nothing
            End If
        End If
    End Sub


    '' TODO LIST
    '' Writing the messages on the click event to the right side
    '' Home page
    ''

End Class

