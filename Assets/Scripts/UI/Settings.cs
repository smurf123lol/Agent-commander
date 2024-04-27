using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public GameObject MainMenuPrefab;
    public Slider volumeSlider;
    public Dropdown DevicesDropdown;

    private float mVolume;
    private string mInputDeviceID;
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            mVolume = PlayerPrefs.GetFloat("Volume");
            mInputDeviceID = PlayerPrefs.GetString("InputDeviceName");
        }
        volumeSlider.value = mVolume;
        volumeSlider.onValueChanged.AddListener((float value) => { mVolume = value; });
        var microphoneList = Microphone.devices.ToList();
        DevicesDropdown.AddOptions(microphoneList);
        int deviceidx = microphoneList.FindIndex(x => x == mInputDeviceID);
        DevicesDropdown.value = deviceidx;
        DevicesDropdown.onValueChanged.AddListener((int value) => {
            mInputDeviceID = DevicesDropdown.options[value].text;
        });
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("Volume", mVolume);
        PlayerPrefs.SetString("InputDeviceName", mInputDeviceID);
        Return();
    }
    public void Return()
    {
        var go = Instantiate(MainMenuPrefab, transform.parent);
        Destroy(this.gameObject);
    }
}
