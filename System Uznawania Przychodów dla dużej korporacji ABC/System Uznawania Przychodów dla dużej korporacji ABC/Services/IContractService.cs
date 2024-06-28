using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

public interface IContractService
{
    Task<IEnumerable<SoftwareContract>> GetAllContracts();
    Task<SoftwareContract> GetContractById(int id);
    Task<SoftwareContract> AddContract(SoftwareContract contract);
    Task<SoftwareContract> UpdateContract(SoftwareContract contract);
    Task<bool> DeleteContract(int id);
    Task<decimal> CalculateCurrentRevenue();
    Task<decimal> CalculateExpectedRevenue();
    Task<decimal> CalculateRevenueForProduct(int productId);
    Task<decimal> CalculateExpectedRevenueForProduct(int productId);
}
