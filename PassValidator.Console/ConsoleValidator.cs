namespace PassValidator.Console;

public static class ConsoleValidator
{
    public static int ValidatePass(string path, bool isVerbose)
    {
        if (!File.Exists(path))
        {
            VerbosePrinter.Print(isVerbose, $"The file '{path}' does not exist.");
            return -2;
        }

        try
        {
            VerbosePrinter.Print(isVerbose, $"Validating pass at: {path}");
            var passContents = File.ReadAllBytes(path);
            if (passContents.Length == 0)
            {
                VerbosePrinter.Print(isVerbose, "The pass file is empty.");
                return -3;
            }

            var validator = new Validator.Validator();
            var validationResult = validator.Validate(passContents);

            VerbosePrinter.PrintValidationResults(isVerbose, validationResult);
            bool isValid = IsPassValid(validationResult);

            return isValid ? 0 : -4;
        }
        catch (Exception ex)
        {
            VerbosePrinter.Print(isVerbose, $"An error occurred while validating the pass: {ex.Message}");
            return -5;
        }
    }

    private static bool IsPassValid(Validator.ValidationResult validationResult)
    {
        bool fileStructureValid = IsFileStructureValid(validationResult);
        bool hasRequiredFields = HasRequiredFields(validationResult);
        bool identifiersMatch = IdentifiersMatch(validationResult);
        bool wwdrCertificateValid = IsWwdrCertificateValid(validationResult);
        bool signaturesValid = IsPassSignatureValid(validationResult);

        bool isValid = fileStructureValid && hasRequiredFields &&
                        identifiersMatch && wwdrCertificateValid &&
                        signaturesValid;
        return isValid;
    }

    private static bool IsPassSignatureValid(Validator.ValidationResult validationResult)
    {
        return !validationResult.HasSignatureExpired &&
                validationResult.HasSignature &&
                validationResult.SignatureValid &&
                validationResult.SignedByApple;
    }

    private static bool IsWwdrCertificateValid(Validator.ValidationResult validationResult)
    {
        return validationResult.WwdrCertificateIsCorrectVersion &&
                validationResult.WwdrCertificateSubjectMatches &&
                !validationResult.WwdrCertificateExpired;
    }

    private static bool IdentifiersMatch(Validator.ValidationResult validationResult)
    {
        return validationResult.TeamIdentifierMatches &&
                validationResult.PassTypeIdentifierMatches;
    }

    private static bool HasRequiredFields(Validator.ValidationResult validationResult)
    {
        return validationResult.HasDescription &&
                validationResult.HasFormatVersion &&
                validationResult.HasOrganizationName &&
                validationResult.HasPassTypeIdentifier &&
                validationResult.HasSerialNumber &&
                validationResult.HasTeamIdentifier;
    }

    private static bool IsFileStructureValid(Validator.ValidationResult validationResult)
    {
        bool hasIcons = validationResult.HasIcon1x && validationResult.HasIcon2x;

        bool fileStructureValid = validationResult.HasPass && validationResult.HasManifest &&
                                    validationResult.HasSignature && hasIcons;
        return fileStructureValid;
    }
}
