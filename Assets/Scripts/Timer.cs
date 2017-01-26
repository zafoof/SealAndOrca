using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    Image timeImage;
    public float timeAmount;
    public float time;
    Text timeText;
    Text surviveText;
    LevelManager levelManager;

	// Use this for initialization
	void Start () {
        timeImage = GetComponent<Image>();
        time = timeAmount;
        timeText = GameObject.Find("TimerText").GetComponent<Text>();
        surviveText = GameObject.Find("Survive").GetComponent<Text>();
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        surviveText.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(time >= 0)
        {
            time -= Time.deltaTime;
            timeImage.fillAmount = time / timeAmount;
            timeText.text = "Time: " + time.ToString("F") + "  ";
        }
        else
        {
            surviveText.enabled = true;
            FishPowerup.kill = 0;
            levelManager.LoadNextLevel();
        }
	}
}
