using System;

namespace BugTracker.BL.Identities
{
    public abstract class IdentityBase<TConcreteIdentity>
        where TConcreteIdentity : IdentityBase<TConcreteIdentity>, new()
    {
        private static readonly Lazy<TConcreteIdentity> SingleInstance =
            new Lazy<TConcreteIdentity>(() => new TConcreteIdentity());

        public abstract int Id { get; }

        public static TConcreteIdentity Instance => SingleInstance.Value;
    }
}