using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniPedometer.IOS {
	public class IOSInterface {
		protected static long callbackIdCounter;
		protected Action<CMPedometerData, NSError> pedometerUpdatesCallback;
		protected Dictionary<long, Action<CMPedometerData, NSError>> queryPedometerDataCallbackDict;
		protected PedometerAvailability availability;

		public IOSInterface() {
			queryPedometerDataCallbackDict = new Dictionary<long, Action<CMPedometerData, NSError>> ();
			availability = new PedometerAvailability ();
		}

		public bool IsStepCountingAvailable { get { return availability.IsStepCountingAvailable; } }
		public bool IsDistanceAvailable { get { return availability.IsDistanceAvailable; } }
		public bool IsPaceAvailable { get { return availability.IsPaceAvailable; } }
		public bool IsFloorCountingAvailable { get { return availability.IsFloorCountingAvailable; } }
		public bool IsCadenceAvailable { get { return availability.IsCadenceAvailable; } }

		public bool IsPedometerUpdatesStarted {
			get {
				return pedometerUpdatesCallback != null;
			}
		}

		/// <summary>
		/// Call native startPedometerUpdatesFromDate method.
		/// this method throws exception if given date is more than 7 days ago.
		/// </summary>
		public void StartPedometerUpdatesFromDate (DateTime start, Action<CMPedometerData, NSError> callback) {
			if (pedometerUpdatesCallback != null)
				throw new Exception ("pedometer updates already started");
			if (IsDateTooOld (start))
				throw new Exception ("cannot query data more than 7 days ago");
			
			pedometerUpdatesCallback = callback;

			int fromDateSec = (int)(start.ToUniversalTime() - CMPedometerData.BaseDateTime).TotalSeconds;
			NativeBridge.startPedometerUpdatesFromDate (fromDateSec);
		}

		/// <summary>
		/// Call native stopPedometerUpdates method.
		/// </summary>
		public void StopPedometerUpdates () {
			pedometerUpdatesCallback = null;
			NativeBridge.stopPedometerUpdates ();
		}

		/// <summary>
		/// Call native queryPedometerDataFromDate method.
		/// this method throws exception if given date is more than 7 days ago.
		/// </summary>
		public void QueryPedometerDataFromDate(DateTime fromDate, DateTime toDate, Action<CMPedometerData, NSError> callback) {
			var callbackId = AddQueryPedometerDataCallback (callback);
			if(IsDateTooOld(fromDate) || IsDateTooOld(toDate))
				throw new Exception ("cannot query data more than 7 days ago");

			int fromDateSec = (int)(fromDate.ToUniversalTime() - CMPedometerData.BaseDateTime).TotalSeconds;
			var toDateSec = (int)(toDate.ToUniversalTime() - CMPedometerData.BaseDateTime).TotalSeconds;
			NativeBridge.queryPedometerDataFromDate (
				fromDateSec,
				toDateSec,
				callbackId
			);
		}

		bool IsDateTooOld(DateTime date) {
			return (DateTime.Now - date).CompareTo(TimeSpan.FromDays(7)) > 0;
		}

		long AddQueryPedometerDataCallback(Action<CMPedometerData, NSError> callback) {
			var callbackId = callbackIdCounter++;
			queryPedometerDataCallbackDict [callbackId] = callback;
			return callbackId;
		}

		protected void CallbackQueryPedometerData(long callbackId, CMPedometerData data, NSError error) {
			var callback = queryPedometerDataCallbackDict [callbackId];
			queryPedometerDataCallbackDict.Remove (callbackId);
			callback (data, error);
		}

		/// Called from native
		internal void QueryPedometerDataFromDateCallback(string json) {
			var data = JsonUtility.FromJson<PedometerCallbackData> (json);
			var pedometerData = data.data.Count == 0 ? null : data.data [0];
			var error = data.nsError.Count == 0 ? null : data.nsError [0];
			CallbackQueryPedometerData (data.callbackId, pedometerData, error);
		}

		/// Called from native
		internal void StartPedometerUpdatesFromDateCallback(string json) {
			if (pedometerUpdatesCallback == null)
				return;

			var data = JsonUtility.FromJson<PedometerCallbackData> (json);
			var pedometerData = data.data.Count == 0 ? null : data.data [0];
			var error = data.nsError.Count == 0 ? null : data.nsError [0];
			pedometerUpdatesCallback (pedometerData, error);
		}
	}
}
