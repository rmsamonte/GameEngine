<?php

include 'dbConnect.php';

$sql = "SELECT * FROM users";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
    // output data of each row
    $return_arr = array();
    $return_arr = $result->fetch_all(MYSQLI_ASSOC);

    echo json_encode($return_arr);
} else {
    echo "0 results";
}
$conn->close();