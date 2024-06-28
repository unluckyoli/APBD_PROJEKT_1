using Microsoft.EntityFrameworkCore;
using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.DTOs;
using System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Models;

namespace System_Uznawania_Przychodów_dla_dużej_korporacji_ABC.Services
{
    public class ClientService : IClientService
    {
        private readonly DatabaseContext _context;

        public ClientService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClientDTO>> GetAllClients()
        {
            var individualClients = await _context.IndividualClients.ToListAsync();
            var companyClients = await _context.CompanyClients.ToListAsync();

            var clients = new List<ClientDTO>();

            clients.AddRange(individualClients.Select(c => new IndividualClientDTO
            {
                Id = c.Id,
                Address = c.Address,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                FirstName = c.FirstName,
                LastName = c.LastName,
                PESEL = c.PESEL
            }));

            clients.AddRange(companyClients.Select(c => new CompanyClientDTO
            {
                Id = c.Id,
                Address = c.Address,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                CompanyName = c.CompanyName,
                KRS = c.KRS
            }));

            return clients;
        }

        public async Task<ClientDTO> GetClientById(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client is IndividualClient individualClient)
            {
                return new IndividualClientDTO
                {
                    Id = individualClient.Id,
                    Address = individualClient.Address,
                    Email = individualClient.Email,
                    PhoneNumber = individualClient.PhoneNumber,
                    FirstName = individualClient.FirstName,
                    LastName = individualClient.LastName,
                    PESEL = individualClient.PESEL
                };
            }
            if (client is CompanyClient companyClient)
            {
                return new CompanyClientDTO
                {
                    Id = companyClient.Id,
                    Address = companyClient.Address,
                    Email = companyClient.Email,
                    PhoneNumber = companyClient.PhoneNumber,
                    CompanyName = companyClient.CompanyName,
                    KRS = companyClient.KRS
                };
            }
            return null;
        }

        public async Task<ClientDTO> AddClient(ClientDTO clientDto)
        {
            Client client;
            if (clientDto is IndividualClientDTO individualClientDto)
            {
                client = new IndividualClient
                {
                    Address = individualClientDto.Address,
                    Email = individualClientDto.Email,
                    PhoneNumber = individualClientDto.PhoneNumber,
                    FirstName = individualClientDto.FirstName,
                    LastName = individualClientDto.LastName,
                    PESEL = individualClientDto.PESEL
                };
                _context.IndividualClients.Add((IndividualClient)client);
            }
            else if (clientDto is CompanyClientDTO companyClientDto)
            {
                client = new CompanyClient
                {
                    Address = companyClientDto.Address,
                    Email = companyClientDto.Email,
                    PhoneNumber = companyClientDto.PhoneNumber,
                    CompanyName = companyClientDto.CompanyName,
                    KRS = companyClientDto.KRS
                };
                _context.CompanyClients.Add((CompanyClient)client);
            }
            else
            {
                throw new ArgumentException("Invalid client type");
            }

            await _context.SaveChangesAsync();
            clientDto.Id = client.Id;
            return clientDto;
        }

        public async Task<ClientDTO> UpdateClient(int id, ClientDTO clientDto)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return null;
            }

            if (clientDto is IndividualClientDTO individualClientDto && client is IndividualClient individualClient)
            {
                individualClient.Address = individualClientDto.Address;
                individualClient.Email = individualClientDto.Email;
                individualClient.PhoneNumber = individualClientDto.PhoneNumber;
                individualClient.FirstName = individualClientDto.FirstName;
                individualClient.LastName = individualClientDto.LastName;
                individualClient.PESEL = individualClientDto.PESEL;
            }
            else if (clientDto is CompanyClientDTO companyClientDto && client is CompanyClient companyClient)
            {
                companyClient.Address = companyClientDto.Address;
                companyClient.Email = companyClientDto.Email;
                companyClient.PhoneNumber = companyClientDto.PhoneNumber;
                companyClient.CompanyName = companyClientDto.CompanyName;
                companyClient.KRS = companyClientDto.KRS;
            }
            else
            {
                throw new ArgumentException("Invalid client type or ID mismatch");
            }

            await _context.SaveChangesAsync();
            return clientDto;
        }

        public async Task<bool> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return false;
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
