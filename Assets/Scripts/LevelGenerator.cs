using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public List<GameObject> platform;
    public int noOfPlatforms;

    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    static int counter;

    bool createPlatform = false;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        for (int i =0; i < noOfPlatforms; i++)
        {
            GameObject temp = (GameObject)Instantiate(platformPrefab);
            temp.SetActive(false);
            platform.Add(temp);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void CreateNextPlatforms()
    {
        int numbers = 1;
        for (int i = 0; i <= numbers; i++)
        {
            if(counter < noOfPlatforms)
            {
                //get random values of vector in above range
                Vector3 pos = new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY),-43.8f);
                GameObject plat = platform[counter];
                if (!plat.activeInHierarchy)
                {
                    print("Set to activee");
                    plat.transform.position = pos;
                    plat.SetActive(true);
                    //set the generated vector to the platform
                    counter++;
                }
            }
            else
            {
                counter = 0;
            }
        }  
    }
}
