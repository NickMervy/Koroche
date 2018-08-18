using Signals;
using UnityEngine;

namespace Contexts
{
    public class UIContext : SignalContext
    {
        public UIContext() : base() { }
        public UIContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            commandBinder.Bind<StartSignal>()
                .Once();
        }
    }
}