using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class iOSNotification : MonoBehaviour {
	public static iOSNotification instance;
	public static iOSNotification Instance {
		get { return instance; }
	}

	bool isPaused = false;
	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad (this.gameObject);

		UnityEngine.iOS.NotificationServices.RegisterForNotifications(
			UnityEngine.iOS.NotificationType.Alert | 
			UnityEngine.iOS.NotificationType.Badge | 
			UnityEngine.iOS.NotificationType.Sound);
	}

	void Start()
	{

	}

	void OnGUI()
	{
		if (isPaused)
			GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
	}

	void OnApplicationFocus(bool hasFocus)
	{
		isPaused = !hasFocus;
	}

	void OnApplicationPause(bool pauseStatus)
	{
		isPaused = pauseStatus;
		// schedule notification to be delivered in 10 seconds
		var notif = new UnityEngine.iOS.LocalNotification();
		notif.fireDate = DateTime.Now.AddSeconds(10);
		notif.alertAction = "It's walking time";
		notif.alertBody = "Go find me a flower hooman!";
		notif.soundName = UnityEngine.iOS.LocalNotification.defaultSoundName;
		UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(notif);
	}

	void Update()
	{
		if (UnityEngine.iOS.NotificationServices.localNotificationCount > 0) {
			Debug.Log(UnityEngine.iOS.NotificationServices.localNotifications[0].alertBody);
			UnityEngine.iOS.NotificationServices.ClearLocalNotifications();
		}
	}
}
