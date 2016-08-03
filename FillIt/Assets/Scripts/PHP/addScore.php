<?php

// Create connection
$conn = new mysqli("localhost", "Mryeis", "yeis1234", "mryeis_Fillit");
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 

$userID = "";
$username = "";
$Score=  1100;
$pass = "";

$Date;
$query =  "INSERT INTO Scores (UserID , Username, Score,Date)
VALUES ('".$usrID."', '".$username."', '".$Score."', '".$Date."')";

if ($conn->query($sql) === TRUE) {
    echo "New User created successfully";
} else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}

$conn->close();

?>