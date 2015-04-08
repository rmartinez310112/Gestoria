Imports System.Web.Configuration

Public Class Logs

    ''' <summary>
    ''' Ruta del archivo de log de errores
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared RUTA_ARCHIVO_LOG As String = System.Configuration.ConfigurationManager.AppSettings("Logs")

    ''' <summary>
    ''' Log de errores
    ''' </summary>
    ''' <param name="archivo">Archivo donde se produjo el error</param>
    ''' <param name="rutina">Rutina donde se produjo el error</param>
    ''' <param name="mensaje">Mensaje de error</param>
    ''' <param name="InfoExtra">Información extra acerca del error</param>
    ''' <remarks></remarks>
    Public Shared Sub LogError(ByVal archivo As String, ByVal rutina As String, ByVal mensaje As String, Optional ByVal InfoExtra As String = "")
        On Error Resume Next

        'Log de errores
        Dim fecha As Date = Now
        Dim sw As IO.StreamWriter = IO.File.AppendText(RUTA_ARCHIVO_LOG & "Errores_" & getNombreMes(fecha.Month) & "_" & fecha.Year & ".log")
        sw.WriteLine(fecha & ": " & archivo & " - " & rutina & "; " & mensaje & " " & InfoExtra)
        sw.Close()
        ' Envía un email
        'Email.Enviar(WebConfigurationManager.AppSettings("mailFrom"),
        '             WebConfigurationManager.AppSettings("mailAdmin"),
        '             "Error en el sistema AutoSigue", mensaje)
    End Sub
End Class

