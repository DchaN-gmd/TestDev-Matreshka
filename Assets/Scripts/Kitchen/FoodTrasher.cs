using System;

using UnityEngine;

using JetBrains.Annotations;

using UnityEngine.Events;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {

		FoodPlace _place = null;
		float     _timer = 0f;
		int       _tapCount=0;
		float     _maxTimeBetweenTap = 1f;
		
		void Start() {
			_place = GetComponent<FoodPlace>();
		}

		private void Update() {
			_timer += Time.deltaTime;
			if ( _timer > _maxTimeBetweenTap ) {
				_timer = 0f;
				_tapCount = 0;
				return;
			}
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			_timer = 0;
			_tapCount++;

			if (_tapCount > 1) {
				if ( !_place.IsCooking && !_place.IsFree ) {
					_place.FreePlace();
				}
				_tapCount = 0;
			}
		}
	}
}
