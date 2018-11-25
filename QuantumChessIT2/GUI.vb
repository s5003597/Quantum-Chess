Public Class GUI

    'Graphic Variables
    Private G As Graphics
    Private BBG As Graphics
    Private BB As Bitmap
    Private bmpTile As Bitmap = New Bitmap(PictureForm.chessBox.Image)
    Private srcRec As Rectangle
    Private desRec As Rectangle

    Dim resWidth As Integer = Game.Width
    Dim resHeight As Integer = Game.Height
    Private tileSize As Integer = 64

    Public Sub New()
        G = Game.CreateGraphics
        BB = New Bitmap(resWidth, resHeight)
    End Sub

    Public Sub graphicSetup()
        For x As Integer = 0 To 7
            For y As Integer = 0 To 7
                srcRec = Game.gameBoard.getSrcRec(x, y) ' This calls the function to get the location of the image, by using the public variable in the main form (Game)
                ' Then the public board (gameBoard) and its function (getSrcRec)
                desRec = New Rectangle(x * tileSize, y * tileSize, tileSize, tileSize)
                G.DrawImage(bmpTile, desRec, srcRec, GraphicsUnit.Pixel)
                srcRec = Nothing

                Dim piece As ChessPiece = Game.gameBoard.getPiece(x, y)
                If piece IsNot Nothing Then
                    desRec = New Rectangle(x * tileSize, y * tileSize, tileSize, tileSize)
                    G.DrawImage(bmpTile, desRec, piece.getSrcRec, GraphicsUnit.Pixel)
                End If
            Next
        Next

        'GUIS/MENUS
        If Game.mouseMapX < 8 And Game.mouseMapY < 8 Then
            G.DrawRectangle(Pens.Red, Game.mouseMapX * tileSize, Game.mouseMapY * tileSize, tileSize, tileSize)
        End If

        G.DrawString("Mouse Map X: " & Game.mouseMapX & vbCrLf &
                 "Mouse Map Y: " & Game.mouseMapY, Game.Font, Brushes.Black, 650, 0)

        G.DrawString("Current Player: " & Game.currentPlayer.getName & vbCrLf &
                     "First Click: " & Game.currentPlayer.getCords & vbCrLf &
                     "Quantum Enabled: " & Game.currentPlayer.getQClick, Game.DefaultFont, Brushes.Black, 600, 50)

        G.DrawString("Player 1:", Game.DefaultFont, Brushes.Black, 600, 100)
        G.DrawString("Quantum Pieces: " & Game.wPlayer.getNoOfQuantum & vbCrLf &
                     "Score: " & Game.wPlayer.getScore, Game.DefaultFont, Brushes.Black, 600, 115)

        G.DrawRectangle(Pens.Black, 600, 45, 165, 150)
        G.DrawString("Player 2:", Game.DefaultFont, Brushes.Black, 600, 150)
        G.DrawString("Quantum Pieces: " & Game.bPlayer.getNoOfQuantum & vbCrLf &
                     "Score: " & Game.bPlayer.getScore, Game.DefaultFont, Brushes.Black, 600, 165)



        'Copy Backbuffer to Graphics Object
        G = Graphics.FromImage(BB)

        ' Draw Backbuffer to Screen
        BBG = Game.CreateGraphics
        BBG.DrawImage(BB, 0, 0, resWidth, resHeight)

        ' Fix overdraw
        G.Clear(Color.Wheat)
    End Sub

    Public Function getResWidth()
        Return resWidth
    End Function
    Public Function getResHeight()
        Return resHeight
    End Function
    Public Function getTileSize()
        Return tileSize
    End Function

End Class
