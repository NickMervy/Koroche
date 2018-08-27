using Controllers;
using Signals;
using UnityEngine;
using View;

namespace Contexts
{
    public class MenuContext : SignalContext
    {
        public MenuContext() : base() { }
        public MenuContext(MonoBehaviour view, bool autoStartup) : base(view, autoStartup) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            #region CommandBinder
            commandBinder.Bind<StartSignal>()
                .Once();
            commandBinder.Bind<NewGameButtonClickSignal>()
                .To<DispatchNewGameSignalCommand>();
            commandBinder.Bind<ContinueButtonClickSignal>()
                .To<DispatchContinueSignalCommand>();
            commandBinder.Bind<AppExitSignal>()
                .To<AppExitCommand>();
            #endregion

            #region MediationBinder
            mediationBinder.Bind<MenuView>().To<MenuMediator>();
            #endregion
        }
    }
}