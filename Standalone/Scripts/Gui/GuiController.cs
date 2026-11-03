using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GuiController : MonoBehaviour, ISubsystem
{
    [SerializeField]
    private List<GuiBase> guis;

    private GuiBase CurrentGui;

    private List<GuiBase> PreviousGuis;

    public void Clear()
    {
        Start();
    }

    private void Start()
    {
        foreach(GuiBase gui in guis)
            gui.Hide();
        CurrentGui = null;
        PreviousGuis=new List<GuiBase> ();
    }

    public void Show<TGui>() where TGui : GuiBase
    {
        if (CurrentGui is TGui)
            return;
        if(CurrentGui != null)
        {
            CurrentGui.Hide();
            PreviousGuis.Add(CurrentGui);
        }
        CurrentGui=guis.FirstOrDefault((gui)=>gui is TGui);
        if(CurrentGui != null)
            CurrentGui.Show();
    }

    public void Return()
    {
        CurrentGui?.Hide();
        if(PreviousGuis.Count > 0 )
        {
            CurrentGui = PreviousGuis.Last();
            PreviousGuis.Remove(CurrentGui);
            CurrentGui.Show();
        }
    }

    public GuiBase GetCurrentGui()
    {
        return CurrentGui;
    }

}
