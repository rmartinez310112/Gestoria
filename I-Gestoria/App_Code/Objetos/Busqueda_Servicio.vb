Imports Microsoft.VisualBasic

Public Class CBusqueda_Servicios
    Private _estado As String
    Private _municipio As String
    Private _cliente As String
    Private _servicio As String

    Public Property Estado() As String
        Set(value As String)
            _estado = value
        End Set
        Get
            Return _estado
        End Get
    End Property

    Public Property Municipio() As String
        Set(value As String)
            _municipio = value
        End Set
        Get
            Return _municipio
        End Get
    End Property

    Public Property Cliente() As String
        Set(value As String)
            _cliente = value
        End Set
        Get
            Return _cliente
        End Get
    End Property

    Public Property Servicio() As String
        Set(value As String)
            _servicio = value
        End Set
        Get
            Return _servicio
        End Get
    End Property
End Class

Public Class CNumero_Remesa

    Private _numServicio As String
    Private _usuario As String
    Private _etapa As Integer
    Private _fecha As Date
    Private _numRemesa As String

    Public Property NumRemesa() As String
        Set(value As String)
            _numRemesa = value
        End Set
        Get
            Return _numRemesa
        End Get
    End Property

    Public Property NumServicio() As String
        Set(value As String)
            _numServicio = value
        End Set
        Get
            Return _numServicio
        End Get
    End Property

    Public Property Usuario() As String
        Set(value As String)
            _usuario = value
        End Set
        Get
            Return _usuario
        End Get
    End Property

    Public Property Etapa() As Integer
        Set(value As Integer)
            _etapa = value
        End Set
        Get
            Return _etapa
        End Get
    End Property

    Public Property Fecha() As Date
        Set(value As Date)
            _fecha = value
        End Set
        Get
            Return _fecha
        End Get
    End Property

End Class
