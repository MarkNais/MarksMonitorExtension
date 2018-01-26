Imports DriveWorks.SolidWorks.Generation
Imports System.Windows.Forms

Public Class ModelContextHandler
    Private WithEvents mContext As IModelGenerationContext

    Public Sub New(ByVal context As IModelGenerationContext)
        mContext = context
    End Sub

    Private Sub handleCopied(ByVal sender As Object, ByVal e As System.EventArgs) Handles mContext.CopiedMasterModel
        MessageBox.Show("event handleCopied called")
    End Sub

    Private Sub handelGenerated(sender As Object, e As EventArgs) Handles mContext.Generated
        MessageBox.Show("event handelGenerated called")
    End Sub
End Class
