using UnityEngine;

namespace Assets.Scripts.Brett
{
	[System.Serializable]
	public class GameRunningState : State
	{
		public override void OnEnter()
		{
            var gameEvent = Resources.Load<GameEvent>("Game Events/OnFadeIn");
            GameObject.Instantiate(Resources.Load("Prefabs/Player"), new Vector3(0, 0, 0), Quaternion.identity);
            gameEvent.Raise();
        }

		public override void OnExit()
		{
		}

		public override void Update(Context c, ConditionScriptable conditionScriptable)
		{
			for (int i = 0; i < conditionScriptable.conditions.Count; i++)

			{
				if(conditionScriptable.conditions[i].name == "OnGameEnd" && conditionScriptable.conditions[i].isRaised)
				{
					c.ChangeState(new GameEndState());
					conditionScriptable.Toggle("OnGameEnd");
				}

			}
		}
	}
}
