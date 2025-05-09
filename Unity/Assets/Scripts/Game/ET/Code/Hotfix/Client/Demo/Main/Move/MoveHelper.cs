using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Cysharp.Threading.Tasks;
using Unity.Mathematics;

namespace ET.Client
{
    public static partial class MoveHelper
    {
        // 可以多次调用，多次调用的话会取消上一次的协程
        public static async UniTask<int> MoveToAsync(this Unit unit, float3 targetPos, CancellationToken token = default)
        {
            C2M_PathfindingResult msg = C2M_PathfindingResult.Create();
            msg.Position = targetPos;
            unit.Root().GetComponent<ClientSenderComponent>().Send(msg);

            ObjectWait objectWait = unit.GetComponent<ObjectWait>();
            
            // 要取消上一次的移动协程
            objectWait.Notify(new Wait_UnitStop() { Error = WaitTypeError.Cancel });
            
            // 一直等到unit发送stop
            (bool canceled, Wait_UnitStop waitUnitStop) = await objectWait.Wait<Wait_UnitStop>(token).SuppressCancellationThrow();
            if (canceled)
            {
                return WaitTypeError.Cancel;
            }
            return waitUnitStop.Error;
        }
        
        public static async UniTask MoveToAsync(this Unit unit, List<float3> path)
        {
            float speed = unit.GetComponent<NumericComponent>().GetAsFloat(NumericType.Speed);
            MoveComponent moveComponent = unit.GetComponent<MoveComponent>();
            await moveComponent.MoveToAsync(path, speed);
        }
    }
}