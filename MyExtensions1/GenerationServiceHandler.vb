Imports DriveWorks.Applications
Imports DriveWorks.SolidWorks.Generation
Imports DriveWorks.SolidWorks
'Imports DriveWorks.Specification

''' <summary>
''' Handles the model generation process.
''' </summary>
''' <remarks></remarks>
Public Class GenerationServiceHandler
    Private WithEvents mGenerationService As IGenerationService
    Private WithEvents mSolidWorksService As ISolidWorksService
    Private WithEvents mGroupService As IGroupService

    ''' <summary>
    ''' Initializes a new instance of the <see cref="GenerationServiceHandler" /> class.
    ''' </summary>
    ''' <param name="application">The hosting application.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal application As IApplication)
        If application Is Nothing Then Throw New ArgumentNullException("application is Nothing")

        ' Get hold of the services - if the application doesn't have one, Nothing is returned
        mGenerationService = application.ServiceManager.GetService(Of IGenerationService)()
        mSolidWorksService = application.ServiceManager.GetService(Of ISolidWorksService)()
        mGroupService = application.ServiceManager.GetService(Of IGroupService)()
    End Sub

    Private Sub HandleGeneratingModel(ByVal sender As Object, ByVal e As ModelGenerationContextEventArgs) Handles mGenerationService.ModelGenerationContextCreated

        ' Create a new handler to handle the generation of the specified model
        Dim handler As ModelContextHandler
        handler = New ModelContextHandler(e.Context, mSolidWorksService, mGroupService.ActiveGroup)
    End Sub


End Class