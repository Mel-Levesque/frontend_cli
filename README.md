#Consigne :

Choper un clé API pour OpenAi API et la mettre dans les variables d'environnement de la machine sous le nom "CHAT_GPT_KEY"\

Pour le build, exécuter les commandes : 
``
dotnet pack .\mjj.csproj
dotnet build .\mjj.csproj
dotnet tool install --global --add-source .\nupkg\ mjj
``

Le cli est maintenant disponible et appelable par la commadne ``mjj``