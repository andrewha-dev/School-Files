$(document).ready(function(){
	$('#loader').click(function(){
		$('#readIt').load("Lorem.txt", function(){
			console.log("Load Completed")
		})
	
	});

	
});