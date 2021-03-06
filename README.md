# AwesomeBankingApp

The application has been devided into many projects:

* **AwesomeBankingApp.Bootstrap**  
    Contains abstraction for Module bootstraping. Registers configuration and services. It helps (in the future) to add next modules easily, such as Currency handling or additional module to manage Loans Configuration. Splitting project in separate modules helps to organize the code, test modules independently or reuse some of them.
* **AwesomeBankingApp.Api**  
    Main API host, registers Modules (Authorization, LoanWeb and LoanWebValidatior), configures .net core pipelines.
* **AwesomeBankingApp.Loan**  
    Module responsible for loans handling. Contains all business logic related to loans calculation, mostly maths and algorithms.
* **AwesomeBankingApp.Loan.Tests**  
    Unit tests for services within AwesomeBankingApp.Loan. Just example tests has been added to project.
* **AwesomeBankingApp.Loan.Web**  
    Module containing endpoints and web contracts for Loan. It is registered in main API project. If contracts would be dependency of some other projects (e.g. API client) it should be split to separate project to export just them, not endpoints.
* **AwesomeBankingApp.Loan.Validator**  
    Module containing validator for contracts (http requests) based on FluentValidation.
* **AwesomeBankingApp.Authorization**  
    Module containing Basic authentication. For demo purposes, it does not use any user repository but takes username and password stored in appsettings.  
    **Use admin/admin to authenticate**.  
    The module is added to the project just to show the simplicity of adding next modules into project, both middlewares and endpoints.

All required configuration has been added to appsettings.json file.  
The application does not require any third party services or databases.
To disable authentication, simple remove/comment out  
`services.AddModule<AuthorizationModule>((IConfigurationRoot)Configuration);`  
in `Startup.cs`.  
Docker support has been added to the project. 
