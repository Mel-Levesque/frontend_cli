using System.Reflection;
using CliWrap;

namespace microsoft.botsay;

internal class Program
{
    static void Main(string[] args)
    {
        //string databaseUrl = Environment.GetEnvironmentVariable("CHAT_GPT_KEY");
        Console.Write("Ecris ! : ");
        string? text = Console.ReadLine();
        if (text is not null && text.Trim() != "")
        {
            string[] words = text.Trim().Split(' ', 2);

            if (words[0] == "html")
            {
                string contenu = words.Length < 2 ? "Pas de consigne" : words[1];
                cssTemplate();
                javascriptTemplate();
                htmlTemplate(contenu);
            }

            // if(text.Contains("html")){
            //     var result = Cli.Wrap("wsl")
            //     .WithArguments(new[] {"touch", "index.html"})
            //     .ExecuteAsync();
            // }
            //touch index.html

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

    static void htmlTemplate(string contenu)
    {
        string cheminFichier = "test.html";
        string contenuHtml = $@"
<!DOCTYPE html>
<html>
    <head>
        <title>Mon premier fichier HTML en C#</title>
        <link href='./test.css' rel='stylesheet' />
        <script type='text/javascript' src='./test.js'></script>
    </head>
    <body>
        <h1>Bienvenue dans mon fichier HTML généré en C#!</h1>
        <p>C'est simple et amusant.</p>
        <p>{contenu}</p>
        <button onclick='writeSomething()'>Cliquer ici</button>
    </body>
</html>
";
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

    static void cssTemplate()
    {
        string cheminFichier = "test.css";
        string contenuCss = @"
body{
    background-color: black;
    color: white;
}
";

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

    static void javascriptTemplate()
    {
        string cheminFichier = "test.js";
        string contenuCss = @"
function writeSomething(){
    window.alert('Hello world!');
}
";
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
}