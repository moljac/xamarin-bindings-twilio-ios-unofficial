using System;
using Foundation;
using ObjCRuntime;
using Twilio.Common;

namespace Twilio.IPMessagingClient
{
	// typedef void (^TWMCompletion)(TWMResult *);
	delegate void TWMCompletion(TWMResult arg0);

	// typedef void (^TWMChannelListCompletion)(TWMResult *, TWMChannels *);
	delegate void TWMChannelListCompletion(TWMResult arg0, TWMChannels arg1);

	// typedef void (^TWMChannelCompletion)(TWMResult *, TWMChannel *);
	delegate void TWMChannelCompletion(TWMResult arg0, TWMChannel arg1);

	// typedef void (^TWMMessagesCompletion)(TWMResult *, NSArray<TWMMessage *> *);
	delegate void TWMMessagesCompletion(TWMResult arg0, TWMMessage[] arg1);

	[Static]
	partial interface Constants
	{
		// extern NSString *const TWMChannelOptionFriendlyName;
		[Field("TWMChannelOptionFriendlyName", "__Internal")]
		NSString TWMChannelOptionFriendlyName { get; }

		// extern NSString *const TWMChannelOptionUniqueName;
		[Field("TWMChannelOptionUniqueName", "__Internal")]
		NSString TWMChannelOptionUniqueName { get; }

		// extern NSString *const TWMChannelOptionType;
		[Field("TWMChannelOptionType", "__Internal")]
		NSString TWMChannelOptionType { get; }

		// extern NSString *const TWMChannelOptionAttributes;
		[Field("TWMChannelOptionAttributes", "__Internal")]
		NSString TWMChannelOptionAttributes { get; }

		// extern NSString *const TWMErrorDomain;
		[Field("TWMErrorDomain", "__Internal")]
		NSString TWMErrorDomain { get; }

		// extern const NSInteger TWMErrorGeneric;
		[Field("TWMErrorGeneric", "__Internal")]
		nint TWMErrorGeneric { get; }

		// extern NSString *const TWMErrorMsgKey;
		[Field("TWMErrorMsgKey", "__Internal")]
		NSString TWMErrorMsgKey { get; }
	}

	// @interface TWMError : NSError
	[BaseType(typeof(NSError), Name="TWMError")]
	interface TWMError { }

	// @interface TWMResult : NSObject
	[BaseType(typeof(NSObject), Name="TWMResult")]
	interface TWMResult
	{
		// @property (readonly, nonatomic, strong) TWMError * error;
		[Export("error", ArgumentSemantic.Strong)]
		TWMError Error { get; }

		// -(BOOL)isSuccessful;
		[Export("isSuccessful")]
		bool IsSuccessful { get; }
	}

	// @interface TWMMessage : NSObject
	[BaseType(typeof(NSObject), Name="TWMMessage")]
	interface TWMMessage
	{
		// @property (readonly, copy, nonatomic) NSString * sid;
		[Export("sid")]
		string Sid { get; }

		// @property (readonly, copy, nonatomic) NSNumber * index;
		[Export("index", ArgumentSemantic.Copy)]
		NSNumber Index { get; }

		// @property (readonly, copy, nonatomic) NSString * author;
		[Export("author")]
		string Author { get; }

		// @property (readonly, copy, nonatomic) NSString * body;
		[Export("body")]
		string Body { get; }

		// @property (readonly, copy, nonatomic) NSString * timestamp;
		[Export("timestamp")]
		string Timestamp { get; }

		// @property (readonly, nonatomic, strong) NSDate * timestampAsDate;
		[Export("timestampAsDate", ArgumentSemantic.Strong)]
		NSDate TimestampAsDate { get; }

		// @property (readonly, copy, nonatomic) NSString * dateUpdated;
		[Export("dateUpdated")]
		string DateUpdated { get; }

		// @property (readonly, nonatomic, strong) NSDate * dateUpdatedAsDate;
		[Export("dateUpdatedAsDate", ArgumentSemantic.Strong)]
		NSDate DateUpdatedAsDate { get; }

		// @property (readonly, copy, nonatomic) NSString * lastUpdatedBy;
		[Export("lastUpdatedBy")]
		string LastUpdatedBy { get; }

		// -(void)updateBody:(NSString *)body completion:(TWMCompletion)completion;
		[Export("updateBody:completion:")]
		void UpdateBody(string body, TWMCompletion completion);

		// -(NSDictionary<NSString *,id> *)attributes;
		[Export("attributes")]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(void)setAttributes:(NSDictionary<NSString *,id> *)attributes completion:(TWMCompletion)completion;
		[Export("setAttributes:completion:")]
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, TWMCompletion completion);
	}

	// @interface TWMMessages : NSObject
	[BaseType(typeof(NSObject), Name="TWMMessages")]
	interface TWMMessages
	{
		// @property (readonly, copy, nonatomic) NSNumber * lastConsumedMessageIndex;
		[Export("lastConsumedMessageIndex", ArgumentSemantic.Copy)]
		NSNumber LastConsumedMessageIndex { get; }

		// -(TWMMessage *)createMessageWithBody:(NSString *)body;
		[Export("createMessageWithBody:")]
		TWMMessage CreateMessageWithBody(string body);

		// -(void)sendMessage:(TWMMessage *)message completion:(TWMCompletion)completion;
		[Export("sendMessage:completion:")]
		void SendMessage(TWMMessage message, TWMCompletion completion);

		// -(void)removeMessage:(TWMMessage *)message completion:(TWMCompletion)completion;
		[Export("removeMessage:completion:")]
		void RemoveMessage(TWMMessage message, TWMCompletion completion);

		// -(NSArray<TWMMessage *> *)allObjects;
		[Export("allObjects")]
		TWMMessage[] AllObjects { get; }

		// -(void)getLastMessagesWithCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getLastMessagesWithCount:completion:")]
		void GetLastMessagesWithCount(nuint count, TWMMessagesCompletion completion);

		// -(void)getMessagesBefore:(NSUInteger)index withCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getMessagesBefore:withCount:completion:")]
		void GetMessagesBefore(nuint index, nuint count, TWMMessagesCompletion completion);

		// -(void)getMessagesAfter:(NSUInteger)index withCount:(NSUInteger)count completion:(TWMMessagesCompletion)completion;
		[Export("getMessagesAfter:withCount:completion:")]
		void GetMessagesAfter(nuint index, nuint count, TWMMessagesCompletion completion);

		// -(TWMMessage *)messageWithIndex:(NSNumber *)index;
		[Export("messageWithIndex:")]
		TWMMessage MessageWithIndex(NSNumber index);

		// -(TWMMessage *)messageForConsumptionIndex:(NSNumber *)index;
		[Export("messageForConsumptionIndex:")]
		TWMMessage MessageForConsumptionIndex(NSNumber index);

		// -(void)setLastConsumedMessageIndex:(NSNumber *)index;
		[Export("setLastConsumedMessageIndex:")]
		void SetLastConsumedMessageIndex(NSNumber index);

		// -(void)advanceLastConsumedMessageIndex:(NSNumber *)index;
		[Export("advanceLastConsumedMessageIndex:")]
		void AdvanceLastConsumedMessageIndex(NSNumber index);

		// -(void)setAllMessagesConsumed;
		[Export("setAllMessagesConsumed")]
		void SetAllMessagesConsumed();

		// -(void)setNoMessagesConsumed;
		[Export("setNoMessagesConsumed")]
		void SetNoMessagesConsumed();
	}

	// @interface TWMUserInfo : NSObject
	[BaseType(typeof(NSObject), Name="TWMUserInfo")]
	interface TWMUserInfo
	{
		// @property (readonly, copy, nonatomic) NSString * identity;
		[Export("identity")]
		string Identity { get; }

		// @property (readonly, copy, nonatomic) NSString * friendlyName;
		[Export("friendlyName")]
		string FriendlyName { get; }

		// -(NSDictionary<NSString *,id> *)attributes;
		[Export("attributes")]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(void)setAttributes:(NSDictionary<NSString *,id> *)attributes completion:(TWMCompletion)completion;
		[Export("setAttributes:completion:")]
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, TWMCompletion completion);

		// -(void)setFriendlyName:(NSString *)friendlyName completion:(TWMCompletion)completion;
		[Export("setFriendlyName:completion:")]
		void SetFriendlyName(string friendlyName, TWMCompletion completion);

		// -(BOOL)isOnline;
		[Export("isOnline")]
		bool IsOnline { get; }

		// -(BOOL)isNotifiable;
		[Export("isNotifiable")]
		bool IsNotifiable { get; }
	}

	// @interface TWMMember : NSObject
	[BaseType(typeof(NSObject), Name="TWMMember")]
	interface TWMMember
	{
		// @property (readonly, nonatomic, strong) TWMUserInfo * userInfo;
		[Export("userInfo", ArgumentSemantic.Strong)]
		TWMUserInfo UserInfo { get; }

		// @property (readonly, copy, nonatomic) NSNumber * lastConsumedMessageIndex;
		[Export("lastConsumedMessageIndex", ArgumentSemantic.Copy)]
		NSNumber LastConsumedMessageIndex { get; }

		// @property (readonly, copy, nonatomic) NSString * lastConsumptionTimestamp;
		[Export("lastConsumptionTimestamp")]
		string LastConsumptionTimestamp { get; }

		// @property (readonly, nonatomic, strong) NSDate * lastConsumptionTimestampAsDate;
		[Export("lastConsumptionTimestampAsDate", ArgumentSemantic.Strong)]
		NSDate LastConsumptionTimestampAsDate { get; }
	}

	// @interface TWMMembers : NSObject
	[BaseType(typeof(NSObject), Name="TWMMembers")]
	interface TWMMembers
	{
		// -(NSArray<TWMMember *> *)allObjects;
		[Export("allObjects")]
		TWMMember[] AllObjects { get; }

		// -(void)addByIdentity:(NSString *)identity completion:(TWMCompletion)completion;
		[Export("addByIdentity:completion:")]
		void AddByIdentity(string identity, TWMCompletion completion);

		// -(void)inviteByIdentity:(NSString *)identity completion:(TWMCompletion)completion;
		[Export("inviteByIdentity:completion:")]
		void InviteByIdentity(string identity, TWMCompletion completion);

		// -(void)removeMember:(TWMMember *)member completion:(TWMCompletion)completion;
		[Export("removeMember:completion:")]
		void RemoveMember(TWMMember member, TWMCompletion completion);
	}

	// @interface TWMChannel : NSObject
	[BaseType(typeof(NSObject), Name="TWMChannel")]
	interface TWMChannel
	{
		[Wrap("WeakDelegate")]
		TWMChannelDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TWMChannelDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, copy, nonatomic) NSString * sid;
		[Export("sid")]
		string Sid { get; }

		// @property (readonly, copy, nonatomic) NSString * friendlyName;
		[Export("friendlyName")]
		string FriendlyName { get; }

		// @property (readonly, copy, nonatomic) NSString * uniqueName;
		[Export("uniqueName")]
		string UniqueName { get; }

		// @property (readonly, nonatomic, strong) TWMMessages * messages;
		[Export("messages", ArgumentSemantic.Strong)]
		TWMMessages Messages { get; }

		// @property (readonly, nonatomic, strong) TWMMembers * members;
		[Export("members", ArgumentSemantic.Strong)]
		TWMMembers Members { get; }

		// @property (readonly, assign, nonatomic) TWMChannelSynchronizationStatus synchronizationStatus;
		[Export("synchronizationStatus", ArgumentSemantic.Assign)]
		TWMChannelSynchronizationStatus SynchronizationStatus { get; }

		// @property (readonly, assign, nonatomic) TWMChannelStatus status;
		[Export("status", ArgumentSemantic.Assign)]
		TWMChannelStatus Status { get; }

		// @property (readonly, assign, nonatomic) TWMChannelType type;
		[Export("type", ArgumentSemantic.Assign)]
		TWMChannelType Type { get; }

		// @property (readonly, nonatomic, strong) NSString * dateCreated;
		[Export("dateCreated", ArgumentSemantic.Strong)]
		string DateCreated { get; }

		// @property (readonly, nonatomic, strong) NSDate * dateCreatedAsDate;
		[Export("dateCreatedAsDate", ArgumentSemantic.Strong)]
		NSDate DateCreatedAsDate { get; }

		// @property (readonly, nonatomic, strong) NSString * dateUpdated;
		[Export("dateUpdated", ArgumentSemantic.Strong)]
		string DateUpdated { get; }

		// @property (readonly, nonatomic, strong) NSDate * dateUpdatedAsDate;
		[Export("dateUpdatedAsDate", ArgumentSemantic.Strong)]
		NSDate DateUpdatedAsDate { get; }

		// -(void)synchronizeWithCompletion:(TWMCompletion)completion;
		[Export("synchronizeWithCompletion:")]
		void SynchronizeWithCompletion(TWMCompletion completion);

		// -(NSDictionary<NSString *,id> *)attributes;
		[Export("attributes")]
		NSDictionary<NSString, NSObject> Attributes { get; }

		// -(void)setAttributes:(NSDictionary<NSString *,id> *)attributes completion:(TWMCompletion)completion;
		[Export("setAttributes:completion:")]
		void SetAttributes(NSDictionary<NSString, NSObject> attributes, TWMCompletion completion);

		// -(void)setFriendlyName:(NSString *)friendlyName completion:(TWMCompletion)completion;
		[Export("setFriendlyName:completion:")]
		void SetFriendlyName(string friendlyName, TWMCompletion completion);

		// -(void)setUniqueName:(NSString *)uniqueName completion:(TWMCompletion)completion;
		[Export("setUniqueName:completion:")]
		void SetUniqueName(string uniqueName, TWMCompletion completion);

		// -(void)joinWithCompletion:(TWMCompletion)completion;
		[Export("joinWithCompletion:")]
		void JoinWithCompletion(TWMCompletion completion);

		// -(void)declineInvitationWithCompletion:(TWMCompletion)completion;
		[Export("declineInvitationWithCompletion:")]
		void DeclineInvitationWithCompletion(TWMCompletion completion);

		// -(void)leaveWithCompletion:(TWMCompletion)completion;
		[Export("leaveWithCompletion:")]
		void LeaveWithCompletion(TWMCompletion completion);

		// -(void)destroyWithCompletion:(TWMCompletion)completion;
		[Export("destroyWithCompletion:")]
		void DestroyWithCompletion(TWMCompletion completion);

		// -(void)typing;
		[Export("typing")]
		void Typing();

		// -(TWMMember *)memberWithIdentity:(NSString *)identity;
		[Export("memberWithIdentity:")]
		TWMMember MemberWithIdentity(string identity);
	}

	// @protocol TWMChannelDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject), Name="TWMChannelDelegate")]
	interface TWMChannelDelegate
	{
		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelChanged:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelChanged:")]
		void ChannelChanged(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelDeleted:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelDeleted:")]
		void ChannelDeleted(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel synchronizationStatusChanged:(TWMChannelSynchronizationStatus)status;
		[Export("ipMessagingClient:channel:synchronizationStatusChanged:")]
		void ChannelSynchronizationStatusChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMChannelSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberJoined:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberJoined:")]
		void ChannelMemberJoined(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberChanged:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberChanged:")]
		void ChannelMemberChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel member:(TWMMember *)member userInfo:(TWMUserInfo *)userInfo updated:(TWMUserInfoUpdate)updated;
		[Export("ipMessagingClient:channel:member:userInfo:updated:")]
		void Channel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member, TWMUserInfo userInfo, TWMUserInfoUpdate updated);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberLeft:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberLeft:")]
		void ChannelMemberLeft(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageAdded:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageAdded:")]
		void ChannelMessageAdded(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageChanged:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageChanged:")]
		void ChannelMessageChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageDeleted:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageDeleted:")]
		void ChannelMessageDeleted(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingStartedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingStartedOnChannel:member:")]
		void TypingStartedOnChannel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingEndedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingEndedOnChannel:member:")]
		void TypingEndedOnChannel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);
	}

	// @interface TWMChannels : NSObject
	[BaseType(typeof(NSObject), Name="TWMChannels")]
	interface TWMChannels
	{
		// -(NSArray<TWMChannel *> *)allObjects;
		[Export("allObjects")]
		TWMChannel[] AllObjects { get; }

		// -(void)createChannelWithOptions:(NSDictionary *)options completion:(TWMChannelCompletion)completion;
		[Export("createChannelWithOptions:completion:")]
		void CreateChannelWithOptions(NSDictionary options, TWMChannelCompletion completion);

		// -(TWMChannel *)channelWithId:(NSString *)channelId;
		[Export("channelWithId:")]
		TWMChannel ChannelWithId(string channelId);

		// -(TWMChannel *)channelWithUniqueName:(NSString *)uniqueName;
		[Export("channelWithUniqueName:")]
		TWMChannel ChannelWithUniqueName(string uniqueName);
	}

	// @interface TwilioIPMessagingClient : NSObject
	[BaseType(typeof(NSObject), Name="TwilioIPMessagingClient")]
	interface TwilioIPMessagingClient
	{
		// @property (nonatomic, strong) TwilioAccessManager * accessManager;
		[Export("accessManager", ArgumentSemantic.Strong)]
		TwilioAccessManager AccessManager { get; set; }

		[Wrap("WeakDelegate")]
		TwilioIPMessagingClientDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<TwilioIPMessagingClientDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// @property (readonly, nonatomic, strong) TWMUserInfo * userInfo;
		[Export("userInfo", ArgumentSemantic.Strong)]
		TWMUserInfo UserInfo { get; }

		// @property (readonly, assign, nonatomic) TWMClientSynchronizationStatus synchronizationStatus;
		[Export("synchronizationStatus", ArgumentSemantic.Assign)]
		TWMClientSynchronizationStatus SynchronizationStatus { get; }

		// +(TWMLogLevel)logLevel;
		// +(void)setLogLevel:(TWMLogLevel)logLevel;
		[Static]
		[Export("logLevel")]
		TWMLogLevel LogLevel { get; set; }

		// +(TwilioIPMessagingClient *)ipMessagingClientWithAccessManager:(TwilioAccessManager *)accessManager properties:(TwilioIPMessagingClientProperties *)properties delegate:(id<TwilioIPMessagingClientDelegate>)delegate;
		[Static]
		[Export("ipMessagingClientWithAccessManager:properties:delegate:")]
		TwilioIPMessagingClient IpMessagingClientWithAccessManager(TwilioAccessManager accessManager, TwilioIPMessagingClientProperties properties, TwilioIPMessagingClientDelegate @delegate);

		// -(NSString *)version;
		[Export("version")]
		string Version { get; }

		// -(TWMChannels *)channelsList;
		[Export("channelsList")]
		TWMChannels ChannelsList { get; }

		// -(void)registerWithToken:(NSData *)token;
		[Export("registerWithToken:")]
		void RegisterWithToken(NSData token);

		// -(void)deregisterWithToken:(NSData *)token;
		[Export("deregisterWithToken:")]
		void DeregisterWithToken(NSData token);

		// -(void)handleNotification:(NSDictionary *)notification;
		[Export("handleNotification:")]
		void HandleNotification(NSDictionary notification);

		// -(BOOL)isReachabilityEnabled;
		[Export("isReachabilityEnabled")]
		bool IsReachabilityEnabled { get; }

		// -(void)shutdown;
		[Export("shutdown")]
		void Shutdown();
	}

	// @interface TwilioIPMessagingClientProperties : NSObject
	[BaseType(typeof(NSObject), Name="TwilioIPMessagingClientProperties")]
	interface TwilioIPMessagingClientProperties
	{
		// @property (assign, nonatomic) TWMClientSynchronizationStrategy synchronizationStrategy;
		[Export("synchronizationStrategy", ArgumentSemantic.Assign)]
		TWMClientSynchronizationStrategy SynchronizationStrategy { get; set; }

		// @property (assign, nonatomic) uint initialMessageCount;
		[Export("initialMessageCount")]
		uint InitialMessageCount { get; set; }

		// @property (copy, nonatomic) NSString * region;
		[Export("region")]
		string Region { get; set; }
	}

	// @protocol TwilioIPMessagingClientDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject), Name="TwilioIPMessagingClientDelegate")]
	interface TwilioIPMessagingClientDelegate
	{
		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client synchronizationStatusChanged:(TWMClientSynchronizationStatus)status;
		[Export("ipMessagingClient:synchronizationStatusChanged:")]
		void IpMessagingClientSynchronizationStatusChanged(TwilioIPMessagingClient client, TWMClientSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelAdded:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelAdded:")]
		void IpMessagingClientChannelAdded(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelChanged:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelChanged:")]
		void IpMessagingClientChannelChanged(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channelDeleted:(TWMChannel *)channel;
		[Export("ipMessagingClient:channelDeleted:")]
		void IpMessagingClientChannelDeleted(TwilioIPMessagingClient client, TWMChannel channel);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel synchronizationStatusChanged:(TWMChannelSynchronizationStatus)status;
		[Export("ipMessagingClient:channel:synchronizationStatusChanged:")]
		void IpMessagingClientSynchronizationStatusChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMChannelSynchronizationStatus status);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberJoined:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberJoined:")]
		void IpMessagingClientMemberJoined(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberChanged:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberChanged:")]
		void IpMessagingClientMemberChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel memberLeft:(TWMMember *)member;
		[Export("ipMessagingClient:channel:memberLeft:")]
		void IpMessagingClientMemberLeft(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageAdded:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageAdded:")]
		void IpMessagingClientMessageAdded(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageChanged:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageChanged:")]
		void IpMessagingClientMessageChanged(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client channel:(TWMChannel *)channel messageDeleted:(TWMMessage *)message;
		[Export("ipMessagingClient:channel:messageDeleted:")]
		void IpMessagingClientMessageDeleted(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client errorReceived:(TWMError *)error;
		[Export("ipMessagingClient:errorReceived:")]
		void IpMessagingClientErrorReceived(TwilioIPMessagingClient client, TWMError error);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingStartedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingStartedOnChannel:member:")]
		void IpMessagingClientTypingStartedOnChannel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client typingEndedOnChannel:(TWMChannel *)channel member:(TWMMember *)member;
		[Export("ipMessagingClient:typingEndedOnChannel:member:")]
		void IpMessagingClientTypingEndedOnChannel(TwilioIPMessagingClient client, TWMChannel channel, TWMMember member);

		// @optional -(void)ipMessagingClientToastSubscribed:(TwilioIPMessagingClient *)client;
		[Export("ipMessagingClientToastSubscribed:")]
		void IpMessagingClientToastSubscribed(TwilioIPMessagingClient client);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client toastReceivedOnChannel:(TWMChannel *)channel message:(TWMMessage *)message;
		[Export("ipMessagingClient:toastReceivedOnChannel:message:")]
		void IpMessagingClientToastReceivedOnChannel(TwilioIPMessagingClient client, TWMChannel channel, TWMMessage message);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client toastRegistrationFailedWithError:(TWMError *)error;
		[Export("ipMessagingClient:toastRegistrationFailedWithError:")]
		void IpMessagingClientToastRegistrationFailedWithError(TwilioIPMessagingClient client, TWMError error);

		// @optional -(void)ipMessagingClient:(TwilioIPMessagingClient *)client userInfo:(TWMUserInfo *)userInfo updated:(TWMUserInfoUpdate)updated;
		[Export("ipMessagingClient:userInfo:updated:")]
		void IpMessagingClientUserInfoUpdated(TwilioIPMessagingClient client, TWMUserInfo userInfo, TWMUserInfoUpdate updated);
	}
}