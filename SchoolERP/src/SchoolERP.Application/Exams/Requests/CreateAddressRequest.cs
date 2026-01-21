public sealed class CreateAddressRequest
{
    public string AddressLine { get; set; } = default!;
    public string City { get; set; } = default!;
    public string State { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string Pincode { get; set; } = default!;
}
