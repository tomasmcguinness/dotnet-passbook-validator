using PassValidator.Validator;

namespace PassValidator.Console;

public static class VerbosePrinter
{

    public static void Print(bool isVerbose, string message)
    {
        if (isVerbose)
        {
            System.Console.WriteLine(message);
        }
    }

    public static void PrintValidationResults(bool isVerbose, ValidationResult validationResult)
    {
        if (!isVerbose) return;
        System.Console.WriteLine("Validation Results:");
        System.Console.WriteLine($"\tHas Pass: {validationResult.HasPass}");
        System.Console.WriteLine($"\tHas Manifest: {validationResult.HasManifest}");
        System.Console.WriteLine($"\tHas Signature: {validationResult.HasSignature}");
        System.Console.WriteLine($"\tTeam Identifier Matches: {validationResult.TeamIdentifierMatches}");
        System.Console.WriteLine($"\tPass Type Identifier Matches: {validationResult.PassTypeIdentifierMatches}");
        System.Console.WriteLine($"\tSigned By Apple: {validationResult.SignedByApple}");
        System.Console.WriteLine($"\tSignature Expiration Date: {validationResult.SignatureExpirationDate}");
        System.Console.WriteLine($"\tSignature Valid: {validationResult.SignatureValid}");
        System.Console.WriteLine($"\tHas Icon 3x: {validationResult.HasIcon3x}");
        System.Console.WriteLine($"\tHas Icon 2x: {validationResult.HasIcon2x}");
        System.Console.WriteLine($"\tHas Icon 1x: {validationResult.HasIcon1x}");
        System.Console.WriteLine($"\tHas Pass Type Identifier: {validationResult.HasPassTypeIdentifier}");
        System.Console.WriteLine($"\tHas Team Identifier: {validationResult.HasTeamIdentifier}");
        System.Console.WriteLine($"\tHas Description: {validationResult.HasDescription}");
        System.Console.WriteLine($"\tHas Format Version: {validationResult.HasFormatVersion}");
        System.Console.WriteLine($"\tHas Serial Number: {validationResult.HasSerialNumber}");
        System.Console.WriteLine($"\tHas Serial Number of Correct Length: {validationResult.HasSerialNumberOfCorrectLength}");
        System.Console.WriteLine($"\tHas Organization Name: {validationResult.HasOrganizationName}");
        System.Console.WriteLine($"\tHas App Launch URL: {validationResult.HasAppLaunchUrl}");
        System.Console.WriteLine($"\tHas Associated Store Identifiers: {validationResult.HasAssociatedStoreIdentifiers}");
        System.Console.WriteLine($"\tWWDR Certificate Expired: {validationResult.WwdrCertificateExpired}");
        System.Console.WriteLine($"\tWWDR Certificate Subject Matches: {validationResult.WwdrCertificateSubjectMatches}");
        System.Console.WriteLine($"\tWWDR Certificate Is Correct Version: {validationResult.WwdrCertificateIsCorrectVersion}");
        System.Console.WriteLine($"\tHas Authentication Token: {validationResult.HasAuthenticationToken}");
        System.Console.WriteLine($"\tHas Web Service URL: {validationResult.HasWebServiceUrl}");
        System.Console.WriteLine($"\tWeb Service URL Is HTTPS: {validationResult.WebServiceUrlIsHttps}");
        System.Console.WriteLine($"\tAuthentication Token Requires Web Service URL: {validationResult.AuthenticationTokenRequiresWebServiceUrl}");
        System.Console.WriteLine($"\tWeb Service URL Requires Authentication Token: {validationResult.WebServiceUrlRequiresAuthenticationToken}");
        System.Console.WriteLine($"\tPassKit Certificate Name Correct: {validationResult.PassKitCertificateNameCorrect}");
    }
}
