Public Class ExternalGraphics
    Public Shared Sub UpdateGraphics(
        homePoints As Integer,
        awayPoints As Integer,
        homeSets As Integer,
        awaySets As Integer,
        server As String,
        currentSet As Integer,
        gameEnded As Boolean,
        winPoints1 As Integer,
        winPoints2 As Integer,
        winPoints3 As Integer,
        homeTeamPointsList As List(Of Integer),
        awayTeamPointsList As List(Of Integer)
    )
        ' Implementieren Sie hier die Logik zur Aktualisierung der externen Grafik
        ' Zum Beispiel:
        Console.WriteLine("Home Points: " & homePoints)
        Console.WriteLine("Away Points: " & awayPoints)
        Console.WriteLine("Home Sets: " & homeSets)
        Console.WriteLine("Away Sets: " & awaySets)
        Console.WriteLine("Server: " & server)
        Console.WriteLine("Current Set: " & currentSet)
        Console.WriteLine("Game Ended: " & gameEnded)
        Console.WriteLine("Win Points Set 1: " & winPoints1)
        Console.WriteLine("Win Points Set 2: " & winPoints2)
        Console.WriteLine("Win Points Set 3: " & winPoints3)
        Console.WriteLine("Home Team Points Set 1: " & homeTeamPointsList(0))
        Console.WriteLine("Home Team Points Set 2: " & homeTeamPointsList(1))
        Console.WriteLine("Home Team Points Set 3: " & homeTeamPointsList(2))
        Console.WriteLine("Away Team Points Set 1: " & awayTeamPointsList(0))
        Console.WriteLine("Away Team Points Set 2: " & awayTeamPointsList(1))
        Console.WriteLine("Away Team Points Set 3: " & awayTeamPointsList(2))
    End Sub
End Class

