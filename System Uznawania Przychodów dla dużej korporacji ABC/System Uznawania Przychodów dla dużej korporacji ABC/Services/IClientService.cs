using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.DTOs;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetAllClients();
        Task<ClientDTO> GetClientById(int id);
        Task<ClientDTO> AddClient(ClientDTO clientDto);
        Task<ClientDTO> UpdateClient(int id, ClientDTO clientDto);
        Task<bool> DeleteClient(int id);
    }
}

