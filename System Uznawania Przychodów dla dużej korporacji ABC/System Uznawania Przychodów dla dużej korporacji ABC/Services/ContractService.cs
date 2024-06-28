using Microsoft.EntityFrameworkCore;

using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

public class ContractService : IContractService
{
    private readonly DatabaseContext _context;

    public ContractService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SoftwareContract>> GetAllContracts()
    {
        return await _context.Contracts.ToListAsync();
    }

    public async Task<SoftwareContract> GetContractById(int id)
    {
        return await _context.Contracts.FindAsync(id);
    }

    public async Task<SoftwareContract> AddContract(SoftwareContract contract)
    {
        _context.Contracts.Add(contract);
        await _context.SaveChangesAsync();
        return contract;
    }

    public async Task<SoftwareContract> UpdateContract(SoftwareContract contract)
    {
        _context.Contracts.Update(contract);
        await _context.SaveChangesAsync();
        return contract;
    }

    public async Task<bool> DeleteContract(int id)
    {
        var contract = await _context.Contracts.FindAsync(id);
        if (contract == null)
        {
            return false;
        }

        _context.Contracts.Remove(contract);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<decimal> CalculateCurrentRevenue()
    {
        var contracts = await _context.Contracts
            .Where(c => c.IsPaid)
            .ToListAsync();

        return contracts.Sum(c => c.Price);
    }

    public async Task<decimal> CalculateExpectedRevenue()
    {
        var contracts = await _context.Contracts
            .Where(c => !c.IsPaid)
            .ToListAsync();

        return contracts.Sum(c => c.Price);
    }

    public async Task<decimal> CalculateRevenueForProduct(int productId)
    {
        var contracts = await _context.Contracts
            .Where(c => c.SoftwareId == productId && c.IsPaid)
            .ToListAsync();

        return contracts.Sum(c => c.Price);
    }

    public async Task<decimal> CalculateExpectedRevenueForProduct(int productId)
    {
        var contracts = await _context.Contracts
            .Where(c => c.SoftwareId == productId && !c.IsPaid)
            .ToListAsync();

        return contracts.Sum(c => c.Price);
    }

    
}
