Creating a development environment
==

1. Create a Windows 2012 Virtual Machine
2. Run the following as an administrator in PowerShell CLI
    
        Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope LocalMachine
        iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))
        choco install visualstudio2013professional "/Features:'WebTools'"
        choco install sourcetree
        Import-Module ServerManager
        Add-WindowsFeature -Name Web-Common-Http,Web-Asp-Net,Web-Net-Ext,Web-ISAPI-Ext,Web-ISAPI-Filter,Web-Http-Logging,Web-Request-Monitor,Web-Basic-Auth,Web-Windows-Auth,Web-Filtering,WebPerformance,Web-Mgmt-Console,Web-Mgmt-Compat,Web-Server,WAS
    	 & c:\Windows\Microsoft.NET\Framework64\v4.0\aspnet_regiis.exe /i


Creating a test environment
==

1. Create a Windows 2012 Virtual Machine
2. Run the following as an administrator in PowerShell CLI

     	Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope LocalMachine
        iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))
     	Import-Module ServerManager
    	Add-WindowsFeature -Name Web-Common-Http,Web-Asp-Net,Web-Net-Ext,Web-ISAPI-Ext,Web-ISAPI-Filter,Web-Http-Logging,Web-Request-Monitor,Web-Basic-Auth,Web-Windows-Auth,Web-Filtering,WebPerformance,Web-Mgmt-Console,Web-Mgmt-Compat,Web-Server,WAS
	   	& c:\Windows\Microsoft.NET\Framework64\v4.0\aspnet_regiis.exe /i
		choco install microsoft-build-tools 
		choco install git 
		cd c:\
		mkdir development
		cd development
		git clone https://github.com/DimensionDataCBUSydney/CaaS.OpenStack-Facade.git
		nuget.exe restore CaaS.OpenStack-Facade\src\CaaS.OpenStack.API.sln
		msbuild CaaS.OpenStack-Facade\src\CaaS.OpenStack.API.sln 