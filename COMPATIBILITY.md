Compatibility with OpenStack API


Identity API 2.0 
-----------
Get an authentication token that permits access to the OpenStack services REST API.

## Methods Implemented 

**API versions**

*GET/* - List versions

Lists information about all Identity API versions.


*GET/v2.0* - Show version details

Shows details for the Identity API v2.0.

**Extensions**

*GET/v2.0/extensions* - List extensions

Lists available extensions.

**Tokens**

*POST/v2.0/tokens* - Authenticate

Authenticates and generates a token.

## Methods Not Implemented ##


**Extensions**

*GET/v2.0/extensions/​{alias}​* - Get extension details

Gets detailed information for a specified extension.

**Tokens**

*GET/v2.0/tenants* - List tenants

Lists tenants to which the specified token has access.

*GET/v2.0/tokens/​{tokenId}​* - Validate token

Validates a token and confirms that it belongs to a specified tenant.

*HEAD/v2.0/tokens/​{tokenId}​* - Validate token (admin)

Validates a token and confirms that it belongs to a specified tenant, for performance.

**Users**

*POST/v2.0/users* - Add user

Adds a user.

*PUT/v2.0/users/​{userId}​* - Update user

Updates a user.

*DELETE/v2.0/users/​{userId}*​ - Delete user

Deletes a user.

*GET/v2.0/users/​{name}​* - Get user information by name

Gets detailed information about a specified user by user name.

*GET/v2.0/users/​{user_id}*​ - Get user information by ID

Gets detailed information about a specified user by user ID.

*GET/v2.0/users/​{user_id}​/roles* - List user global roles

Lists global roles for a specified user. Excludes tenant roles.

**Tenants**

*GET/v2.0/tenants* - List tenants

Lists all tenants.

GET/v2.0/tenants - Get tenant information by name

Gets detailed information about a specified tenant by name.

GET/v2.0/tenants/​{tenantId}​Get tenant information by ID

Gets detailed information about a specified tenant by ID.

GET/v2.0/tenants/​{tenantId}​/users/​{userId}​/rolesList roles for user

Lists roles for a specified user on a specified tenant. Excludes global roles.
