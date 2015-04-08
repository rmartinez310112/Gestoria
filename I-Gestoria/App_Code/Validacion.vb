Imports Microsoft.VisualBasic

Public Class Validacion

    ''' <summary>
    ''' Arreglo con los símbolos mas comunes que aparecen generalmente en los nombre de los conceptos del sisema
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared SimbolosComunes() As Char = {"_", "-", "'", "(", ")", ",", ".", "@", "?", "¿", "¡", "!", ";", ":"}

    ''' <summary>
    ''' Verifica si la cadena contiene solo letras, digitos, espacios en blanco y simbolos comúnes
    ''' </summary>
    ''' <param name="txt"></param>
    ''' <returns></returns>
    ''' <remarks>Simbolos Comunes: _ - ' ( ) , . </remarks>
    Public Shared Function Solo_LetrasDigitosEspaciosSimbolos(ByVal txt As String) As Boolean
        ' Verifica si la cadena contiene números
        For i As Short = 0 To txt.Length - 1
            If Not (Char.IsLetterOrDigit(txt.Chars(i)) Or Char.IsWhiteSpace(txt.Chars(i)) Or SimbolosComunes_Contiene(txt.Chars(i))) Then
                Return False
            End If
        Next

        Return True
    End Function

    'Public Shared Function Solo_LetrasDigitosEspaciosSinNumeros(ByVal txt As String) As Boolean
    '    ' Verifica si la cadena contiene números
    '    For i As Short = 0 To txt.Length - 1
    '        If Not ( _
    '                   Char.IsLetter(txt.Chars(i)) Or _
    '                   Char.IsWhiteSpace(txt.Chars(i))
    '                ) Then
    '            Return False
    '        End If
    '    Next

    '    Return True
    'End Function

    ''' <summary>
    ''' Para saber si el arreglo de simbolos comunes contiene un cierto caracter. Esto es porque no funciona la rutina Contains
    ''' </summary>
    ''' <param name="c"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function SimbolosComunes_Contiene(c As Char) As Boolean
        For i As Short = 0 To SimbolosComunes.Length - 1
            If SimbolosComunes(i) = c Then Return True
        Next

        Return False
    End Function

End Class

''' <summary>
''' Excepción especial para las validaciones
''' </summary>
''' <remarks></remarks>
Public Class Validacion_Exception
    Inherits Exception


    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="Campo">Campo que resultó ser inválido</param>
    ''' <remarks></remarks>
    Sub New(ByVal Campo As String)
        MyBase.New("El campo: {" & Campo & "} es inválido")
    End Sub
End Class

