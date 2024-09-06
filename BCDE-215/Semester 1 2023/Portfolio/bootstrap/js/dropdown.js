$(document).ready(function () {
	$(".dropdown").on("hide.bs.dropdown", function () {
		$(".btn").html('AWS Setup <span class="caret"></span>');
	});
	$(".dropdown").on("show.bs.dropdown", function () {
		$(".btn").html('AWS Setup <span class="caret caret-up"></span>');
	});
});
