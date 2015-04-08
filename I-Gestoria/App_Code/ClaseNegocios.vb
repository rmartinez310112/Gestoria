Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Net
Imports System.Data
Imports System.IO
Imports System.ComponentModel
Imports Telerik.Web.UI
Imports System.Security.Cryptography

Public Class ClaseNegocios

    Dim Unidad(9) As String
    Dim Teens(5) As String
    Dim Decenas(9) As String
    Dim Centenas(9) As String
    Dim Caract(15) As Integer

    Public Shared MailHost As String
    Public Shared MailPort As String

    Sub New()

        MailHost = ConfigurationManager.AppSettings("mailHost").ToString
        MailPort = ConfigurationManager.AppSettings("mailPort").ToString

    End Sub

    Public Function NumLetras(ByVal tyCantidad As Double) As String
        Dim lyCantidad As Double, lyCentavos As Double, lnDigito As Byte, lnPrimerDigito As Byte, lnSegundoDigito As Byte, lnTercerDigito As Byte, lcBloque As String, lnNumeroBloques As Byte, lnBloqueCero
        Dim I As Object 'Si esta como Option Explicit
        NumLetras = ""
        tyCantidad = Math.Round(tyCantidad, 2)
        lyCantidad = Int(tyCantidad)
        lyCentavos = (tyCantidad - lyCantidad) * 100
        Dim laUnidades() As Object = {"UN", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE", "DIECISEIS", "DIECISIETE", "DIECIOCHO", "DIECINUEVE", "VEINTE", "VEINTIUN", "VEINTIDOS", "VEINTITRES", "VEINTICUATRO", "VEINTICINCO", "VEINTISEIS", "VEINTISIETE", "VEINTIOCHO", "VEINTINUEVE"}
        Dim laDecenas() As Object = {"DIEZ", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA"}
        Dim laCentenas() As Object = {"CIENTO", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS"}
        lnNumeroBloques = 1
        Do
            lnPrimerDigito = 0
            lnSegundoDigito = 0
            lnTercerDigito = 0
            lcBloque = ""
            lnBloqueCero = 0
            For I = 1 To 3
                lnDigito = lyCantidad Mod 10
                If lnDigito <> 0 Then
                    Select Case I
                        Case 1
                            lcBloque = " " & laUnidades(lnDigito - 1)
                            lnPrimerDigito = lnDigito
                        Case 2
                            If lnDigito <= 2 Then
                                lcBloque = " " & laUnidades((lnDigito * 10) + lnPrimerDigito - 1)
                            Else
                                lcBloque = " " & laDecenas(lnDigito - 1) & IIf(lnPrimerDigito <> 0, " Y", "") & lcBloque
                            End If
                            lnSegundoDigito = lnDigito
                        Case 3
                            lcBloque = " " & IIf(lnDigito = 1 And lnPrimerDigito = 0 And lnSegundoDigito = 0, "CIEN", laCentenas(lnDigito - 1)) & lcBloque
                            lnTercerDigito = lnDigito
                    End Select
                Else
                    lnBloqueCero = lnBloqueCero + 1
                End If
                lyCantidad = Int(lyCantidad / 10)
                If lyCantidad = 0 Then
                    Exit For
                End If
            Next I
            Select Case lnNumeroBloques
                Case 1
                    NumLetras = lcBloque
                Case 2
                    NumLetras = lcBloque & IIf(lnBloqueCero = 3, "", " MIL") & NumLetras
                Case 3
                    NumLetras = lcBloque & IIf(lnPrimerDigito = 1 And lnSegundoDigito = 0 And lnTercerDigito = 0, " MILLON", " MILLONES") & NumLetras
            End Select
            lnNumeroBloques = lnNumeroBloques + 1
        Loop Until lyCantidad = 0

        If NumLetras = "" Then
            NumLetras = "CERO PESOS " & Completar2(CInt(Math.Round(lyCentavos))) & "/100 M.N."
        Else
            NumLetras &= IIf(tyCantidad > 1, " PESOS ", " PESO ") & Completar2(CInt(Math.Round(lyCentavos))) & "/100 M.N."
        End If

        NumLetras = Trim(NumLetras)
    End Function

    Public Function Completar2(ByVal numero As Integer) As String
        Return IIf(numero < 10, "0" & numero, numero)
    End Function

    Public Sub EnviarEmail3h(ByRef de As String, ByRef para As String, ByRef titulo As String, ByRef mensaje As String)

        Try
            Dim mail_enviar As New MailMessage()
            mail_enviar.From = New MailAddress(de)
            mail_enviar.To.Add(para)

            mail_enviar.Subject = titulo
            mail_enviar.Body = mensaje
            mail_enviar.Priority = Net.Mail.MailPriority.High
            Dim client As New SmtpClient(System.Configuration.ConfigurationManager.AppSettings("ServidorEmail"))
            Dim credencial = New NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("EmailEnvia"), System.Configuration.ConfigurationManager.AppSettings("PassEnvia"))
            client.Credentials = credencial
            client.EnableSsl = True
            client.Send(mail_enviar)

        Catch er As SystemException
        'MsgBox("No hay comunicación con el servidor smtp, favor de verificarlo. Gracias.")
        End Try
    End Sub

    Public Sub EnviarEmail3hHTML(ByRef de As String, ByRef para As String, ByRef titulo As String, ByRef mensaje As String)

        Try
            Dim mail_enviar As New MailMessage()
            mail_enviar.From = New MailAddress(de)
            mail_enviar.To.Add(para)
            Dim htmlView As AlternateView = AlternateView.CreateAlternateViewFromString(mensaje, Nothing, "text/html")
            mail_enviar.Subject = titulo
            mail_enviar.IsBodyHtml = True
            mail_enviar.Body = mensaje
            mail_enviar.Priority = Net.Mail.MailPriority.High
            Dim client As New SmtpClient(System.Configuration.ConfigurationManager.AppSettings("ServidorEmail"))
            Dim credencial = New NetworkCredential(System.Configuration.ConfigurationManager.AppSettings("EmailEnvia"), System.Configuration.ConfigurationManager.AppSettings("PassEnvia"))
            client.Credentials = credencial

            client.EnableSsl = True
            client.Send(mail_enviar)

        Catch er As SystemException
            Dim err As String = er.Message
        'MsgBox("No hay comunicación con el servidor smtp, favor de verificarlo. Gracias.")
        End Try
    End Sub

    Public Shared Function EncryptString(ByVal InputString As String, ByVal SecretKey As String, Optional ByVal CyphMode As CipherMode = CipherMode.ECB) As String
        Try
            Dim Des As New TripleDESCryptoServiceProvider
            'Put the string into a byte array
            Dim InputbyteArray() As Byte = Encoding.UTF8.GetBytes(InputString)
            'Create the crypto objects, with the key, as passed in
            Dim hashMD5 As New MD5CryptoServiceProvider
            Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretKey))
            Des.Mode = CyphMode
            Dim ms As MemoryStream = New MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateEncryptor(), _
            CryptoStreamMode.Write)
            'Write the byte array into the crypto stream
            '(It will end up in the memory stream)
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()
            'Get the data back from the memory stream, and into a string
            Dim ret As StringBuilder = New StringBuilder
            Dim b() As Byte = ms.ToArray
            ms.Close()
            Dim I As Integer
            For I = 0 To UBound(b)
                'Format as hex
                ret.AppendFormat("{0:X2}", b(I))
            Next

            Return ret.ToString()
        Catch ex As System.Security.Cryptography.CryptographicException
            Return ""
        End Try

    End Function

    Public Shared Function DecryptString(ByVal InputString As String, ByVal SecretKey As String, Optional ByVal CyphMode As CipherMode = CipherMode.ECB) As String
        If InputString = String.Empty Then
            Return ""
        Else
            Dim Des As New TripleDESCryptoServiceProvider
            'Put the string into a byte array
            Dim InputbyteArray(InputString.Length / 2 - 1) As Byte '= Encoding.UTF8.GetBytes(InputString)
            'Create the crypto objects, with the key, as passed in
            Dim hashMD5 As New MD5CryptoServiceProvider

            Des.Key = hashMD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(SecretKey))
            Des.Mode = CyphMode
            'Put the input string into the byte array

            Dim X As Integer

            For X = 0 To InputbyteArray.Length - 1
                Dim IJ As Int32 = (Convert.ToInt32(InputString.Substring(X * 2, 2), 16))
                Dim BT As New ByteConverter
                InputbyteArray(X) = New Byte
                InputbyteArray(X) = CType(BT.ConvertTo(IJ, GetType(Byte)), Byte)
            Next

            Dim ms As MemoryStream = New MemoryStream
            Dim cs As CryptoStream = New CryptoStream(ms, Des.CreateDecryptor(), _
            CryptoStreamMode.Write)

            'Flush the data through the crypto stream into the memory stream
            cs.Write(InputbyteArray, 0, InputbyteArray.Length)
            cs.FlushFinalBlock()

            '//Get the decrypted data back from the memory stream
            Dim ret As StringBuilder = New StringBuilder
            Dim B() As Byte = ms.ToArray

            ms.Close()

            Dim I As Integer

            For I = 0 To UBound(B)
                ret.Append(Chr(B(I)))
            Next

            Return ret.ToString()
        End If
    End Function


    Public Function Fecha_Texto(ByVal fecha As Date) As String
        Fecha_Texto = IIf(fecha.Month < 10, "0", "") & fecha.Month & "-"
        Fecha_Texto &= IIf(fecha.Day < 10, "0", "") & fecha.Day & "-"
        Fecha_Texto &= fecha.Year
    End Function
    ' Convierte una fecha a texto en el formato 'hh:mm'
    Public Function Hora_Texto(ByVal fecha As Date) As String
        Hora_Texto = IIf(fecha.Hour < 10, "0", "") & fecha.Hour & ":"
        Hora_Texto &= IIf(fecha.Minute < 10, "0", "") & fecha.Minute
    End Function

    Public Function VaciosTexto(ByVal sControl As Object) As Boolean
        VaciosTexto = False
        Dim sText As Telerik.Web.UI.RadTextBox = sControl
        If sText.Text.Trim = String.Empty Then
            VaciosTexto = True
        End If

    End Function

    Public Function VaciosNumero(ByVal sControl As Object) As Boolean
        VaciosNumero = False
        Dim sText As Telerik.Web.UI.RadNumericTextBox = sControl
        If Val(sText.Text) = 0 Then
            VaciosNumero = True
        End If
    End Function

    Public Function checaNumTelefonos(ByVal sControl As Object) As Boolean
        checaNumTelefonos = False
        Dim sText As Telerik.Web.UI.RadTextBox = sControl
        If sText.Text.Trim <> String.Empty Then
            If Len(sText.Text.Trim) < 10 Then
                checaNumTelefonos = True
            End If
        End If
    End Function
    Public Function EnteroFrac(ByVal numero As Double) As String

        Dim result As String = ""
        Dim nCantidad As Double
        If IsNumeric(numero) Then
            nCantidad = numero
            Dim nLeng = Len(nCantidad)
            Dim nPos = InStr(1, Trim(Str(numero)), ".")
            If nPos <> 0 Then
                Dim parEntera = Mid(Trim(Str(numero)), 1, nPos - 1)
                Dim parFracc = Mid(Trim(Str(numero)), nPos + 1, nLeng)
                If Len(parFracc) = 1 Then
                    parFracc = Trim(parFracc) & "0"
                End If
                result = Num2Txt(parEntera) & " Pesos " & parFracc & "/100 "
            Else
                Dim parEntera = numero
                Dim parFracc = "00"
                result = Num2Txt(parEntera) & " Pesos " & parFracc & "/100 "
            End If
        End If
        EnteroFrac = result
    End Function
    Public Function Num2Txt(ByVal Numero As Double) As String
        Dim i As Integer
        'Unidades
        Unidad(0) = "Cero"
        Unidad(1) = "Un"
        Unidad(2) = "Dos"
        Unidad(3) = "Tres"
        Unidad(4) = "Cuatro"
        Unidad(5) = "Cinco"
        Unidad(6) = "Seis"
        Unidad(7) = "Siete"
        Unidad(8) = "Ocho"
        Unidad(9) = "Nueve"
        '10 al 15
        Teens(0) = "Diez"
        Teens(1) = "Once"
        Teens(2) = "Doce"
        Teens(3) = "Trece"
        Teens(4) = "Catorce"
        Teens(5) = "Quince"
        '20 al 90
        Decenas(1) = "Diez"
        Decenas(2) = "Veinte"
        Decenas(3) = "Treinta"
        Decenas(4) = "Cuarenta"
        Decenas(5) = "Cincuenta"
        Decenas(6) = "Sesenta"
        Decenas(7) = "Setenta"
        Decenas(8) = "Ochenta"
        Decenas(9) = "Noventa"
        '100 al 900
        Centenas(1) = "Cien"
        Centenas(2) = "Doscientos"
        Centenas(3) = "Trescientos"
        Centenas(4) = "Cuatrocientos"
        Centenas(5) = "Quinientos"
        Centenas(6) = "Seiscientos"
        Centenas(7) = "Setecientos"
        Centenas(8) = "Ochocientos"
        Centenas(9) = "Novecientos"

        Dim NumPPP As String
        Dim NumStr As String
        Dim Largo As Integer

        NumStr = ""
        NumPPP = ""
        For i = 1 To (15 - Len(CStr(Numero)))
            NumStr = NumStr + "0"
        Next i
        NumStr = NumStr + CStr(Numero)
        For i = 1 To 15
            Caract(i) = CInt(Mid(NumStr, i, 1))
        Next i
        Largo = Len(CStr(Numero))

        Select Case Largo
            Case 1 'Unidad
                NumPPP = Unidad(Numero)
            Case 2 'Decena
                NumPPP = DecenaTxt(14) + Unidadtxt(15)
            Case 3 'Centena
                NumPPP = CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 4 'Mil
                NumPPP = MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 5 'Decena Mil
                NumPPP = DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 6 'Centena Mil
                NumPPP = CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 7 'Millon
                If Caract(9) = 1 Then
                    NumPPP = "Un Millón " + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
                Else
                    NumPPP = MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
                End If
            Case 8 'Decena Mill
                NumPPP = DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 9 'Centena Mill
                NumPPP = CentenaTxt(7) + DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 10 'Mil Mill
                NumPPP = MilTxt(6) + CentenaTxt(7) + DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 11 'Decena Mill
                NumPPP = DecenaTxt(5) + MilTxt(6) + CentenaTxt(7) + DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 12 'Centena Mill
                NumPPP = CentenaTxt(4) + DecenaTxt(5) + MilTxt(6) + CentenaTxt(7) + DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 13 'Billon
                If Caract(3) = 1 Then
                    NumPPP = "Un Billón " + CentenaTxt(4) + DecenaTxt(5) + MilTxt(6) + CentenaTxt(7) + DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
                Else
                    NumPPP = MilTxt(3) + "Billones " + CentenaTxt(4) + DecenaTxt(5) + MilTxt(6) + CentenaTxt(7) + DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
                End If
            Case 14 'Decena Bill
                NumPPP = DecenaTxt(2) + MilTxt(3) + "Billones " + CentenaTxt(4) + DecenaTxt(5) + MilTxt(6) + CentenaTxt(7) + DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
            Case 15 'Centena Bill
                NumPPP = CentenaTxt(1) + DecenaTxt(2) + MilTxt(3) + "Billones " + CentenaTxt(4) + DecenaTxt(5) + MilTxt(6) + CentenaTxt(7) + DecenaTxt(8) + MilTxt(9) + CentenaTxt(10) + DecenaTxt(11) + MilTxt(12) + CentenaTxt(13) + DecenaTxt(14) + Unidadtxt(15)
        End Select
        Return NumPPP
    End Function

    Public Function Unidadtxt(ByVal pos As Integer) As String
        If Caract(pos) > 0 And Caract(pos - 1) = 0 Then
            Unidadtxt = Unidad(Caract(pos)) + " "
        End If
    End Function

    Public Function DecenaTxt(ByVal pos As Integer) As String
        Select Case Caract(pos)
            Case 1
                Select Case Caract(pos + 1)
                    Case Is < 6
                        Select Case pos
                            Case 14
                                DecenaTxt = Teens(Caract(pos + 1)) + " "
                            Case 8
                                DecenaTxt = Teens(Caract(pos + 1)) + " Millones "
                            Case 2
                                DecenaTxt = Teens(Caract(pos + 1)) + " "
                            Case 5
                                DecenaTxt = Teens(Caract(pos + 1)) + " Mil Millones "
                            Case Else
                                DecenaTxt = Teens(Caract(pos + 1)) + " Mil "
                        End Select
                    Case Is >= 6
                        Select Case pos
                            Case 14
                                DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " "
                            Case 2
                                DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " "
                            Case 8
                                DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " Millones "
                            Case 5
                                DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " Mil Millones "
                            Case Else
                                DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " Mil "
                        End Select
                End Select
            Case Is > 1
                If Caract(pos + 1) > 0 Then
                    Select Case pos
                        Case 14
                            DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " "
                        Case 8
                            DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " Millones "
                        Case 5
                            DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " Mil Millones "
                        Case 2
                            DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " "
                        Case Else
                            DecenaTxt = Decenas(Caract(pos)) + " y " + Unidad(Caract(pos + 1)) + " Mil "
                    End Select
                Else
                    Select Case pos
                        Case 14
                            DecenaTxt = Decenas(Caract(pos)) + " "
                        Case 8
                            DecenaTxt = Decenas(Caract(pos)) + " Millones "
                        Case 5
                            DecenaTxt = Decenas(Caract(pos)) + " Mil Millones "
                        Case 2
                            DecenaTxt = Decenas(Caract(pos)) + " "
                        Case Else
                            DecenaTxt = Decenas(Caract(pos)) + " Mil "
                    End Select
                End If
        End Select
    End Function

    Public Function CentenaTxt(ByVal pos As Integer) As String
        Select Case Caract(pos)
            Case 1
                If Caract(pos + 1) = 0 And Caract(pos + 2) = 0 Then
                    Select Case pos
                        Case 4
                            CentenaTxt = "Cien Mil Millones "
                        Case 7
                            CentenaTxt = "Cien Millones "
                        Case 10
                            CentenaTxt = "Cien Mil "
                        Case Else
                            CentenaTxt = "Cien "
                    End Select
                Else
                    CentenaTxt = "Ciento "
                End If
            Case Is > 1
                CentenaTxt = Centenas(Caract(pos)) + " "
        End Select
    End Function

    Public Function MilTxt(ByVal pos As Integer) As String
        If Caract(pos - 1) = 0 Then
            Select Case Caract(pos)
                Case 1
                    Select Case pos
                        Case 6
                            MilTxt = "Mil Millones "
                        Case 12
                            MilTxt = "Mil "
                    End Select
                Case Is > 1
                    Select Case pos
                        Case 6
                        Case 12
                            MilTxt = Unidad(Caract(pos)) + " Mil "
                        Case 9
                            MilTxt = Unidad(Caract(pos)) + " Millones "
                        Case Else
                            MilTxt = Unidad(Caract(pos)) + " "
                    End Select
            End Select
        End If
    End Function

    Public Sub WindowAlert(ByVal ajax As RadAjaxManager, ByVal message As String)
        'HtmlEncode string to prevent JavaScript hacks 
        Dim alertMsg As String = HttpContext.Current.Server.HtmlEncode(message)
        'String.Format breaks this function due to the extra { } brackets 
        'so we must resort to usign the old fashion string concat 
        ajax.ResponseScripts.Add("try{radalert('" & alertMsg & "');}catch(err){alert('" & alertMsg & "');}")
    End Sub

    Public Function VerificaEmail(ByVal sMailAdd As String) As Boolean
        Try
            Dim oMailMsg As New MailMessage
            oMailMsg.To.Add(sMailAdd)
            Return True
        Catch exFormat As FormatException
            Return False
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function EnviarMail(ByRef de As String, ByRef para As String, ByRef titulo As String, ByRef mensaje As String, ByRef server As String, ByVal att As Integer, ByVal fileEnviar As String) As Boolean
        If Not server = "" Then
            Try
                Dim mail_enviar As New System.Net.Mail.MailMessage
                mail_enviar.From = New MailAddress(de)
                mail_enviar.To.Add(New MailAddress(para))
                mail_enviar.Subject = titulo
                mail_enviar.Body = mensaje
                mail_enviar.IsBodyHtml = True
                mail_enviar.Priority = Net.Mail.MailPriority.High
                If att = 1 Then
                    Dim attach As New Net.Mail.Attachment(fileEnviar)
                    mail_enviar.Attachments.Add(attach)
                End If
                Dim client As New SmtpClient(server)
                client.Send(mail_enviar)
                Return True
            Catch er As SystemException
                Return False
            End Try
        End If

    End Function

    'MAIL12345678_4206E676G85A

    Public Function myStr(ByVal valor As String) As String
        Try
            myStr = ""
            myStr = "'" & Replace(Trim(valor.Trim.ToUpper), "'", "") & "'"
            Return myStr
        Catch ex As Exception
            Return valor
        End Try

    End Function
    Public Function myStrlwr(ByVal valor As String) As String
        Try
            myStrlwr = ""
            myStrlwr = "'" & Replace(Trim(valor.Trim.ToLower), "'", "") & "'"
            Return myStrlwr
        Catch ex As Exception
            Return valor
        End Try

    End Function

    Public Function GetPassword() As String
        Dim builder As String
        builder = (RandomString(2, True)) & (RandomNumber(10, 30)) & (RandomString(1, False))
        Return builder.ToString()
    End Function 'GetPassword 
    Public Function RandomNumber(ByVal min As Integer, ByVal max As Integer) As Integer
        Dim random As New Random()
        Threading.Thread.Sleep(10)
        Return random.Next(min, max)
    End Function 'RandomNumber 

    Public Function RandomString(ByVal size As Integer, ByVal lowerCase As Boolean) As String
        Dim builder As String = ""
        Dim random As New Random()
        Dim ch As Char
        'Dim i As Integer
        For i = 0 To size - 1

            Threading.Thread.Sleep(10)
            ch = Convert.ToChar(Convert.ToInt32((26 * random.NextDouble() + 65)))
            builder = builder + ch
        Next
        If lowerCase Then
            Return builder.ToString().ToUpper()
        End If
        Return builder.ToString()
    End Function 'RandomString 

#Region "Envio Mail con adjuntos"

    Public Sub EnviarTxt(ByVal [from] As String, ByVal [to] As IList(Of String), ByVal Copia As IList(Of String), ByVal subject As String, ByVal body As String, ByVal Adjuntos_Texto() As String, ByVal ContentType_Texto() As String, ByVal Adjuntos_Archivo() As String, ByVal ContentType_Archivo() As String)

        'If [to] = "" Then Exit Sub

        ' Prepara los objetos
        Dim mensaje As New MailMessage()
        Dim smtp As New SmtpClient(MailHost)

        ' Prepara el mensaje
        'mensaje.To.Add([to].Trim)
        If [to].Count <> 0 Then
            For i As Integer = 0 To [to].Count - 1
                mensaje.To.Add([to].Item(i))
            Next
        End If

        mensaje.From = New MailAddress([from])
        mensaje.Subject = subject
        mensaje.Body = body

        ' attachments como archivos
        If Adjuntos_Archivo IsNot Nothing Then
            For i As Integer = 0 To Adjuntos_Archivo.Length - 1
                'mensaje.Attachments.Add(New Attachment(ReemplazaCaracteres(Adjuntos_Archivo(i)))) ', ContentType_Texto(i)))
                mensaje.Attachments.Add(New Attachment(Adjuntos_Archivo(i))) ', ContentType_Texto(i)))
            Next
        End If

        ' attachments en forma de stream
        If Adjuntos_Texto IsNot Nothing Then
            For i As Integer = 0 To Adjuntos_Texto.Length - 1
                mensaje.Attachments.Add(Attachment.CreateAttachmentFromString(Adjuntos_Texto(i), ContentType_Texto(i)))
            Next
        End If

        ' Envía un email
        smtp.Send(mensaje)

    End Sub

#End Region


End Class


