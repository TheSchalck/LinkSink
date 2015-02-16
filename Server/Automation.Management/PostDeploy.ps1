$ErrorActionPreference = "Stop"
Import-Module (Join-Path -Path $PSScriptRoot -ChildPath "\Dk.Schalck.LinkSink.Automation.Management.dll")

	$runAll = $TRUE
	Write-Host "Running all"


	#MessageStore.Entity
	Write-Host "Updating LinkSink database"
	Update-LinkSinkDatabase

