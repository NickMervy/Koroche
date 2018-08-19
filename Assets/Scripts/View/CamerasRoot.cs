using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class CamerasRoot : ContextView
    {
        protected void Awake()
        {
            context = new CamerasContext(this, true);
            context.Start();
        }
    }
}