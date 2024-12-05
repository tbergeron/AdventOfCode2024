Imports System
Imports System.IO

Module Program

Sub Main(args As String())
    Console.WriteLine($"Advent of Code - Day 4! {vbCrLf}---")

    Dim rules As String() = File.ReadAllLines("rules.txt")
    Dim pages As String() = File.ReadAllLines("pages.txt")

    Dim part1Total = 0

	For Each line As String In pages
        Dim pageNumbers As Integer() = Array.ConvertAll(line.Split(","), Function(x) Integer.Parse(x))
        If IsValid(pageNumbers, rules) Then
            part1Total += pageNumbers(Math.Floor(pageNumbers.Length / 2))
        End If
    Next

    Console.WriteLine($"Part 1: {part1Total}{vbCrLf}")
End Sub

Function IsValid(pageNumbers As Integer(), rules As String()) As Boolean
    Dim numberOfPages = pageNumbers.Length
    Dim pageNumbersValid = true

    For i As Integer = 0 To numberOfPages - 1
        Dim pageNumber = pageNumbers(i)

        For Each rule As String In rules
            Dim ruleParts As String() = rule.Split("|")
            Dim x As Integer = ruleParts(0)
            Dim y As Integer = ruleParts(1)

            Dim xIndex = Array.IndexOf(pageNumbers, x)
            Dim yIndex = Array.IndexOf(pageNumbers, y)
            
            If xIndex > -1 AndAlso yIndex > -1 Then
                If xIndex > yIndex Then
                    pageNumbersValid = false
                End If
            End If
        Next
    Next

    Return pageNumbersValid
End Function

End Module