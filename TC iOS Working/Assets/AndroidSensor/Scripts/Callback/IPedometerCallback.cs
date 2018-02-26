using UnityEngine;
using System.Collections;
using System;

public class IPedometerCallback :  AndroidJavaProxy {

	public Action <int>OnLoadTotalStepCount;
	public Action <int>OnLoadTotalStepToday;
	public Action <int>OnLoadPrevStepCount;
	public Action <int>OnStepCount;
	public Action <int>OnStepCountToday;
	public Action OnStepDetect;
	
	public IPedometerCallback() : base("com.gigadrillgames.androidsensor.pedometer.IPedometerCallback") {}

	void onStepCount(int count){
		OnStepCount(count);
	}

	void onStepCountToday(int count){
		OnStepCountToday(count);
	}

	void onStepDetect(){
		OnStepDetect();
	}

	void onLoadTotalStepCount(int count){
		OnLoadTotalStepCount(count);
	}

	void onLoadTotalStepToday(int count){
		OnLoadTotalStepToday(count);
	}

	void onLoadPrevStepCount(int count){
		OnLoadPrevStepCount(count);
	}
}