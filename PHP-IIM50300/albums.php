﻿<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

$_SESSION['current'] = "Albums";

require_once("db-init-music.php");

include("select-queries/all-albums-query.php");

$result = $conn->prepare($sql);
$result -> execute();

include("albums-table.php");

include("footer.php");

?>