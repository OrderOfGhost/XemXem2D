using UnityEngine;

public interface IState
{
    public void OnEnter(StateController sc);

    public void OnUpdate(StateController sc);

    public void OnExit(StateController sc);
}
