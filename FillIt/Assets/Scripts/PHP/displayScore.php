<?php

$db  =  mysql_connect('localhost','mryeis', 'yeis1234') or die ("COuld not connect". mysql_error());
mysql_select_db('mryeis_Fillit') or die ('Could not select database');

$query = " SELECT * FROM 'Scores'   ORDER BY Score DESC LIMIT 100 ";
$result = mysql_query($query) or die ('Query Failed'.mysql_error());


$num_results = mysql_num_rows($result);

for($i = 0 ; $i < $num_results ; $i++)
{
    $row = mysql_fetch_array($result);
    echo $row["ScoreID"] . ";" . $row["UserID"] . ";" . $row["Username"] . ";" . $row["Score"] . ";" . $row["Date"] . ";" ;
}


?>