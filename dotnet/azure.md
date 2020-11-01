# Azure

Azure is set of cloud services used for building, testing, deploying and managing applications and services through data centers.

## Overview

To be able to use and deploy application in production we usually need stack of various services. Cloud service modules:

- On-premises
- Infrastructure as a Service ([IaaS](https://azure.microsoft.com/en-us/overview/what-is-iaas))
- Platform as a Service ([PaaS](https://azure.microsoft.com/en-gb/overview/what-is-paas))
- Software as a Service ([SaaS](https://azure.microsoft.com/en-us/overview/what-is-saas)) 

[![what-is-saas.png](https://www.snapagogo.com/images/2020/06/04/what-is-saas.png)](https://www.snapagogo.com/image/cm0ENu)

Options for managing Azure resources:

- [Portal](https://portal.azure.com) - Great for exploring, but not automated.
- [Azure PowerShell](https://docs.microsoft.com/en-us/powershell/azure) - Limited core version of PowerShell is available for Linux. 
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure) - Fully cross platform solution for managing Azure using command line.

### Defense and security layers

Three [layer](https://azure.microsoft.com/en-us/blog/azure-layered-approach-to-physical-security/) approach to security to prevent or slow down malicious attack:

- **Confidentiality** - Principle of least privilege. Restricts access to information (e.g. passwords, e-mail content, access certificates) only to explicitly granted individuals.
- **Integrity** - Prevent unauthorized changes to information at rest or in transit.
- **Availability** - Ensure services are available. Denial of service attack prevention, system security from natural disasters, high availability and disaster recovery.

System [defense-in-depth strategy](https://docs.microsoft.com/en-us/kaizala/partnerdocs/security) can be layered into six parts:

[![defence-in-depth.png](https://docs.microsoft.com/en-us/kaizala/partnerdocs/images/defence%20in%20depth.png)](https://docs.microsoft.com/en-us/kaizala/partnerdocs/security)

- **Physical security** - Access to the building, control of data center hardware.
- **Network** - Protection from network attacks, by identifying attack, minimizing impact and alert (e.g. DDOS protection, Firewall). Limit communication and access control (deny by default), restrict inbound internet access and limit [outbound connections](https://docs.microsoft.com/en-us/azure/load-balancer/load-balancer-outbound-connections).
- **Host** - Endpoint protection, control access to operating system. 
- **Application** - Ensure application is securely build (e.g. update packages), do not publicly expose application secrets (e.g. passwords), make security design requirements.
- **Administration** - Authentication and authorization, control access to infrastructure, audit events and changes.
- **Data** - Ensure data security while it is at rest and in transit.

### Compliance and security requirements

Overall product security is a joint responsibility. Below diagram show [shared responsibilities](https://gallery.technet.microsoft.com/Shared-Responsibilities-81d0ff91) between Microsoft and customer:

[![shared-responsibility.png](https://docs.microsoft.com/en-us/azure/security/fundamentals/media/shared-responsibility/shared-responsibility.png)](https://docs.microsoft.com/en-us/azure/security/fundamentals/shared-responsibility)

We can see that cloud computing solution provides many benefits over on-premises. Responsibilities always retained by customer:

- Data
- Endpoints
- Account
- Access management

On [Microsoft Trust Center](https://servicetrust.microsoft.com/) you can get more in-depth information about audit reports, data protection, security assessment. It have centralized [resources](https://servicetrust.microsoft.com/ViewPage/TrustDocuments) about security, compliance and privacy. Using [Compliance Manager](https://docs.microsoft.com/en-us/microsoft-365/compliance/compliance-manager-overview) you can manage compliance from central location, proactive risk assessment, prepare for compliance reports for audit and get insights and recommended actions.

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

| Command                                         | Description                                                  |
| ----------------------------------------------- | ------------------------------------------------------------ |
| az                                              | Show all available commands.                                 |
| az login                                        | Login to Azure. Default WEB browser should open up and you should choose account you want to use. |
| az logout                                       | Log out to remove access to Azure subscriptions.             |
| az account clear                                | Clear all subscriptions from the CLI's local cache.          |
| az account list --output table                  | Get list of all subscriptions.                               |
| az account set -s "Name or ID of subscription." | Switch to subscription using ID or name.                     |
| az account show                                 | Show currently selected subscription.                        |
| az account list                                 | Show all available subscriptions.                            |
| az subcommand -h                                | Get help information about subcommand (e.g. `az webapp -h` or `az webapp create -h`). |
| az interactive                                  | Start interactive CLI mode with IntelliSense auto completion. |

[![az-interactive.png](https://www.snapagogo.com/images/2020/06/07/az-interactive.png)](https://www.snapagogo.com/image/cmAW35)

## Azure AD users and groups

[Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/fundamentals/active-directory-whatis) is cloud based identity and access management service. You can manage users and groups using portal, [PowerShell](https://docs.microsoft.com/en-us/powershell/azure) or [CLI](https://docs.microsoft.com/en-us/cli/azure).

[![azure-ad.png](https://docs.microsoft.com/en-us/azure/architecture/reference-architectures/identity/images/azure-ad.png)](https://docs.microsoft.com/en-us/azure/architecture/reference-architectures/identity/azure-ad)

### Application registration in Azure AD

Applications should be added to [Azure AD](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-how-applications-are-added) to be able to access services like user authorization and [authentication](https://docs.microsoft.com/en-us/azure/active-directory/develop/authentication-vs-authorization), [SSO](https://docs.microsoft.com/en-us/azure/active-directory/manage-apps/what-is-single-sign-on), role based access control, [OAuth](https://docs.microsoft.com/en-us/azure/active-directory/develop/active-directory-v2-protocols) authorization, application publishing and etc. To create, configure and [manage](https://docs.microsoft.com/en-us/cli/azure/ad/app) application registration you can use [Azure CLI](https://docs.microsoft.com/en-us/azure/media-services/previous/media-services-cli-create-and-configure-aad-app) or [PowerShell](https://docs.microsoft.com/en-us/azure/media-services/previous/media-services-powershell-create-and-configure-aad-app).

#### Azure AD application registration

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

#### Grant application permissions

Grant application and delegated permissions through administrator consent. You must login as a directory administrator.

```bash
az ad app permission admin-consent --id "00000000-0000-0000-0000-000000000000"
```

- **id** - required identifier URI, application ID, or object ID.

#### Create an Azure AD application and configure

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

### Configure application registration permission scopes

For third party applications to request resources on behalf of a user you can use OAuth2 authorization protocol. Scopes are groups of permissions used to define actions which application can perform on behalf of a user. There are delegated and application permissions.

| Delegated permissions                                       | Application permissions                               |
| ----------------------------------------------------------- | ----------------------------------------------------- |
| Application consent is granted on behalf of a specific user | Application consent is granted on behalf of any user  |
| Used by applications that have present signed in user       | Used by application without present of signed in user |

#### OAuth code grant flow

Most basic [sign in flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-protocols-oidc):

1. User opens application.
2. Vendor requests permissions scope through a specialized URL.
3. Identity management system provides a code back to application.
4. Application redeems the code for a token.
5. User application redirects ID token.
6. Vendor validates token and sets session cookie.
7. Secured page is returned to the user.

[![convergence-scenarios-webapp.svg](https://docs.microsoft.com/en-us/azure/active-directory/develop/media/v2-protocols-oidc/convergence-scenarios-webapp.svg)](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-protocols-oidc)

Other flows:

- [Microsoft identity platform and Implicit grant flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-implicit-grant-flow)
- [Microsoft identity platform and OAuth 2.0 authorization code flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-auth-code-flow)
- [Microsoft identity platform and OAuth 2.0 On-Behalf-Of flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-on-behalf-of-flow)
- [Microsoft identity platform and the OAuth 2.0 client credentials flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-client-creds-grant-flow)
- [Microsoft identity platform and the OAuth 2.0 device authorization grant flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth2-device-code)
- [Microsoft identity platform and OAuth 2.0 Resource Owner Password Credentials](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-oauth-ropc)
- [Microsoft identity platform and OAuth 2.0 SAML bearer assertion flow](https://docs.microsoft.com/en-us/azure/active-directory/develop/v2-saml-bearer-assertion)

### Certificates and secrets

When programmatically signing in you need to pass tenant ID, application ID and authentication key. If you store your application secret or certificate in key vault you need to update access policies to allow application access.

You can [manage](https://docs.microsoft.com/en-us/cli/azure/ad/app/credential?view=azure-cli-latest) an application password or certificate credentials. Create an additional client secret with `--append`:

```bash
az ad app credential reset --id "00000000-0000-0000-0000-000000000000" --append
```

Remove `--append` to overwrite instead of appending additional.

To upload an SSL certificate to a web application:

```bash
az webapp config ssl upload --certificate-file pathToPfxFile --certificate-password pfxPassword --name webappname --resource-group resourceGroup
```

- **certificate-file** - the file path for the `.pfx` file.
- **certificate-password**  - the SSL cert password.
- **name** - name of the web application. You can configure the default using `az configure --defaults web=<name>`.
- **resource-group** - name of resource group. You can configure the default group using `az configure --defaults group=<name>`.

To clean up deployment resource group:

```bash
az group delete --name resourceGroupName
```

### Service principal and managed identity

[Service principle](https://docs.microsoft.com/en-us/azure/active-directory/develop/app-objects-and-service-principals) requires to store application credentials in Key Vault for secure storage and access. By using [managed identity](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview) (recommended) we do not need anymore worry about credentials in code, it can be easily enabled for supported services and it is tied to service life cycle, therefore it is managing the creation and automatic renewal of a service principle. To create service principle you can execute below [command](https://docs.microsoft.com/en-us/cli/azure/create-an-azure-service-principal-azure-cli), use [PowerShell](https://docs.microsoft.com/en-us/powershell/azure/create-azure-service-principal-azureps) or [Portal](https://docs.microsoft.com/en-us/azure/active-directory/develop/howto-create-service-principal-portal).

```bash
az ad sp create-for-rbac --name servicePrincipalName
```

To create user assigned managed identity execute below [command](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/how-to-manage-ua-identity-cli):

```bash
az identity create --resource-group resourceGroup --name userAssignedIdentityName
```

- **identity** - managed service Identities.
- **create** - managed service Identities.
- **resource-group** - name of resource group. You can configure the default group.
- **name** - the name of the identity resource.

List user assigned managed identities:

```bash
az identity list -g resourceGroup
```

Delete a user assigned managed identity:

```bash
az identity delete -n userAssignedIdentityName -g resourceGroup
```

Other examples:

- [Configure managed identities for Azure resources on an Azure VM using Azure CLI](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/qs-configure-cli-windows-vm)
- [Assign a managed identity access to a resource using Azure CLI](https://docs.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/howto-assign-access-cli)
- [How to use managed identities for App Service and Azure Functions](https://docs.microsoft.com/en-us/azure/app-service/overview-managed-identity)



### AD identity protection



### AD Privileged Identity Management PIM

- Overview
- Activation
- Configuration
- Access request
- Approval
- Access

https://app.pluralsight.com/library/courses/microsoft-azure-ad-privileged-identity-management-configuring/table-of-contents



## Multi-factor authentication (MFA) and Single Sign-On (SSO)

https://app.pluralsight.com/library/courses/microsoft-azure-multi-factor-authentication-implementing-managing/table-of-contents
https://www.linkedin.com/learning-login/share?forceAccount=false&redirect=https%3A%2F%2Fwww.linkedin.com%2Flearning%2Fmicrosoft-azure-security-technologies-az-500-cert-prep-1-manage-identity-and-access%3Ftrk%3Dshare_ent_url&account=2057564



## Service principal



## Conditional access



## Subscriptions

- Transfer between tenants
- Move subscription to another directory
- Subscription Policies

https://app.pluralsight.com/library/courses/securing-microsoft-azure-subscriptions
https://app.pluralsight.com/library/courses/microsoft-azure-subscription-security-implementing



## Virtual networks

- Overview





- Create VNets and subnets





- Configure user defined routes and VNet peering



- Application security groups

https://app.pluralsight.com/library/courses/microsoft-azure-implement-manage-virtual-networks



## Network security

- Overview
- Network security groups (NSGs)
- Create and configure a NSG

https://app.pluralsight.com/library/courses/microsoft-azure-networks-securing
https://app.pluralsight.com/library/courses/microsoft-azure-host-security-implementing
https://www.linkedin.com/learning-login/share?forceAccount=false&redirect=https%3A%2F%2Fwww.linkedin.com%2Flearning%2Fmicrosoft-azure-security-technologies-az-500-cert-prep-2-implement-platform-protection%3Ftrk%3Dshare_ent_url&account=2057564



## Load balancing services

- Create and configure azure load balancer



## Application gateway

- Configure application gateway



## Application security groups



## Firewall

- Configure azure firewall

### Resource firewall



## Distributed Denial of Service (DDoS)

### Configure DDoS

### Network watcher



## Virtual machines

Overview

Create VM

VM endpoint security

VM system updates

Prepare Application for Azure Kubernetes Service (AKS)

Create Azure Container Registry

Run Application on Kubernetes

Create Kubernetes Cluster

https://app.pluralsight.com/library/courses/microsoft-azure-configuring-virtual-machines



## Role-based access control (RBAC)

- Assign resource roles
- Implement Role-Based Access



## Managed identities



## Azure resource locks

- Implement a Resource Lock



## Azure management groups



## Azure policies

- Implement azure region policy

https://app.pluralsight.com/library/courses/microsoft-azure-configuring-security-services-policies
https://www.linkedin.com/learning-login/share?forceAccount=false&redirect=https%3A%2F%2Fwww.linkedin.com%2Flearning%2Fmicrosoft-azure-security-technologies-az-500-cert-prep-4-policy-and-data-infrastructure%3Ftrk%3Dshare_ent_url&account=2057564



## Containers

### Container registry security



### Instance security configuration



### Container groups



### Container vulnerability management



## AKS security



## Diagnostic logging and log retention

- Log Analytics



## Azure security center

- Overview
- Just in time VM access
- Prevent and respond to threats

https://app.pluralsight.com/library/courses/microsoft-azure-security-managing-update
https://www.linkedin.com/learning-login/share?forceAccount=false&redirect=https%3A%2F%2Fwww.linkedin.com%2Flearning%2Fmicrosoft-azure-security-technologies-az-500-cert-prep-3-manage-security-operations%3Ftrk%3Dshare_ent_url&account=2057564



## Azure monitor and alerts

- Reviewing
- Responding
- Recommendation

https://app.pluralsight.com/library/courses/microsoft-azure-managing-responding-security-alerts
https://app.pluralsight.com/library/courses/microsoft-azure-incident-response-remediation



## Data classification using information protection



## Storage analytic data retention policies

https://app.pluralsight.com/library/courses/microsoft-azure-configuring-data-security-policies



## Data sovereignty with Azure policy



## Azure Key vault and encryption keys

- Create a key vault followed by a Key Secret

https://app.pluralsight.com/library/courses/microsoft-azure-key-vault-configuring-managing
https://www.linkedin.com/learning-login/share?forceAccount=false&redirect=https%3A%2F%2Fwww.linkedin.com%2Flearning%2Fmicrosoft-azure-security-technologies-az-500-cert-prep-5-data-at-rest-app-security-and-key-vault%3Ftrk%3Dshare_ent_url&account=2057564



## Database authentication and auditing



## Azure SQL Services

- Azure SQL database thread detection
- Azure SQL database creation
- Azure SQL database encryption
- Design auditing and cashing strategies
- SQL long term backup retention

https://docs.microsoft.com/en-us/azure/azure-sql/database/security-overview



## Storage Account

- Access control and keys for storage accounts
- Create a Storage Account
- Use storage explorer with Azure Storage



## Security for HDInsight



## Security for Cosmos DB

- Cosmos DB consistency levels



## Azure data lake

- Overview
- Implement security for azure data lake store



## Data security

- Types of data

https://app.pluralsight.com/library/courses/microsoft-azure-data-infrastructure-security-configuring



### Storage service encryption



### Disk encryption

https://app.pluralsight.com/library/courses/microsoft-azure-configuring-encryption-data-rest



### Backup encryption



## Security validations for application development

https://app.pluralsight.com/library/courses/microsoft-azure-securing-application-lifecycle
https://app.pluralsight.com/library/courses/microsoft-azure-applications-securing



## Synthetic security transactions



## Shared Access Signature

- Create and manage SAS

https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas



## SSLTLS certificates



## WEB application protection



## Deployment security

https://app.pluralsight.com/library/courses/microsoft-azure-deployment-security-maintaining



## Security baselines

- Create security baseline

https://app.pluralsight.com/library/courses/microsoft-azure-creating-security-baselines



## Redis



## Elastic Pools



## Service Bus



## References

1. [What is Azure](https://azure.microsoft.com/en-us/overview/what-is-azure)
2. [Azure security documentation](https://docs.microsoft.com/en-us/azure/security)

2. [Azure security fundamentals documentation](https://docs.microsoft.com/en-us/azure/security/fundamentals)