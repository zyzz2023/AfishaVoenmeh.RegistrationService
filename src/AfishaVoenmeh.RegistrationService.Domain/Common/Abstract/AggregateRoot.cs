namespace AfishaVoenmeh.RegistrationService.Domain.Common.Abstract;

public class AggregateRoot<TId> : Entity<TId>
    where TId : notnull
{
    //private readonly List<DomainEvent> _domainEvents = new();
    //public ICollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    //protected void RaiseDomainEvent(DomainEvent domainEvent)
    //{
    //    _domainEvents.Add(domainEvent);
    //}

    //protected void RemoveDomainEvent(DomainEvent domainEvent)
    //{
    //    _domainEvents.Remove(domainEvent);
    //}

    //protected void ClearDomainEvents()
    //{
    //    _domainEvents.Clear();
    //}
}
