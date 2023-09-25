using System.Reflection;
using CliWrap;

namespace microsoft.frontend_cli;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("html [nom du projet] [texte a afficher]");
        Console.Write("Ecris ! : ");
        string? text = Console.ReadLine();
        if (text is not null && text.Trim() != "")
        {
            string[] words = text.Trim().Split(' ', 3);

            if (words[0] == "html")
            {
                string contenu = words.Length < 3 ? "Pas de consigne" : words[2];
                string projectName = words[1];

                createFolder(projectName);
                cssTemplate(projectName);
                javascriptTemplate(projectName);
                htmlTemplate(projectName, contenu);
            }

            // Nom de la variable d'environnement que vous souhaitez récupérer
            string variableName = "CHAT_GPT_KEY";

            // Récupérer la valeur de la variable d'environnement
            string? variableValue = Environment.GetEnvironmentVariable(variableName);

            if (variableValue != null)
            {
                Console.WriteLine($"La valeur de la variable {variableName} est : {variableValue}");
            }
            else
            {
                Console.WriteLine($"La variable d'environnement {variableName} n'est pas définie.");
            }
        }
    }

    static void htmlTemplate(string projectName, string contenu)
    {
        //string cheminFichier = projectName + ".html";
        string cheminFichier = "./projects/" + projectName + "/" + projectName + ".html";

        string contenuHtml = Template.Htmltp(projectName);
        try
        {
            File.WriteAllText(cheminFichier, contenuHtml);
            Console.WriteLine($"Fichier HTML '{cheminFichier}' créé avec succès.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Une erreur s'est produite : {e.Message}");
        }
    }

    static void cssTemplate(string projectName)
    {
        string cheminFichier = "./projects/" + projectName + "/" + projectName + ".css";

        string contenuCss = Template.Csstp();

        try
        {
            File.WriteAllText(cheminFichier, contenuCss);
            Console.WriteLine($"Fichier Css '{cheminFichier}' créé avec succès.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Une erreur s'est produite : {e.Message}");
        }
    }

    static void javascriptTemplate(string projectName)
    {
        string cheminFichier = "./projects/" + projectName + "/" + projectName + ".js";
        string contenuJs = @"
        function writeSomething(){
            window.alert('Hello world!');
        }
        ";

        //string contenuCss = Template.JsTp();

        try
        {
            File.WriteAllText(cheminFichier, contenuJs);
            Console.WriteLine($"Fichier Css '{cheminFichier}' créé avec succès.");
        }
        catch (IOException e)
        {
            Console.WriteLine($"Une erreur s'est produite : {e.Message}");
        }
    }

    //Create sub Folder in 'projects' folder with the project name
    static void createFolder(string projectName)
    {
        if (!Directory.Exists("projects"))
        {
            Directory.CreateDirectory("projects");
        }
        string dirProject = "projects/" + projectName;
        if (!Directory.Exists(dirProject))
        {
            Directory.CreateDirectory(dirProject);
        }
    }
}