Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Text

Public Class HttpRequest

    Public Class HttpResponseData

        Public Property Status As Integer
        Public Property Headers As Dictionary(Of String, String)
        Public Property Body As Byte()
        Public Property Cookies As Dictionary(Of String, String)

        Public Sub New()
            Headers = New Dictionary(Of String, String)()
            Cookies = New Dictionary(Of String, String)()
            Body = Array.Empty(Of Byte)()
        End Sub

        Public Function GetBodyAsString(Optional encoding As Encoding = Nothing) As String
            If encoding Is Nothing Then encoding = Encoding.UTF8
            Return encoding.GetString(Body)
        End Function

    End Class

    Private ReadOnly cookieContainer As CookieContainer

    Public Sub New()
        cookieContainer = New CookieContainer()
    End Sub

    Public Function MakeRequest(url As String, Optional method As String = "GET", Optional data As Dictionary(Of String, String) = Nothing, Optional headers As Dictionary(Of String, String) = Nothing) As HttpResponseData

        Dim handler As New HttpClientHandler() With {
            .AllowAutoRedirect = True,
            .UseCookies = True,
            .CookieContainer = cookieContainer
        }

        Dim client As New HttpClient(handler) With {
            .Timeout = TimeSpan.FromSeconds(30)
        }
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:143.0) Gecko/20100101 Firefox/143.0")

        Dim requestMessage As New HttpRequestMessage(New HttpMethod(method), url)

        If headers IsNot Nothing Then
            For Each kvp In headers
                Dim headerName = kvp.Key.ToLowerInvariant()

                If headerName = "transfer-encoding" Or headerName = "content-length" Or headerName = "host" Then
                    Continue For
                End If


                If headerName = "content-type" Then
                    If requestMessage.Content Is Nothing Then
                        requestMessage.Content = New StringContent("")
                    End If
                    requestMessage.Content.Headers.ContentType = New Headers.MediaTypeHeaderValue(kvp.Value)
                Else
                    requestMessage.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value)
                End If
            Next
        End If

        If method.Equals("POST", StringComparison.CurrentCultureIgnoreCase) AndAlso data IsNot Nothing Then
            Dim postData As String = String.Join("&", data.Select(Function(kvp) WebUtility.UrlEncode(kvp.Key) & "=" & WebUtility.UrlEncode(kvp.Value)))
            requestMessage.Content = New StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")
        End If

        Try
            Dim response As HttpResponseMessage = client.SendAsync(requestMessage).Result

            Dim result As New HttpResponseData() With {
                .Status = response.StatusCode,
                .Body = response.Content.ReadAsByteArrayAsync().Result
            }

            For Each h In response.Headers
                Dim headerValue As String = String.Join(";", h.Value)

                result.Headers(h.Key) = headerValue
            Next
            For Each h In response.Content.Headers
                Dim headerValue As String = String.Join(";", h.Value)

                result.Headers(h.Key) = headerValue
            Next

            Dim cookieCollection As CookieCollection = cookieContainer.GetCookies(New Uri(url))
            For Each c As Cookie In cookieCollection
                result.Cookies(c.Name) = c.Value
            Next

            Return result
        Catch ex As IOException
            Throw New Exception("Error de transporte (EOF). Reintenta la petición.", ex)
        End Try
    End Function

    Public Async Function MakeRequest2(url As String,
                                Optional method As String = "GET",
                                Optional data As Dictionary(Of String, String) = Nothing,
                                Optional headers As Dictionary(Of String, String) = Nothing,
                                Optional returnAsByteArray As Boolean = False) As Task(Of HttpResponseData)

        Dim handler As New HttpClientHandler() With {
            .AllowAutoRedirect = True,
            .UseCookies = True,
            .CookieContainer = cookieContainer
        }

        Dim client As New HttpClient(handler) With {
            .Timeout = TimeSpan.FromSeconds(30)
        }
        client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:143.0) Gecko/20100101 Firefox/143.0")

        Dim requestMessage As New HttpRequestMessage(New HttpMethod(method), url)

        If headers IsNot Nothing Then
            For Each kvp In headers
                Dim headerName = kvp.Key.ToLowerInvariant()

                If headerName = "transfer-encoding" Or headerName = "content-length" Or headerName = "host" Then
                    Continue For
                End If

                If headerName = "content-type" Then
                    If requestMessage.Content Is Nothing Then
                        requestMessage.Content = New StringContent("")
                    End If
                    requestMessage.Content.Headers.ContentType = New Headers.MediaTypeHeaderValue(kvp.Value)
                Else
                    requestMessage.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value)
                End If
            Next
        End If

        If method.Equals("POST", StringComparison.CurrentCultureIgnoreCase) AndAlso data IsNot Nothing Then
            Dim postData As String = String.Join("&", data.Select(Function(kvp) WebUtility.UrlEncode(kvp.Key) & "=" & WebUtility.UrlEncode(kvp.Value)))
            requestMessage.Content = New StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded")
        End If

        Try
            Dim response As HttpResponseMessage = Await client.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead)

            Dim result As New HttpResponseData() With {
                .Status = response.StatusCode,
                .Body = If(returnAsByteArray, Await response.Content.ReadAsByteArrayAsync(), Encoding.UTF8.GetBytes(Await response.Content.ReadAsStringAsync()))
            }

            For Each h In response.Headers
                result.Headers(h.Key) = String.Join(";", h.Value)
            Next
            For Each h In response.Content.Headers
                result.Headers(h.Key) = String.Join(";", h.Value)
            Next

            Dim cookieCollection As CookieCollection = cookieContainer.GetCookies(New Uri(url))
            For Each c As Cookie In cookieCollection
                result.Cookies(c.Name) = c.Value
            Next

            Return result

        Catch ex As IOException
            Throw New Exception("Error de transporte (EOF). Reintenta la petición.", ex)
        End Try
    End Function

End Class
