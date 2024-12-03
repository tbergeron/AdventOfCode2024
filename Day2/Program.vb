Imports System.IO

Module Program
Sub Main()
  Console.WriteLine("Advent of Code - Day 2!" & vbCrLf & "---" & vbCrLf)

  Dim input As String() = File.ReadAllLines("input.txt")

  ' Part 1
  Dim safeCountPt1 As Integer = 0

  For Each line As String In input
    Dim levels As List(Of Integer) = line.Split(" " c).Select(Function (x) Integer.Parse(x)).ToList()
      If IsReportSafe(levels) Then
        safeCountPt1 + = 1
      End If
    Next

    Console.WriteLine($"Part 1: {safeCountPt1}")

    ' Part 2
    Dim safeCountPt2 As Integer = 0

    For Each line As String In input
      Dim levels As List(Of Integer) = line.Split(" " c).Select(Function (x) Integer.Parse(x)).ToList()
        If ProblemDampener(levels) Then
          safeCountPt2 + = 1
        End If
      Next

      Console.WriteLine($"Part 2: {safeCountPt2}")

    End Sub

    Function IsReportSafe(levels As List(Of Integer)) As Boolean
      ' Create sub lists of the levels, removing the first and last elements
      Dim l1 As List(Of Integer) = levels.Take(levels.Count - 1).ToList()
      Dim l2 As List(Of Integer) = levels.Skip(1).ToList()

      ' Differentiate the two lists
      Dim diff As List(Of Integer) = l1.Zip(l2, Function (a, b) b - a).ToList()

        ' If any of the differences are zero, the report is not safe
        If diff.Any(Function (x) x = 0) Then
            Return False
          End If

          ' If any of the differences are greater than 3, the report is not safe
          If diff.Any(Function (x) x > 3) OrElse diff.Any(Function (x) x < - 3) Then
                Return False
              End If

              ' If the differences are not all positive or all negative, the report is not safe
              If diff.Any(Function (x) x > 0) AndAlso diff.Any(Function (x) x < 0) Then
                    Return False
                  End If

                  Return True
                End Function

                Function ProblemDampener(levels As List(Of Integer)) As Boolean
                  ' If the report is safe, we're done
                  If IsReportSafe(levels) Then
                    Return True
                  End If

                  ' Try removing each level in turn
                  For i As Integer = 0 To levels.Count - 1
                    Dim newLevels As New List(Of Integer)(levels)
                    newLevels.RemoveAt(i)

                    ' If we get a safe report, we're done
                    If IsReportSafe(newLevels) Then
                      Return True
                    End If
                  Next

                  Return False
                End Function
                End Module