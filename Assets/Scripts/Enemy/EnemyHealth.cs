using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int health;

    public bool isBoss;

    Animator anim;

    [SerializeField] GameObject textPrefab;

    Vector3 textPosition = new Vector3(0, 3.07f, 0);

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            health -= amount;
            CreateDamageText(amount);
            if (health <= 0)
            {
              //  anim.SetBool("isDead", true);
                if (isBoss)
                {
                    Boss.Death();
                    Destroy(gameObject, 1);
                }
            }
        }
    }

    void CreateDamageText(int amount)
    {
        GameObject text = Instantiate(textPrefab, transform.position + textPosition, Quaternion.identity, transform);
        text.GetComponent<TextMeshPro>().text = amount.ToString();
    }
}
