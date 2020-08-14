<html>
<meta charset="UTF-8">

<?
$server = "localhost";
$port = "3306";
$user = "root";
$pass = "";
$database = "vtmanager";

	$link = mysql_connect($server, $user, $pass);
	
    if(!mysql_select_db($database))
	{
		echo'Сервер или база не найдены \n';
		die(mysql_error());
	}	
	else
	{
		echo'server='.$server.'&port='.$port.'&user='.$user.'&pass='.$pass.'&database='.$database.'';
	}
	

?>
</html>