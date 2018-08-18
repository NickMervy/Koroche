using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class LoadingRoot : ContextView
    {
        protected override void Awake()
        {
            base.Awake();
            context = new LoadingContext(this, true);
            context.Start();
        }
    }
}