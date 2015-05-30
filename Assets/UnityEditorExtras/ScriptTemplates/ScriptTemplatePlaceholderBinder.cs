using UnityEditor;
using System;
using System.IO;
using PedZed.StringManipulation;

namespace PedZed.Unity
{
    public class ScriptTemplatePlaceholderBinder : UnityEditor.AssetModificationProcessor
    {
        private const string PascalCaseCompanyNamePlaceholder = "#PASCALCASED_COMPANY_NAME#";
        private const string PascalCaseProjectNamePlaceholder = "#PASCALCASED_PROJECT_NAME#";
        private const string PascalCaseScriptNamePlaceholder = "#PASCALCASED_SCRIPT_NAME#";
        private const string CreationDatePlaceholder = "#CREATION_DATE#";

        private static string file;
        private static string fileName;
        private static string filePath;
        private static string fileExtension;
        private static string fileContents;

        private static void OnWillCreateAsset(string assetMetaFile)
        {
            filePath = assetMetaFile.Replace(".meta", "");
            file = Path.GetFileName(filePath);
            int indexUpToExtension = file.LastIndexOf(".");
            fileName = file.Substring(0, indexUpToExtension);
            fileExtension = file.Substring(indexUpToExtension);

            if(IsAScript(filePath))
            {
                fileContents = File.ReadAllText(filePath);

                BindPlaceholders(filePath);

                AssetDatabase.Refresh();
            }
        }

        private static bool IsAScript(string file)
        {
            return (
                fileExtension == ".cs" ||
                fileExtension == ".js" ||
                fileExtension == ".boo"
            );
        }

        private static void BindPlaceholders(string file)
        {
            BindCreationDatePlaceholder();
            BindPascalCasedCompanyNamePlaceholder();
            BindPascalCasedProjectNamePlaceholder();
            BindPascalCasedScriptNamePlaceholder();

            File.WriteAllText(file, fileContents);
        }

        private static void BindCreationDatePlaceholder()
        {
            fileContents = fileContents.Replace(CreationDatePlaceholder, DateTime.Now.ToString());
        }

        private static void BindPascalCasedCompanyNamePlaceholder()
        {
            fileContents = fileContents.Replace(
                PascalCaseCompanyNamePlaceholder,
                GetPascalCasedString(PlayerSettings.companyName)
            );
        }

        private static void BindPascalCasedProjectNamePlaceholder()
        {
            fileContents = fileContents.Replace(
                PascalCaseProjectNamePlaceholder,
                GetPascalCasedString(PlayerSettings.productName)
            );
        }

        private static void BindPascalCasedScriptNamePlaceholder()
        {
            fileContents = fileContents.Replace(
                PascalCaseScriptNamePlaceholder,
                GetPascalCasedString(fileName)
            );
        }

        private static string GetPascalCasedString(string toPascalCase)
        {
            StringToPascalCase stringManipulator = new StringToPascalCase(toPascalCase);
            return stringManipulator.GetManipulatedString();
        }
    }
}
