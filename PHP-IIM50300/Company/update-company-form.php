﻿<?php 
include ("../Init/header.php"); 

require_once($dbInit);

$id = $_POST['ID'];


$sql="SELECT yhtio.avain as id, yhtio.nimi as nimi, vuosi.vuosi as vuosi, maa.nimi as maa
     FROM yhtio
     left join vuosi on yhtio.vuosi_avain = vuosi.avain
     left join maa on yhtio.maa_avain = maa.avain
     WHERE yhtio.avain = '$id';";
$result = $conn->query("$sql");

if ($row = $result->fetch_assoc()){
  ?>
    <form action='<?php echo $companies ?>'><button id='btnBack' class='buttons'><i id="backIcon" class="fa fa-arrow-left fa-lg"></i></button></form>
    <div id="updateForm">
      <h1>Update company</h1>
      <form method='post' action='update-company.php'>
          <table border='0' cellpadding='5'>
            <tr id='hiddenTr' valign='top'>
              <td align='right'>ID</td>
              <td><?php echo $row['id']?><input type='hidden' name='id' size='30' value='<?php echo $row['id']?>'></td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Name</td>
              <td><input type='text' name='nimi' size='30' value='<?php echo $row['nimi']?>'></td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Year</td>
              <td>
                <select name='vuosi' id="comboYear"> <option value='<?php echo $row['vuosi']?>' selected><?php echo $row['vuosi']?></option>
              <?php 
                $combo = $conn->query('select vuosi from vuosi order by vuosi desc');
                while($crow = $combo->fetch_assoc()){
              ?>
            <option value ='<?php echo $crow['vuosi']?>'><?php echo $crow['vuosi']?></option>
          <?php } ?> 
          </select>
        </td>
            </tr>
            <tr valign='top'>
              <td align='right' style="color: white;">Country</td>
              <td>
                <select name='maa' id="comboCountry"> <option value='<?php echo $row['maa']?>'><?php echo $row['maa']?></option>
              <?php 
                $combo = $conn->query('select nimi from maa');
                while($crow = $combo->fetch_assoc()){
              ?>
            <option value ='<?php echo $crow['nimi']?>'><?php echo $crow['nimi']?></option>
          <?php } ?> 
          </select>
        </td>
            </tr>
          </table>
        <input type='submit' name='action' value='Save changes' class='buttons' id='updateButton' onclick="javascript: return confirm('Update company <?php echo $row['nimi'] ?> ?')">
        <input type='submit' name='action' value='Delete company' class="buttons" id="deleteButton" onclick="javascript: return confirm('Delete company <?php echo $row['nimi'] ?> ?')"><br>
      </form>
    </div>  
 <?php   
}
include ($footer); 

?>