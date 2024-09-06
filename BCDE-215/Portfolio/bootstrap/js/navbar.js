$(document).ready(function () {
	$(".dropdown").on("show.bs.dropdown", function (event) {
		var x = $(event.relatedTarget).text(); // Get the button text
	});
});
