<?php

$servername = "localhost";
$username = "pixelb5_rey";
$password = "Romans828#";
$dbname = "pixelb5_wpSite";

$conn = connectToDatabase($servername, $username, $password, $dbname);

function connectToDatabase($servername, $username, $password, $dbname)
{
    $con = new mysqli($servername, $username, $password, $dbname);
    // Check connection
    if ($con->connect_error) 
    {
        die("Connection failed: " . $conn->connect_error);
    }
    
    return $con;
}