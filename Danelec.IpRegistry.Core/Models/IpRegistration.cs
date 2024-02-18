namespace Danelec.IpRegistry.Core.Models;

public record IpRegistration
{
    public string Id { get; init; } = Guid.NewGuid().ToString();
    public string Ip { get; init; }
    public string Name { get; init; }
};