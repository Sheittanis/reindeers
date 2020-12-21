<?php
error_reporting(E_ALL &~ E_DEPRECATED);
	$db = mysql_connect('mysql.hostinger.co.uk', 'u709899010_ab10', 'Databae123') or die('Could not connect: ' . mysql_error());
	mysql_select_db('u709899010_wk01t') or die('Could not select database');

	//Strings must be escaped to prevent SQL injection attack
	$Level = mysql_real_escape_string($_GET['Level'], $db);
	$Name = mysql_real_escape_string($_GET['Name'], $db);
	$Score = mysql_real_escape_string($_GET['Score'], $db);
	$hash = $_GET['hash'];

	$secretKey = "mySecretKey"; # Must be the same as in your code!

	$real_hash = md5($Level . $Name . $Score . $secretKey); #Generates an MD5 hash of the
								#level name and score
	if($real_hash == $hash){
		// Send variables for MySQL database class.
		$query = "insert into HANDINSCORES values (NULL, '$Level', '$Name', '$Score');";
		$result = mysql_query($query) or die('Query failed: ' . mysql_error());
	}
?>