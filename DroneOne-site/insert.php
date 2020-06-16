 <?php
$servername = "3.128.7.77";
$username = "admin";
$password = "Alohomora01";
$dbname = "database1";

try {
  $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
  // set the PDO error mode to exception
  $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

  // prepare sql and bind parameters
  $stmt = $conn->prepare(('UPDATE usuarios SET nome=:fnome, usuario=:fusuario, sexo=:fsexo, cep=:fcep WHERE id=2'));
  
  $stmt->bindParam(':fnome', $nome);
  $stmt->bindParam(':fusuario', $usuario);
  $stmt->bindParam('fsexo',$sexo);
  $stmt->bindParam('fcep',$cep);

  // insert a row
  $nome = $_GET['fnome'];
  $usuario = $_GET['fusuario'];
  $sexo = $_GET['fsexo'];
  $cep = $_GET['fcep'];
  $stmt->execute();

  echo "update successfully";
} catch(PDOException $e) {
  echo "Error: " . $e->getMessage();
}
$conn = null;
?> 