Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks

Public Class ModelEventHandler

    Private WithEvents mModelGenerationContext As IModelGenerationContext
    Private mSolidWorksService As ISolidWorksService

    Public Sub New(context As IModelGenerationContext, solidworksservice As ISolidWorksService)
        mModelGenerationContext = context
        mSolidWorksService = solidworksservice

    End Sub

    Private Sub mModelGenerationContext_CopiedMasterModel(sender As Object, e As EventArgs) Handles mModelGenerationContext.CopiedMasterModel
        'MessageBox.Show("event mModelGenerationContext_CopiedMasterModel called")
    End Sub

    Private Sub mModelGenerationContext_Prepared(sender As Object, e As ModelPreparationResultEventArgs) Handles mModelGenerationContext.Prepared
        'MessageBox.Show("event mModelGenerationContext_Prepared called")
    End Sub
End Class