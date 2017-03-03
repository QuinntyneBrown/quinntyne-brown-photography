namespace QuinntyneBrownPhotography.Features.Payments
{
    public interface IStripeConfiguration
    {
        string StripePublishableKey { get; }
        string StripeSecretKey { get; }
    }
}
