$ProjectDir=$args[0]
$ConfigurationName=$args[1]
Write-Host "ProjectDir: $ProjectDir"
Write-Host "ConfigurationName: $ConfigurationName"
$gorilla="GORILLA"
$debug="DEBUG"
$ManifestPath = $ProjectDir + "Properties\AndroidManifest.xml"

Write-Host "ManifestPath: $ManifestPath"

[xml] $xdoc = Get-Content $ManifestPath
Try
{
$package = $xdoc.manifest.package
Write-Host "Current Package Name: $package"
If ($ConfigurationName -eq "Release") 
{ 

    $package = $package.Replace($debug, "").Replace($gorilla, "") 
	Write-Host "Set Release: $package"
}
If ($ConfigurationName -eq "Debug") 
{ 
    $package = $package.Replace($gorilla, "").Replace($debug, "") + $debug
	Write-Host "Set Debug: $package"
}
If ($ConfigurationName -eq "Gorilla") 
{ 
    $package = $package.Replace($gorilla, "").Replace($debug, "")  + $gorilla 
	Write-Host "Set Gorilla: $package"
}

If ($package -ne $xdoc.manifest.package) 
{
    $xdoc.manifest.package = $package
    $xdoc.Save($ManifestPath)
    Write-Host "AndroidManifest.xml package name updated to $package"
}
}
Catch
{
    $ErrorMessage = $_.Exception.Message
    $FailedItem = $_.Exception.ItemName
    write-output "ProjectDir: $ProjectDir" | add-content $home\Desktop\output.txt
write-output "ConfigurationName: $ConfigurationName" | add-content $home\Desktop\output.txt
write-output "ManifestPath: $ManifestPath" | add-content $home\Desktop\output.txt
   write-output $ErrorMessage | add-content $home\Desktop\output.txt
    write-output "Item" | add-content $home\Desktop\output.txt
    write-output $FailedItem | add-content $home\Desktop\output.txt

    Break
}