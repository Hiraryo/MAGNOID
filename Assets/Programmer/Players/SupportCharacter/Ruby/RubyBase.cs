using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Players.SupportCharacter.Ruby
{
    public abstract class Ruby : MonoBehaviour
    {
        private RubyMover rubyMover;
        private RubyAttacker rubyAttacker;

        private void Start()
        {
            rubyMover = new RubyMover();
            rubyAttacker = new RubyAttacker();
        }

        private void Update()
        {
            
        }
    }
}

