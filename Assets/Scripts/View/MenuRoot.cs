using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class MenuRoot : ContextView
    {
        protected override void Awake()
        {
            base.Awake();
            context = new MenuContext(this, true);
            context.Start();
        }
    }
}