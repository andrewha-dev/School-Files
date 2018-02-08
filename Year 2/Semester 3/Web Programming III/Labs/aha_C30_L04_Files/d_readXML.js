$(document).ready(function () {
        $("input").change(function () {
			var thename = $("input:checked").val();
            var file = "files/" + thename;
            $.post("generic.php", {
                param1: file
            }, function(data) {
                console.log(data);
            })
        });
    });