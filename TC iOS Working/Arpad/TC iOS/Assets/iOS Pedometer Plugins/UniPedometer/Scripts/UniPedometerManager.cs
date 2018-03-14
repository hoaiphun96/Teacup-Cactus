using UnityEngine;
using UniPedometer.IOS;

namespace UniPedometer {
	public class UniPedometerManager : MonoBehaviour {
		protected static UniPedometerManager soleInstance;
		IOSInterface ios;

		public static UniPedometerManager Instance {
			get {
				if(soleInstance != null)
					return soleInstance;

				soleInstance = UnityEngine.Object.FindObjectOfType<UniPedometerManager> ();
				if (soleInstance != null)
					return soleInstance;

				var go = new GameObject("UniPedometerManager", typeof(UniPedometerManager));
				soleInstance = go.GetComponent<UniPedometerManager>();
				return soleInstance;
			}
		}

		/// <summary>
		/// Property to access iOS pedometer functionality.
		/// </summary>
		public static IOSInterface IOS {
			get {
				return Instance.ios;
			}
		}

		protected void Awake() {
			if(soleInstance == null || soleInstance == this) {
				soleInstance = this;
				DontDestroyOnLoad(gameObject);

				Init();
			}
			else {
				DestroyImmediate(this);
			}
		}

		void Init () {
			ios = new IOSInterface ();
		}

		/// Called from native
		protected void QueryPedometerDataFromDateCallback(string json) {
			ios.QueryPedometerDataFromDateCallback (json);
		}

		/// Called from native
		protected void StartPedometerUpdatesFromDateCallback(string json) {
			ios.StartPedometerUpdatesFromDateCallback (json);
		}
	}
}
