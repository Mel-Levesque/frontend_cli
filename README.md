# Consigne :

Choper un clé API pour OpenAi API et la mettre dans les variables d'environnement de la machine sous le nom "CHAT_GPT_KEY"\

Supprimer l'ancien outils s'il existe :
```
dotnet tool uninstall mjj -g
```

Pour le build, exécuter les commandes : 
```
dotnet pack mjj.csproj
dotnet build mjj.csproj
dotnet tool install --global --add-source nupkg/ mjj
```

Pour les experts qui comprennent ce qu'ils font :
```
dotnet pack mjj.csproj && dotnet tool update --global --add-source nupkg/ mjj
```

Le cli est maintenant disponible et appelable par la commande ```mjj```


Application Electron
Se rendre dans le dossier electron-app puis exécuter la commande:
```
npm run start
```