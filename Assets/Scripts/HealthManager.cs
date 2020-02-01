using UnityEngine;

public class HealthManager : MonoBehaviour
{
    IExplodable explodable;
    TextMesh textMesh;
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
        textMesh = GetComponent<TextMesh>();
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        if (meshRenderer != null)
        {
            meshRenderer.sortingOrder = 2;
        }
    }

    void Start()
    {
        if (textMesh != null)
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
