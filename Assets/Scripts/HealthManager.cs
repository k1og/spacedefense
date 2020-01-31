using UnityEngine;

public class HealthManager : MonoBehaviour
{
    IExplodable explodable;
    public int hp = 100;
    private int HP
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
            }
        }
    }
    void Start()
    {
        explodable = GetComponent<IExplodable>();
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
