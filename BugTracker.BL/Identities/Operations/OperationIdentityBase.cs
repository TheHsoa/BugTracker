namespace BugTracker.BL.Identities.Operations
{
    public abstract class OperationIdentityBase<TConcreteIdentity> : IdentityBase<TConcreteIdentity>
        where TConcreteIdentity : IdentityBase<TConcreteIdentity>, new()
    {
    }
}