using ETModel;
namespace ETModel
{
//测试向服务器发送消息
	[Message(HotfixOpcode.C2G_TestMessage)]
	public partial class C2G_TestMessage : IRequest {}

//测试向服务器返回消息
	[Message(HotfixOpcode.G2C_TestMessage)]
	public partial class G2C_TestMessage : IResponse {}

//ET----
	[Message(HotfixOpcode.C2R_Login)]
	public partial class C2R_Login : IRequest {}

	[Message(HotfixOpcode.R2C_Login)]
	public partial class R2C_Login : IResponse {}

	[Message(HotfixOpcode.C2G_LoginGate)]
	public partial class C2G_LoginGate : IRequest {}

	[Message(HotfixOpcode.G2C_LoginGate)]
	public partial class G2C_LoginGate : IResponse {}

	[Message(HotfixOpcode.G2C_TestHotfixMessage)]
	public partial class G2C_TestHotfixMessage : IMessage {}

	[Message(HotfixOpcode.C2M_TestActorRequest)]
	public partial class C2M_TestActorRequest : IActorLocationRequest {}

	[Message(HotfixOpcode.M2C_TestActorResponse)]
	public partial class M2C_TestActorResponse : IActorLocationResponse {}

	[Message(HotfixOpcode.PlayerInfo)]
	public partial class PlayerInfo : IMessage {}

	[Message(HotfixOpcode.C2G_PlayerInfo)]
	public partial class C2G_PlayerInfo : IRequest {}

	[Message(HotfixOpcode.G2C_PlayerInfo)]
	public partial class G2C_PlayerInfo : IResponse {}

	[Message(HotfixOpcode.C2G_LoginGate_Req)]
	public partial class C2G_LoginGate_Req : IRequest {}

	[Message(HotfixOpcode.G2C_LoginGate_Back)]
	public partial class G2C_LoginGate_Back : IResponse {}

}
namespace ETModel
{
	public static partial class HotfixOpcode
	{
		 public const ushort C2G_TestMessage = 10001;
		 public const ushort G2C_TestMessage = 10002;
		 public const ushort C2R_Login = 10003;
		 public const ushort R2C_Login = 10004;
		 public const ushort C2G_LoginGate = 10005;
		 public const ushort G2C_LoginGate = 10006;
		 public const ushort G2C_TestHotfixMessage = 10007;
		 public const ushort C2M_TestActorRequest = 10008;
		 public const ushort M2C_TestActorResponse = 10009;
		 public const ushort PlayerInfo = 10010;
		 public const ushort C2G_PlayerInfo = 10011;
		 public const ushort G2C_PlayerInfo = 10012;
		 public const ushort C2G_LoginGate_Req = 10013;
		 public const ushort G2C_LoginGate_Back = 10014;
	}
}
