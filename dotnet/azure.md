# Azure

Azure is set of cloud services used for building, testing, deploying and managing applications and services through data centers.

## Overview

To be able to use and deploy application in production we usually need stack of various services. Cloud service modules:

- Traditional
- Infrastructure as a Service ([IaaS](https://azure.microsoft.com/en-us/overview/what-is-iaas))
- Platform as a Service ([PaaS](https://azure.microsoft.com/en-gb/overview/what-is-paas))
- Software as a Service ([SaaS](https://azure.microsoft.com/en-us/overview/what-is-saas)) 

[![what-is-saas.png](https://www.snapagogo.com/images/2020/06/04/what-is-saas.png)](https://www.snapagogo.com/image/cm0ENu)

Options for managing Azure resources:

- [Portal](https://portal.azure.com) - great for exploring, but not automated.
- [Azure PowerShell](https://docs.microsoft.com/en-us/powershell/azure)
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure)

### PowerShell core installation on Ubuntu

To install cross platform [PowerShell](https://github.com/PowerShell/Powershell) core fallow [instructions](https://docs.microsoft.com/en-us/powershell/scripting/install/installing-powershell-core-on-linux) or download latest stable [.deb](https://github.com/PowerShell/PowerShell/releases) file. If you have already added Microsoft repository you can just execute below command.

```bash
sudo apt-get install -y powershell
```

Start PowerShell with command `pwsh`.

### Azure CLI installation on Ubuntu

You can [install](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli) Azure CLI on Ubuntu based OS using below command.

```bash
curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
```

Execute command `az --version` to ensure what installation is completed successfully. 

#### Basic Azure CLI commands

| Command                                     | Description                                                  |
| ------------------------------------------- | ------------------------------------------------------------ |
| az                                          | Show all available commands.                                 |
| az login                                    | Login to Azure. Default WEB browser should open up and you should choose account you want to use. |
| az account show                             | Show currently selected subscription.                        |
| az account list                             | Show all available subscriptions.                            |
| az account set -s "subscription name or ID" | Set specific subscription.                                   |
| az subcommand -h                            | Get help information about subcommand (e.g. `az webapp -h` or `az webapp create -h`). |
| az interactive                              | Start interactive CLI mode with IntelliSense auto completion. |

[![az-interactive.png](https://www.snapagogo.com/images/2020/06/07/az-interactive.png)](https://www.snapagogo.com/image/cmAW35)

### Azure AD users and groups

Azure AD is cloud based identity and access management service. You can manage users and groups using portal, [PowerShell](https://docs.microsoft.com/en-us/powershell/azure) or [CLI](https://docs.microsoft.com/en-us/cli/azure).

#### Application registration in Azure AD

Applications should be added to [Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-how-applications-are-added) to be able to access services like user authorization and [authentication](https://docs.microsoft.com/en-us/azure/active-directory/develop/authentication-vs-authorization), [SSO](https://docs.microsoft.com/en-us/azure/active-directory/manage-apps/what-is-single-sign-on), role based access control, [OAuth](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-protocols) authorization, application publishing and etc. To create, configure and [manage](https://docs.microsoft.com/en-us/cli/azure/ad/app) application registration you can use [Azure CLI](https://docs.microsoft.com/en-us/azure/media-services/previous/media-services-cli-create-and-configure-aad-app) or [PowerShell](https://docs.microsoft.com/en-us/azure/media-services/previous/media-services-powershell-create-and-configure-aad-app).

##### Azure AD application registration

Create a web application, web API or native application.

```bash
az ad app create --display-name applicationDisplayName
```

- **display-name** - the display name of the application.
- **identifier-uris** - space separated unique URIs that Azure AD can use for this application.
- **reply-urls** - space separated URIs to which Azure AD will redirect in response to an OAuth 2.0 request. The value does not need to be a physical endpoint, but must be a valid URI.
- **required-resource-accesses** - resource scopes and roles the application requires access to. Should be in manifest JSON format. See examples below for details.

Reply or redirect URI restricts where the issued token can go and ensures you are not accidentally giving token away to another application.

To access resources of the subscription you need to assign application to a role.

##### Grant application permissions

Grant application and delegated permissions through administrator consent. You must login as a directory administrator.

```bash
az ad app permission admin-consent --id 00000000-0000-0000-0000-000000000000
```

- **id** - required identifier URI, application ID, or object ID.

##### Create an Azure AD application and configure

To create an Azure AD application and configure access to the media account with Azure CLI you can execute below [command](https://docs.microsoft.com/en-us/azure/media-services/previous/media-services-cli-create-and-configure-aad-app):

```bash
az ad sp create-for-rbac --name appName 
az role assignment create --assignee userOrAppId --role Contributor --scope subscriptionNameOrId
```

Commands and arguments description:

- **ad** - manage Azure Active Directory Graph entities needed for Role Based Access Control.
- **sp** - manage Azure Active Directory service principals for automation authentication.
- **create-for-rbac** - create for role-based access control.
- **name** - URI to use as the logic name. It doesn't need to exist. If not present, CLI will generate one.
- **role** - role of the service principal.  Default: Contributor.
- **assignment** - manage role assignments.
- **create** - create a new role assignment for a user, group, or service principal.
- **assignee** - Represent a user, group, or service principal. supported format: object id, user sign-in name, or service principal name.
- **role** - Role name or id.
- **scope** - Scope at which the role assignment or definition applies to.

## References

1. [What is Azure](https://azure.microsoft.com/en-us/overview/what-is-azure)
2. [Azure security documentation](https://docs.microsoft.com/en-us/azure/security)

2. [Azure security fundamentals documentation](https://docs.microsoft.com/en-us/azure/security/fundamentals)