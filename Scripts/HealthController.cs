using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    [Range(0.1f, 10f)]
    public int hp = 0;
    public int maxHp = 0;
    void Awake()
    {
        maxHp = hp;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
            if (gameObject.tag.Equals("Player"))
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }
    }
    public void setMaxHp(int maxHp)
    {
        this.maxHp = maxHp;








    }
}   
