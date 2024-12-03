using UnityEngine;

namespace Mypet.AI
{

    public class CatController : AnimalController
    {
        protected override void Start()
        {
            base.Start();

            //고양이 고유의 상태 추가 등록
            stateMachine.AddState(new SitState());
            stateMachine.AddState(new DrinkState());
        }

        public void Idle()
        {
            ChangeState<IdleState>();
        }

        public void Sit()
        {
            ChangeState<SitState>();
        }

        public void Drink()
        {
            ChangeState<DrinkState>();
        }
    }
}

