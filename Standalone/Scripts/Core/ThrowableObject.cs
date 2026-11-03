using Band.Extensions;
using System;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody2D))]
public class ThrowableObject : MonoBehaviour, IThrowable, IPoolable
{
    [SerializeField]
    private float damage;

    [SerializeField]
    private LayerMask damageLayerMask;

    private Transform owner;

    private ObjectPool<ThrowableObject> pool;

    private BandTimer timer;

    private Rigidbody2D rigidBody;

    private void Awake()
    {
        timer=new BandTimer();
        timer.OnTimeout.AddListener(Release);

        rigidBody=this.GetComponent<Rigidbody2D>();
        Freeze();
    }

    public void SetPool(ObjectPool<ThrowableObject> pool)
    {
        this.pool = pool;
    }

    public void Throw(Vector3 direction)
    {
        if (rigidBody == null)
            rigidBody = this.GetComponent<Rigidbody2D>();
        Unfreeze();
        if (timer == null)
            timer = new BandTimer();
        timer.Start();
        rigidBody.AddForce(direction,ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<IDamageable>(out IDamageable damageable) && collision.gameObject.IsContainedLayer(damageLayerMask))
            damageable.TakeDamage(collision.gameObject,damage);
        Release();
    }

    private void Release()
    {
        if (pool != null)
            pool.Release(this);
    }

    public void Freeze()
    {
        if (rigidBody == null)
            rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Unfreeze()
    {
        if (rigidBody == null)
            rigidBody = this.GetComponent<Rigidbody2D>();
        rigidBody.constraints = RigidbodyConstraints2D.None;
    }
}
