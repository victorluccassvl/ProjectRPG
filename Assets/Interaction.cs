
public interface IInteractionReceiver { }
public interface IInteractionActivator { }
public interface IInteraction<A, B> where A : IInteractionActivator where B : IInteractionReceiver
{
    public void Perform(A activator, B receiver);
}