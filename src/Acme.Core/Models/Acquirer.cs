namespace Acme.Core.Models
{
    /// <summary>
    /// Model that contains information about the acquirer.
    /// </summary>
    public class Acquirer
    {
        public Acquirer(int id, string name)
        {
            Id = id;
            Name = name;
        }

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