<html>
<meta charset="UTF-8">
<head>
<meta charset="UTF-8">
    <title>Тест</title>
</head>
<?
	mysql_set_charset('utf8');
    include("db_vtmanager.php");
    $link = mysql_connect($server, $user, $pass);
    if(!mysql_select_db($database)) die(mysql_error());
 
    
    $query = mysql_query("SELECT id, pass FROM personal WHERE login='".mysql_real_escape_string($_POST['login'])."' LIMIT 1");
    $data = mysql_fetch_assoc($query);
    $hashed = hash('sha256',($_POST['password']));
	
    if(isset($_POST['btn_auth']))
    {
        if($data['pass'] === $_POST['password'])
        {
              echo'!OK Успешная авторизация';
        }
        else
        {
              echo'Неверные данные';
        }
    }
    else
    {
        echo('
        <form method="post">
        Логин: <input type="text" name="login" />
        Пароль: <input type="password" name="password" />
        <input type="submit" value="Войти" name="btn_auth" />
        </form>
        ');
    }
?>
</html>