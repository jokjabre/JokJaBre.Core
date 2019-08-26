Add-Type -AssemblyName 'System.Xml.Linq'


$path = 

$file = [System.IO.Path]::Combine($args[0], $args[1], $args[1] + ".csproj")

$doc = [System.Xml.Linq.XDocument]::Load($file)
$elem = $doc.Root.Element("PropertyGroup").Element("Version")
$version = $elem.Value.Split('.')
$newVersion = $version[0] + "." + $version[1] + "." + ([int]::Parse($version[2]) + 1)

$elem.Value = $newVersion
$doc.Save($file)