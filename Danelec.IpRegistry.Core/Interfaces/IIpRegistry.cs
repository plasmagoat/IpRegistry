using Danelec.IpRegistry.Core.Models;

namespace Danelec.IpRegistry.Core.Interfaces;

public interface IIpRegistry
{
    Task<IpRegistration?> GetAsync(string ip);
    Task<IpRegistration> AddAsync(IpRegistration item);
    Task<IpRegistration> UpdateAsync(IpRegistration item);
    Task DeleteAsync(string ip);
    Task<IEnumerable<IpRegistration>> GetAllAsync();
}