using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public List<GameObject> platform;
    public int noOfPlatforms =10;

    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    static int counter;
    int tempCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        counter = 1;
        for (int i =0; i < noOfPlatforms; i++)
        {
            GameObject temp = (GameObject)Instantiate(platformPrefab);
            temp.SetActive(false);
            platform.Add(temp);
        }
        platform[0].transform.position = new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY), -43.8f);
        platform[0].SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void CreateNextPlatforms(float currentPlatformPos)
    {
        int numbers = Random.Range(0,4);
        for (int i = 0; i <= numbers; i++)
        {
            if(counter < noOfPlatforms)
            {
                GameObject plat = platform[counter];
                if (!plat.activeInHierarchy)
                {
                    plat.transform.position = GetNewPosition();
                    plat.SetActive(true);
                    counter++;
                }
            }
            else
            {
                counter = 0;
            }
        }  
        //To deactivate the older platforms
        for(int i = 0; i < noOfPlatforms; i++)
        {
            GameObject plat = platform[i];
            if (plat.activeInHierarchy && plat.transform.position.y < currentPlatformPos-3)
            {
                plat.SetActive(false);
            }
        }

    }

    Vector3 GetNewPosition()
    {
        float xPos = Random.Range(-levelWidth, levelWidth);
        float zPos = -43.8f;
        float yPos = 0f;
        if (counter == 0)
        {
            yPos = Random.Range(minY, maxY) + platform[noOfPlatforms - 1].transform.position.y;
        }
        else
        {
            yPos = Random.Range(minY, maxY) + platform[counter - 1].transform.position.y;
        }
        Vector3 pos = new Vector3(xPos, yPos, zPos);
        return pos;
    }
}
