Imports System.Drawing
Imports System.Drawing.Imaging

Public Class Sniper
    Private startPoint As Point
    Private endPoint As Point
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        startPoint = e.Location
        isDragging = True
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If isDragging Then
            endPoint = e.Location
            Me.Invalidate() ' Redraw selection
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        isDragging = False

        ' Calculate rectangle bounds
        Dim rect As New Rectangle(Math.Min(startPoint.X, endPoint.X),
                                  Math.Min(startPoint.Y, endPoint.Y),
                                  Math.Abs(startPoint.X - endPoint.X),
                                  Math.Abs(startPoint.Y - endPoint.Y))

        ' Hide overlay so it doesn't appear in screenshot
        Me.Hide()

        ' Take screenshot of selected area
        Dim bmp As New Bitmap(rect.Width, rect.Height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.CopyFromScreen(rect.Location, Point.Empty, rect.Size)
        End Using

        ' Save
        Dim filename As String = $"Screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png"
        bmp.Save(filename, ImageFormat.Png)
        MessageBox.Show($"Screenshot saved as {filename}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.Close()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        If isDragging Then
            Dim rect As New Rectangle(Math.Min(startPoint.X, endPoint.X),
                                      Math.Min(startPoint.Y, endPoint.Y),
                                      Math.Abs(startPoint.X - endPoint.X),
                                      Math.Abs(startPoint.Y - endPoint.Y))
            Using pen As New Pen(Color.Red, 2)
                e.Graphics.DrawRectangle(pen, rect)
            End Using
        End If
    End Sub
End Class