using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Players.GoldHAL2
{
    public abstract class GoldHAL2Base : MonoBehaviour
    {
        private GoldHAL2Mover goldHAL2Mover;
        private GoldHAL2Attacker goldHAL2Attacker;

        private void Start()
        {
            goldHAL2Mover = new GoldHAL2Mover();
            goldHAL2Attacker = new GoldHAL2Attacker();
        }

        private void Update()
        {
            
        }
    }
}