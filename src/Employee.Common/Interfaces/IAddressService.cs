using Employee.Common.Dtos;

namespace Employee.Common.Interfaces;

public interface IAddressService
{
    Task<int> CreateAddressAsync(AddressCreate addressCreate);
    Task UpdateAddressAsync(AddressUpdate addressCreate);
    Task DeleteAddressAsync(AddressDelete addressDelete);
    Task<AddressGet> GetAddressAsync(int id);
    Task<List<AddressGet>> GetAddressesAsync();
}
