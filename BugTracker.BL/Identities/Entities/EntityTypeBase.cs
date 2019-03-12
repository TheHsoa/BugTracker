namespace BugTracker.BL.Identities.Entities
{
    public abstract class EntityTypeBase<TConcreteIdentity> : IdentityBase<TConcreteIdentity>, IEntityType
        where TConcreteIdentity : IdentityBase<TConcreteIdentity>, new()
    {
    }
}