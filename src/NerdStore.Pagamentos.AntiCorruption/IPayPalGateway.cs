namespace NerdStore.Pagamentos.AntiCorruption
{
    public interface IPayPalGateway
    {
        string GetPayPalServiceKey(string apiKey, string encriptionKey);
        string GetCardHashKey(string serviceKey, string cartaoCredito);
        bool CommitTransaction(string orderId, decimal amount);
    }
}
