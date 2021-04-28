using Foundation.Movement;

namespace Foundation.Character.StateMachine
{
    public interface IStateMachine: IStateChangedEventProvider, IPlayerMovementInputHandler
    {
        IState CurrentState { get; }
    }
}
