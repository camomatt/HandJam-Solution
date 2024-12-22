Option Strict On
Option Explicit On

Public Class SettersAndGetters
    '============================
    '=== Right Panel Controls ===
    '============================
    Public Property RPControls As Object(,)
        Get
            Return _RPControls
        End Get
        Set(value As Object(,))
            _RPControls = value
        End Set
    End Property
    Public _RPControls As Object(,) = {}
    Public Property Conditions As Object(,)
        Get
            Return _Conditions
        End Get
        Set(value As Object(,))
            _Conditions = value
        End Set
    End Property
    Public _Conditions As Object(,) = {}
    Public Property ImportHeaders As String()
        Get
            Return _ImportHeaders
        End Get
        Set(value As String())
            _ImportHeaders = value
        End Set
    End Property
    Public _ImportHeaders As String() = {}
    Public Property CardProperties As Integer()
        Get
            Return _CardProperties
        End Get
        Set(value As Integer())
            _CardProperties = value
        End Set
    End Property
    Public _CardProperties As Integer() = {}
End Class
