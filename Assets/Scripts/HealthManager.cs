using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    IExplodable explodable;
    TextMeshPro textMesh;
    [SerializeField]
    private int hp = 1;
    public int HP
    {
        get 
        {
            return hp;
        }
        set
        {
            if (value <= 0) 
            {
                if (explodable != null)
                {
                    explodable.Explode();
                }
                if (this.gameObject.transform.parent != null)
                {
                    if (this.gameObject.transform.parent.tag == "Pool")
                    {
                        this.gameObject.SetActive(false);
                    }
                    else
                    {
                        Destroy(this.gameObject);
                    }
                }
                else
                {
                    Destroy(this.gameObject);
                }
            } 
            else
            {
                hp = value;
                if (textMesh != null)
                {
                    textMesh.text = value.ToString();
                }
            }
        }
    }
    void Awake()
    {
        explodable = GetComponent<IExplodable>();
        textMesh = GetComponentInChildren<TextMeshPro>();
    }

    void Start()
    {
        // if (textMesh != null)
        {
            textMesh.text = hp.ToString();
        }
    }

    public void TakeDamage(int damage) 
    {
        HP -= damage;
    }

    public void Kill()
    {
        HP = 0;
    }
}
