<?php
$fileName="./files/jw.xml";
header("Content-Type: text/xml");
header("Content-Length: " . strlen(file_get_contents($fileName)));
header("Cache-Control: no-cache");
readfile($fileName);
?>