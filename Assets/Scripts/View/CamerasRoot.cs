using Contexts;
using strange.extensions.context.impl;

namespace View
{
    public class CamerasRoot : ContextView
    {
        protected override void Awake()
        {
            base.Awake();
            context = new CamerasContext(this, true);
            context.Start();
        }
    }
}