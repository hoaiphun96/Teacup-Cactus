using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

namespace UniPedometer.IOS {
	public class NativeBridge {
		[DllImport("__Internal")]
		public static extern void queryPedometerDataFromDate(int fromDate, int toDate, long callbackId);

		[DllImport("__Internal")]
		public static extern void startPedometerUpdatesFromDate (int fromDate);

		[DllImport("__Internal")]
		public static extern void stopPedometerUpdates();

		[DllImport("__Internal")]
		public static extern bool isStepCountingAvailable ();

		[DllImport("__Internal")]
		public static extern bool isDistanceAvailable ();

		[DllImport("__Internal")]
		public static extern bool isFloorCountingAvailable ();

		[DllImport("__Internal")]
		public static extern bool isPaceAvailable ();

		[DllImport("__Internal")]
		public static extern bool isCadenceAvailable ();
	}
}
