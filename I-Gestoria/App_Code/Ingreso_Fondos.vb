Imports Microsoft.VisualBasic

Public Enum EnumFasesGuardar
    Insertar
    ActualizarDispersion
    ActualizarContabilidad
    Rechazar
    ActualizarAutorizacion
End Enum

Public Class Ingreso_Fondos
    Public cliente_clvCliente As Integer
    Public monto As Double
    Public ref_bancaria As String
    Public usuario As String
    Public fechadeposito As Date
    'Public fechaalta As DateTime
End Class

Public Class Retiro_Fondos
    Public Anio As Integer
    Public Cliente As Integer
    Public Tipo As Integer
    Public ClvEstado As Integer
    Public Numero As Integer

    Public cliente_clvCliente As Integer
    Public monto As Double
    Public motivosalida As String
    Public rfcgestor As String
    Public clavedeposito As String
    Public usuario As String
    Public fechadispersion As DateTime
    Public fechacontabilidad As DateTime
    Public numautorizadis As String
    Public numautorizaconta As String
    Public usuariodipersion As String
    Public usuariocontabilidad As String
    Public fase As EnumFasesGuardar
    Public motivorechazo As String
    Public fase2 As Integer
    Public usuarioAutoriza As String
    Public fechaAutoriza As String
End Class