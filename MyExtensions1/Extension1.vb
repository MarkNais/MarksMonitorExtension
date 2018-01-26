' Import main DriveWorks Extensibility types
Imports DriveWorks.Applications
Imports DriveWorks.Applications.Extensibility
Imports DriveWorks.SolidWorks

Imports DriveWorks.Extensibility
Imports DriveWorks.SolidWorks.Generation
Imports System.Windows.Forms



' Other useful extensibility imports in DriveWorks.Engine.dll (this has been added as a reference for you)
' Imports DriveWorks
' Imports DriveWorks.Specification

' Other useful extensibility imports in DriveWorks.Applications.dll (this has been added as a reference for you)
' Imports DriveWorks.Applications                              
' Imports DriveWorks.Applications.Administrator.Extensibility  
' Imports DriveWorks.Applications.Autopilot.Extensibility      

' Other useful extensibility imports (you will need to add a reference to use these)
' Imports DriveWorks.SolidWorks                                 ' In DriveWorks.SolidWorks.dll
<ApplicationPlugin(
    "MarksExtension",
    "Marks Special Plugin",
    "It should show a message box")>
Public NotInheritable Class DriveWorksEventsPlugin
    Implements IApplicationPlugin

    'Private WithEvents mGenerationService As IGenerationService
    'Private WithEvents mModelGenerationContext As IModelGenerationContext
    Private mGenerationHandler As GenerationServiceHandler
    Private mSolidWorksService As ISolidWorksService




    Public Sub Initialize(ByVal application As IApplication) Implements IApplicationPlugin.Initialize
        Try
            'mGenerationService = application.ServiceManager.GetService(Of IGenerationService)()
            'mModelGenerationContext = application.ServiceManager.GetService(Of IModelGenerationContext)()

            MessageBox.Show("event Initialize called")
            mGenerationHandler = New GenerationServiceHandler(application)

            mSolidWorksService = application.ServiceManager.GetService(Of ISolidWorksService)()
            MessageBox.Show("mSolidWorksService is Nothing = " + CStr(mSolidWorksService Is Nothing))

            MessageBox.Show("Initialize done")
        Catch ex As Exception

            MessageBox.Show("Initialize failed")
        End Try

        'Throw New NotImplementedException()
    End Sub

    'Private Sub mGenerationService_ModelGenerationContextCreated(sender As Object, e As ModelGenerationContextEventArgs) Handles mGenerationService.ModelGenerationContextCreated
    '    Dim handler As ModelEventHandler
    '    handler = New ModelEventHandler(e.Context, mSolidWorksService)
    'End Sub
End Class
