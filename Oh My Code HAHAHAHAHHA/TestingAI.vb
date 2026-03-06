Imports System.Net
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json.Linq
Imports System.Threading.Tasks


Public Class TestingAI

    ' Tambah chat bubble ke panel
    Private Sub AddChatBubble(message As String, isUser As Boolean)
        Dim lbl As New Label()
        lbl.Text = message
        lbl.AutoSize = True
        lbl.MaximumSize = New Size(300, 0)
        lbl.Padding = New Padding(10)
        lbl.Margin = New Padding(5)
        lbl.BackColor = If(isUser, Color.LightBlue, Color.LightGray)
        lbl.ForeColor = Color.Black

        ' Wrap in a Panel for alignment
        Dim panel As New Panel()
        panel.AutoSize = True
        panel.Padding = New Padding(5)
        panel.Dock = DockStyle.Top
        panel.Controls.Add(lbl)

        FlowLayoutPanel1.Controls.Add(panel)
        FlowLayoutPanel1.ScrollControlIntoView(panel)
        FlowLayoutPanel1.VerticalScroll.Value = FlowLayoutPanel1.VerticalScroll.Maximum
    End Sub

    ' Bila user tekan Send
    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim userMsg As String = txtInput.Text.Trim()
        If userMsg = "" Then Exit Sub

        AddChatBubble(userMsg, True)
        txtInput.Clear()

        ' Buat bubble kosong dulu untuk bot reply
        Dim botLbl As New Label()
        botLbl.Text = ""
        botLbl.AutoSize = True
        botLbl.MaximumSize = New Size(300, 0)
        botLbl.Padding = New Padding(10)
        botLbl.Margin = New Padding(5)
        botLbl.BackColor = Color.LightGray
        botLbl.ForeColor = Color.Black

        Dim panel As New Panel()
        panel.AutoSize = True
        panel.Padding = New Padding(5)
        panel.Dock = DockStyle.Top
        panel.Controls.Add(botLbl)

        FlowLayoutPanel1.Controls.Add(panel)
        FlowLayoutPanel1.ScrollControlIntoView(panel)

        ' Streaming response
        GetOllamaResponseStream(userMsg, Sub(chunk)
                                             ' Invoke sebab callback datang dari thread lain
                                             If botLbl.InvokeRequired Then
                                                 botLbl.Invoke(Sub() botLbl.Text &= chunk)
                                             Else
                                                 botLbl.Text &= chunk
                                             End If
                                         End Sub)
    End Sub


    ' Fungsi panggil Ollama API
    Function GetOllamaResponseStream(prompt As String, callback As Action(Of String)) As Task
        Return Task.Run(Sub()
                            Dim url As String = "http://localhost:11434/api/generate"
                            Dim model As String = "llama3"

                            Try
                                Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                                request.Method = "POST"
                                request.ContentType = "application/json"

                                Dim jsonBody As String = $"{{""model"":""{model}"",""prompt"":""{prompt.Replace("""", "\""")}"",""stream"":true}}"
                                Dim byteData As Byte() = Encoding.UTF8.GetBytes(jsonBody)
                                request.ContentLength = byteData.Length

                                Using dataStream As Stream = request.GetRequestStream()
                                    dataStream.Write(byteData, 0, byteData.Length)
                                End Using

                                Using response As WebResponse = request.GetResponse()
                                    Using reader As New StreamReader(response.GetResponseStream())
                                        Dim line As String
                                        Do
                                            line = reader.ReadLine()
                                            If String.IsNullOrWhiteSpace(line) Then Continue Do
                                            Dim json As JObject = JObject.Parse(line)
                                            Dim chunk As String = json("response")?.ToString()
                                            If Not String.IsNullOrEmpty(chunk) Then
                                                callback(chunk)
                                            End If
                                        Loop While Not reader.EndOfStream
                                    End Using
                                End Using

                            Catch ex As WebException
                                callback("API Error: " & ex.Message)
                            Catch ex As Exception
                                callback("Unexpected Error: " & ex.Message)
                            End Try
                        End Sub)
    End Function


End Class
