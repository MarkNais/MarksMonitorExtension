' Import main DriveWorks Extensibility types
Imports DriveWorks.Applications
Imports DriveWorks.Applications.Extensibility
'Imports DriveWorks.SolidWorks
'Imports DriveWorks.Extensibility
'Imports DriveWorks.SolidWorks.Generation   


<ApplicationPlugin(
    "Top-Down through XML",
    "Top-Down Reference Corrector",
    "This plugin will allow assemblies to be modeled with a 'skeleton' part." & vbCrLf &
    "The plugin will try to find an XML file with the paths of the old and new skeleton part," & vbCrLf &
    "and will correct every part/assy that references the old skeleton before the main generation sequence.")>
Public NotInheritable Class DriveWorksEventsPlugin
    Implements IApplicationPlugin

    'Private WithEvents mGenerationService As IGenerationService
    'Private WithEvents mModelGenerationContext As IModelGenerationContext
    Private mGenerationHandler As GenerationServiceHandler



    Public Sub Initialize(ByVal application As IApplication) Implements IApplicationPlugin.Initialize
        Try
            Debug.Assert(Not application Is Nothing, "application is 'nothing'! Can not execute!")
            mGenerationHandler = New GenerationServiceHandler(application)
        Catch ex As Exception
            Debug.Fail("The 'Top-Down' DriveWorks Extension failed to load")
        End Try

        'Throw New NotImplementedException()
    End Sub

End Class