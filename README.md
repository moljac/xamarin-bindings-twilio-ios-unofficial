# xamarin-bindings-twilio-ios-unofficial
Bindings for Twilio Common, Coversations, and IPMessaging.

This repository provides the ApiDefinitions and Structures for Twilio Common, Conversations, and IPMessagining. These files are for reference and additional work is required to compile each binding.

You will need the following archives to compile these bindings:

- [Twilio Common v0.3.1](https://media.twiliocdn.com/sdk/ios/common/releases/0.3.1/twilio-common-ios-0.3.1.tar.bz2)
- [Twilio IPMessaging v0.15](https://media.twiliocdn.com/sdk/ios/ip-messaging/v0.15/twilio-ip-messaging-ios.tar.bz2)
- [Twilio Conversations v.0.25.1](https://media.twiliocdn.com/sdk/ios/conversations/releases/0.25.1/twilio-conversations-ios-0.25.1.tar.bz2)


To compile:

1. Download the 3 frameworks above
    - Expand each framework.
2. Navigation to Versions\A\
3. Find the static archive.
    - It won't have an extension, but will be > 50MB
    - Example: TwilioCommon is 135.3MB
4. Copy the static archive into this repository's Lib directory
5. Add an ".a" extension to the static archive
    - Example: TwilioCommon.a
6. Compile

