$("input").change(function(){
	$.get("servertime.php", function(data){
		$("#time").text(data)
	})
})