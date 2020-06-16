<?php
$servername = "3.128.7.77";
$username = "admin";
$password = "Alohomora01";
$dbname = "database1";

try {
  $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
  
  // set the PDO error mode to exception
  $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

  $stmt = $conn->prepare(('UPDATE encomendas SET codigoRastreio= :codigoRastreio, empresa= :empresa, WHERE id = :id'));

  $stmt->bindParam(':id', $id);
  $stmt->bindParam(':codigoRastreio', $codigoRastreio);
  $stmt->bindParam(':empresa', $empresa);
  $stmt->bindParam('stats',$stats);

   $id = 1;
   $codigoRastreio = "22313";
   $empresa = "amazon";
   $stats = "registro";
   $stmt->execute();

echo "update successfully"; 
} catch(PDOException $e) {
  echo 'Error: ' . $e->getMessage();
}
$conn = null;
?>
