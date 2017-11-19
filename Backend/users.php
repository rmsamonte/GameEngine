<?php

include 'dbConnect.php';

$sql = "SELECT * FROM users";
getUserData($conn, $sql);

function getUserData($conn, $query)
{
    $result = $conn->query($query);
    if ($result->num_rows > 0) 
    {
        // output data of each row
        $return_arr = array();
        $return_arr = $result->fetch_all(MYSQLI_ASSOC);

        echo json_encode(array('array' => $return_arr));
    } 
    else 
    {
        echo "0 results";
    }
    $conn->close();
}