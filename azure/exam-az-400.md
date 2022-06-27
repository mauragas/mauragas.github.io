# Exam AZ-400

- [Exam AZ-400: Designing and Implementing Microsoft DevOps Solutions](https://docs.microsoft.com/en-us/learn/certifications/exams/az-400)

# Configure processes and communications (10—15%)

## Configure activity traceability and flow of work

- plan and implement a structure for the flow of work and feedback cycles
- identify appropriate metrics related to flow of work, such as cycle times, time to recovery, and lead time
- integrate pipelines with work item tracking tools, such as Azure DevOps and GitHub
- implement traceability policies decided by development
- integrate a repository with Azure Boards

## Configure collaboration and communication

- communicate actionable information by using custom dashboards in Azure DevOps
- document a project by using tools, such as wikis and process diagrams
- configure release documentation, including release notes and API documentation
- automate creation of documentation from Git history
- configure notifications by using webhooks

# Design and implement source control (15—20%)

## Design and implement a source control strategy

- design and implement an authentication strategy
- design a strategy for managing large files, including Git LFS and git-fat
- design a strategy for scaling and optimizing a Git repository, including Scalar and cross-repository sharing
- implement workflow hooks

## Plan and implement branching strategies for the source code

- design a branch strategy, including trunk-based, feature branch, and release branch
- design and implement a pull request workflow by using branch policies and branch protections
- implement branch merging restrictions by using branch policies and branch protections

## Configure and manage repositories

- integrate GitHub repositories with Azure Pipelines, one of the services in Azure DevOps
- configure permissions in the source control repository
- configure tags to organize the source control repository
- recover data by using Git commands
- purge data from source control

# Design and implement build and release pipelines (40—45%)

## Design and implement pipeline automation

- integrate pipelines with external tools, including dependency scanning, security scanning, and code coverage
- design and implement quality and release gates, including security and governance
- design integration of automated tests into a pipeline
- design and implement a comprehensive testing strategy
- implement orchestration of tools, such as GitHub Actions and Azure Pipelines

## Design and implement a package management strategy

- design a package management implementation that uses Azure Artifacts, GitHub Packages, NuGet, and npm
- design and implement package feeds, including upstream sources
- design and implement a dependency versioning strategy for code assets and packages, including semantic versioning and date-based
- design and implement a versioning strategy for pipeline artifacts

## Design and implement pipelines

- select a deployment automation solution, including GitHub Actions and Azure Pipelines
- design and implement an agent infrastructure, including cost, tool selection, licenses, connectivity, and maintainability
- develop and implement pipeline trigger rules
- develop pipelines, including classic and YAML
- design and implement a strategy for job execution order, including parallelism and multi-stage
- develop complex pipeline scenarios, such as containerized agents and hybrid
- configure and manage self-hosted agents, including virtual machine (VM) templates and containerization
- create reusable pipeline elements, including YAML templates, task groups, variables, and variable groups
- design and implement checks and approvals by using YAML environments

## Design and implement deployments

- design a deployment strategy, including blue/green, canary, ring, progressive exposure, feature flags, and A/B testing
- design a pipeline to ensure reliable order of dependency deployments
- plan for minimizing downtime during deployments by using VIP swap, load balancer, and rolling deployments
- design a hotfix path plan for responding to high-priority code fixes
- implement load balancing for deployment, including Azure Traffic Manager and the Web Apps feature of Azure App Service
- implement feature flags by using Azure App Configuration Feature Manager
- implement application deployment by using containers, binary, and scripts

## Design and implement infrastructure as code (IaC)

- recommend a configuration management technology for application infrastructure
- implement a configuration management strategy for application infrastructure, including IaC
- define an IaC strategy, including source control and automation of testing and deployment
- design and implement desired state configuration for environments, including Azure Automation State Configuration, Azure Resource Manager, Bicep, and Azure Policy guest configuration

## Maintain pipelines

- monitor pipeline health, including failure rate, duration, and flaky tests
- optimize pipelines for cost, time, performance, and reliability
- analyze pipeline load to determine agent configuration and capacity
- design and implement a retention strategy for pipeline artifacts and dependencies

# Develop a security and compliance plan (10—15%)

## Design and implement a strategy for managing sensitive information in automation

- implement and manage service connections
- implement and manage personal access tokens
- implement and manage secrets, keys, and certificates by using Azure Key Vault, GitHub secrets, and Azure Pipelines secrets
- design and implement a strategy for managing sensitive files during deployment
- design pipelines to prevent leakage of sensitive information

## Automate security and compliance scanning

- automate analysis of source code by using GitHub code scanning, GitHub secrets scanning, pipeline-based scans, and SonarQube
- automate security scanning, including container scanning and OWASP ZAP
- automate analysis of licensing, vulnerabilities, and versioning of open-source components by using WhiteSource and GitHub Dependency Scanning

# Implement an instrumentation strategy (10—15%)

## Configure monitoring for a DevOps environment

- configure and integrate monitoring by using Azure Monitor
- configure and integrate with monitoring tools, such as Azure Monitor and Application Insights
- manage access control to the monitoring platform
- configure alerts for pipeline events

## Analyze metrics

- inspect distributed tracing by using Application Insights
- inspect application performance indicators
- inspect infrastructure performance indicators, including CPU, memory, disk, and network
- identify and monitor metrics for business value
- analyze usage metrics by using Application Insight
- interrogate logs using basic Kusto Query Language (KQL) queries

# Microsoft Learn Paths

- [Get started on a DevOps transformation journey](https://docs.microsoft.com/en-us/learn/paths/az-400-get-started-devops-transformation-journey/)
- [Development for enterprise DevOps](https://docs.microsoft.com/en-us/learn/paths/az-400-work-git-for-enterprise-devops/)
- [Implement CI with Azure Pipelines and GitHub Actions](https://docs.microsoft.com/en-us/learn/paths/az-400-implement-ci-azure-pipelines-github-actions/)
- [Design and implement a release strategy](https://docs.microsoft.com/en-us/learn/paths/az-400-design-implement-release-strategy/)
- [Implement a secure continuous deployment using Azure Pipelines](https://docs.microsoft.com/en-us/learn/paths/az-400-implement-secure-continuous-deployment/)
- [Manage infrastructure as code using Azure and DSC](https://docs.microsoft.com/en-us/learn/paths/az-400-manage-infrastructure-as-code-using-azure/)
- [Design and implement a dependency management strategy](https://docs.microsoft.com/en-us/learn/paths/az-400-design-implement-dependency-management-strategy/)
- [Create and manage containers using Docker and Kubernetes](https://docs.microsoft.com/en-us/learn/paths/az-400-create-manage-containers-using-docker-kubernetes/)
- [Implement continuous feedback](https://docs.microsoft.com/en-us/learn/paths/az-400-implement-continuous-feedback/)
- [Implement security and validate code bases for compliance](https://docs.microsoft.com/en-us/learn/paths/az-400-implement-security-validate-code-bases-compliance/)

# Online Courses

- [LinkedIn Learning: Prepare for the Designing and Implementing Microsoft DevOps Solutions (AZ-400) Exam](https://www.linkedin.com/learning/paths/prepare-for-the-designing-and-implementing-microsoft-devops-solutions-az-400-exam)
- [Pluralsight: Designing and Implementing Microsoft DevOps Solutions (AZ-400)](https://app.pluralsight.com/paths/certificate/designing-and-implementing-microsoft-devops-solutions-az-400)
