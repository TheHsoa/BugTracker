namespace BugTracker.BL.Validation.Abstract
{
    public interface ICommandValidator<in TCommand> where TCommand : class
    {
        void Validate(TCommand command);
    }
}
