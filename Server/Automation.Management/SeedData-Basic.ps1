$ErrorActionPreference = "Stop"
Import-Module (Join-Path -Path $PSScriptRoot -ChildPath "\Dk.Schalck.LinkSink.Automation.Management.dll")

# Adding the device operating systems
Add-ProjectRole -Id "10" -Name "ProjectAdministrator" -DisplayName "Can administer a project"
Add-ProjectRole -Id "20" -Name "SiteAdministrator" -DisplayName "Can administer the administrative areas"
Add-ProjectRole -Id "30" -Name "ProjectReader" -DisplayName "Can use the information on a project"
Add-ProjectRole -Id "40" -Name "ProjectContributor" -DisplayName "Can add and use the information on a project"


