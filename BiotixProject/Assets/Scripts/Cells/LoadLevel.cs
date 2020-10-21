using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : GenericSingletonClass<LoadLevel>
{
    [SerializeField] List<GameObject> levelsPrefabs;
    public static int level = 0;
    private GameObject selectLevel;


    private void Start()
    {
        selectLevel = Instantiate(levelsPrefabs[level]);
    }
    public void LoadNextLevel()
    {
        level++;
        selectLevel = Instantiate(levelsPrefabs[level]);
        Reload();
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

  

}
