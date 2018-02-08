$(document).ready(function(){
	$("input").click(function(){
		updateFile($(this).val());
	});
})

function updateFile(_file)
{
	var url = "files/" +  _file;
	console.log(url);
	$.post("generic.php", 
	{param1: url})
}