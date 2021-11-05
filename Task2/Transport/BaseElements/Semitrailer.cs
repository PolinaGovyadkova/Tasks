using CargoProduct.BaseCargo;
using CargoProduct.Interfaces;
using System;
using Transport.Intefaces;

namespace Transport.BaseElements
{
    /// <summary>
    /// Semitrailer
    /// </summary>
    /// <seealso cref="Transport.Intefaces.ISemitrailer" />
    public abstract class Semitrailer : ISemitrailer
    {
        /// <summary>
        /// The current cargo
        /// </summary>
        protected Cargo CurrentCargo;
        /// <summary>
        /// The base payload capacity
        /// </summary>
        private const int BasePayloadCapacity = 200;
        /// <summary>
        /// Gets or sets the payload capacity.
        /// </summary>
        /// <value>
        /// The payload capacity.
        /// </value>
        public double PayloadCapacity { get; set; }
        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        public double Volume { get; set; }
        /// <summary>
        /// Gets the free weight.
        /// </summary>
        /// <value>
        /// The free weight.
        /// </value>
        public double FreeWeight => PayloadCapacity - CurrentCargo?.PayloadCapacity ?? PayloadCapacity;
        /// <summary>
        /// Gets the free volume.
        /// </summary>
        /// <value>
        /// The free volume.
        /// </value>
        public double FreeVolume => Volume - CurrentCargo?.Volume ?? Volume;
        /// <summary>
        /// Gets the type product.
        /// </summary>
        /// <value>
        /// The type product.
        /// </value>
        public Type TypeProduct { get => Cargo.GetType(); }

        /// <summary>
        /// Gets or sets the cargo.
        /// </summary>
        /// <value>
        /// The cargo.
        /// </value>
        public Cargo Cargo
        {
            get => CurrentCargo;
            set => CurrentCargo = value;
        }

        /// <summary>
        /// Gets the total weight.
        /// </summary>
        /// <value>
        /// The total weight.
        /// </value>
        public double TotalWeight => BasePayloadCapacity + CurrentCargo?.PayloadCapacity ?? BasePayloadCapacity;

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
            {
                return false;
            }
            Semitrailer semitrailer = (Semitrailer)obj;
            return PayloadCapacity == semitrailer.PayloadCapacity && Volume == semitrailer.Volume && semitrailer.CurrentCargo == Cargo;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"Полуприцеп {GetType().Name} с грузоподъёмностью {PayloadCapacity} и вместимым объёмом {Volume}";

        /// <summary>
        /// Products the add.
        /// </summary>
        /// <param name="product">The product.</param>
        public void ProductAdd(ICargo product)
        {
            Cargo.Volume += product.Volume;
            Cargo.PayloadCapacity += product.PayloadCapacity;
        }
    }
}