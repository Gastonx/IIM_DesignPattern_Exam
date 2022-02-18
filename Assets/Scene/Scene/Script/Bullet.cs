using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed;
    [SerializeField] float _collisionCooldown = 0.5f;

    public UnityEvent Particle;

   

    public Vector3 Direction { get; private set; }
    public int Power { get; private set; }
    float LaunchTime { get; set; }

    internal Bullet Init(Vector3 vector3, int power)
    {
        Direction = vector3;
        Power = power;
        LaunchTime = Time.fixedTime;
        return this;
    }

    void FixedUpdate()
    {
        _rb.MovePosition((transform.position + (Direction.normalized * _speed)));
    }
    
    void LateUpdate()
    {
        transform.rotation = EntityRotation.AimPositionToZRotation(transform.position, transform.position + Direction);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Particle.Invoke();
        if (Time.fixedTime < LaunchTime + _collisionCooldown) return;
        var health = collision.GetComponent<IHealth>(); 
        var touch = collision.GetComponent<ITouchable>(); 
        if (health != null)
        {
            collision.GetComponent<IHealth>()?.TakeDamage(Power);
        }
        else if(touch != null)
        {
            collision.GetComponent<ITouchable>()?.Touch(Power);
        }


        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Particle.Invoke();
        var health = collision.collider.GetComponent<IHealth>();
        var touch = collision.collider.GetComponent<ITouchable>();
        if (health != null)
        {
            collision.collider.GetComponent<IHealth>()?.TakeDamage(Power);
        }
        else if (touch != null)
        {
            collision.collider.GetComponent<ITouchable>()?.Touch(Power);
        }
        Destroy(gameObject);
    }

    private void Health_OnDamage(int arg0)
    {
        throw new NotImplementedException();
    }
}
