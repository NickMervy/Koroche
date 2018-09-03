using System.Collections.Generic;
using Models;
using strange.extensions.signal.impl;

namespace Signals
{
    public class CharacterHealthUpdateSignal : Signal<int, ICharacterState> { }
}