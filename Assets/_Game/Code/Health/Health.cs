using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;


    [SerializeField] private float iFrameDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        
    }

    public void TakeDamage(float _damage)

    { 
    currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
        }

        else 
        {
            if (!dead) 
            {
                anim.SetTrigger("die");
                GetComponent<PlatformerController>().enabled = false;
                dead = true;
            }
            
        }

    }


    private IEnumerator Invunerability() 
    
    {
        Physics2D.IgnoreLayerCollision(8,9,true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new color(1, 0, 0, .5f);
            yield return new WaitForSeconds(1);
            spriteRend.c
        }
    }

   /* private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            TakeDamage(1);
    } */
}
