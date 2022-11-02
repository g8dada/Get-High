using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneLevel1Map()
    {
        SceneManager.LoadScene("Level1Map");
    }
    public void LoadSceneLevel2Map()
    {
        SceneManager.LoadScene("Level2Map");
    }
    public void LoadSceneLevel13Map()
    {
        SceneManager.LoadScene("Level3Map");
    }
    public void LoadSceneLevel1()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadSceneLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void LoadSceneLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
