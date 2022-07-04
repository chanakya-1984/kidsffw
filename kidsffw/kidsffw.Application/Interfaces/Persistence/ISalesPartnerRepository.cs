using kidsffw.Domain.Entities;

namespace kidsffw.Application.Interfaces.Persistence;

public interface ISalesPartnerRepository
{
    public Task<SalesPartner> GetSalesPartnerByIdAsync(int id);
    public Task<SalesPartner> AddSalesPartnerAsync(SalesPartner salesPartner);
    public Task<SalesPartner> GetSalesPartnerByPhoneAsync(string phone);
}