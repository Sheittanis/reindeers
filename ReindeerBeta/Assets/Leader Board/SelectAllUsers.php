<?php
error_reporting(E_ALL &~ E_DEPRECATED);
	$database = mysql_connect('mysql.hostinger.co.uk', 'u709899010_ab10', 'Databae123') or die('Could not connect: ' . mysql_error());
	mysql_select_db('u709899010_wk01t') or die('Could not select database');

	//Make query
	$query = "SELECT * FROM HANDINSCORES ORDER by Level, Score Desc, ID";
	//Run query
	$result = mysql_query($query) or die('Query failed: ' . mysql_error());

	//Get the number of returned rows
	$num_results = mysql_num_rows($result);

	//For each row print tupleto page
	for($i = 0; $i < $num_results; $i++)
	{
		$row = mysql_fetch_array($result); //Get the data
		//Print the data
		echo $row['Level'] ."\t". $row['Name'] . "\t" . $row['Score'] . "\n";
	}
?>