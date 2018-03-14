using UnityEngine;
using System.Collections;
using System;

namespace UniPedometer {
	public class Callback {
		bool continuous;
		Action<string> action;

		public Callback (bool continuous, Action<string> action) {
			this.continuous = continuous;
			this.action = action;
		}

		public bool Continuous {
			get {
				return continuous;
			}
		}

		public void Call(string json) {
			action (json);
		}
	}
}
