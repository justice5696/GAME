using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootState : State
{

    private CharacterStatus playerStatus;

    public LootState(EnemyState enemyState) : base(enemyState)
    {
      playerStatus = GameObject.FindWithTag("Player").GetComponent<CharacterStatus>();
    }

    public override void Tick()
    {
      int interval = 10; //this shoudl keep update running 30/10 = 3 times per second
      if (Time.frameCount % interval == 0)
      {
        if((playerStatus.getCharHealth() > 0) && playerStatus.getTrigger())//the hedge instance trigger is activated by the player )
        {
          Debug.Log("Player has triggered trigger, and we are setting enemyState to attacKState");
          enemyState.SetState(new AttackState(enemyState));
        }
      }
    }
}
