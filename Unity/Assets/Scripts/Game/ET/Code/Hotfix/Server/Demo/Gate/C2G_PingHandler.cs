﻿using Cysharp.Threading.Tasks;

namespace ET.Server
{
	[MessageSessionHandler(SceneType.Gate)]
	public class C2G_PingHandler : MessageSessionHandler<C2G_Ping, G2C_Ping>
	{
		protected override async UniTask Run(Session session, C2G_Ping request, G2C_Ping response)
		{
			response.Time = TimeInfo.Instance.ServerNow();
			await UniTask.CompletedTask;
		}
	}
}