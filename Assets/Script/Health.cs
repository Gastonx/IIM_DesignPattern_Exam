using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IHealth
{
    // Champs
    [SerializeField] int _startHealth;
    [SerializeField] int _maxHealth;
    
    [SerializeField] UnityEvent _onDeath;
    [SerializeField] EntityShield _shield;
    public string EntityName { get => entityName ; }
    public Slider HealthBar;

    public string entityName;

    // Propriétés
    public int CurrentHealth { get; private set; }
    public int MaxHealth => _maxHealth;
    public bool IsDead => CurrentHealth <= 0;

    // Events
    public event UnityAction OnSpawn;
    public event UnityAction<int> OnDamage;
    public event UnityAction OnDeath { add => _onDeath.AddListener(value); remove => _onDeath.RemoveListener(value); }
    public UnityEvent CameraShake;
    

    // Methods
    void Awake() => Init();

    void Init()
    {
        CurrentHealth = _startHealth;
        OnSpawn?.Invoke();
    }

    

    public void TakeDamage(int amount)
    {
        if (_shield == null || _shield.IsShield == false) 
        {
            if (amount < 0) throw new ArgumentException($"Argument amount {nameof(amount)} is negativ");

            var tmp = CurrentHealth;
            CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
            var delta = CurrentHealth - tmp;
            OnDamage?.Invoke(delta);
            if (entityName == "Player")
            {
                UpdateLife();//mise a jour de la barre de vie
                CameraShake?.Invoke(); // ScreenShake
                
            }
             

            
        }
        if (CurrentHealth <= 0)
        {
            _onDeath?.Invoke();
        }

    }

    private void UpdateLife()
    {
        HealthBar.value = (float)CurrentHealth / 10;
    }
    public void Heal() 
    {
        if (CurrentHealth < _maxHealth )
        {
            CurrentHealth++;
            if (entityName == "Player")
            {
                UpdateLife();//mise a jour de la barre de vie
            }
        }
    
    }

    

    [Button("test")]
    void MaFonction()
    {
        var enumerator = MesIntPrefere();

        while(enumerator.MoveNext())
        {
            Debug.Log(enumerator.Current);
        }
    }


    List<IEnumerator> _coroutines;

    IEnumerator<int> MesIntPrefere()
    {

        //

        var age = 12;

        yield return 12;


        //

        yield return 3712;

        age++;
        //

        yield return 0;



        //
        yield break;
    }





}
