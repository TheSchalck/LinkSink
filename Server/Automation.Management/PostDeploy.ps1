$ErrorActionPreference = "Stop"
Import-Module (Join-Path -Path $PSScriptRoot -ChildPath "\Dk.Schalck.LinkSink.Automation.Management.dll")

	$runAll = $TRUE
	Write-Host "Running all"


	#LinkSink.Entity
	Write-Host "Updating LinkSink database"
	Update-LinkSinkDatabase
	Write-Host "Importing required data"
	& (Join-Path -Path $PSScriptRoot -ChildPath "\SeedData-Basic.ps1") 

