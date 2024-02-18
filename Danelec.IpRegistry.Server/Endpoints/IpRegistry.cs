using Danelec.IpRegistry.Core.Interfaces;
using Danelec.IpRegistry.Core.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Danelec.IpRegistry.Server.Endpoints;

public static class Endpoints
{
    public static IEndpointRouteBuilder MapIpRegistryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var ipRegistrations = endpoints.MapGroup("/ip-registry");

        ipRegistrations.MapGet("/list",
                async ([FromServices] IIpRegistry registry) => 
                TypedResults.Ok(await registry.GetAllAsync()))
            .WithName("Get IP Registry List")
            .WithOpenApi();

        ipRegistrations.MapGet("/{ip}",
            async Task<Results<Ok<IpRegistration>, NotFound>> (string ip, [FromServices] IIpRegistry registry) =>
            {
                var ipRegistration = await registry.GetAsync(ip);
                return ipRegistration != null ? TypedResults.Ok(ipRegistration) : TypedResults.NotFound();
            })
            .WithName("Get IP Registration")
            .WithOpenApi();

        ipRegistrations.MapPost("/",
                async ([FromBody] IpRegistration ipRegistration, [FromServices] IIpRegistry registry) =>
                TypedResults.Ok(await registry.AddAsync(ipRegistration)))
            .WithName("Add IP Registration")
            .WithOpenApi();
        
        ipRegistrations.MapPut("/",
                async ([FromBody] IpRegistration ipRegistration, [FromServices] IIpRegistry registry) =>
                TypedResults.Ok(await registry.UpdateAsync(ipRegistration)))
            .WithName("Update IP Registration")
            .WithOpenApi();
        
        ipRegistrations.MapDelete("/{ip}",
                async (string ip, [FromServices] IIpRegistry registry) =>
                await registry.DeleteAsync(ip))
            .WithName("Delete IP Registration")
            .WithOpenApi();
        
        return endpoints;
    }
}