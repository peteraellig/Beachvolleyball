' Versendet vMix-Befehle per HTTP-GET an die vMix-Web-API (http://IP:Port/api/?Function=...).
' Analog zu Tennis26/SoccerClock VmixHttpSender.vb - IP/Port kommen hier aus
' BeachVolleyballScorer.IP/BeachVolleyballScorer.PORT.
Public Class VmixHttpSender
    Implements IVmixSender

    Private lastCommandValue As String = ""

    Public ReadOnly Property LastCommand As String Implements IVmixSender.LastCommand
        Get
            Return lastCommandValue
        End Get
    End Property

    Public Function Send(command As String) As String Implements IVmixSender.Send
        Dim url As String = "http://" + BeachVolleyballScorer.IP + ":" + BeachVolleyballScorer.PORT.ToString() + "/api/?" + command
        lastCommandValue = url

        Try
            Dim cookieJar As New Net.CookieContainer()
            Dim hwrequest As Net.HttpWebRequest = Net.WebRequest.Create(url)
            hwrequest.CookieContainer = cookieJar
            hwrequest.Accept = "*/*"
            hwrequest.AllowAutoRedirect = True
            hwrequest.UserAgent = "http_requester/0.1"
            hwrequest.Method = "GET"
            ' 3000ms statt der ursprünglichen 30ms (Tippfehler-Erbe) - ein echter vMix-Request
            ' dauert normalerweise <3ms, aber 30ms liess bereits jeden minimalen Hänger (z.B.
            ' Netzwerk-Retry) als Timeout fehlschlagen, bevor vMix überhaupt antworten konnte.
            hwrequest.Timeout = 3000

            Dim hwresponse As Net.HttpWebResponse = hwrequest.GetResponse()
            Dim responseData As String = ""
            If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
                Dim responseStream As New IO.StreamReader(hwresponse.GetResponseStream())
                responseData = responseStream.ReadToEnd()
            End If
            hwresponse.Close()
            Return responseData
        Catch ex As Exception
            Return "Exception Error in VTX (vMix running?): " & ex.Message
        End Try
    End Function

End Class
