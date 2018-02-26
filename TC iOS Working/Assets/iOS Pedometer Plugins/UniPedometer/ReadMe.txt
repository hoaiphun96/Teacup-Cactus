
UniPedometer is a plugin which wraps iOS CMPedometer functionality.
UniPedometer provides almost the same interface as the CMPedometer.


-----------
Sample Code
-----------

Here is a sample code of UniPedometer corresponding to each function of CMPedometer below.

<---

// check step counting available
bool stepCountingAvailable = UniPedometerManager.IOS.IsStepCountingAvailable;

// check distance available
bool distanceAvailable = UniPedometerManager.IOS.IsDistanceAvailable;

// check pace available
bool paceAvailable = UniPedometerManager.IOS.IsPaceAvailable;

// check floor counting available
bool floorCountingAvailable = UniPedometerManager.IOS.IsFloorCountingAvailable;

// check cadence available
bool cadenceAvailable = UniPedometerManager.IOS.IsCadenceAvailable;

// fetching historical pedometer data
UniPedometerManager.IOS.QueryPedometerDataFromDate (
	DateTime.Now - TimeSpan.FromHours (3),
	DateTime.Now,
	(CMPedometerData data, NSError error) => {
		if(error != null)
			Debug.Log(error.LocalizedDescription);
		else
			Debug.Log(data.NumberOfSteps);
	});

// generating live pedometer data
UniPedometerManager.IOS.StartPedometerUpdatesFromDate (
	DateTime.Now - TimeSpan.FromHours (3),
	(CMPedometerData data, NSError error) => {
		if(error != null)
			Debug.Log(error.LocalizedDescription);
		else
			Debug.Log(data.NumberOfSteps);
	});

// stop live pedometer data generation
UniPedometerManager.IOS.StopPedometerUpdates ();

--->


We recommend to see the document of CMPedometer (https://developer.apple.com/library/prerelease/ios/documentation/CoreMotion/Reference/CMPedometer_class/index.html)
and sample scenes we provide.


--------------------------------
Limitaions of Evaluation Version
--------------------------------

- QueryPedometerDataFromDate() and StartPedometerUpdatesFromDate() cannot be called more than 3 times
- The callback of StartPedometerUpdatesFromDate() notifies step counts up to 100 steps






If you have any questions or requests, please contact us.
(mari.ika.entertainment@gmail.com)