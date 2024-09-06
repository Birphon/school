// Define a function to toggle the navigation menu on mobile screens
function toggleNav() {
	var nav = document.querySelector("nav");
	nav.classList.toggle("active");
}

// Attach a click event listener to the hamburger menu icon
var hamburger = document.querySelector(".hamburger");
hamburger.addEventListener("click", toggleNav);

// Define a function to display a modal dialog when a product is clicked
function showModal(event) {
	// Prevent the default link behavior
	event.preventDefault();

	// Get the product details from the clicked link
	var link = event.target;
	var product = link.closest(".product");
	var image = product.querySelector(".product-image").innerHTML;
	var name = product.querySelector(".product-name").innerHTML;
	var price = product.querySelector(".product-price").innerHTML;

	// Create the modal dialog content
	var content = '<div class="modal-image">' + image + "</div>";
	content += '<div class="modal-details">';
	content += "<h3>" + name + "</h3>";
	content += "<p>" + price + "</p>";
	content += '<button class="button">Buy Now</button>';
	content += "</div>";

	// Create and display the modal dialog
	var modal = document.createElement("div");
	modal.classList.add("modal");
	modal.innerHTML = content;
	document.body.appendChild(modal);

	// Attach a click event listener to the Buy Now button to close the modal dialog
	var closeButton = modal.querySelector(".button");
	closeButton.addEventListener("click", function () {
		modal.remove();
	});
}

// Attach a click event listener to all product links
var productLinks = document.querySelectorAll(".product-link");
productLinks.forEach(function (link) {
	link.addEventListener("click", showModal);
});
