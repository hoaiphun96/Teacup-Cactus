using UnityEngine;
using System.Collections;
using System;

public class IShakeCallback :  AndroidJavaProxy {	

	public Action <int,float>OnShake;
	
	public IShakeCallback() : base("com.gigadrillgames.androidsensor.shake.IShakeCallback") {}

	
	void onShake(int count,float speed){
		OnShake(count,speed);
	}
}
