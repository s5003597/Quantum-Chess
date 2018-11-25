Public Class Board

    'Tile
    Private lightTile As Integer = 0
    Private darkTile As Integer = 1

    'Map
    Private mapX, mapY As Integer
    Private backboard(7, 7) As Integer
    Private gameBoard(7, 7) As ChessPiece


    Public Sub New()
        For y As Integer = 0 To 7
            For x As Integer = 0 To 7
                'Traditional Chess board is 8x8, therefore the x and y co-ordinates of the array
                'will only assign tiles in an 8x8
                If y Mod 2 = 0 Then
                    If x Mod 2 = 0 Then
                        backboard(x, y) = lightTile
                    Else
                        backboard(x, y) = darkTile
                    End If
                ElseIf y Mod 2 > 0 Then
                    If x Mod 2 = 0 Then
                        backboard(x, y) = darkTile
                    Else
                        backboard(x, y) = lightTile
                    End If
                End If
            Next
        Next
    End Sub


    'GET FUNCTIONS
    Public Function getSrcRec(ByVal x As Integer, ByVal y As Integer)
        Dim tileSize As Integer = Game.graphicsOb.getTileSize
        Select Case backboard(x, y)
            'Checks a condition and returns a value
            Case 0 ' Light blank space
                Return New Rectangle(0, 0, tileSize, tileSize)
            Case 1 ' Dark blank space
                Return New Rectangle(128, 0, tileSize, tileSize)
            Case Else
                Return Nothing
        End Select
    End Function

    Public Function getPiece(ByVal positionX As Integer, ByVal positionY As Integer)
        Return gameBoard(positionX, positionY)
    End Function

    Public Sub setMapInfo(ByVal piece As ChessPiece, ByVal x As Integer, ByVal y As Integer)
        gameBoard(x, y) = piece
    End Sub
    Public Sub setMapNULL(ByVal x As Integer, ByVal y As Integer)
        gameBoard(x, y) = Nothing
    End Sub
End Class
