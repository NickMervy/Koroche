using Contexts;
using strange.extensions.context.impl;
using Services;
using UnityEngine;

namespace View
{
    public class DesertUonaRoot : ContextView
    {
        protected void Awake()
        {
            context = new DesertUonaContext(this, true);
            context.Start();
        }
    }
}
