<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous">

    <title>Atualize Dados</title>
  </head>
  <body>
     <center>
    <h1>Atualize Dados</h1>
   <br>
  <form action="insert.php" method="get">

  
  <label for="fnome">NOME:</label>
  <input type="text" id="fnome" name="fnome"><br><br>
  <label for="fusuario">USUARIO:</label>
  <input type="text" id="fusuario" name="fusuario"><br><br>
 
  <div class="form-check">
  <input class="form-check-input" type="radio" name="fsexo" id="fsexo" value="Masculino" checked>
  <label class="form-check-label" for="fsexoM">Masulino</label><br>
  </div>
  <div class="form-check">
  <input class="form-check-input" type="radio" name="fsexo" id="fsexo" value="Feminino" checked>
  <label class="form-check-label" for="fsexoF">Feminino</label><br>
  </div>
  <div class="form-check">
  <input class="form-check-input" type="radio" name="fsexo" id="fsexo" value="Nao definido" checked>
  <label class="form-check-label" for="fsexoN">Nao definido</label><br><br>
  </div>

  <label for="fcep">CEP:</label>
  <input type="text" id="fcep" name="fcep"><br><br>

  <input type="submit" name="submit" value="Atualizar"><br><br>
  </form>

<?php
$servername = "3.128.7.77";
$username = "admin";
$password = "Alohomora01";
$dbname = "database1";

echo "<table style='border: solid 1px black;'>";
echo "<tr><th>ID</th><th>nome</th><th>usuario</th><th>Sexo</th><th>cep</th></tr>";

class TableRows extends RecursiveIteratorIterator {
  function __construct($it) {
    parent::__construct($it, self::LEAVES_ONLY);
  }

  function current() {
    return "<td style='width:150px;border:1px solid black;'>" . parent::current(). "</td>";
  }

  function beginChildren() {
    echo "<tr>";
  }

  function endChildren() {
    echo "</tr>" . "\n";
  }
} 

try {
  $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
  
  // set the PDO error mode to exception
  $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

  $stmt = $conn->prepare(('select id, nome, usuario, sexo, cep from usuarios'));
  $stmt->execute();

 $result = $stmt->setFetchMode(PDO::FETCH_ASSOC);
  foreach(new TableRows(new RecursiveArrayIterator($stmt->fetchAll())) as $k=>$v) {
    echo $v;
  } 
} catch(PDOException $e) {
  echo 'Error: ' . $e->getMessage();
}
$conn = null;
?>
</center>
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js" integrity="sha384-DfXdz2htPH0lsSSs5nCTpuj/zy4C+OGpamoFVy38MVBnE+IbbVYUew+OrCXaRkfj" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js" integrity="sha384-Q6E9RHvbIyZFJoft+2mJbHaEWldlvI9IOYy5n3zV9zzTtmI3UksdQRVvoxMfooAo" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js" integrity="sha384-OgVRvuATP1z7JjHLkuOU7Xw704+h835Lr+6QL9UvYjZE3Ipu6Tp75j7Bh/kR0JKI" crossorigin="anonymous"></script>
  </body>
</html>