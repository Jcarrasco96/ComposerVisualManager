Imports Newtonsoft.Json

Public Class RequireConverter
    Inherits JsonConverter

    Public Overrides Function CanConvert(objectType As Type) As Boolean
        Return objectType = GetType(Dictionary(Of String, String))
    End Function

    Public Overrides Function ReadJson(reader As JsonReader, objectType As Type, existingValue As Object, serializer As JsonSerializer) As Object
        If reader.TokenType = JsonToken.String Then
            Dim stringValue = reader.Value?.ToString()
            If stringValue = "__unset" Then
                Return New Dictionary(Of String, String)()
            End If
        End If

        If reader.TokenType = JsonToken.StartObject Then
            Try
                Return serializer.Deserialize(Of Dictionary(Of String, String))(reader)
            Catch ex As Exception
                Return New Dictionary(Of String, String)()
            End Try
        End If

        Return New Dictionary(Of String, String)()
    End Function

    Public Overrides Sub WriteJson(writer As JsonWriter, value As Object, serializer As JsonSerializer)
        serializer.Serialize(writer, value)
    End Sub

End Class