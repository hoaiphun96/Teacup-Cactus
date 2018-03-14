using UnityEngine;

namespace UniPedometer {
	[System.Serializable]
	public class NSError {
		[SerializeField] int code;
		[SerializeField] string domain;
		[SerializeField] string localizedDescription;
		[SerializeField] string localizedRecoverySuggestion;
		[SerializeField] string localizedFailureReason;

		public int Code {
			get {
				return code;
			}
		}

		public string Domain {
			get {
				return domain;
			}
		}

		public string LocalizedDescription {
			get {
				return localizedDescription;
			}
		}

		public string LocalizedRecoverySuggestion {
			get {
				return localizedRecoverySuggestion;
			}
		}

		public string LocalizedFailureReason {
			get {
				return localizedFailureReason;
			}
		}
	}
}
