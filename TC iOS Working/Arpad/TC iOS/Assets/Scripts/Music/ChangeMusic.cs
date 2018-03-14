using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMusic : MonoBehaviour {
	public List<AudioClip> Songs = new List<AudioClip>();


	// Use this for initialization
	public void RightButtonClicked(){
		int index = PlayerPrefs.GetInt ("Song");
		if (index == Songs.Count - 1) {
			ChangeSong (0);
		} else {
			ChangeSong (index + 1);
		}
	}
	public void  LeftButtonClicked(){
		int index = PlayerPrefs.GetInt ("Song");
		if (index == 0) {
			ChangeSong (Songs.Count - 1);
		} else {
			ChangeSong (index - 1);
		}
	}
	public void ChangeSong(int index) {
		PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().clip = Songs[index] ;
		PlayerPrefs.SetInt ("Song", index);
		PlayMusic.Instance.gameObject.GetComponent<AudioSource> ().Play();

	}
	

}
