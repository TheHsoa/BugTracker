namespace BugTracker.BL.Identities.Entities.EntityTypes
{
    public sealed class EntityTypeIssue : EntityTypeBase<EntityTypeIssue>
    {
        public override int Id => EntityTypeIds.Issue;
    }
}