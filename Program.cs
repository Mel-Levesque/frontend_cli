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

        // Récupérer la valeur de la variable d'environnement
        /* string? variableValue = Environment.GetEnvironmentVariable("CHAT_GPT_KEY");

        if (variableValue != null)
        {
            OpenAIAPI api = new OpenAIAPI(variableValue);
            var chat = api.Chat.CreateConversation();
            //chat.AppendSystemMessage("What is the number after 10 ?");
            /* chat.AppendUserInput("Give me a picture of flowers");
            string response = await chat.GetResponseFromChatbotAsync();
            Console.WriteLine(response); */
            /*var result = await api.ImageGenerations.CreateImageAsync("A pack of flowers");
            Console.WriteLine(result.Data[0].Url);
        } */
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