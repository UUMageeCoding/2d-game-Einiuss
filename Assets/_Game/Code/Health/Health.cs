using UnityEngine;
using System.Collections;


public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    //iframe settings
    [SerializeField] private float iFrameDuration;
    [SerializeField] private float numberOfFlashes;
    private SpriteRenderer spriteRend;

    [SerializeField] private Behaviour[] components;
    private bool invulnerable;
    private UIManager uiManager;

    private void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
        uiManager = FindObjectOfType<UIManager>();
    }



    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHealth);
        //+1 health
    }



    public void TakeDamage(float _damage)

    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        //-1 health

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            //animation and flashes for damage
        }

        else
        {
            if (!dead)
            {

                anim.SetTrigger("die");
                GetComponent<PlatformerController>().enabled = false;
                dead = true;
                //death animation and player movement is disabled
            }

        }

    }


    private IEnumerator Invunerability()

    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, .8f);
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFrameDuration / (numberOfFlashes * 2));
            //flash player red and white
        }
        Physics2D.IgnoreLayerCollision(8, 9, false);
        //ignores the enemy layer
    }
public void CheckHealth()
    {
        if (currentHealth == 0)
        {
            uiManager.GameOver();
            return;
            //if player is dead game over screen will play
        }

    }

    /* private void Update()
     {
         if (Input.GetKeyDown(KeyCode.E))
             TakeDamage(1);
     } */
}
