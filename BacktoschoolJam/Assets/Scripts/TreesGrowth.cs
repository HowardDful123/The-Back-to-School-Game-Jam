using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesGrowth : MonoBehaviour {
    public Transform content;
    public float growSpeed;
    public WoodCarrier woodCarrier;
    public int damage;

    public Queue<GameObject> treeBodyQ;
    public GameObject woodPrefab;

    private int plankCount;
    private float growthTime;
    private int childcount;

    private void Start()
    {
        //woodCarrier.GetComponent<WoodCarrier>().plankNumber;
        treeBodyQ = new Queue<GameObject>();
    }

    void Update()
    {
        growthTime += Time.deltaTime;

        if (growthTime >= growSpeed)
        {
            Add_button();
            growthTime = 0;
        }

        if (childcount != 0)
        {
            if (content.GetComponentInChildren<TreeBody>().isDestroyed == true)
            {
                Delete();
            }
        }
        
    }

    public void Add_button()
    {
        childcount = content.childCount;
        Transform copy = Instantiate(woodPrefab.transform, new Vector2(content.GetComponent<Transform>().GetChild(childcount - 1).position.x,
                                      content.GetComponent<Transform>().GetChild(0).position.y + content.GetComponent<Transform>().GetChild(childcount-1).position.y), Quaternion.identity);
        treeBodyQ.Enqueue(copy.gameObject);
        copy.transform.parent = gameObject.transform;
    }

    private void Delete()
    {
        if (Mathf.Abs(content.GetComponentInChildren<Rigidbody2D>().velocity.y) < 0.5)
        {

            if (woodCarrier.GetComponent<WoodCarrier>().plankNumber < woodCarrier.GetComponent<WoodCarrier>().plankCapacity)
            {
                Destroy(GetComponent<Transform>().GetChild(0).gameObject);
                woodCarrier.GetComponent<WoodCarrier>().plankNumber++;
                woodCarrier.GetComponent<WoodCarrier>().AddPlank();
            }
            
        }

    }
}
