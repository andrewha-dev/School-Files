<?php
$SportsLeague=$_GET["sport"];
header("Content-Type: text/xml");
header("Content-Length: " . strlen(file_get_contents($SportsLeague)));
header("Cache-Control: no-cache");
readfile($SportsLeague);
?>