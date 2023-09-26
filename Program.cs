using OpenAI_API;
using OpenAI_API.Images;

namespace microsoft.botsay;
internal class Program
{
    static async Task Main(string[] args)
    {
        /*
        * Nom du projet
        * Texte qui explique le projet
        *
        * Exemple :
        * mjj Nom_du_projet Desctiption du projet avec autant d'espaces que tu veux
        */
        string[] argumentList = Environment.GetCommandLineArgs();
        string projectName = string.Join(" ", argumentList.Skip(1).Take(1));
        string contenu = string.Join( " ", argumentList.Skip(2).Take(argumentList.Length - 1));
        createFolder(projectName);
        cssTemplate(projectName);
        javascriptTemplate(projectName);
        htmlTemplate(projectName, contenu);
        await OpenApiData(projectName, words);
    }

    static async Task OpenApiData(string projectName, string[] words)
    {
        // Nom de la variable d'environnement que vous souhaitez récupérer
        string variableName = "CHAT_GPT_KEY";

        // Récupérer la valeur de la variable d'environnement
        string? variableValue = Environment.GetEnvironmentVariable(variableName);

        if (variableValue != null)
        {
            OpenAIAPI api = new OpenAIAPI(variableValue);
            var chat = api.Chat.CreateConversation();
            string path = "./projects/" + projectName + "/" + projectName + ".html";
            string templateString = File.ReadAllText(path);
            chat.AppendSystemMessage("Tu es un expert html qui remplace tous les textes en latin, Lorem ipsum, en anglais, les titres et noms de fonctionnalités par du texte en français correspondant au thème donné. Ne répond que du code, pas autre chose. Ne pas changer <link rel='stylesheet' href='./{filename}.css'>.");
            chat.AppendUserInput("A partir de ce template, génère le texte (qui remplace le Lorem ipsum) et les images correspondants au produit suivant: " + words[2] + ". Ne répond que du code, pas autre chose. Ne pas changer <link rel='stylesheet' href='./{filename}.css'> template:" + templateString);
            string response = await chat.GetResponseFromChatbotAsync();
            Console.WriteLine(response);
            File.WriteAllText(path, response);
            //var result = await api.ImageGenerations.CreateImageAsync("A drawing of a flowers");
            //Console.WriteLine(result.Data[0].Url);
        }
        else
        {
            Console.WriteLine($"La variable d'environnement {variableName} n'est pas définie.");
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