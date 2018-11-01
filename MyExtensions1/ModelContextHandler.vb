Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks
Imports DriveWorks
Imports System.IO
Imports System.Xml

Public Class ModelContextHandler
    Private WithEvents mContext As IModelGenerationContext
    Private WithEvents mSolidWorksService As ISolidWorksService
    Private WithEvents mGroup As Group
    Private oldSkeletonReference As String
    Private newSkeletongReference As String

    Public Sub New(ByVal context As IModelGenerationContext, solidWorksService As ISolidWorksService, group As Group)

        Dim swTargetPath As String, specificationResultPath As String, xmlPath As String
        Dim searchResults() As String
        Dim Settings As XmlReaderSettings
        Dim reader As XmlReader

        mContext = context
        mSolidWorksService = solidWorksService
        mGroup = group
        oldSkeletonReference = ""
        newSkeletongReference = ""

        'String manipulation to determine the Specification Result folder, and find the Skeleton Update XML file within
        swTargetPath = mContext.Model.TargetPath
        specificationResultPath = swTargetPath.Substring(0, swTargetPath.LastIndexOf("\"))
        searchResults = Directory.GetFiles(specificationResultPath, "SkeletonUpdate2*")

        If searchResults.Length > 0 Then
            xmlPath = searchResults(0) 'Existence of more than one "SkeletonUpdate2" file is unreasonable
            Settings = New XmlReaderSettings
            Settings.DtdProcessing = DtdProcessing.Parse
            reader = XmlReader.Create(xmlPath, Settings)

            On Error GoTo Cleanup

            'Find the two required tags in the document.
            reader.MoveToContent()
            While (reader.Read())

                If (reader.Name = "old") Then
                    reader.Read()
                    oldSkeletonReference = reader.Value
                    reader.Read() 'Skip the closing tag
                ElseIf (reader.Name = "new") Then
                    reader.Read()
                    newSkeletongReference = reader.Value
                    reader.Read() 'Skip the closing tag
                End If

            End While
Cleanup:
            reader.Close()

            'Else, if no XML file was found, fail silently. The lack of a new skeleton should be obvious to the user.
        End If
    End Sub

    Private Sub handleCopied(ByVal sender As Object, ByVal e As System.EventArgs) Handles mContext.CopiedMasterModel
        Dim swApp As SldWorks.SldWorks

        If newSkeletongReference <> "" And oldSkeletonReference <> "" Then
            'Replace the reference of generating-file's old skeleton with the new one.
            'Empty-string checking shouldn't be required, as ReplaceReferencedDocument() should fail silently.
            swApp = CType(mSolidWorksService.SolidWorks, SldWorks.SldWorks)
            'MsgBox("model:" & vbCrLf &
            '       mContext.Model.TargetPath &
            '        "Old:" & vbCrLf &
            '        oldSkeletonReference &
            '         "New:" & vbCrLf &
            '        newSkeletongReference)
            swApp.ReplaceReferencedDocument(mContext.Model.TargetPath, oldSkeletonReference, newSkeletongReference)
        End If
    End Sub

End Class
