using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject SettingsPrefab;
    public void SwitchToSettings()
    {
        var go = Instantiate(SettingsPrefab, transform.parent);
        Destroy(this.gameObject);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName: "Demo");
    }

}