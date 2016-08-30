
<?php


//inicializar la conexcion con la base de datos 
$db =mysql_connect('localhost', 'Mryeis','yeis1234') or die ('Could not connect:  '.mysql_error());
mysql_select_db('mryeis_Fillit') or die ('Could not select database');


//usamos la funcion escape para evitar SQL injection
$userID = mysql_real_escape_string($_GET['UserID'],$db);
$username = mysql_real_escape_string($_GET['Username'],$db);
$score = mysql_real_escape_string($_GET['Score'],$db);
$date = date('Y-m-d H:i:s');

//NO DEL TODO SEGURO PARA QUE SIRVE EL HASH 
$hash = _GET['hash'];
$secretkey = "woloolow";
$real_hash = md5($userID . $username . $score . $date . $secretkey);

if($real_hash == $hash)
{
    //hacemos el query 
    $query = "insert into scores values (NULL , '$userID' , '$username' , '$score' ,'$date' );";
    $result = mysql_query($query) or die ('Query Failed: ', mysql_error());
}
    
    

?>