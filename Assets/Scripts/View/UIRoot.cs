using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class UIRoot : ContextView
    {
        protected void Awake()
        {
            context = new UIContext(this, true);
            context.Start();
        }
    }
}