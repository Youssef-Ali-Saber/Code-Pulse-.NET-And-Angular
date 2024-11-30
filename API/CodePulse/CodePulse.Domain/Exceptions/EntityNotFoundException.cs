using CodePulse.Domain.Entities.Base;

namespace CodePulse.Domain.Exceptions;

public class EntityNotFoundException<T>(Guid id) : Exception($"{typeof(T).Name} with id {id} not found")
    where T : BaseEntity;