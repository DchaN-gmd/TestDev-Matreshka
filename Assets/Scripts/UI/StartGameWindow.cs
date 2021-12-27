using UnityEngine;
using UnityEngine.UI;

using CookingPrototype.Controllers;

using TMPro;
namespace CookingPrototype.UI
{
	public sealed class StartGameWindow : MonoBehaviour
	{
		public TMP_Text GoalText = null;
		public Button PlayButton = null;

		void Init() {
			var gc = GameplayController.Instance;

			PlayButton.onClick.AddListener(gc.StartGame);
		}

		public void Show(){
			var gc = GameplayController.Instance;

			GoalText.text = gc.OrdersTarget.ToString();

			gameObject.SetActive(true);
		}

		public void Hide(){
			gameObject.SetActive(false);
		}
	}
}

