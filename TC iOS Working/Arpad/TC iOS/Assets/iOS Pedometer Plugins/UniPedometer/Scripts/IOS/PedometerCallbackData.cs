using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UniPedometer.IOS {
	public class PedometerCallbackData {
		public long callbackId;
		public List<CMPedometerData> data;
		public List<NSError> nsError;
	}
}