using System;
using ObjCRuntime;

namespace Twilio.IPMessagingClient
{
	[Native]
	public enum TWMClientSynchronizationStrategy : ulong
	{
		All,
		ChannelsList
	}

	[Native]
	public enum TWMClientSynchronizationStatus : ulong
	{
		Started = 0,
		ChannelsListCompleted,
		Completed,
		Failed
	}

	[Native]
	public enum TWMLogLevel : ulong
	{
		Fatal = 0,
		Critical,
		Warning,
		Info,
		Debug
	}

	[Native]
	public enum TWMChannelSynchronizationStatus : ulong
	{
		None = 0,
		Identifier,
		Metadata,
		All,
		Failed
	}

	[Native]
	public enum TWMChannelStatus : ulong
	{
		Invited = 0,
		Joined,
		NotParticipating
	}

	[Native]
	public enum TWMChannelType : ulong
	{
		ublic = 0,
		rivate
	}

	[Native]
	public enum TWMUserInfoUpdate : ulong
	{
		FriendlyName = 0,
		Attributes,
		ReachabilityOnline,
		ReachabilityNotifiable
	}

}