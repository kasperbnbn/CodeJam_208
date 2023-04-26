using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public Vector2Int size;
    public Vector2 Offset;
    public GameObject PillPrefap;
    public Gradient gradient;
    // Start is called before the first frame update
    private void Awake()
    {
        for(int i = 0; i < size.x; i++)
        {
            for(int j = 0; j < size.y; j++)
            {
                GameObject NewPill = Instantiate(PillPrefap, transform);
                NewPill.transform.position = transform.position + new Vector3((float)((size.x - 1) * .5f - i) * Offset.x, j * Offset.y, 0);
                NewPill.GetComponent<SpriteRenderer>().color = gradient.Evaluate((float)j /(size.y-1));


            }
               

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
