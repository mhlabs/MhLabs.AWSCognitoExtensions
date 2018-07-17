# MhLabs.AWSCognitoExtensions

## Extensions methods for AWS Cognito Userpools.

### V 1.0.1
Get usename claim from authentications using both IdToken and AccessToken. The cognito claim for the username value differs depending on token type.

Usage:

```
using MhLabs.AWSCognitoExtensions;

[...]

var userId = HttpContext.User.UserId();
```
