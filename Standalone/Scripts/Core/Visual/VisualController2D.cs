using UnityEngine;

[RequireComponent (typeof(SpriteRenderer))]
public class VisualController2D : VisualController
{
    protected SpriteRenderer sprite;

    [SerializeField]
    private bool startFlipped;



    protected override void Start()
    {
        base.Start();
        animator = this.GetComponent<Animator> ();
        sprite = this.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Direction.x > 0.01f)
            Flip(true);
        else if (Direction.x < -0.01f)
            Flip(false);
    }

    public void Flip(bool value)
    {
        sprite.flipX = value;
    }
}
