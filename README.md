# Feature Flag Management and Usage in Azure App Configuration using C#.NET

The example contains:

Feature Flag Manager - A web API project to manage(create, update and delete) feature flags.

Client Application - An MVC application which consumes the feature flags and acts as a client.

## Feature flag
- A feature flag is a variable with a binary state on or off. Feature flagging is a software engineering technique that turns select functionality on and off during runtime, without deploying code.

## Azure App Configuration
- Azure app configuration is a resource in azure which provides a service to centrally manage application settings and feature flags. User can create app configuration to store Key-Value settings and consume (Read) it in application.

## Let's get started 
**Pre-requisite** 
 - .Net 5.0
 - C# > 7.0
 - An Azure Account
 - Code Editor (Visual Studio or VS Code)


## Step 1: Create an App Configuration resource in Azure
 - Login to your azure subscription Azure Portal and search for app configuration.
 ![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/1.png)
 
 - Create a new app configuration resource by providing the required fields and hit "Review + Create".
 ![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/2.png)
 
 - Confirm details and click on "Create" button. Here we created an app configuration resource successfully.
 
 - Now click on "Access Keys" under settings blade from left panel. As we are going to read and push values to app configuration, we need to choose "Read-Write Keys" tab and would need the connection string for the same.
![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/3.png)

 - Click on "Configuration explorer" under Operations blade from left pane and you will notice there are no key-values are available.
 
 ## Step 2: Feature Flag Manager
 
 Let's create a new Web API application to manage(create, update, delete) feature flags.
 
 Open Visual Studio and create new Web API project (Feature Flag Manager)
 
 ![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/4.png)
 
 Add below NuGet packages to project.
Microsoft.Azure.AppConfiguration.AspNetCore,  Azure.Data.AppConfiguration

Add connection string in appsetting.json file.
Note: We discussed connection string in step 1

Now, add a new controller(FeatureFlagController) and create a new api(CreateFeatureFlag) using the below code

 ![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/5.png)

Here in the above piece of code, we are creating a new configuration client object using the connection string.

We are going to create a new configuration setting ".appconfig.featureflag/" as prefix for name and ContentType as "application/vnd.microsoft.appconfig.ff+json;charset=utf-8" which is specific for feature flags.

We also create a configuration with "LatestUpdate" as key and current time as value and make updates to it, so it can be used for dynamic refresh on the client. We will go through the client part later.

Coming to the Request model, We have the properties that the feature manager expects. Through this we can configure the filters and also the corresponding parameters.

![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/6.png)

Now, run the application and the swagger UI shows up. Create a request referencing the following and notice if the feature flag has been created in Azure app configuration.

![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/7.png)

![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/8.png)

You can also look for the filters in the options -> advanced edit.

![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/9.png)

## Step 3: Client Application

Client application to see if the feature flag works.

Create a new ASP.NET Core MVC application.

Add below NuGet packages to project.
Microsoft.Azure.AppConfiguration.AspNetCore, Microsoft.FeatureManagement.AspNetCore

Your startup file needs to have below code for feature management.

![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/10.png)

The program.cs should look like this.

![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/11.png)

Notice the Configure Refresh part which is used for updating configuration on demand without needing an application restart.

I have helper classes for Filters, Context and Parameters under FilterHelpers folder.

Now create a new controller and add the below code

![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/12.png)

The above code checks if feature flag is enabled in the given context and returns view based on the state(on or off).

Run the application and you will notice a navigation bar at the top with New Feature. Click on New feature and you will know feature is turn on or off.

![](https://github.com/Vikas1116/FeatureFlagManager/blob/main/Images/13.png)

You will see Feature enabled if the feature flag is on and vice versa.



