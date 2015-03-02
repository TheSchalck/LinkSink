$ErrorActionPreference = "Stop"
Import-Module (Join-Path -Path $PSScriptRoot -ChildPath "\Dk.Schalck.LinkSink.Automation.Management.dll")

# Adding the device operating systems
Add-ProjectRole -Id "591EB9CD-FC9A-D949-98DC-124FA200A109" -Name "ProjectAdministrator" -DisplayName "Can administer a project"
Add-ProjectRole -Id "D46FCDFF-7803-9BF6-68B8-79F8555FCA60" -Name "SiteAdministrator" -DisplayName "Can administer the administrative areas"
Add-ProjectRole -Id "4CBC9875-9562-260D-10AF-0FAA3BA33659" -Name "ProjectReader" -DisplayName "Can use the information on a project"
Add-ProjectRole -Id "C0A63A47-A982-71E4-769A-3181AC0F1610" -Name "ProjectContributor" -DisplayName "Can add and use the information on a project"


