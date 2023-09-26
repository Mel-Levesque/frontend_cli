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
        Console.WriteLine("html [nom du projet] [texte a afficher]");
        Console.Write("Ecris ! : ");
        string? text = Console.ReadLine();
        if (text is not null && text.Trim() != "")
        {
            string[] words = text.Trim().Split(' ', 3);
            string projectName = words.Length < 2 ? "project" : words[1];
            string codeHtml = "";

            if (words[0] == "html")
            {
                string contenu = words.Length < 3 ? "Pas de consigne" : words[2];               
                createFolder(projectName);
                cssTemplate(projectName);
                javascriptTemplate(projectName);
                htmlTemplate(projectName, contenu);
            }

            // Récupérer la valeur de la variable d'environnement
            string? variableValue = Environment.GetEnvironmentVariable("CHAT_GPT_KEY");

            if (variableValue != null)
            {
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
                
                OpenAIAPI api = new OpenAIAPI(variableValue);
                var chat = api.Chat.CreateConversation();
                //chat.AppendSystemMessage("What is the number after 10 ?");
                /* chat.AppendUserInput("Give me a picture of flowers");
                string response = await chat.GetResponseFromChatbotAsync();
                Console.WriteLine(response); */
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