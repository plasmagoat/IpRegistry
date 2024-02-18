using Danelec.IpRegistry.Core.Interfaces;
using Danelec.IpRegistry.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Danelec.IpRegistry.Infrastructure.Data;

public class IpRegistry : IIpRegistry
{
    private readonly IpRegistryContext _context;

    public IpRegistry(IpRegistryContext context)
    {
        _context = context;
    }

    public Task<IpRegistration?> GetAsync(string ip)
    {
        return _context.IpRegistrations.SingleOrDefaultAsync(reg => reg.Ip == ip);
    }

    public async Task<IpRegistration> AddAsync(IpRegistration item)
    {
        var result = await _context.IpRegistrations.AddAsync(item);
        await _context.SaveChangesAsync();
        return result.Entity;
        // try
        // {
        //     await _context.SaveChangesAsync();
        //     return result.Entity;
        // }
        // catch (DbUpdateException e)
        //     when (e.InnerException?.InnerException is DbException dbException && 
        //           dbException.ErrorCode is 2601 or 2627)
        // {
        //     throw 
        // }
    }

    public async Task<IpRegistration> UpdateAsync(IpRegistration item)
    {
        var result = _context.IpRegistrations.Update(item);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task DeleteAsync(string ip)
    {
        var item = await GetAsync(ip);
        if(item == null) return;
        var result = _context.IpRegistrations.Remove(item);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<IpRegistration>> GetAllAsync()
    {
        return await _context.IpRegistrations.ToListAsync();
    }
}