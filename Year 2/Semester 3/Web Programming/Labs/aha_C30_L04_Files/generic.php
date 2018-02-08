<?php
$GetWhat=$_POST["param1"];
header("Content-Type: text/xml");
header("Content-Length: " . strlen(file_get_contents($GetWhat)));
header("Cache-Control: no-cache");
readfile($GetWhat);
?>