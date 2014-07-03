Imports DotNetNuke.Entities.Users
Imports DotNetNuke.Entities.Profile

Namespace Connect.Libraries.UserManagement.Interfaces

    ''' <summary>
    ''' Provides pre and post hooks on the user registration.
    ''' </summary>
    ''' <remarks></remarks>
    Public Interface iAccountRegistration

        ''' <summary>
        ''' Provides a validation routine that will be called just before the user registration happens.
        ''' At this point the <see cref="UserInfo">objUser</see> object contains values for all properties that have
        ''' been filled from the template.
        ''' 
        ''' If the method returns false the regisitration will be cancelled and the user will not be registered
        ''' </summary>
        ''' <param name="Server"></param>
        ''' <param name="Response"></param>
        ''' <param name="Request"></param>
        ''' <param name="objUser">The <see cref="UserInfo">UserInfo</see> instance that contains the values filled from the template form</param>
        ''' <param name="profileProperties">Collection of ProfilePropertyDefinition with the values filled from the template form</param>
        ''' <param name="errorMessages">Contains all the messages that will be displayed to the user in case the validation fails. Can already
        ''' contain some messages when it is passed to the method because of some previous errors detected on the form.</param>
        ''' <returns>True if the validation succeeds, false otherwise. If there are any messages they should be returned as new entries on the
        ''' <paramref name="errorMessages">errorMessages</paramref> parameter</returns>
        ''' <remarks>If the validation fails the registration will be cancelled</remarks>
        Function ValidateRegistration(ByRef Server As System.Web.HttpServerUtility, ByRef Response As HttpResponse, ByRef Request As HttpRequest, ByVal objUser As UserInfo, ByVal profileProperties As ProfilePropertyDefinitionCollection, ByVal errorMessages As List(Of String)) As Boolean

        ''' <summary>
        ''' Provides a method that will be called after the <see cref="UserInfo">user</see> has been succesfully registered
        ''' </summary>
        ''' <param name="Server"></param>
        ''' <param name="Response"></param>
        ''' <param name="Request"></param>
        ''' <param name="objUser">The <see cref="UserInfo">UserInfo</see> instance that contains the values filled from the template form</param>
        ''' <remarks>The user might not be approved at this point yet depending on the registration mode for the site</remarks>
        Sub FinalizeAccountRegistration(ByRef Server As System.Web.HttpServerUtility, ByRef Response As HttpResponse, ByRef Request As HttpRequest, ByVal objUser As UserInfo)

    End Interface

End Namespace

