using System;

namespace OfficeRent.Api.Database.Exceptions
{
	public class EntityNotFoundException<TId> : Exception
	{
		public Type EntityType { get; }

		public TId EntityId { get; }
		
		public EntityNotFoundException(Type entityType, TId entityId)
			: base($"Entity of type {entityType.Name} with id {entityId} not found.")
		{
			EntityType = entityType;
			EntityId = entityId;
		}
	}
}