﻿Imports System.Xml.Serialization
Imports Microsoft.VisualBasic.Text.Xml.Linq

Public Class database

    Public Property name As String
    Public Property description As String
    Public Property release As String
    Public Property release_date As String
    Public Property entry_count As Integer
    Public Property entries As entry()

    Public Shared Function LoadReferenceEntries(file As String) As IEnumerable(Of entry)
        Return file.LoadUltraLargeXMLDataSet(Of entry)()
    End Function

End Class

Public Class entry

    <XmlAttribute> Public Property id As String
    Public Property name As String
    Public Property description As String
    Public Property cross_references As ref()
    Public Property dates As [date]()
    Public Property additional_fields As field()

End Class

Public Class ref

    <XmlAttribute> Public Property dbkey As String
    <XmlAttribute> Public Property dbname As String

End Class

Public Class [date]

    <XmlAttribute> Public Property type As String
    <XmlAttribute> Public Property value As String

End Class

Public Class field

    <XmlAttribute>
    Public Property name As String

    <XmlText> Public Property value As String

End Class

