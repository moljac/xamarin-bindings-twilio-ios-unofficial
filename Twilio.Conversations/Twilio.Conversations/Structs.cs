using System;
using System.Runtime.InteropServices;
using CoreGraphics;
using ObjCRuntime;

namespace Twilio.Conversations 
{
	/*
	[StructLayout(LayoutKind.Sequential)]
	public struct TWCAspectRatio
	{
		public nuint numerator;
		public nuint denominator;
	}
	*/

	[Native]
	public enum TWCMediaTrackState : ulong
	{
		Idle = 0,
		Starting,
		Started,
		Ending,
		Ended
	}

	[Native]
	public enum TWCVideoCaptureSource : ulong
	{
		FrontCamera = 0,
		BackCamera
	}

	[Native]
	public enum TWCInviteStatus : ulong
	{
		Pending = 0,
		Accepting,
		Accepted,
		Rejected,
		Cancelled,
		Failed
	}

	[Native]
	public enum TWCErrorCode : long
	{
		Unknown = -1,
		InvalidAuthData = 100,
		InvalidSIPAccount = 102,
		ClientRegistration = 103,
		InvalidConversation = 105,
		ConversationParticipantNotAvailable = 106,
		ConversationRejected = 107,
		ConversationIgnored = 108,
		ConversationFailed = 109,
		ConversationTerminated = 110,
		PeerConnectFailed = 111,
		InvalidParticipantAddresses = 112,
		ClientDisconnected = 200,
		ClientFailedToReconnect = 201,
		TooManyActiveConversations = 202,
		TooManyTracks = 300,
		InvalidVideoCapturer = 301,
		InvalidVideoTrack = 302,
		VideoFailed = 303,
		TrackOperationInProgress = 304,
		TrackAddFailed = 305
	}

	[Native]
	public enum TWCVideoOrientation : ulong
	{
		Up = 0,
		Left,
		Down,
		Right
	}

	[Native]
	public enum TWCIceTransportPolicy : ulong
	{
		All = 0,
		Relay = 1
	}

	[Native]
	public enum TWCVideoRenderingType : ulong
	{
		Metal = 0,
		OpenGLES
	}

	[Native]
	public enum TWCLogLevel : ulong
	{
		Off = 0,
		Fatal,
		Error,
		Warning,
		Info,
		Debug,
		Trace,
		All
	}

	[Native]
	public enum TWCLogModule : ulong
	{
		Core = 0,
		Platform,
		Signaling,
		WebRTC
	}

	[Native]
	public enum TWCAudioOutput : ulong
	{
		Default = 0,
		Speaker = 1,
		Receiver = 2,
		Application = 3
	}
}