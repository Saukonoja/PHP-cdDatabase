﻿<?php

function __autoload($class_name){
        require_once $class_name .'.class.php';
}

session_start();
require_once("db-init-music.php");

include("select-queries/all-albums-query.php");

include("header.php");

$result = $conn->query($sql);

echo '<h1>Albums</h1>';
if ($result->num_rows > 0) {

    echo '<table class="query">';
    echo '<tr><th><a href="?sort=album&sort_by='.$sort_order.'" id="headerLink">Album</a></th>
    		  <th><a href="?sort=artist&sort_by='.$sort_order.'" id="headerLink">Artist</a></th>
    		  <th><a href="?sort=year&sort_by='.$sort_order.'" id="headerLink">Year</a></th>
    		  <th><a href="?sort=company&sort_by='.$sort_order.'" id="headerLink">Record company</a></th></tr>';
    while($row = $result->fetch_assoc()) {  	
        $newAlbum = new Album($row["album"], $row["artist"], $row["year"], $row['company']);
        echo $newAlbum;
    }
    echo '</table>';
} else {
    echo "0 results";
}
$conn->close();

include("footer.php");

?>