using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerController : Controller
{
    [SerializeField]
    public IInputActionCollection2 InputAsset;

    public abstract void SetupControls(IInputActionCollection2 inputAsset);

    protected override void Awake()
    {
        base.Awake();
        InputAsset = new PlayerInputSystem();
    }

    protected virtual void OnEnable()
    {
        InputAsset.Enable();
    }

    protected virtual void OnDisable()
    {
        InputAsset.Disable();
    }

    protected override void Start()
    {
        base.Start();
        SetupControls(InputAsset);
    }
}
