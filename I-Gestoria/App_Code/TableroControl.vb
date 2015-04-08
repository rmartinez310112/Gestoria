'Imports Microsoft.VisualBasic

Public Class TableroControl

    Public Function ObtieneClienteTableto(ByVal sesionClienteTablero As String, ByVal comboclientetablero As String) As String
        Dim clienteTablero As String = "0"
        If comboclientetablero = "" Or comboclientetablero = "0" Then

            If sesionClienteTablero <> "0" Then clienteTablero = sesionClienteTablero

        Else

            clienteTablero = comboclientetablero

        End If

        ObtieneClienteTableto = clienteTablero

        Return ObtieneClienteTableto
    End Function


End Class
