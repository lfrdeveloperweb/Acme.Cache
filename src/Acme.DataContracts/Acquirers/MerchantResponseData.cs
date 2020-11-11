namespace Acme.DataContracts.Acquirers
{
    /// <summary>
    /// Data contract that contains information about the acquirer.
    /// </summary>
    public sealed class AcquirerResponseData
    {
        /// <summary>
        /// Acquirer identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Acquirer name.
        /// </summary>
        public string Name { get; set; }
    }
}
