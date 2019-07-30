[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SqlServer.SMO") | Out-Null;
[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SqlServer.SmoExtended") | Out-Null;
[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SqlServer.ConnectionInfo") | Out-Null;
[System.Reflection.Assembly]::LoadWithPartialName("Microsoft.SqlServer.SmoEnum") | Out-Null;
Add-PSSnapin Microsoft.SharePoint.PowerShell;

$server = New-Object ("Microsoft.SqlServer.Management.Smo.Server") $server

$sqlConnection = new-object System.Data.SqlClient.SqlConnection "Server=;Initial Catalog=;Persist Security Info=True;User ID=;Password="
$sqlConnection.Open()
$sqlCommand = $sqlConnection.CreateCommand()
$query = "SELECT TABLE_NAME FROM DATABASE.INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
 
$sqlCommand.CommandText =$query;

$sqlReader = $sqlCommand.ExecuteReader();

while ($sqlReader.Read()){

$dados=$sqlReader["TABLE_NAME"].ToString();

write-host($dados);

}
