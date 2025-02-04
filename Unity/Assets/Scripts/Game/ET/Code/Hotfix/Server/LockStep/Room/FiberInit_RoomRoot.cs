﻿using Cysharp.Threading.Tasks;

namespace ET.Server
{
    [Invoke((long)SceneType.RoomRoot)]
    public class FiberInit_RoomRoot: AInvokeHandler<FiberInit, UniTask>
    {
        public override async UniTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            Room room = root.AddChild<Room>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<MessageLocationSenderComponent>();
            
            room.Name = "Server";

            await UniTask.CompletedTask;
        }
    }
}