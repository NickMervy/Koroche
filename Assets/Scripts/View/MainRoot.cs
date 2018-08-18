using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class MainRoot : ContextView
    {
        protected override void Awake()
        {
            base.Awake();
            context = new MainContext(this, true);
            context.Start();
        }
    }
}