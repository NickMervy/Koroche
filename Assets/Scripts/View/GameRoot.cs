using System.Runtime.CompilerServices;
using Contexts;
using strange.extensions.context.impl;

namespace View
{ 
    public class GameRoot : ContextView
    {
        protected override void Awake()
        {
            base.Awake();
            context = new GameContext(this, true);
            context.Start();
        }
    }
}
