<?php

$servername = "localhost";
$username = "pixelb5_rey";
$password = "Romans828#";
$dbname = "pixelb5_wpSite";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}