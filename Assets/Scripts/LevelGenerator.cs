using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platformPrefab;
    public List<GameObject> platform;
    int noOfPlatforms =50;

    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    static int counter;

    Camera mainCam;

    void Start()
    {
        mainCam = Camera.main;
        //Platform geneerate wrt the camera.............
        counter = 1;
        for (int i =0; i < noOfPlatforms; i++)
        {
            GameObject temp = (GameObject)Instantiate(platformPrefab);
            temp.SetActive(false);
            platform.Add(temp);
        }
        platform[0].transform.position = new Vector3(Random.Range(-levelWidth, levelWidth), Random.Range(minY, maxY), 0);
        platform[0].SetActive(true);
        CreateNextPlatforms(platform[0].transform.position.y);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void CreateNextPlatforms(float currentPlatformPos)
    {
        int numbers = Random.Range(1,4);
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
        /*To deactivate the older platforms*/
        for (int i = 0; i < noOfPlatforms; i++)
        {
            GameObject plat = platform[i];
            if (plat.activeInHierarchy && plat.transform.position.y < currentPlatformPos-10f)
            {
                plat.SetActive(false);
            }
        }
        Debug.Log(counter);
        
    }

    Vector3 GetNewPosition()
    {
        float xPos = Random.Range(-levelWidth, levelWidth);
        float zPos = 0f;
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
