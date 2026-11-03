using UnityEngine;

[System.Serializable]
public class VisualTrigger
{
    [SerializeField] private string name;
    [SerializeField] private AnimatorControllerParameterType type;

    // Proprietà con sintassi moderna (Expression-bodied)
    public string Name { get => name; set => name = value; }
    public AnimatorControllerParameterType Type { get => type; set => type = value; }

    // Memorizziamo l'ID numerico per prestazioni fulminee
    private int nameHash;
    private bool isInitialized;

    // Inizializzazione dell'Hash (da chiamare una volta nel Start del Controller)
    public void Initialize()
    {
        nameHash = Animator.StringToHash(name);
        isInitialized = true;
    }

    // Metodo pubblico. Passiamo l'animator e i valori in modo sicuro senza fare "boxing" di object
    public void Activate(Animator animator, float floatValue = 0f, int intValue = 0, bool boolValue = false)
    {
        if (animator == null) return;

        // Autocompila l'hash se ci si è dimenticati di inizializzarlo
        if (!isInitialized) Initialize();

        switch (type)
        {
            case AnimatorControllerParameterType.Trigger:
                animator.SetTrigger(nameHash);
                break;
            case AnimatorControllerParameterType.Bool:
                animator.SetBool(nameHash, boolValue);
                break;
            case AnimatorControllerParameterType.Int:
                animator.SetInteger(nameHash, intValue);
                break;
            case AnimatorControllerParameterType.Float:
                animator.SetFloat(nameHash, floatValue);
                break;
        }
    }
}