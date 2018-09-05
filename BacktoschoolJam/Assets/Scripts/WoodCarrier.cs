using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodCarrier : MonoBehaviour {
    public GameObject plankPrefab;
    public Transform content;
    public Money moneyBoi;
    public int plankCapacity;
    public int plankNumber;

    private float stackingNumber = 0.22f;
    private int childcount;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<TextMesh>().text = "Capacity: " + plankNumber + " / " + plankCapacity;
    }

    public void AddPlank()
    {
        childcount = content.childCount;
        Transform copy = Instantiate(plankPrefab.transform, new Vector2(content.GetComponent<Transform>().GetChild(3).position.x,
                                    content.GetComponent<Transform>().GetChild(3).position.y + stackingNumber), Quaternion.identity );
        copy.transform.parent = gameObject.transform;

        stackingNumber += 0.22f;    
    }

    public void SellPlank()
    {
        stackingNumber = 0.22f;

        if (plankNumber != 0)
        {
            for (int i = 4; i <= childcount; i++)
            {
                Destroy(content.GetComponent<Transform>().GetChild(i).gameObject);
                moneyBoi.moneyValue++;
            }
            plankNumber = 0;
        }
        

    }

}
