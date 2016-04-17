﻿<?php
include("header.php");
function __autoload($class_name){
        require_once $class_name .'.class.php';
}

require_once("db-init-music.php");

include("select-queries/all-tracks-query.php");



$trackPage = 0;

if(isset($_GET["page"])){
    $page = $_GET["page"];

    if($page == "" || $page == "1"){
        $page1 = 0;
        $trackPage = $page1;
    } else{
        $page1 = ($page * 10) - 10;
        $trackPage = $page1;
    }   
} else{
    $page = 1;
}

$sort = (isset($_GET['sort'])) ? $_GET['sort'] : 'track';  

include("sort.php");

$sql =
"select 
        kappale.nimi as track,
        esittaja.nimi as artist,
        cd.nimi as album,
        vuosi.vuosi as year
from cd
left join cd_kappale on cd_kappale.cd_avain = cd.avain
left join kappale on cd_kappale.kappale_avain = kappale.avain
left join esittaja on kappale.esittaja_avain = esittaja.avain
left join vuosi on kappale.vuosi_avain = vuosi.avain
order by $sort $sort_order
limit $trackPage,10;";

$_SESSION['current'] = "Tracks";

require_once("db-init-music.php");

include("select-queries/all-tracks-query.php");

include("tracks-table.php");

include("footer.php");

?>
