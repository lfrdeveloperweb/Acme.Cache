namespace Acme.Core.Models
{
    /// <summary>
    /// Model that contains information about the merchant.
    /// </summary>
    public class Merchant
    {
        public Merchant(string id, string fantasyName)
        {
            Id = id;
            FantasyName = fantasyName;
        }

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
