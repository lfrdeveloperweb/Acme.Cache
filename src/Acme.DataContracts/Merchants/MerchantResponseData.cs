namespace Acme.DataContracts.Merchants
{
    /// <summary>
    /// Data contract that contains information about the merchant.
    /// </summary>
    public sealed class MerchantResponseData
    {
        /// <summary>
        /// Merchant identifier.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Merchant fantasy name.
        /// </summary>
        public string FantasyName { get; set; }
    }
}
