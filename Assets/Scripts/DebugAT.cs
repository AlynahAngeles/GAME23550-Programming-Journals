using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DebugAT : ActionTask {
		public float waitTime = 3f;
		public float timeWaiting = 0f;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			Debug.Log("On initialization."); //only happens the first time the action is run
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			Debug.Log("On execute."); //happens at the start of everytime the action is run
			timeWaiting = 0f;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			Debug.Log("On update."); //happens in every frame while the action is running
			timeWaiting += Time.deltaTime;
			agent.transform.position += agent.transform.forward * 3f;
			agent.GetComponent<MeshRenderer>();
			agent.gameObject.SetActive(false);
			if(timeWaiting >= waitTime)
			{
                EndAction(true);
            }
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}