public abstract class State
{
    protected EnemyState enemyState;

    public abstract void Tick();

    public virtual void OnStateEnter() { }
    public virtual void OnStateExit() { }

    public State(EnemyState enemyState)
    {
        this.enemyState = enemyState;
    }
}
