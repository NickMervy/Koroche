using System.Runtime.CompilerServices;
using Contexts;
using strange.extensions.context.impl;
using UnityEngine;

namespace View
{ 
    public class GameRoot : ContextView
    {
        protected void Awake()
        {
            context = new GameContext(this, true);
            context.Start();
        }
    }
}
