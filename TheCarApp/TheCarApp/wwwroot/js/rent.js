function updateMainImage(element) {
    var mainImage = document.getElementById('mainImage');
    mainImage.src = element.src;  // Updates the source of the main image to the clicked thumbnail's source
}

document.getElementById('endDate').addEventListener('change', calculatePrice);
document.getElementById('startDate').addEventListener('change', calculatePrice);

function calculatePrice() {
    var startDate = new Date(document.getElementById('startDate').value);
    var endDate = new Date(document.getElementById('endDate').value);
    var today = new Date();
    today.setHours(0, 0, 0, 0); // Normalize today date to remove time part

    var errorDiv = document.getElementById('error');
    var totalPriceDiv = document.getElementById('totalPrice');

    // Clear previous messages
    errorDiv.innerHTML = '';
    totalPriceDiv.innerHTML = '';

    // Check if start date is before today's date
    if (startDate < today) {
        errorDiv.innerHTML = 'Error: Start date cannot be before today.';
        return;
    }

    // Check if the end date is before the start date
    if (endDate <= startDate) {
        errorDiv.innerHTML = 'Error: End date must be after the start date.';
        return;
    }

    // Calculate the total days
    var timeDiff = endDate - startDate;
    var days = Math.ceil(timeDiff / (1000 * 3600 * 24));

    // Assuming price per day is fetched from the model or defined in your script
    var pricePerDay = @Model.Car.PricePerDay; // Use the server-side price per day
    var totalPrice = days * pricePerDay;
    totalPriceDiv.innerHTML = 'Total Price: $' + totalPrice;
}