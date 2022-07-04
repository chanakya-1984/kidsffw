namespace kidsffw.Application.Services.SalesPartner;
using Domain.Entities;

public interface ISalesPartnerService
{
    public Task<SalesPartner> GetSalesPartnerByIdAsync(int salesPartnerId);
    public Task<SalesPartner> GetSalesPartnerByPhoneAsync(string email);
    public Task<SalesPartner> AddSalesPartnerAsync(SalesPartner salesPartner);
}