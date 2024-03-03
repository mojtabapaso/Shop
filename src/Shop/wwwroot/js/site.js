$(document).ready(function () {
	$(".dropdown-content a").click(function () {
		var selectedTagName = $(this).text();
		var selectedTagId = $(this).attr("value");

		$("#Tag-name").val(selectedTagName);
		$("#Tag-id").val(selectedTagId);
	});
});