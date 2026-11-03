using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class GuiFacade : FacadeBase<GuiController>
{
    public void Show<TGui>() where TGui : GuiBase
    {
        subsystem?.Show<TGui>();
    }

    public void Return()
    {
        subsystem?.Return();
    }
}
