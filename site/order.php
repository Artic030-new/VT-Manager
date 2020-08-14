<?
	@mysql_set_charset('utf8');
    include("db.php");
	
    $link = @mysql_connect($server, $user, $pass);
    if(!@mysql_select_db($database)) die(mysql_error());
    $query = @mysql_query("SELECT id, pass FROM users WHERE login='".mysql_real_escape_string($_POST['login'])."' LIMIT 1");
    $data = @mysql_fetch_assoc($query);
	
    if(isset($_POST['order']))
	{
		$user =  $_POST['user'];
		$db_user_id = @mysql_query("SELECT id FROM users WHERE login='".mysql_real_escape_string($user)."' LIMIT 1");
		$fetch_user_id = @mysql_fetch_assoc($db_user_id);
		$user_id = $fetch_user_id['id'];
		#Марки радиоламп в таблице заказа. Индексы массива соответствуют id ламп в БД.
		$marks = array(
			2 => $_POST['mk_1'],
			3 => $_POST['mk_2'],
			4 => $_POST['mk_3'],
			5 => $_POST['mk_4']
		);
		#Установленные пользователем количества заказываемых ламп в таблице заказа.
		$counts = array(
			2 => $_POST['count_1'],
			3 => $_POST['count_2'],
			4 => $_POST['count_3'],
			5 => $_POST['count_4']
		);
		#Размер массива всех возможных для продажи марок ламп.
		$all_marks = sizeof($marks);
		#Массив для записи id всех возможных для продажи марок ламп.
		$ids = array();
		for ($i = 2; $i <= $all_marks+1; $i++)
		{
			$db_mark_id = @mysql_query("SELECT id FROM vt WHERE mark = '".$marks[$i]."' LIMIT 1");
			$data_mark = @mysql_fetch_assoc($db_mark_id);
			$ids[$i] =  $data_mark['id'];
		}
	
		$all_counts = sizeof($counts);
		for ($i = 2; $i <= $all_counts+1; $i++)
		{
			#Отсеиваем марки ламп, которые пользователь не стал заказывать, т.е. количество их = 0.
			if ($counts[$i] > 0) 
			{
				#Запись заказа пользователя в таблицу заказов.
				$db_insert_order = @mysql_query("INSERT INTO orders (id, vtId, userId, count, date) VALUES(NULL, '".$ids[$i]."', '".$user_id."', '".$counts[$i]."', now())");
			}
		}
	}
	else echo 'no';
?>