using UnityEngine;
using System.Collections;

public enum SensorDelay{
	/** get sensor data as fast as possible */
	SENSOR_DELAY_FASTEST = 0,
	/** rate suitable for games */
	SENSOR_DELAY_GAME = 1,
	/** rate suitable for the user interface  */
	SENSOR_DELAY_UI = 2,
	/** rate (default) suitable for screen orientation changes */
	SENSOR_DELAY_NORMAL = 3
}
