Add-Type -AssemblyName 'System.Xml.Linq'


function Bump-Version($file)
{
    $doc = [System.Xml.Linq.XDocument]::Load($file)
    $elem = $doc.Root.Element("PropertyGroup").Element("Version")
    $version = $elem.Value.Split('.')
    $newVersion = $version[0] + "." + $version[1] + "." + ([int]::Parse($version[2]) + 1)

    $elem.Value = $newVersion
    $doc.Save($file)

    $projName = [System.IO.Path]::GetFileNameWithoutExtension($file)
    Write-Host "Version of $projName bummped to $newVersion"
}

#======================MAIN=============

$projects = @("JokJaBre.Core.API", "JokJaBre.Core.Identity", "JokJaBre.Core.Objects")

foreach($proj in $projects)
{
    $csProj = [System.IO.Path]::Combine($args[0], $proj, $proj + ".csproj")
    Bump-Version $csProj
}
