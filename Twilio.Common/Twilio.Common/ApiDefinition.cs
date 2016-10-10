using Foundation;
using ObjCRuntime;

namespace Twilio.Common
{
	[BaseType(typeof(NSObject))]
	interface TwilioAccessManager
	{
		[NullAllowed]
		[Export("delegate", ArgumentSemantic.Weak)]
		ITwilioAccessManagerDelegate Delegate { get; set; }

		// +(instancetype)accessManagerWithToken:(NSString *)token delegate:(id<TwilioAccessManagerDelegate>)delegate;
		[Static]
		[Export("accessManagerWithToken:delegate:")]
		TwilioAccessManager AccessManagerWithToken(string token, ITwilioAccessManagerDelegate @delegate);

		// -(void)updateToken:(NSString *)token;
		[Export("updateToken:")]
		void UpdateToken(string token);

		// -(NSString *)token;
		[Export("token")]
		string Token { get; }

		// -(NSString *)identity;
		[Export("identity")]
		string Identity { get; }

		// -(BOOL)isExpired;
		[Export("isExpired")]
		bool IsExpired { get; }

		// -(NSDate *)expirationDate;
		[Export("expirationDate")]
		NSDate ExpirationDate { get; }
	}

	interface ITwilioAccessManagerDelegate { }

	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface TwilioAccessManagerDelegate
	{
		// @required -(void)accessManagerTokenExpired:(TwilioAccessManager *)accessManager;
		[Abstract]
		[Export("accessManagerTokenExpired:")]
		void AccessManagerTokenExpired(TwilioAccessManager accessManager);

		// @required -(void)accessManager:(TwilioAccessManager *)accessManager error:(NSError *)error;
		[Abstract]
		[Export("accessManager:error:")]
		void AccessManagerError(TwilioAccessManager accessManager, NSError error);
	}
}