using UnityEngine;
using System.Collections;
using UniPedometer.IOS;

namespace UniPedometer.IOS {
	public class PedometerAvailability {
		bool? isStepCountingAvailable;
		bool? isDistanceAvailable;
		bool? isFloorCountingAvailable;
		bool? isPaceAvailable;
		bool? isCadenceAvailable;


		public bool IsStepCountingAvailable {
			get {
				if (isStepCountingAvailable.HasValue)
					return isStepCountingAvailable.Value;

				isStepCountingAvailable = NativeBridge.isStepCountingAvailable ();
				return isStepCountingAvailable.Value;
			}
		}

		public bool IsDistanceAvailable {
			get {
				if (isDistanceAvailable.HasValue)
					return isDistanceAvailable.Value;

				isDistanceAvailable = NativeBridge.isDistanceAvailable ();
				return isDistanceAvailable.Value;
			}
		}

		public bool IsFloorCountingAvailable {
			get {
				if (isFloorCountingAvailable.HasValue)
					return isFloorCountingAvailable.Value;

				isFloorCountingAvailable = NativeBridge.isFloorCountingAvailable();
				return isFloorCountingAvailable.Value;
			}
		}

		public bool IsPaceAvailable {
			get {
				if (isPaceAvailable.HasValue)
					return isPaceAvailable.Value;

				isPaceAvailable = NativeBridge.isPaceAvailable ();
				return isPaceAvailable.Value;
			}
		}

		public bool IsCadenceAvailable {
			get {
				if(isCadenceAvailable.HasValue)
					return isCadenceAvailable.Value;

				isCadenceAvailable = NativeBridge.isCadenceAvailable ();
				return isCadenceAvailable.Value;
			}
		}
	}
}