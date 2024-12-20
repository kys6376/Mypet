using UnityEngine;

namespace Mypet.AI
{ 
public class DogController : AnimalController
    {
        protected override void Start()
        {
            base.Start();

            //dog와 관련된 상태 추가 등록
            stateMachine.AddState(new DrinkState());
            stateMachine.AddState(new SitState());
            stateMachine.AddState(new DogIdleState());
        }
    }
}
