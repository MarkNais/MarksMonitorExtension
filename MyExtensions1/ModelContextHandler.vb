Imports DriveWorks.SolidWorks.Generation
Imports System.Windows.Forms

Public Class ModelContextHandler
    Private WithEvents mContext As IModelGenerationContext

    Public Sub New(ByVal context As IModelGenerationContext)
        mContext = context
    End Sub

    Private Sub HandleCopied(ByVal sender As Object, ByVal e As System.EventArgs) Handles mContext.CopiedMasterModel

        MessageBox.Show("event HandleCopied called")
    End Sub

End Class
