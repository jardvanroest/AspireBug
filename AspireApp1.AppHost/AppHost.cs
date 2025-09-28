using Azure.Provisioning;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder
    .AddProject<Projects.AspireApp1_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder
    .AddBicepTemplate("frontDoor", "./bicep/frontDoor.bicep")
    .WithParameter("location", "Global")
    .WithParameter("webContainerHost", apiService.GetEndpoint("https"));

builder.AddAzureContainerAppEnvironment("cae");

builder.Build().Run();
