﻿Imports System.IO
Imports Microsoft.VisualBasic.CommandLine.Reflection
Imports Microsoft.VisualBasic.Scripting.MetaData
Imports SMRUCC.Rsharp.Runtime
Imports SMRUCC.Rsharp.Runtime.Components
Imports SMRUCC.Rsharp.Runtime.Interop

''' <summary>
''' MTBLS study project data reader
''' </summary>
<Package("MTBLSStudy")>
Module MTBLSStudy

    <ExportAPI("read.study_source")>
    <RApiReturn(GetType(Source))>
    Public Function readSourceInformation(<RRawVectorArgument> file As Object, Optional env As Environment = Nothing) As Object
        Dim is_path As Boolean = False
        Dim s = SMRUCC.Rsharp.GetFileStream(file, FileAccess.Read, env, is_filepath:=is_path)

        If s Like GetType(Message) Then
            Return s.TryCast(Of Message)
        End If

        Dim metadata As Source() = Source.LoadTsv(s.TryCast(Of Stream)).ToArray

        If is_path Then
            Call s.TryCast(Of Stream).Close()
        End If

        Return metadata
    End Function

End Module
