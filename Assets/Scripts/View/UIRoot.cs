using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class UIRoot : ContextView
    {
        protected override void Awake()
        {
            base.Awake();
            context = new UIContext(this, true);
            context.Start();
        }
    }
}