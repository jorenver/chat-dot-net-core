# chat-dot-net-core
 .Net Core Web Chat
 
 # Install dependencies
 ```console
User:~$ dotnet add package MongoDB.Driver.Core --version 2.12.2
User:~$ dotnet add package MongoDB.Driver --version 2.12.2
User:~$ dotnet add package Newtonsoft.Json --version 13.0.1
```
 # Configure MonDB
 fill out appsettings.json
  ```js
"ChatDatabaseSettings": {
  "MessageCollectionName": "Messages",
  "ConnectionString": "mongodb://localhost:27017",
  "DatabaseName": "ChatDB"
}
```

 
 # Run Project
 ```console
User:~$ dotnet run
```

# Example
<img width="1278" alt="Screen Shot 2021-04-26 at 00 01 43" src="https://user-images.githubusercontent.com/5691763/116031519-7613b000-a623-11eb-84ee-3898a8082b9c.png">

<img width="1280" alt="Screen Shot 2021-04-26 at 00 01 57" src="https://user-images.githubusercontent.com/5691763/116031531-7b70fa80-a623-11eb-84c5-9cb6628c75bb.png">
