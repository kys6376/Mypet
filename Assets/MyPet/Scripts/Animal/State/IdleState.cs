using UnityEngine;
using UnityEngine.AI;

namespace Mypet.AI
{
    [System.Serializable]
    public class IdleState : State<AnimalController>
    {
        private Animator animator;
        //private CharacterController characterController;
        //private NavMeshAgent agent;
        public override void OnInitialized()
        {
           //ÂüÁ¶
           animator = context.GetComponent<Animator>();
        }

        public override void OnEnter()
        {
            
        }

        public override void Update(float deltaTime)
        {
            
        }

        public override void OnExit()
        {
            
        }
    }  
}
