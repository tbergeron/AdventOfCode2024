Imports System
Imports System.IO
Imports System.Text.RegularExpressions

Module Program

Sub Main(args As String())
	Console.WriteLine($"Advent of Code - Day 3! {vbCrLf}---{vbCrLf}")

	Dim input As String() = File.ReadAllLines("input.txt")

  ' Part 1
	Dim mulRegex As New Regex("mul\(([0-9]+),([0-9]+)\)")
  Dim part1Matches As New List(Of KeyValuePair(Of Integer, Integer))

  part1Matches = ExtractMatches(input, mulRegex)

  Dim part1Total = ComputeTotal(part1Matches)
	Console.WriteLine($"---{vbCrlf}Part 1: {part1Total}{vbCrLf}")

  ' Part 2
  Dim mulDoDontRegex As New Regex("mul\(([0-9]+),([0-9]+)\)|do\(\)|don\'t\(\)")
  Dim part2Matches As New List(Of KeyValuePair(Of Integer, Integer))

  part2Matches = ExtractDoMatches(input, mulDoDontRegex)

  Dim part2Total = ComputeTotal(part2Matches)
	Console.WriteLine($"---{vbCrlf}Part 2: {part2Total}{vbCrLf}")
End Sub

Function ExtractDoMatches(input As String(), regex As Regex) As List(Of KeyValuePair(Of Integer, Integer))
  Dim muls As New List(Of KeyValuePair(Of Integer, Integer))()

  Dim allowed As Boolean = False

  For Each line As String In input
		Dim matches As MatchCollection = regex.Matches(line)
    ' Console.WriteLine($"Matches: {matches.Count}{vbCrLf}---{vbCrLf}")

    For Each match As Match In matches

      If match.Value = "do()" Then
        allowed = True
        ' Console.WriteLine($"{vbCrLf}Allowed{vbCrLf}")
      ElseIf match.Value = "don't()" Then
        allowed = False
        ' Console.WriteLine($"{vbCrLf}Disallowed{vbCrLf}")
      ElseIf allowed Then
        ' Console.WriteLine($"Match: {match.Value}")
        Dim a As Integer = Integer.Parse(match.Groups(1).Value)
        Dim b As Integer = Integer.Parse(match.Groups(2).Value)
        ' Console.WriteLine($"Match: {a}, {b}")
        muls.Add(New KeyValuePair(Of Integer, Integer)(a, b))
      End If

    Next
  Next

  Return muls
End Function

Function ExtractMatches(input As String(), regex As Regex) As List(Of KeyValuePair(Of Integer, Integer))
	Dim muls As New List(Of KeyValuePair(Of Integer, Integer))()

	For Each line As String In input
		Dim matches As MatchCollection = regex.Matches(line)
		' Console.WriteLine($"Line: {line}")
		' Console.WriteLine($"Matches: {matches.Count}")
		For Each match As Match In matches
      ' Console.WriteLine($"Match: {match.Value}")
			Dim a As Integer = Integer.Parse(match.Groups(1).Value)
			Dim b As Integer = Integer.Parse(match.Groups(2).Value)
			' Console.WriteLine($"Match: {a}, {b}")
			muls.Add(New KeyValuePair(Of Integer, Integer)(a, b))
		Next
	Next

	Return muls
End Function

Function ComputeTotal(muls As List(Of KeyValuePair(Of Integer, Integer))) As Integer
  Dim total As Integer = 0
  For Each kvp As KeyValuePair(Of Integer, Integer) In muls
    total += kvp.Key * kvp.Value
  Next

  Return total
End Function

End Module