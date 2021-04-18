using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Players.HAL2
{
    public class HAL2Base : MonoBehaviour
    {
        private HAL2Mover HAL2Mover;
        private HAL2Attacker HAL2Attacker;

        private void Start()
        {
            HAL2Mover = new HAL2Mover();
            HAL2Attacker = new HAL2Attacker();
        }

        private void Update()
        {
            
        }
    }
}