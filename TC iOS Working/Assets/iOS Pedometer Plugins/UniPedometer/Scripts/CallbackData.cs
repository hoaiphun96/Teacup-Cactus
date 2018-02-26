
namespace UniPedometer {
	struct CallbackData {
		public long callbackId;
		public string json;

		public CallbackData (long callbackId, string json)
		{
			this.callbackId = callbackId;
			this.json = json;
		}
	}
}