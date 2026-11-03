using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    [SerializeField]
    private bool useAttachedCharacter = false;

    [SerializeField]
    protected CharacterBase character;

    protected virtual void Awake()
    {

    }

    protected virtual void Start()
    {
        if(useAttachedCharacter && character==null)
            Attach(this.GetComponent<CharacterBase>());
    }

    public void Attach(CharacterBase character)
    { 
        this.character = character;
    }
}
