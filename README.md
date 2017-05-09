cx-demo
=======

This repo contains code created during presentation/follow-along workshop presented at Computas 09.05.2017.
The topic was .Net core and azure. Under is the speekers notes for the presentations.

Prerequisites
-------------

In order to follow along with the presentation, you'll need to install the following:
* [.Net Core](https://www.microsoft.com/net/core#windowscmd) - Choose Command line/other if installing on Windows
* A [GitHub account](https://github.com/join?source=header)
* A free [Azure account](https://azure.microsoft.com/nb-no/free/)

In addition you'll need something to edit code with. Any editor will do, but the presentation was given with [Visual Studio Code](https://code.visualstudio.com/).


Azure and .Net Core
-------------------

### Create a new git repo on GitHub

Create a new github repo named cx-demo. Then:
```
git clone https://github.com/teodoran/cx-demo.git
cd cx-demo
```

### Initialize a new .Net Core webapi-project

Initialize a new .Net Core webapi-project with:
```
dotnet new webapi -o CxApi
```

Add the new bare-bones project to git
```
git add --all
git commit -m "Initialized new webapi"
```

Restore and run the project
```
cd .\CxApi
dotnet restore
dotnet run
```
You should now be able to visit [localhost:5000/api/values](localhost:5000/api/values)

Note that dotnet has produced build folders `bin/` and `obj`. Create a `.gitignore`-file and add the following:
```
# Ignore C# build files
bin/
obj/
```

Add and commit the changes with:
```
git add --all
git commit -m "Ignored C# build folders"
```

### Modify the default webapi to create a hello-api

We'll now have a look at what the default webapi-prosject contains. Program.cs contains out main() function. This is the starting point of the application. The main funtion builds a host-server, and starts it. Note that the host server object is configured with a Startup-type. This is related to the contents of Startup.cs

Startup.cs contains the api-server framework setup. Among other things, it spesifies that we'll use [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/) as our server framework.

Finally we'll look at ValuesController.cs. This contains the acutal API-implementation. Note that the class and the methods in the class is annotated with route-annotations like `[Route("api/[controller]")]`. Theese annotations tell ASP.NET core how different url's should result in different functions in different controllers beeing called.

Now we'll rewrite the ValuesController into our own HelloController. First rename the file to HelloController.cs and the class to HelloController. Then modify the hello controller so it matches [this version](https://github.com/teodoran/cx-demo/blob/48dfb6f7151b5dd2675637e28a50e452cffd8e23/CxApi/Controllers/HelloController.cs).

Test the changes out with:
```
dotnet run
```
Then visit [localhost:5000/api/hello](localhost:5000/api/hello) and [localhost:5000/hello/world](localhost:5000/api/hello/world). Note that [localhost:5000/api/values](localhost:5000/api/values) dosn't work any more.

Add and commit the modified webapi with:
```
git add --all
git commit -m "Added api/hello and api/hello/{name}"
```

Push the changes to GitHub with:
```
git push origin master
```

### Deploy the hello-api to Azure

Visit the [Azure-portal](portal.azure.com) and do the following:
1.  Create a new resource group named cx-demo
2.  Add a new API App to the resource group cx-demo named cx-hello-someuniquename
3.  Open the new API App and visit Deployment Options
4.  Under deployment options: Configure it to use GitHub (you'll need to authorize azure to access your github profile) and select the cx-demo project

If everything worked, a new deployment should start, based on the code in your GitHub-repository.
After the deployment is finished, you should be able to visit [cx-hello-someuniquename.azurewebsites.net/api/hello](cx-hello-someuniquename.azurewebsites.net/api/hello)

New changed pushed to GitHub will now be deployed automatically to Azure. Try i out! Make a small change on your local machine, add, commit and puth the changes to GitHub.

### Final topics

We modified the hello-api to return JSON based on a C# model. This was done according to the changes in [this changeset](https://github.com/teodoran/cx-demo/commit/7e8abf692c12c25f88346f4e7bf5cbfd41b2fa55)

Finally we moved the model class to another project called CxCommon, and referenced this project in the CxApi-project.
To create the CxCommon project we used the following command to create a new class-library project:
```
dotnet new classlib -o CxCommon
```
Then the model class was moved and the code updated as shown in [this commit](https://github.com/teodoran/cx-demo/commit/c572825796fb0dbf0b21848809b06443d643df69)

### Any questions?

Try submitting a [GitHub issue](https://github.com/teodoran/cx-demo/issues/new), or contact me on twitter [@_teodoran](https://twitter.com/_teodoran/)
