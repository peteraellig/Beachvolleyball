' Gemeinsame Abstraktion für den Versand von vMix-Befehlen - ermöglicht den Wechsel
' zwischen HTTP- und TCP-API (BeachVolleyballScorer.UseHttpForVmix), ohne die Aufrufstellen
' in Update_vMix.vb/BeachVolleyballScorer.vb anzufassen. Die bauen weiterhin denselben
' "Function=X&Param=Y&..."-String wie bisher; jede Implementierung übersetzt ihn in ihr
' eigenes Protokoll (siehe VmixHttpSender/VmixTcpSender). Analog zu Tennis26/SoccerClock.
Public Interface IVmixSender

    ' Was zuletzt tatsächlich über die Leitung ging (volle URL bei HTTP, TCP-Zeile bei TCP) -
    ' rein informativ für die Anzeige (ToolStripStatusLabel2).
    ReadOnly Property LastCommand As String

    ' command: "Function=X&Param=Y&..." wie bisher. Rückgabe: Antworttext/Statusmeldung -
    ' wirft bewusst keine Ausnahme nach aussen, ein einzelner fehlgeschlagener Befehl soll
    ' das laufende Match nicht stoppen.
    Function Send(command As String) As String

End Interface
