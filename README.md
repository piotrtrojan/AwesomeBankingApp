# AwesomeBankingApp

The application has been devided into many projects:

* **AwesomeBankingApp.Bootstrap**  
    Contains bootstrap for Modules. It can help (in the future) easily add next modules, such as Currency handling, Authorization/Authentication. Splitting project in separate modules helps to organize the code, test modules independently or reuse some of them.
* **AwesomeBankingApp.Api**  
    Main API host, registers Modules (LoanWeb and LoanWebValidatior), configures .net core pipelines.
* **AwesomeBankingApp.Loan**  
    Module responsible for loans handling. Contains all business logic related to loans calculation.
* **AwesomeBankingApp.Loan.Tests**  
    Unit tests for services within AwesomeBankingApp.Loan.
* **AwesomeBankingApp.Loan.Web**  
    Module containing endpoints and contracts for Loan. It is registered in main API project. If contracts would be dependency of some other projects (e.g. API client) it should be split to separate project to export just them, not endpoints.
* **AwesomeBankingApp.Loan.Validator**  
    Module containing validator for contracts (http requests).

Application has no authentication/authorization mechanism implemented. If it would be required, it could be easly added as a next Module, registered by `AddModule<>()` call and added to pipeline.

All required configuration has been added to appsettings.json file.
