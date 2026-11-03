using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent (typeof(UIDocument))]
public class GuiBase : MonoBehaviour
{
    private UIDocument document;

    private VisualElement root;

    protected virtual void Start()
    {
        document = this.GetComponent<UIDocument>();
        if (document == null)
            return;
        root = document.rootVisualElement;
    }

    public void Show()
    {
        this.gameObject.SetActive (true);
        if (root != null)
            root.style.display = DisplayStyle.Flex;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
        if (root != null)
            root.style.display = DisplayStyle.None;
    }
}
