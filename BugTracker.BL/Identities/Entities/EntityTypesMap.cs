using System;
using System.Collections.Generic;
using BugTracker.BL.Domain.Model;
using BugTracker.BL.Identities.Entities.EntityTypes;

namespace BugTracker.BL.Identities.Entities
{
    public static class EntityTypesExtensions
    {
        private static readonly IReadOnlyDictionary<Type, IEntityType> EntityTypeMap;

        static EntityTypesExtensions()
        {
            EntityTypeMap = new Dictionary<Type, IEntityType>
            {
                {typeof(Issue), EntityTypeIssue.Instance}
            };
        }

        public static IEntityType GetEntityId(this Type entityType)
        {
            if (!EntityTypeMap.TryGetValue(entityType, out var entityTypeIdentity))
                throw new NotSupportedException($"Entity name for {entityType} is not supported");

            return entityTypeIdentity;
        }
    }
}