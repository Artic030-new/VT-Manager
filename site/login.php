<?
	@mysql_set_charset('utf8');
    include("db.php");
    $link = @mysql_connect($server, $user, $pass);
    if(!@mysql_select_db($database)) die(mysql_error());
    $query = @mysql_query("SELECT id, pass FROM users WHERE login='".mysql_real_escape_string($_POST['login'])."' LIMIT 1");
    $data_login = @mysql_fetch_assoc($query);
    $hashed = hash('sha256',($_POST['password']));
	$banned = @mysql_query("SELECT ban FROM users WHERE login='".mysql_real_escape_string($_POST['login'])."' LIMIT 1");
	$data_ban = @mysql_fetch_assoc($banned);
    if(isset($_POST['loginn']))
    {
        if($data_login['pass'] === $_POST['password'])
        {
			if($data_ban['ban'] == '1')
			{
				echo "<script>self.location='banned.html';</script>";
			}
			else $user = $_POST['login'];
        }
        else
        {
            echo "<script>self.location='error.html';</script>";
        }
    }
	else echo 'no';
?>
<!DOCTYPE html>
<!--By Fedorenkov Arthur, KTK, 3IS, #last edit: 16:55@02.04.2020# Oh, yeah!1-->
<html lang="en">
<head>
	<meta charset="UTF-8"/>
	<title>VT Energistics</title>
	<link rel="stylesheet" type="text/css" href="css/styles.css"/> 
	<link rel="stylesheet" type="text/css" href="sli/sli.css"/>
	<link href="https://fonts.googleapis.com/css?family=Varela+Round&display=swap" rel="stylesheet">
	<script src="sli/sli.js"></script>
	<script src="js/cart_summator.js"></script>
	<script  src="js/show.js"></script>
</head>
<body>
	<header class="header">
		<div class="base">
			<div class="header__inner">
				<nav>
					<div class="header__logo"><img id="logo"src="imgs/vtv2.svg"></div>
					<div class="header__text"><h4>VT Energistics</h4></div>
				</nav>
				<nav>
					<a class="nav__link" href="#">О заводе</a>
					<a class="nav__link" href="#">Продукция</a>
					<a class="nav__link" href="#">Новости</a>
					<a class="nav__link" href="#">Как купить</a>
					<a class="nav__link" href="#">Контакты</a>
				</nav>
			</div>
		</div>
	</header>
	<div class="content">
		<div class="base">
			<div class="content__main">
			<div class="content__main_left"></div>
				<div class="content__main_center">
					<div class="_center_slider">
						<center>
								<div class="ism-slider" data-play_type="loop" data-buttons="false" id="my-slider">
								  <ol>
									  <li>
										  <img src="sli/slides/1.jpg">
										  <div class="ism-caption ism-caption-0">Ламповый звук</div>
									  </li>
									  <li>
										  <img src="sli/slides/2.jpg">
										  <div class="ism-caption ism-caption-0">Линейные ускорители</div>
									  </li>
									  <li>
										  <img src="sli/slides/3.jpg">
										  <div class="ism-caption ism-caption-0">Радиоаппаратура</div>
									  </li>
									  <li>
										  <img src="sli/slides/4.jpg">
										  <div class="ism-caption ism-caption-0">Радары</div>
									  </li>
								  </ol>
								</div>
						</center>
					</div>
					<div class="_center_content" id="center_content" style="display:none;">
						<center>
								<div class="h">Оформить заказ</div>
									<hr>
									<div class="order_container" >
										<form id="send" name="send" action="order.php" method="post" >
											<input id="acc" name="user" type="text"  value="<?php echo $user;?>"hidden>
											<table id="divtable" name="order_data" border="0" color="White">
												<tr>
													<th>Название радиолампы</th>
													<th>Цена за ед.</th>
													<th>Количество</th>
													<th>Сумма</th>
												</tr>
												<tr>
													<td><input readonly id="mk_1" name="mk_1" value="6К4" type="text"></td>
													<td><input readonly id="price_1" value="130" type="number">руб.</td>
													<td><input id="count_1" name="count_1" type="number" oninput="add(1)" value="1"></td>
													<td><b><output id="result_1"></output></b>руб. </td>
												</tr>
												<tr>
													<td><input readonly id="mk_2" name="mk_2" value="6К7" type="text"></td>
													<td><input readonly id="price_2" value="160" type="number">руб.</td>
													<td><input id="count_2" name="count_2" type="number" oninput="add(2)" value="1"></td>
													<td><b><output id="result_2"></output></b>руб. </td>
												</tr>
												<tr>
													<td><input readonly id="mk_3" name="mk_3" value="6Ж3" type="text"></td>
													<td><input readonly id="price_3" value="190" type="number">руб.</td>
													<td><input id="count_3" name="count_3" type="number" oninput="add(3)" value="1"></td>
													<td><b><output id="result_3"></output></b>руб. </td>
												</tr>
												<tr>
													<td><input readonly id="mk_4" name="mk_4" value="6С1П" type="text"></td>
													<td><input readonly id="price_4" value="260" type="number"> руб.</td>
													<td><input id="count_4" name="count_4" type="number" oninput="add(4)" value="1"></td>
													<td><b><output id="result_4"></output></b>руб. </td>
												</tr>
												<tr>
													<td colspan="2">Итого: <b id="total">0</b> руб.</td>	
													<td colspan="2"><input type="submit" name="order" value="Заказать"></td>
												</tr>
											</table>
										</form>
									</div>
						</center>
					</div>
				</div>
				<div class="content__main_right">
					<div class="_right_auth">
						<div class="_auth_header"><text id="user">Добро пожаловать, <?php echo $user;?>!</text></div>
						<div class="user_content">
							<div class="_content_profile">
								<div class="_profile_icon"></div>
								<div class="_profile_links">
									
									<table name="links" id="divtable" border="0">
										<tr>
											<td><a href="#">Поставки</a></td>
											<td><a href="#">Сообщения</a></td>
										</tr>
										<tr>
											<td><a href="#">Акции</a></td>
											<td><a href="#">Выйти</a></td>
										</tr>
									</table>
								</div>
							</div>
							<center>
								<table name="iconifiedlinks" id="iconified_links" border="0">
									<tr>
										<td><span class="i" id="profile"></span><a href="#">Профиль</a></td>
										<td><span class="i" id="search"></span><a href="#">Поиск</a></td>
									</tr>
									<tr>
										<td><span class="i" id="balance"></span><a href="#">Баланс</a></td>
										<td><span class="i" id="promo"></span><a href="#">Промокоды</a></td>
									</tr>
									<tr>
										<td><span class="i" id="orders"></span><a onclick="show()" href="#">Заказы</a></td>
										<td><span class="i" id="forum"></span><a href="#">Форум</a></td>
									</tr>
									<tr>
										<td><span class="i" id="active"></span><a href="#">Активность</a></td>
										<td><span class="i" id="help"></span><a href="#">Помощь</a></td>
									</tr>
								</table>
							</center>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<footer>
		<div class="footer_text"><font color="white">VT Energistics. &copy 2020 By Artic030 and all red-eyed evenings.</font></div>
	</footer>
</body>
</html>