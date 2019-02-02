using UnityEngine;

public class AttackState : State
{
    public AttackState(EnemyState enemyState) : base(enemyState)
    {
    }

    public override void OnStateEnter()
    {
        Debug.Log("ATTACK STATE");
    }


    public override void Tick()
    {
    }
}
