using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace CodeDesignPlus.Event.Bus.Abstractions
{
    /// <summary>
    /// EventBase is used to create the events that will be published to the message broker
    /// </summary>
    public abstract class EventBase: IEquatable<EventBase>
    {
        /// <summary>
        /// Initializes a new instance of the CodeDesignPlus.Event.Bus.Abstractions.EventBase class
        /// </summary>
        protected EventBase()
        {
            this.IdEvent = Guid.NewGuid();
            this.EventDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Initializes a new instance of the CodeDesignPlus.Event.Bus.Abstractions.EventBase class with a specified idEvent and createDate
        /// </summary>
        /// <param name="idEvent">Id Event</param>
        /// <param name="eventDate">Date the event was generated</param>
        /// <exception cref="ArgumentOutOfRangeException">The assigned date is invalid</exception>
        [JsonConstructor]
        protected EventBase(Guid idEvent, DateTime eventDate)
        {
            if (eventDate == DateTime.MinValue)
                throw new ArgumentOutOfRangeException(nameof(eventDate));

            this.IdEvent = idEvent;
            this.EventDate = eventDate;
        }

        /// <summary>
        /// Gets the id event
        /// </summary>
        [JsonProperty]
        public Guid IdEvent { get; private set; }
        /// <summary>
        /// Gets the event date
        /// </summary>
        [JsonProperty]
        public DateTime EventDate { get; private set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns> true if the current object is equal to the other parameter; otherwise, false.</returns>
        public virtual bool Equals([AllowNull] EventBase other)
        {
            return this.IdEvent == other.IdEvent;
        }
    }
}
