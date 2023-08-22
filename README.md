Construction365 Mobile App Middleware
---
 

## Code Naming Conventions 

Classes: PascalCase 

Constants: UPPER_SNAKE_CASE 

Interfaces: IPascalCase (Prefix I + PascalCase) 

Methods: lowerCamelCase 

Parameters: lowerCamelCase 

Variables: lowerCamelCase 

Database Table Name: PascalCase (Singular) 

Database Column Name: camelCase 

 

## Files Naming Conventions 

Services: camelCase.service.ts or camelCase.service.js 

Components: camelCase.component.ts or camelCase.component.js 

Pipes: camelCase.pipe.ts or camelCase.pipe.js 

 

## Git Naming Conventions 

Branches: taskCategory_branchName_trackerId_userName  (task category can be feature-, hotfix-, chore- etc, trackerId is the id of the feature/bug to easily track branch) 

 
Getting Started
---
### Env: Development
- Install the latest version of [Visual Studio](https://visualstudio.microsoft.com/vs/).
- Install  Git Version:2.38.1.windows.1 (https://git-scm.com/downloads).
- Open start menu, search Git Bash and open it.
- Change the current working directory to the location where you want the cloned directory.
- Type git clone in the terminal, paste the URL (https://impulztech@dev.azure.com/impulztech/Construction365%20Mobile%20App%20Middleware/_git/Construction365MiddleWare), and press "enter" to create your local clone.
- Open visual studio and open the project from the directory where it was cloned. Select project's .sln file to open it.
- Click on "IIS Express" or press F5 to start the middleware on IIS server.
- Visit ```https://localhost:44367/swagger``` and call APIs throught swagger or Postman.


### Env: Production
- Publish the application from Visual studio.
- Create a new site on IIS Manager and copied the files in the site's directory.
- Configure the front end app to point towards the site URL set in IIS Manager.
