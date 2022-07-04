namespace kidsffw.Domain.Entities;

public record class ReferenceCoupon(
    int Id,
    string CouponCode,
    DateTime ExpirationDate,
    DateTime CreatedDate,
    bool IsActive, 
    decimal PercentageDiscount,
    SalesPartner PartnerDetails
);
