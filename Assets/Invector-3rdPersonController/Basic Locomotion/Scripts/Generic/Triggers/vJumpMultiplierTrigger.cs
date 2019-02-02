﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Invector.vCharacterController
{
    public class vJumpMultiplierTrigger : MonoBehaviour
    {
        public float multiplier = 5;
        public float timeToReset = 0.5f;
        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                var motor = other.GetComponent<vThirdPersonController>();

                if (motor && (motor.isJumping || !motor.isGrounded))
                {
                    motor.SetJumpMultiplier(multiplier, timeToReset);
                    motor.isJumping = false;
                    motor.isGrounded = true;
                    motor.Jump();
                }
            }
        }
    }
}

