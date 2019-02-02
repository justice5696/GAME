using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private State currentState;

    public State getState()
    {
      return currentState;
    }

    private void Start()
    {
        SetState(new LootState(this));
    }

    private void Update()
    {
        currentState.Tick();
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;
        Debug.Log("EnemyState - " + state.GetType().Name);

        if (currentState != null)
            currentState.OnStateEnter();
    }
}
