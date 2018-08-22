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
            injectionBinder.Bind<SetContinueButtonSignal>().ToSingleton();
            commandBinder.Bind<StartSignal>()
                .To<SetContinueButtonCommand>()
                .Once();
            commandBinder.Bind<NewGameButtonClickSignal>()
                .To<DispatchNewGameCommand>();
            commandBinder.Bind<AppExitSignal>()
                .To<AppExitCommand>();

            mediationBinder.Bind<MenuView>()
                .To<MenuViewMediator>();
        }
    }
}