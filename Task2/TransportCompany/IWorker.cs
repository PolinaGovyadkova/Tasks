namespace TransportCompany
{
    /// <summary>
    /// IWorker
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }
        /// <summary>
        /// Gets or sets the surname.
        /// </summary>
        /// <value>
        /// The surname.
        /// </value>
        string Surname { get; set; }
    }
}