Imports DriveWorks.Applications
Imports DriveWorks.SolidWorks.Generation
Imports System.Windows.Forms

''' <summary>
''' Handles the interaction between the model generation process and a PDM system.
''' </summary>
''' <remarks></remarks>
Public Class GenerationServiceHandler
    Private mEnabled As Boolean
    Private WithEvents mGenerationService As IGenerationService

    ''' <summary>
    ''' Initializes a new instance of the <see cref="GenerationServiceHandler" /> class.
    ''' </summary>
    ''' <param name="application">The hosting application.</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal application As IApplication)
        MessageBox.Show("application is Nothing = " + CStr(application Is Nothing))

        'MessageBox.Show("new GenerationServiceHandler called\nWith application: " + (application Is Nothing))
        'If application Is Nothing Then Throw New ArgumentNullException("application")

        mEnabled = True

        ' Get hold of the generation service - if the application doesn't have one, Nothing is returned
        mGenerationService = application.ServiceManager.GetService(Of IGenerationService)()
        MessageBox.Show("mGenerationService is Nothing = " + CStr(mGenerationService Is Nothing))
    End Sub

    Private Sub HandleGeneratingModel(ByVal sender As Object, ByVal e As ModelGenerationContextEventArgs) Handles mGenerationService.ModelGenerationContextCreated
        If Not mEnabled Then
            Return
        End If

        ' Create a new handler to handle the generation of the specified model
        Dim handler As ModelContextHandler
        handler = New ModelContextHandler(e.Context)
        MessageBox.Show("handler is Nothing = " + CStr(handler Is Nothing))
    End Sub
End Class