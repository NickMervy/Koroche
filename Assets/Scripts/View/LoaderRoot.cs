using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class LoaderRoot : ContextView
    {
        protected void Awake()
        {
            context = new LoaderContext(this, true);
            context.Start();
        }
    }
}