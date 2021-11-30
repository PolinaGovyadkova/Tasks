namespace ClientServer
{
    /// <summary>
    /// Network
    /// </summary>
    public abstract class Network
    {
        /// <summary>
        /// The port
        /// </summary>
        protected const int Port = 8888;

        /// <summary>
        /// The server ip
        /// </summary>
        protected const string ServerIp = "127.0.0.1";

        /// <summary>
        /// Dispouses this instance.
        /// </summary>
        protected abstract void Dispouse();

        /// <summary>
        /// Sets the listener.
        /// </summary>
        /// <returns></returns>
        protected abstract bool SetListener();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $" Port: {Port}. ServerIp: {ServerIp}";

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj != null && obj.GetType() != GetType())
                return false;
            Network network = (Network)obj;
            return network != null;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode() => Port.GetHashCode() + ServerIp.GetHashCode();
    }
}