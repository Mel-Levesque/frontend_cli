using OpenAI_API;
using OpenAI_API.Images;
using System;
using System.IO;
using System.Threading;
using System.Text.RegularExpressions;

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
        string contenu = string.Join(" ", argumentList.Skip(2).Take(argumentList.Length - 1));
        createFolder(projectName);
        cssTemplate(projectName);
        javascriptTemplate(projectName);
        htmlTemplate(projectName, contenu);
        await OpenApiData(projectName, contenu);
    }

    static async Task OpenApiData(string projectName, string contenu)
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
                chat.AppendUserInput("A partir de ce template, génère le texte (qui remplace le Lorem ipsum) et les images correspondants au produit suivant: " + contenu + ". Ne répond que du code, pas autre chose. Ne pas changer <link rel='stylesheet' href='./{filename}.css'> template:" + templateString);
                string response = await chat.GetResponseFromChatbotAsync();
                Console.WriteLine(response);
                File.WriteAllText(path, response);

                string cheminFichier = "./projects/" + projectName + "/" + projectName + ".html";
                string contenuFichier = File.ReadAllText(cheminFichier);

                string pattern1 = @"<p id=""p1"">(.*?)<\/p>";
                Regex regex1 = new Regex(pattern1, RegexOptions.Singleline);
                Match match1 = regex1.Match(contenuFichier);
                string p1 = match1.Groups[1].Value;

                string pattern2 = @"<p id=""p2"">(.*?)<\/p>";
                Regex regex2 = new Regex(pattern2, RegexOptions.Singleline);
                Match match2 = regex2.Match(contenuFichier);
                string p2 = match2.Groups[1].Value;

                string pattern3 = @"<p id=""p3"">(.*?)<\/p>";
                Regex regex3 = new Regex(pattern3, RegexOptions.Singleline);
                Match match3 = regex3.Match(contenuFichier);
                string p3 = match3.Groups[1].Value;
            
                var image1 = await api.ImageGenerations.CreateImageAsync("Find me an image related to this paragraph : " + p1);
                string url1 = image1.Data[0].Url;
                contenuFichier = contenuFichier.Replace(@"src=""imgToReplace1""", @"src='"+ url1 +"'");
                File.WriteAllText(cheminFichier, contenuFichier);

                var image2 = await api.ImageGenerations.CreateImageAsync("Find me an image related to this paragraph : " + p2);
                string url2 = image2.Data[0].Url;
                contenuFichier = contenuFichier.Replace(@"src=""imgToReplace2""", @"src='"+ url2 +"'");
                File.WriteAllText(cheminFichier, contenuFichier);

                var image3 = await api.ImageGenerations.CreateImageAsync("Find me an image related to this paragraph : " + p3);
                string url3 = image3.Data[0].Url;
                contenuFichier = contenuFichier.Replace(@"src=""imgToReplace3""", @"src='"+ url3 +"'");
                File.WriteAllText(cheminFichier, contenuFichier);
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