<?php

// Create connection
$conn = new mysqli("localhost", "Mryeis", "yeis1234", "mryeis_Fillit");
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$username = "";
$pass = "";
$email = "@";
$level = 1;
$elo_value = 100;
$Date;
$query =  "INSERT INTO Users (Username, password, Level,elo_value,email,initial_date)
VALUES ('".$username."', '".$pass."', '".$level."', '".$elo_value."', '".$email."', CURDATE())";
$result = mysql_query($query) or die('Query failed: ' . mysql_error());
//if ($conn->query($query) === TRUE) {
  //  echo "New User created successfully";
//} else {
  //  echo "Error: " . $sql . "<br>" . $conn->error;
//}

$conn->close();

?>