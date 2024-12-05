Imports System
Imports System.IO

Module Program

Sub Main(args As String())
	Console.WriteLine($"Advent of Code - Day 4! {vbCrLf}---")
	Dim input As String() = File.ReadAllLines("input.txt")

    ' Count number of characters on first line of input
    Dim maxX As Integer = input(0).Length
    ' Get number of lines in input
    Dim maxY As Integer = input.Length

    ' Generate a two dimensional array of integers from the input
    Dim grid(maxX, maxY) As String
    For y As Integer = 0 To maxY - 1
        For x As Integer = 0 To maxX - 1
            grid(x, y) = input(y)(x)
        Next
    Next

    ' Loop through the grid and print out the contents
    Dim part1Total As Integer = 0
    For y As Integer = 0 To maxY - 1
        For x As Integer = 0 To maxX - 1
            part1Total += LookForXMAS(x, y, grid)
        Next
    Next

    Console.WriteLine($"Part 1: {part1Total}{vbCrLf}")

    ' Loop through the grid and print out the contents
    Dim part2Total As Integer = 0
    For y As Integer = 0 To maxY - 1
        For x As Integer = 0 To maxX - 1
            part2Total += LookForMAS(x, y, grid)
        Next
    Next

    Console.WriteLine($"Part 2: {part2Total}{vbCrLf}")
End Sub

Function LookForXMAS(x As Integer, y As Integer, grid As String(,)) As Integer
    Dim matches = 0

    ' Forward
    If x + 3 < grid.GetLength(0) Then
        If grid(x, y) = "X" AndAlso grid(x + 1, y) = "M" AndAlso grid(x + 2, y) = "A" AndAlso grid(x + 3, y) = "S" Then
            matches += 1
        End If
    End If

    ' Backward
    If x - 3 >= 0 Then
        If grid(x, y) = "X" AndAlso grid(x - 1, y) = "M" AndAlso grid(x - 2, y) = "A" AndAlso grid(x - 3, y) = "S" Then
            matches += 1
        End If
    End If

    ' Upward
    If y - 3 >= 0 Then
        If grid(x, y) = "X" AndAlso grid(x, y - 1) = "M" AndAlso grid(x, y - 2) = "A" AndAlso grid(x, y - 3) = "S" Then
            matches += 1
        End If
    End If

    ' Downward
    If y + 3 < grid.GetLength(1) Then
        If grid(x, y) = "X" AndAlso grid(x, y + 1) = "M" AndAlso grid(x, y + 2) = "A" AndAlso grid(x, y + 3) = "S" Then
            matches += 1
        End If
    End If

    ' Diagonal (4 directions)
    ' Upward Left
    If x - 3 >= 0 AndAlso y - 3 >= 0 Then
        If grid(x, y) = "X" AndAlso grid(x - 1, y - 1) = "M" AndAlso grid(x - 2, y - 2) = "A" AndAlso grid(x - 3, y - 3) = "S" Then
            matches += 1
        End If
    End If

    ' Upward Right
    If x + 3 < grid.GetLength(0) AndAlso y - 3 >= 0 Then
        If grid(x, y) = "X" AndAlso grid(x + 1, y - 1) = "M" AndAlso grid(x + 2, y - 2) = "A" AndAlso grid(x + 3, y - 3) = "S" Then
            matches += 1
        End If
    End If

    ' Downward Left
    If x - 3 >= 0 AndAlso y + 3 < grid.GetLength(1) Then
        If grid(x, y) = "X" AndAlso grid(x - 1, y + 1) = "M" AndAlso grid(x - 2, y + 2) = "A" AndAlso grid(x - 3, y + 3) = "S" Then
            matches += 1
        End If
    End If

    ' Downward Right
    If x + 3 < grid.GetLength(0) AndAlso y + 3 < grid.GetLength(1) Then
        If grid(x, y) = "X" AndAlso grid(x + 1, y + 1) = "M" AndAlso grid(x + 2, y + 2) = "A" AndAlso grid(x + 3, y + 3) = "S" Then
            matches += 1
        End If
    End If

    Return matches
End Function


Function LookForMAS(x As Integer, y As Integer, grid As String(,)) As Integer
    Dim matches = 0

    ' YX012
    ' 0 M.M
    ' 1 .A.
    ' 2 S.S
    If grid(x, y) = "M" AndAlso grid(x + 1, y + 1) = "A" AndAlso grid(x + 2 , y + 2) = "S" Then
        If grid(x + 2, y) = "M" AndAlso grid(x + 1, y + 1) = "A" AndAlso grid(x, y + 2) = "S" Then
            matches += 1
        End If
    End If

    ' YX012
    ' 0 M.S
    ' 1 .A.
    ' 2 M.S
    If grid(x, y) = "M" AndAlso grid(x + 1, y + 1) = "A" AndAlso grid(x + 2 , y + 2) = "S" Then
        If grid(x + 2, y) = "S" AndAlso grid(x + 1, y + 1) = "A" AndAlso grid(x, y + 2) = "M" Then
            matches += 1
        End If
    End If

    ' YX012
    ' 0 S.M
    ' 1 .A.
    ' 2 S.M
    If grid(x, y) = "S" AndAlso grid(x + 1, y + 1) = "A" AndAlso grid(x + 2 , y + 2) = "M" Then
        If grid(x + 2, y) = "M" AndAlso grid(x + 1, y + 1) = "A" AndAlso grid(x, y + 2) = "S" Then
            matches += 1
        End If
    End If

    ' YX012
    ' 0 S.S
    ' 1 .A.
    ' 2 M.M
    If grid(x, y) = "S" AndAlso grid(x + 1, y + 1) = "A" AndAlso grid(x + 2 , y + 2) = "M" Then
        If grid(x + 2, y) = "S" AndAlso grid(x + 1, y + 1) = "A" AndAlso grid(x, y + 2) = "M" Then
            matches += 1
        End If
    End If

    Return matches
End Function

End Module