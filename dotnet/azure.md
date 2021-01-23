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

| Command                                         | Description                                                                                       |
| ----------------------------------------------- | ------------------------------------------------------------------------------------------------- |
| az                                              | Show all available commands.                                                                      |
| az login                                        | Login to Azure. Default WEB browser should open up and you should choose account you want to use. |
| az logout                                       | Log out to remove access to Azure subscriptions.                                                  |
| az account clear                                | Clear all subscriptions from the CLI's local cache.                                               |
| az account list --output table                  | Get list of all subscriptions.                                                                    |
| az account set -s "Name or ID of subscription." | Switch to subscription using ID or name.                                                          |
| az account show                                 | Show currently selected subscription.                                                             |
| az account list                                 | Show all available subscriptions.                                                                 |
| az subcommand -h                                | Get help information about subcommand (e.g. `az webapp -h` or `az webapp create -h`).             |
| az interactive                                  | Start interactive CLI mode with IntelliSense auto completion.                                     |

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
az group delete --name myResourceGroup --yes --no-wait
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

## Implement IaaS solutions

### Provision VMs

To create Ubuntu LTS virtual machine execute [az vm](https://docs.microsoft.com/en-us/cli/azure/vm?view=azure-cli-latest):

```bash
az vm create \
  --resource-group myResourceGroup \
  --name myVM \
  --image UbuntuLTS \
  --admin-username azureuser \
  --generate-ssh-keys
```

SSH key files will be automatically generated under `~/.ssh` to allow SSH access to the VM. When you first to connect to VM you will be asked to you accept identifier and it will be saved in file `~/.ssh/known_hosts`.

Delete VM:

```bash
az vm delete --name MyVm --resource-group MyResourceGroup --yes
```

Stop or start VM:

```bash
az vm stop --resource-group myResourceGroupVM --name myVM
az vm start --resource-group myResourceGroupVM --name myVM
```

[Quickstart: Create a Linux virtual machine with the Azure CLI](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/quick-create-cli)

[Tutorial: Create and Manage Linux VMs with the Azure CLI](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/tutorial-manage-vm)

### Configure VMs for remote access

Connect to virtual machine:

```bash
ssh azureuser@publicIpAddress
```

Connect with key file:

```bash
ssh -i ./myVM_key.pem azureuser@publicIpAddress
```

Create and configure an SSH config file:

```bash
touch ~/.ssh/config
echo "Host myVm\n\tHostname publicIpAddress\n\tUser azureuser" > ~/.ssh/config
```

Configuration file allows to connect using command `ssh myVm`.

Creates a network security group rule on port 3389:

```bash
az vm open-port --resource-group myResourceGroup --name myVM --port 3389
```

[Install and configure Remote Desktop to connect to a Linux VM in Azure](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/use-remote-desktop)

[Secure your management ports with just-in-time access](https://docs.microsoft.com/en-us/azure/security-center/security-center-just-in-time)

[Quick steps: Create and use an SSH public-private key pair for Linux VMs in Azure](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/mac-create-ssh-keys)

### Create ARM template

Azure Resource Manager (ARM) templates are used for implementation of infrastructure as code (JSON) for your Azure solutions.

You can deploy a [QuickStart ARM Template](https://github.com/Azure/azure-quickstart-templates) from GitHub or you can generate an ARM template based on an existing resource group via the Portal.

Deployment command using ARM template, to deploy to a resource group:

```bash
templateFile="path/to/the/template/file}"
az deployment group create \
  --name deploymentName \
  --resource-group myResourceGroup \
  --template-file $templateFile
```

You can [verify deployment](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/template-tutorial-create-first-template?tabs=azure-cli#verify-deployment) in the [Azure portal](https://portal.azure.com).

You can change [deployment scope](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/deploy-cli#deployment-scope).

Use the [what-if](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/template-deploy-what-if?tabs=azure-cli#azure-cli) operation to verify that the template makes the changes that you expect and to validates the template for errors:

```bash
az deployment group what-if
az deployment sub what-if
az deployment mg what-if
az deployment tenant what-if
```

There is Azure SDK for [deployment What-if operation](https://docs.microsoft.com/en-us/dotnet/api/microsoft.azure.management.resourcemanager.models.deploymentwhatif?view=azure-dotnet).

[What are ARM templates?](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/overview)

[Tutorial: Create and deploy your first ARM template](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/template-tutorial-create-first-template?tabs=azure-cli)

[Extend Azure Resource Manager template functionality](https://docs.microsoft.com/en-us/azure/architecture/building-blocks/extending-templates)

[Deploy resources with ARM templates and Azure CLI](https://docs.microsoft.com/en-us/azure/azure-resource-manager/templates/deploy-cli)

### Create container images for solutions by using Docker

[Install](https://docs.docker.com/engine/install/ubuntu) docker:

```bash
sudo apt-get update &&

sudo apt-get install \
    apt-transport-https \
    ca-certificates \
    curl \
    gnupg-agent \
    software-properties-common  &&

curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo apt-key add - &&

sudo add-apt-repository \
   "deb [arch=amd64] https://download.docker.com/linux/ubuntu \
   $(lsb_release -cs) \
   stable"  &&

sudo apt-get update  &&

sudo apt-get install docker-ce docker-ce-cli containerd.io
```

Check `docker` service status or run `hello-world` image:

```bash
sudo systemctl status docker
sudo docker run hello-world
```

Create Ubuntu image and go to container bash session:

```bash
docker run -it ubuntu bash
```

**NOTE:** Write `exit` to quit bash session.

Add current user to group therefore you will not need `sudo` command:

```bash
sudo groupadd docker
sudo usermod -aG docker $USER
```

**NOTE:** You may need to restart computer.

Create basic web application and build publish files:

```bash
dotnet new blazorwasm --hosted -o BlazorTestApp &&
cd ./BlazorTestApp
dotnet publish
```

Test application locally:

```bash
dotnet ./Server/bin/Debug/netcoreapp3.1/publish/BlazorTestApp.Server.dll
```

You should be able to access page `http://localhost:5000`.

Create `Dockerfile` file in solution root directory with content:

```Dockerfile
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "BlazorTestApp.Server.dll"]
```

Build docker image:

```bash
docker build -t blazortestapp .
```

You can verify that image is created by listing all images `docker images`.

Run test application from docker:

```bash
docker run -d -p 80:80 blazortestapp:latest --rm
```

You will be able to access page `http://localhost/`. You can check all running containers with command `docker ps`.

[Tutorial: Build and deploy container images in the cloud with Azure Container Registry Tasks](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-tutorial-quick-task)

[Tutorial: Create container images on a Linux Service Fabric cluster](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-tutorial-create-container-images)

[Tutorial: Create a container image for deployment to Azure Container Instances](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-tutorial-prepare-app)

[Build and store container images with Azure Container Registry](https://docs.microsoft.com/en-us/learn/modules/build-and-store-container-images)

### Publish an image to the Azure Container Registry

Create Azure Container Registry (ACR):

```bash
az acr create --resource-group myResourceGroup --name myContainerRegistry --sku Standard --location westeurope
```

[Login](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-authentication#individual-login-with-azure-ad) to registry:

```bash
az acr login --name myContainerRegistry --expose-token
```

**NOTE:** Token will be used later as password when creating container.

Create an alias of the image and push to repository:

```bash
docker tag blazortestapp mycontainerregistry.azurecr.io/samples/blazortestapp
docker push mycontainerregistry.azurecr.io/samples/blazortestapp:latest
```

Pull and start the image from your registry:

```bash
docker pull mycontainerregistry.azurecr.io/samples/blazortestapp
docker run --rm -p 80:80 mycontainerregistry.azurecr.io/samples/blazortestapp
```

Command to remove the image:

```bash
docker rmi mycontainerregistry.azurecr.io/samples/blazortestapp
az acr repository delete --name mycontainerregistry --image samples/blazortestapp:latest
```

[Push your first image to a private Docker container registry using the Docker CLI](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-get-started-docker-cli)

### Run container by using Azure Container Instance

List all available container images:

```bash
az acr repository list --name myContainerRegistry --output table
```

[Enable Admin](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-authentication#admin-account) user:

```bash
az acr update -n myContainerRegistry --admin-enabled true
```

[Create](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-tutorial-deploy-app#deploy-container) a container in a container group with 1 core and 1Gb of memory:

```bash
az container create \
  --resource-group myResourceGroup \
  --name blazor-test-app-container \
  --image mycontainerregistry.azurecr.io/samples/blazortestapp \
  --cpu 1 \
  --memory 1 \
  --dns-name-label blazortestapp \
  --ports 80 443
```

**NOTE:** Use [user name](https://docs.microsoft.com/en-us/azure/container-registry/container-registry-authentication#az-acr-login-with---expose-token) `00000000-0000-0000-0000-000000000000` and use token as a password. After container is created you should be able to access web page `blazortestapp.westeurope.azurecontainer.io`.

[Run Docker containers with Azure Container Instances](https://docs.microsoft.com/en-us/learn/modules/run-docker-with-azure-container-instances)

[What is Azure Container Instances?](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-overview)

[Quickstart: Deploy a container instance in Azure using the Azure CLI](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-quickstart)

[Tutorial: Deploy a container application to Azure Container Instances](https://docs.microsoft.com/en-us/azure/container-instances/container-instances-tutorial-deploy-app)

## Create Azure App Service Web Apps

### Create an Azure App Service Web App

Create WEB app and test it locally:

```bash
dotnet new blazorserver -o  TestBlazorApp &&
cd ./TestBlazorApp &&
dotnet run
```

Initialize git repository locally:

```bash
dotnet new gitignore &&
git init &&
git add . &&
git commit -m "Initial commit"
```

Create an Azure App Service plan

```bash
az appservice plan create --name myAppServicePlan --resource-group myResourceGroup --sku F1 --is-linux
```

Configure a deployment user used for push git repository to Azure:

```bash
az webapp deployment user set --user-name my-deployment-user --password my-deployment-user-password
```

**NOTE:** Remember user name and password. You can use it for all your Azure deployments.

Create a web app

```bash
az webapp create --resource-group myResourceGroup --plan myAppServicePlan --name MyTestBlazorApp --runtime "DOTNETCORE|3.1" --deployment-local-git
```

**NOTE:** We will use `deploymentLocalGitUrl` property to push data from local git repository.

Push to Azure from local git:

```bash
git remote add azure https://my-deployment-user@mytestblazorapp.scm.azurewebsites.net/MyTestBlazorApp.git &&
git push azure master
```

**NOTE:** You will be asked to enter deployment user password. After deployment is finished you should be able to access your web page `mytestblazorapp.azurewebsites.net`. For managing web app you can use `mytestblazorapp.scm.azurewebsites.net`.

Get the details of a web app:

```bash
az webapp show --name MyTestBlazorApp --resource-group myResourceGroup
```

[Quickstart: Create an ASP.NET Core web app in Azure](https://docs.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?pivots=platform-linux)

### Enable diagnostics logging

To enable application logging fallow [instructions](https://docs.microsoft.com/en-us/azure/app-service/troubleshoot-diagnostic-logs#enable-application-logging-linuxcontainer) or execute command:

```bash
az webapp log config --application-logging filesystem --level verbose --name MyTestBlazorApp --resource-group myResourceGroup
```

**NOTE:** Allowed application-logging values: `azureblobstorage`, `filesystem`, `off`.

To enable docker container logging  (STDOUT and STDERR output) to filesystem:

```bash
az webapp log config --docker-container-logging filesystem --name MyTestBlazorApp --resource-group myResourceGroup
```

**NOTE:** Allowed docker-container-logging values: `filesystem`, `off`.

Get last logs from web app:

```bash
az webapp log tail --name MyTestBlazorApp --resource-group myResourceGroup
```

[Enable diagnostics logging for apps in Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/troubleshoot-diagnostic-logs)

[Capture Web Application Logs with App Service Diagnostics Logging](https://docs.microsoft.com/en-us/learn/modules/capture-application-logs-app-service)

### Deploy code to a web app

To be able to deploy dotnet project as a ZIP file you need to publish project:

```bash
dotnet publish -c Release -o ../PublishedFiles &&
cd ../PublishedFiles
```

Create ZIP of all published files:

```bash
zip -r ../TestBlazorApp.zip . &&
cd ..
```

Deploy ZIP file:

```bash
az webapp deployment source config-zip --resource-group myResourceGroup --name MyTestBlazorApp --src ./TestBlazorApp.zip
```

[Deploy your app to Azure App Service with a ZIP or WAR file](https://docs.microsoft.com/en-us/azure/app-service/deploy-zip)

[Deploy an Azure Web App](https://docs.microsoft.com/en-us/azure/devops/pipelines/targets/webapp?view=azure-devops&tabs=yaml)

[Provision and deploy microservices predictably in Azure](https://docs.microsoft.com/en-us/azure/app-service/deploy-complex-application-predictably)

[Deploy a custom container to App Service using GitHub Actions](https://docs.microsoft.com/en-us/azure/app-service/deploy-container-github-action?tabs=publish-profile)

### Configure web app settings including SSL, API and connection strings

Show all settings and their values of the previously created web app:

```bash
az webapp config appsettings list --name MyTestBlazorApp --resource-group myResourceGroup
```

[Set or delete](https://docs.microsoft.com/en-us/azure/app-service/configure-common#automate-app-settings-with-the-azure-cli) setting:

```bash
az webapp config appsettings set --name MyTestBlazorApp --resource-group myResourceGroup --settings <setting-name>="<value>"
az webapp config appsettings delete --name MyTestBlazorApp --resource-group myResourceGroup --setting-names {<names>}
```

[Custom configuration and application settings in Azure Web Sites](https://azure.microsoft.com/en-us/resources/videos/configuration-and-app-settings-of-azure-web-sites)

[Configure an App Service app in the Azure portal](https://docs.microsoft.com/en-us/azure/app-service/configure-common)

[Buy a custom domain name for Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/manage-custom-dns-buy-domain)

[Add a TLS/SSL certificate in Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/configure-ssl-certificate)

### Implement autoscaling rules, including scheduled autoscaling and scaling by operational or system metrics

Scale an App Service app to B1(Basic Small):

```bash
az appservice plan update --name myAppServicePlan --resource-group myResourceGroup --sku B1
```

Define an auto scale setting:

```bash
az monitor autoscale create \
  --resource-group myResourceGroup \
  --resource-type "Microsoft.Web/serverfarms" \
  --resource myAppServicePlan \
  --name MyAutoScale \
  --count 2
```

List all profiles:

```bash
az monitor autoscale profile list --resource-group myResourceGroup --autoscale-name MyAutoScale
```

**NOTE:** Profile name will be needed if default does not exist.

To get resource type of web app you can use [jshon](http://kmkeen.com/jshon) tool:

```bash
az webapp show --name MyTestBlazorApp --resource-group myResourceGroup | jshon -e type
```

Create rule for web app:

```bash
az monitor autoscale rule create \
  --resource-group myResourceGroup \
  --resource MyTestBlazorApp \
  --resource-type 'Microsoft.Web/sites' \
  --autoscale-name MyAutoScale \
  --profile-name ProfileName \
  --condition "Requests >= 200 avg 5m" \
  --scale out 1
```

[Scale up an app in Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/manage-scale-up)

[Get started with Autoscale in Azure](https://docs.microsoft.com/en-us/azure/azure-monitor/platform/autoscale-get-started)

## Implement Azure functions

Install the Azure Functions Core Tools using [instruction](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Ccsharp%2Cbash#install-the-azure-functions-core-tools) or execute below commands for Ubuntu 20.04:

```bash
wget -q https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb &&
sudo dpkg -i packages-microsoft-prod.deb &&
sudo apt-get update &&
sudo apt-get install azure-functions-core-tools-3
```

Validate that installation succeeded:

```bash
func
```

Create a test function application in the current folder:

```bash
func init TestFunctionProject --worker-runtime dotnet
```

### Implement input and output bindings for a function

Triggers and bindings are configured by decorating methods and parameters with C# attributes in class library or in other cases updating `function.json` (eg. Azure portal).

- `Triggers` - Input into function what cause a function to run. It have data which provides payload of the function. Biding direction is always `in`.
- `Bindings` - Function can have input and / or output binding(s), binding direction can be `in` or `out` (or in some cases special direction `inout`). Binding data provided as parameters allows function connect to other [services](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings?tabs=csharp#supported-bindings).

#### Bindings to Blob storage

C# [code examples](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings?tabs=csharp#bindings-code-examples) of biding to Blob storage can be found in below links:

- [Trigger](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp#example)
- [Input](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-input?tabs=csharp#example)
- [Output](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-output?tabs=csharp#example)

#### Blob storage trigger example

You can use [Azure storage emulator](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-emulator) open source solution [Azurite](https://github.com/azure/azurite) for local Blob storage on your computer.

Option to install Azurite:

- [Visual Studio Code extension](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite#install-and-run-the-azurite-visual-studio-code-extension)
- [NPM](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite#install-and-run-azurite-by-using-npm)
- [Docker image](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite#install-and-run-the-azurite-docker-image)
- [NuGet](https://github.com/azure/azurite#nuget)
- [Build from the GitHub repository](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite#clone-build-and-run-azurite-from-the-github-repository)

`Option 1` - Start azurite from [docker image](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite#install-and-run-the-azurite-docker-image). Create local folder for data persistence `~/azurite` before executing command:

```bash
docker run -p 10000:10000 -p 10001:10001 -v ~/azurite:/data mcr.microsoft.com/azure-storage/azurite
```

`Option 2` - Install locally. Command to install NPM and Azurite:

```bash
sudo snap install node --classic &&
sudo npm install -g azurite &&
azurite -v
```

You can start service using below command and you can access it using [Azure Storage Explorer](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite#microsoft-azure-storage-explorer).

```bash
mkdir ~/azurite &&
azurite --silent --location ~/azurite --debug ~/azurite/debug.log --blobPort 10000
```

You can use [func CLI](https://docs.microsoft.com/en-us/azure/azure-functions/create-first-function-cli-csharp?tabs=azure-cli) (to get full template list execute `func templates list`) or dotnet templates (only C# and F# languages supported) to generate source code from [templates](https://github.com/Azure/azure-functions-templates).
To install [dotnet templates](https://github.com/Azure/azure-functions-templates/tree/dev/Functions.Templates/Templates/BlobTrigger-CSharp) and create function for [Azure Blob Storage trigger](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-blob-trigger?tabs=csharp) execute commands:

```bash
dotnet new -i Azure.Functions.Templates &&
dotnet new blob --name BlobStorageExample
```

**NOTE:** Function project can be also initialized using installed template with command `dotnet new func -o TestFunctionProject`.

Generated function source code should look like:

```csharp
[FunctionName("BlobStorageExample")]
public static void Run([BlobTrigger("samples-workitems/{name}", Connection = "")]Stream myBlob, string name, ILogger log)
{
    log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
}
```

**NOTE:** [Connection string](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azurite#connection-strings) `UseDevelopmentStorage=true` for Azurite should be automatically placed into `local.settings.json`.

[Run](https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Ccsharp%2Cbash#start) function locally:

```bash
func start --build --verbose
```

**NOTE:** Function will be triggered every time any file to `samples-workitems` blob container is uploaded, you will be able to see log message with file name and size in bytes.

[Azure Functions triggers and bindings concepts](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings?tabs=csharp)

[Azure Functions trigger and binding example](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-example)

### Implement function triggers by using data operations, timers, and webhooks

[Azure Functions triggers and bindings concepts](https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings?tabs=csharp)

[Azure Functions trigger and binding example](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-example)

[Azure Functions HTTP triggers and bindings overview](https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-http-webhook)

### Implement Azure Durable Functions

[What are Durable Functions?](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-overview?tabs=csharp)

[Create your first durable function in C#](https://docs.microsoft.com/en-us/azure/azure-functions/durable/durable-functions-create-first-csharp?pivots=code-editor-vscode)

## References

1. [What is Azure](https://azure.microsoft.com/en-us/overview/what-is-azure)
2. [Azure security documentation](https://docs.microsoft.com/en-us/azure/security)
3. [Azure security fundamentals documentation](https://docs.microsoft.com/en-us/azure/security/fundamentals)