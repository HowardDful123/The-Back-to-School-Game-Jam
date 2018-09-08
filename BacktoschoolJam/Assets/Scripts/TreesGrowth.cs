using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TreesGrowth : MonoBehaviour {
    public Transform content;
    public Transform top;
    public float growSpeed;
    public WoodCarrier woodCarrier;
    public int damage;
    public Queue<GameObject> treeBodyQ;
    public GameObject woodPrefab;
    public float difficultyCheckpoint;
    public bool isDifficultyIncreased;
    public TextMeshProUGUI textDifficulty;
    public TextMeshProUGUI textCapacityFulled;
    public int globalHealth;

    private bool difficultyTextOn;
    private float difficultyTextTime;
    private float difficultyTime;
    private int plankCount;
    private float growthTime;
    private int childcount;

    void Start()
    {
        //woodCarrier.GetComponent<WoodCarrier>().plankNumber;
        treeBodyQ = new Queue<GameObject>();
        childcount = content.childCount;
        textDifficulty.GetComponent<TextMeshProUGUI>().enabled = false;
        textCapacityFulled.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    void Update()
    {
        growthTime += Time.deltaTime;
        difficultyTime += Time.deltaTime;
        childcount = content.childCount;
        if (difficultyTime >= difficultyCheckpoint)
        {
            globalHealth += 2;
            isDifficultyIncreased = true;
            foreach (Transform child in content.transform)
            {
                child.GetComponent<TreeBody>().IncreaseHealth();
            }
            top.GetComponent<TreeTop>().IncreaseHealth();
            difficultyTextOn = true;
            difficultyTime = 0;
            difficultyCheckpoint += 10;
        }

        if (difficultyTextOn)
        {
            difficultyTextTime += Time.deltaTime;
            textDifficulty.GetComponent<TextMeshProUGUI>().enabled = true;
            if (difficultyTextTime >= 1f)
            {
                difficultyTextTime = 0;
                textDifficulty.GetComponent<TextMeshProUGUI>().enabled = false;
                difficultyTextOn = false;
                isDifficultyIncreased = false;
            } 
        }


        if (childcount > 0)
        {
            if (top.position.y < (content.GetComponent<Transform>().GetChild(childcount - 1).position.y + 1f))
            {
                top.position = new Vector2(content.GetComponent<Transform>().GetChild(0).position.x, content.GetComponent<Transform>().GetChild(childcount - 1).position.y + 1.8f);
            }
        }



        if (growthTime >= growSpeed)
        {
            Add_button();
            growthTime = 0;
            if (childcount == 0)
            {
                Transform copy = Instantiate(woodPrefab.transform, new Vector2(0.54f, 0.4f), Quaternion.identity);
                treeBodyQ.Enqueue(copy.gameObject);
                copy.transform.parent = gameObject.transform;
            }
        }

        if (childcount != 0)
        {
            if (content.GetComponentInChildren<TreeBody>().isDestroyed == true)
            {
                Delete();
            }
        }

        if (woodCarrier.GetComponent<WoodCarrier>().plankNumber >= woodCarrier.GetComponent<WoodCarrier>().plankCapacity)
        {
            textCapacityFulled.GetComponent<TextMeshProUGUI>().enabled = true;
        }
        else
        {
            textCapacityFulled.GetComponent<TextMeshProUGUI>().enabled = false;
        }

    }

    public void Add_button()
    {
        if (childcount > 0)
        {
            Transform copy = Instantiate(woodPrefab.transform, new Vector2(content.GetComponent<Transform>().GetChild(0).position.x,
                                   content.GetComponent<Transform>().GetChild(0).position.y + content.GetComponent<Transform>().GetChild(childcount - 1).position.y), Quaternion.identity);
            treeBodyQ.Enqueue(copy.gameObject);
            copy.transform.parent = gameObject.transform;
            top.position = new Vector2(content.GetComponent<Transform>().GetChild(0).position.x, content.GetComponent<Transform>().GetChild(childcount - 1).position.y + 1.8f);
        }
        
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
