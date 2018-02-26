using UnityEngine;
using System.Collections;
using System;

namespace UniPedometer
{
	
	[System.Serializable]
	public class CMPedometerData {
		[SerializeField] int startDate;
		[SerializeField] int endDate;
		[SerializeField] int numberOfSteps;
		[SerializeField] float distance;
		[SerializeField] bool hasCurrentPace;
		[SerializeField] float currentPace;
		[SerializeField] bool hasCurrentCadence;
		[SerializeField] float currentCadence;
		[SerializeField] bool hasFloorsAscended;
		[SerializeField] int floorsAscended;
		[SerializeField] bool hasFloorsDescended;
		[SerializeField] int floorsDescended;

		public static DateTime BaseDateTime {
			get {
				return new DateTime (1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			}
		}

		public DateTime StartDate {
			get {
				return BaseDateTime.AddSeconds (startDate).ToLocalTime();
			}
		}

		public DateTime EndDate {
			get {
				return BaseDateTime.AddSeconds (endDate).ToLocalTime();
			}
		}

		public int NumberOfSteps {
			get {
				return numberOfSteps;
			}
		}

		public float Distance {
			get {
				return distance;
			}
		}

		public bool HasCurrentPase {
			get {
				return hasCurrentPace;
			}
		}

		public float CurrentPace {
			get {
				return currentPace;
			}
		}

		public bool HasCurrentCadence {
			get {
				return hasCurrentCadence;
			}
		}

		public float CurrentCadence {
			get {
				return currentCadence;
			}
		}

		public bool HasFloorsAscended {
			get {
				return hasFloorsAscended;
			}
		}

		public int FloorsAscended {
			get {
				return floorsAscended;
			}
		}

		public bool HasFloorsDescended {
			get {
				return hasFloorsDescended;
			}
		}

		public int FloorsDescended {
			get {
				return floorsDescended;
			}
		}
	}

}