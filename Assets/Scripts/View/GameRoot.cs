using System.Runtime.CompilerServices;
using Contexts;
using strange.extensions.context.impl;

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
